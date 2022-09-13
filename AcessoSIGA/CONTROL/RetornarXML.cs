using System.Xml;
using System.Xml.Linq;

namespace AcessoSIGA
{
    public class RetornarXML
    {
        public static string retornarToken(string xml)
        {
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Retorno(xml);

            string token = "";

            try
            {

                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dataitem")
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "token")
                                token = xmlReader.ReadElementContentAsString();
                            break;
                        }
                    }

                }

                return token;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao obter o token!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return token;
        }

        //Lê o XML com retorno do chamado
        public static Ticket retornarChamado(string xml)
        {
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Retorno(xml);

            Ticket ticket = new Ticket();

            try
            {

                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;

                while (xmlReader.Read())
                {

                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dataitem")
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdchamado")
                                ticket.cdChamado = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdsituacao")
                                ticket.sitChamado = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmsituacao")
                                ticket.nmSituacao = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dtchamado")
                                ticket.dataChamado = xmlReader.ReadElementContentAsString();
                            break;
                        }
                    }
                }
                return ticket;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao obter chamado!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return ticket;
        }

        //Lê o XML com retorno dos detalhes do chamado
        public static Ticket retornarDadosChamado(string xml)
        {
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Retorno(xml);

            Ticket ticket = new Ticket();

            try
            {

                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;

                while (xmlReader.Read())
                {

                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dataitem")
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdchamado")
                                ticket.cdChamado = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dtchamado")
                                ticket.dataChamado = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dschamado")
                                ticket.dsChamado = xmlReader.ReadElementContentAsString();
                            break;
                        }
                    }
                }
                return ticket;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao obter dados do chamado!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return ticket;
        }

        //Lê o XML com lista de chamados do cliente e contato especificado
        public static List<Ticket> retornarListaChamados(string xml)
        {
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Retorno(xml);

            List<Ticket> lista = new List<Ticket>();

            try
            {

                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;

                while (xmlReader.Read())
                {
                    Ticket ticket = new Ticket();

                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dataitem")
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdchamado")
                                ticket.cdChamado = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmtitulochamado")
                                ticket.titChamado = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmsituacao")
                                ticket.nmSituacao = xmlReader.ReadElementContentAsString();
                            break;
                        }

                        lista.Add(ticket);
                    }

                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao obter lista de chamados!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return lista;
        }

        //Lê o XML com lista do histórico do chamado
        public static List<Historico> retornarHistoricoChamado(string xml)
        {
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Retorno(xml);

            List<Historico> lista = new List<Historico>();

            try
            {

                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;

                while (xmlReader.Read())
                {
                    Historico historico = new Historico();

                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dataitem")
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdchamado")
                                historico.cdChamado = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdacompanhamento")
                                historico.cdaCompanhamento = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmtipoacompanhamento")
                                historico.nmtipoacompanhamento = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dsacompanhamento")
                                historico.dsAcompanhamento = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmusuario")
                                historico.nmUsuario = xmlReader.ReadElementContentAsString();
                            break;
                        }

                        lista.Add(historico);
                    }

                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao obter histórico do chamado!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return lista;
        }

        //Lê o XML com empresa localizada pelo CNPJ
        public static Cliente retornarEmpresa(string xml)
        {
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Retorno(xml);

            Cliente cliente = new Cliente();

            try
            {
                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dataitem")
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdcliente")
                                cliente.cdCliente = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmcliente")
                                cliente.nmCliente = xmlReader.ReadElementContentAsString();
                            break;
                        }
                    }
                }

                return cliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao obter empresa!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return cliente;
        }

        //Lê o XML com retorno do contato da empresa pelo login
        public static Contato retornarContatoEmpresa(string xml)
        {
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Retorno(xml);

            Contato contato = new Contato();

            try
            {
                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dataitem")
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdloginweb")
                                contato.login = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdcliente")
                                contato.cdCliente = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdcontato")
                                contato.cdContato = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmcontato")
                                contato.nmContato = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dsemail")
                                contato.email = xmlReader.ReadElementContentAsString();
                        }
                    }
                }

                return contato;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao obter contato!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return contato;
        }

        //Lê o XML com retorno do anexo enviado
        public static bool retornarRespostaAnexo(string xml)
        {
            bool resposta = false;
            string status = "";

            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Retorno(xml);

            try
            {
                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "response_status")
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "status")
                                status = xmlReader.ReadElementContentAsString();          
                        }
                    }
                }

                if(status == "1")
                {
                    resposta = true;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao obter anexo!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return resposta;
        }
    }
}
