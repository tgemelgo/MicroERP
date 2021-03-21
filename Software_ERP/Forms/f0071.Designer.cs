namespace ERP.Forms
{
    partial class f0071
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
            this.grdLista = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_Pageframe1 = new CompSoft.cf_Bases.cf_Pageframe();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkAtivar_TpDoc = new CompSoft.cf_Bases.cf_CheckBox();
            this.chkAtivar_Empresa = new CompSoft.cf_Bases.cf_CheckBox();
            this.chkAtivar_DataEmissao = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_GroupBox3 = new CompSoft.cf_Bases.cf_GroupBox();
            this.prdDataEmissao = new CompSoft.cf_Bases.cf_Periodo();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.optTpDocAmbos = new CompSoft.cf_Bases.cf_RadioButton();
            this.optTpDocCupom = new CompSoft.cf_Bases.cf_RadioButton();
            this.optTpDocNotaFiscal = new CompSoft.cf_Bases.cf_RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.cf_Pageframe1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cf_GroupBox3.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            this.cf_GroupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdLista
            // 
            this.grdLista.Allow_Alter_Value_All_StatusForm = false;
            this.grdLista.AllowEditRow = true;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdLista.Cancel_OnClick = true;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.grdLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLista.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdLista.GridColor = System.Drawing.Color.DimGray;
            this.grdLista.Location = new System.Drawing.Point(3, 3);
            this.grdLista.MultiSelect = false;
            this.grdLista.Name = "grdLista";
            this.grdLista.RowHeadersWidth = 24;
            this.grdLista.ShowCellErrors = false;
            this.grdLista.ShowCellToolTips = false;
            this.grdLista.ShowRowErrors = false;
            this.grdLista.Size = new System.Drawing.Size(543, 326);
            this.grdLista.TabIndex = 0;
            this.grdLista.TabStop = false;
            this.grdLista.VirtualMode = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Produto";
            this.Column1.HeaderText = "Produto";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Desc_Produto";
            this.Column2.HeaderText = "Descr. Prod.";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Quantidade";
            this.Column3.HeaderText = "Quantidade";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Peso_Bruto";
            this.Column4.HeaderText = "Peso Bruto";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Peso_Liquido";
            this.Column5.HeaderText = "Peso Liquido";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Valor_Total_Item";
            this.Column6.HeaderText = "Valor";
            this.Column6.Name = "Column6";
            // 
            // cf_Pageframe1
            // 
            this.cf_Pageframe1.Controls.Add(this.tabPage1);
            this.cf_Pageframe1.Controls.Add(this.tabPage2);
            this.cf_Pageframe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cf_Pageframe1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Pageframe1.HotTrack = true;
            this.cf_Pageframe1.Location = new System.Drawing.Point(0, 0);
            this.cf_Pageframe1.Name = "cf_Pageframe1";
            this.cf_Pageframe1.SelectedIndex = 0;
            this.cf_Pageframe1.Size = new System.Drawing.Size(557, 358);
            this.cf_Pageframe1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkAtivar_TpDoc);
            this.tabPage1.Controls.Add(this.chkAtivar_Empresa);
            this.tabPage1.Controls.Add(this.chkAtivar_DataEmissao);
            this.tabPage1.Controls.Add(this.cf_GroupBox3);
            this.tabPage1.Controls.Add(this.cf_GroupBox2);
            this.tabPage1.Controls.Add(this.cf_GroupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filtro avançado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkAtivar_TpDoc
            // 
            this.chkAtivar_TpDoc.AutoSize = true;
            this.chkAtivar_TpDoc.ControlSource = "";
            this.chkAtivar_TpDoc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivar_TpDoc.Grupo = "";
            this.chkAtivar_TpDoc.Incluir_QueryBy = false;
            this.chkAtivar_TpDoc.Location = new System.Drawing.Point(148, 158);
            this.chkAtivar_TpDoc.MensagemObrigatorio = "";
            this.chkAtivar_TpDoc.Name = "chkAtivar_TpDoc";
            this.chkAtivar_TpDoc.Obrigatorio = false;
            this.chkAtivar_TpDoc.ReadOnly = false;
            this.chkAtivar_TpDoc.Size = new System.Drawing.Size(55, 17);
            this.chkAtivar_TpDoc.Tabela = "";
            this.chkAtivar_TpDoc.Tabela_INNER = null;
            this.chkAtivar_TpDoc.TabIndex = 2;
            this.chkAtivar_TpDoc.Text = "Ativar";
            this.chkAtivar_TpDoc.UseVisualStyleBackColor = true;
            this.chkAtivar_TpDoc.ValorAnterior = false;
            this.chkAtivar_TpDoc.Value = false;
            // 
            // chkAtivar_Empresa
            // 
            this.chkAtivar_Empresa.AutoSize = true;
            this.chkAtivar_Empresa.ControlSource = "";
            this.chkAtivar_Empresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivar_Empresa.Grupo = "";
            this.chkAtivar_Empresa.Incluir_QueryBy = false;
            this.chkAtivar_Empresa.Location = new System.Drawing.Point(439, 70);
            this.chkAtivar_Empresa.MensagemObrigatorio = "";
            this.chkAtivar_Empresa.Name = "chkAtivar_Empresa";
            this.chkAtivar_Empresa.Obrigatorio = false;
            this.chkAtivar_Empresa.ReadOnly = false;
            this.chkAtivar_Empresa.Size = new System.Drawing.Size(55, 17);
            this.chkAtivar_Empresa.Tabela = "";
            this.chkAtivar_Empresa.Tabela_INNER = null;
            this.chkAtivar_Empresa.TabIndex = 5;
            this.chkAtivar_Empresa.Text = "Ativar";
            this.chkAtivar_Empresa.UseVisualStyleBackColor = true;
            this.chkAtivar_Empresa.ValorAnterior = false;
            this.chkAtivar_Empresa.Value = false;
            // 
            // chkAtivar_DataEmissao
            // 
            this.chkAtivar_DataEmissao.AutoSize = true;
            this.chkAtivar_DataEmissao.ControlSource = "";
            this.chkAtivar_DataEmissao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivar_DataEmissao.Grupo = "";
            this.chkAtivar_DataEmissao.Incluir_QueryBy = false;
            this.chkAtivar_DataEmissao.Location = new System.Drawing.Point(439, 158);
            this.chkAtivar_DataEmissao.MensagemObrigatorio = "";
            this.chkAtivar_DataEmissao.Name = "chkAtivar_DataEmissao";
            this.chkAtivar_DataEmissao.Obrigatorio = false;
            this.chkAtivar_DataEmissao.ReadOnly = false;
            this.chkAtivar_DataEmissao.Size = new System.Drawing.Size(55, 17);
            this.chkAtivar_DataEmissao.Tabela = "";
            this.chkAtivar_DataEmissao.Tabela_INNER = null;
            this.chkAtivar_DataEmissao.TabIndex = 8;
            this.chkAtivar_DataEmissao.Text = "Ativar";
            this.chkAtivar_DataEmissao.UseVisualStyleBackColor = true;
            this.chkAtivar_DataEmissao.ValorAnterior = false;
            this.chkAtivar_DataEmissao.Value = false;
            // 
            // cf_GroupBox3
            // 
            this.cf_GroupBox3.Controls.Add(this.prdDataEmissao);
            this.cf_GroupBox3.ControlSource = "";
            this.cf_GroupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox3.Location = new System.Drawing.Point(211, 168);
            this.cf_GroupBox3.Name = "cf_GroupBox3";
            this.cf_GroupBox3.Size = new System.Drawing.Size(283, 80);
            this.cf_GroupBox3.Tabela = "";
            this.cf_GroupBox3.TabIndex = 7;
            this.cf_GroupBox3.TabStop = false;
            this.cf_GroupBox3.Text = "Data emissão";
            this.cf_GroupBox3.Value = "";
            // 
            // prdDataEmissao
            // 
            this.prdDataEmissao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdDataEmissao.Location = new System.Drawing.Point(6, 17);
            this.prdDataEmissao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdDataEmissao.Name = "prdDataEmissao";
            this.prdDataEmissao.Size = new System.Drawing.Size(264, 51);
            this.prdDataEmissao.TabIndex = 0;
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.cboEmpresa);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(29, 80);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(465, 55);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 6;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Empresa";
            this.cf_GroupBox2.Value = "";
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
            this.cboEmpresa.Location = new System.Drawing.Point(10, 22);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.ReadOnly = false;
            this.cboEmpresa.Size = new System.Drawing.Size(442, 21);
            this.cboEmpresa.SQLStatement = "SELECT EMPRESA, NOME_FANTASIA FROM EMPRESAS ORDER BY 2";
            this.cboEmpresa.Tabela = "";
            this.cboEmpresa.Tabela_INNER = null;
            this.cboEmpresa.TabIndex = 3;
            this.cboEmpresa.ValorAnterior = null;
            this.cboEmpresa.Value = null;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.optTpDocAmbos);
            this.cf_GroupBox1.Controls.Add(this.optTpDocCupom);
            this.cf_GroupBox1.Controls.Add(this.optTpDocNotaFiscal);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(29, 168);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(176, 80);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 0;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Tipo de documento";
            this.cf_GroupBox1.Value = "";
            // 
            // optTpDocAmbos
            // 
            this.optTpDocAmbos.AutoSize = true;
            this.optTpDocAmbos.Checked = true;
            this.optTpDocAmbos.ControlSource = "";
            this.optTpDocAmbos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTpDocAmbos.Grupo = "";
            this.optTpDocAmbos.Incluir_QueryBy = false;
            this.optTpDocAmbos.Location = new System.Drawing.Point(102, 44);
            this.optTpDocAmbos.MensagemObrigatorio = "";
            this.optTpDocAmbos.Name = "optTpDocAmbos";
            this.optTpDocAmbos.Obrigatorio = false;
            this.optTpDocAmbos.ReadOnly = false;
            this.optTpDocAmbos.Size = new System.Drawing.Size(57, 17);
            this.optTpDocAmbos.Tabela = "";
            this.optTpDocAmbos.Tabela_INNER = null;
            this.optTpDocAmbos.TabIndex = 2;
            this.optTpDocAmbos.TabStop = true;
            this.optTpDocAmbos.Text = "Ambos";
            this.optTpDocAmbos.UseVisualStyleBackColor = true;
            this.optTpDocAmbos.ValorAnterior = false;
            this.optTpDocAmbos.Value = true;
            // 
            // optTpDocCupom
            // 
            this.optTpDocCupom.AutoSize = true;
            this.optTpDocCupom.ControlSource = "";
            this.optTpDocCupom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTpDocCupom.Grupo = "";
            this.optTpDocCupom.Incluir_QueryBy = false;
            this.optTpDocCupom.Location = new System.Drawing.Point(14, 44);
            this.optTpDocCupom.MensagemObrigatorio = "";
            this.optTpDocCupom.Name = "optTpDocCupom";
            this.optTpDocCupom.Obrigatorio = false;
            this.optTpDocCupom.ReadOnly = false;
            this.optTpDocCupom.Size = new System.Drawing.Size(58, 17);
            this.optTpDocCupom.Tabela = "";
            this.optTpDocCupom.Tabela_INNER = null;
            this.optTpDocCupom.TabIndex = 1;
            this.optTpDocCupom.Text = "Cupom";
            this.optTpDocCupom.UseVisualStyleBackColor = true;
            this.optTpDocCupom.ValorAnterior = false;
            this.optTpDocCupom.Value = false;
            // 
            // optTpDocNotaFiscal
            // 
            this.optTpDocNotaFiscal.AutoSize = true;
            this.optTpDocNotaFiscal.ControlSource = "";
            this.optTpDocNotaFiscal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTpDocNotaFiscal.Grupo = "";
            this.optTpDocNotaFiscal.Incluir_QueryBy = false;
            this.optTpDocNotaFiscal.Location = new System.Drawing.Point(14, 20);
            this.optTpDocNotaFiscal.MensagemObrigatorio = "";
            this.optTpDocNotaFiscal.Name = "optTpDocNotaFiscal";
            this.optTpDocNotaFiscal.Obrigatorio = false;
            this.optTpDocNotaFiscal.ReadOnly = false;
            this.optTpDocNotaFiscal.Size = new System.Drawing.Size(77, 17);
            this.optTpDocNotaFiscal.Tabela = "";
            this.optTpDocNotaFiscal.Tabela_INNER = null;
            this.optTpDocNotaFiscal.TabIndex = 0;
            this.optTpDocNotaFiscal.Text = "Nota Fiscal";
            this.optTpDocNotaFiscal.UseVisualStyleBackColor = true;
            this.optTpDocNotaFiscal.ValorAnterior = false;
            this.optTpDocNotaFiscal.Value = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdLista);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(549, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Resultado do filtro";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // f0071
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 358);
            this.Controls.Add(this.cf_Pageframe1);
            this.MainTabela = "notas_fiscais";
            this.Name = "f0071";
            this.Text = "Venda por produto";
            this.Tipo_Formulario = CompSoft.TipoForm.Consulta;
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0071_user_AfterRefreshData);
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.cf_Pageframe1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.cf_GroupBox3.ResumeLayout(false);
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CompSoft.cf_Bases.cf_DataGrid grdLista;
        private CompSoft.cf_Bases.cf_Pageframe cf_Pageframe1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivar_TpDoc;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_RadioButton optTpDocCupom;
        private CompSoft.cf_Bases.cf_RadioButton optTpDocNotaFiscal;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivar_Empresa;
        private CompSoft.cf_Bases.cf_ComboBox cboEmpresa;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox3;
        private CompSoft.cf_Bases.cf_Periodo prdDataEmissao;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivar_DataEmissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private CompSoft.cf_Bases.cf_RadioButton optTpDocAmbos;
    }
}