namespace AcessoSIGA
{
    partial class Frm_Acompanhamento
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
            this.lblData = new System.Windows.Forms.Label();
            this.lblChamado = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewHistorico = new System.Windows.Forms.ListView();
            this.clDataAcompanhamento = new System.Windows.Forms.ColumnHeader();
            this.clDesAcompanhamento = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescricao = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDetalhes = new System.Windows.Forms.RichTextBox();
            this.btnAnexo = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblData
            // 
            this.lblData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblData.Location = new System.Drawing.Point(331, 9);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(301, 23);
            this.lblData.TabIndex = 8;
            this.lblData.Text = "DATA ABERTURA:";
            // 
            // lblChamado
            // 
            this.lblChamado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblChamado.Location = new System.Drawing.Point(12, 9);
            this.lblChamado.Name = "lblChamado";
            this.lblChamado.Size = new System.Drawing.Size(203, 23);
            this.lblChamado.TabIndex = 7;
            this.lblChamado.Text = "CHAMADO Nº :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewHistorico);
            this.groupBox2.Location = new System.Drawing.Point(6, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(632, 254);
            this.groupBox2.TabIndex = 6;
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
            this.listViewHistorico.Size = new System.Drawing.Size(620, 232);
            this.listViewHistorico.TabIndex = 0;
            this.listViewHistorico.UseCompatibleStateImageBehavior = false;
            this.listViewHistorico.View = System.Windows.Forms.View.Details;
            this.listViewHistorico.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewHistorico_MouseClick);
            // 
            // clDataAcompanhamento
            // 
            this.clDataAcompanhamento.Text = "Data";
            this.clDataAcompanhamento.Width = 150;
            // 
            // clDesAcompanhamento
            // 
            this.clDesAcompanhamento.Text = "Descrição do Acompanhamento";
            this.clDesAcompanhamento.Width = 460;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescricao);
            this.groupBox1.Location = new System.Drawing.Point(6, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 79);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descrição do Chamado";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(6, 22);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(620, 51);
            this.txtDescricao.TabIndex = 0;
            this.txtDescricao.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDetalhes);
            this.groupBox3.Location = new System.Drawing.Point(6, 425);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(632, 113);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalhes do Acompanhamento";
            // 
            // txtDetalhes
            // 
            this.txtDetalhes.Location = new System.Drawing.Point(6, 22);
            this.txtDetalhes.Name = "txtDetalhes";
            this.txtDetalhes.Size = new System.Drawing.Size(620, 85);
            this.txtDetalhes.TabIndex = 0;
            this.txtDetalhes.Text = "";
            // 
            // btnAnexo
            // 
            this.btnAnexo.Location = new System.Drawing.Point(269, 394);
            this.btnAnexo.Name = "btnAnexo";
            this.btnAnexo.Size = new System.Drawing.Size(114, 23);
            this.btnAnexo.TabIndex = 10;
            this.btnAnexo.Text = "Visualizar Aneexos";
            this.btnAnexo.UseVisualStyleBackColor = true;
            this.btnAnexo.Click += new System.EventHandler(this.btnAnexo_Click);
            // 
            // Frm_Acompanhamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 561);
            this.Controls.Add(this.btnAnexo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblChamado);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Acompanhamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acompanhamento do Chamado";
            this.Load += new System.EventHandler(this.Frm_Acompanhamento_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblData;
        private Label lblChamado;
        private GroupBox groupBox2;
        private ListView listViewHistorico;
        private ColumnHeader clDataAcompanhamento;
        private ColumnHeader clDesAcompanhamento;
        private GroupBox groupBox1;
        private RichTextBox txtDescricao;
        private GroupBox groupBox3;
        private RichTextBox txtDetalhes;
        private Button btnAnexo;
    }
}