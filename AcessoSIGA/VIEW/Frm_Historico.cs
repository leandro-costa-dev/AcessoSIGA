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
            DateTime dtInicio = dtPicker_dataInicio.Value;
            DateTime dtFim = dtPicker_dtFim.Value;

            string dtInicial = dtInicio.ToString();
            string dtFinal = dtFim.ToString();

            string dataInicial = DateTime.Parse(dtInicial) .ToString("yyyy-MM-dd");
            string dataFinal = DateTime.Parse(dtFinal).ToString("yyyy-MM-dd");


            consultarChamados(dataInicial, dataFinal);
            
        }

        private void listViewChamados_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int linha = listViewChamados.SelectedItems[0].Index;

            int idChamado = int.Parse(listViewChamados.Items[linha].SubItems[0].Text);

            consultarHistoricoChamado(idChamado);

        }

        public void consultarChamados(string dtInicio, string dtFim)
        {
            List<Ticket> lista = new List<Ticket>();

            Ticket ticket = new Ticket();

            ticket.cdCliente = 2; //Codigo do Cliente Ex: GOVSUL=106941 ou 1726182 GOVBR=2
            ticket.cdContato = 47; //Codigo do Contato Ex: GOVSUL=23 ou 444 GOVBR=47
            ticket.idTIpoPeriodo = 1; //1-data de abertura, 2-data de término, 3-data de previsão de resposta, 4-data de previsão de término.
            ticket.dtPeriodo1 = dtInicio;
            ticket.dtPeriodo2 = dtFim;

            string operacao = "getTicket";
            string wsdl_file = "WSTicket";

            WService wService = new WService(operacao, wsdl_file, WSTicket.XML_getTicket(ticket));

            lista = XML.retornarListaChamados(wService.RequisicaoPOST());

            foreach (Ticket t in lista)
            {
                ListViewItem item = new ListViewItem(t.cdChamado.ToString());
                item.SubItems.Add(t.titChamado);
                item.SubItems.Add(t.nmSituacao);
                listViewChamados.Items.Add(item);                
            }          

        }

        public void consultarHistoricoChamado(int cdChamado)
        {
            List<Historico> lista = new List<Historico>();

            Historico historico = new Historico();
            
            string operacao = "getTicketHistoryData";
            string wsdl_file = "WSTicket";

            WService wService = new WService(operacao, wsdl_file, WSTicket.XML_getTicketHistoryData(cdChamado));

            lista = XML.retornarHistoricoChamado(wService.RequisicaoPOST());

            Frm_Historico_Detalhe f = new Frm_Historico_Detalhe(lista, cdChamado);
            f.ShowDialog();

        }
    }
}
