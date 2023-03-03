using System.Diagnostics;

namespace AcessoSIGA
{
    public class CtrParametros
    {
        public Cliente ConsultarEmpresa(Cliente cliente)
        {
            string operacao = "getCustomer";
            string wsdl_file = "WSGeneral.wsdl";

            //Gera o XML de envio para o webservice
            WSGeneral wSGeneral = new WSGeneral();
            string xml = wSGeneral.XML_getCustomer(cliente.cnpj);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST_XML();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS consulta empresa ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                RetornarXML retornarXML = new RetornarXML();
                cliente = retornarXML.RetornarEmpresa(wsRetorno);
            }
            return cliente;
        }

        public Contato BuscarContato(Cliente cliente, Contato contato)
        {
            string operacao = "getCustomerContact";
            string wsdl_file = "WSGeneral.wsdl";

            //Se login não for informado busca o contato pelo e-mail informado
            if (String.IsNullOrEmpty(contato.login))
            {
                //Gera o XML de envio para o webservice
                WSGeneral wSGeneral = new WSGeneral();
                string xml = wSGeneral.XML_getCustomerContactEmail(cliente.cdCliente, contato.email);

                //Instancia o webservice passando os dados
                WService wService = new WService(operacao, wsdl_file, xml);

                //Envia a requisição POST e faz a leitura do XML de retorno
                string wsRetorno = wService.RequisicaoPOST_XML();

                //Lê XML de retorno e devolve os dados
                RetornarXML retornarXML = new RetornarXML();
                contato = retornarXML.RetornarContatoEmpresa(wsRetorno);
            }
            else
            {
                //Gera o XML de envio para o webservice
                WSGeneral wSGeneral = new WSGeneral();
                string xml = wSGeneral.XML_getCustomerContactLogin(cliente.cdCliente, contato.login);

                //Instancia o webservice passando os dados
                WService wService = new WService(operacao, wsdl_file, xml);

                //Envia a requisição POST e faz a leitura do XML de retorno
                string wsRetorno = wService.RequisicaoPOST_XML();

                //Lê XML de retorno e devolve os dados
                RetornarXML retornarXML = new RetornarXML();
                contato = retornarXML.RetornarContatoEmpresa(wsRetorno);
            }
            return contato;
        }

        public Contato BuscarDadosContato(Cliente cliente, Contato contato)
        {
            string operacao = "getCustomerContactData";
            string wsdl_file = "WSGeneral.wsdl";

            //Gera o XML de envio para o webservice
            WSGeneral wSGeneral = new WSGeneral();
            string xml = wSGeneral.XML_getCustomerContactData(cliente.cdCliente, contato.cdContato);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST_XML();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS consulta dados do contato ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                RetornarXML retornarXML = new RetornarXML();
                contato = retornarXML.RetornarDadosContato(wsRetorno);
            }

            return contato;
        }

        public bool ValidarSenhaContato(Cliente cliente, Contato contato)
        {
            bool resposta = false;

            string operacao = "verifyCustomerContactPassword";
            string wsdl_file = "WSGeneral.wsdl";
            string xml = "";

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST_LOGIN(cliente.cdCliente, contato.login, contato.senhaContato);

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS consulta dados do contato ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                RetornarXML retornarXML = new RetornarXML();
                resposta = retornarXML.RetornarValidacaoContato(wsRetorno);                
            }

            return resposta;
        }

        public void AcessoSigaContato()
        {
            string operacao = "getAuthTokenContact";
            string wsdl_file = "WSGeneral.wsdl";

            ParametrosDAO parametrosDAO = new ParametrosDAO();
            Parametros parametros = parametrosDAO.ConsultarParametros();

            //Gera o XML de envio para o webservice
            WSGeneral wSGeneral = new WSGeneral();
            string xml = wSGeneral.XML_getAutTokenContact(parametros);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST_XML();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("WS consulta token do contato ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                RetornarXML retornarXML = new RetornarXML();
                string token = retornarXML.RetornarToken(wsRetorno);

                //Abre o navegador web com usuario logado                
                Process.Start(new ProcessStartInfo("http://siga_hml.govbr.com.br/loginUsuario.php?authws=" + token) { UseShellExecute = true });
            }
        }
    }
}
