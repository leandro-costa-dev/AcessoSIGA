using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace AcessoSIGA
{
    public class GravarXML
    {
        string path = Directory.GetCurrentDirectory();

        public void criarDiretorios()
        {            
            try
            {
                if (Directory.Exists(path + @"\XML"))
                {
                    return;
                }
                else
                {
                    Directory.CreateDirectory(path + @"\XML");
                    Directory.CreateDirectory(path + @"\XML\Envio");
                    Directory.CreateDirectory(path + @"\XML\Rretorno");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao criar as pastas!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        public string XML_addTicketByData(Ticket ticket)
        {
            criarDiretorios();

            string arquivoXML = path + @"\XML\Envio\" + Util.limparString(DateTime.Now.ToString()) + "-Envio.xml";

            XmlWriter xmlWriter = XmlWriter.Create(arquivoXML);
            
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
                xmlWriter.WriteElementString("cdseveridade", ticket.severidade.ToString());
                xmlWriter.WriteElementString("dschamado", ticket.dsChamado);
                xmlWriter.WriteElementString("dspalavrachave", "");
                xmlWriter.WriteElementString("cdorigem", ticket.cdOrigem.ToString());
                xmlWriter.WriteElementString("cdcomplexidade", "");
                xmlWriter.WriteElementString("cdanimo", ticket.animo.ToString());
                xmlWriter.WriteElementString("idfca", "");
            xmlWriter.WriteStartElement("faturamento");
                xmlWriter.WriteElementString("idtipofaturamento", "1");
            xmlWriter.WriteEndElement();
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

            return arquivoXML;

        }

    }
}
