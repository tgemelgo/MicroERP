namespace ERP.Forms
{
    partial class f0090
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
            this.grdDados = new CompSoft.cf_Bases.cf_DataGrid();
            this.prdPeriodo = new CompSoft.cf_Bases.cf_Periodo();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.optNaoProtestado = new CompSoft.cf_Bases.cf_RadioButton();
            this.optProtestado = new CompSoft.cf_Bases.cf_RadioButton();
            this.optTodos = new CompSoft.cf_Bases.cf_RadioButton();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.txtCodCliente = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtNomeCliente = new CompSoft.cf_Bases.cf_TextBox();
            this.chkAtivaEmpresa = new CompSoft.cf_Bases.cf_CheckBox();
            this.chkAtivaCliente = new CompSoft.cf_Bases.cf_CheckBox();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDados)).BeginInit();
            this.cf_GroupBox1.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDados
            // 
            this.grdDados.Allow_Alter_Value_All_StatusForm = false;
            this.grdDados.AllowEditRow = true;
            this.grdDados.AllowUserToDeleteRows = false;
            this.grdDados.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdDados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDados.Cancel_OnClick = true;
            this.grdDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column9,
            this.Column5,
            this.Column7});
            this.grdDados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdDados.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdDados.GridColor = System.Drawing.Color.DimGray;
            this.grdDados.Location = new System.Drawing.Point(0, 166);
            this.grdDados.MultiSelect = false;
            this.grdDados.Name = "grdDados";
            this.grdDados.RowHeadersWidth = 24;
            this.grdDados.ShowCellErrors = false;
            this.grdDados.ShowCellToolTips = false;
            this.grdDados.ShowRowErrors = false;
            this.grdDados.Size = new System.Drawing.Size(1039, 360);
            this.grdDados.TabIndex = 9;
            this.grdDados.TabStop = false;
            this.grdDados.VirtualMode = true;
            // 
            // prdPeriodo
            // 
            this.prdPeriodo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdPeriodo.Location = new System.Drawing.Point(6, 21);
            this.prdPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdPeriodo.Name = "prdPeriodo";
            this.prdPeriodo.Size = new System.Drawing.Size(264, 51);
            this.prdPeriodo.TabIndex = 0;
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.prdPeriodo);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(12, 64);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(285, 79);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 7;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Data de vencimento";
            this.cf_GroupBox1.Value = "";
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.optNaoProtestado);
            this.cf_GroupBox2.Controls.Add(this.optProtestado);
            this.cf_GroupBox2.Controls.Add(this.optTodos);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(303, 64);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(172, 96);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 8;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Status do Titulo";
            this.cf_GroupBox2.Value = "";
            // 
            // optNaoProtestado
            // 
            this.optNaoProtestado.AutoSize = true;
            this.optNaoProtestado.ControlSource = "";
            this.optNaoProtestado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNaoProtestado.Grupo = "";
            this.optNaoProtestado.Incluir_QueryBy = false;
            this.optNaoProtestado.Location = new System.Drawing.Point(7, 69);
            this.optNaoProtestado.MensagemObrigatorio = "";
            this.optNaoProtestado.Name = "optNaoProtestado";
            this.optNaoProtestado.Obrigatorio = false;
            this.optNaoProtestado.ReadOnly = false;
            this.optNaoProtestado.Size = new System.Drawing.Size(100, 17);
            this.optNaoProtestado.Tabela = "";
            this.optNaoProtestado.Tabela_INNER = null;
            this.optNaoProtestado.TabIndex = 2;
            this.optNaoProtestado.Text = "Não protestado";
            this.optNaoProtestado.UseVisualStyleBackColor = true;
            this.optNaoProtestado.ValorAnterior = false;
            this.optNaoProtestado.Value = false;
            // 
            // optProtestado
            // 
            this.optProtestado.AutoSize = true;
            this.optProtestado.ControlSource = "";
            this.optProtestado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optProtestado.Grupo = "";
            this.optProtestado.Incluir_QueryBy = false;
            this.optProtestado.Location = new System.Drawing.Point(7, 45);
            this.optProtestado.MensagemObrigatorio = "";
            this.optProtestado.Name = "optProtestado";
            this.optProtestado.Obrigatorio = false;
            this.optProtestado.ReadOnly = false;
            this.optProtestado.Size = new System.Drawing.Size(78, 17);
            this.optProtestado.Tabela = "";
            this.optProtestado.Tabela_INNER = null;
            this.optProtestado.TabIndex = 1;
            this.optProtestado.Text = "Protestado";
            this.optProtestado.UseVisualStyleBackColor = true;
            this.optProtestado.ValorAnterior = false;
            this.optProtestado.Value = false;
            // 
            // optTodos
            // 
            this.optTodos.AutoSize = true;
            this.optTodos.Checked = true;
            this.optTodos.ControlSource = "";
            this.optTodos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTodos.Grupo = "";
            this.optTodos.Incluir_QueryBy = false;
            this.optTodos.Location = new System.Drawing.Point(7, 21);
            this.optTodos.MensagemObrigatorio = "";
            this.optTodos.Name = "optTodos";
            this.optTodos.Obrigatorio = false;
            this.optTodos.ReadOnly = false;
            this.optTodos.Size = new System.Drawing.Size(54, 17);
            this.optTodos.Tabela = "";
            this.optTodos.Tabela_INNER = null;
            this.optTodos.TabIndex = 0;
            this.optTodos.TabStop = true;
            this.optTodos.Text = "Todos";
            this.optTodos.UseVisualStyleBackColor = true;
            this.optTodos.ValorAnterior = false;
            this.optTodos.Value = true;
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
            this.cboEmpresa.Location = new System.Drawing.Point(70, 10);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.ReadOnly = false;
            this.cboEmpresa.Size = new System.Drawing.Size(405, 21);
            this.cboEmpresa.SQLStatement = "SELECT Empresa, Razao_Social FROM empresas WHERE inativo = 0 ORDER BY Razao_Socia" +
                "l";
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
            this.cf_Label1.Location = new System.Drawing.Point(12, 13);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(52, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Empresa:";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtCodCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodCliente.Coluna_LookUp = 0;
            this.txtCodCliente.ControlSource = "";
            this.txtCodCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCodCliente.Grupo = "";
            this.txtCodCliente.Incluir_QueryBy = true;
            this.txtCodCliente.Location = new System.Drawing.Point(70, 38);
            this.txtCodCliente.LookUp = true;
            this.txtCodCliente.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Obrigatorio = false;
            this.txtCodCliente.Qtde_Casas_Decimais = 0;
            this.txtCodCliente.Size = new System.Drawing.Size(61, 20);
            this.txtCodCliente.SQLStatement = "SELECT Cliente, Razao_Social, Nome_Fantasia, CPF_CNPJ FROM clientes WHERE cliente" +
                "@ ORDER BY Razao_Social";
            this.txtCodCliente.Tabela = "";
            this.txtCodCliente.Tabela_INNER = null;
            this.txtCodCliente.TabIndex = 4;
            this.txtCodCliente.TipoControles = CompSoft.TipoControle.Geral;
            this.txtCodCliente.ValorAnterior = "";
            this.txtCodCliente.Value = "";
            this.txtCodCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCliente_Validating);
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(20, 42);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(44, 13);
            this.cf_Label2.TabIndex = 3;
            this.cf_Label2.Text = "Cliente:";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNomeCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeCliente.Coluna_LookUp = 0;
            this.txtNomeCliente.ControlSource = "";
            this.txtNomeCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtNomeCliente.Grupo = "";
            this.txtNomeCliente.Incluir_QueryBy = true;
            this.txtNomeCliente.Location = new System.Drawing.Point(137, 38);
            this.txtNomeCliente.LookUp = false;
            this.txtNomeCliente.MensagemObrigatorio = "Campo obrigatório";
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Obrigatorio = false;
            this.txtNomeCliente.Qtde_Casas_Decimais = 0;
            this.txtNomeCliente.Size = new System.Drawing.Size(338, 20);
            this.txtNomeCliente.SQLStatement = "";
            this.txtNomeCliente.Tabela = "";
            this.txtNomeCliente.Tabela_INNER = null;
            this.txtNomeCliente.TabIndex = 5;
            this.txtNomeCliente.TipoControles = CompSoft.TipoControle.Geral;
            this.txtNomeCliente.ValorAnterior = "";
            this.txtNomeCliente.Value = "";
            // 
            // chkAtivaEmpresa
            // 
            this.chkAtivaEmpresa.AutoSize = true;
            this.chkAtivaEmpresa.ControlSource = "";
            this.chkAtivaEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivaEmpresa.Grupo = "";
            this.chkAtivaEmpresa.Incluir_QueryBy = false;
            this.chkAtivaEmpresa.Location = new System.Drawing.Point(482, 13);
            this.chkAtivaEmpresa.MensagemObrigatorio = "";
            this.chkAtivaEmpresa.Name = "chkAtivaEmpresa";
            this.chkAtivaEmpresa.Obrigatorio = false;
            this.chkAtivaEmpresa.ReadOnly = false;
            this.chkAtivaEmpresa.Size = new System.Drawing.Size(51, 17);
            this.chkAtivaEmpresa.Tabela = "";
            this.chkAtivaEmpresa.Tabela_INNER = null;
            this.chkAtivaEmpresa.TabIndex = 2;
            this.chkAtivaEmpresa.Text = "Ativa";
            this.chkAtivaEmpresa.UseVisualStyleBackColor = true;
            this.chkAtivaEmpresa.ValorAnterior = false;
            this.chkAtivaEmpresa.Value = false;
            this.chkAtivaEmpresa.CheckedChanged += new System.EventHandler(this.chkAtivaEmpresa_CheckedChanged);
            // 
            // chkAtivaCliente
            // 
            this.chkAtivaCliente.AutoSize = true;
            this.chkAtivaCliente.ControlSource = "";
            this.chkAtivaCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivaCliente.Grupo = "";
            this.chkAtivaCliente.Incluir_QueryBy = false;
            this.chkAtivaCliente.Location = new System.Drawing.Point(481, 38);
            this.chkAtivaCliente.MensagemObrigatorio = "";
            this.chkAtivaCliente.Name = "chkAtivaCliente";
            this.chkAtivaCliente.Obrigatorio = false;
            this.chkAtivaCliente.ReadOnly = false;
            this.chkAtivaCliente.Size = new System.Drawing.Size(51, 17);
            this.chkAtivaCliente.Tabela = "";
            this.chkAtivaCliente.Tabela_INNER = null;
            this.chkAtivaCliente.TabIndex = 6;
            this.chkAtivaCliente.Text = "Ativa";
            this.chkAtivaCliente.UseVisualStyleBackColor = true;
            this.chkAtivaCliente.ValorAnterior = false;
            this.chkAtivaCliente.Value = false;
            this.chkAtivaCliente.CheckedChanged += new System.EventHandler(this.chAtivaCliente_CheckedChanged);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Razao_Social_Empresa";
            this.Column6.HeaderText = "Empresa";
            this.Column6.Name = "Column6";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Razao_Social_Cliente";
            this.Column8.HeaderText = "Cliente";
            this.Column8.Name = "Column8";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Numero_Documento";
            this.Column1.HeaderText = "Numero documento";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Data_Vencimento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Data vencimento";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Valor_Titulo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Valor Total";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Valor_Parcela";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Valor Titulo";
            this.Column4.Name = "Column4";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Valor_Pago";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column9.HeaderText = "Valor Pago";
            this.Column9.Name = "Column9";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Protesto";
            this.Column5.FalseValue = "false";
            this.Column5.HeaderText = "Protestado";
            this.Column5.IndeterminateValue = "false";
            this.Column5.Name = "Column5";
            this.Column5.TrueValue = "true";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Parcela_Paga";
            this.Column7.FalseValue = "false";
            this.Column7.HeaderText = "Pago";
            this.Column7.IndeterminateValue = "false";
            this.Column7.Name = "Column7";
            this.Column7.TrueValue = "true";
            // 
            // f0090
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 526);
            this.Controls.Add(this.chkAtivaCliente);
            this.Controls.Add(this.chkAtivaEmpresa);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.grdDados);
            this.MainTabela = "contas_receber_parcela";
            this.Name = "f0090";
            this.Text = "Verifica Status Titulos a Receber";
            this.Tipo_Formulario = CompSoft.TipoForm.Consulta;
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0090_user_AfterRefreshData);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.f0090_user_FormStatus_Change);
            ((System.ComponentModel.ISupportInitialize)(this.grdDados)).EndInit();
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_DataGrid grdDados;
        private CompSoft.cf_Bases.cf_Periodo prdPeriodo;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_RadioButton optNaoProtestado;
        private CompSoft.cf_Bases.cf_RadioButton optProtestado;
        private CompSoft.cf_Bases.cf_RadioButton optTodos;
        private CompSoft.cf_Bases.cf_ComboBox cboEmpresa;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtCodCliente;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtNomeCliente;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivaEmpresa;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
    }
}