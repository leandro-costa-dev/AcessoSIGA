namespace AcessoSIGA
{
    partial class Frm_Historico
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dtPicker_dtFim = new System.Windows.Forms.DateTimePicker();
            this.dtPicker_dataInicio = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewChamados = new System.Windows.Forms.ListView();
            this.clCodigo = new System.Windows.Forms.ColumnHeader();
            this.clTitulo = new System.Windows.Forms.ColumnHeader();
            this.clSituacao = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.dtPicker_dtFim);
            this.groupBox1.Controls.Add(this.dtPicker_dataInicio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data Inicial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "-";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(437, 35);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dtPicker_dtFim
            // 
            this.dtPicker_dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker_dtFim.Location = new System.Drawing.Point(231, 35);
            this.dtPicker_dtFim.Name = "dtPicker_dtFim";
            this.dtPicker_dtFim.Size = new System.Drawing.Size(200, 23);
            this.dtPicker_dtFim.TabIndex = 1;
            // 
            // dtPicker_dataInicio
            // 
            this.dtPicker_dataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker_dataInicio.Location = new System.Drawing.Point(6, 35);
            this.dtPicker_dataInicio.Name = "dtPicker_dataInicio";
            this.dtPicker_dataInicio.Size = new System.Drawing.Size(200, 23);
            this.dtPicker_dataInicio.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewChamados);
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 326);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chamados:";
            // 
            // listViewChamados
            // 
            this.listViewChamados.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewChamados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clCodigo,
            this.clTitulo,
            this.clSituacao});
            this.listViewChamados.FullRowSelect = true;
            this.listViewChamados.GridLines = true;
            this.listViewChamados.HoverSelection = true;
            this.listViewChamados.Location = new System.Drawing.Point(6, 22);
            this.listViewChamados.MultiSelect = false;
            this.listViewChamados.Name = "listViewChamados";
            this.listViewChamados.Size = new System.Drawing.Size(682, 298);
            this.listViewChamados.TabIndex = 0;
            this.listViewChamados.UseCompatibleStateImageBehavior = false;
            this.listViewChamados.View = System.Windows.Forms.View.Details;
            this.listViewChamados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewChamados_MouseDoubleClick);
            // 
            // clCodigo
            // 
            this.clCodigo.Text = "Código";
            this.clCodigo.Width = 80;
            // 
            // clTitulo
            // 
            this.clTitulo.Text = "Titulo do Chamado";
            this.clTitulo.Width = 440;
            // 
            // clSituacao
            // 
            this.clSituacao.Text = "Situação";
            this.clSituacao.Width = 150;
            // 
            // Frm_Historico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 426);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Historico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historico de Chamados";
            this.Load += new System.EventHandler(this.Frm_Historico_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnPesquisar;
        private DateTimePicker dtPicker_dtFim;
        private DateTimePicker dtPicker_dataInicio;
        private GroupBox groupBox2;
        private ListView listViewChamados;
        private ColumnHeader clCodigo;
        private ColumnHeader clTitulo;
        private ColumnHeader clSituacao;
    }
}