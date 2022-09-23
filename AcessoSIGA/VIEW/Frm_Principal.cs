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
            //Posicionar o botão na tela inicial
            pictureBox.Location = new Point(this.Width - 100, this.Height - 140);

            //Criar banco e tabelas se não existir
            ConexaoSQL conexaoSQL = new ConexaoSQL();
            conexaoSQL.CriarBancoSQL();
            conexaoSQL.CriarTabelasSQL();

            //Executa thread de atualização do historico
            Thread t1 = new Thread(AtualizarHistorico);
            t1.Start();

            //Executa thread para exibir as notificações
            Thread t2 = new Thread(ExibirNotificacao);
            t2.Start();
        }

        private void acessoSIGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrParametros ctrParametros = new CtrParametros();
            ctrParametros.AcessoSigaContato();

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
            while (executar)
            {
                Thread.Sleep(5000); //Aguarda 5 segundos

                if (executar)
                {
                    List<Ticket> listaTicket = new List<Ticket>();

                    CtrHistorico ctrHistorico = new CtrHistorico();
                    ctrHistorico.AtualizaHistoricoChamados();                    
                }
            }
        }

        private void ExibirNotificacao()
        {
            while (executar)
            {
                Thread.Sleep(10000);

                List<Historico> listHistorico = new List<Historico>();

                CtrHistorico ctrHistorico = new CtrHistorico();
                listHistorico = ctrHistorico.ConsultaNovoHistorico();

                foreach (Historico h in listHistorico)
                {
                    notifyIcon1.Icon = SystemIcons.Application;
                    notifyIcon1.BalloonTipTitle = "Chamado Atualizado!";
                    notifyIcon1.BalloonTipText = "Há uma nova atualização no chamado nº: " + h.cdChamado;
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(30000);

                    Thread.Sleep(5000); //Aguardar clique no balão exibido

                    //Atualiza flag de controle histórico após notificação ser exibida
                    HistoricoDAO historicoDAO = new HistoricoDAO();
                    historicoDAO.AtualizaHistorico(h);

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

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {

        }

    }
}