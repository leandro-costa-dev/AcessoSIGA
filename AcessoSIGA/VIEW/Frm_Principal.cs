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

        }

        private void acessoSIGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato();
            
            contato.login = "leandro.costa";
            contato.cdCliente = 123456;

            string token = "";

            WService wService = new WService("getAuthToken", "wsgeneral", WSGeneral.XML_getAutToken(contato));
            token = RetornarXML.retornarToken(wService.RequisicaoPOST());

            Process.Start(new ProcessStartInfo("http://siga820.govbr.com.br/loginUsuario.php?authws=" + token) { UseShellExecute = true }); //GOVSUL
            //Process.Start(new ProcessStartInfo("http://siga_hml.govbr.com.br/loginUsuario.php?authws=" + token) { UseShellExecute = true });

        }

        private void acessoSIGAautenticaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Chamado f = new Frm_Chamado();
            f.ShowDialog();          
        }

        private void parâmetrosSIGAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void parametrosSIGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Parametros f = new Frm_Parametros();
            f.ShowDialog();
        }
    }
}