using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class WSTicket
    {
        public static string XML_addTicketByData(Ticket ticket)
        {

            string xml = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><wsqualitor><contents><data><cdcliente>"+ticket.cdCliente+ "</cdcliente><cdcontato>"+ticket.cdContato+ "</cdcontato><idchamado>1</idchamado><nmtitulochamado>"+ticket.titChamado+ "</nmtitulochamado><cdtipochamado>"+ticket.tipoChamado+ "</cdtipochamado><cdcategoria>"+ticket.cdCategoria+ "</cdcategoria><cdlocalidade>"+ticket.cdLocalidade+ "</cdlocalidade><cdseveridade>"+ticket.severidade+ "</cdseveridade><dschamado>"+ticket.dsChamado+ "</dschamado><dspalavrachave/><cdorigem>"+ticket.cdOrigem+ "</cdorigem><cdcomplexidade/><cdanimo>"+ticket.animo+"</cdanimo><idfca/><faturamento><idtipofaturamento>1</idtipofaturamento></faturamento><vlcustoprevisto>0.00</vlcustoprevisto><vlcustorealizado>0.00</vlcustorealizado><cdperfilchamado/><cddocumento/><cdchamadosuperior/><idprontoatendimento/><cdprojeto/><cdfase/><cdproblema/><produto><cdproduto/><dtnotafiscal/><dtfabricacao/><dtvalidade/></produto><cdequipamento/><cdic/></data><depends><depends_on/></depends><attachments/><informacoesadicionais><vlinformacaoadicional1/></informacoesadicionais></contents></wsqualitor>";

            //string xml = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" +
            //    "<wsqualitor>" +
            //    "<contents>" +
            //    "<data>" +
            //    "<idchamado>" + ticket.idChamado + "</idchamado>" +
            //    "<cdcliente>" + ticket.cdCliente + "</cdcliente>" +
            //    "<cdcontato>" + ticket.cdContato + "</cdcontato>" +
            //    "<nmtitulochamado>" + ticket.titChamado + "</nmtitulochamado>" +
            //    "<cdtipochamado>" + ticket.tipoChamado + "</cdtipochamado>" +
            //    "<cdcategoria>" + ticket.cdCategoria + "</cdcategoria>" +
            //    "<cdlocalidade>" + ticket.cdLocalidade + "</cdlocalidade>" +
            //    "<cdseveridade>" + ticket.severidade + "</cdseveridade>" +
            //    "<dschamado>" + ticket.dsChamado + "</dschamado>" +
            //    "<dspalavrachave/>" +
            //    "<cdorigem>" + ticket.cdOrigem + "</cdorigem>" +
            //    "<cdcomplexidade/>" +
            //    "<cdanimo>" + ticket.animo + "<cdanimo/>" +
            //    "<idfca/>" +
            //    "<faturamento>" +
            //    "<idtipofaturamento>1</idtipofaturamento>" +
            //    "</faturamento>" +
            //    "<vlcustoprevisto>0.00</vlcustoprevisto>" +
            //    "<vlcustorealizado>0.00</vlcustorealizado>" +
            //    "<cdperfilchamado/>" +
            //    "<cddocumento/>" +
            //    "<cdchamadosuperior/>" +
            //    "<idprontoatendimento/>" +
            //    "<cdprojeto/>" +
            //    "<cdfase/>" +
            //    "<cdproblema/>" +
            //    "<produto><cdproduto/>" +
            //    "<dtnotafiscal/>" +
            //    "<dtfabricacao/>" +
            //    "<dtvalidade/>" +
            //    "</produto>" +
            //    "<cdequipamento/>" +
            //    "<cdic/>" +
            //    "</data>" +
            //    "<depends>" +
            //    "<depends_on/>" +
            //    "</depends>" +
            //    "<attachments/>" +
            //    "<informacoesadicionais>" +
            //    "<vlinformacaoadicional1/>" +
            //    "</informacoesadicionais>" +
            //    "</contents>" +
            //    "</wsqualitor>";

            return xml;
        }

        public static string XML_getTicket(Ticket ticket)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" +
                "<wsqualitor>" +
                "<contents>" +
                "<data>" +
                "<cdchamado>"+ticket.cdChamado+"</cdchamado>" +
                "<cdcliente>"+ticket.cdCliente+"</cdcliente>" +
                "<cdcontato>"+ticket.cdContato+"</cdcontato>" +
                "<Idtipoperiodo>"+ticket.idTIpoPeriodo+"</Idtipoperiodo>" +
                "<dtperiodo>"+ticket.dtPeriodo1+"</dtperiodo>" +
                "<dtperiodo2>"+ticket.dtPeriodo2+"</dtperiodo2>" +
                "</data></contents>" +
                "</wsqualitor>";

            return xml;
        }

        public static string XML_getTicketHistoryData(int cdChamado)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" +
                "<wsqualitor>" +
                "<contents>" +
                "<data>" +
                "<cdchamado>"+cdChamado+"</cdchamado>" +
                "</data>" +
                "</contents>" +
                "</wsqualitor>";

            return xml;
        }
    }
}
