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
            string path = Util.criarDiretorios();

            arquivo = path + @"\XML\Envio\" + Util.limparString(DateTime.Now.ToString()) + "-Envio.xml";
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
                MessageBox.Show("Erro: " + ex.Message, "Ocorreu erro ao gerar o XML de envio!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

        }

        //Gerar o XML retorno em arquivo
        public void gravarXML_Retorno(string xml)
        {
            string arquivo;
            string path = Util.criarDiretorios();

            arquivo = path + @"\XML\Retorno\" + Util.limparString(DateTime.Now.ToString()) + "-Retorno.xml";

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
                MessageBox.Show("Erro: " + ex.Message, "Ocorreu erro ao gerar o XML de retorno!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

        }

    }
}
