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
    public partial class Frm_Historico_Detalhe : Form
    {
        int cdChamado;
        List<Historico> listaHistorico = new List<Historico>();
        public Frm_Historico_Detalhe(List<Historico> historico, int cdChamado)
        {
            InitializeComponent();
            this.cdChamado = cdChamado;
            this.listaHistorico = historico;
        }

        private void Frm_Historico_Detalhe_Load(object sender, EventArgs e)
        {
            lblChamado.Text = "Chamado nº: " + cdChamado.ToString();

            foreach (Historico h in listaHistorico)
            {
                ListViewItem item = new ListViewItem(h.cdchamado.ToString());
                item.SubItems.Add(h.dsacompanhamento);                
                listViewHistorico.Items.Add(item);
            }
        }
    }
}
