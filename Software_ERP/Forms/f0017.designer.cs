namespace ERP.Forms
{
    partial class f0017
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cf_Label12 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label9 = new CompSoft.cf_Bases.cf_Label();
            this.txtValorPagar = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label8 = new CompSoft.cf_Bases.cf_Label();
            this.txtValorOriginal = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label5 = new CompSoft.cf_Bases.cf_Label();
            this.cboTipoDocumento = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.txtNumeroDocumento = new CompSoft.cf_Bases.cf_TextBox();
            this.txtDescCliente = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.txtCliente = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtCodTitulo = new CompSoft.cf_Bases.cf_TextBox();
            this.txtDescFilial = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.txtFilial = new CompSoft.cf_Bases.cf_TextBox();
            this.grdParcelas = new CompSoft.cf_Bases.cf_DataGrid();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.agParcelas = new CompSoft.cf_Bases.cf_AcaoGrid();
            this.cmdGerarParcelas = new CompSoft.cf_Bases.cf_Button();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.txtPrimeiraDataVencimento = new CompSoft.cf_Bases.cf_DateEdit();
            this.cf_Label18 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label17 = new CompSoft.cf_Bases.cf_Label();
            this.txtQtdeParcelas = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label16 = new CompSoft.cf_Bases.cf_Label();
            this.optParcelamento_EmDias = new CompSoft.cf_Bases.cf_RadioButton();
            this.opgParcelamento_DiaFixo = new CompSoft.cf_Bases.cf_RadioButton();
            this.txtParcelamentoQtde = new CompSoft.cf_Bases.cf_TextBox();
            this.txtDtCadastro = new CompSoft.cf_Bases.cf_DateEdit();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewDatePikerColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdParcelas)).BeginInit();
            this.cf_GroupBox1.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimeiraDataVencimento.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimeiraDataVencimento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtCadastro.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtCadastro.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cf_Label12
            // 
            this.cf_Label12.AutoSize = true;
            this.cf_Label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label12.Location = new System.Drawing.Point(289, 127);
            this.cf_Label12.Name = "cf_Label12";
            this.cf_Label12.Size = new System.Drawing.Size(79, 13);
            this.cf_Label12.TabIndex = 14;
            this.cf_Label12.Text = "Data cadastro:";
            // 
            // cf_Label9
            // 
            this.cf_Label9.AutoSize = true;
            this.cf_Label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label9.Location = new System.Drawing.Point(20, 153);
            this.cf_Label9.Name = "cf_Label9";
            this.cf_Label9.Size = new System.Drawing.Size(117, 13);
            this.cf_Label9.TabIndex = 16;
            this.cf_Label9.Text = "Valor a pagar do titulo:";
            // 
            // txtValorPagar
            // 
            this.txtValorPagar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValorPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorPagar.Coluna_LookUp = 0;
            this.txtValorPagar.ControlSource = "Valor_Pago";
            this.txtValorPagar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPagar.ForeColor = System.Drawing.Color.DimGray;
            this.txtValorPagar.Grupo = "";
            this.txtValorPagar.Incluir_QueryBy = true;
            this.txtValorPagar.Location = new System.Drawing.Point(143, 150);
            this.txtValorPagar.LookUp = false;
            this.txtValorPagar.MensagemObrigatorio = "Campo obrigatório";
            this.txtValorPagar.Name = "txtValorPagar";
            this.txtValorPagar.Obrigatorio = false;
            this.txtValorPagar.Qtde_Casas_Decimais = 0;
            this.txtValorPagar.Size = new System.Drawing.Size(136, 20);
            this.txtValorPagar.SQLStatement = "";
            this.txtValorPagar.Tabela = "contas_pagar";
            this.txtValorPagar.Tabela_INNER = null;
            this.txtValorPagar.TabIndex = 17;
            this.txtValorPagar.Text = null;
            this.txtValorPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorPagar.TipoControles = CompSoft.TipoControle.Moeda;
            this.txtValorPagar.ValorAnterior = "";
            this.txtValorPagar.Value = null;
            // 
            // cf_Label8
            // 
            this.cf_Label8.AutoSize = true;
            this.cf_Label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label8.Location = new System.Drawing.Point(23, 127);
            this.cf_Label8.Name = "cf_Label8";
            this.cf_Label8.Size = new System.Drawing.Size(114, 13);
            this.cf_Label8.TabIndex = 12;
            this.cf_Label8.Text = "Valor original do titulo:";
            // 
            // txtValorOriginal
            // 
            this.txtValorOriginal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValorOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorOriginal.Coluna_LookUp = 0;
            this.txtValorOriginal.ControlSource = "Valor_Original";
            this.txtValorOriginal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorOriginal.ForeColor = System.Drawing.Color.DimGray;
            this.txtValorOriginal.Grupo = "";
            this.txtValorOriginal.Incluir_QueryBy = true;
            this.txtValorOriginal.Location = new System.Drawing.Point(143, 124);
            this.txtValorOriginal.LookUp = false;
            this.txtValorOriginal.MensagemObrigatorio = "Campo obrigatório";
            this.txtValorOriginal.Name = "txtValorOriginal";
            this.txtValorOriginal.Obrigatorio = false;
            this.txtValorOriginal.Qtde_Casas_Decimais = 0;
            this.txtValorOriginal.Size = new System.Drawing.Size(136, 20);
            this.txtValorOriginal.SQLStatement = "";
            this.txtValorOriginal.Tabela = "contas_pagar";
            this.txtValorOriginal.Tabela_INNER = null;
            this.txtValorOriginal.TabIndex = 13;
            this.txtValorOriginal.Text = null;
            this.txtValorOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorOriginal.TipoControles = CompSoft.TipoControle.Moeda;
            this.txtValorOriginal.ValorAnterior = "";
            this.txtValorOriginal.Value = null;
            this.txtValorOriginal.Validated += new System.EventHandler(this.txtValorOriginal_Validated);
            // 
            // cf_Label5
            // 
            this.cf_Label5.AutoSize = true;
            this.cf_Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label5.Location = new System.Drawing.Point(7, 93);
            this.cf_Label5.Name = "cf_Label5";
            this.cf_Label5.Size = new System.Drawing.Size(102, 13);
            this.cf_Label5.TabIndex = 10;
            this.cf_Label5.Text = "Tipo de documento:";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboTipoDocumento.ControlSource = "Tipo_Documento";
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTipoDocumento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDocumento.ForeColor = System.Drawing.Color.DimGray;
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Grupo = "";
            this.cboTipoDocumento.Incluir_QueryBy = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(115, 90);
            this.cboTipoDocumento.MensagemObrigatorio = "Campo obrigatório";
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Obrigatorio = false;
            this.cboTipoDocumento.ReadOnly = false;
            this.cboTipoDocumento.Size = new System.Drawing.Size(254, 21);
            this.cboTipoDocumento.SQLStatement = "select * from tipos_documentos where inativo = 0 order by desc_tipo_documento";
            this.cboTipoDocumento.Tabela = "contas_pagar";
            this.cboTipoDocumento.Tabela_INNER = null;
            this.cboTipoDocumento.TabIndex = 11;
            this.cboTipoDocumento.ValorAnterior = "";
            this.cboTipoDocumento.Value = null;
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(230, 15);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(104, 13);
            this.cf_Label4.TabIndex = 2;
            this.cf_Label4.Text = "Número documento:";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroDocumento.Coluna_LookUp = 0;
            this.txtNumeroDocumento.ControlSource = "Numero_Documento";
            this.txtNumeroDocumento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDocumento.ForeColor = System.Drawing.Color.DimGray;
            this.txtNumeroDocumento.Grupo = "";
            this.txtNumeroDocumento.Incluir_QueryBy = true;
            this.txtNumeroDocumento.Location = new System.Drawing.Point(338, 12);
            this.txtNumeroDocumento.LookUp = false;
            this.txtNumeroDocumento.MensagemObrigatorio = "Campo obrigatório";
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Obrigatorio = false;
            this.txtNumeroDocumento.Qtde_Casas_Decimais = 0;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(136, 20);
            this.txtNumeroDocumento.SQLStatement = "";
            this.txtNumeroDocumento.Tabela = "contas_pagar";
            this.txtNumeroDocumento.Tabela_INNER = null;
            this.txtNumeroDocumento.TabIndex = 3;
            this.txtNumeroDocumento.TipoControles = CompSoft.TipoControle.Geral;
            this.txtNumeroDocumento.ValorAnterior = "";
            this.txtNumeroDocumento.Value = "";
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtDescCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescCliente.Coluna_LookUp = 1;
            this.txtDescCliente.ControlSource = "Razao_Social";
            this.txtDescCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescCliente.ForeColor = System.Drawing.Color.Black;
            this.txtDescCliente.Grupo = "";
            this.txtDescCliente.Incluir_QueryBy = false;
            this.txtDescCliente.Location = new System.Drawing.Point(143, 64);
            this.txtDescCliente.LookUp = true;
            this.txtDescCliente.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Obrigatorio = false;
            this.txtDescCliente.Qtde_Casas_Decimais = 0;
            this.txtDescCliente.Size = new System.Drawing.Size(331, 20);
            this.txtDescCliente.SQLStatement = "select Cliente, Razao_Social, CPF_Cnpj from clientes where Tipo_Fornecedor = 1 an" +
                "d Razao_Social@";
            this.txtDescCliente.Tabela = "contas_pagar";
            this.txtDescCliente.Tabela_INNER = "cl";
            this.txtDescCliente.TabIndex = 9;
            this.txtDescCliente.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescCliente.ValorAnterior = "";
            this.txtDescCliente.Value = "";
            this.txtDescCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescCliente_Validating);
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(9, 67);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(66, 13);
            this.cf_Label3.TabIndex = 7;
            this.cf_Label3.Text = "Fornecedor:";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Coluna_LookUp = 0;
            this.txtCliente.ControlSource = "Cliente";
            this.txtCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCliente.Grupo = "";
            this.txtCliente.Incluir_QueryBy = true;
            this.txtCliente.Location = new System.Drawing.Point(76, 64);
            this.txtCliente.LookUp = true;
            this.txtCliente.MensagemObrigatorio = "Campo obrigatório";
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Obrigatorio = false;
            this.txtCliente.Qtde_Casas_Decimais = 0;
            this.txtCliente.Size = new System.Drawing.Size(57, 20);
            this.txtCliente.SQLStatement = "select Cliente, Razao_Social, CPF_Cnpj from clientes where Tipo_Fornecedor = 1 an" +
                "d cliente@";
            this.txtCliente.Tabela = "contas_pagar";
            this.txtCliente.Tabela_INNER = null;
            this.txtCliente.TabIndex = 8;
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCliente.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCliente.ValorAnterior = "";
            this.txtCliente.Value = "";
            this.txtCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtCliente_Validating);
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(12, 14);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(63, 13);
            this.cf_Label2.TabIndex = 0;
            this.cf_Label2.Text = "Cód. Titulo:";
            // 
            // txtCodTitulo
            // 
            this.txtCodTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodTitulo.Coluna_LookUp = 0;
            this.txtCodTitulo.ControlSource = "Conta_Pagar";
            this.txtCodTitulo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodTitulo.Grupo = "";
            this.txtCodTitulo.Incluir_QueryBy = true;
            this.txtCodTitulo.Location = new System.Drawing.Point(76, 12);
            this.txtCodTitulo.LookUp = false;
            this.txtCodTitulo.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodTitulo.Name = "txtCodTitulo";
            this.txtCodTitulo.Obrigatorio = false;
            this.txtCodTitulo.Qtde_Casas_Decimais = 0;
            this.txtCodTitulo.Size = new System.Drawing.Size(91, 20);
            this.txtCodTitulo.SQLStatement = "";
            this.txtCodTitulo.Tabela = "contas_pagar";
            this.txtCodTitulo.Tabela_INNER = null;
            this.txtCodTitulo.TabIndex = 1;
            this.txtCodTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodTitulo.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCodTitulo.ValorAnterior = "";
            this.txtCodTitulo.Value = "";
            // 
            // txtDescFilial
            // 
            this.txtDescFilial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescFilial.Coluna_LookUp = 0;
            this.txtDescFilial.ControlSource = "Razao_Social_Filial";
            this.txtDescFilial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescFilial.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescFilial.Grupo = "";
            this.txtDescFilial.Incluir_QueryBy = false;
            this.txtDescFilial.Location = new System.Drawing.Point(143, 38);
            this.txtDescFilial.LookUp = false;
            this.txtDescFilial.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescFilial.Name = "txtDescFilial";
            this.txtDescFilial.Obrigatorio = false;
            this.txtDescFilial.Qtde_Casas_Decimais = 0;
            this.txtDescFilial.Size = new System.Drawing.Size(331, 20);
            this.txtDescFilial.SQLStatement = "";
            this.txtDescFilial.Tabela = "contas_pagar";
            this.txtDescFilial.Tabela_INNER = "F";
            this.txtDescFilial.TabIndex = 6;
            this.txtDescFilial.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescFilial.ValorAnterior = "";
            this.txtDescFilial.Value = "";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(23, 41);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(52, 13);
            this.cf_Label1.TabIndex = 4;
            this.cf_Label1.Text = "Empresa:";
            // 
            // txtFilial
            // 
            this.txtFilial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilial.Coluna_LookUp = 0;
            this.txtFilial.ControlSource = "Empresa";
            this.txtFilial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilial.ForeColor = System.Drawing.Color.Black;
            this.txtFilial.Grupo = "";
            this.txtFilial.Incluir_QueryBy = true;
            this.txtFilial.Location = new System.Drawing.Point(76, 38);
            this.txtFilial.LookUp = true;
            this.txtFilial.MensagemObrigatorio = "Campo obrigatório";
            this.txtFilial.Name = "txtFilial";
            this.txtFilial.Obrigatorio = false;
            this.txtFilial.Qtde_Casas_Decimais = 0;
            this.txtFilial.Size = new System.Drawing.Size(57, 20);
            this.txtFilial.SQLStatement = "select Empresa, Razao_Social, Cnpj from Empresas where empresa@";
            this.txtFilial.Tabela = "contas_pagar";
            this.txtFilial.Tabela_INNER = null;
            this.txtFilial.TabIndex = 5;
            this.txtFilial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFilial.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtFilial.ValorAnterior = "";
            this.txtFilial.Value = "";
            this.txtFilial.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilial_Validating);
            // 
            // grdParcelas
            // 
            this.grdParcelas.Allow_Alter_Value_All_StatusForm = false;
            this.grdParcelas.AllowEditRow = true;
            this.grdParcelas.AllowUserToAddRows = false;
            this.grdParcelas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.grdParcelas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdParcelas.BackgroundColor = System.Drawing.Color.Gray;
            this.grdParcelas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdParcelas.Cancel_OnClick = true;
            this.grdParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.NullValue = "(nulo)";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdParcelas.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdParcelas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdParcelas.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdParcelas.GridColor = System.Drawing.Color.DimGray;
            this.grdParcelas.Location = new System.Drawing.Point(35, 21);
            this.grdParcelas.MultiSelect = false;
            this.grdParcelas.Name = "grdParcelas";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdParcelas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdParcelas.RowHeadersWidth = 15;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.grdParcelas.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdParcelas.RowTemplate.Height = 20;
            this.grdParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdParcelas.ShowCellErrors = false;
            this.grdParcelas.ShowCellToolTips = false;
            this.grdParcelas.ShowEditingIcon = false;
            this.grdParcelas.ShowRowErrors = false;
            this.grdParcelas.Size = new System.Drawing.Size(603, 179);
            this.grdParcelas.TabIndex = 0;
            this.grdParcelas.TabStop = false;
            this.grdParcelas.VirtualMode = true;
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.agParcelas);
            this.cf_GroupBox1.Controls.Add(this.grdParcelas);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(8, 197);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(644, 206);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 18;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Parcelamento automático";
            this.cf_GroupBox1.Value = "";
            // 
            // agParcelas
            // 
            this.agParcelas.BackColor = System.Drawing.Color.Transparent;
            this.agParcelas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agParcelas.Location = new System.Drawing.Point(6, 42);
            this.agParcelas.Name = "agParcelas";
            this.agParcelas.Permitir_Alteracao = true;
            this.agParcelas.Permitir_Exclusao = true;
            this.agParcelas.Permitir_Inclusao = true;
            this.agParcelas.Size = new System.Drawing.Size(23, 47);
            this.agParcelas.TabIndex = 13;
            this.agParcelas.user_After_Novo_OnClick += new CompSoft.cf_Bases.cf_AcaoGrid.After_Novo_OnClick(this.agParcelas_user_After_Novo_OnClick);
            this.agParcelas.user_After_Click_All_Button_OnClick += new CompSoft.cf_Bases.cf_AcaoGrid.After_Click_All_Button_OnClick(this.agParcelas_user_After_Click_All_Button_OnClick);
            // 
            // cmdGerarParcelas
            // 
            this.cmdGerarParcelas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGerarParcelas.ForeColor = System.Drawing.Color.Black;
            this.cmdGerarParcelas.Grupo = "";
            this.cmdGerarParcelas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdGerarParcelas.Location = new System.Drawing.Point(30, 165);
            this.cmdGerarParcelas.Name = "cmdGerarParcelas";
            this.cmdGerarParcelas.Size = new System.Drawing.Size(122, 23);
            this.cmdGerarParcelas.TabIndex = 8;
            this.cmdGerarParcelas.TabStop = false;
            this.cmdGerarParcelas.Text = "Gerar parcelas";
            this.cmdGerarParcelas.UseVisualStyleBackColor = true;
            this.cmdGerarParcelas.Click += new System.EventHandler(this.cmdGerarParcelas_Click);
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.txtPrimeiraDataVencimento);
            this.cf_GroupBox2.Controls.Add(this.cmdGerarParcelas);
            this.cf_GroupBox2.Controls.Add(this.cf_Label18);
            this.cf_GroupBox2.Controls.Add(this.cf_Label17);
            this.cf_GroupBox2.Controls.Add(this.txtQtdeParcelas);
            this.cf_GroupBox2.Controls.Add(this.cf_Label16);
            this.cf_GroupBox2.Controls.Add(this.optParcelamento_EmDias);
            this.cf_GroupBox2.Controls.Add(this.opgParcelamento_DiaFixo);
            this.cf_GroupBox2.Controls.Add(this.txtParcelamentoQtde);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(480, 6);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(172, 193);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 19;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Parametros para parcelamento";
            this.cf_GroupBox2.Value = "";
            // 
            // txtPrimeiraDataVencimento
            // 
            this.txtPrimeiraDataVencimento.ControlSource = null;
            this.txtPrimeiraDataVencimento.EditValue = null;
            this.txtPrimeiraDataVencimento.Grupo = "";
            this.txtPrimeiraDataVencimento.Incluir_QueryBy = true;
            this.txtPrimeiraDataVencimento.Location = new System.Drawing.Point(34, 141);
            this.txtPrimeiraDataVencimento.MensagemObrigatorio = "Campo obrigatório";
            this.txtPrimeiraDataVencimento.Name = "txtPrimeiraDataVencimento";
            this.txtPrimeiraDataVencimento.Obrigatorio = false;
            this.txtPrimeiraDataVencimento.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPrimeiraDataVencimento.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtPrimeiraDataVencimento.Properties.Appearance.Options.UseBackColor = true;
            this.txtPrimeiraDataVencimento.Properties.Appearance.Options.UseForeColor = true;
            this.txtPrimeiraDataVencimento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPrimeiraDataVencimento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)))});
            this.txtPrimeiraDataVencimento.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtPrimeiraDataVencimento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPrimeiraDataVencimento.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtPrimeiraDataVencimento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPrimeiraDataVencimento.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.txtPrimeiraDataVencimento.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPrimeiraDataVencimento.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.txtPrimeiraDataVencimento.Properties.Mask.BeepOnError = true;
            this.txtPrimeiraDataVencimento.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtPrimeiraDataVencimento.Properties.Mask.SaveLiteral = false;
            this.txtPrimeiraDataVencimento.Properties.MaxValue = new System.DateTime(2158, 10, 31, 0, 0, 0, 0);
            this.txtPrimeiraDataVencimento.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.txtPrimeiraDataVencimento.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPrimeiraDataVencimento.ReadOnly = false;
            this.txtPrimeiraDataVencimento.Size = new System.Drawing.Size(115, 20);
            this.txtPrimeiraDataVencimento.Tabela = "";
            this.txtPrimeiraDataVencimento.Tabela_INNER = null;
            this.txtPrimeiraDataVencimento.TabIndex = 7;
            this.txtPrimeiraDataVencimento.ValorAnterior = null;
            this.txtPrimeiraDataVencimento.Value = null;
            // 
            // cf_Label18
            // 
            this.cf_Label18.AutoSize = true;
            this.cf_Label18.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label18.Location = new System.Drawing.Point(31, 125);
            this.cf_Label18.Name = "cf_Label18";
            this.cf_Label18.Size = new System.Drawing.Size(121, 13);
            this.cf_Label18.TabIndex = 6;
            this.cf_Label18.Text = "1º Data de vencimento:";
            // 
            // cf_Label17
            // 
            this.cf_Label17.AutoSize = true;
            this.cf_Label17.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label17.Location = new System.Drawing.Point(17, 99);
            this.cf_Label17.Name = "cf_Label17";
            this.cf_Label17.Size = new System.Drawing.Size(78, 13);
            this.cf_Label17.TabIndex = 4;
            this.cf_Label17.Text = "Qtde parcelas:";
            // 
            // txtQtdeParcelas
            // 
            this.txtQtdeParcelas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQtdeParcelas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtdeParcelas.Coluna_LookUp = 0;
            this.txtQtdeParcelas.ControlSource = "";
            this.txtQtdeParcelas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtdeParcelas.ForeColor = System.Drawing.Color.DimGray;
            this.txtQtdeParcelas.Grupo = "";
            this.txtQtdeParcelas.Incluir_QueryBy = true;
            this.txtQtdeParcelas.Location = new System.Drawing.Point(101, 97);
            this.txtQtdeParcelas.LookUp = false;
            this.txtQtdeParcelas.MensagemObrigatorio = "Campo obrigatório";
            this.txtQtdeParcelas.Name = "txtQtdeParcelas";
            this.txtQtdeParcelas.Obrigatorio = false;
            this.txtQtdeParcelas.Qtde_Casas_Decimais = 0;
            this.txtQtdeParcelas.Size = new System.Drawing.Size(49, 20);
            this.txtQtdeParcelas.SQLStatement = "";
            this.txtQtdeParcelas.Tabela = "";
            this.txtQtdeParcelas.Tabela_INNER = null;
            this.txtQtdeParcelas.TabIndex = 5;
            this.txtQtdeParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtdeParcelas.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtQtdeParcelas.ValorAnterior = "";
            this.txtQtdeParcelas.Value = "";
            // 
            // cf_Label16
            // 
            this.cf_Label16.AutoSize = true;
            this.cf_Label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label16.Location = new System.Drawing.Point(38, 74);
            this.cf_Label16.Name = "cf_Label16";
            this.cf_Label16.Size = new System.Drawing.Size(57, 13);
            this.cf_Label16.TabIndex = 2;
            this.cf_Label16.Text = "Qtde dias:";
            // 
            // optParcelamento_EmDias
            // 
            this.optParcelamento_EmDias.AutoSize = true;
            this.optParcelamento_EmDias.ControlSource = "";
            this.optParcelamento_EmDias.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optParcelamento_EmDias.Grupo = "";
            this.optParcelamento_EmDias.Incluir_QueryBy = false;
            this.optParcelamento_EmDias.Location = new System.Drawing.Point(16, 45);
            this.optParcelamento_EmDias.MensagemObrigatorio = "";
            this.optParcelamento_EmDias.Name = "optParcelamento_EmDias";
            this.optParcelamento_EmDias.Obrigatorio = false;
            this.optParcelamento_EmDias.ReadOnly = false;
            this.optParcelamento_EmDias.Size = new System.Drawing.Size(136, 17);
            this.optParcelamento_EmDias.Tabela = "";
            this.optParcelamento_EmDias.Tabela_INNER = null;
            this.optParcelamento_EmDias.TabIndex = 1;
            this.optParcelamento_EmDias.Text = "Parcelamento - Em dias";
            this.optParcelamento_EmDias.UseVisualStyleBackColor = true;
            this.optParcelamento_EmDias.ValorAnterior = false;
            this.optParcelamento_EmDias.Value = false;
            this.optParcelamento_EmDias.CheckedChanged += new System.EventHandler(this.optParcelamento_EmDias_CheckedChanged);
            // 
            // opgParcelamento_DiaFixo
            // 
            this.opgParcelamento_DiaFixo.AutoSize = true;
            this.opgParcelamento_DiaFixo.Checked = true;
            this.opgParcelamento_DiaFixo.ControlSource = "";
            this.opgParcelamento_DiaFixo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opgParcelamento_DiaFixo.Grupo = "";
            this.opgParcelamento_DiaFixo.Incluir_QueryBy = false;
            this.opgParcelamento_DiaFixo.Location = new System.Drawing.Point(16, 26);
            this.opgParcelamento_DiaFixo.MensagemObrigatorio = "";
            this.opgParcelamento_DiaFixo.Name = "opgParcelamento_DiaFixo";
            this.opgParcelamento_DiaFixo.Obrigatorio = false;
            this.opgParcelamento_DiaFixo.ReadOnly = false;
            this.opgParcelamento_DiaFixo.Size = new System.Drawing.Size(133, 17);
            this.opgParcelamento_DiaFixo.Tabela = "";
            this.opgParcelamento_DiaFixo.Tabela_INNER = null;
            this.opgParcelamento_DiaFixo.TabIndex = 0;
            this.opgParcelamento_DiaFixo.TabStop = true;
            this.opgParcelamento_DiaFixo.Text = "Parcelamento - Mensal";
            this.opgParcelamento_DiaFixo.UseVisualStyleBackColor = true;
            this.opgParcelamento_DiaFixo.ValorAnterior = false;
            this.opgParcelamento_DiaFixo.Value = true;
            this.opgParcelamento_DiaFixo.CheckedChanged += new System.EventHandler(this.opgParcelamento_DiaFixo_CheckedChanged);
            // 
            // txtParcelamentoQtde
            // 
            this.txtParcelamentoQtde.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtParcelamentoQtde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParcelamentoQtde.Coluna_LookUp = 0;
            this.txtParcelamentoQtde.ControlSource = "";
            this.txtParcelamentoQtde.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParcelamentoQtde.ForeColor = System.Drawing.Color.DimGray;
            this.txtParcelamentoQtde.Grupo = "";
            this.txtParcelamentoQtde.Incluir_QueryBy = true;
            this.txtParcelamentoQtde.Location = new System.Drawing.Point(101, 71);
            this.txtParcelamentoQtde.LookUp = false;
            this.txtParcelamentoQtde.MensagemObrigatorio = "Campo obrigatório";
            this.txtParcelamentoQtde.Name = "txtParcelamentoQtde";
            this.txtParcelamentoQtde.Obrigatorio = false;
            this.txtParcelamentoQtde.Qtde_Casas_Decimais = 0;
            this.txtParcelamentoQtde.Size = new System.Drawing.Size(49, 20);
            this.txtParcelamentoQtde.SQLStatement = "";
            this.txtParcelamentoQtde.Tabela = "";
            this.txtParcelamentoQtde.Tabela_INNER = null;
            this.txtParcelamentoQtde.TabIndex = 3;
            this.txtParcelamentoQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtParcelamentoQtde.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtParcelamentoQtde.ValorAnterior = "";
            this.txtParcelamentoQtde.Value = "";
            // 
            // txtDtCadastro
            // 
            this.txtDtCadastro.ControlSource = "Data_Cadastro";
            this.txtDtCadastro.EditValue = null;
            this.txtDtCadastro.Grupo = "";
            this.txtDtCadastro.Incluir_QueryBy = true;
            this.txtDtCadastro.Location = new System.Drawing.Point(374, 124);
            this.txtDtCadastro.MensagemObrigatorio = "Campo obrigatório";
            this.txtDtCadastro.Name = "txtDtCadastro";
            this.txtDtCadastro.Obrigatorio = false;
            this.txtDtCadastro.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDtCadastro.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtDtCadastro.Properties.Appearance.Options.UseBackColor = true;
            this.txtDtCadastro.Properties.Appearance.Options.UseForeColor = true;
            this.txtDtCadastro.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDtCadastro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)))});
            this.txtDtCadastro.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDtCadastro.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDtCadastro.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtDtCadastro.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDtCadastro.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.txtDtCadastro.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDtCadastro.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.txtDtCadastro.Properties.Mask.BeepOnError = true;
            this.txtDtCadastro.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtDtCadastro.Properties.Mask.SaveLiteral = false;
            this.txtDtCadastro.Properties.MaxValue = new System.DateTime(2158, 10, 31, 0, 0, 0, 0);
            this.txtDtCadastro.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.txtDtCadastro.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDtCadastro.ReadOnly = false;
            this.txtDtCadastro.Size = new System.Drawing.Size(100, 20);
            this.txtDtCadastro.Tabela = "contas_pagar";
            this.txtDtCadastro.Tabela_INNER = null;
            this.txtDtCadastro.TabIndex = 15;
            this.txtDtCadastro.ValorAnterior = null;
            this.txtDtCadastro.Value = null;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Parcela";
            this.Column1.HeaderText = "Nº Parcela";
            this.Column1.Name = "Column1";
            this.Column1.Width = 95;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Parcela_Paga";
            this.Column5.HeaderText = "Parcela paga";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Data_Vencimento";
            dataGridViewCellStyle2.Format = "d";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Data Vencimento";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Valor_Original";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Valor original";
            this.Column3.Name = "Column3";
            this.Column3.Width = 130;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Valor_Pagar";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "Valor a pagar";
            this.Column4.Name = "Column4";
            this.Column4.Width = 130;
            // 
            // f0017
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 409);
            this.Controls.Add(this.txtDtCadastro);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.cf_Label12);
            this.Controls.Add(this.txtCodTitulo);
            this.Controls.Add(this.txtFilial);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.txtDescFilial);
            this.Controls.Add(this.cf_Label5);
            this.Controls.Add(this.cf_Label9);
            this.Controls.Add(this.cboTipoDocumento);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.txtValorPagar);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtDescCliente);
            this.Controls.Add(this.cf_Label8);
            this.Controls.Add(this.txtValorOriginal);
            this.Controls.Add(this.cf_Label3);
            this.MainTabela = "contas_pagar";
            this.Name = "f0017";
            this.Text = "Cadastro de contas a pagar";
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0017_user_AfterRefreshData);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.frmCad_ContasPagar_user_FormStatus_Change);
            this.user_AfterNew += new CompSoft.FormSet.AfterNew(this.frmCad_ContasPagar_user_AfterNew);
            this.Enter += new System.EventHandler(this.f0017_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.grdParcelas)).EndInit();
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimeiraDataVencimento.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimeiraDataVencimento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtCadastro.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtCadastro.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label12;
        private CompSoft.cf_Bases.cf_Label cf_Label9;
        private CompSoft.cf_Bases.cf_TextBox txtValorPagar;
        private CompSoft.cf_Bases.cf_Label cf_Label8;
        private CompSoft.cf_Bases.cf_TextBox txtValorOriginal;
        private CompSoft.cf_Bases.cf_Label cf_Label5;
        private CompSoft.cf_Bases.cf_ComboBox cboTipoDocumento;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_TextBox txtNumeroDocumento;
        private CompSoft.cf_Bases.cf_TextBox txtDescCliente;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox txtCliente;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtCodTitulo;
        private CompSoft.cf_Bases.cf_TextBox txtDescFilial;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtFilial;
        private CompSoft.cf_Bases.cf_DataGrid grdParcelas;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_AcaoGrid agParcelas;
        private CompSoft.cf_Bases.cf_Button cmdGerarParcelas;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_TextBox txtParcelamentoQtde;
        private CompSoft.cf_Bases.cf_RadioButton optParcelamento_EmDias;
        private CompSoft.cf_Bases.cf_RadioButton opgParcelamento_DiaFixo;
        private CompSoft.cf_Bases.cf_Label cf_Label16;
        private CompSoft.cf_Bases.cf_Label cf_Label17;
        private CompSoft.cf_Bases.cf_TextBox txtQtdeParcelas;
        private CompSoft.cf_Bases.cf_Label cf_Label18;
        private CompSoft.cf_Bases.cf_DateEdit txtPrimeiraDataVencimento;
        private CompSoft.cf_Bases.cf_DateEdit txtDtCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewDatePikerColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}