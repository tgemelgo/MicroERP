namespace ERP.Forms
{
    partial class f0039
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.prdPeriodo = new CompSoft.cf_Bases.cf_Periodo();
            this.grdPedidos = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selecionarTodasNotasFiscaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecionarTodosCuponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.selecionarTudoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.chkData = new CompSoft.cf_Bases.cf_CheckBox();
            this.optEntrega = new CompSoft.cf_Bases.cf_RadioButton();
            this.optPedido = new CompSoft.cf_Bases.cf_RadioButton();
            this.txtCliente = new CompSoft.cf_Bases.cf_TextBox();
            this.txtCodCliente = new CompSoft.cf_Bases.cf_TextBox();
            this.chkEmpresa = new CompSoft.cf_Bases.cf_CheckBox();
            this.chkCliente = new CompSoft.cf_Bases.cf_CheckBox();
            this.cmdPesquisar = new CompSoft.cf_Bases.cf_Button();
            this.cmdGerar = new CompSoft.cf_Bases.cf_Button();
            this.lblDataBaseVencimento = new CompSoft.cf_Bases.cf_Label();
            this.txtDataBaseVencimento = new CompSoft.cf_Bases.cf_DateEdit();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.cf_GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBaseVencimento.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBaseVencimento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // prdPeriodo
            // 
            this.prdPeriodo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdPeriodo.Location = new System.Drawing.Point(6, 49);
            this.prdPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdPeriodo.Name = "prdPeriodo";
            this.prdPeriodo.Size = new System.Drawing.Size(264, 51);
            this.prdPeriodo.TabIndex = 0;
            // 
            // grdPedidos
            // 
            this.grdPedidos.Allow_Alter_Value_All_StatusForm = false;
            this.grdPedidos.AllowEditRow = false;
            this.grdPedidos.AllowUserToAddRows = false;
            this.grdPedidos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.grdPedidos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPedidos.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdPedidos.Cancel_OnClick = true;
            this.grdPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column11,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column9,
            this.Column10});
            this.grdPedidos.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.NullValue = "(nulo)";
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPedidos.DefaultCellStyle = dataGridViewCellStyle10;
            this.grdPedidos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdPedidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdPedidos.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdPedidos.GridColor = System.Drawing.Color.DimGray;
            this.grdPedidos.Location = new System.Drawing.Point(0, 115);
            this.grdPedidos.MultiSelect = false;
            this.grdPedidos.Name = "grdPedidos";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPedidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.grdPedidos.RowHeadersWidth = 22;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.grdPedidos.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdPedidos.RowTemplate.Height = 20;
            this.grdPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPedidos.ShowCellErrors = false;
            this.grdPedidos.ShowCellToolTips = false;
            this.grdPedidos.ShowEditingIcon = false;
            this.grdPedidos.ShowRowErrors = false;
            this.grdPedidos.Size = new System.Drawing.Size(683, 278);
            this.grdPedidos.TabIndex = 1;
            this.grdPedidos.TabStop = false;
            this.grdPedidos.VirtualMode = true;
            this.grdPedidos.EditModeChanged += new System.EventHandler(this.grdPedidos_EditModeChanged);
            this.grdPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPedidos_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "Sel";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "[  ]";
            this.Column1.MinimumWidth = 35;
            this.Column1.Name = "Column1";
            this.Column1.ToolTipText = "Selecione para gerar a nota fiscal";
            this.Column1.Width = 35;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Tipo_Documento";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column11.Frozen = true;
            this.Column11.HeaderText = "Tipo documento";
            this.Column11.Name = "Column11";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Pedido";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "Nº do pedido";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Empresa";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "Cód. Empresa";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Nome_empresa";
            this.Column4.HeaderText = "Nome empresa";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Cliente";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column5.HeaderText = "Cód. Cliente";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Nome_Cliente";
            this.Column6.HeaderText = "Nome cliente";
            this.Column6.Name = "Column6";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Data_Pedido";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column8.HeaderText = "Data pedido";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Data_Entrega";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column9.HeaderText = "Data entrega";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Data_Vencimento";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column10.HeaderText = "Data vencimento";
            this.Column10.Name = "Column10";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selecionarTodasNotasFiscaisToolStripMenuItem,
            this.selecionarTodosCuponsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.selecionarTudoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(230, 76);
            // 
            // selecionarTodasNotasFiscaisToolStripMenuItem
            // 
            this.selecionarTodasNotasFiscaisToolStripMenuItem.Name = "selecionarTodasNotasFiscaisToolStripMenuItem";
            this.selecionarTodasNotasFiscaisToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.selecionarTodasNotasFiscaisToolStripMenuItem.Text = "Selecionar todas Notas Fiscais";
            this.selecionarTodasNotasFiscaisToolStripMenuItem.Click += new System.EventHandler(this.selecionarTodasNotasFiscaisToolStripMenuItem_Click);
            // 
            // selecionarTodosCuponsToolStripMenuItem
            // 
            this.selecionarTodosCuponsToolStripMenuItem.Name = "selecionarTodosCuponsToolStripMenuItem";
            this.selecionarTodosCuponsToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.selecionarTodosCuponsToolStripMenuItem.Text = "Selecionar todos Cupons";
            this.selecionarTodosCuponsToolStripMenuItem.Click += new System.EventHandler(this.selecionarTodosCuponsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(226, 6);
            // 
            // selecionarTudoToolStripMenuItem
            // 
            this.selecionarTudoToolStripMenuItem.Name = "selecionarTudoToolStripMenuItem";
            this.selecionarTudoToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.selecionarTudoToolStripMenuItem.Text = "Selecionar Tudo";
            this.selecionarTudoToolStripMenuItem.Click += new System.EventHandler(this.selecionarTudoToolStripMenuItem_Click);
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.chkData);
            this.cf_GroupBox1.Controls.Add(this.optEntrega);
            this.cf_GroupBox1.Controls.Add(this.optPedido);
            this.cf_GroupBox1.Controls.Add(this.prdPeriodo);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(7, 4);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(273, 105);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 0;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Filtro por data";
            this.cf_GroupBox1.Value = "1";
            // 
            // chkData
            // 
            this.chkData.AutoSize = true;
            this.chkData.ControlSource = "";
            this.chkData.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkData.Grupo = "";
            this.chkData.Incluir_QueryBy = false;
            this.chkData.Location = new System.Drawing.Point(173, 10);
            this.chkData.MensagemObrigatorio = "";
            this.chkData.Name = "chkData";
            this.chkData.Obrigatorio = false;
            this.chkData.ReadOnly = false;
            this.chkData.Size = new System.Drawing.Size(94, 17);
            this.chkData.Tabela = "";
            this.chkData.Tabela_INNER = null;
            this.chkData.TabIndex = 1;
            this.chkData.Text = "Filtro por data";
            this.chkData.UseVisualStyleBackColor = true;
            this.chkData.ValorAnterior = false;
            this.chkData.Value = false;
            this.chkData.CheckedChanged += new System.EventHandler(this.chkData_CheckedChanged);
            // 
            // optEntrega
            // 
            this.optEntrega.AutoSize = true;
            this.optEntrega.ControlSource = "";
            this.optEntrega.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.optEntrega.Grupo = "";
            this.optEntrega.Incluir_QueryBy = false;
            this.optEntrega.Location = new System.Drawing.Point(76, 28);
            this.optEntrega.MensagemObrigatorio = "";
            this.optEntrega.Name = "optEntrega";
            this.optEntrega.Obrigatorio = false;
            this.optEntrega.ReadOnly = false;
            this.optEntrega.Size = new System.Drawing.Size(63, 17);
            this.optEntrega.Tabela = "";
            this.optEntrega.Tabela_INNER = null;
            this.optEntrega.TabIndex = 2;
            this.optEntrega.Text = "Entrega";
            this.optEntrega.UseVisualStyleBackColor = true;
            this.optEntrega.ValorAnterior = false;
            this.optEntrega.Value = false;
            // 
            // optPedido
            // 
            this.optPedido.AutoSize = true;
            this.optPedido.ControlSource = "";
            this.optPedido.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.optPedido.Grupo = "";
            this.optPedido.Incluir_QueryBy = false;
            this.optPedido.Location = new System.Drawing.Point(7, 28);
            this.optPedido.MensagemObrigatorio = "";
            this.optPedido.Name = "optPedido";
            this.optPedido.Obrigatorio = false;
            this.optPedido.ReadOnly = false;
            this.optPedido.Size = new System.Drawing.Size(57, 17);
            this.optPedido.Tabela = "";
            this.optPedido.Tabela_INNER = null;
            this.optPedido.TabIndex = 0;
            this.optPedido.Text = "Pedido";
            this.optPedido.ValorAnterior = false;
            this.optPedido.Value = false;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Coluna_LookUp = 2;
            this.txtCliente.ControlSource = "";
            this.txtCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtCliente.Grupo = "";
            this.txtCliente.Incluir_QueryBy = true;
            this.txtCliente.Location = new System.Drawing.Point(412, 52);
            this.txtCliente.LookUp = false;
            this.txtCliente.MensagemObrigatorio = "Campo obrigatório";
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Obrigatorio = false;
            this.txtCliente.Qtde_Casas_Decimais = 0;
            this.txtCliente.Size = new System.Drawing.Size(265, 20);
            this.txtCliente.SQLStatement = "";
            this.txtCliente.Tabela = "";
            this.txtCliente.Tabela_INNER = null;
            this.txtCliente.TabIndex = 6;
            this.txtCliente.TipoControles = CompSoft.TipoControle.Geral;
            this.txtCliente.ValorAnterior = "";
            this.txtCliente.Value = "";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodCliente.Coluna_LookUp = 0;
            this.txtCodCliente.ControlSource = "";
            this.txtCodCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodCliente.Grupo = "";
            this.txtCodCliente.Incluir_QueryBy = true;
            this.txtCodCliente.Location = new System.Drawing.Point(355, 52);
            this.txtCodCliente.LookUp = false;
            this.txtCodCliente.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Obrigatorio = false;
            this.txtCodCliente.Qtde_Casas_Decimais = 0;
            this.txtCodCliente.Size = new System.Drawing.Size(51, 20);
            this.txtCodCliente.SQLStatement = "";
            this.txtCodCliente.Tabela = "";
            this.txtCodCliente.Tabela_INNER = null;
            this.txtCodCliente.TabIndex = 5;
            this.txtCodCliente.TipoControles = CompSoft.TipoControle.Geral;
            this.txtCodCliente.ValorAnterior = "";
            this.txtCodCliente.Value = "";
            // 
            // chkEmpresa
            // 
            this.chkEmpresa.AutoSize = true;
            this.chkEmpresa.ControlSource = "";
            this.chkEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmpresa.Grupo = "";
            this.chkEmpresa.Incluir_QueryBy = false;
            this.chkEmpresa.Location = new System.Drawing.Point(284, 27);
            this.chkEmpresa.MensagemObrigatorio = "";
            this.chkEmpresa.Name = "chkEmpresa";
            this.chkEmpresa.Obrigatorio = false;
            this.chkEmpresa.ReadOnly = false;
            this.chkEmpresa.Size = new System.Drawing.Size(71, 17);
            this.chkEmpresa.Tabela = "";
            this.chkEmpresa.Tabela_INNER = null;
            this.chkEmpresa.TabIndex = 0;
            this.chkEmpresa.Text = "Empresa:";
            this.chkEmpresa.UseVisualStyleBackColor = true;
            this.chkEmpresa.ValorAnterior = false;
            this.chkEmpresa.Value = false;
            this.chkEmpresa.CheckedChanged += new System.EventHandler(this.chkEmpresa_CheckedChanged);
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.ControlSource = "";
            this.chkCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCliente.Grupo = "";
            this.chkCliente.Incluir_QueryBy = false;
            this.chkCliente.Location = new System.Drawing.Point(284, 53);
            this.chkCliente.MensagemObrigatorio = "";
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Obrigatorio = false;
            this.chkCliente.ReadOnly = false;
            this.chkCliente.Size = new System.Drawing.Size(63, 17);
            this.chkCliente.Tabela = "";
            this.chkCliente.Tabela_INNER = null;
            this.chkCliente.TabIndex = 4;
            this.chkCliente.Text = "Cliente:";
            this.chkCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.ValorAnterior = false;
            this.chkCliente.Value = false;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.ForeColor = System.Drawing.Color.Black;
            this.cmdPesquisar.Grupo = "";
            this.cmdPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdPesquisar.Location = new System.Drawing.Point(284, 86);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.ReadOnly = false;
            this.cmdPesquisar.Size = new System.Drawing.Size(75, 23);
            this.cmdPesquisar.TabIndex = 7;
            this.cmdPesquisar.TabStop = false;
            this.cmdPesquisar.Text = "Pesquisar";
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // cmdGerar
            // 
            this.cmdGerar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGerar.ForeColor = System.Drawing.Color.Black;
            this.cmdGerar.Grupo = "";
            this.cmdGerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdGerar.Location = new System.Drawing.Point(365, 86);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.ReadOnly = false;
            this.cmdGerar.Size = new System.Drawing.Size(75, 23);
            this.cmdGerar.TabIndex = 8;
            this.cmdGerar.TabStop = false;
            this.cmdGerar.Text = "Gerar";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // lblDataBaseVencimento
            // 
            this.lblDataBaseVencimento.AutoSize = true;
            this.lblDataBaseVencimento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataBaseVencimento.Location = new System.Drawing.Point(446, 90);
            this.lblDataBaseVencimento.Name = "lblDataBaseVencimento";
            this.lblDataBaseVencimento.Size = new System.Drawing.Size(118, 13);
            this.lblDataBaseVencimento.TabIndex = 9;
            this.lblDataBaseVencimento.Text = "Data base vencimento:";
            // 
            // txtDataBaseVencimento
            // 
            this.txtDataBaseVencimento.ControlSource = null;
            this.txtDataBaseVencimento.EditValue = null;
            this.txtDataBaseVencimento.Grupo = "";
            this.txtDataBaseVencimento.Incluir_QueryBy = true;
            this.txtDataBaseVencimento.Location = new System.Drawing.Point(567, 87);
            this.txtDataBaseVencimento.MensagemObrigatorio = "Campo obrigatório";
            this.txtDataBaseVencimento.Name = "txtDataBaseVencimento";
            this.txtDataBaseVencimento.Obrigatorio = false;
            this.txtDataBaseVencimento.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDataBaseVencimento.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtDataBaseVencimento.Properties.Appearance.Options.UseBackColor = true;
            this.txtDataBaseVencimento.Properties.Appearance.Options.UseForeColor = true;
            this.txtDataBaseVencimento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDataBaseVencimento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)), serializableAppearanceObject1, "", null, null, false)});
            this.txtDataBaseVencimento.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDataBaseVencimento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDataBaseVencimento.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtDataBaseVencimento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDataBaseVencimento.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtDataBaseVencimento.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.txtDataBaseVencimento.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDataBaseVencimento.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.txtDataBaseVencimento.Properties.Mask.BeepOnError = true;
            this.txtDataBaseVencimento.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtDataBaseVencimento.Properties.Mask.SaveLiteral = false;
            this.txtDataBaseVencimento.Properties.MaxValue = new System.DateTime(2158, 6, 30, 0, 0, 0, 0);
            this.txtDataBaseVencimento.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.txtDataBaseVencimento.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.txtDataBaseVencimento.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDataBaseVencimento.ReadOnly = false;
            this.txtDataBaseVencimento.Size = new System.Drawing.Size(100, 20);
            this.txtDataBaseVencimento.Tabela = "";
            this.txtDataBaseVencimento.Tabela_INNER = null;
            this.txtDataBaseVencimento.TabIndex = 10;
            this.txtDataBaseVencimento.ValorAnterior = null;
            this.txtDataBaseVencimento.Value = null;
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
            this.cboEmpresa.Incluir_QueryBy = true;
            this.cboEmpresa.Incluir_Reg_Selecione = false;
            this.cboEmpresa.Location = new System.Drawing.Point(355, 25);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.ReadOnly = false;
            this.cboEmpresa.Size = new System.Drawing.Size(322, 21);
            this.cboEmpresa.SQLStatement = "select Empresa, Nome_Fantasia from empresas where inativo = 0 order by Nome_Fanta" +
                "sia";
            this.cboEmpresa.Tabela = "";
            this.cboEmpresa.Tabela_INNER = null;
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.ValorAnterior = "";
            this.cboEmpresa.Value = null;
            // 
            // f0039
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Barra_Ferramentas_Excluir_Registro = false;
            this.Barra_Ferramentas_Novo_Registro = false;
            this.ClientSize = new System.Drawing.Size(683, 393);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.txtDataBaseVencimento);
            this.Controls.Add(this.lblDataBaseVencimento);
            this.Controls.Add(this.cmdGerar);
            this.Controls.Add(this.cmdPesquisar);
            this.Controls.Add(this.chkCliente);
            this.Controls.Add(this.chkEmpresa);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.grdPedidos);
            this.MainTabela = "notas_fiscais";
            this.Name = "f0039";
            this.Text = "Geração de nota fiscal";
            this.user_AfterSave += new CompSoft.FormSet.AfterSave(this.f0039_user_AfterSave);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.f0039_user_FormStatus_Change);
            this.user_BeforeSave += new CompSoft.FormSet.BeforeSave(this.f0039_user_BeforeSave);
            this.Shown += new System.EventHandler(this.f0039_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBaseVencimento.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBaseVencimento.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Periodo prdPeriodo;
        private CompSoft.cf_Bases.cf_DataGrid grdPedidos;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_RadioButton optEntrega;
        private CompSoft.cf_Bases.cf_RadioButton optPedido;
        private CompSoft.cf_Bases.cf_TextBox txtCliente;
        private CompSoft.cf_Bases.cf_TextBox txtCodCliente;
        private CompSoft.cf_Bases.cf_CheckBox chkEmpresa;
        private CompSoft.cf_Bases.cf_CheckBox chkCliente;
        private CompSoft.cf_Bases.cf_CheckBox chkData;
        private CompSoft.cf_Bases.cf_Button cmdPesquisar;
        private CompSoft.cf_Bases.cf_Button cmdGerar;
        private CompSoft.cf_Bases.cf_Label lblDataBaseVencimento;
        private CompSoft.cf_Bases.cf_DateEdit txtDataBaseVencimento;
        private CompSoft.cf_Bases.cf_ComboBox cboEmpresa;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selecionarTodasNotasFiscaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selecionarTodosCuponsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selecionarTudoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}