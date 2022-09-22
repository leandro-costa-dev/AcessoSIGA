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
            listViewChamados.Items.Clear();

            List<Ticket> lista = new List<Ticket>();

            DateTime dtInicio = dtPicker_dataInicio.Value;
            DateTime dtFim = dtPicker_dtFim.Value;

            string dtInicial = DateTime.Parse(dtInicio.ToString()).ToShortDateString();
            string dtFinal = DateTime.Parse(dtFim.ToString()).ToShortDateString();

            DateTime dataInicial = DateTime.Parse(dtInicial);
            DateTime dataFinal = DateTime.Parse(dtFinal);

            ParametrosDAO parametrosDAO = new ParametrosDAO();
            Parametros parametros = parametrosDAO.ConsultarParametros();

            ChamadoDAO chamadoDAO = new ChamadoDAO();
            lista = chamadoDAO.ConsultaChamadosContato(parametros);

            foreach (Ticket t in lista)
            {
                DateTime dtChamado = DateTime.Parse(t.dataChamado.Substring(0, 10));

                if (dtChamado >= dataInicial && dtChamado <= dataFinal)
                {
                    ListViewItem item = new ListViewItem(t.cdChamado.ToString());
                    item.SubItems.Add(t.titChamado);
                    item.SubItems.Add(t.nmSituacao);
                    listViewChamados.Items.Add(item);
                }
            }
        }

        private void listViewChamados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Historico> lista = new List<Historico>();

            Ticket ticket = new Ticket();

            //Obtem o código do chamado da linha selecionada
            int linha = listViewChamados.SelectedItems[0].Index;
            int cdChamado = int.Parse(listViewChamados.Items[linha].SubItems[0].Text);

            Frm_Acompanhamento f = new Frm_Acompanhamento(cdChamado);
            f.ShowDialog();
        }
    }
}
