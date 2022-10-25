using System;

namespace AcessoSIGA
{
    public partial class Frm_Acompanhamento : Form
    {
        int cdChamado;
        public Frm_Acompanhamento(int cdChamado)
        {
            InitializeComponent();

            this.cdChamado = cdChamado;
        }

        private void Frm_Acompanhamento_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            List<Historico> listaHistorico = new List<Historico>();
            Ticket ticket = new Ticket();

            ChamadoDAO chamadoDAO = new ChamadoDAO();
            ticket = chamadoDAO.ConsultaChamado(cdChamado);

            HistoricoDAO historicoDAO = new HistoricoDAO();
            listaHistorico = historicoDAO.ConsultaHistoricoChamado(cdChamado);

            lblChamado.Text = "CHAMADO Nº: " + cdChamado.ToString();
            lblData.Text = "DATA ABERTURA: " + ticket.dataChamado;
            txtDescricao.Text = ticket.dsChamado;

            foreach (Historico h in listaHistorico)
            {
                if (h.idPrivado == "N")
                {
                    ListViewItem item = new ListViewItem(h.dtAcompanhamento);
                    item.SubItems.Add(h.dsAcompanhamento);

                    listViewHistorico.Items.Add(item);
                }
            }
        }

        private void listViewHistorico_MouseClick(object sender, MouseEventArgs e)
        {
            //Obtem o texto da linha selecionada
            int linha = listViewHistorico.SelectedItems[0].Index;
            string texto = listViewHistorico.Items[linha].SubItems[1].Text;

            txtDetalhes.Text = texto;
        }

        private void btnAnexo_Click(object sender, EventArgs e)
        {
            List<Anexo> listaAnexos = new List<Anexo>();

            AnexoDAO anexoDAO = new AnexoDAO();
            listaAnexos = anexoDAO.ConsultaGeralAnexos(cdChamado);

            Frm_Anexo f = new Frm_Anexo(cdChamado, listaAnexos);
            f.ShowDialog();
        }
    }
}
