using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AcessoSIGA
{
    //Acesso ao WebService no modo STATELESS
    public class WService 
    {
        //string UrlService = "http://siga820.govbr.com.br/ws/statelessws.php?"; //GOVSUL
        string UrlService = "http://siga_hml.govbr.com.br/ws/statelessws.php?";

        string usuarioADM = "ws_siga";
        string senhaADM = "bc@FLv4r";
        string empresaADM = "2";

        //GOV SUL
        //string usuarioADM = "leandro.costa";
        //string senhaADM = "123456";
        //string empresaADM = "1";

        string operacao;
        string wsdl;
        string xml;

        public WService(string operacao, string wsdl, string xml)
        {                       
            this.operacao = operacao;
            this.wsdl = wsdl;
            this.xml = xml;
        }
        public string RequisicaoPOST()
        {
            string xmlRetorno = "";

            //Dados requisição Auth
            string dadosPOST = "user=" + usuarioADM + "&password=" + senhaADM + "&company=" + empresaADM +
                "&wsdl_file=" + wsdl + "&operation=" + operacao + "&input_xml=" + xml;

            try
            {

                var dados = Encoding.UTF8.GetBytes(dadosPOST);

                var requisicaoWeb = HttpWebRequest.CreateHttp(UrlService);

                requisicaoWeb.Method = "POST";
                requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
                requisicaoWeb.ContentLength = dados.Length;
                requisicaoWeb.UserAgent = "RequisicaoWeb";

                //Grava dados POST para o stream
                using (var stream = requisicaoWeb.GetRequestStream())
                {
                    stream.Write(dados, 0, dados.Length);
                    stream.Close();
                }

                //Obtem a resposta da requisição
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    Stream streamDados = resposta.GetResponseStream();

                    Encoding encode = Encoding.GetEncoding("utf-8");

                    StreamReader reader = new StreamReader(streamDados, encode);
                    xmlRetorno = reader.ReadToEnd();

                    streamDados.Close();
                    resposta.Close();

                    return xmlRetorno;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu erro na conexão: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return xmlRetorno;
        }
    }
}
