namespace AcessoSIGA
{
    partial class Frm_Anexo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewAnexo = new System.Windows.Forms.ListView();
            this.clId = new System.Windows.Forms.ColumnHeader();
            this.clNomeAnexo = new System.Windows.Forms.ColumnHeader();
            this.clTamanho = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listViewAnexo
            // 
            this.listViewAnexo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clId,
            this.clNomeAnexo,
            this.clTamanho});
            this.listViewAnexo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAnexo.FullRowSelect = true;
            this.listViewAnexo.GridLines = true;
            this.listViewAnexo.Location = new System.Drawing.Point(0, 0);
            this.listViewAnexo.MultiSelect = false;
            this.listViewAnexo.Name = "listViewAnexo";
            this.listViewAnexo.Size = new System.Drawing.Size(356, 345);
            this.listViewAnexo.TabIndex = 0;
            this.listViewAnexo.UseCompatibleStateImageBehavior = false;
            this.listViewAnexo.View = System.Windows.Forms.View.Details;
            this.listViewAnexo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewAnexo_MouseDoubleClick);
            // 
            // clId
            // 
            this.clId.Text = "ID";
            this.clId.Width = 30;
            // 
            // clNomeAnexo
            // 
            this.clNomeAnexo.Text = "Descrição";
            this.clNomeAnexo.Width = 230;
            // 
            // clTamanho
            // 
            this.clTamanho.Text = "Tamanho";
            this.clTamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clTamanho.Width = 100;
            // 
            // Frm_Anexo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 345);
            this.Controls.Add(this.listViewAnexo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Anexo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anexos";
            this.Load += new System.EventHandler(this.Frm_Anexo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listViewAnexo;
        private ColumnHeader clNomeAnexo;
        private ColumnHeader clTamanho;
        private ColumnHeader clId;
    }
}