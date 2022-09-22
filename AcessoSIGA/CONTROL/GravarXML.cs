using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AcessoSIGA
{
    public class GravarXML
    {
        public void gravarXML_Banco(string xml)
        {
            //XmlWriter xmlWriter = XmlWriter.Create(arquivo);

            //Lê o arquivo XML gerado
            //XmlDocument doc = new XmlDocument();
            //doc.Load(caminhoXML);

            //string xml = doc.InnerXml;
        }

        //Gerar o XML envio em arquivo
        public void gravarXML_Envio(string xml)
        {
            string arquivo;
            string path = Util.CriarDiretorios();

            arquivo = path + @"\XML\Envio\" + Util.LimparString(DateTime.Now.ToString()) + "-Envio.xml";
            try
            {
                // Criar o documento XML
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;

                // Salvar o documento no arquivo e auto-indenta a saida.
                XmlWriter writer = XmlWriter.Create(arquivo, settings);
                doc.Save(writer);

                writer.Close();
            }
            catch (Exception ex)
            {
                Util.GravarLog("Gravar XML ", "Ocorreu erro ao gravar o XML de envio! " + ex.Message);                
            }

        }

        //Gerar o XML retorno em arquivo
        public void gravarXML_Retorno(string xml)
        {
            string arquivo;
            string path = Util.CriarDiretorios();

            arquivo = path + @"\XML\Retorno\" + Util.LimparString(DateTime.Now.ToString()) + "-Retorno.xml";

            try
            {
                // Criar o documento XML
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;

                // Salvar o documento no arquivo e auto-indenta a saida.
                XmlWriter writer = XmlWriter.Create(arquivo, settings);
                doc.Save(writer);

                writer.Close();
            }
            catch (Exception ex)
            {
                Util.GravarLog("Gravar XML ", "Ocorreu erro ao gravar o XML de retorno! " + ex.Message);                
            }
        }
    }
}
