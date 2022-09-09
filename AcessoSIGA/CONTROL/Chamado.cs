using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Chamado
    {
        //Abertura de chamado
        public void GravarChamado(Ticket ticket, string arquivoAnexo, string descAnexo)
        {
            string operacao = "addTicketByData";
            string wsdl_file = "WSTicket";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_addTicketByData(ticket);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                MessageBox.Show("Ocorreu erro na conexão com WebService, verifique!", "Conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                ticket = RetornarXML.retornarChamado(wsRetorno);

                //Envia o anexo para o chamado aberto
                ticket.anexo = arquivoAnexo; //Arquivo anexo ao chamado
                ticket.dsAnexo = descAnexo; //Descrição do anexo
                EnviarAnexo(ticket);

                if (ticket.cdChamado > 0)
                {
                    MessageBox.Show("Chamado nº " + ticket.cdChamado + " cadastrado com sucesso!", "Sucesso!: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //Enviar o arquivo anexo para o chamado
        public void EnviarAnexo(Ticket ticket)
        {
            string operacao = "addAttachment";
            string wsdl_file = "WSTicket";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_addAttachment(ticket);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            //Lê XML de retorno e devolve os dados
            //contato = RetornarXML.retornarContatoEmpresa(wsRetorno);

        }

        //Consulta geral de chamados
        public List<Ticket> consultarChamados(string dtInicio, string dtFim)
        {
            List<Ticket> lista = new List<Ticket>();

            Ticket ticket = new Ticket();

            ticket.cdCliente = 2; //Codigo do Cliente Ex: GOVSUL=106941 ou 1726182 GOVBR=2
            ticket.cdContato = 47; //Codigo do Contato Ex: GOVSUL=23 ou 444 GOVBR=47
            ticket.idTIpoPeriodo = 1; //1-data de abertura, 2-data de término, 3-data de previsão de resposta, 4-data de previsão de término.
            ticket.dtPeriodo1 = dtInicio;
            ticket.dtPeriodo2 = dtFim;

            string operacao = "getTicket";
            string wsdl_file = "WSTicket";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_getTicket(ticket);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                MessageBox.Show("Ocorreu erro na conexão com WebService, verifique!", "Conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                lista = RetornarXML.retornarListaChamados(wsRetorno);
            }
            return lista;
        }

        //Consultar histórico do chamado informado
        public void consultarHistoricoChamado(int cdChamado)
        {
            List<Historico> lista = new List<Historico>();

            Historico historico = new Historico();

            Ticket ticket = new Ticket();

            string operacao = "getTicketHistoryData";
            string wsdl_file = "WSTicket";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_getTicketHistoryData(cdChamado);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                MessageBox.Show("Ocorreu erro na conexão com WebService, verifique!", "Conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                lista = RetornarXML.retornarHistoricoChamado(wsRetorno);

                ticket = consultarDadosChamado(cdChamado);

                Frm_Historico_Detalhe f = new Frm_Historico_Detalhe(lista, cdChamado, ticket.dsChamado, ticket.dataChamado);
                f.ShowDialog();
            }
        }

        //Consulta dados adicionais do chamado informado
        public Ticket consultarDadosChamado(int cdChamado)
        {
            Ticket ticket = new Ticket();

            string operacao = "getTicketData";
            string wsdl_file = "WSTicket";

            //Gera o XML de envio para o webservice
            WSTicket wSTicket = new WSTicket();
            string xml = wSTicket.XML_getTicketData(cdChamado);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                MessageBox.Show("Ocorreu erro na conexão com WebService, verifique!", "Conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
