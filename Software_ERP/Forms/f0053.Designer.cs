namespace ERP.Forms
{
    partial class f0053
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
            this.grdEstoque = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCodProduto = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtDescProduto = new CompSoft.cf_Bases.cf_TextBox();
            this.rbTotal = new CompSoft.cf_Bases.cf_RadioButton();
            this.rbDisponivel = new CompSoft.cf_Bases.cf_RadioButton();
            this.rbReservado = new CompSoft.cf_Bases.cf_RadioButton();
            this.txtQuantidade = new CompSoft.cf_Bases.cf_TextBox();
            this.rbIgual = new CompSoft.cf_Bases.cf_RadioButton();
            this.rbMaior = new CompSoft.cf_Bases.cf_RadioButton();
            this.rbMenor = new CompSoft.cf_Bases.cf_RadioButton();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.lblQuantidade = new CompSoft.cf_Bases.cf_Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstoque)).BeginInit();
            this.cf_GroupBox1.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEstoque
            // 
            this.grdEstoque.Allow_Alter_Value_All_StatusForm = false;
            this.grdEstoque.AllowEditRow = false;
            this.grdEstoque.AllowUserToAddRows = false;
            this.grdEstoque.AllowUserToDeleteRows = false;
            this.grdEstoque.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdEstoque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdEstoque.Cancel_OnClick = true;
            this.grdEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.grdEstoque.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdEstoque.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdEstoque.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdEstoque.GridColor = System.Drawing.Color.DimGray;
            this.grdEstoque.Location = new System.Drawing.Point(0, 88);
            this.grdEstoque.MultiSelect = false;
            this.grdEstoque.Name = "grdEstoque";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEstoque.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstoque.RowHeadersWidth = 22;
            this.grdEstoque.RowTemplate.Height = 20;
            this.grdEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstoque.ShowCellErrors = false;
            this.grdEstoque.ShowCellToolTips = false;
            this.grdEstoque.ShowEditingIcon = false;
            this.grdEstoque.ShowRowErrors = false;
            this.grdEstoque.Size = new System.Drawing.Size(649, 268);
            this.grdEstoque.TabIndex = 0;
            this.grdEstoque.TabStop = false;
            this.grdEstoque.VirtualMode = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Produto";
            this.Column1.HeaderText = "Produto";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "desc_produto";
            this.Column2.HeaderText = "Desc. Produto";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Quantidade_Disponivel";
            this.Column3.HeaderText = "Estoque disponível";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Quantidade_Reservada";
            this.Column4.HeaderText = "Estoque reservado";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Quantidade_Total";
            this.Column5.HeaderText = "Estoque atual";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "razao_social";
            this.Column6.HeaderText = "Empresa";
            this.Column6.Name = "Column6";
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
            this.txtCodProduto.Location = new System.Drawing.Point(74, 60);
            this.txtCodProduto.LookUp = true;
            this.txtCodProduto.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Obrigatorio = false;
            this.txtCodProduto.Qtde_Casas_Decimais = 0;
            this.txtCodProduto.Size = new System.Drawing.Size(45, 20);
            this.txtCodProduto.SQLStatement = "select Produto, desc_produto from produtos where Produto@";
            this.txtCodProduto.Tabela = "";
            this.txtCodProduto.Tabela_INNER = "est";
            this.txtCodProduto.TabIndex = 1;
            this.txtCodProduto.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCodProduto.ValorAnterior = "";
            this.txtCodProduto.Value = "";
            this.txtCodProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodProduto_Validating);
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(15, 62);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(49, 13);
            this.cf_Label1.TabIndex = 2;
            this.cf_Label1.Text = "Produto:";
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
            this.cboEmpresa.Location = new System.Drawing.Point(74, 20);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.ReadOnly = false;
            this.cboEmpresa.Size = new System.Drawing.Size(297, 21);
            this.cboEmpresa.SQLStatement = "select empresa, razao_social from empresas where inativo = 0 order by razao_socia" +
                "l";
            this.cboEmpresa.Tabela = "";
            this.cboEmpresa.Tabela_INNER = "emp";
            this.cboEmpresa.TabIndex = 3;
            this.cboEmpresa.ValorAnterior = "";
            this.cboEmpresa.Value = null;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(15, 23);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(52, 13);
            this.cf_Label2.TabIndex = 4;
            this.cf_Label2.Text = "Empresa:";
            // 
            // txtDescProduto
            // 
            this.txtDescProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtDescProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescProduto.Coluna_LookUp = 0;
            this.txtDescProduto.ControlSource = "";
            this.txtDescProduto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescProduto.ForeColor = System.Drawing.Color.Black;
            this.txtDescProduto.Grupo = "";
            this.txtDescProduto.Incluir_QueryBy = true;
            this.txtDescProduto.Location = new System.Drawing.Point(125, 60);
            this.txtDescProduto.LookUp = true;
            this.txtDescProduto.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescProduto.Name = "txtDescProduto";
            this.txtDescProduto.Obrigatorio = false;
            this.txtDescProduto.Qtde_Casas_Decimais = 0;
            this.txtDescProduto.Size = new System.Drawing.Size(246, 20);
            this.txtDescProduto.SQLStatement = "select Produto, desc_produto from produtos where desc_produto@";
            this.txtDescProduto.Tabela = "";
            this.txtDescProduto.Tabela_INNER = "pro";
            this.txtDescProduto.TabIndex = 5;
            this.txtDescProduto.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescProduto.ValorAnterior = "";
            this.txtDescProduto.Value = "";
            this.txtDescProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescProduto_Validating);
            // 
            // rbTotal
            // 
            this.rbTotal.AutoSize = true;
            this.rbTotal.ControlSource = "";
            this.rbTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTotal.Grupo = "";
            this.rbTotal.Incluir_QueryBy = false;
            this.rbTotal.Location = new System.Drawing.Point(168, 16);
            this.rbTotal.MensagemObrigatorio = "";
            this.rbTotal.Name = "rbTotal";
            this.rbTotal.Obrigatorio = false;
            this.rbTotal.ReadOnly = false;
            this.rbTotal.Size = new System.Drawing.Size(49, 17);
            this.rbTotal.Tabela = "";
            this.rbTotal.Tabela_INNER = null;
            this.rbTotal.TabIndex = 6;
            this.rbTotal.Text = "Total";
            this.rbTotal.UseVisualStyleBackColor = true;
            this.rbTotal.ValorAnterior = false;
            this.rbTotal.Value = false;
            this.rbTotal.CheckedChanged += new System.EventHandler(this.rbTotal_CheckedChanged);
            // 
            // rbDisponivel
            // 
            this.rbDisponivel.AutoSize = true;
            this.rbDisponivel.ControlSource = "";
            this.rbDisponivel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDisponivel.Grupo = "";
            this.rbDisponivel.Incluir_QueryBy = false;
            this.rbDisponivel.Location = new System.Drawing.Point(6, 16);
            this.rbDisponivel.MensagemObrigatorio = "";
            this.rbDisponivel.Name = "rbDisponivel";
            this.rbDisponivel.Obrigatorio = false;
            this.rbDisponivel.ReadOnly = false;
            this.rbDisponivel.Size = new System.Drawing.Size(73, 17);
            this.rbDisponivel.Tabela = "";
            this.rbDisponivel.Tabela_INNER = null;
            this.rbDisponivel.TabIndex = 7;
            this.rbDisponivel.Text = "Disponível";
            this.rbDisponivel.UseVisualStyleBackColor = true;
            this.rbDisponivel.ValorAnterior = false;
            this.rbDisponivel.Value = false;
            this.rbDisponivel.CheckedChanged += new System.EventHandler(this.rbDisponivel_CheckedChanged);
            // 
            // rbReservado
            // 
            this.rbReservado.AutoSize = true;
            this.rbReservado.ControlSource = "";
            this.rbReservado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReservado.Grupo = "";
            this.rbReservado.Incluir_QueryBy = false;
            this.rbReservado.Location = new System.Drawing.Point(85, 16);
            this.rbReservado.MensagemObrigatorio = "";
            this.rbReservado.Name = "rbReservado";
            this.rbReservado.Obrigatorio = false;
            this.rbReservado.ReadOnly = false;
            this.rbReservado.Size = new System.Drawing.Size(77, 17);
            this.rbReservado.Tabela = "";
            this.rbReservado.Tabela_INNER = null;
            this.rbReservado.TabIndex = 8;
            this.rbReservado.Text = "Reservado";
            this.rbReservado.UseVisualStyleBackColor = true;
            this.rbReservado.ValorAnterior = false;
            this.rbReservado.Value = false;
            this.rbReservado.CheckedChanged += new System.EventHandler(this.rbReservado_CheckedChanged);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantidade.Coluna_LookUp = 0;
            this.txtQuantidade.ControlSource = "";
            this.txtQuantidade.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.ForeColor = System.Drawing.Color.DimGray;
            this.txtQuantidade.Grupo = "";
            this.txtQuantidade.Incluir_QueryBy = true;
            this.txtQuantidade.Location = new System.Drawing.Point(560, 60);
            this.txtQuantidade.LookUp = false;
            this.txtQuantidade.MensagemObrigatorio = "Campo obrigatório";
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Obrigatorio = false;
            this.txtQuantidade.Qtde_Casas_Decimais = 0;
            this.txtQuantidade.Size = new System.Drawing.Size(81, 20);
            this.txtQuantidade.SQLStatement = "";
            this.txtQuantidade.Tabela = "";
            this.txtQuantidade.Tabela_INNER = null;
            this.txtQuantidade.TabIndex = 9;
            this.txtQuantidade.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtQuantidade.ValorAnterior = "";
            this.txtQuantidade.Value = "";
            this.txtQuantidade.Visible = false;
            // 
            // rbIgual
            // 
            this.rbIgual.AutoSize = true;
            this.rbIgual.ControlSource = "";
            this.rbIgual.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIgual.Grupo = "";
            this.rbIgual.Incluir_QueryBy = false;
            this.rbIgual.Location = new System.Drawing.Point(124, 16);
            this.rbIgual.MensagemObrigatorio = "";
            this.rbIgual.Name = "rbIgual";
            this.rbIgual.Obrigatorio = false;
            this.rbIgual.ReadOnly = false;
            this.rbIgual.Size = new System.Drawing.Size(47, 17);
            this.rbIgual.Tabela = "";
            this.rbIgual.Tabela_INNER = null;
            this.rbIgual.TabIndex = 6;
            this.rbIgual.Text = "igual";
            this.rbIgual.UseVisualStyleBackColor = true;
            this.rbIgual.ValorAnterior = false;
            this.rbIgual.Value = false;
            // 
            // rbMaior
            // 
            this.rbMaior.AutoSize = true;
            this.rbMaior.ControlSource = "";
            this.rbMaior.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMaior.Grupo = "";
            this.rbMaior.Incluir_QueryBy = false;
            this.rbMaior.Location = new System.Drawing.Point(6, 16);
            this.rbMaior.MensagemObrigatorio = "";
            this.rbMaior.Name = "rbMaior";
            this.rbMaior.Obrigatorio = false;
            this.rbMaior.ReadOnly = false;
            this.rbMaior.Size = new System.Drawing.Size(51, 17);
            this.rbMaior.Tabela = "";
            this.rbMaior.Tabela_INNER = null;
            this.rbMaior.TabIndex = 7;
            this.rbMaior.Text = "maior";
            this.rbMaior.UseVisualStyleBackColor = true;
            this.rbMaior.ValorAnterior = false;
            this.rbMaior.Value = false;
            // 
            // rbMenor
            // 
            this.rbMenor.AutoSize = true;
            this.rbMenor.ControlSource = "";
            this.rbMenor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMenor.Grupo = "";
            this.rbMenor.Incluir_QueryBy = false;
            this.rbMenor.Location = new System.Drawing.Point(63, 16);
            this.rbMenor.MensagemObrigatorio = "";
            this.rbMenor.Name = "rbMenor";
            this.rbMenor.Obrigatorio = false;
            this.rbMenor.ReadOnly = false;
            this.rbMenor.Size = new System.Drawing.Size(55, 17);
            this.rbMenor.Tabela = "";
            this.rbMenor.Tabela_INNER = null;
            this.rbMenor.TabIndex = 8;
            this.rbMenor.Text = "menor";
            this.rbMenor.UseVisualStyleBackColor = true;
            this.rbMenor.ValorAnterior = false;
            this.rbMenor.Value = false;
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.rbTotal);
            this.cf_GroupBox1.Controls.Add(this.rbDisponivel);
            this.cf_GroupBox1.Controls.Add(this.rbReservado);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(377, 0);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(229, 41);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 12;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Tipo de pesquisa";
            this.cf_GroupBox1.Value = "";
            this.cf_GroupBox1.Visible = false;
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.rbMenor);
            this.cf_GroupBox2.Controls.Add(this.rbIgual);
            this.cf_GroupBox2.Controls.Add(this.rbMaior);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(377, 41);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(177, 41);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 13;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Filtro de busca";
            this.cf_GroupBox2.Value = "";
            this.cf_GroupBox2.Visible = false;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(560, 44);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(81, 13);
            this.lblQuantidade.TabIndex = 14;
            this.lblQuantidade.Text = "Valor para filtro";
            this.lblQuantidade.Visible = false;
            // 
            // f0053
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 356);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtDescProduto);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.grdEstoque);
            this.MainTabela = "estoques";
            this.Name = "f0053";
            this.Text = "Estoque";
            this.Load += new System.EventHandler(this.f0053_Load);
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0053_user_AfterRefreshData);
            this.user_AfterClear += new CompSoft.FormSet.AfterClear(this.f0053_user_AfterClear);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstoque)).EndInit();
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_DataGrid grdEstoque;
        private CompSoft.cf_Bases.cf_TextBox txtCodProduto;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_ComboBox cboEmpresa;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtDescProduto;
        private CompSoft.cf_Bases.cf_RadioButton rbTotal;
        private CompSoft.cf_Bases.cf_RadioButton rbDisponivel;
        private CompSoft.cf_Bases.cf_RadioButton rbReservado;
        private CompSoft.cf_Bases.cf_TextBox txtQuantidade;
        private CompSoft.cf_Bases.cf_RadioButton rbIgual;
        private CompSoft.cf_Bases.cf_RadioButton rbMaior;
        private CompSoft.cf_Bases.cf_RadioButton rbMenor;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_Label lblQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}