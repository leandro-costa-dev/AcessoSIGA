using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Xml;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace AcessoSIGA
{
    public partial class Frm_Chamado : Form
    {
        public Frm_Chamado()
        {
            InitializeComponent();
        }

        private void Frm_Chamado_Load(object sender, EventArgs e)
        {

        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();

            string operacao = "addTicketByData";
            string wsdl_file = "WSTicket";                       

            //Dados para abertura do chamado
            ticket.cdCliente = int.Parse(txtCodCliente.Text); //Codigo do Cliente
            ticket.cdContato = int.Parse(txtCodContato.Text); //Codigo do Contato
            ticket.idChamado = 1; //1 – Chamado por solicitante, 2 – Chamado por equipamento, 3 – Chamado por produto, 4 – Chamado por IC.
            ticket.titChamado = txtTitulo.Text; //Titulo do chamado
            ticket.tipoChamado = 8; //Suporte
            ticket.cdCategoria = 70000338; //Código da categoria (AR - Administração de Receitas)
            ticket.cdLocalidade = 12; //CAC
            ticket.severidade = 3; //Normal
            ticket.animo = 4; //Normal
            ticket.cdOrigem = 9; //Telefone
            ticket.dsChamado = txtDescricao.Text; //Descrição do chamado

            //Gera o XML de envio para o webservice
            GravarXML gravarXML = new GravarXML();
            string caminhoXML = gravarXML.XML_addTicketByData(ticket);

            //Lê o arquivo XML gerado
            XmlDocument doc = new XmlDocument();
            doc.Load(caminhoXML);

            string xml = doc.InnerXml;

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);            

            //Envia a requisição POST e faz a leitura do XML de retorno
            ticket = XML.retornarChamado(wService.RequisicaoPOST());

            if (ticket.cdChamado > 0)
            {
                MessageBox.Show("Chamado nº " + ticket.cdChamado + " cadastrado com sucesso!", "Sucesso!: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro na abertura do chamado", "Erro!: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            Frm_Historico f = new Frm_Historico();
            f.ShowDialog();
        }
    }
}
