using Microsoft.VisualBasic.Logging;
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
                txtSenhaContato.Text = p.Contato.senhaContato.ToString();

                txtIdChamado.Text = p.Ticket.idChamado.ToString();
                txtTipoChamado.Text = p.Ticket.tipoChamado.ToString();
                txtCdCategoria.Text = p.Ticket.cdCategoria.ToString();
                txtCdSeveridade.Text = p.Ticket.cdSeveridade.ToString();
                txtCdAnimo.Text = p.Ticket.cdAnimo.ToString();
                txtCdOrigem.Text = p.Ticket.cdOrigem.ToString();

                txtUrlWs.Text = p.urlWs.ToString();
                txtUsuarioWs.Text = p.usuarioWs.ToString();
                txtSenhaWs.Text = p.senhaWs.ToString();
                txtEmpresaWs.Text = p.empresaWs.ToString();
                txtServidor.Text = p.servidor.ToString();
                txtBanco.Text = p.banco.ToString();
                txtUsuarioBanco.Text = p.usuarioBanco.ToString();
                txtSenhaBanco.Text = p.senhaBanco.ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }
        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            ConexaoSQL.banco = txtBanco.Text;
            ConexaoSQL.servidor = txtServidor.Text;
            ConexaoSQL.usuario = txtUsuarioBanco.Text;
            ConexaoSQL.senha = txtSenhaBanco.Text;

            ConexaoSQL conexaoSQL = new ConexaoSQL();
            conexaoSQL.ConectarBancoSQL(false);

            if (conexaoSQL.sqlConnection.State.Equals(ConnectionState.Open))
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
            GravarParametros();
        }

        private void GravarParametros()
        {
            if (VerificarCampos() && ValidarInformacoes())
            {
                ConexaoSQL.banco = txtBanco.Text;
                ConexaoSQL.servidor = txtServidor.Text;
                ConexaoSQL.usuario = txtUsuarioBanco.Text;
                ConexaoSQL.senha = txtSenhaBanco.Text;

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
                contato.senhaContato = txtSenhaContato.Text;

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
                parametros.urlWs = txtUrlWs.Text;
                parametros.usuarioWs = txtUsuarioWs.Text;
                parametros.senhaWs = txtSenhaWs.Text;
                parametros.empresaWs = int.Parse(txtEmpresaWs.Text);
                parametros.servidor = txtServidor.Text;
                parametros.banco = txtBanco.Text;
                parametros.usuarioBanco = txtUsuarioBanco.Text;
                parametros.senhaBanco = txtSenhaBanco.Text;

                //Grava os parâmetros
                ParametrosDAO parametrosDAO = new ParametrosDAO();
                parametrosDAO.GravarParametros(parametros);

                MessageBox.Show("Parâmetros gravados com sucesso! ", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private bool VerificarCampos()
        {
            bool situacao = true;

            if (String.IsNullOrEmpty(txtEmail.Text) && String.IsNullOrEmpty(txtLoginContato.Text))
            {
                MessageBox.Show("O campo e-mail ou login devem ser preenchidos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                situacao = false;
            }
            else if (String.IsNullOrEmpty(txtCpfCnpj.Text) || String.IsNullOrEmpty(txtCdLocalidade.Text) ||
                     String.IsNullOrEmpty(txtCdAnimo.Text) || String.IsNullOrEmpty(txtCdCategoria.Text) ||
                     String.IsNullOrEmpty(txtCdOrigem.Text) || String.IsNullOrEmpty(txtCdSeveridade.Text) ||
                     String.IsNullOrEmpty(txtIdChamado.Text) || String.IsNullOrEmpty(txtTipoChamado.Text) ||
                     String.IsNullOrEmpty(txtUrlWs.Text) || String.IsNullOrEmpty(txtUsuarioWs.Text) ||
                     String.IsNullOrEmpty(txtSenhaWs.Text) || String.IsNullOrEmpty(txtEmpresaWs.Text) ||
                     String.IsNullOrEmpty(txtServidor.Text) || String.IsNullOrEmpty(txtBanco.Text) ||
                     String.IsNullOrEmpty(txtUsuarioBanco.Text) || String.IsNullOrEmpty(txtSenhaBanco.Text))
            {
                MessageBox.Show("Há campos de prenchimento obrigatório não informados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                situacao = false;
            }          

            return situacao;
        }

        //valida as informações do cliente e contato informadas
        private bool ValidarInformacoes()
        {
            bool situacao = true;

            Cliente cliente = new Cliente();
            Contato contato = new Contato();

            cliente.cnpj = txtCpfCnpj.Text;
            contato.login = txtLoginContato.Text;
            contato.email = txtEmail.Text;
            contato.senhaContato = txtSenhaContato.Text;

            CtrParametros ctrParametros = new CtrParametros();
            cliente = ctrParametros.ConsultarEmpresa(cliente);
            txtCodCliente.Text = cliente.cdCliente.ToString();
            txtNomeCliente.Text = cliente.nmCliente;

            var dadosLoginContato = ctrParametros.BuscarContato(cliente, contato);
            contato.cdContato = dadosLoginContato.cdContato;
            contato.nmContato = dadosLoginContato.nmContato;
            contato.email = dadosLoginContato.email;
            contato.login = dadosLoginContato.login;

            var dadosLocalidadeContato = ctrParametros.BuscarDadosContato(cliente, contato);
            contato.cdLocalidade = dadosLocalidadeContato.cdLocalidade;
            contato.nmLocalidade = dadosLocalidadeContato.nmLocalidade;

            txtCodContato.Text = contato.cdContato.ToString();
            txtNomeContato.Text = contato.nmContato;
            txtEmail.Text = contato.email;
            txtLoginContato.Text = contato.login;           
            txtCdLocalidade.Text = contato.cdLocalidade.ToString();
            txtLocalidade.Text = contato.nmLocalidade;


            if (!VerificaLogin(cliente, contato))
            {
                MessageBox.Show("Não foí possível validar as credencias de login do contato. ", "Credenciais inválidas, verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                situacao = false;
            }

            return situacao;
        }

        //Verifica se o login e senha são válidos
        private bool VerificaLogin(Cliente cliente, Contato contato)
        {
            bool situacao = false;

            CtrParametros ctrParametros = new CtrParametros();
            
            if (ctrParametros.ValidarSenhaContato(cliente, contato))
            {
                situacao = true;
            }
            else
            {
                MessageBox.Show("Login ou senha do contato são inválidos. Verifique! ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);           
            }

            return situacao;
        }
    }
}
