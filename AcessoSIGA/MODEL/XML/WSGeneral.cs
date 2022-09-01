using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class WSGeneral
    {
        public static string XML_getAutToken(Contato usuario)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" +
             "<wsqualitor>" +
                 "<contents>" +
                     "<data>" +
                     "<nmusuario>" + usuario.login + "</nmusuario>" +
                     "<cdempresa>" + usuario.cdCliente + "</cdempresa>" +
                     "</data>" +
                "</contents>" +
             "</wsqualitor>";

            return xml;
        }

        public static string XML_getCustomer(string cpfCnpj)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" +
                "<wsqualitor>" +
                "<contents>" +
                "<data>" +
                "<nrcpfcnpj>" + cpfCnpj + "</nrcpfcnpj>" +
                "</data>" +
                "</contents>" +
                "</wsqualitor>";

            return xml;
        }

        public static string XML_getCustomerContact(int cdCliente, string nmLogin)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" +
                "<wsqualitor>" +
                "<contents>" +
                "<data>" +
                "<cdcliente>" + cdCliente + "</cdcliente>" +
                "<nmloginweb>" + nmLogin + "</nmloginweb>" +
                "</data>" +
                "</contents>" +
                "</wsqualitor>";

            return xml;
        }
    }
}
