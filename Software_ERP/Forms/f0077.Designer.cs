namespace ERP.Forms
{
    partial class f0077
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            this.prdDataEmissao = new CompSoft.cf_Bases.cf_Periodo();
            this.grdNotasFiscais = new CompSoft.cf_Bases.cf_DataGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selecionarTudoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.selecionarNotasFiscaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecionarTodosOsCuponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkAtivarEmpresa = new CompSoft.cf_Bases.cf_CheckBox();
            this.chkAtivarDataEmissao = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cmdPesquisar = new CompSoft.cf_Bases.cf_Button();
            this.cmdGerar = new CompSoft.cf_Bases.cf_Button();
            this.cboImpressora = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.txtNumeroPedido = new CompSoft.cf_Bases.cf_TextBox();
            this.txtNumeroNF = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.chkImprimirBoleto = new CompSoft.cf_Bases.cf_CheckBox();
            this.chkGerarRemessa = new CompSoft.cf_Bases.cf_CheckBox();
            this.txtArquivoRemessa = new CompSoft.cf_Bases.cf_TextBox();
            this.cmdDefinirArquivo = new CompSoft.cf_Bases.cf_Button();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cboEmpresa.Enabled = false;
            this.cboEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.ForeColor = System.Drawing.Color.DimGray;
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Grupo = "";
            this.cboEmpresa.Incluir_QueryBy = true;
            this.cboEmpresa.Location = new System.Drawing.Point(63, 12);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.ReadOnly = false;
            this.cboEmpresa.Size = new System.Drawing.Size(428, 21);
            this.cboEmpresa.SQLStatement = "select empresa, Nome_Fantasia from Empresas where inativo = 0 order by Nome_Fanta" +
                "sia";
            this.cboEmpresa.Tabela = "";
            this.cboEmpresa.Tabela_INNER = null;
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.ValorAnterior = null;
            this.cboEmpresa.Value = null;
            // 
            // prdDataEmissao
            // 
            this.prdDataEmissao.Enabled = false;
            this.prdDataEmissao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdDataEmissao.Location = new System.Drawing.Point(10, 26);
            this.prdDataEmissao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdDataEmissao.Name = "prdDataEmissao";
            this.prdDataEmissao.Size = new System.Drawing.Size(264, 51);
            this.prdDataEmissao.TabIndex = 1;
            // 
            // grdNotasFiscais
            // 
            this.grdNotasFiscais.Allow_Alter_Value_All_StatusForm = false;
            this.grdNotasFiscais.AllowEditRow = true;
            this.grdNotasFiscais.AllowUserToAddRows = false;
            this.grdNotasFiscais.AllowUserToDeleteRows = false;
            this.grdNotasFiscais.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdNotasFiscais.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdNotasFiscais.Cancel_OnClick = true;
            this.grdNotasFiscais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdNotasFiscais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.grdNotasFiscais.ContextMenuStrip = this.contextMenuStrip1;
            this.grdNotasFiscais.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdNotasFiscais.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdNotasFiscais.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdNotasFiscais.GridColor = System.Drawing.Color.DimGray;
            this.grdNotasFiscais.Location = new System.Drawing.Point(0, 171);
            this.grdNotasFiscais.MultiSelect = false;
            this.grdNotasFiscais.Name = "grdNotasFiscais";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdNotasFiscais.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdNotasFiscais.RowHeadersWidth = 22;
            this.grdNotasFiscais.RowTemplate.Height = 20;
            this.grdNotasFiscais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdNotasFiscais.ShowCellErrors = false;
            this.grdNotasFiscais.ShowCellToolTips = false;
            this.grdNotasFiscais.ShowRowErrors = false;
            this.grdNotasFiscais.Size = new System.Drawing.Size(663, 302);
            this.grdNotasFiscais.TabIndex = 12;
            this.grdNotasFiscais.TabStop = false;
            this.grdNotasFiscais.VirtualMode = true;
            this.grdNotasFiscais.EditModeChanged += new System.EventHandler(this.grdNotasFiscais_EditModeChanged);
            this.grdNotasFiscais.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdNotasFiscais_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selecionarTudoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.selecionarNotasFiscaisToolStripMenuItem,
            this.selecionarTodosOsCuponsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(246, 76);
            // 
            // selecionarTudoToolStripMenuItem
            // 
            this.selecionarTudoToolStripMenuItem.Name = "selecionarTudoToolStripMenuItem";
            this.selecionarTudoToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.selecionarTudoToolStripMenuItem.Text = "Selecionar tudo";
            this.selecionarTudoToolStripMenuItem.Click += new System.EventHandler(this.selecionarTudoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(242, 6);
            // 
            // selecionarNotasFiscaisToolStripMenuItem
            // 
            this.selecionarNotasFiscaisToolStripMenuItem.Name = "selecionarNotasFiscaisToolStripMenuItem";
            this.selecionarNotasFiscaisToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.selecionarNotasFiscaisToolStripMenuItem.Text = "Selecionar todas as Notas Fiscais";
            // 
            // selecionarTodosOsCuponsToolStripMenuItem
            // 
            this.selecionarTodosOsCuponsToolStripMenuItem.Name = "selecionarTodosOsCuponsToolStripMenuItem";
            this.selecionarTodosOsCuponsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.selecionarTodosOsCuponsToolStripMenuItem.Text = "Selecionar todos os cupons";
            // 
            // chkAtivarEmpresa
            // 
            this.chkAtivarEmpresa.AutoSize = true;
            this.chkAtivarEmpresa.ControlSource = "";
            this.chkAtivarEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivarEmpresa.Grupo = "";
            this.chkAtivarEmpresa.Incluir_QueryBy = false;
            this.chkAtivarEmpresa.Location = new System.Drawing.Point(497, 14);
            this.chkAtivarEmpresa.MensagemObrigatorio = "";
            this.chkAtivarEmpresa.Name = "chkAtivarEmpresa";
            this.chkAtivarEmpresa.Obrigatorio = false;
            this.chkAtivarEmpresa.ReadOnly = false;
            this.chkAtivarEmpresa.Size = new System.Drawing.Size(55, 17);
            this.chkAtivarEmpresa.Tabela = "";
            this.chkAtivarEmpresa.Tabela_INNER = null;
            this.chkAtivarEmpresa.TabIndex = 2;
            this.chkAtivarEmpresa.Text = "Ativar";
            this.chkAtivarEmpresa.UseVisualStyleBackColor = true;
            this.chkAtivarEmpresa.ValorAnterior = false;
            this.chkAtivarEmpresa.Value = false;
            this.chkAtivarEmpresa.CheckedChanged += new System.EventHandler(this.chkAtivarEmpresa_CheckedChanged);
            // 
            // chkAtivarDataEmissao
            // 
            this.chkAtivarDataEmissao.AutoSize = true;
            this.chkAtivarDataEmissao.ControlSource = "";
            this.chkAtivarDataEmissao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivarDataEmissao.Grupo = "";
            this.chkAtivarDataEmissao.Incluir_QueryBy = false;
            this.chkAtivarDataEmissao.Location = new System.Drawing.Point(223, 12);
            this.chkAtivarDataEmissao.MensagemObrigatorio = "";
            this.chkAtivarDataEmissao.Name = "chkAtivarDataEmissao";
            this.chkAtivarDataEmissao.Obrigatorio = false;
            this.chkAtivarDataEmissao.ReadOnly = false;
            this.chkAtivarDataEmissao.Size = new System.Drawing.Size(55, 17);
            this.chkAtivarDataEmissao.Tabela = "";
            this.chkAtivarDataEmissao.Tabela_INNER = null;
            this.chkAtivarDataEmissao.TabIndex = 0;
            this.chkAtivarDataEmissao.Text = "Ativar";
            this.chkAtivarDataEmissao.UseVisualStyleBackColor = true;
            this.chkAtivarDataEmissao.ValorAnterior = false;
            this.chkAtivarDataEmissao.Value = false;
            this.chkAtivarDataEmissao.CheckedChanged += new System.EventHandler(this.chkAtivarDataEmissao_CheckedChanged);
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.chkAtivarDataEmissao);
            this.cf_GroupBox2.Controls.Add(this.prdDataEmissao);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(7, 58);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(290, 83);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 3;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Data de vencimento do boleto";
            this.cf_GroupBox2.Value = "";
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.ForeColor = System.Drawing.Color.Black;
            this.cmdPesquisar.Grupo = "";
            this.cmdPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdPesquisar.Location = new System.Drawing.Point(502, 118);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.ReadOnly = false;
            this.cmdPesquisar.Size = new System.Drawing.Size(75, 23);
            this.cmdPesquisar.TabIndex = 10;
            this.cmdPesquisar.TabStop = false;
            this.cmdPesquisar.Text = "&Pesquisar";
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // cmdGerar
            // 
            this.cmdGerar.Enabled = false;
            this.cmdGerar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGerar.ForeColor = System.Drawing.Color.Black;
            this.cmdGerar.Grupo = "";
            this.cmdGerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdGerar.Location = new System.Drawing.Point(583, 118);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.ReadOnly = false;
            this.cmdGerar.Size = new System.Drawing.Size(75, 23);
            this.cmdGerar.TabIndex = 11;
            this.cmdGerar.TabStop = false;
            this.cmdGerar.Text = "&Gerar";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // cboImpressora
            // 
            this.cboImpressora.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboImpressora.ControlSource = "";
            this.cboImpressora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImpressora.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboImpressora.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboImpressora.ForeColor = System.Drawing.Color.DimGray;
            this.cboImpressora.FormattingEnabled = true;
            this.cboImpressora.Grupo = "";
            this.cboImpressora.Incluir_QueryBy = true;
            this.cboImpressora.Location = new System.Drawing.Point(406, 91);
            this.cboImpressora.MensagemObrigatorio = "Campo obrigatório";
            this.cboImpressora.Name = "cboImpressora";
            this.cboImpressora.Obrigatorio = false;
            this.cboImpressora.ReadOnly = false;
            this.cboImpressora.Size = new System.Drawing.Size(252, 21);
            this.cboImpressora.SQLStatement = "";
            this.cboImpressora.Tabela = "";
            this.cboImpressora.Tabela_INNER = null;
            this.cboImpressora.TabIndex = 9;
            this.cboImpressora.ValorAnterior = null;
            this.cboImpressora.Value = null;
            this.cboImpressora.Leave += new System.EventHandler(this.cboImpressora_Leave);
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(335, 95);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(65, 13);
            this.cf_Label2.TabIndex = 8;
            this.cf_Label2.Text = "Impressora:";
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(323, 42);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(77, 13);
            this.cf_Label3.TabIndex = 4;
            this.cf_Label3.Text = "Nº. do Pedido:";
            // 
            // txtNumeroPedido
            // 
            this.txtNumeroPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNumeroPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroPedido.Coluna_LookUp = 0;
            this.txtNumeroPedido.ControlSource = "";
            this.txtNumeroPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroPedido.ForeColor = System.Drawing.Color.DimGray;
            this.txtNumeroPedido.Grupo = "";
            this.txtNumeroPedido.Incluir_QueryBy = true;
            this.txtNumeroPedido.Location = new System.Drawing.Point(406, 39);
            this.txtNumeroPedido.LookUp = false;
            this.txtNumeroPedido.MensagemObrigatorio = "Campo obrigatório";
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Obrigatorio = false;
            this.txtNumeroPedido.Qtde_Casas_Decimais = 0;
            this.txtNumeroPedido.Size = new System.Drawing.Size(85, 20);
            this.txtNumeroPedido.SQLStatement = "";
            this.txtNumeroPedido.Tabela = "";
            this.txtNumeroPedido.Tabela_INNER = null;
            this.txtNumeroPedido.TabIndex = 5;
            this.txtNumeroPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroPedido.TipoControles = CompSoft.TipoControle.Inteiro;
            this.toolTipController1.SetToolTip(this.txtNumeroPedido, "Para utilizar o número do pedido como filtro basta preenche-lo, caso não quera ma" +
                    "is usa-lo, deixe-o vazio.");
            this.toolTipController1.SetToolTipIconType(this.txtNumeroPedido, DevExpress.Utils.ToolTipIconType.Information);
            this.txtNumeroPedido.ValorAnterior = "";
            this.txtNumeroPedido.Value = "";
            // 
            // txtNumeroNF
            // 
            this.txtNumeroNF.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNumeroNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroNF.Coluna_LookUp = 0;
            this.txtNumeroNF.ControlSource = "";
            this.txtNumeroNF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroNF.ForeColor = System.Drawing.Color.DimGray;
            this.txtNumeroNF.Grupo = "";
            this.txtNumeroNF.Incluir_QueryBy = true;
            this.txtNumeroNF.Location = new System.Drawing.Point(406, 65);
            this.txtNumeroNF.LookUp = false;
            this.txtNumeroNF.MensagemObrigatorio = "Campo obrigatório";
            this.txtNumeroNF.Name = "txtNumeroNF";
            this.txtNumeroNF.Obrigatorio = false;
            this.txtNumeroNF.Qtde_Casas_Decimais = 0;
            this.txtNumeroNF.Size = new System.Drawing.Size(85, 20);
            this.txtNumeroNF.SQLStatement = "";
            this.txtNumeroNF.Tabela = "";
            this.txtNumeroNF.Tabela_INNER = null;
            this.txtNumeroNF.TabIndex = 7;
            this.txtNumeroNF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroNF.TipoControles = CompSoft.TipoControle.Inteiro;
            this.toolTipController1.SetToolTip(this.txtNumeroNF, "Para utilizar o número da nota fiscal como filtro basta preenche-lo, caso não que" +
                    "ra mais usa-lo, deixe-o vazio.");
            this.toolTipController1.SetToolTipIconType(this.txtNumeroNF, DevExpress.Utils.ToolTipIconType.Information);
            this.txtNumeroNF.ValorAnterior = "";
            this.txtNumeroNF.Value = "";
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(303, 68);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(97, 13);
            this.cf_Label4.TabIndex = 6;
            this.cf_Label4.Text = "Nº. da Nota Fiscal:";
            // 
            // chkImprimirBoleto
            // 
            this.chkImprimirBoleto.AutoSize = true;
            this.chkImprimirBoleto.ControlSource = "";
            this.chkImprimirBoleto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImprimirBoleto.ForeColor = System.Drawing.Color.Blue;
            this.chkImprimirBoleto.Grupo = "";
            this.chkImprimirBoleto.Incluir_QueryBy = false;
            this.chkImprimirBoleto.Location = new System.Drawing.Point(7, 147);
            this.chkImprimirBoleto.MensagemObrigatorio = "";
            this.chkImprimirBoleto.Name = "chkImprimirBoleto";
            this.chkImprimirBoleto.Obrigatorio = false;
            this.chkImprimirBoleto.ReadOnly = false;
            this.chkImprimirBoleto.Size = new System.Drawing.Size(121, 17);
            this.chkImprimirBoleto.Tabela = "";
            this.chkImprimirBoleto.Tabela_INNER = null;
            this.chkImprimirBoleto.TabIndex = 13;
            this.chkImprimirBoleto.Text = "Imprimir boletos";
            this.chkImprimirBoleto.UseVisualStyleBackColor = true;
            this.chkImprimirBoleto.ValorAnterior = false;
            this.chkImprimirBoleto.Value = false;
            // 
            // chkGerarRemessa
            // 
            this.chkGerarRemessa.AutoSize = true;
            this.chkGerarRemessa.ControlSource = "";
            this.chkGerarRemessa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGerarRemessa.ForeColor = System.Drawing.Color.Blue;
            this.chkGerarRemessa.Grupo = "";
            this.chkGerarRemessa.Incluir_QueryBy = false;
            this.chkGerarRemessa.Location = new System.Drawing.Point(140, 147);
            this.chkGerarRemessa.MensagemObrigatorio = "";
            this.chkGerarRemessa.Name = "chkGerarRemessa";
            this.chkGerarRemessa.Obrigatorio = false;
            this.chkGerarRemessa.ReadOnly = false;
            this.chkGerarRemessa.Size = new System.Drawing.Size(173, 17);
            this.chkGerarRemessa.Tabela = "";
            this.chkGerarRemessa.Tabela_INNER = null;
            this.chkGerarRemessa.TabIndex = 14;
            this.chkGerarRemessa.Text = "Gerar arquivo de remessa";
            this.chkGerarRemessa.UseVisualStyleBackColor = true;
            this.chkGerarRemessa.ValorAnterior = false;
            this.chkGerarRemessa.Value = false;
            this.chkGerarRemessa.CheckedChanged += new System.EventHandler(this.chkGerarRemessa_CheckedChanged);
            // 
            // txtArquivoRemessa
            // 
            this.txtArquivoRemessa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtArquivoRemessa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArquivoRemessa.Coluna_LookUp = 0;
            this.txtArquivoRemessa.ControlSource = "";
            this.txtArquivoRemessa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArquivoRemessa.ForeColor = System.Drawing.Color.DimGray;
            this.txtArquivoRemessa.Grupo = "";
            this.txtArquivoRemessa.Incluir_QueryBy = true;
            this.txtArquivoRemessa.Location = new System.Drawing.Point(319, 144);
            this.txtArquivoRemessa.LookUp = false;
            this.txtArquivoRemessa.MensagemObrigatorio = "Campo obrigatório";
            this.txtArquivoRemessa.Name = "txtArquivoRemessa";
            this.txtArquivoRemessa.Obrigatorio = false;
            this.txtArquivoRemessa.Qtde_Casas_Decimais = 0;
            this.txtArquivoRemessa.Size = new System.Drawing.Size(310, 20);
            this.txtArquivoRemessa.SQLStatement = "";
            this.txtArquivoRemessa.Tabela = "";
            this.txtArquivoRemessa.Tabela_INNER = null;
            this.txtArquivoRemessa.TabIndex = 15;
            this.txtArquivoRemessa.TipoControles = CompSoft.TipoControle.Geral;
            this.txtArquivoRemessa.ValorAnterior = "";
            this.txtArquivoRemessa.Value = "";
            // 
            // cmdDefinirArquivo
            // 
            this.cmdDefinirArquivo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDefinirArquivo.ForeColor = System.Drawing.Color.Black;
            this.cmdDefinirArquivo.Grupo = "";
            this.cmdDefinirArquivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDefinirArquivo.Location = new System.Drawing.Point(631, 144);
            this.cmdDefinirArquivo.Name = "cmdDefinirArquivo";
            this.cmdDefinirArquivo.ReadOnly = false;
            this.cmdDefinirArquivo.Size = new System.Drawing.Size(27, 21);
            this.cmdDefinirArquivo.TabIndex = 16;
            this.cmdDefinirArquivo.TabStop = false;
            this.cmdDefinirArquivo.Text = "...";
            this.cmdDefinirArquivo.UseVisualStyleBackColor = true;
            this.cmdDefinirArquivo.Click += new System.EventHandler(this.cmdDefinirArquivo_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "sel";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "[  ]";
            this.Column1.MinimumWidth = 35;
            this.Column1.Name = "Column1";
            this.Column1.Width = 35;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Tipo_Documento";
            this.Column9.HeaderText = "Tipo Doc.";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Boleto_Impresso";
            this.Column10.FalseValue = "false";
            this.Column10.HeaderText = "Bol. Impresso";
            this.Column10.IndeterminateValue = "false";
            this.Column10.Name = "Column10";
            this.Column10.TrueValue = "true";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "ArquivoRemessao_Enviado";
            this.Column11.FalseValue = "false";
            this.Column11.HeaderText = "Arq. Remessa";
            this.Column11.IndeterminateValue = "false";
            this.Column11.Name = "Column11";
            this.Column11.TrueValue = "true";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.DataPropertyName = "Razao_Social_Cendente";
            this.Column2.HeaderText = "Empresa";
            this.Column2.Name = "Column2";
            this.Column2.Width = 83;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.DataPropertyName = "Razao_Social_Cliente";
            this.Column4.HeaderText = "Cliente";
            this.Column4.Name = "Column4";
            this.Column4.Width = 72;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.DataPropertyName = "Numero_Nota";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "00000000";
            dataGridViewCellStyle2.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Número Nota Fiscal";
            this.Column3.Name = "Column3";
            this.Column3.Width = 103;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.DataPropertyName = "Data_Emissao";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Data Emissão NF";
            this.Column5.Name = "Column5";
            this.Column5.Width = 105;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Numero_Parcela";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "000";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column6.HeaderText = "Número Duplicata";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Valor_Duplicata";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "n2";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column7.HeaderText = "Valor Duplicata";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Data_Vencimento";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "dd/MM/yyyy";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column8.HeaderText = "Data Vencimento";
            this.Column8.Name = "Column8";
            // 
            // f0077
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 473);
            this.Controls.Add(this.cmdDefinirArquivo);
            this.Controls.Add(this.txtArquivoRemessa);
            this.Controls.Add(this.chkGerarRemessa);
            this.Controls.Add(this.chkImprimirBoleto);
            this.Controls.Add(this.txtNumeroNF);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.txtNumeroPedido);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cboImpressora);
            this.Controls.Add(this.chkAtivarEmpresa);
            this.Controls.Add(this.grdNotasFiscais);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cmdGerar);
            this.Controls.Add(this.cmdPesquisar);
            this.Name = "f0077";
            this.Text = "Geração e impressão de Boletos (CNAB)";
            this.Load += new System.EventHandler(this.f0072_Load);
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
        private System.Windows.Forms.ToolStripMenuItem selecionarTudoToolStripMenuItem;
        private CompSoft.cf_Bases.cf_ComboBox cboImpressora;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox txtNumeroPedido;
        private CompSoft.cf_Bases.cf_TextBox txtNumeroNF;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selecionarNotasFiscaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selecionarTodosOsCuponsToolStripMenuItem;
        private CompSoft.cf_Bases.cf_CheckBox chkImprimirBoleto;
        private CompSoft.cf_Bases.cf_CheckBox chkGerarRemessa;
        private CompSoft.cf_Bases.cf_TextBox txtArquivoRemessa;
        private CompSoft.cf_Bases.cf_Button cmdDefinirArquivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}