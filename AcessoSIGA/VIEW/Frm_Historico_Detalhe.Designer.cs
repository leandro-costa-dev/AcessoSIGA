namespace AcessoSIGA
{
    partial class Frm_Historico_Detalhe
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.lblChamado = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewHistorico = new System.Windows.Forms.ListView();
            this.clDataAcompanhamento = new System.Windows.Forms.ColumnHeader();
            this.clDesAcompanhamento = new System.Windows.Forms.ColumnHeader();
            this.lblData = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descrição do Chamado";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(6, 22);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(620, 51);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // lblChamado
            // 
            this.lblChamado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblChamado.Location = new System.Drawing.Point(18, 9);
            this.lblChamado.Name = "lblChamado";
            this.lblChamado.Size = new System.Drawing.Size(203, 23);
            this.lblChamado.TabIndex = 3;
            this.lblChamado.Text = "CHAMADO Nº :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewHistorico);
            this.groupBox2.Location = new System.Drawing.Point(12, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(632, 285);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // listViewHistorico
            // 
            this.listViewHistorico.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clDataAcompanhamento,
            this.clDesAcompanhamento});
            this.listViewHistorico.FullRowSelect = true;
            this.listViewHistorico.GridLines = true;
            this.listViewHistorico.Location = new System.Drawing.Point(6, 16);
            this.listViewHistorico.MultiSelect = false;
            this.listViewHistorico.Name = "listViewHistorico";
            this.listViewHistorico.Size = new System.Drawing.Size(620, 263);
            this.listViewHistorico.TabIndex = 0;
            this.listViewHistorico.UseCompatibleStateImageBehavior = false;
            this.listViewHistorico.View = System.Windows.Forms.View.Details;
            // 
            // clDataAcompanhamento
            // 
            this.clDataAcompanhamento.Text = "Data";
            this.clDataAcompanhamento.Width = 100;
            // 
            // clDesAcompanhamento
            // 
            this.clDesAcompanhamento.Text = "Descrição do Acompanhamento";
            this.clDesAcompanhamento.Width = 5000;
            // 
            // lblData
            // 
            this.lblData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblData.Location = new System.Drawing.Point(337, 9);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(301, 23);
            this.lblData.TabIndex = 4;
            this.lblData.Text = "DATA ABERTURA:";
            // 
            // Frm_Historico_Detalhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 431);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblChamado);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Historico_Detalhe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historico do Chamado";
            this.Load += new System.EventHandler(this.Frm_Historico_Detalhe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListView listViewHistorico;
        private ColumnHeader clDataAcompanhamento;
        private ColumnHeader clDesAcompanhamento;
        private Label lblChamado;
        private RichTextBox richTextBox;
        private Label lblData;
    }
}