using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace AcessoSIGA
{
    public partial class Frm_Chamado : Form
    {
        string arquivoAnexo = ""; //Variavel do arquivo anexo em base 64
        string descAnexo = ""; //Descrição do anexo
        public Frm_Chamado()
        {
            InitializeComponent();
        }

        private void Frm_Chamado_Load(object sender, EventArgs e)
        {

        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();       

            //Dados para abertura do chamado
            ticket.cdCliente = int.Parse(txtCodCliente.Text); //Codigo do Cliente
            ticket.cdContato = int.Parse(txtCodContato.Text); //Codigo do Contato
            ticket.idChamado = 1; //1 – Chamado por solicitante, 2 – Chamado por equipamento, 3 – Chamado por produto, 4 – Chamado por IC.
            ticket.titChamado = txtTitulo.Text; //Titulo do chamado
            ticket.dsChamado = txtDescricao.Text; //Descrição do chamado
            ticket.tipoChamado = 8; //Suporte
            ticket.cdCategoria = 70000338; //Código da categoria (AR - Administração de Receitas)
            ticket.cdLocalidade = 12; //CAC
            ticket.severidade = 12; //Media
            ticket.animo = 4; //Normal
            ticket.cdOrigem = 88; //WebService
            ticket.anexo = arquivoAnexo; //Arquivo anexo
            ticket.dsAnexo = descAnexo; //Descrição do anexo

            CtrChamado ctrChamado = new CtrChamado();
            ticket = ctrChamado.GravarChamados(ticket);

            if (ticket.cdChamado > 0)
            {
                MessageBox.Show("Chamado nº " + ticket.cdChamado + " cadastrado com sucesso!", "Sucesso!: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocorreu erro na abertura do chamado! ", "Erro!: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            Frm_Historico f = new Frm_Historico();
            f.ShowDialog();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            CarregaArquivo();
        }

        private void CarregaArquivo()
        {
            try
            {
                openFileDialog.ShowDialog(this);
                string strFn = openFileDialog.FileName;

                descAnexo = openFileDialog.SafeFileName;

                txtAnexo.Text = strFn;

                if (String.IsNullOrEmpty(strFn))
                {
                    return;
                }
                else
                {
                    FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);

                    byte[] bytesArquivo = new byte[fs.Length];
                    fs.Read(bytesArquivo, 0, Convert.ToInt32(fs.Length));

                    arquivoAnexo = Convert.ToBase64String(bytesArquivo);

                    fs.Close();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu erro na leitura do arquivo! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
