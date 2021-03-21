namespace ERP.Forms
{
    partial class f0055
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdComissao = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prdPeriodo = new CompSoft.cf_Bases.cf_Periodo();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.optDataNF = new CompSoft.cf_Bases.cf_RadioButton();
            this.optDataPedido = new CompSoft.cf_Bases.cf_RadioButton();
            this.chkAtivaData = new CompSoft.cf_Bases.cf_CheckBox();
            this.cboVendedor = new CompSoft.cf_Bases.cf_ComboBox();
            this.chkVendedor = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.chkAtivaNFImpressa = new CompSoft.cf_Bases.cf_CheckBox();
            this.optNFImpressaNao = new CompSoft.cf_Bases.cf_RadioButton();
            this.optNFImpressaSim = new CompSoft.cf_Bases.cf_RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdComissao)).BeginInit();
            this.cf_GroupBox1.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdComissao
            // 
            this.grdComissao.Allow_Alter_Value_All_StatusForm = false;
            this.grdComissao.AllowEditRow = false;
            this.grdComissao.AllowUserToAddRows = false;
            this.grdComissao.AllowUserToDeleteRows = false;
            this.grdComissao.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdComissao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdComissao.Cancel_OnClick = true;
            this.grdComissao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdComissao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.grdComissao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdComissao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdComissao.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdComissao.GridColor = System.Drawing.Color.DimGray;
            this.grdComissao.Location = new System.Drawing.Point(0, 109);
            this.grdComissao.MultiSelect = false;
            this.grdComissao.Name = "grdComissao";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdComissao.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdComissao.RowHeadersWidth = 22;
            this.grdComissao.RowTemplate.Height = 20;
            this.grdComissao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdComissao.ShowCellErrors = false;
            this.grdComissao.ShowCellToolTips = false;
            this.grdComissao.ShowEditingIcon = false;
            this.grdComissao.ShowRowErrors = false;
            this.grdComissao.Size = new System.Drawing.Size(544, 224);
            this.grdComissao.TabIndex = 4;
            this.grdComissao.TabStop = false;
            this.grdComissao.VirtualMode = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Numero_Nota";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Nº. nota fiscal";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Pedido";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Nº pedido";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Vendedor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Cód. vendedor";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Nome_Vendedor";
            this.Column4.HeaderText = "Vendedor";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Data_pedido";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "Data pedido";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Data_Emissao";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column6.HeaderText = "Emissao Nota Fiscal";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Impressa";
            this.Column7.HeaderText = "NF Impressa";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Valor_Total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "n2";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column8.HeaderText = "Valor pedido";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Valor_Comissao";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "n2";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column9.HeaderText = "Valor comissão";
            this.Column9.Name = "Column9";
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // prdPeriodo
            // 
            this.prdPeriodo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdPeriodo.Location = new System.Drawing.Point(4, 38);
            this.prdPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdPeriodo.Name = "prdPeriodo";
            this.prdPeriodo.Size = new System.Drawing.Size(264, 51);
            this.prdPeriodo.TabIndex = 3;
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.optDataNF);
            this.cf_GroupBox1.Controls.Add(this.optDataPedido);
            this.cf_GroupBox1.Controls.Add(this.chkAtivaData);
            this.cf_GroupBox1.Controls.Add(this.prdPeriodo);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(9, 7);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(275, 96);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 0;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Filtro por data";
            this.cf_GroupBox1.Value = "";
            // 
            // optDataNF
            // 
            this.optDataNF.AutoSize = true;
            this.optDataNF.ControlSource = "";
            this.optDataNF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDataNF.Grupo = "";
            this.optDataNF.Incluir_QueryBy = false;
            this.optDataNF.Location = new System.Drawing.Point(69, 15);
            this.optDataNF.MensagemObrigatorio = "";
            this.optDataNF.Name = "optDataNF";
            this.optDataNF.Obrigatorio = false;
            this.optDataNF.ReadOnly = false;
            this.optDataNF.Size = new System.Drawing.Size(130, 17);
            this.optDataNF.Tabela = "";
            this.optDataNF.Tabela_INNER = null;
            this.optDataNF.TabIndex = 2;
            this.optDataNF.TabStop = true;
            this.optDataNF.Text = "Emissão da nota fiscal";
            this.optDataNF.UseVisualStyleBackColor = true;
            this.optDataNF.ValorAnterior = false;
            this.optDataNF.Value = false;
            // 
            // optDataPedido
            // 
            this.optDataPedido.AutoSize = true;
            this.optDataPedido.ControlSource = "";
            this.optDataPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDataPedido.Grupo = "";
            this.optDataPedido.Incluir_QueryBy = false;
            this.optDataPedido.Location = new System.Drawing.Point(6, 15);
            this.optDataPedido.MensagemObrigatorio = "";
            this.optDataPedido.Name = "optDataPedido";
            this.optDataPedido.Obrigatorio = false;
            this.optDataPedido.ReadOnly = false;
            this.optDataPedido.Size = new System.Drawing.Size(57, 17);
            this.optDataPedido.Tabela = "";
            this.optDataPedido.Tabela_INNER = null;
            this.optDataPedido.TabIndex = 1;
            this.optDataPedido.TabStop = true;
            this.optDataPedido.Text = "Pedido";
            this.optDataPedido.UseVisualStyleBackColor = true;
            this.optDataPedido.ValorAnterior = false;
            this.optDataPedido.Value = false;
            // 
            // chkAtivaData
            // 
            this.chkAtivaData.AutoSize = true;
            this.chkAtivaData.ControlSource = "";
            this.chkAtivaData.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivaData.Grupo = "";
            this.chkAtivaData.Incluir_QueryBy = false;
            this.chkAtivaData.Location = new System.Drawing.Point(83, 2);
            this.chkAtivaData.MensagemObrigatorio = "";
            this.chkAtivaData.Name = "chkAtivaData";
            this.chkAtivaData.Obrigatorio = false;
            this.chkAtivaData.ReadOnly = false;
            this.chkAtivaData.Size = new System.Drawing.Size(15, 14);
            this.chkAtivaData.Tabela = "";
            this.chkAtivaData.Tabela_INNER = null;
            this.chkAtivaData.TabIndex = 0;
            this.chkAtivaData.UseVisualStyleBackColor = true;
            this.chkAtivaData.ValorAnterior = false;
            this.chkAtivaData.Value = false;
            this.chkAtivaData.CheckedChanged += new System.EventHandler(this.chkAtivaData_CheckedChanged);
            // 
            // cboVendedor
            // 
            this.cboVendedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboVendedor.ControlSource = "";
            this.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVendedor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboVendedor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVendedor.ForeColor = System.Drawing.Color.DimGray;
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Grupo = "";
            this.cboVendedor.Incluir_QueryBy = true;
            this.cboVendedor.Location = new System.Drawing.Point(290, 82);
            this.cboVendedor.MensagemObrigatorio = "Campo obrigatório";
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Obrigatorio = false;
            this.cboVendedor.ReadOnly = false;
            this.cboVendedor.Size = new System.Drawing.Size(245, 21);
            this.cboVendedor.SQLStatement = "select Vendedor, Nome_Vendedor from vendedores where(inativo = 0) order by nome_v" +
                "endedor";
            this.cboVendedor.Tabela = "";
            this.cboVendedor.Tabela_INNER = null;
            this.cboVendedor.TabIndex = 3;
            this.cboVendedor.ValorAnterior = "";
            this.cboVendedor.Value = null;
            // 
            // chkVendedor
            // 
            this.chkVendedor.AutoSize = true;
            this.chkVendedor.ControlSource = "";
            this.chkVendedor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVendedor.Grupo = "";
            this.chkVendedor.Incluir_QueryBy = false;
            this.chkVendedor.Location = new System.Drawing.Point(290, 63);
            this.chkVendedor.MensagemObrigatorio = "";
            this.chkVendedor.Name = "chkVendedor";
            this.chkVendedor.Obrigatorio = false;
            this.chkVendedor.ReadOnly = false;
            this.chkVendedor.Size = new System.Drawing.Size(72, 17);
            this.chkVendedor.Tabela = "";
            this.chkVendedor.Tabela_INNER = null;
            this.chkVendedor.TabIndex = 2;
            this.chkVendedor.Text = "Vendedor";
            this.chkVendedor.UseVisualStyleBackColor = true;
            this.chkVendedor.ValorAnterior = false;
            this.chkVendedor.Value = false;
            this.chkVendedor.CheckedChanged += new System.EventHandler(this.chkVendedor_CheckedChanged);
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.chkAtivaNFImpressa);
            this.cf_GroupBox2.Controls.Add(this.optNFImpressaNao);
            this.cf_GroupBox2.Controls.Add(this.optNFImpressaSim);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(290, 7);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(173, 47);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 1;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Nota fiscal / Cupom impresso";
            this.cf_GroupBox2.Value = "";
            // 
            // chkAtivaNFImpressa
            // 
            this.chkAtivaNFImpressa.AutoSize = true;
            this.chkAtivaNFImpressa.ControlSource = "";
            this.chkAtivaNFImpressa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivaNFImpressa.Grupo = "";
            this.chkAtivaNFImpressa.Incluir_QueryBy = false;
            this.chkAtivaNFImpressa.Location = new System.Drawing.Point(152, 1);
            this.chkAtivaNFImpressa.MensagemObrigatorio = "";
            this.chkAtivaNFImpressa.Name = "chkAtivaNFImpressa";
            this.chkAtivaNFImpressa.Obrigatorio = false;
            this.chkAtivaNFImpressa.ReadOnly = false;
            this.chkAtivaNFImpressa.Size = new System.Drawing.Size(15, 14);
            this.chkAtivaNFImpressa.Tabela = "";
            this.chkAtivaNFImpressa.Tabela_INNER = null;
            this.chkAtivaNFImpressa.TabIndex = 5;
            this.chkAtivaNFImpressa.UseVisualStyleBackColor = true;
            this.chkAtivaNFImpressa.ValorAnterior = false;
            this.chkAtivaNFImpressa.Value = false;
            this.chkAtivaNFImpressa.CheckedChanged += new System.EventHandler(this.chkAtivaNFImpressa_CheckedChanged);
            // 
            // optNFImpressaNao
            // 
            this.optNFImpressaNao.AutoSize = true;
            this.optNFImpressaNao.ControlSource = "";
            this.optNFImpressaNao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNFImpressaNao.Grupo = "";
            this.optNFImpressaNao.Incluir_QueryBy = false;
            this.optNFImpressaNao.Location = new System.Drawing.Point(53, 20);
            this.optNFImpressaNao.MensagemObrigatorio = "";
            this.optNFImpressaNao.Name = "optNFImpressaNao";
            this.optNFImpressaNao.Obrigatorio = false;
            this.optNFImpressaNao.ReadOnly = false;
            this.optNFImpressaNao.Size = new System.Drawing.Size(44, 17);
            this.optNFImpressaNao.Tabela = "";
            this.optNFImpressaNao.Tabela_INNER = null;
            this.optNFImpressaNao.TabIndex = 1;
            this.optNFImpressaNao.TabStop = true;
            this.optNFImpressaNao.Text = "Não";
            this.optNFImpressaNao.UseVisualStyleBackColor = true;
            this.optNFImpressaNao.ValorAnterior = false;
            this.optNFImpressaNao.Value = false;
            // 
            // optNFImpressaSim
            // 
            this.optNFImpressaSim.AutoSize = true;
            this.optNFImpressaSim.ControlSource = "";
            this.optNFImpressaSim.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNFImpressaSim.Grupo = "";
            this.optNFImpressaSim.Incluir_QueryBy = false;
            this.optNFImpressaSim.Location = new System.Drawing.Point(6, 20);
            this.optNFImpressaSim.MensagemObrigatorio = "";
            this.optNFImpressaSim.Name = "optNFImpressaSim";
            this.optNFImpressaSim.Obrigatorio = false;
            this.optNFImpressaSim.ReadOnly = false;
            this.optNFImpressaSim.Size = new System.Drawing.Size(41, 17);
            this.optNFImpressaSim.Tabela = "";
            this.optNFImpressaSim.Tabela_INNER = null;
            this.optNFImpressaSim.TabIndex = 0;
            this.optNFImpressaSim.TabStop = true;
            this.optNFImpressaSim.Text = "Sim";
            this.optNFImpressaSim.UseVisualStyleBackColor = true;
            this.optNFImpressaSim.ValorAnterior = false;
            this.optNFImpressaSim.Value = false;
            // 
            // f0055
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 333);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.chkVendedor);
            this.Controls.Add(this.cboVendedor);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.grdComissao);
            this.MainTabela = "comissao";
            this.Name = "f0055";
            this.Text = "Comissão dos vendedores";
            this.Tipo_Formulario = CompSoft.TipoForm.Consulta;
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0055_user_AfterRefreshData);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.f0055_user_FormStatus_Change);
            ((System.ComponentModel.ISupportInitialize)(this.grdComissao)).EndInit();
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_DataGrid grdComissao;
        private CompSoft.cf_Bases.cf_Periodo prdPeriodo;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_RadioButton optDataNF;
        private CompSoft.cf_Bases.cf_RadioButton optDataPedido;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivaData;
        private CompSoft.cf_Bases.cf_ComboBox cboVendedor;
        private CompSoft.cf_Bases.cf_CheckBox chkVendedor;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivaNFImpressa;
        private CompSoft.cf_Bases.cf_RadioButton optNFImpressaNao;
        private CompSoft.cf_Bases.cf_RadioButton optNFImpressaSim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}