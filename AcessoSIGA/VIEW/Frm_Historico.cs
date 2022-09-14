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
    public partial class Frm_Historico : Form
    {
        public Frm_Historico()
        {
            InitializeComponent();
        }

        private void Frm_Historico_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            List<Ticket> lista = new List<Ticket>();

            DateTime dtInicio = dtPicker_dataInicio.Value;
            DateTime dtFim = dtPicker_dtFim.Value;

            string dtInicial = dtInicio.ToString();
            string dtFinal = dtFim.ToString();

            string dataInicial = DateTime.Parse(dtInicial) .ToString("yyyy-MM-dd");
            string dataFinal = DateTime.Parse(dtFinal).ToString("yyyy-MM-dd");
           
            GravarChamado gravarChamado = new GravarChamado();
            lista = gravarChamado.consultarChamados(dataInicial, dataFinal);

            foreach (Ticket t in lista)
            {
                ListViewItem item = new ListViewItem(t.cdChamado.ToString());
                item.SubItems.Add(t.titChamado);
                item.SubItems.Add(t.nmSituacao);
                listViewChamados.Items.Add(item);
            }

        }

        private void listViewChamados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Historico> lista = new List<Historico>();

            Ticket ticket = new Ticket();

            //Obtem o código do chamado da linha selecionada
            int linha = listViewChamados.SelectedItems[0].Index;
            int cdChamado = int.Parse(listViewChamados.Items[linha].SubItems[0].Text);

            GravarChamado gravarChamado = new GravarChamado();
            lista = gravarChamado.consultarHistoricoChamado(cdChamado);
            ticket = gravarChamado.consultarDadosChamado(cdChamado);

            Frm_Historico_Detalhe f = new Frm_Historico_Detalhe(lista, cdChamado, ticket.dsChamado, ticket.dataChamado);
            f.ShowDialog();

        }
    }
}
