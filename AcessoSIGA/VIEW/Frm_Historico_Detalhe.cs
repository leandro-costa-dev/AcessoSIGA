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
        string descricao;
        string data;

        List<Historico> listaHistorico = new List<Historico>();
        public Frm_Historico_Detalhe(List<Historico> historico, int cdChamado, string descricao, string data)
        {
            InitializeComponent();
            this.cdChamado = cdChamado;
            this.descricao = descricao;
            this.data = data;
            this.listaHistorico = historico;
        }

        private void Frm_Historico_Detalhe_Load(object sender, EventArgs e)
        {
            mostrarDetalhes();
        }

        private void mostrarDetalhes()
        {
            lblChamado.Text = "CHAMADO Nº: " + cdChamado.ToString();
            lblData.Text = "DATA ABERTURA: " + data;
            richTextBox.Text = descricao;

            foreach (Historico h in listaHistorico)
            {
                ListViewItem item = new ListViewItem(h.dtAcompanhamento);
                item.SubItems.Add(h.dsAcompanhamento);

                listViewHistorico.Items.Add(item);
            }
        }
    }
}
