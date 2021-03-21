namespace ERP.Forms
{
    partial class f0086
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
            this.cf_TextBox1 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_ComboBox1 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox2 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.cboBanco = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label5 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox3 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cf_Label9 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox6 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label8 = new CompSoft.cf_Bases.cf_Label();
            this.cboEspecieDoc = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label7 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox5 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label6 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox4 = new CompSoft.cf_Bases.cf_TextBox();
            this.grdInstrucoes = new CompSoft.cf_Bases.cf_DataGrid();
            this.acInstrucoes = new CompSoft.cf_Bases.cf_AcaoGrid();
            this.colCodInstrucao = new CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cf_GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstrucoes)).BeginInit();
            this.SuspendLayout();
            // 
            // cf_TextBox1
            // 
            this.cf_TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox1.Coluna_LookUp = 0;
            this.cf_TextBox1.ControlSource = "Conta_Corrente";
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = "";
            this.cf_TextBox1.Incluir_QueryBy = true;
            this.cf_TextBox1.Location = new System.Drawing.Point(72, 11);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = false;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(69, 20);
            this.cf_TextBox1.SQLStatement = "";
            this.cf_TextBox1.Tabela = "contas_correntes";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 1;
            this.cf_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox1.ValorAnterior = "";
            this.cf_TextBox1.Value = "";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(22, 14);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(44, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Código:";
            // 
            // cf_ComboBox1
            // 
            this.cf_ComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox1.ControlSource = "Empresa";
            this.cf_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox1.FormattingEnabled = true;
            this.cf_ComboBox1.Grupo = "";
            this.cf_ComboBox1.Incluir_QueryBy = true;
            this.cf_ComboBox1.Location = new System.Drawing.Point(72, 37);
            this.cf_ComboBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox1.Name = "cf_ComboBox1";
            this.cf_ComboBox1.Obrigatorio = false;
            this.cf_ComboBox1.ReadOnly = false;
            this.cf_ComboBox1.Size = new System.Drawing.Size(363, 21);
            this.cf_ComboBox1.SQLStatement = "select empresa, Nome_fantasia from empresas where inativo = 0 order by nome_fanta" +
                "sia";
            this.cf_ComboBox1.Tabela = "contas_correntes";
            this.cf_ComboBox1.Tabela_INNER = null;
            this.cf_ComboBox1.TabIndex = 3;
            this.cf_ComboBox1.ValorAnterior = null;
            this.cf_ComboBox1.Value = null;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(14, 41);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(52, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Empresa:";
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(17, 94);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(49, 13);
            this.cf_Label3.TabIndex = 6;
            this.cf_Label3.Text = "Agência:";
            // 
            // cf_TextBox2
            // 
            this.cf_TextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox2.Coluna_LookUp = 0;
            this.cf_TextBox2.ControlSource = "Agencia";
            this.cf_TextBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox2.Grupo = "";
            this.cf_TextBox2.Incluir_QueryBy = true;
            this.cf_TextBox2.Location = new System.Drawing.Point(72, 91);
            this.cf_TextBox2.LookUp = false;
            this.cf_TextBox2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox2.Name = "cf_TextBox2";
            this.cf_TextBox2.Obrigatorio = false;
            this.cf_TextBox2.Qtde_Casas_Decimais = 0;
            this.cf_TextBox2.Size = new System.Drawing.Size(86, 20);
            this.cf_TextBox2.SQLStatement = "";
            this.cf_TextBox2.Tabela = "contas_correntes";
            this.cf_TextBox2.Tabela_INNER = null;
            this.cf_TextBox2.TabIndex = 7;
            this.cf_TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox2.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox2.ValorAnterior = "";
            this.cf_TextBox2.Value = "";
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(26, 67);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(40, 13);
            this.cf_Label4.TabIndex = 4;
            this.cf_Label4.Text = "Banco:";
            // 
            // cboBanco
            // 
            this.cboBanco.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboBanco.ControlSource = "Banco";
            this.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanco.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboBanco.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBanco.ForeColor = System.Drawing.Color.DimGray;
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Grupo = "";
            this.cboBanco.Incluir_QueryBy = true;
            this.cboBanco.Location = new System.Drawing.Point(72, 64);
            this.cboBanco.MensagemObrigatorio = "Campo obrigatório";
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Obrigatorio = false;
            this.cboBanco.ReadOnly = false;
            this.cboBanco.Size = new System.Drawing.Size(203, 21);
            this.cboBanco.SQLStatement = "select Banco, Descr_Banco from bancos where inativo = 0 order by descr_Banco";
            this.cboBanco.Tabela = "contas_correntes";
            this.cboBanco.Tabela_INNER = null;
            this.cboBanco.TabIndex = 5;
            this.cboBanco.ValorAnterior = null;
            this.cboBanco.Value = null;
            this.cboBanco.SelectedValueChanged += new System.EventHandler(this.cboEmpresa_SelectedValueChanged);
            // 
            // cf_Label5
            // 
            this.cf_Label5.AutoSize = true;
            this.cf_Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label5.Location = new System.Drawing.Point(180, 94);
            this.cf_Label5.Name = "cf_Label5";
            this.cf_Label5.Size = new System.Drawing.Size(153, 13);
            this.cf_Label5.TabIndex = 8;
            this.cf_Label5.Text = "Número da conta (Sem dígito):";
            // 
            // cf_TextBox3
            // 
            this.cf_TextBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox3.Coluna_LookUp = 0;
            this.cf_TextBox3.ControlSource = "Numero_Conta";
            this.cf_TextBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox3.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox3.Grupo = "";
            this.cf_TextBox3.Incluir_QueryBy = true;
            this.cf_TextBox3.Location = new System.Drawing.Point(339, 91);
            this.cf_TextBox3.LookUp = false;
            this.cf_TextBox3.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox3.Name = "cf_TextBox3";
            this.cf_TextBox3.Obrigatorio = false;
            this.cf_TextBox3.Qtde_Casas_Decimais = 0;
            this.cf_TextBox3.Size = new System.Drawing.Size(96, 20);
            this.cf_TextBox3.SQLStatement = "";
            this.cf_TextBox3.Tabela = "contas_correntes";
            this.cf_TextBox3.Tabela_INNER = null;
            this.cf_TextBox3.TabIndex = 9;
            this.cf_TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox3.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox3.ValorAnterior = "";
            this.cf_TextBox3.Value = "";
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.cf_Label9);
            this.cf_GroupBox1.Controls.Add(this.cf_TextBox6);
            this.cf_GroupBox1.Controls.Add(this.cf_Label8);
            this.cf_GroupBox1.Controls.Add(this.cboEspecieDoc);
            this.cf_GroupBox1.Controls.Add(this.cf_Label7);
            this.cf_GroupBox1.Controls.Add(this.cf_TextBox5);
            this.cf_GroupBox1.Controls.Add(this.cf_Label6);
            this.cf_GroupBox1.Controls.Add(this.cf_TextBox4);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(12, 117);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(437, 104);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 10;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Dados para geração do boleto bancário (CNAB)";
            this.cf_GroupBox1.Value = "";
            // 
            // cf_Label9
            // 
            this.cf_Label9.AutoSize = true;
            this.cf_Label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label9.Location = new System.Drawing.Point(243, 49);
            this.cf_Label9.Name = "cf_Label9";
            this.cf_Label9.Size = new System.Drawing.Size(56, 13);
            this.cf_Label9.TabIndex = 4;
            this.cf_Label9.Text = "Convênio:";
            // 
            // cf_TextBox6
            // 
            this.cf_TextBox6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox6.Coluna_LookUp = 0;
            this.cf_TextBox6.ControlSource = "Boleto_Convenio";
            this.cf_TextBox6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox6.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox6.Grupo = "";
            this.cf_TextBox6.Incluir_QueryBy = true;
            this.cf_TextBox6.Location = new System.Drawing.Point(305, 46);
            this.cf_TextBox6.LookUp = false;
            this.cf_TextBox6.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox6.Name = "cf_TextBox6";
            this.cf_TextBox6.Obrigatorio = false;
            this.cf_TextBox6.Qtde_Casas_Decimais = 0;
            this.cf_TextBox6.Size = new System.Drawing.Size(118, 20);
            this.cf_TextBox6.SQLStatement = "";
            this.cf_TextBox6.Tabela = "contas_correntes";
            this.cf_TextBox6.Tabela_INNER = null;
            this.cf_TextBox6.TabIndex = 5;
            this.cf_TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox6.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox6.ValorAnterior = "";
            this.cf_TextBox6.Value = "";
            // 
            // cf_Label8
            // 
            this.cf_Label8.AutoSize = true;
            this.cf_Label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label8.Location = new System.Drawing.Point(20, 76);
            this.cf_Label8.Name = "cf_Label8";
            this.cf_Label8.Size = new System.Drawing.Size(72, 13);
            this.cf_Label8.TabIndex = 6;
            this.cf_Label8.Text = "Especie Doc.:";
            // 
            // cboEspecieDoc
            // 
            this.cboEspecieDoc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboEspecieDoc.ControlSource = "Boleto_EspecieDoc";
            this.cboEspecieDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecieDoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEspecieDoc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEspecieDoc.ForeColor = System.Drawing.Color.DimGray;
            this.cboEspecieDoc.FormattingEnabled = true;
            this.cboEspecieDoc.Grupo = "";
            this.cboEspecieDoc.Incluir_QueryBy = true;
            this.cboEspecieDoc.Location = new System.Drawing.Point(98, 72);
            this.cboEspecieDoc.MensagemObrigatorio = "Campo obrigatório";
            this.cboEspecieDoc.Name = "cboEspecieDoc";
            this.cboEspecieDoc.Obrigatorio = false;
            this.cboEspecieDoc.ReadOnly = false;
            this.cboEspecieDoc.Size = new System.Drawing.Size(325, 21);
            this.cboEspecieDoc.SQLStatement = "select EspecieDoc, Desc_EspecieDoc from Boletos_Especies_Documentos where inativo" +
                " = 0 order by Desc_EspecieDoc";
            this.cboEspecieDoc.Tabela = "contas_correntes";
            this.cboEspecieDoc.Tabela_INNER = null;
            this.cboEspecieDoc.TabIndex = 7;
            this.cboEspecieDoc.ValorAnterior = null;
            this.cboEspecieDoc.Value = null;
            // 
            // cf_Label7
            // 
            this.cf_Label7.AutoSize = true;
            this.cf_Label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label7.Location = new System.Drawing.Point(14, 49);
            this.cf_Label7.Name = "cf_Label7";
            this.cf_Label7.Size = new System.Drawing.Size(78, 13);
            this.cf_Label7.TabIndex = 2;
            this.cf_Label7.Text = "Cód. Cedente:";
            // 
            // cf_TextBox5
            // 
            this.cf_TextBox5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox5.Coluna_LookUp = 0;
            this.cf_TextBox5.ControlSource = "Boleto_CodigoCedente";
            this.cf_TextBox5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox5.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox5.Grupo = "";
            this.cf_TextBox5.Incluir_QueryBy = true;
            this.cf_TextBox5.Location = new System.Drawing.Point(98, 46);
            this.cf_TextBox5.LookUp = false;
            this.cf_TextBox5.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox5.Name = "cf_TextBox5";
            this.cf_TextBox5.Obrigatorio = false;
            this.cf_TextBox5.Qtde_Casas_Decimais = 0;
            this.cf_TextBox5.Size = new System.Drawing.Size(118, 20);
            this.cf_TextBox5.SQLStatement = "";
            this.cf_TextBox5.Tabela = "contas_correntes";
            this.cf_TextBox5.Tabela_INNER = null;
            this.cf_TextBox5.TabIndex = 3;
            this.cf_TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox5.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox5.ValorAnterior = "";
            this.cf_TextBox5.Value = "";
            // 
            // cf_Label6
            // 
            this.cf_Label6.AutoSize = true;
            this.cf_Label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label6.Location = new System.Drawing.Point(23, 23);
            this.cf_Label6.Name = "cf_Label6";
            this.cf_Label6.Size = new System.Drawing.Size(69, 13);
            this.cf_Label6.TabIndex = 0;
            this.cf_Label6.Text = "Nº. Carteira:";
            // 
            // cf_TextBox4
            // 
            this.cf_TextBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox4.Coluna_LookUp = 0;
            this.cf_TextBox4.ControlSource = "Boleto_Carteira";
            this.cf_TextBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox4.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox4.Grupo = "";
            this.cf_TextBox4.Incluir_QueryBy = true;
            this.cf_TextBox4.Location = new System.Drawing.Point(98, 20);
            this.cf_TextBox4.LookUp = false;
            this.cf_TextBox4.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox4.Name = "cf_TextBox4";
            this.cf_TextBox4.Obrigatorio = false;
            this.cf_TextBox4.Qtde_Casas_Decimais = 0;
            this.cf_TextBox4.Size = new System.Drawing.Size(69, 20);
            this.cf_TextBox4.SQLStatement = "";
            this.cf_TextBox4.Tabela = "contas_correntes";
            this.cf_TextBox4.Tabela_INNER = null;
            this.cf_TextBox4.TabIndex = 1;
            this.cf_TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox4.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox4.ValorAnterior = "";
            this.cf_TextBox4.Value = "";
            // 
            // grdInstrucoes
            // 
            this.grdInstrucoes.Allow_Alter_Value_All_StatusForm = false;
            this.grdInstrucoes.AllowEditRow = true;
            this.grdInstrucoes.AllowUserToDeleteRows = false;
            this.grdInstrucoes.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdInstrucoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdInstrucoes.Cancel_OnClick = true;
            this.grdInstrucoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInstrucoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodInstrucao,
            this.Column3,
            this.Column4});
            this.grdInstrucoes.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdInstrucoes.GridColor = System.Drawing.Color.DimGray;
            this.grdInstrucoes.Location = new System.Drawing.Point(38, 227);
            this.grdInstrucoes.MultiSelect = false;
            this.grdInstrucoes.Name = "grdInstrucoes";
            this.grdInstrucoes.RowHeadersWidth = 24;
            this.grdInstrucoes.ShowCellErrors = false;
            this.grdInstrucoes.ShowCellToolTips = false;
            this.grdInstrucoes.ShowRowErrors = false;
            this.grdInstrucoes.Size = new System.Drawing.Size(411, 150);
            this.grdInstrucoes.TabIndex = 11;
            this.grdInstrucoes.TabStop = false;
            this.grdInstrucoes.VirtualMode = true;
            // 
            // acInstrucoes
            // 
            this.acInstrucoes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acInstrucoes.Location = new System.Drawing.Point(9, 266);
            this.acInstrucoes.Name = "acInstrucoes";
            this.acInstrucoes.Permitir_Alteracao = true;
            this.acInstrucoes.Permitir_Exclusao = true;
            this.acInstrucoes.Permitir_Inclusao = true;
            this.acInstrucoes.Size = new System.Drawing.Size(24, 55);
            this.acInstrucoes.TabIndex = 12;
            // 
            // colCodInstrucao
            // 
            this.colCodInstrucao.DataPropertyName = "Boleto_Instrucao";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCodInstrucao.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCodInstrucao.HeaderText = "Cód Instrução";
            this.colCodInstrucao.Name = "colCodInstrucao";
            this.colCodInstrucao.Retorno_Lookup = null;
            this.colCodInstrucao.ReturnColumn = "Boleto_instrucao";
            this.colCodInstrucao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCodInstrucao.SQLStatement = "";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Desc_Boleto_Instrucao";
            this.Column3.HeaderText = "Descrição Instrução";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Inativo";
            this.Column4.FalseValue = "false";
            this.Column4.HeaderText = "Inativo";
            this.Column4.IndeterminateValue = "false";
            this.Column4.Name = "Column4";
            this.Column4.TrueValue = "true";
            // 
            // f0086
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 387);
            this.Controls.Add(this.acInstrucoes);
            this.Controls.Add(this.grdInstrucoes);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.cf_Label5);
            this.Controls.Add(this.cf_TextBox3);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.cboBanco);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_TextBox2);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_ComboBox1);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cf_TextBox1);
            this.MainTabela = "contas_correntes";
            this.Name = "f0086";
            this.Text = "Contas Correntes";
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0086_user_AfterRefreshData);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.f0086_user_FormStatus_Change);
            this.Load += new System.EventHandler(this.f0086_Load);
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstrucoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox2;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_ComboBox cboBanco;
        private CompSoft.cf_Bases.cf_Label cf_Label5;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox3;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label6;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox4;
        private CompSoft.cf_Bases.cf_Label cf_Label8;
        private CompSoft.cf_Bases.cf_ComboBox cboEspecieDoc;
        private CompSoft.cf_Bases.cf_Label cf_Label7;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox5;
        private CompSoft.cf_Bases.cf_Label cf_Label9;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox6;
        private CompSoft.cf_Bases.cf_DataGrid grdInstrucoes;
        private CompSoft.cf_Bases.cf_AcaoGrid acInstrucoes;
        private CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn colCodInstrucao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
    }
}