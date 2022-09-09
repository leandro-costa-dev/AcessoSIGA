using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Chamado
    {
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

    }
}
