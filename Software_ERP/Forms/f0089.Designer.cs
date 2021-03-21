namespace ERP.Forms
{
    partial class f0089
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.prdDataEmissao = new CompSoft.cf_Bases.cf_Periodo();
            this.grdDados = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.chkAtivarDataEmissao = new CompSoft.cf_Bases.cf_CheckBox();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.chkApenasCancelada = new CompSoft.cf_Bases.cf_CheckBox();
            this.chkNfeNaoExportada = new CompSoft.cf_Bases.cf_CheckBox();
            this.chkCancelada = new CompSoft.cf_Bases.cf_CheckBox();
            this.lblTotalGeral = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.lblTotaAVista = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label6 = new CompSoft.cf_Bases.cf_Label();
            this.lblTotalAPrazo = new CompSoft.cf_Bases.cf_Label();
            this.chkAtivarEmpresa = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_GroupBox3 = new CompSoft.cf_Bases.cf_GroupBox();
            this.chkAtivarTipoDocumento = new CompSoft.cf_Bases.cf_CheckBox();
            this.rdoNotaFiscal = new CompSoft.cf_Bases.cf_RadioButton();
            this.rdoCupom = new CompSoft.cf_Bases.cf_RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDados)).BeginInit();
            this.cf_GroupBox1.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            this.cf_GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // prdDataEmissao
            // 
            this.prdDataEmissao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdDataEmissao.Location = new System.Drawing.Point(6, 21);
            this.prdDataEmissao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdDataEmissao.Name = "prdDataEmissao";
            this.prdDataEmissao.Size = new System.Drawing.Size(264, 51);
            this.prdDataEmissao.TabIndex = 0;
            // 
            // grdDados
            // 
            this.grdDados.Allow_Alter_Value_All_StatusForm = false;
            this.grdDados.AllowEditRow = true;
            this.grdDados.AllowUserToDeleteRows = false;
            this.grdDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDados.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdDados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDados.Cancel_OnClick = true;
            this.grdDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column9,
            this.Column8,
            this.Column7,
            this.Column3});
            this.grdDados.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdDados.GridColor = System.Drawing.Color.DimGray;
            this.grdDados.Location = new System.Drawing.Point(1, 126);
            this.grdDados.MultiSelect = false;
            this.grdDados.Name = "grdDados";
            this.grdDados.RowHeadersWidth = 24;
            this.grdDados.ShowCellErrors = false;
            this.grdDados.ShowCellToolTips = false;
            this.grdDados.ShowRowErrors = false;
            this.grdDados.Size = new System.Drawing.Size(604, 237);
            this.grdDados.TabIndex = 6;
            this.grdDados.TabStop = false;
            this.grdDados.VirtualMode = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Data_Emissao";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Data";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Pedido";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "00000";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Pedido";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Numero_Nota";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Nota Fiscal";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Cliente";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "Cliente";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Razao_Social";
            this.Column6.HeaderText = "Razão Social";
            this.Column6.Name = "Column6";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Parcelado";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column9.HeaderText = "Tipo Pgto.";
            this.Column9.Name = "Column9";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Desc_Cond_Pgto";
            this.Column8.HeaderText = "Condição de Pgto.";
            this.Column8.Name = "Column8";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Valor_Total_Produtos";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column7.HeaderText = "Valor Produtos";
            this.Column7.Name = "Column7";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Valor_Total_Nota";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column3.HeaderText = "Valor Total Nota";
            this.Column3.Name = "Column3";
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.chkAtivarDataEmissao);
            this.cf_GroupBox1.Controls.Add(this.prdDataEmissao);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(12, 39);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(283, 81);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 3;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Data Emissão";
            this.cf_GroupBox1.Value = "";
            // 
            // chkAtivarDataEmissao
            // 
            this.chkAtivarDataEmissao.AutoSize = true;
            this.chkAtivarDataEmissao.ControlSource = "";
            this.chkAtivarDataEmissao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivarDataEmissao.Grupo = "";
            this.chkAtivarDataEmissao.Incluir_QueryBy = false;
            this.chkAtivarDataEmissao.Location = new System.Drawing.Point(215, 0);
            this.chkAtivarDataEmissao.MensagemObrigatorio = "";
            this.chkAtivarDataEmissao.Name = "chkAtivarDataEmissao";
            this.chkAtivarDataEmissao.Obrigatorio = false;
            this.chkAtivarDataEmissao.ReadOnly = false;
            this.chkAtivarDataEmissao.Size = new System.Drawing.Size(55, 17);
            this.chkAtivarDataEmissao.Tabela = "";
            this.chkAtivarDataEmissao.Tabela_INNER = null;
            this.chkAtivarDataEmissao.TabIndex = 1;
            this.chkAtivarDataEmissao.Text = "Ativar";
            this.chkAtivarDataEmissao.UseVisualStyleBackColor = true;
            this.chkAtivarDataEmissao.ValorAnterior = false;
            this.chkAtivarDataEmissao.Value = false;
            this.chkAtivarDataEmissao.CheckedChanged += new System.EventHandler(this.chkAtivarDataEmissao_CheckedChanged);
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
            this.cboEmpresa.Location = new System.Drawing.Point(67, 12);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.ReadOnly = false;
            this.cboEmpresa.Size = new System.Drawing.Size(370, 21);
            this.cboEmpresa.SQLStatement = "SELECT empresa, Nome_Fantasia FROM Empresas WHERE Inativo = 0 ORDER BY Nome_Fanta" +
                "sia";
            this.cboEmpresa.Tabela = "";
            this.cboEmpresa.Tabela_INNER = null;
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.ValorAnterior = null;
            this.cboEmpresa.Value = null;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(9, 15);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(52, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Empresa:";
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.chkApenasCancelada);
            this.cf_GroupBox2.Controls.Add(this.chkNfeNaoExportada);
            this.cf_GroupBox2.Controls.Add(this.chkCancelada);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(301, 39);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(136, 81);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 4;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Situações - NF (Filtro)";
            this.cf_GroupBox2.Value = "";
            // 
            // chkApenasCancelada
            // 
            this.chkApenasCancelada.AutoSize = true;
            this.chkApenasCancelada.ControlSource = "";
            this.chkApenasCancelada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApenasCancelada.Grupo = "";
            this.chkApenasCancelada.Incluir_QueryBy = false;
            this.chkApenasCancelada.Location = new System.Drawing.Point(6, 18);
            this.chkApenasCancelada.MensagemObrigatorio = "";
            this.chkApenasCancelada.Name = "chkApenasCancelada";
            this.chkApenasCancelada.Obrigatorio = false;
            this.chkApenasCancelada.ReadOnly = false;
            this.chkApenasCancelada.Size = new System.Drawing.Size(113, 17);
            this.chkApenasCancelada.Tabela = "";
            this.chkApenasCancelada.Tabela_INNER = null;
            this.chkApenasCancelada.TabIndex = 0;
            this.chkApenasCancelada.Text = "Apenas cancelada";
            this.chkApenasCancelada.UseVisualStyleBackColor = true;
            this.chkApenasCancelada.ValorAnterior = false;
            this.chkApenasCancelada.Value = false;
            this.chkApenasCancelada.CheckedChanged += new System.EventHandler(this.chkApenasCancelada_CheckedChanged);
            // 
            // chkNfeNaoExportada
            // 
            this.chkNfeNaoExportada.AutoSize = true;
            this.chkNfeNaoExportada.ControlSource = "";
            this.chkNfeNaoExportada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNfeNaoExportada.Grupo = "";
            this.chkNfeNaoExportada.Incluir_QueryBy = false;
            this.chkNfeNaoExportada.Location = new System.Drawing.Point(6, 61);
            this.chkNfeNaoExportada.MensagemObrigatorio = "";
            this.chkNfeNaoExportada.Name = "chkNfeNaoExportada";
            this.chkNfeNaoExportada.Obrigatorio = false;
            this.chkNfeNaoExportada.ReadOnly = false;
            this.chkNfeNaoExportada.Size = new System.Drawing.Size(123, 17);
            this.chkNfeNaoExportada.Tabela = "";
            this.chkNfeNaoExportada.Tabela_INNER = null;
            this.chkNfeNaoExportada.TabIndex = 2;
            this.chkNfeNaoExportada.Text = "NF-e não exportada";
            this.chkNfeNaoExportada.UseVisualStyleBackColor = true;
            this.chkNfeNaoExportada.ValorAnterior = false;
            this.chkNfeNaoExportada.Value = false;
            // 
            // chkCancelada
            // 
            this.chkCancelada.AutoSize = true;
            this.chkCancelada.ControlSource = "";
            this.chkCancelada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCancelada.Grupo = "";
            this.chkCancelada.Incluir_QueryBy = false;
            this.chkCancelada.Location = new System.Drawing.Point(6, 39);
            this.chkCancelada.MensagemObrigatorio = "";
            this.chkCancelada.Name = "chkCancelada";
            this.chkCancelada.Obrigatorio = false;
            this.chkCancelada.ReadOnly = false;
            this.chkCancelada.Size = new System.Drawing.Size(106, 17);
            this.chkCancelada.Tabela = "";
            this.chkCancelada.Tabela_INNER = null;
            this.chkCancelada.TabIndex = 1;
            this.chkCancelada.Text = "Incluir cancelada";
            this.chkCancelada.UseVisualStyleBackColor = true;
            this.chkCancelada.ValorAnterior = false;
            this.chkCancelada.Value = false;
            // 
            // lblTotalGeral
            // 
            this.lblTotalGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalGeral.AutoSize = true;
            this.lblTotalGeral.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeral.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalGeral.Location = new System.Drawing.Point(487, 385);
            this.lblTotalGeral.Name = "lblTotalGeral";
            this.lblTotalGeral.Size = new System.Drawing.Size(71, 19);
            this.lblTotalGeral.TabIndex = 12;
            this.lblTotalGeral.Text = "R$ 0,00";
            this.lblTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cf_Label3
            // 
            this.cf_Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(376, 385);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(105, 19);
            this.cf_Label3.TabIndex = 11;
            this.cf_Label3.Text = "Total geral:";
            // 
            // cf_Label4
            // 
            this.cf_Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(55, 373);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(117, 19);
            this.cf_Label4.TabIndex = 7;
            this.cf_Label4.Text = "Total a vista:";
            // 
            // lblTotaAVista
            // 
            this.lblTotaAVista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotaAVista.AutoSize = true;
            this.lblTotaAVista.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotaAVista.ForeColor = System.Drawing.Color.Blue;
            this.lblTotaAVista.Location = new System.Drawing.Point(178, 373);
            this.lblTotaAVista.Name = "lblTotaAVista";
            this.lblTotaAVista.Size = new System.Drawing.Size(71, 19);
            this.lblTotaAVista.TabIndex = 9;
            this.lblTotaAVista.Text = "R$ 0,00";
            this.lblTotaAVista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cf_Label6
            // 
            this.cf_Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cf_Label6.AutoSize = true;
            this.cf_Label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label6.Location = new System.Drawing.Point(48, 397);
            this.cf_Label6.Name = "cf_Label6";
            this.cf_Label6.Size = new System.Drawing.Size(124, 19);
            this.cf_Label6.TabIndex = 8;
            this.cf_Label6.Text = "Total a prazo:";
            // 
            // lblTotalAPrazo
            // 
            this.lblTotalAPrazo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAPrazo.AutoSize = true;
            this.lblTotalAPrazo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAPrazo.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalAPrazo.Location = new System.Drawing.Point(178, 397);
            this.lblTotalAPrazo.Name = "lblTotalAPrazo";
            this.lblTotalAPrazo.Size = new System.Drawing.Size(71, 19);
            this.lblTotalAPrazo.TabIndex = 10;
            this.lblTotalAPrazo.Text = "R$ 0,00";
            this.lblTotalAPrazo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAtivarEmpresa
            // 
            this.chkAtivarEmpresa.AutoSize = true;
            this.chkAtivarEmpresa.ControlSource = "";
            this.chkAtivarEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivarEmpresa.Grupo = "";
            this.chkAtivarEmpresa.Incluir_QueryBy = false;
            this.chkAtivarEmpresa.Location = new System.Drawing.Point(443, 14);
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
            // cf_GroupBox3
            // 
            this.cf_GroupBox3.Controls.Add(this.rdoCupom);
            this.cf_GroupBox3.Controls.Add(this.rdoNotaFiscal);
            this.cf_GroupBox3.Controls.Add(this.chkAtivarTipoDocumento);
            this.cf_GroupBox3.ControlSource = "";
            this.cf_GroupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox3.Location = new System.Drawing.Point(443, 39);
            this.cf_GroupBox3.Name = "cf_GroupBox3";
            this.cf_GroupBox3.Size = new System.Drawing.Size(151, 81);
            this.cf_GroupBox3.Tabela = "";
            this.cf_GroupBox3.TabIndex = 13;
            this.cf_GroupBox3.TabStop = false;
            this.cf_GroupBox3.Text = "Tipo Documento";
            this.cf_GroupBox3.Value = "";
            // 
            // chkAtivarTipoDocumento
            // 
            this.chkAtivarTipoDocumento.AutoSize = true;
            this.chkAtivarTipoDocumento.ControlSource = "";
            this.chkAtivarTipoDocumento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivarTipoDocumento.Grupo = "";
            this.chkAtivarTipoDocumento.Incluir_QueryBy = false;
            this.chkAtivarTipoDocumento.Location = new System.Drawing.Point(90, 0);
            this.chkAtivarTipoDocumento.MensagemObrigatorio = "";
            this.chkAtivarTipoDocumento.Name = "chkAtivarTipoDocumento";
            this.chkAtivarTipoDocumento.Obrigatorio = false;
            this.chkAtivarTipoDocumento.ReadOnly = false;
            this.chkAtivarTipoDocumento.Size = new System.Drawing.Size(55, 17);
            this.chkAtivarTipoDocumento.Tabela = "";
            this.chkAtivarTipoDocumento.Tabela_INNER = null;
            this.chkAtivarTipoDocumento.TabIndex = 2;
            this.chkAtivarTipoDocumento.Text = "Ativar";
            this.chkAtivarTipoDocumento.UseVisualStyleBackColor = true;
            this.chkAtivarTipoDocumento.ValorAnterior = false;
            this.chkAtivarTipoDocumento.Value = false;
            this.chkAtivarTipoDocumento.CheckedChanged += new System.EventHandler(this.chkAtivarTipoDocumento_CheckedChanged);
            // 
            // rdoNotaFiscal
            // 
            this.rdoNotaFiscal.AutoSize = true;
            this.rdoNotaFiscal.ControlSource = "";
            this.rdoNotaFiscal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNotaFiscal.Grupo = "";
            this.rdoNotaFiscal.Incluir_QueryBy = false;
            this.rdoNotaFiscal.Location = new System.Drawing.Point(13, 28);
            this.rdoNotaFiscal.MensagemObrigatorio = "";
            this.rdoNotaFiscal.Name = "rdoNotaFiscal";
            this.rdoNotaFiscal.Obrigatorio = false;
            this.rdoNotaFiscal.ReadOnly = false;
            this.rdoNotaFiscal.Size = new System.Drawing.Size(77, 17);
            this.rdoNotaFiscal.Tabela = "";
            this.rdoNotaFiscal.Tabela_INNER = null;
            this.rdoNotaFiscal.TabIndex = 3;
            this.rdoNotaFiscal.TabStop = true;
            this.rdoNotaFiscal.Text = "Nota Fiscal";
            this.rdoNotaFiscal.UseVisualStyleBackColor = true;
            this.rdoNotaFiscal.ValorAnterior = false;
            this.rdoNotaFiscal.Value = false;
            // 
            // rdoCupom
            // 
            this.rdoCupom.AutoSize = true;
            this.rdoCupom.ControlSource = "";
            this.rdoCupom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCupom.Grupo = "";
            this.rdoCupom.Incluir_QueryBy = false;
            this.rdoCupom.Location = new System.Drawing.Point(13, 51);
            this.rdoCupom.MensagemObrigatorio = "";
            this.rdoCupom.Name = "rdoCupom";
            this.rdoCupom.Obrigatorio = false;
            this.rdoCupom.ReadOnly = false;
            this.rdoCupom.Size = new System.Drawing.Size(58, 17);
            this.rdoCupom.Tabela = "";
            this.rdoCupom.Tabela_INNER = null;
            this.rdoCupom.TabIndex = 4;
            this.rdoCupom.TabStop = true;
            this.rdoCupom.Text = "Cupom";
            this.rdoCupom.UseVisualStyleBackColor = true;
            this.rdoCupom.ValorAnterior = false;
            this.rdoCupom.Value = false;
            // 
            // f0089
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Barra_Ferramentas_Editar_Registro = false;
            this.Barra_Ferramentas_Excluir_Registro = false;
            this.Barra_Ferramentas_Novo_Registro = false;
            this.ClientSize = new System.Drawing.Size(606, 425);
            this.Controls.Add(this.cf_GroupBox3);
            this.Controls.Add(this.chkAtivarEmpresa);
            this.Controls.Add(this.cf_Label6);
            this.Controls.Add(this.lblTotalAPrazo);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.lblTotaAVista);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.lblTotalGeral);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.grdDados);
            this.MainTabela = "notas_fiscais";
            this.Name = "f0089";
            this.Text = "Notas Fiscais - Faturamento";
            this.Tipo_Formulario = CompSoft.TipoForm.Consulta;
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0089_user_AfterRefreshData);
            this.user_AfterClear += new CompSoft.FormSet.AfterClear(this.f0089_user_AfterClear);
            this.Load += new System.EventHandler(this.f0089_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDados)).EndInit();
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox2.PerformLayout();
            this.cf_GroupBox3.ResumeLayout(false);
            this.cf_GroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Periodo prdDataEmissao;
        private CompSoft.cf_Bases.cf_DataGrid grdDados;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivarDataEmissao;
        private CompSoft.cf_Bases.cf_ComboBox cboEmpresa;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_CheckBox chkNfeNaoExportada;
        private CompSoft.cf_Bases.cf_CheckBox chkCancelada;
        private CompSoft.cf_Bases.cf_Label lblTotalGeral;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_Label lblTotaAVista;
        private CompSoft.cf_Bases.cf_Label cf_Label6;
        private CompSoft.cf_Bases.cf_Label lblTotalAPrazo;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivarEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private CompSoft.cf_Bases.cf_CheckBox chkApenasCancelada;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox3;
        private CompSoft.cf_Bases.cf_RadioButton rdoCupom;
        private CompSoft.cf_Bases.cf_RadioButton rdoNotaFiscal;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivarTipoDocumento;
    }
}