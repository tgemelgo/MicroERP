namespace ERP.Forms
{
    partial class f0035
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
            this.txtCodigo = new CompSoft.cf_Bases.cf_TextBox();
            this.txtDescricao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.chkInativo = new CompSoft.cf_Bases.cf_CheckBox();
            this.grdPrazo = new CompSoft.cf_Bases.cf_DataGrid();
            this.acPrazo = new CompSoft.cf_Bases.cf_AcaoGrid();
            this.cf_CheckBox1 = new CompSoft.cf_Bases.cf_CheckBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrazo)).BeginInit();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(22, 15);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(44, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Coluna_LookUp = 0;
            this.txtCodigo.ControlSource = "Condicao_Pagamento_Pedido";
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodigo.Grupo = "";
            this.txtCodigo.Incluir_QueryBy = true;
            this.txtCodigo.Location = new System.Drawing.Point(72, 12);
            this.txtCodigo.LookUp = false;
            this.txtCodigo.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Obrigatorio = false;
            this.txtCodigo.Qtde_Casas_Decimais = 0;
            this.txtCodigo.Size = new System.Drawing.Size(55, 20);
            this.txtCodigo.SQLStatement = "";
            this.txtCodigo.Tabela = "condicoes_pagamento_pedido";
            this.txtCodigo.Tabela_INNER = null;
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigo.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCodigo.ValorAnterior = "";
            this.txtCodigo.Value = "";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Coluna_LookUp = 0;
            this.txtDescricao.ControlSource = "Desc_Cond_Pgto";
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricao.Grupo = "";
            this.txtDescricao.Incluir_QueryBy = true;
            this.txtDescricao.Location = new System.Drawing.Point(72, 38);
            this.txtDescricao.LookUp = false;
            this.txtDescricao.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Obrigatorio = false;
            this.txtDescricao.Qtde_Casas_Decimais = 0;
            this.txtDescricao.Size = new System.Drawing.Size(240, 20);
            this.txtDescricao.SQLStatement = "";
            this.txtDescricao.Tabela = "condicoes_pagamento_pedido";
            this.txtDescricao.Tabela_INNER = null;
            this.txtDescricao.TabIndex = 3;
            this.txtDescricao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao.ValorAnterior = "";
            this.txtDescricao.Value = "";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(9, 41);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Descrição:";
            // 
            // chkInativo
            // 
            this.chkInativo.AutoSize = true;
            this.chkInativo.ControlSource = "Inativo";
            this.chkInativo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInativo.Grupo = "";
            this.chkInativo.Incluir_QueryBy = false;
            this.chkInativo.Location = new System.Drawing.Point(245, 15);
            this.chkInativo.MensagemObrigatorio = "";
            this.chkInativo.Name = "chkInativo";
            this.chkInativo.Obrigatorio = false;
            this.chkInativo.ReadOnly = false;
            this.chkInativo.Size = new System.Drawing.Size(67, 17);
            this.chkInativo.Tabela = "condicoes_pagamento_pedido";
            this.chkInativo.Tabela_INNER = null;
            this.chkInativo.TabIndex = 5;
            this.chkInativo.Text = "Inativo";
            this.chkInativo.UseVisualStyleBackColor = true;
            this.chkInativo.ValorAnterior = false;
            this.chkInativo.Value = false;
            // 
            // grdPrazo
            // 
            this.grdPrazo.Allow_Alter_Value_All_StatusForm = false;
            this.grdPrazo.AllowEditRow = true;
            this.grdPrazo.AllowUserToAddRows = false;
            this.grdPrazo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.grdPrazo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPrazo.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdPrazo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdPrazo.Cancel_OnClick = true;
            this.grdPrazo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPrazo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "(nulo)";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPrazo.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdPrazo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdPrazo.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdPrazo.GridColor = System.Drawing.Color.DimGray;
            this.grdPrazo.Location = new System.Drawing.Point(35, 83);
            this.grdPrazo.MultiSelect = false;
            this.grdPrazo.Name = "grdPrazo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPrazo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdPrazo.RowHeadersWidth = 22;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.grdPrazo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdPrazo.RowTemplate.Height = 20;
            this.grdPrazo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPrazo.ShowCellErrors = false;
            this.grdPrazo.ShowCellToolTips = false;
            this.grdPrazo.ShowEditingIcon = false;
            this.grdPrazo.ShowRowErrors = false;
            this.grdPrazo.Size = new System.Drawing.Size(276, 150);
            this.grdPrazo.TabIndex = 6;
            this.grdPrazo.TabStop = false;
            this.grdPrazo.VirtualMode = true;
            // 
            // acPrazo
            // 
            this.acPrazo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acPrazo.Location = new System.Drawing.Point(6, 105);
            this.acPrazo.Name = "acPrazo";
            this.acPrazo.Permitir_Alteracao = true;
            this.acPrazo.Permitir_Exclusao = true;
            this.acPrazo.Permitir_Inclusao = true;
            this.acPrazo.Size = new System.Drawing.Size(23, 47);
            this.acPrazo.TabIndex = 7;
            // 
            // cf_CheckBox1
            // 
            this.cf_CheckBox1.AutoSize = true;
            this.cf_CheckBox1.ControlSource = "Parcelado";
            this.cf_CheckBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox1.Grupo = "";
            this.cf_CheckBox1.Incluir_QueryBy = false;
            this.cf_CheckBox1.Location = new System.Drawing.Point(72, 63);
            this.cf_CheckBox1.MensagemObrigatorio = "";
            this.cf_CheckBox1.Name = "cf_CheckBox1";
            this.cf_CheckBox1.Obrigatorio = false;
            this.cf_CheckBox1.ReadOnly = false;
            this.cf_CheckBox1.Size = new System.Drawing.Size(230, 17);
            this.cf_CheckBox1.Tabela = "condicoes_pagamento_pedido";
            this.cf_CheckBox1.Tabela_INNER = null;
            this.cf_CheckBox1.TabIndex = 4;
            this.cf_CheckBox1.Text = "Condição de pagamento de parcelamento?";
            this.cf_CheckBox1.UseVisualStyleBackColor = true;
            this.cf_CheckBox1.ValorAnterior = false;
            this.cf_CheckBox1.Value = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Prazo_dias";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Prazo em dias";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // f0035
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 245);
            this.Controls.Add(this.cf_CheckBox1);
            this.Controls.Add(this.acPrazo);
            this.Controls.Add(this.grdPrazo);
            this.Controls.Add(this.chkInativo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "condicoes_pagamento_pedido";
            this.Name = "f0035";
            this.Text = "Condições de pagamento do pedido";
            this.Load += new System.EventHandler(this.f0035_Load);
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0035_user_AfterRefreshData);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.f0035_user_FormStatus_Change);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrazo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtCodigo;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_CheckBox chkInativo;
        private CompSoft.cf_Bases.cf_DataGrid grdPrazo;
        private CompSoft.cf_Bases.cf_AcaoGrid acPrazo;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}