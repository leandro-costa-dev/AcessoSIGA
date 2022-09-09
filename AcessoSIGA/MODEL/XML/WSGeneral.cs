using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AcessoSIGA
{
    public class WSGeneral
    {
        public string XML_getAutToken(Contato usuario)
        {
            string xml;

            StringWriter sw = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\"");
            xmlWriter.WriteStartElement("wsqualitor");
            xmlWriter.WriteStartElement("contents");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteElementString("nmusuario", usuario.login);
            xmlWriter.WriteElementString("cdempresa", usuario.cdCliente.ToString());
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

        public string XML_getCustomer(string cpfCnpj)
        {
            string xml;

            StringWriter sw = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\"");
            xmlWriter.WriteStartElement("wsqualitor");
            xmlWriter.WriteStartElement("contents");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteElementString("nrcpfcnpj", cpfCnpj);           
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

        public string XML_getCustomerContactLogin(int cdCliente, string nmLogin)
        {
            string xml;

            StringWriter sw = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\"");
            xmlWriter.WriteStartElement("wsqualitor");
            xmlWriter.WriteStartElement("contents");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteElementString("cdcliente", cdCliente.ToString());
            xmlWriter.WriteElementString("nmloginweb", nmLogin);
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

        public string XML_getCustomerContactEmail(int cdCliente, string email)
        {
            string xml;

            StringWriter sw = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\"");
            xmlWriter.WriteStartElement("wsqualitor");
            xmlWriter.WriteStartElement("contents");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteElementString("cdcliente", cdCliente.ToString());
            xmlWriter.WriteElementString("dsemail", email);
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
