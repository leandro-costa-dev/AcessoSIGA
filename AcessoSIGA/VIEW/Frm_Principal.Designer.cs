namespace AcessoSIGA
{
    partial class Frm_Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.suporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acessoSIGAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acessoSIGAautenticaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ParametrosSIGAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParametrosGeraisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeChamadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.suporteToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem1.Text = "Módulos";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 20);
            this.toolStripMenuItem2.Text = "Controle e Documentação";
            // 
            // suporteToolStripMenuItem
            // 
            this.suporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acessoSIGAToolStripMenuItem,
            this.acessoSIGAautenticaçãoToolStripMenuItem,
            this.toolStripSeparator2,
            this.ParametrosSIGAToolStripMenuItem});
            this.suporteToolStripMenuItem.Name = "suporteToolStripMenuItem";
            this.suporteToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.suporteToolStripMenuItem.Text = "Suporte";
            // 
            // acessoSIGAToolStripMenuItem
            // 
            this.acessoSIGAToolStripMenuItem.Name = "acessoSIGAToolStripMenuItem";
            this.acessoSIGAToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.acessoSIGAToolStripMenuItem.Text = "Acesso SIGA (Site)";
            this.acessoSIGAToolStripMenuItem.Click += new System.EventHandler(this.acessoSIGAToolStripMenuItem_Click);
            // 
            // acessoSIGAautenticaçãoToolStripMenuItem
            // 
            this.acessoSIGAautenticaçãoToolStripMenuItem.Name = "acessoSIGAautenticaçãoToolStripMenuItem";
            this.acessoSIGAautenticaçãoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.acessoSIGAautenticaçãoToolStripMenuItem.Text = "Acesso SIGA (autenticação)";
            this.acessoSIGAautenticaçãoToolStripMenuItem.Click += new System.EventHandler(this.acessoSIGAautenticaçãoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // ParametrosSIGAToolStripMenuItem
            // 
            this.ParametrosSIGAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ParametrosGeraisToolStripMenuItem,
            this.toolStripSeparator1,
            this.tabelasToolStripMenuItem});
            this.ParametrosSIGAToolStripMenuItem.Name = "ParametrosSIGAToolStripMenuItem";
            this.ParametrosSIGAToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ParametrosSIGAToolStripMenuItem.Text = "Parâmetros SIGA";
            // 
            // ParametrosGeraisToolStripMenuItem
            // 
            this.ParametrosGeraisToolStripMenuItem.Name = "ParametrosGeraisToolStripMenuItem";
            this.ParametrosGeraisToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.ParametrosGeraisToolStripMenuItem.Text = "Parâmetros Gerais";
            this.ParametrosGeraisToolStripMenuItem.Click += new System.EventHandler(this.ParametrosGeraisToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // tabelasToolStripMenuItem
            // 
            this.tabelasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoDeChamadoToolStripMenuItem});
            this.tabelasToolStripMenuItem.Name = "tabelasToolStripMenuItem";
            this.tabelasToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.tabelasToolStripMenuItem.Text = "Tabelas";
            // 
            // tipoDeChamadoToolStripMenuItem
            // 
            this.tipoDeChamadoToolStripMenuItem.Name = "tipoDeChamadoToolStripMenuItem";
            this.tipoDeChamadoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.tipoDeChamadoToolStripMenuItem.Text = "Tipo de Chamado";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Image = global::AcessoSIGA.Properties.Resources.chamado_icon;
            this.pictureBox.Location = new System.Drawing.Point(705, 422);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(64, 55);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Tag = "Clique aqui para abrir chamado";
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AcessoSIGA.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(781, 512);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Principal";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem suporteToolStripMenuItem;
        private ToolStripMenuItem acessoSIGAToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem ajudaToolStripMenuItem;
        private ToolStripMenuItem acessoSIGAautenticaçãoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem ParametrosSIGAToolStripMenuItem;
        private ToolStripMenuItem ParametrosGeraisToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tabelasToolStripMenuItem;
        private ToolStripMenuItem tipoDeChamadoToolStripMenuItem;
        private PictureBox pictureBox;
    }
}