namespace ERP.Forms
{
    partial class f0052
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMovimentoEstoque = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label0 = new CompSoft.cf_Bases.cf_Label();
            this.txtNumeroDocumento = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label11 = new CompSoft.cf_Bases.cf_Label();
            this.txtDescricao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.txtValorTotal = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label7 = new CompSoft.cf_Bases.cf_Label();
            this.cboTipoMovimento = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label8 = new CompSoft.cf_Bases.cf_Label();
            this.txtQtde = new CompSoft.cf_Bases.cf_TextBox();
            this.txtProduto = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label5 = new CompSoft.cf_Bases.cf_Label();
            this.txtPreco = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label6 = new CompSoft.cf_Bases.cf_Label();
            this.grdProdutos = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_Label10 = new CompSoft.cf_Bases.cf_Label();
            this.txtCodProduto = new CompSoft.cf_Bases.cf_TextBox();
            this.txtCliente = new CompSoft.cf_Bases.cf_TextBox();
            this.txtCodCliente = new CompSoft.cf_Bases.cf_TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtDataMovimento = new CompSoft.cf_Bases.cf_DateEdit();
            this.rbEntrada = new CompSoft.cf_Bases.cf_RadioButton();
            this.rbSaida = new CompSoft.cf_Bases.cf_RadioButton();
            this.cf_Pageframe1 = new CompSoft.cf_Bases.cf_Pageframe();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.chkFiltroData = new CompSoft.cf_Bases.cf_CheckBox();
            this.prdDataMovimento = new CompSoft.cf_Bases.cf_Periodo();
            ((System.ComponentModel.ISupportInitialize)(this.grdProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataMovimento.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataMovimento.Properties)).BeginInit();
            this.cf_Pageframe1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.cf_GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMovimentoEstoque
            // 
            this.txtMovimentoEstoque.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMovimentoEstoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMovimentoEstoque.Coluna_LookUp = 0;
            this.txtMovimentoEstoque.ControlSource = "Movimento_Estoque";
            this.txtMovimentoEstoque.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMovimentoEstoque.ForeColor = System.Drawing.Color.DimGray;
            this.txtMovimentoEstoque.Grupo = "";
            this.txtMovimentoEstoque.Incluir_QueryBy = true;
            this.txtMovimentoEstoque.Location = new System.Drawing.Point(83, 6);
            this.txtMovimentoEstoque.LookUp = false;
            this.txtMovimentoEstoque.MensagemObrigatorio = "Campo obrigatório";
            this.txtMovimentoEstoque.Name = "txtMovimentoEstoque";
            this.txtMovimentoEstoque.Obrigatorio = false;
            this.txtMovimentoEstoque.Qtde_Casas_Decimais = 0;
            this.txtMovimentoEstoque.Size = new System.Drawing.Size(133, 20);
            this.txtMovimentoEstoque.SQLStatement = "";
            this.txtMovimentoEstoque.Tabela = "movimentos_estoque";
            this.txtMovimentoEstoque.Tabela_INNER = "me";
            this.txtMovimentoEstoque.TabIndex = 1;
            this.txtMovimentoEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMovimentoEstoque.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtMovimentoEstoque.ValorAnterior = "";
            this.txtMovimentoEstoque.Value = "";
            // 
            // cf_Label0
            // 
            this.cf_Label0.AutoSize = true;
            this.cf_Label0.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label0.Location = new System.Drawing.Point(33, 9);
            this.cf_Label0.Name = "cf_Label0";
            this.cf_Label0.Size = new System.Drawing.Size(44, 13);
            this.cf_Label0.TabIndex = 0;
            this.cf_Label0.Text = "Código:";
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
            this.txtNumeroDocumento.Location = new System.Drawing.Point(487, 8);
            this.txtNumeroDocumento.LookUp = false;
            this.txtNumeroDocumento.MensagemObrigatorio = "Campo obrigatório";
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Obrigatorio = false;
            this.txtNumeroDocumento.Qtde_Casas_Decimais = 0;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(133, 20);
            this.txtNumeroDocumento.SQLStatement = "";
            this.txtNumeroDocumento.Tabela = "movimentos_estoque";
            this.txtNumeroDocumento.Tabela_INNER = "me";
            this.txtNumeroDocumento.TabIndex = 5;
            this.txtNumeroDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroDocumento.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtNumeroDocumento.ValorAnterior = "";
            this.txtNumeroDocumento.Value = "";
            // 
            // cf_Label11
            // 
            this.cf_Label11.AutoSize = true;
            this.cf_Label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label11.Location = new System.Drawing.Point(439, 11);
            this.cf_Label11.Name = "cf_Label11";
            this.cf_Label11.Size = new System.Drawing.Size(47, 13);
            this.cf_Label11.TabIndex = 4;
            this.cf_Label11.Text = "Nº doc.:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Coluna_LookUp = 0;
            this.txtDescricao.ControlSource = "Descricao";
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricao.Grupo = "";
            this.txtDescricao.Incluir_QueryBy = true;
            this.txtDescricao.Location = new System.Drawing.Point(83, 111);
            this.txtDescricao.LookUp = false;
            this.txtDescricao.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Obrigatorio = false;
            this.txtDescricao.Qtde_Casas_Decimais = 0;
            this.txtDescricao.Size = new System.Drawing.Size(328, 20);
            this.txtDescricao.SQLStatement = "";
            this.txtDescricao.Tabela = "movimentos_estoque";
            this.txtDescricao.Tabela_INNER = "me";
            this.txtDescricao.TabIndex = 16;
            this.txtDescricao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao.ValorAnterior = "";
            this.txtDescricao.Value = "";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(20, 114);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(57, 13);
            this.cf_Label1.TabIndex = 15;
            this.cf_Label1.Text = "Descrição:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorTotal.Coluna_LookUp = 0;
            this.txtValorTotal.ControlSource = "Valor_Total";
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.ForeColor = System.Drawing.Color.DimGray;
            this.txtValorTotal.Grupo = "";
            this.txtValorTotal.Incluir_QueryBy = true;
            this.txtValorTotal.Location = new System.Drawing.Point(487, 35);
            this.txtValorTotal.LookUp = false;
            this.txtValorTotal.MensagemObrigatorio = "Campo obrigatório";
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Obrigatorio = false;
            this.txtValorTotal.Qtde_Casas_Decimais = 0;
            this.txtValorTotal.Size = new System.Drawing.Size(133, 20);
            this.txtValorTotal.SQLStatement = "";
            this.txtValorTotal.Tabela = "movimentos_estoque";
            this.txtValorTotal.Tabela_INNER = "me";
            this.txtValorTotal.TabIndex = 9;
            this.txtValorTotal.Text = null;
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorTotal.TipoControles = CompSoft.TipoControle.Moeda;
            this.txtValorTotal.ValorAnterior = "";
            this.txtValorTotal.Value = null;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(426, 38);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(60, 13);
            this.cf_Label2.TabIndex = 8;
            this.cf_Label2.Text = "Valor total:";
            // 
            // cf_Label7
            // 
            this.cf_Label7.AutoSize = true;
            this.cf_Label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label7.Location = new System.Drawing.Point(46, 35);
            this.cf_Label7.Name = "cf_Label7";
            this.cf_Label7.Size = new System.Drawing.Size(31, 13);
            this.cf_Label7.TabIndex = 6;
            this.cf_Label7.Text = "Tipo:";
            // 
            // cboTipoMovimento
            // 
            this.cboTipoMovimento.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboTipoMovimento.ControlSource = "Tipo_Movimento_Estoque";
            this.cboTipoMovimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovimento.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTipoMovimento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoMovimento.ForeColor = System.Drawing.Color.DimGray;
            this.cboTipoMovimento.FormattingEnabled = true;
            this.cboTipoMovimento.Grupo = "";
            this.cboTipoMovimento.Incluir_QueryBy = true;
            this.cboTipoMovimento.Location = new System.Drawing.Point(83, 32);
            this.cboTipoMovimento.MensagemObrigatorio = "Campo obrigatório";
            this.cboTipoMovimento.Name = "cboTipoMovimento";
            this.cboTipoMovimento.Obrigatorio = false;
            this.cboTipoMovimento.ReadOnly = false;
            this.cboTipoMovimento.Size = new System.Drawing.Size(328, 21);
            this.cboTipoMovimento.SQLStatement = "select tipo_movimento_estoque, desc_tipo_movimento_estoque from tipos_movimentos_" +
                "estoque where inativo = 0 order by desc_tipo_movimento_estoque";
            this.cboTipoMovimento.Tabela = "movimentos_estoque";
            this.cboTipoMovimento.Tabela_INNER = "me";
            this.cboTipoMovimento.TabIndex = 7;
            this.cboTipoMovimento.ValorAnterior = "";
            this.cboTipoMovimento.Value = null;
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(25, 62);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(52, 13);
            this.cf_Label3.TabIndex = 10;
            this.cf_Label3.Text = "Empresa:";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboEmpresa.ControlSource = "Empresa";
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.ForeColor = System.Drawing.Color.DimGray;
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Grupo = "";
            this.cboEmpresa.Incluir_QueryBy = true;
            this.cboEmpresa.Location = new System.Drawing.Point(83, 59);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.ReadOnly = false;
            this.cboEmpresa.Size = new System.Drawing.Size(328, 21);
            this.cboEmpresa.SQLStatement = "select empresa, razao_social from empresas where inativo = 0 order by razao_socia" +
                "l";
            this.cboEmpresa.Tabela = "movimentos_estoque";
            this.cboEmpresa.Tabela_INNER = "me";
            this.cboEmpresa.TabIndex = 11;
            this.cboEmpresa.ValorAnterior = "";
            this.cboEmpresa.Value = null;
            // 
            // cf_Label8
            // 
            this.cf_Label8.AutoSize = true;
            this.cf_Label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label8.Location = new System.Drawing.Point(275, 10);
            this.cf_Label8.Name = "cf_Label8";
            this.cf_Label8.Size = new System.Drawing.Size(34, 13);
            this.cf_Label8.TabIndex = 2;
            this.cf_Label8.Text = "Data:";
            // 
            // txtQtde
            // 
            this.txtQtde.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQtde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtde.Coluna_LookUp = 0;
            this.txtQtde.ControlSource = "";
            this.txtQtde.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtde.ForeColor = System.Drawing.Color.DimGray;
            this.txtQtde.Grupo = "";
            this.txtQtde.Incluir_QueryBy = true;
            this.txtQtde.Location = new System.Drawing.Point(570, 10);
            this.txtQtde.LookUp = false;
            this.txtQtde.MensagemObrigatorio = "Campo obrigatório";
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Obrigatorio = false;
            this.txtQtde.Qtde_Casas_Decimais = 0;
            this.txtQtde.Size = new System.Drawing.Size(63, 20);
            this.txtQtde.SQLStatement = "";
            this.txtQtde.Tabela = "";
            this.txtQtde.Tabela_INNER = null;
            this.txtQtde.TabIndex = 6;
            this.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtde.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtQtde.ValorAnterior = "";
            this.txtQtde.Value = "";
            this.txtQtde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtde_KeyPress);
            // 
            // txtProduto
            // 
            this.txtProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProduto.Coluna_LookUp = 1;
            this.txtProduto.ControlSource = "";
            this.txtProduto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.ForeColor = System.Drawing.Color.Black;
            this.txtProduto.Grupo = "";
            this.txtProduto.Incluir_QueryBy = true;
            this.txtProduto.Location = new System.Drawing.Point(123, 9);
            this.txtProduto.LookUp = true;
            this.txtProduto.MensagemObrigatorio = "Campo obrigatório";
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Obrigatorio = false;
            this.txtProduto.Qtde_Casas_Decimais = 0;
            this.txtProduto.Size = new System.Drawing.Size(291, 20);
            this.txtProduto.SQLStatement = "select class.*, valor_custo_unitario from produtos pr inner join vw_class_Produto" +
                " class on class.produto = pr.produto where pr.Desc_Produto@";
            this.txtProduto.Tabela = "";
            this.txtProduto.Tabela_INNER = null;
            this.txtProduto.TabIndex = 2;
            this.txtProduto.TabStop = false;
            this.txtProduto.TipoControles = CompSoft.TipoControle.Geral;
            this.txtProduto.ValorAnterior = "";
            this.txtProduto.Value = "";
            this.txtProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduto_KeyPress);
            this.txtProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtProduto_Validating);
            // 
            // cf_Label5
            // 
            this.cf_Label5.AutoSize = true;
            this.cf_Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label5.Location = new System.Drawing.Point(537, 13);
            this.cf_Label5.Name = "cf_Label5";
            this.cf_Label5.Size = new System.Drawing.Size(35, 13);
            this.cf_Label5.TabIndex = 5;
            this.cf_Label5.Text = "Qtde:";
            // 
            // txtPreco
            // 
            this.txtPreco.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreco.Coluna_LookUp = 0;
            this.txtPreco.ControlSource = "";
            this.txtPreco.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreco.ForeColor = System.Drawing.Color.DimGray;
            this.txtPreco.Grupo = "";
            this.txtPreco.Incluir_QueryBy = true;
            this.txtPreco.Location = new System.Drawing.Point(456, 10);
            this.txtPreco.LookUp = false;
            this.txtPreco.MensagemObrigatorio = "Campo obrigatório";
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Obrigatorio = false;
            this.txtPreco.Qtde_Casas_Decimais = 0;
            this.txtPreco.Size = new System.Drawing.Size(75, 20);
            this.txtPreco.SQLStatement = "";
            this.txtPreco.Tabela = "";
            this.txtPreco.Tabela_INNER = null;
            this.txtPreco.TabIndex = 4;
            this.txtPreco.Text = null;
            this.txtPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPreco.TipoControles = CompSoft.TipoControle.Moeda;
            this.txtPreco.ValorAnterior = "";
            this.txtPreco.Value = null;
            this.txtPreco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreco_KeyPress);
            // 
            // cf_Label6
            // 
            this.cf_Label6.AutoSize = true;
            this.cf_Label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label6.Location = new System.Drawing.Point(420, 13);
            this.cf_Label6.Name = "cf_Label6";
            this.cf_Label6.Size = new System.Drawing.Size(38, 13);
            this.cf_Label6.TabIndex = 3;
            this.cf_Label6.Text = "Preço:";
            // 
            // grdProdutos
            // 
            this.grdProdutos.Allow_Alter_Value_All_StatusForm = false;
            this.grdProdutos.AllowEditRow = false;
            this.grdProdutos.AllowUserToAddRows = false;
            this.grdProdutos.AllowUserToDeleteRows = false;
            this.grdProdutos.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdProdutos.Cancel_OnClick = true;
            this.grdProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column7,
            this.Column8,
            this.Column9});
            this.grdProdutos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdProdutos.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdProdutos.GridColor = System.Drawing.Color.DimGray;
            this.grdProdutos.Location = new System.Drawing.Point(3, 36);
            this.grdProdutos.MultiSelect = false;
            this.grdProdutos.Name = "grdProdutos";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProdutos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdProdutos.RowHeadersWidth = 22;
            this.grdProdutos.RowTemplate.Height = 20;
            this.grdProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProdutos.ShowCellErrors = false;
            this.grdProdutos.ShowCellToolTips = false;
            this.grdProdutos.ShowEditingIcon = false;
            this.grdProdutos.ShowRowErrors = false;
            this.grdProdutos.Size = new System.Drawing.Size(635, 241);
            this.grdProdutos.TabIndex = 7;
            this.grdProdutos.TabStop = false;
            this.grdProdutos.VirtualMode = true;
            this.grdProdutos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdProdutos_UserDeletingRow);
            this.grdProdutos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grdProdutos_RowsRemoved);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Grupo_Produto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Grupo produto";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Desc_Grupo_Produto";
            this.Column2.HeaderText = "Desc. grupo produto";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Produto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Produto";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Desc_Produto";
            this.Column4.HeaderText = "Desc. produto";
            this.Column4.Name = "Column4";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Quantidade";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column7.HeaderText = "Qtde";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Valor_Unitario";
            dataGridViewCellStyle4.Format = "N2";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column8.HeaderText = "Valor unitário";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Valor_Total";
            dataGridViewCellStyle5.Format = "N2";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column9.HeaderText = "Valor total";
            this.Column9.Name = "Column9";
            // 
            // cf_Label10
            // 
            this.cf_Label10.AutoSize = true;
            this.cf_Label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label10.Location = new System.Drawing.Point(8, 12);
            this.cf_Label10.Name = "cf_Label10";
            this.cf_Label10.Size = new System.Drawing.Size(49, 13);
            this.cf_Label10.TabIndex = 0;
            this.cf_Label10.Text = "Produto:";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtCodProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodProduto.Coluna_LookUp = 0;
            this.txtCodProduto.ControlSource = "";
            this.txtCodProduto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProduto.ForeColor = System.Drawing.Color.Black;
            this.txtCodProduto.Grupo = "";
            this.txtCodProduto.Incluir_QueryBy = true;
            this.txtCodProduto.Location = new System.Drawing.Point(63, 9);
            this.txtCodProduto.LookUp = true;
            this.txtCodProduto.MaxLength = 9;
            this.txtCodProduto.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Obrigatorio = false;
            this.txtCodProduto.Qtde_Casas_Decimais = 0;
            this.txtCodProduto.Size = new System.Drawing.Size(54, 20);
            this.txtCodProduto.SQLStatement = "select class.*, valor_custo_unitario from produtos pr inner join vw_class_Produto" +
                " class on class.produto = pr.produto where pr.produto@";
            this.txtCodProduto.Tabela = "";
            this.txtCodProduto.Tabela_INNER = null;
            this.txtCodProduto.TabIndex = 1;
            this.txtCodProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodProduto.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCodProduto.ValorAnterior = "";
            this.txtCodProduto.Value = "";
            this.txtCodProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodProduto_KeyPress);
            this.txtCodProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodProduto_Validating);
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Coluna_LookUp = 1;
            this.txtCliente.ControlSource = "Razao_Cliente";
            this.txtCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCliente.Grupo = "";
            this.txtCliente.Incluir_QueryBy = false;
            this.txtCliente.Location = new System.Drawing.Point(129, 86);
            this.txtCliente.LookUp = true;
            this.txtCliente.MensagemObrigatorio = "Campo obrigatório";
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Obrigatorio = false;
            this.txtCliente.Qtde_Casas_Decimais = 0;
            this.txtCliente.Size = new System.Drawing.Size(282, 20);
            this.txtCliente.SQLStatement = "select Cliente, Razao_Social, Nome_Fantasia from Clientes where Razao_Social@";
            this.txtCliente.Tabela = "movimentos_estoque";
            this.txtCliente.Tabela_INNER = "me";
            this.txtCliente.TabIndex = 14;
            this.txtCliente.TabStop = false;
            this.txtCliente.TipoControles = CompSoft.TipoControle.Geral;
            this.txtCliente.ValorAnterior = "";
            this.txtCliente.Value = "";
            this.txtCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtCliente_Validating);
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtCodCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodCliente.Coluna_LookUp = 0;
            this.txtCodCliente.ControlSource = "Cliente";
            this.txtCodCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCodCliente.Grupo = "";
            this.txtCodCliente.Incluir_QueryBy = true;
            this.txtCodCliente.Location = new System.Drawing.Point(84, 86);
            this.txtCodCliente.LookUp = true;
            this.txtCodCliente.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Obrigatorio = false;
            this.txtCodCliente.Qtde_Casas_Decimais = 0;
            this.txtCodCliente.Size = new System.Drawing.Size(39, 20);
            this.txtCodCliente.SQLStatement = "select Cliente, Razao_Social, Nome_Fantasia from Clientes where Cliente@";
            this.txtCodCliente.Tabela = "movimentos_estoque";
            this.txtCodCliente.Tabela_INNER = "me";
            this.txtCodCliente.TabIndex = 13;
            this.txtCodCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodCliente.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCodCliente.ValorAnterior = "";
            this.txtCodCliente.Value = "";
            this.txtCodCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCliente_Validating);
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(9, 89);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(68, 13);
            this.lblCliente.TabIndex = 12;
            this.lblCliente.Text = "Fornecedor:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataMovimento
            // 
            this.txtDataMovimento.ControlSource = "Data_Movimento";
            this.txtDataMovimento.EditValue = null;
            this.txtDataMovimento.Grupo = "";
            this.txtDataMovimento.Incluir_QueryBy = true;
            this.txtDataMovimento.Location = new System.Drawing.Point(311, 7);
            this.txtDataMovimento.MensagemObrigatorio = "Campo obrigatório";
            this.txtDataMovimento.Name = "txtDataMovimento";
            this.txtDataMovimento.Obrigatorio = true;
            this.txtDataMovimento.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDataMovimento.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtDataMovimento.Properties.Appearance.Options.UseBackColor = true;
            this.txtDataMovimento.Properties.Appearance.Options.UseForeColor = true;
            this.txtDataMovimento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDataMovimento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)))});
            this.txtDataMovimento.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDataMovimento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDataMovimento.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtDataMovimento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDataMovimento.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.txtDataMovimento.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDataMovimento.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.txtDataMovimento.Properties.Mask.BeepOnError = true;
            this.txtDataMovimento.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtDataMovimento.Properties.Mask.SaveLiteral = false;
            this.txtDataMovimento.Properties.MaxValue = new System.DateTime(2158, 6, 30, 0, 0, 0, 0);
            this.txtDataMovimento.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.txtDataMovimento.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDataMovimento.ReadOnly = false;
            this.txtDataMovimento.Size = new System.Drawing.Size(100, 20);
            this.txtDataMovimento.Tabela = "movimentos_estoque";
            this.txtDataMovimento.Tabela_INNER = "me";
            this.txtDataMovimento.TabIndex = 3;
            this.txtDataMovimento.ValorAnterior = null;
            this.txtDataMovimento.Value = null;
            // 
            // rbEntrada
            // 
            this.rbEntrada.AutoSize = true;
            this.rbEntrada.Checked = true;
            this.rbEntrada.ControlSource = "";
            this.rbEntrada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEntrada.Grupo = "";
            this.rbEntrada.Incluir_QueryBy = false;
            this.rbEntrada.Location = new System.Drawing.Point(557, 63);
            this.rbEntrada.MensagemObrigatorio = "";
            this.rbEntrada.Name = "rbEntrada";
            this.rbEntrada.Obrigatorio = false;
            this.rbEntrada.ReadOnly = false;
            this.rbEntrada.Size = new System.Drawing.Size(63, 17);
            this.rbEntrada.Tabela = "";
            this.rbEntrada.Tabela_INNER = null;
            this.rbEntrada.TabIndex = 18;
            this.rbEntrada.TabStop = true;
            this.rbEntrada.Text = "Entrada";
            this.rbEntrada.UseVisualStyleBackColor = true;
            this.rbEntrada.ValorAnterior = false;
            this.rbEntrada.Value = true;
            this.rbEntrada.Visible = false;
            this.rbEntrada.CheckedChanged += new System.EventHandler(this.rbEntrada_CheckedChanged);
            // 
            // rbSaida
            // 
            this.rbSaida.AutoSize = true;
            this.rbSaida.ControlSource = "";
            this.rbSaida.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSaida.Grupo = "";
            this.rbSaida.Incluir_QueryBy = false;
            this.rbSaida.Location = new System.Drawing.Point(557, 86);
            this.rbSaida.MensagemObrigatorio = "";
            this.rbSaida.Name = "rbSaida";
            this.rbSaida.Obrigatorio = false;
            this.rbSaida.ReadOnly = false;
            this.rbSaida.Size = new System.Drawing.Size(51, 17);
            this.rbSaida.Tabela = "";
            this.rbSaida.Tabela_INNER = null;
            this.rbSaida.TabIndex = 19;
            this.rbSaida.Text = "Saída";
            this.rbSaida.UseVisualStyleBackColor = true;
            this.rbSaida.ValorAnterior = false;
            this.rbSaida.Value = false;
            this.rbSaida.Visible = false;
            this.rbSaida.CheckedChanged += new System.EventHandler(this.rbSaida_CheckedChanged);
            // 
            // cf_Pageframe1
            // 
            this.cf_Pageframe1.Controls.Add(this.tabPage1);
            this.cf_Pageframe1.Controls.Add(this.tabPage2);
            this.cf_Pageframe1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cf_Pageframe1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Pageframe1.HotTrack = true;
            this.cf_Pageframe1.Location = new System.Drawing.Point(0, 137);
            this.cf_Pageframe1.Name = "cf_Pageframe1";
            this.cf_Pageframe1.SelectedIndex = 0;
            this.cf_Pageframe1.Size = new System.Drawing.Size(649, 306);
            this.cf_Pageframe1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPreco);
            this.tabPage1.Controls.Add(this.cf_Label6);
            this.tabPage1.Controls.Add(this.grdProdutos);
            this.tabPage1.Controls.Add(this.txtQtde);
            this.tabPage1.Controls.Add(this.txtCodProduto);
            this.tabPage1.Controls.Add(this.cf_Label5);
            this.tabPage1.Controls.Add(this.cf_Label10);
            this.tabPage1.Controls.Add(this.txtProduto);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(641, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Itens do movimento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cf_GroupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(641, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Filtro avançado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.chkFiltroData);
            this.cf_GroupBox1.Controls.Add(this.prdDataMovimento);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(32, 39);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(281, 85);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 1;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Filtro de data";
            this.cf_GroupBox1.Value = "";
            // 
            // chkFiltroData
            // 
            this.chkFiltroData.AutoSize = true;
            this.chkFiltroData.ControlSource = "";
            this.chkFiltroData.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltroData.Grupo = "";
            this.chkFiltroData.Incluir_QueryBy = false;
            this.chkFiltroData.Location = new System.Drawing.Point(215, 11);
            this.chkFiltroData.MensagemObrigatorio = "";
            this.chkFiltroData.Name = "chkFiltroData";
            this.chkFiltroData.Obrigatorio = false;
            this.chkFiltroData.ReadOnly = false;
            this.chkFiltroData.Size = new System.Drawing.Size(55, 17);
            this.chkFiltroData.Tabela = "";
            this.chkFiltroData.Tabela_INNER = null;
            this.chkFiltroData.TabIndex = 1;
            this.chkFiltroData.Text = "Ativar";
            this.chkFiltroData.UseVisualStyleBackColor = true;
            this.chkFiltroData.ValorAnterior = false;
            this.chkFiltroData.Value = false;
            // 
            // prdDataMovimento
            // 
            this.prdDataMovimento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdDataMovimento.Location = new System.Drawing.Point(6, 25);
            this.prdDataMovimento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdDataMovimento.Name = "prdDataMovimento";
            this.prdDataMovimento.Size = new System.Drawing.Size(264, 51);
            this.prdDataMovimento.TabIndex = 0;
            // 
            // f0052
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 443);
            this.Controls.Add(this.cf_Pageframe1);
            this.Controls.Add(this.rbSaida);
            this.Controls.Add(this.rbEntrada);
            this.Controls.Add(this.txtDataMovimento);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cf_Label8);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.cf_Label7);
            this.Controls.Add(this.cboTipoMovimento);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.cf_Label11);
            this.Controls.Add(this.txtMovimentoEstoque);
            this.Controls.Add(this.cf_Label0);
            this.MainTabela = "movimentos_estoque";
            this.Name = "f0052";
            this.Text = "Movimento de estoque";
            this.Load += new System.EventHandler(this.f0052_Load);
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0052_user_AfterRefreshData);
            this.Shown += new System.EventHandler(this.f0052_Shown);
            this.user_BeforeSave += new CompSoft.FormSet.BeforeSave(this.f0052_user_BeforeSave);
            ((System.ComponentModel.ISupportInitialize)(this.grdProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataMovimento.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataMovimento.Properties)).EndInit();
            this.cf_Pageframe1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_TextBox txtMovimentoEstoque;
        private CompSoft.cf_Bases.cf_Label cf_Label0;
        private CompSoft.cf_Bases.cf_TextBox txtNumeroDocumento;
        private CompSoft.cf_Bases.cf_Label cf_Label11;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtValorTotal;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_Label cf_Label7;
        private CompSoft.cf_Bases.cf_ComboBox cboTipoMovimento;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_ComboBox cboEmpresa;
        private CompSoft.cf_Bases.cf_Label cf_Label8;
        private CompSoft.cf_Bases.cf_TextBox txtQtde;
        private CompSoft.cf_Bases.cf_TextBox txtProduto;
        private CompSoft.cf_Bases.cf_Label cf_Label5;
        private CompSoft.cf_Bases.cf_DataGrid grdProdutos;
        private CompSoft.cf_Bases.cf_Label cf_Label10;
        private CompSoft.cf_Bases.cf_TextBox txtCodProduto;
        private CompSoft.cf_Bases.cf_TextBox txtCliente;
        private CompSoft.cf_Bases.cf_TextBox txtCodCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private CompSoft.cf_Bases.cf_DateEdit txtDataMovimento;
        private CompSoft.cf_Bases.cf_TextBox txtPreco;
        private CompSoft.cf_Bases.cf_Label cf_Label6;
        private CompSoft.cf_Bases.cf_RadioButton rbEntrada;
        private CompSoft.cf_Bases.cf_RadioButton rbSaida;
        private CompSoft.cf_Bases.cf_Pageframe cf_Pageframe1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_CheckBox chkFiltroData;
        private CompSoft.cf_Bases.cf_Periodo prdDataMovimento;
    }
}