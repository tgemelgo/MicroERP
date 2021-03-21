namespace ERP.Forms
{
    partial class f0069
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            this.prdDataEmissao = new CompSoft.cf_Bases.cf_Periodo();
            this.grdNotasFiscais = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selecionarTudoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkAtivarEmpresa = new CompSoft.cf_Bases.cf_CheckBox();
            this.chkAtivarDataEmissao = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cmdPesquisar = new CompSoft.cf_Bases.cf_Button();
            this.cmdGerar = new CompSoft.cf_Bases.cf_Button();
            this.txtPasta = new CompSoft.cf_Bases.cf_TextBox();
            this.lblPasta = new CompSoft.cf_Bases.cf_Label();
            this.cmdLocalizarPasta = new CompSoft.cf_Bases.cf_Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotasFiscais)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(5, 15);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(52, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Empresa:";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboEmpresa.ControlSource = "";
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.ForeColor = System.Drawing.Color.DimGray;
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Grupo = "";
            this.cboEmpresa.Location = new System.Drawing.Point(63, 12);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.Size = new System.Drawing.Size(396, 21);
            this.cboEmpresa.SQLStatement = "select empresa, Nome_Fantasia from Empresas where inativo = 0 and nfp_ativar_recu" +
                "rso = 1 order by Nome_Fantasia";
            this.cboEmpresa.Tabela = null;
            this.cboEmpresa.Tabela_INNER = null;
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.ValorAnterior = null;
            // 
            // prdDataEmissao
            // 
            this.prdDataEmissao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdDataEmissao.Location = new System.Drawing.Point(10, 26);
            this.prdDataEmissao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdDataEmissao.Name = "prdDataEmissao";
            this.prdDataEmissao.Size = new System.Drawing.Size(264, 51);
            this.prdDataEmissao.TabIndex = 0;
            // 
            // grdNotasFiscais
            // 
            this.grdNotasFiscais.AllowUserToAddRows = false;
            this.grdNotasFiscais.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.grdNotasFiscais.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdNotasFiscais.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdNotasFiscais.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdNotasFiscais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdNotasFiscais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            this.grdNotasFiscais.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.NullValue = "(nulo)";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdNotasFiscais.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdNotasFiscais.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdNotasFiscais.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdNotasFiscais.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdNotasFiscais.GridColor = System.Drawing.Color.DimGray;
            this.grdNotasFiscais.Location = new System.Drawing.Point(0, 128);
            this.grdNotasFiscais.MultiSelect = false;
            this.grdNotasFiscais.Name = "grdNotasFiscais";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdNotasFiscais.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdNotasFiscais.RowHeadersWidth = 22;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.grdNotasFiscais.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdNotasFiscais.RowTemplate.Height = 20;
            this.grdNotasFiscais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdNotasFiscais.ShowCellErrors = false;
            this.grdNotasFiscais.ShowCellToolTips = false;
            this.grdNotasFiscais.ShowEditingIcon = false;
            this.grdNotasFiscais.ShowRowErrors = false;
            this.grdNotasFiscais.Size = new System.Drawing.Size(620, 274);
            this.grdNotasFiscais.TabIndex = 12;
            this.grdNotasFiscais.TabStop = false;
            this.grdNotasFiscais.VirtualMode = true;
            this.grdNotasFiscais.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdNotasFiscais_CellClick);
            this.grdNotasFiscais.EditModeChanged += new System.EventHandler(this.grdNotasFiscais_EditModeChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "sel";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "[  ]";
            this.Column1.MinimumWidth = 35;
            this.Column1.Name = "Column1";
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.DataPropertyName = "Nome_Empresa";
            this.Column2.HeaderText = "Empresa";
            this.Column2.Name = "Column2";
            this.Column2.Width = 83;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.DataPropertyName = "Numero_nota";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "00000000";
            dataGridViewCellStyle3.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Nº. Nota Fiscal";
            this.Column3.Name = "Column3";
            this.Column3.Width = 117;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.DataPropertyName = "Data_Emissao";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "Dt Emissão NF";
            this.Column5.Name = "Column5";
            this.Column5.Width = 115;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.DataPropertyName = "Nome_Cliente";
            this.Column4.HeaderText = "Cliente";
            this.Column4.Name = "Column4";
            this.Column4.Width = 72;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selecionarTudoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 26);
            // 
            // selecionarTudoToolStripMenuItem
            // 
            this.selecionarTudoToolStripMenuItem.Name = "selecionarTudoToolStripMenuItem";
            this.selecionarTudoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.selecionarTudoToolStripMenuItem.Text = "Selecionar tudo";
            this.selecionarTudoToolStripMenuItem.Click += new System.EventHandler(this.selecionarTudoToolStripMenuItem_Click);
            // 
            // chkAtivarEmpresa
            // 
            this.chkAtivarEmpresa.AutoSize = true;
            this.chkAtivarEmpresa.ControlSource = "";
            this.chkAtivarEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivarEmpresa.Grupo = "";
            this.chkAtivarEmpresa.Location = new System.Drawing.Point(465, 15);
            this.chkAtivarEmpresa.MensagemObrigatorio = "";
            this.chkAtivarEmpresa.Name = "chkAtivarEmpresa";
            this.chkAtivarEmpresa.Obrigatorio = false;
            this.chkAtivarEmpresa.Size = new System.Drawing.Size(55, 17);
            this.chkAtivarEmpresa.Tabela = null;
            this.chkAtivarEmpresa.Tabela_INNER = null;
            this.chkAtivarEmpresa.TabIndex = 2;
            this.chkAtivarEmpresa.Text = "Ativar";
            this.chkAtivarEmpresa.UseVisualStyleBackColor = true;
            this.chkAtivarEmpresa.ValorAnterior = false;
            this.chkAtivarEmpresa.CheckedChanged += new System.EventHandler(this.chkAtivarEmpresa_CheckedChanged);
            // 
            // chkAtivarDataEmissao
            // 
            this.chkAtivarDataEmissao.AutoSize = true;
            this.chkAtivarDataEmissao.ControlSource = "";
            this.chkAtivarDataEmissao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivarDataEmissao.Grupo = "";
            this.chkAtivarDataEmissao.Location = new System.Drawing.Point(223, 12);
            this.chkAtivarDataEmissao.MensagemObrigatorio = "";
            this.chkAtivarDataEmissao.Name = "chkAtivarDataEmissao";
            this.chkAtivarDataEmissao.Obrigatorio = false;
            this.chkAtivarDataEmissao.Size = new System.Drawing.Size(55, 17);
            this.chkAtivarDataEmissao.Tabela = null;
            this.chkAtivarDataEmissao.Tabela_INNER = null;
            this.chkAtivarDataEmissao.TabIndex = 1;
            this.chkAtivarDataEmissao.Text = "Ativar";
            this.chkAtivarDataEmissao.UseVisualStyleBackColor = true;
            this.chkAtivarDataEmissao.ValorAnterior = false;
            this.chkAtivarDataEmissao.CheckedChanged += new System.EventHandler(this.chkAtivarDataEmissao_CheckedChanged);
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.chkAtivarDataEmissao);
            this.cf_GroupBox2.Controls.Add(this.prdDataEmissao);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(8, 39);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(290, 83);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 3;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Data de emissão";
            this.cf_GroupBox2.Value = "";
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.ForeColor = System.Drawing.Color.Black;
            this.cmdPesquisar.Grupo = "";
            this.cmdPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdPesquisar.Location = new System.Drawing.Point(453, 67);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.Size = new System.Drawing.Size(75, 23);
            this.cmdPesquisar.TabIndex = 9;
            this.cmdPesquisar.TabStop = false;
            this.cmdPesquisar.Text = "&Pesquisar";
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // cmdGerar
            // 
            this.cmdGerar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGerar.ForeColor = System.Drawing.Color.Black;
            this.cmdGerar.Grupo = "";
            this.cmdGerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdGerar.Location = new System.Drawing.Point(534, 67);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Size = new System.Drawing.Size(75, 23);
            this.cmdGerar.TabIndex = 11;
            this.cmdGerar.TabStop = false;
            this.cmdGerar.Text = "&Gerar";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // txtPasta
            // 
            this.txtPasta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasta.Coluna_LookUp = 0;
            this.txtPasta.ControlSource = "";
            this.txtPasta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasta.ForeColor = System.Drawing.Color.DimGray;
            this.txtPasta.Grupo = "";
            this.txtPasta.Incluir_QueryBy = true;
            this.txtPasta.Location = new System.Drawing.Point(304, 96);
            this.txtPasta.LookUp = false;
            this.txtPasta.MensagemObrigatorio = "Campo obrigatório";
            this.txtPasta.Name = "txtPasta";
            this.txtPasta.Obrigatorio = false;
            this.txtPasta.Qtde_Casas_Decimais = 0;
            this.txtPasta.Size = new System.Drawing.Size(277, 20);
            this.txtPasta.SQLStatement = "";
            this.txtPasta.Tabela = null;
            this.txtPasta.Tabela_INNER = null;
            this.txtPasta.TabIndex = 8;
            this.txtPasta.TipoControles = CompSoft.TipoControle.Geral;
            this.txtPasta.ValorAnterior = "";
            // 
            // lblPasta
            // 
            this.lblPasta.AutoSize = true;
            this.lblPasta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasta.Location = new System.Drawing.Point(303, 80);
            this.lblPasta.Name = "lblPasta";
            this.lblPasta.Size = new System.Drawing.Size(143, 13);
            this.lblPasta.TabIndex = 7;
            this.lblPasta.Text = "Pasta para salvar o arquivo:";
            // 
            // cmdLocalizarPasta
            // 
            this.cmdLocalizarPasta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocalizarPasta.ForeColor = System.Drawing.Color.Black;
            this.cmdLocalizarPasta.Grupo = "";
            this.cmdLocalizarPasta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLocalizarPasta.Location = new System.Drawing.Point(581, 95);
            this.cmdLocalizarPasta.Name = "cmdLocalizarPasta";
            this.cmdLocalizarPasta.Size = new System.Drawing.Size(28, 22);
            this.cmdLocalizarPasta.TabIndex = 10;
            this.cmdLocalizarPasta.TabStop = false;
            this.cmdLocalizarPasta.Text = "...";
            this.cmdLocalizarPasta.UseVisualStyleBackColor = true;
            this.cmdLocalizarPasta.Click += new System.EventHandler(this.cmdLocalizarPasta_Click);
            // 
            // f0069
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 402);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.chkAtivarEmpresa);
            this.Controls.Add(this.grdNotasFiscais);
            this.Controls.Add(this.cmdLocalizarPasta);
            this.Controls.Add(this.txtPasta);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.lblPasta);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cmdPesquisar);
            this.Controls.Add(this.cmdGerar);
            this.Name = "f0069";
            this.Text = "Exportação de Nota Fiscal Paulista";
            this.Load += new System.EventHandler(this.f0069_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdNotasFiscais)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_ComboBox cboEmpresa;
        private CompSoft.cf_Bases.cf_Periodo prdDataEmissao;
        private CompSoft.cf_Bases.cf_DataGrid grdNotasFiscais;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivarEmpresa;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivarDataEmissao;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_Button cmdPesquisar;
        private CompSoft.cf_Bases.cf_Button cmdGerar;
        private CompSoft.cf_Bases.cf_TextBox txtPasta;
        private CompSoft.cf_Bases.cf_Label lblPasta;
        private CompSoft.cf_Bases.cf_Button cmdLocalizarPasta;
        private System.Windows.Forms.ToolStripMenuItem selecionarTudoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}