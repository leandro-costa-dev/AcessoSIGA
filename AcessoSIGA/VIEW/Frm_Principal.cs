using System.Diagnostics;

namespace AcessoSIGA
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        bool executar = true; //Contrle execução da thread
        private void Form1_Load(object sender, EventArgs e)
        {
            //Criar banco e tabelas se não existir
            ConexaoSQL.CriarBancoSQL();
            ConexaoSQL.CriarTabelasSQL();

            //Executa thread do historico
            Thread t = new Thread(AtualizarHistorico);
            t.Start();

            //Posicionar o botão na tela inicial
            pictureBox.Location = new Point(this.Width - 100, this.Height - 140);
        }

        private void acessoSIGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato();

            string operacao = "getAuthToken";
            string wsdl_file = "WSGeneral.wsdl";

            contato.login = "leandro.costa";
            contato.cdCliente = 2;

            string token = "";

            //Gera o XML de envio para o webservice
            WSGeneral wSGeneral = new WSGeneral();
            string xml = wSGeneral.XML_getAutToken(contato);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

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

        private void Frm_Principal_Resize(object sender, EventArgs e)
        {
            //Posicionar o botão na tela inicial
            pictureBox.Location = new Point(this.Width - 100, this.Height - 140);
        }

        private void AtualizarHistorico()
        {           
            GravarHistorico gravarHistorico = new GravarHistorico();            

            while (executar)
            {
                Thread.Sleep(10000); //Aguarda 10 segundos

                if (executar)
                {
                    List<Ticket> listaTicket = new List<Ticket>();

                    GravarHistorico gravar = new GravarHistorico();
                    listaTicket = gravar.AtualizaHistoricoChamados();

                    foreach (Ticket t in listaTicket)
                    {
                        notifyIcon1.Icon = SystemIcons.Application;
                        notifyIcon1.BalloonTipTitle = "Chamado Atualizado!";
                        notifyIcon1.BalloonTipText = "Há uma nova atualização no chamado nº: " + t.cdChamado;
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(30000);
                    }
                }
            }
        }

        private void Frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            executar = false;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            string n = notifyIcon1.BalloonTipText;
            int cdChamado = int.Parse(n.Substring(n.IndexOf(":") + 1).Trim());

            Frm_Acompanhamento f = new Frm_Acompanhamento(cdChamado);
            f.ShowDialog();
        }
    }
}