using System.Xml;
using System.Xml.Linq;

namespace AcessoSIGA
{
    public class RetornarXML
    {
        public static string retornarToken(string xml)
        {
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

        public static Ticket retornarChamado(string xml)
        {
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

        public static List<Ticket> retornarListaChamados(string xml)
        {
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

        public static List<Historico> retornarHistoricoChamado(string xml)
        {
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
                                historico.cdchamado = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdacompanhamento")
                                historico.cdacompanhamento = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmtipoacompanhamento")
                                historico.nmtipoacompanhamento = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dsacompanhamento")
                                historico.dsacompanhamento = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmusuario")
                                historico.nmusuario = xmlReader.ReadElementContentAsString();
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
        public static Cliente retornarEmpresa(string xml)
        {
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

        public static Contato retornarContatoEmpresa(string xml)
        {
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
    }
}
