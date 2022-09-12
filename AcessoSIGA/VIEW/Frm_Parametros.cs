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
            if (String.IsNullOrEmpty(txtCpfCnpj.Text))
            {
                MessageBox.Show("O campo CPF/CNPJ deve ser preenchido! ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (String.IsNullOrEmpty(txtLoginContato.Text) && String.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("O campo Login ou e-mail devem ser preenchidos! ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente cliente = new Cliente();

            string CpfCnpj = txtCpfCnpj.Text;
            string operacao = "getCustomer";
            string wsdl_file = "WSGeneral";

            //Gera o XML de envio para o webservice
            WSGeneral wSGeneral = new WSGeneral();
            string xml = wSGeneral.XML_getCustomer(CpfCnpj);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                MessageBox.Show("Ocorreu erro na conexão com WebService, verifique!", "Conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                cliente = RetornarXML.retornarEmpresa(wsRetorno);

                txtCodCliente.Text = cliente.cdCliente.ToString();
                txtNomeCliente.Text = cliente.nmCliente;

                buscarContato(cliente.cdCliente);
            }
        }

        private void buscarContato(int cdCliente)
        {
            Contato contato = new Contato();

            string nmContato = txtLoginContato.Text;
            string email = txtEmail.Text;
            
            string operacao = "getCustomerContact";
            string wsdl_file = "WSGeneral";

            //Se login não for informado busca o contato pelo e-mail informado
            if (String.IsNullOrEmpty(txtLoginContato.Text))
            {
                //Gera o XML de envio para o webservice
                WSGeneral wSGeneral = new WSGeneral();
                string xml = wSGeneral.XML_getCustomerContactEmail(cdCliente, email);

                //Instancia o webservice passando os dados
                WService wService = new WService(operacao, wsdl_file, xml);

                //Envia a requisição POST e faz a leitura do XML de retorno
                string wsRetorno = wService.RequisicaoPOST();

                //Lê XML de retorno e devolve os dados
                contato = RetornarXML.retornarContatoEmpresa(wsRetorno);
            }
            else
            {
                //Gera o XML de envio para o webservice
                WSGeneral wSGeneral = new WSGeneral();
                string xml = wSGeneral.XML_getCustomerContactLogin(cdCliente, nmContato);

                //Instancia o webservice passando os dados
                WService wService = new WService(operacao, wsdl_file, xml);

                //Envia a requisição POST e faz a leitura do XML de retorno
                string wsRetorno = wService.RequisicaoPOST();

                //Lê XML de retorno e devolve os dados
                contato = RetornarXML.retornarContatoEmpresa(wsRetorno);
            }

            txtCodContato.Text = contato.cdContato.ToString();
            txtNomeContato.Text = contato.nmContato;
            txtEmail.Text = contato.email;
            txtLoginContato.Text = contato.login;
            
        }

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            ConexaoSQL.banco = txtBanco.Text;
            ConexaoSQL.servidor = txtServidor.Text;
            ConexaoSQL.usuario = txtUsuario.Text;
            ConexaoSQL.senha = txtSenha.Text;

            ConexaoSQL.ConectarBancoSQL(false);

            if (ConexaoSQL.sqlConnection.State.Equals(ConnectionState.Open))
            {
                MessageBox.Show("Conexão realizada com sucesso! ", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConexaoSQL.FecharConexaoSQL();
            }
            else
            {
                MessageBox.Show("Ocorreu erro na conexão. Verifique os dados informados! ", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ConexaoSQL.FecharConexaoSQL();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                MessageBox.Show("Todos os campos devem ser preenchidos! ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente cliente = new Cliente();
            cliente.cdCliente = int.Parse(txtCodCliente.Text);
            cliente.nmCliente = txtNomeCliente.Text;
            cliente.cnpj = txtCpfCnpj.Text;

            Contato contato = new Contato();
            contato.cdContato = int.Parse(txtCodContato.Text);
            contato.nmContato = txtNomeContato.Text;
            contato.email = txtEmail.Text;
            contato.login = txtLoginContato.Text;

            Parametros parametros = new Parametros();
            parametros.Cliente = cliente;
            parametros.Contato = contato;
            parametros.servidor = txtServidor.Text;
            parametros.banco = txtBanco.Text;
            parametros.usuario = txtUsuario.Text;
            parametros.senha = txtSenha.Text;

            ParametrosDAO parametrosDAO = new ParametrosDAO();
            parametrosDAO.GravarParametros(parametros);

        }

        private bool verificarCampos()
        {
            bool situacao = false;

            if (String.IsNullOrEmpty(txtCodCliente.Text) || String.IsNullOrEmpty(txtNomeCliente.Text) ||
                String.IsNullOrEmpty(txtCodContato.Text) || String.IsNullOrEmpty(txtNomeContato.Text) ||
                String.IsNullOrEmpty(txtServidor.Text) || String.IsNullOrEmpty(txtBanco.Text) ||
                String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtSenha.Text))
            {                
                situacao = true;
            }
            return situacao;
        }
    }
}
