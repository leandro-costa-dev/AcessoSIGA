using System;
using System.Text;

namespace AcessoSIGA
{
    
    public class CtrChamado
    {
        //Abertura de chamado via webservice
        public Ticket GravarChamados(Ticket ticket)
        {
            string operacao = "addTicketByEndUser";
            //string operacao = "addTicketByData";
            string wsdl_file = "WSTicket";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_addTicketByEndUser(ticket);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS gravar chamado ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                Ticket ticket_ret = new Ticket();
                RetornarXML retornarXML = new RetornarXML();
                ticket_ret = retornarXML.RetornarChamado(wsRetorno);

                //Atualiza dados do retorno do chamado
                ticket.cdChamado = ticket_ret.cdChamado;
                ticket.cdSituacao = ticket_ret.cdSituacao;
                ticket.nmSituacao = ticket_ret.nmSituacao;
                ticket.dataChamado = ticket_ret.dataChamado;

                //Envia o anexo para o chamado aberto
                EnviarAnexoAsync(ticket);

                //Gravar chamado no banco de dados
                ChamadoDAO chamadoDAO = new ChamadoDAO();
                chamadoDAO.GravarChamado(ticket);
            }

            return ticket;
        }

        //Enviar para webservice o arquivo anexo do chamado
        public async Task EnviarAnexoAsync(Ticket ticket)
        {
            if (String.IsNullOrEmpty(ticket.anexo))
            {
                return;
            }
            else
            {
                string operacao = "addAttachment";
                string wsdl_file = "WSTicket.wsdl";

                //Gera o XML de envio para o webservice
                WSTicket wSTicket = new WSTicket();
                string xml = wSTicket.XML_addAttachment(ticket);

                //Instancia o webservice passando os dados
                WService wService = new WService(operacao, wsdl_file, xml);

                //Envia a requisição POST e faz a leitura do XML de retorno
                string wsRetorno = await wService.PostAsync();
            }
        }

        //Atualização geral de chamados do contato
        public void AtualizaChamadosContato(Cliente cliente, Contato contato)
        {
            string operacao = "getTicket";
            string wsdl_file = "WSTicket.wsdl";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_getTicket(cliente, contato);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS atualização geral de chamados do contato ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                List<Ticket> listaTicket = new List<Ticket>();
                RetornarXML retornarXML = new RetornarXML();
                listaTicket = retornarXML.retornarListaChamadosContato(wsRetorno);

                List<Historico> listaHistorico = new List<Historico>();
                CtrHistorico ctrHistorico = new CtrHistorico();

                ChamadoDAO chamadoDAO = new ChamadoDAO();
                HistoricoDAO historicoDAO = new HistoricoDAO();

                foreach (Ticket t in listaTicket)
                {
                    Ticket ticket = new Ticket();
                    
                    listaHistorico = ctrHistorico.ConsultarHistoricoChamado(t.cdChamado);
                    ticket = ConsultarDadosChamado(t.cdChamado);

                    //Atualiza informações do chamado
                    chamadoDAO.GravarChamado(ticket);

                    //Verifica se existe novo registro e grava histórico do chamado 
                    historicoDAO.GravarHistorico(listaHistorico);
                }
            }
        }

        //Consulta webservice de dados adicionais do chamado informado
        public Ticket ConsultarDadosChamado(int cdChamado)
        {
            Ticket ticket = new Ticket();

            string operacao = "getTicketData";
            string wsdl_file = "WSTicket.wsdl";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_getTicketData(cdChamado);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS consulta dados do chamado ", "XML de retorno vazio ou nulo!");                
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                RetornarXML retornarXML = new RetornarXML();
                ticket = retornarXML.RetornarDadosChamado(wsRetorno);
            }
            return ticket;
        }
    }
}
