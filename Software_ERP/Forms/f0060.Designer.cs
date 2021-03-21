namespace ERP.Forms
{
    partial class f0060
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdItens = new CompSoft.cf_Bases.cf_DataGrid();
            this.cmdPesquisa = new CompSoft.cf_Bases.cf_Button();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.chkData = new CompSoft.cf_Bases.cf_CheckBox();
            this.prdPeriodo = new CompSoft.cf_Bases.cf_Periodo();
            this.cmdBaixarEstoque = new CompSoft.cf_Bases.cf_Button();
            this.chkEmpresa = new CompSoft.cf_Bases.cf_CheckBox();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            this.chkPedido = new CompSoft.cf_Bases.cf_CheckBox();
            this.txtPedido = new CompSoft.cf_Bases.cf_TextBox();
            this.txtNF = new CompSoft.cf_Bases.cf_TextBox();
            this.chkNF = new CompSoft.cf_Bases.cf_CheckBox();
            this.Column8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdItens)).BeginInit();
            this.cf_GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdItens
            // 
            this.grdItens.AllowUserToAddRows = false;
            this.grdItens.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.grdItens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdItens.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdItens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column7,
            this.Column4,
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.NullValue = "(nulo)";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItens.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdItens.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdItens.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdItens.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdItens.GridColor = System.Drawing.Color.DimGray;
            this.grdItens.Location = new System.Drawing.Point(0, 131);
            this.grdItens.MultiSelect = false;
            this.grdItens.Name = "grdItens";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdItens.RowHeadersWidth = 22;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.grdItens.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdItens.RowTemplate.Height = 20;
            this.grdItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItens.ShowCellErrors = false;
            this.grdItens.ShowCellToolTips = false;
            this.grdItens.ShowEditingIcon = false;
            this.grdItens.ShowRowErrors = false;
            this.grdItens.Size = new System.Drawing.Size(576, 227);
            this.grdItens.TabIndex = 10;
            this.grdItens.TabStop = false;
            this.grdItens.VirtualMode = true;
            this.grdItens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItens_CellClick);
            this.grdItens.EditModeChanged += new System.EventHandler(this.grdItens_EditModeChanged);
            // 
            // cmdPesquisa
            // 
            this.cmdPesquisa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisa.ForeColor = System.Drawing.Color.Black;
            this.cmdPesquisa.Grupo = string.Empty;
            this.cmdPesquisa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdPesquisa.Location = new System.Drawing.Point(459, 102);
            this.cmdPesquisa.Name = "cmdPesquisa";
            this.cmdPesquisa.Size = new System.Drawing.Size(105, 23);
            this.cmdPesquisa.TabIndex = 9;
            this.cmdPesquisa.TabStop = false;
            this.cmdPesquisa.Text = "Pesquisar";
            this.cmdPesquisa.UseVisualStyleBackColor = true;
            this.cmdPesquisa.Click += new System.EventHandler(this.cmdPesquisa_Click);
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.chkData);
            this.cf_GroupBox2.Controls.Add(this.prdPeriodo);
            this.cf_GroupBox2.ControlSource = string.Empty;
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(10, 35);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(273, 90);
            this.cf_GroupBox2.Tabela = string.Empty;
            this.cf_GroupBox2.TabIndex = 2;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Filtro por data de vencimento";
            this.cf_GroupBox2.Value = "1";
            // 
            // chkData
            // 
            this.chkData.AutoSize = true;
            this.chkData.ControlSource = string.Empty;
            this.chkData.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkData.Grupo = string.Empty;
            this.chkData.Location = new System.Drawing.Point(217, 14);
            this.chkData.Name = "chkData";
            this.chkData.Size = new System.Drawing.Size(50, 17);
            this.chkData.Tabela = null;
            this.chkData.Tabela_INNER = null;
            this.chkData.TabIndex = 0;
            this.chkData.Text = "Filtro";
            this.chkData.UseVisualStyleBackColor = true;
            this.chkData.ValorAnterior = false;
            this.chkData.CheckedChanged += new System.EventHandler(this.chkData_CheckedChanged);
            // 
            // prdPeriodo
            // 
            this.prdPeriodo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdPeriodo.Location = new System.Drawing.Point(6, 29);
            this.prdPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdPeriodo.Name = "prdPeriodo";
            this.prdPeriodo.Size = new System.Drawing.Size(264, 51);
            this.prdPeriodo.TabIndex = 1;
            // 
            // cmdBaixarEstoque
            // 
            this.cmdBaixarEstoque.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBaixarEstoque.ForeColor = System.Drawing.Color.Black;
            this.cmdBaixarEstoque.Grupo = string.Empty;
            this.cmdBaixarEstoque.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdBaixarEstoque.Location = new System.Drawing.Point(459, 73);
            this.cmdBaixarEstoque.Name = "cmdBaixarEstoque";
            this.cmdBaixarEstoque.Size = new System.Drawing.Size(105, 23);
            this.cmdBaixarEstoque.TabIndex = 2;
            this.cmdBaixarEstoque.TabStop = false;
            this.cmdBaixarEstoque.Text = "Baixar estoque";
            this.cmdBaixarEstoque.UseVisualStyleBackColor = true;
            this.cmdBaixarEstoque.Visible = false;
            this.cmdBaixarEstoque.Click += new System.EventHandler(this.cmdBaixarEstoque_Click);
            // 
            // chkEmpresa
            // 
            this.chkEmpresa.AutoSize = true;
            this.chkEmpresa.ControlSource = string.Empty;
            this.chkEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmpresa.Grupo = string.Empty;
            this.chkEmpresa.Location = new System.Drawing.Point(10, 10);
            this.chkEmpresa.Name = "chkEmpresa";
            this.chkEmpresa.Size = new System.Drawing.Size(71, 17);
            this.chkEmpresa.Tabela = null;
            this.chkEmpresa.Tabela_INNER = null;
            this.chkEmpresa.TabIndex = 0;
            this.chkEmpresa.Text = "Empresa:";
            this.chkEmpresa.UseVisualStyleBackColor = true;
            this.chkEmpresa.ValorAnterior = false;
            this.chkEmpresa.CheckedChanged += new System.EventHandler(this.chkEmpresa_CheckedChanged);
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboEmpresa.ControlSource = string.Empty;
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.ForeColor = System.Drawing.Color.DimGray;
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Grupo = string.Empty;
            this.cboEmpresa.Location = new System.Drawing.Point(87, 8);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.Size = new System.Drawing.Size(339, 21);
            this.cboEmpresa.SQLStatement = "select Empresa, Razao_Social from empresas where inativo = 0 order by razao_socia" +
                "l";
            this.cboEmpresa.Tabela = null;
            this.cboEmpresa.Tabela_INNER = null;
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.ValorAnterior = string.Empty;
            // 
            // chkPedido
            // 
            this.chkPedido.AutoSize = true;
            this.chkPedido.ControlSource = string.Empty;
            this.chkPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPedido.Grupo = string.Empty;
            this.chkPedido.Location = new System.Drawing.Point(289, 86);
            this.chkPedido.Name = "chkPedido";
            this.chkPedido.Size = new System.Drawing.Size(92, 17);
            this.chkPedido.Tabela = null;
            this.chkPedido.Tabela_INNER = null;
            this.chkPedido.TabIndex = 5;
            this.chkPedido.Text = "Nº do pedido:";
            this.chkPedido.UseVisualStyleBackColor = true;
            this.chkPedido.ValorAnterior = false;
            this.chkPedido.CheckedChanged += new System.EventHandler(this.chkPedido_CheckedChanged);
            // 
            // txtPedido
            // 
            this.txtPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPedido.Coluna_LookUp = 0;
            this.txtPedido.ControlSource = string.Empty;
            this.txtPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.ForeColor = System.Drawing.Color.DimGray;
            this.txtPedido.Grupo = string.Empty;
            this.txtPedido.Incluir_QueryBy = true;
            this.txtPedido.Location = new System.Drawing.Point(289, 105);
            this.txtPedido.LookUp = false;
            this.txtPedido.MensagemObrigatorio = "Campo obrigatório";
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Obrigatorio = false;
            this.txtPedido.Qtde_Casas_Decimais = 0;
            this.txtPedido.Size = new System.Drawing.Size(137, 20);
            this.txtPedido.SQLStatement = string.Empty;
            this.txtPedido.Tabela = null;
            this.txtPedido.Tabela_INNER = null;
            this.txtPedido.TabIndex = 6;
            this.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPedido.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtPedido.ValorAnterior = string.Empty;
            // 
            // txtNF
            // 
            this.txtNF.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNF.Coluna_LookUp = 0;
            this.txtNF.ControlSource = string.Empty;
            this.txtNF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNF.ForeColor = System.Drawing.Color.DimGray;
            this.txtNF.Grupo = string.Empty;
            this.txtNF.Incluir_QueryBy = true;
            this.txtNF.Location = new System.Drawing.Point(289, 60);
            this.txtNF.LookUp = false;
            this.txtNF.MensagemObrigatorio = "Campo obrigatório";
            this.txtNF.Name = "txtNF";
            this.txtNF.Obrigatorio = false;
            this.txtNF.Qtde_Casas_Decimais = 0;
            this.txtNF.Size = new System.Drawing.Size(137, 20);
            this.txtNF.SQLStatement = string.Empty;
            this.txtNF.Tabela = null;
            this.txtNF.Tabela_INNER = null;
            this.txtNF.TabIndex = 12;
            this.txtNF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNF.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtNF.ValorAnterior = string.Empty;
            // 
            // chkNF
            // 
            this.chkNF.AutoSize = true;
            this.chkNF.ControlSource = string.Empty;
            this.chkNF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNF.Grupo = string.Empty;
            this.chkNF.Location = new System.Drawing.Point(289, 41);
            this.chkNF.Name = "chkNF";
            this.chkNF.Size = new System.Drawing.Size(109, 17);
            this.chkNF.Tabela = null;
            this.chkNF.Tabela_INNER = null;
            this.chkNF.TabIndex = 11;
            this.chkNF.Text = "Nº da nota fiscal:";
            this.chkNF.UseVisualStyleBackColor = true;
            this.chkNF.ValorAnterior = false;
            this.chkNF.CheckedChanged += new System.EventHandler(this.chkNF_CheckedChanged);
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column8.DataPropertyName = "sel";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column8.Frozen = true;
            this.Column8.HeaderText = "[ ]";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column8.Width = 47;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Tipo_Documento";
            this.Column7.HeaderText = "Tipo documento";
            this.Column7.Name = "Column7";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Razao_Social_Empresa";
            this.Column4.HeaderText = "Empresa";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Razao_Social_Cliente";
            this.Column5.HeaderText = "Cliente";
            this.Column5.Name = "Column5";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Numero_Nota";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "Numero NF";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Pedido";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "Pedido";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Data_Emissao";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "Data emissão";
            this.Column3.Name = "Column3";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Valor_total_nota";
            dataGridViewCellStyle6.Format = "n2";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column6.HeaderText = "Valor documento";
            this.Column6.Name = "Column6";
            // 
            // f0060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 358);
            this.Controls.Add(this.txtNF);
            this.Controls.Add(this.chkNF);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.chkPedido);
            this.Controls.Add(this.cmdBaixarEstoque);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.chkEmpresa);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.cmdPesquisa);
            this.Controls.Add(this.grdItens);
            this.Name = "f0060";
            this.Text = "Baixa manual do estoque";
            this.Load += new System.EventHandler(this.f0056_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdItens)).EndInit();
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_DataGrid grdItens;
        private CompSoft.cf_Bases.cf_Button cmdPesquisa;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_CheckBox chkData;
        private CompSoft.cf_Bases.cf_Periodo prdPeriodo;
        private CompSoft.cf_Bases.cf_Button cmdBaixarEstoque;
        private CompSoft.cf_Bases.cf_CheckBox chkEmpresa;
        private CompSoft.cf_Bases.cf_ComboBox cboEmpresa;
        private CompSoft.cf_Bases.cf_CheckBox chkPedido;
        private CompSoft.cf_Bases.cf_TextBox txtPedido;
        private CompSoft.cf_Bases.cf_TextBox txtNF;
        private CompSoft.cf_Bases.cf_CheckBox chkNF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;

    }
}