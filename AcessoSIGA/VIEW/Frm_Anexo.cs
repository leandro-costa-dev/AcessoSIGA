using System;
using System.Text;

namespace AcessoSIGA
{
    public partial class Frm_Anexo : Form
    {
        List<Anexo> listaAnexo;
        int cdChamado;
        public Frm_Anexo(int cdChamado, List<Anexo> anexos)
        {
            this.listaAnexo = anexos;
            this.cdChamado = cdChamado;

            InitializeComponent();
        }

        private void Frm_Anexo_Load(object sender, EventArgs e)
        {
            foreach (Anexo a in listaAnexo)
            {
                ListViewItem item = new ListViewItem(a.nrSequencia.ToString());
                item.SubItems.Add(a.nmAnexo);
                item.SubItems.Add(a.vlTamanho);

                listViewAnexo.Items.Add(item);
            }            
        }

        private void listViewAnexo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Anexo anexo = new Anexo();

            int linha = listViewAnexo.SelectedItems[0].Index;
            string id = listViewAnexo.Items[linha].SubItems[0].Text;

            AnexoDAO anexoDAO = new AnexoDAO();
            anexo = anexoDAO.ConsultaAnexo(cdChamado, int.Parse(id));
            
            string extensao = Path.GetExtension(anexo.nmAnexo);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivo (*"+ extensao +")|*"+ extensao +"|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = extensao;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Salvar Arquivo Anexo";
            saveFileDialog.FileName = anexo.nmAnexo;

            Stream stream;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    stream.Close();

                    byte[] dadosAsBytes = System.Convert.FromBase64String(anexo.dsAnexo);

                    //Caminho do arquivo a ser salvo
                    string path = saveFileDialog.FileName;

                    //Grava o arquivo em disco                    
                    File.WriteAllBytes(path, dadosAsBytes);
                }
            }
        }
    }
}
