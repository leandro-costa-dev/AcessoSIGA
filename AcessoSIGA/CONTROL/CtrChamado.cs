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
                ticket_ret = RetornarXML.RetornarChamado(wsRetorno);

                //Atualiza dados do retorno do chamado
                ticket.cdChamado = ticket_ret.cdChamado;
                ticket.cdSituacao = ticket_ret.cdSituacao;
                ticket.nmSituacao = ticket_ret.nmSituacao;
                ticket.dataChamado = ticket_ret.dataChamado;

                //Envia o anexo para o chamado aberto
                EnviarAnexo(ticket);

                //Gravar chamado no banco de dados
                ChamadoDAO chamadoDAO = new ChamadoDAO();
                chamadoDAO.GravarChamado(ticket);
            }

            return ticket;
        }

        //Enviar para webservice o arquivo anexo do chamado
        public void EnviarAnexo(Ticket ticket)
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
                string wsRetorno = wService.RequisicaoPOST();
            }
        }

        //Consulta geral de chamados webservice
        public List<Ticket> ConsultaChamados()
        {
            List<Ticket> lista = new List<Ticket>();

            Ticket ticket = new Ticket();         

            string operacao = "getTicket";
            string wsdl_file = "WSTicket.wsdl";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_getTicket(ticket);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS consulta geral de chamados ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                lista = RetornarXML.retornarListaChamados(wsRetorno);
            }
            return lista;
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
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS consulta histórico do chamado ", "XML de retorno vazio ou nulo!");                
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                lista = RetornarXML.RetornarHistoricoChamado(wsRetorno);
            }
            return lista;
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
                ticket = RetornarXML.RetornarDadosChamado(wsRetorno);
            }
            return ticket;
        }
    }
}
