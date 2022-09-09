using System.Diagnostics;

namespace AcessoSIGA
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Criar banco e tabelas se não existir
            ConexaoSQL.CriarBancoSQL();
            ConexaoSQL.CriarTabelasSQL();

            //Posicionar o botão na tela inicial
            pictureBox.Location = new Point(this.Width - 110, this.Height - 140);
        }

        private void acessoSIGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato();
            
            contato.login = "leandro.costa";
            contato.cdCliente = 2;

            string token = "";

            //Gera o XML de envio para o webservice
            WSGeneral wSGeneral = new WSGeneral();
            string xml = wSGeneral.XML_getAutToken(contato);

            //Instancia o webservice passando os dados
            WService wService = new WService("getAuthToken", "wsgeneral", xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            //Lê XML de retorno e devolve os dados
            token = RetornarXML.retornarToken(wsRetorno);

            //Abre o navegador web com usuario logado
            //Process.Start(new ProcessStartInfo("http://siga820.govbr.com.br/loginUsuario.php?authws=" + token) { UseShellExecute = true }); //GOVSUL
            Process.Start(new ProcessStartInfo("http://siga_hml.govbr.com.br/loginUsuario.php?authws=" + token) { UseShellExecute = true });

        }

        private void acessoSIGAautenticaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Chamado f = new Frm_Chamado();
            f.ShowDialog();          
        }

        private void ParametrosGeraisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Parametros f = new Frm_Parametros();
            f.ShowDialog();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Frm_Chamado f = new Frm_Chamado();
            f.ShowDialog();
        }
    }
}