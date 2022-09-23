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
            carregarParametros();
        }

        private void carregarParametros()
        {
            ParametrosDAO parametrosDAO = new ParametrosDAO();            
            Parametros p = parametrosDAO.ConsultarParametros();

            if (p.Cliente == null)
            {
                return;
            }
            else
            {
                txtCodCliente.Text = p.Cliente.cdCliente.ToString();
                txtNomeCliente.Text = p.Cliente.nmCliente.ToString();
                txtCpfCnpj.Text = p.Cliente.cnpj.ToString();

                txtCodContato.Text = p.Contato.cdContato.ToString();
                txtNomeContato.Text = p.Contato.nmContato.ToString();
                txtCdLocalidade.Text = p.Contato.cdLocalidade.ToString();
                txtLocalidade.Text = p.Contato.nmLocalidade;
                txtEmail.Text = p.Contato.email.ToString();
                txtLoginContato.Text = p.Contato.login.ToString();

                txtIdChamado.Text = p.Ticket.idChamado.ToString();
                txtTipoChamado.Text = p.Ticket.tipoChamado.ToString();
                txtCdCategoria.Text = p.Ticket.cdCategoria.ToString();
                txtCdSeveridade.Text = p.Ticket.cdSeveridade.ToString();
                txtCdAnimo.Text = p.Ticket.cdAnimo.ToString();
                txtCdOrigem.Text = p.Ticket.cdOrigem.ToString();

                txtServidor.Text = p.servidor.ToString();
                txtBanco.Text = p.banco.ToString();
                txtUsuario.Text = p.usuario.ToString();
                txtSenha.Text = p.senha.ToString();
            }
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
            Contato contato = new Contato();            

            cliente.cnpj = txtCpfCnpj.Text;
            contato.login = txtLoginContato.Text;
            contato.email = txtEmail.Text;

            CtrParametros ctrParametros = new CtrParametros();
            cliente = ctrParametros.ConsultarEmpresa(cliente);
            txtCodCliente.Text = cliente.cdCliente.ToString();
            txtNomeCliente.Text = cliente.nmCliente;

            contato = ctrParametros.BuscarContato(cliente, contato);
            txtCodContato.Text = contato.cdContato.ToString();
            txtNomeContato.Text = contato.nmContato;
            txtEmail.Text = contato.email;
            txtLoginContato.Text = contato.login;

            contato = ctrParametros.BuscarDadosContato(cliente, contato);
            txtCdLocalidade.Text = contato.cdLocalidade.ToString();
            txtLocalidade.Text = contato.nmLocalidade;

        }
            private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            ConexaoSQL.banco = txtBanco.Text;
            ConexaoSQL.servidor = txtServidor.Text;
            ConexaoSQL.usuario = txtUsuario.Text;
            ConexaoSQL.senha = txtSenha.Text;

            ConexaoSQL conexaoSQL = new ConexaoSQL();
            conexaoSQL.ConectarBancoSQL(false);

            if (ConexaoSQL.sqlConnection.State.Equals(ConnectionState.Open))
            {
                MessageBox.Show("Conexão realizada com sucesso! ", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexaoSQL.FecharConexaoSQL();
            }
            else
            {
                MessageBox.Show("Ocorreu erro na conexão. Verifique os dados informados! ", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conexaoSQL.FecharConexaoSQL();
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
            contato.cdLocalidade = int.Parse(txtCdLocalidade.Text);
            contato.nmLocalidade = txtLocalidade.Text;
            contato.email = txtEmail.Text;
            contato.login = txtLoginContato.Text;

            Ticket ticket = new Ticket();
            ticket.idChamado = int.Parse(txtIdChamado.Text);
            ticket.tipoChamado = int.Parse(txtTipoChamado.Text);
            ticket.cdCategoria = int.Parse(txtCdCategoria.Text);
            ticket.cdSeveridade = int.Parse(txtCdSeveridade.Text);
            ticket.cdAnimo = int.Parse(txtCdAnimo.Text);
            ticket.cdOrigem = int.Parse(txtCdOrigem.Text);

            Parametros parametros = new Parametros();
            parametros.Cliente = cliente;
            parametros.Contato = contato;
            parametros.Ticket = ticket;
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
