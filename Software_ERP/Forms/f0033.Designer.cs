namespace ERP.Forms
{
    partial class f0033
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.chkInativo = new CompSoft.cf_Bases.cf_CheckBox();
            this.txtCodigoTabela = new CompSoft.cf_Bases.cf_TextBox();
            this.txtDescricao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.grdItens = new CompSoft.cf_Bases.cf_DataGrid();
            this.acTabela = new CompSoft.cf_Bases.cf_AcaoGrid();
            this.cmdListaProdutos = new CompSoft.cf_Bases.cf_Button();
            this.cf_ComboBox1 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label6 = new CompSoft.cf_Bases.cf_Label();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdItens)).BeginInit();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(34, 13);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(43, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Tabela:";
            // 
            // chkInativo
            // 
            this.chkInativo.AutoSize = true;
            this.chkInativo.ControlSource = "Inativo";
            this.chkInativo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInativo.Grupo = "";
            this.chkInativo.Incluir_QueryBy = false;
            this.chkInativo.Location = new System.Drawing.Point(330, 14);
            this.chkInativo.MensagemObrigatorio = "";
            this.chkInativo.Name = "chkInativo";
            this.chkInativo.Obrigatorio = false;
            this.chkInativo.ReadOnly = false;
            this.chkInativo.Size = new System.Drawing.Size(67, 17);
            this.chkInativo.Tabela = "tabelas_precos";
            this.chkInativo.Tabela_INNER = null;
            this.chkInativo.TabIndex = 2;
            this.chkInativo.Text = "Inativo";
            this.chkInativo.UseVisualStyleBackColor = true;
            this.chkInativo.ValorAnterior = false;
            this.chkInativo.Value = false;
            // 
            // txtCodigoTabela
            // 
            this.txtCodigoTabela.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodigoTabela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoTabela.Coluna_LookUp = 0;
            this.txtCodigoTabela.ControlSource = "Tabela_Preco";
            this.txtCodigoTabela.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoTabela.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodigoTabela.Grupo = "";
            this.txtCodigoTabela.Incluir_QueryBy = true;
            this.txtCodigoTabela.Location = new System.Drawing.Point(83, 11);
            this.txtCodigoTabela.LookUp = false;
            this.txtCodigoTabela.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodigoTabela.Name = "txtCodigoTabela";
            this.txtCodigoTabela.Obrigatorio = false;
            this.txtCodigoTabela.Qtde_Casas_Decimais = 0;
            this.txtCodigoTabela.Size = new System.Drawing.Size(45, 20);
            this.txtCodigoTabela.SQLStatement = "";
            this.txtCodigoTabela.Tabela = "tabelas_precos";
            this.txtCodigoTabela.Tabela_INNER = null;
            this.txtCodigoTabela.TabIndex = 1;
            this.txtCodigoTabela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoTabela.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCodigoTabela.ValorAnterior = "";
            this.txtCodigoTabela.Value = "";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Coluna_LookUp = 0;
            this.txtDescricao.ControlSource = "Desc_Tabela_Preco";
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricao.Grupo = "";
            this.txtDescricao.Incluir_QueryBy = true;
            this.txtDescricao.Location = new System.Drawing.Point(83, 37);
            this.txtDescricao.LookUp = false;
            this.txtDescricao.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Obrigatorio = false;
            this.txtDescricao.Qtde_Casas_Decimais = 0;
            this.txtDescricao.Size = new System.Drawing.Size(314, 20);
            this.txtDescricao.SQLStatement = "";
            this.txtDescricao.Tabela = "tabelas_precos";
            this.txtDescricao.Tabela_INNER = null;
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao.ValorAnterior = "";
            this.txtDescricao.Value = "";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(20, 39);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 3;
            this.cf_Label2.Text = "Descrição:";
            // 
            // grdItens
            // 
            this.grdItens.Allow_Alter_Value_All_StatusForm = false;
            this.grdItens.AllowEditRow = true;
            this.grdItens.AllowUserToAddRows = false;
            this.grdItens.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.grdItens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdItens.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdItens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdItens.Cancel_OnClick = true;
            this.grdItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column3,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "(nulo)";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItens.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdItens.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdItens.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdItens.GridColor = System.Drawing.Color.DimGray;
            this.grdItens.Location = new System.Drawing.Point(37, 91);
            this.grdItens.MultiSelect = false;
            this.grdItens.Name = "grdItens";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdItens.RowHeadersWidth = 22;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.grdItens.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdItens.RowTemplate.Height = 20;
            this.grdItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItens.ShowCellErrors = false;
            this.grdItens.ShowCellToolTips = false;
            this.grdItens.ShowEditingIcon = false;
            this.grdItens.ShowRowErrors = false;
            this.grdItens.Size = new System.Drawing.Size(360, 156);
            this.grdItens.TabIndex = 5;
            this.grdItens.TabStop = false;
            this.grdItens.VirtualMode = true;
            // 
            // acTabela
            // 
            this.acTabela.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acTabela.Location = new System.Drawing.Point(8, 126);
            this.acTabela.Name = "acTabela";
            this.acTabela.Permitir_Alteracao = true;
            this.acTabela.Permitir_Exclusao = true;
            this.acTabela.Permitir_Inclusao = true;
            this.acTabela.Size = new System.Drawing.Size(23, 47);
            this.acTabela.TabIndex = 6;
            // 
            // cmdListaProdutos
            // 
            this.cmdListaProdutos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdListaProdutos.ForeColor = System.Drawing.Color.Black;
            this.cmdListaProdutos.Grupo = "";
            this.cmdListaProdutos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdListaProdutos.Location = new System.Drawing.Point(37, 253);
            this.cmdListaProdutos.Name = "cmdListaProdutos";
            this.cmdListaProdutos.Size = new System.Drawing.Size(95, 23);
            this.cmdListaProdutos.TabIndex = 12;
            this.cmdListaProdutos.TabStop = false;
            this.cmdListaProdutos.Text = "Lista produtos";
            this.cmdListaProdutos.UseVisualStyleBackColor = false;
            this.cmdListaProdutos.Click += new System.EventHandler(this.cmdListaProdutos_Click);
            // 
            // cf_ComboBox1
            // 
            this.cf_ComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox1.ControlSource = "Condicao_Pagamento_Pedido";
            this.cf_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox1.FormattingEnabled = true;
            this.cf_ComboBox1.Grupo = "";
            this.cf_ComboBox1.Incluir_QueryBy = true;
            this.cf_ComboBox1.Location = new System.Drawing.Point(83, 63);
            this.cf_ComboBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox1.Name = "cf_ComboBox1";
            this.cf_ComboBox1.Obrigatorio = false;
            this.cf_ComboBox1.ReadOnly = false;
            this.cf_ComboBox1.Size = new System.Drawing.Size(246, 21);
            this.cf_ComboBox1.SQLStatement = "select Condicao_Pagamento_Pedido, Desc_Cond_Pgto from condicoes_Pagamento_pedido " +
                "where inativo = 0 order by desc_cond_pgto";
            this.cf_ComboBox1.Tabela = "tabelas_precos";
            this.cf_ComboBox1.Tabela_INNER = null;
            this.cf_ComboBox1.TabIndex = 15;
            this.cf_ComboBox1.ValorAnterior = "";
            this.cf_ComboBox1.Value = null;
            // 
            // cf_Label6
            // 
            this.cf_Label6.AutoSize = true;
            this.cf_Label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label6.Location = new System.Drawing.Point(8, 66);
            this.cf_Label6.Name = "cf_Label6";
            this.cf_Label6.Size = new System.Drawing.Size(69, 13);
            this.cf_Label6.TabIndex = 16;
            this.cf_Label6.Text = "Cond. Pgto.:";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Produto";
            this.Column4.HeaderText = "Produto";
            this.Column4.Name = "Column4";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Desc_Produto";
            this.Column1.HeaderText = "Descrição do produto";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Valor_Original";
            this.Column3.HeaderText = "Valor original";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Valor_Venda";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Valor de venda";
            this.Column2.Name = "Column2";
            // 
            // f0033
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 281);
            this.Controls.Add(this.cf_Label6);
            this.Controls.Add(this.cf_ComboBox1);
            this.Controls.Add(this.cmdListaProdutos);
            this.Controls.Add(this.acTabela);
            this.Controls.Add(this.grdItens);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtCodigoTabela);
            this.Controls.Add(this.chkInativo);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "tabelas_precos";
            this.Name = "f0033";
            this.Text = "Tabela de preço";
            this.Load += new System.EventHandler(this.f0033_Load);
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0033_user_AfterRefreshData);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.f0033_user_FormStatus_Change);
            ((System.ComponentModel.ISupportInitialize)(this.grdItens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_CheckBox chkInativo;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_DataGrid grdItens;
        private CompSoft.cf_Bases.cf_AcaoGrid acTabela;
        private CompSoft.cf_Bases.cf_Button cmdListaProdutos;
        public CompSoft.cf_Bases.cf_TextBox txtCodigoTabela;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}