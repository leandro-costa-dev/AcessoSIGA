﻿using System.Xml;

namespace AcessoSIGA
{
    public class WSTicket
    {
        public string XML_addTicketByEndUser(Ticket ticket)
        {
            string xml;

            StringWriter sw = new StringWriter();            
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\"");
            xmlWriter.WriteStartElement("wsqualitor");
            xmlWriter.WriteStartElement("contents");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteElementString("cdcliente", ticket.cdCliente.ToString());
            xmlWriter.WriteElementString("cdcontato", ticket.cdContato.ToString());
            xmlWriter.WriteElementString("idchamado", ticket.idChamado.ToString());
            xmlWriter.WriteElementString("nmtitulochamado", ticket.titChamado);
            xmlWriter.WriteElementString("cdtipochamado", ticket.tipoChamado.ToString());
            xmlWriter.WriteElementString("cdcategoria", ticket.cdCategoria.ToString());            
            xmlWriter.WriteElementString("cdlocalidade", ticket.cdLocalidade.ToString());
            xmlWriter.WriteElementString("cdseveridade", ticket.cdSeveridade.ToString());
            xmlWriter.WriteElementString("dschamado", ticket.dsChamado);
            xmlWriter.WriteElementString("dspalavrachave", "");
            xmlWriter.WriteElementString("cdorigem", ticket.cdOrigem.ToString());
            xmlWriter.WriteElementString("cdcomplexidade", "");
            xmlWriter.WriteElementString("cdanimo", ticket.cdAnimo.ToString());
            xmlWriter.WriteElementString("idfca", "");
            xmlWriter.WriteElementString("vlcustoprevisto", "");
            xmlWriter.WriteElementString("vlcustorealizado", "");
            xmlWriter.WriteElementString("cdperfilchamado", "");
            xmlWriter.WriteElementString("cddocumento", "");
            xmlWriter.WriteElementString("cdchamadosuperior", "");
            xmlWriter.WriteElementString("idprontoatendimento", "");
            xmlWriter.WriteElementString("cdprojeto", "");
            xmlWriter.WriteElementString("cdfase", "");
            xmlWriter.WriteElementString("cdproblema", "");
            xmlWriter.WriteStartElement("produto");
            xmlWriter.WriteElementString("cdproduto", "");
            xmlWriter.WriteElementString("dtnotafiscal", "");
            xmlWriter.WriteElementString("dtfabricacao", "");
            xmlWriter.WriteElementString("dtvalidade", "");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("cdequipamento", "");
            xmlWriter.WriteElementString("cdic", "");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("depends");
            xmlWriter.WriteElementString("depends_on", "");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("attachments", "");
            xmlWriter.WriteStartElement("informacoesadicionais");
            xmlWriter.WriteElementString("vlinformacaoadicional1", "");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();

            xml = sw.ToString();

            //Gravar XML
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Envio(xml);

            return xml;            
        }
        
        public string XML_getTicket(Cliente cliente, Contato contato)
        {
            string xml;

            StringWriter sw = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\"");
            xmlWriter.WriteStartElement("wsqualitor");
            xmlWriter.WriteStartElement("contents");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteElementString("cdchamado", "");
            xmlWriter.WriteElementString("cdcliente", cliente.cdCliente.ToString());
            xmlWriter.WriteElementString("cdcontato", contato.cdContato.ToString());
            xmlWriter.WriteElementString("Idtipoperiodo", "");
            xmlWriter.WriteElementString("dtperiodo", "");
            xmlWriter.WriteElementString("dtperiodo2", "");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();

            xml = sw.ToString();

            //Gravar XML
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Envio(xml);

            return xml;
        }

        public string XML_getTicketHistoryData(int cdChamado)
        {
            string xml;

            StringWriter sw = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\"");
            xmlWriter.WriteStartElement("wsqualitor");
            xmlWriter.WriteStartElement("contents");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteElementString("cdchamado", cdChamado.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();

            xml = sw.ToString();

            //Gravar XML
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Envio(xml);

            return xml;
        }

        public string XML_getTicketData(int cdChamado)
        {
            string xml;

            StringWriter sw = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\"");
            xmlWriter.WriteStartElement("wsqualitor");
            xmlWriter.WriteStartElement("contents");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteElementString("cdchamado", cdChamado.ToString());
            xmlWriter.WriteElementString("campos", "cdchamado, nmtitulochamado, nmresponsavel, cdcliente, nmcliente, cdcontato, nmcontato, cdsituacao, nmsituacao, dtchamado, dschamado, cdcategoria");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();

            xml = sw.ToString();

            //Gravar XML
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Envio(xml);

            return xml;
        }

        public string XML_addAttachment(Ticket ticket, Anexo anexo)
        {
            string xml;

            StringWriter sw = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\"");
            xmlWriter.WriteStartElement("wsqualitor");
            xmlWriter.WriteStartElement("contents");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteElementString("cdchamado", ticket.cdChamado.ToString());
            xmlWriter.WriteElementString("nmanexo", anexo.nmAnexo);
            xmlWriter.WriteElementString("idprivado", "N");
            xmlWriter.WriteElementString("attachment", anexo.dsAnexo);            
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();

            xml = sw.ToString();

            //Gravar XML
            GravarXML gravarXML = new GravarXML();
            gravarXML.gravarXML_Envio(xml);

            return xml;
        }
    }
}
