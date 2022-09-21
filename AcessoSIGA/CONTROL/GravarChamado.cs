using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class GravarChamado
    {
        //Abertura de chamado
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
                Util.GravarLog("Gravar chamado ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                Ticket ticket_ret = new Ticket();
                ticket_ret = RetornarXML.retornarChamado(wsRetorno);

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

        //Enviar o arquivo anexo para o chamado
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

        //Consulta geral de chamados
        public List<Ticket> consultarChamados(string dtInicio, string dtFim)
        {
            List<Ticket> lista = new List<Ticket>();

            Ticket ticket = new Ticket();

            ticket.cdCliente = 2; //Codigo do Cliente Ex: GOVSUL=106941 ou 1726182 GOVBR=2
            ticket.cdContato = 48; //Codigo do Contato Ex: GOVSUL=23 ou 444 GOVBR=47
            ticket.idTIpoPeriodo = 1; //1-data de abertura, 2-data de término, 3-data de previsão de resposta, 4-data de previsão de término.
            ticket.dtPeriodo1 = dtInicio;
            ticket.dtPeriodo2 = dtFim;

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
                Util.GravarLog("Consulta do chamado ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                lista = RetornarXML.retornarListaChamados(wsRetorno);
            }
            return lista;
        }

        //Consultar histórico do chamado informado
        public List<Historico> consultarHistoricoChamado(int cdChamado)
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
                Util.GravarLog("Consulta histórico do chamado ", "XML de retorno vazio ou nulo!");                
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                lista = RetornarXML.retornarHistoricoChamado(wsRetorno);
            }
            return lista;
        }

        //Consulta dados adicionais do chamado informado
        public Ticket consultarDadosChamado(int cdChamado)
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
                Util.GravarLog("Consulta dados do chamado ", "XML de retorno vazio ou nulo!");                
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                ticket = RetornarXML.retornarDadosChamado(wsRetorno);
            }
            return ticket;
        }
    }
}
