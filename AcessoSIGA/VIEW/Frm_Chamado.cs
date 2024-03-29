﻿using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace AcessoSIGA
{
    public partial class Frm_Chamado : Form
    {
        string arquivoAnexo = ""; //Variavel do arquivo anexo em base 64
        string nomeAnexo = ""; //Descrição do anexo

        public Frm_Chamado()
        {
            InitializeComponent();
        }

        private void Frm_Chamado_Load(object sender, EventArgs e)
        {
            ParametrosDAO parametrosDAO = new ParametrosDAO();
            Parametros p = parametrosDAO.ConsultarParametros();

            try
            {
                txtCodCliente.Text = p.Cliente?.cdCliente.ToString();
                txtNmCliente.Text = p.Cliente?.nmCliente;
                txtCodContato.Text = p.Contato?.cdContato.ToString();
                txtNmContato.Text = p.Contato?.nmContato;
            }
            catch (Exception ex)
            {

                Util.GravarLog("Abertura de Chamados ", "Ocorreu erro ao consultar as informações no banco de dados! " + ex.Message);
            }


        }
        private async void btnGravar_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            Anexo anexo = new Anexo();

            ParametrosDAO parametrosDAO = new ParametrosDAO();
            Parametros parametros = parametrosDAO.ConsultarParametros();

            //Dados para abertura do chamado
            ticket.titChamado = txtTitulo.Text; //Titulo do chamado
            ticket.dsChamado = txtDescricao.Text; //Descrição do chamado

            ticket.cdCliente = parametros.Cliente.cdCliente; //Codigo do Cliente
            ticket.cdContato = parametros.Contato.cdContato; //Codigo do Contato
            ticket.cdLocalidade = parametros.Contato.cdLocalidade; //CAC

            ticket.idChamado = parametros.Ticket.idChamado; //1 – Chamado por solicitante, 2 – Chamado por equipamento, 3 – Chamado por produto, 4 – Chamado por IC.
            ticket.tipoChamado = parametros.Ticket.tipoChamado; //Suporte
            ticket.cdCategoria = parametros.Ticket.cdCategoria; //Código da categoria (AR - Administração de Receitas)
            ticket.cdSeveridade = parametros.Ticket.cdSeveridade; //Media
            ticket.cdAnimo = parametros.Ticket.cdAnimo; //Normal
            ticket.cdOrigem = parametros.Ticket.cdOrigem; //WebService

            anexo.dsAnexo = arquivoAnexo; //Arquivo anexo
            anexo.nmAnexo = nomeAnexo; //Nome do arquivo anexo

            CtrChamado ctrChamado = new CtrChamado();
            ticket = await ctrChamado.GravarChamados(ticket, anexo);

            if (ticket.cdChamado > 0)
            {
                MessageBox.Show("Chamado nº " + ticket.cdChamado + " cadastrado com sucesso!", "Sucesso!: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocorreu erro na abertura do chamado! ", "Erro!: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            CarregaArquivo();
        }

        private void CarregaArquivo()
        {
            try
            {
                openFileDialog.ShowDialog(this);
                string strFn = openFileDialog.FileName;

                nomeAnexo = openFileDialog.SafeFileName;

                txtAnexo.Text = strFn;

                if (String.IsNullOrEmpty(strFn))
                {
                    return;
                }
                else
                {
                    FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);

                    byte[] bytesArquivo = new byte[fs.Length];
                    fs.Read(bytesArquivo, 0, Convert.ToInt32(fs.Length));

                    arquivoAnexo = Convert.ToBase64String(bytesArquivo);

                    fs.Close();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu erro na leitura do arquivo! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
