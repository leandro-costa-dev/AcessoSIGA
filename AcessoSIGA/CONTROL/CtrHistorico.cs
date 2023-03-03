using System;

namespace AcessoSIGA
{
    public class CtrHistorico
    {
        //Atualiza o registro de históricos no banco de dados
        public void AtualizaHistoricoChamados()
        {
            List<Ticket> listaTicket_ret = new List<Ticket>();

            List<Ticket> listaTicket = new List<Ticket>();
            List<Historico> listaHistorico = new List<Historico>();

            CtrChamado ctrChamado = new CtrChamado();

            ChamadoDAO chamadoDAO = new ChamadoDAO();
            HistoricoDAO historicoDAO = new HistoricoDAO();

            listaTicket = chamadoDAO.ConsultaChamadosAtivos();

            Ticket ticket = new Ticket();

            foreach (Ticket t in listaTicket)
            {                
                listaHistorico = ConsultarHistoricoChamado(t.cdChamado);
                ticket = ctrChamado.ConsultarDadosChamado(t.cdChamado);

                //Atualiza informações do chamado
                chamadoDAO.GravarChamado(ticket);

                //Verifica se existe novo registro e grava histórico do chamado 
                historicoDAO.GravarHistorico(listaHistorico);
            }
        }

        //Consultar webservice de histórico do chamado informado
        public List<Historico> ConsultarHistoricoChamado(int cdChamado)
        {
            List<Historico> lista = new List<Historico>();

            Historico historico = new Historico();

            Ticket ticket = new Ticket();

            string operacao = "getTicketHistoryData";
            string wsdl_file = "WSTicket.wsdl";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_getTicketHistoryData(cdChamado);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST_XML();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS consulta histórico do chamado ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                RetornarXML retornarXML = new RetornarXML();
                lista = retornarXML.RetornarHistoricoChamado(wsRetorno);
            }
            return lista;
        }

        //Retorna o historico se acompanhamento for diferente de rascunho
        // e se o histórico ainda não foi visualizado 
        public List<Historico> ConsultaNovoHistorico()
        {
            List<Historico> listaHistorico = new List<Historico>();

            HistoricoDAO historicoDAO = new HistoricoDAO();
            List<Historico> lista = historicoDAO.ConsultaHistorico();

            foreach (Historico h in lista)
            {
                if (h.cdAcompanhamento != 1 && h.controle == 0)
                {
                    ChamadoDAO chamadoDAO = new ChamadoDAO();
                    
                    Ticket ticket = new Ticket();
                    ticket = chamadoDAO.ConsultaChamado(h.cdChamado);

                    ParametrosDAO parametrosDAO = new ParametrosDAO();
                    Parametros parametros = parametrosDAO.ConsultarParametros();

                    //Verificar se o contato do chamado é igual ao gravado no parametro
                    if (ticket.cdContato == parametros.Contato.cdContato)
                    {
                        listaHistorico.Add(h);
                    }
                }
            }
            return listaHistorico;
        }
    }
}
