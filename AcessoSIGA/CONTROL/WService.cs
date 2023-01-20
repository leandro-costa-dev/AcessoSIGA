using System.Net;
using System.Text;

namespace AcessoSIGA
{
    //Conexão com WebService no modo STATELESS
    public class WService
    {
        string url;
        string usuarioADM;
        string senhaADM;
        int empresaADM;

        string operacao;
        string wsdl;
        string xml;

        //Construtor geral para envio das requisições POST com XML
        public WService(string operacao, string wsdl, string xml)
        {
            ParametrosDAO parametrosDAO = new ParametrosDAO();
            Parametros p = parametrosDAO.ConsultarParametros();

            this.url = p.urlWs;
            this.usuarioADM = p.usuarioWs;
            this.senhaADM = p.senhaWs;
            this.empresaADM = p.empresaWs;

            this.operacao = operacao;
            this.wsdl = wsdl;
            this.xml = xml;
        }


        //Requisição POST com XML
        public string RequisicaoPOST_XML()
        {
            string xmlRetorno = "";

            //Parametros da requisição
            string dadosPOST = "user=" + usuarioADM + 
                               "&password=" + senhaADM + 
                               "&company=" + empresaADM +
                               "&wsdl_file=" + wsdl + 
                               "&operation=" + operacao + 
                               "&input_xml=" + xml;

            try
            {
                var dados = Encoding.UTF8.GetBytes(dadosPOST);

                var requisicaoWeb = HttpWebRequest.CreateHttp(url);

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
                Util.GravarLog("Conexão WebService HttpWebRequest ", "Ocorreu erro na conexão com WebService! " + ex.Message);
            }
            return xmlRetorno;
        }


        //Requisição POST para validar login
        public string RequisicaoPOST_LOGIN(int cdCliente, int cdContato, string senhaContato)
        {
            string xmlRetorno = "";

            //Parametros da requisição
            string dadosPOST = "user=" + usuarioADM +
                               "&password=" + senhaADM +
                               "&company=" + empresaADM +
                               "&wsdl_file=" + wsdl +
                               "&operation=" + operacao +
                               "customerid" + cdCliente +
                               "contactid" + cdContato +
                               "contactpass" + senhaContato;

            try
            {
                var dados = Encoding.UTF8.GetBytes(dadosPOST);

                var requisicaoWeb = HttpWebRequest.CreateHttp(url);

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
                Util.GravarLog("Conexão WebService HttpWebRequest ", "Ocorreu erro na conexão com WebService! " + ex.Message);
            }
            return xmlRetorno;
        }

        //HttpClient assync para envio do anexo
        public async Task<string> PostAsync()
        {
            string xmlRetorno = "";

            try
            {
                HttpClient httpClient = new HttpClient();

                String restCallURL = url;

                HttpRequestMessage apiRequest = new HttpRequestMessage(HttpMethod.Post, restCallURL);
                //apirequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document"));
                //apirequest.Headers.Add("authorization", "YOUR TOKEN");

                MultipartFormDataContent postValues = new MultipartFormDataContent();
                postValues.Add(new StringContent(usuarioADM), "user");
                postValues.Add(new StringContent(senhaADM), "password");
                postValues.Add(new StringContent(empresaADM.ToString()), "company");
                postValues.Add(new StringContent(wsdl), "wsdl_file");
                postValues.Add(new StringContent(operacao), "operation");
                postValues.Add(new StringContent(xml), "input_xml");
                //postValues.Add(new StreamContent(File.OpenRead("C:\\teste.docx")), "file", (new FileInfo("C:\\teste.docx").Name));
                apiRequest.Content = postValues;

                HttpResponseMessage apiCallResponse = await httpClient.SendAsync(apiRequest);

                xmlRetorno = await apiCallResponse.Content.ReadAsStringAsync();

                Stream stream = await apiCallResponse.Content.ReadAsStreamAsync();
                byte[] doc = null;

                //MemoryStream ms = new MemoryStream();
                //stream.CopyTo(ms);
                //doc = ms.ToArray();
                //File.WriteAllBytes("D:\\Projetos\\rez.docx", doc);

            }
            catch (Exception ex)
            {
                Util.GravarLog("Conexão WebService HttpClient ", "Ocorreu erro na conexão com WebService! " + ex.Message);
            }
            return xmlRetorno;
        }
    }
}