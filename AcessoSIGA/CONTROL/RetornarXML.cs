using System;
using System.Xml;

namespace AcessoSIGA
{
    public class RetornarXML
    {
        public string RetornarToken(string xml)
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
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML do Token! " + ex.Message);                
            }
            return token;
        }

        //Lê o XML com retorno do chamado
        public Ticket RetornarChamado(string xml)
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
                                ticket.cdSituacao = int.Parse(xmlReader.ReadElementContentAsString());
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
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML do Chamado! " + ex.Message);                
            }
            return ticket;
        }

        //Lê o XML com retorno dos detalhes do chamado
        public Ticket RetornarDadosChamado(string xml)
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
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmtitulochamado")
                                ticket.titChamado = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmresponsavel")
                                ticket.nmResponsavel = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdcliente")
                                ticket.cdCliente = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmcliente")
                                ticket.nmCliente = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdcontato")
                                ticket.cdContato = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmcontato")
                                ticket.nmContato = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdsituacao")
                                ticket.cdSituacao = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmsituacao")
                                ticket.nmSituacao = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dtchamado")
                                ticket.dataChamado = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dschamado")
                                ticket.dsChamado = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdcategoria")
                                ticket.cdCategoria = int.Parse(xmlReader.ReadElementContentAsString());

                            break;
                        }
                    }
                }
                return ticket;
            }
            catch (Exception ex)
            {
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML de dados do Chamado! " + ex.Message);                
            }
            return ticket;
        }

        //Lê o XML com lista de chamados do cliente e contato especificado
        public List<Ticket> retornarListaChamadosContato(string xml)
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
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML da lista de chamados! " + ex.Message);                
            }
            return lista;
        }

        //Lê o XML com lista do histórico do chamado
        public List<Historico> RetornarHistoricoChamado(string xml)
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
                                historico.cdAcompanhamento = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmtipoacompanhamento")
                                historico.nmTipoacompanhamento = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dsacompanhamento")
                                historico.dsAcompanhamento = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmusuario")
                                historico.nmUsuario = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dtacompanhamento")
                                historico.dtAcompanhamento = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdusuario")
                                historico.cdUsuario = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "idsolicitante")
                                historico.idSolicitante = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "idemail")
                                historico.idEmail = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "idsolucao")
                                historico.idSolucao = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "idprivado")
                                historico.idPrivado = xmlReader.ReadElementContentAsString();

                            break;
                        }
                        lista.Add(historico);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML do histórico do chamado! " + ex.Message);                
            }
            return lista;
        }

        //Lê o XML com empresa localizada pelo CNPJ
        public Cliente RetornarEmpresa(string xml)
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
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML dos dados do cliente! " + ex.Message);                
            }
            return cliente;
        }

        //Lê o XML com retorno do contato da empresa pelo login
        public Contato RetornarContatoEmpresa(string xml)
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
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML do contato! " + ex.Message);                
            }
            return contato;
        }

        //Lê o XML com retorno do contato da empresa pelo login
        public Contato RetornarDadosContato(string xml)
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
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdcliente")
                                contato.cdCliente = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmcliente")
                                contato.nmCliente = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdcontato")
                                contato.cdContato = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmcontato")
                                contato.nmContato = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdlocalidade")
                                contato.cdLocalidade = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nmlocalidade")
                                contato.nmLocalidade = xmlReader.ReadElementContentAsString();
                        }
                    }
                }
                return contato;
            }
            catch (Exception ex)
            {
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML dos dados do contato! " + ex.Message);
            }
            return contato;
        }

        //Lê o XML com retorno da validação da senha do contato
        public bool RetornarValidacaoContato(string xml)
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

                if (status == "1")
                {
                    resposta = true;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML do anexo! " + ex.Message);
            }
            return resposta;
        }

        //Lê o XML com retorno do anexo enviado
        public bool RetornarRespostaAnexo(string xml)
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
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML do anexo! " + ex.Message);                
            }
            return resposta;
        }

        //Lê o XML de retorno do anexo
        public Anexo RetornarInclusaoAnexo(string xml)
        {
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Retorno(xml);

            Anexo anexo = new Anexo();

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
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "dtoperacao")
                                anexo.dtAnexo = xmlReader.ReadElementContentAsString();
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "cdchamado")
                                anexo.cdChamado = int.Parse(xmlReader.ReadElementContentAsString());
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "nrsequencia")
                                anexo.nrSequencia = int.Parse(xmlReader.ReadElementContentAsString());
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.GravarLog("Retornar XML ", "Ocorreu erro ao obter o XML do anexo! " + ex.Message);
            }
            return anexo;
        }
    }
}
