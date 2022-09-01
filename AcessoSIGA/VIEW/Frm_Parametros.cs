using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcessoSIGA
{
    public partial class Frm_Parametros : Form
    {
        public Frm_Parametros()
        {
            InitializeComponent();
        }

        private void Frm_Parametros_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            string CpfCnpj = txtCpfCnpj.Text;
            string operacao = "getCustomer";
            string wsdl_file = "WSGeneral";


            WService wService = new WService(operacao, wsdl_file, WSGeneral.XML_getCustomer(CpfCnpj));

            cliente = RetornarXML.retornarEmpresa(wService.RequisicaoPOST());

            txtCodEmpresa.Text = cliente.cdCliente.ToString();
            txtNomeEmpresa.Text = cliente.nmCliente;

            buscarContato(cliente.cdCliente);

        }

        private void buscarContato(int cdCliente)
        {
            Contato contato = new Contato();

            string nmContato = txtLoginUsuario.Text;
            
            string operacao = "getCustomerContact";
            string wsdl_file = "WSGeneral";

            WService wService = new WService(operacao, wsdl_file, WSGeneral.XML_getCustomerContact(cdCliente, nmContato));

            contato = RetornarXML.retornarContatoEmpresa(wService.RequisicaoPOST());

            txtCodUsuario.Text = contato.cdContato.ToString();
            txtNomeUsuario.Text = contato.nmContato;
            txtEmail.Text = contato.email;
            
        }

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            ConexaoSQL.ConectarBancoSQL();

            if (ConexaoSQL.sqlConnection.State.Equals(ConnectionState.Open))
            {
                MessageBox.Show("Conexão realizada com sucesso! ", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ConexaoSQL.FecharConexaoSQL();
            }
        }
    }
}
