namespace ERP.Forms
{
    partial class f0046
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboUsuarios = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.chkPemissoaModulo = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.lstMenus = new CompSoft.cf_Bases.cf_ListBox();
            this.grdAcessos = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSalvar = new CompSoft.cf_Bases.cf_Button();
            this.cmdExcluir = new CompSoft.cf_Bases.cf_Button();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdModulos = new CompSoft.cf_Bases.cf_DataGrid();
            this.cf_GroupBox1.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAcessos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdModulos)).BeginInit();
            this.SuspendLayout();
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboUsuarios.ControlSource = "";
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboUsuarios.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsuarios.ForeColor = System.Drawing.Color.DimGray;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Grupo = "";
            this.cboUsuarios.Incluir_QueryBy = true;
            this.cboUsuarios.Location = new System.Drawing.Point(59, 7);
            this.cboUsuarios.MensagemObrigatorio = "Campo obrigatório";
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Obrigatorio = false;
            this.cboUsuarios.ReadOnly = false;
            this.cboUsuarios.Size = new System.Drawing.Size(192, 21);
            this.cboUsuarios.SQLStatement = "select * from usuarios where ativo = 1";
            this.cboUsuarios.Tabela = "";
            this.cboUsuarios.Tabela_INNER = null;
            this.cboUsuarios.TabIndex = 1;
            this.cboUsuarios.ValorAnterior = "";
            this.cboUsuarios.Value = null;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(6, 11);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(47, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Usuário:";
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.chkPemissoaModulo);
            this.cf_GroupBox1.Controls.Add(this.grdModulos);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(5, 216);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(251, 173);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 3;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Modulos";
            this.cf_GroupBox1.Value = "";
            // 
            // chkPemissoaModulo
            // 
            this.chkPemissoaModulo.AutoSize = true;
            this.chkPemissoaModulo.ControlSource = "";
            this.chkPemissoaModulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPemissoaModulo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPemissoaModulo.Grupo = "";
            this.chkPemissoaModulo.Incluir_QueryBy = false;
            this.chkPemissoaModulo.Location = new System.Drawing.Point(89, -1);
            this.chkPemissoaModulo.MensagemObrigatorio = "";
            this.chkPemissoaModulo.Name = "chkPemissoaModulo";
            this.chkPemissoaModulo.Obrigatorio = false;
            this.chkPemissoaModulo.ReadOnly = false;
            this.chkPemissoaModulo.Size = new System.Drawing.Size(156, 17);
            this.chkPemissoaModulo.Tabela = "";
            this.chkPemissoaModulo.Tabela_INNER = null;
            this.chkPemissoaModulo.TabIndex = 0;
            this.chkPemissoaModulo.Text = "Acesso completo ao módulo";
            this.chkPemissoaModulo.UseVisualStyleBackColor = true;
            this.chkPemissoaModulo.ValorAnterior = false;
            this.chkPemissoaModulo.Value = false;
            this.chkPemissoaModulo.CheckedChanged += new System.EventHandler(this.chkPemissoaModulo_CheckedChanged);
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.lstMenus);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(262, 216);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(251, 173);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 4;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Menus";
            this.cf_GroupBox2.Value = "";
            // 
            // lstMenus
            // 
            this.lstMenus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstMenus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMenus.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lstMenus.ForeColor = System.Drawing.Color.DimGray;
            this.lstMenus.FormattingEnabled = true;
            this.lstMenus.Location = new System.Drawing.Point(9, 19);
            this.lstMenus.Name = "lstMenus";
            this.lstMenus.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstMenus.Size = new System.Drawing.Size(236, 145);
            this.lstMenus.SQLStatement = "";
            this.lstMenus.TabIndex = 0;
            this.lstMenus.UseTabStops = false;
            // 
            // grdAcessos
            // 
            this.grdAcessos.Allow_Alter_Value_All_StatusForm = false;
            this.grdAcessos.AllowEditRow = true;
            this.grdAcessos.AllowUserToAddRows = false;
            this.grdAcessos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.NullValue = "(nulo)";
            this.grdAcessos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdAcessos.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdAcessos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdAcessos.Cancel_OnClick = true;
            this.grdAcessos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAcessos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.NullValue = "(nulo)";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAcessos.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdAcessos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdAcessos.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdAcessos.GridColor = System.Drawing.Color.DimGray;
            this.grdAcessos.Location = new System.Drawing.Point(5, 34);
            this.grdAcessos.MultiSelect = false;
            this.grdAcessos.Name = "grdAcessos";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAcessos.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdAcessos.RowHeadersWidth = 22;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.grdAcessos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdAcessos.RowTemplate.Height = 20;
            this.grdAcessos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAcessos.ShowCellErrors = false;
            this.grdAcessos.ShowCellToolTips = false;
            this.grdAcessos.ShowEditingIcon = false;
            this.grdAcessos.ShowRowErrors = false;
            this.grdAcessos.Size = new System.Drawing.Size(508, 150);
            this.grdAcessos.TabIndex = 2;
            this.grdAcessos.TabStop = false;
            this.grdAcessos.VirtualMode = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Nome_Usuario";
            this.Column1.HeaderText = "Nome usuário";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Descricao_Modulo";
            this.Column2.HeaderText = "Modulo";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Descricao";
            this.Column3.HeaderText = "Menu";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // cmdSalvar
            // 
            this.cmdSalvar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalvar.ForeColor = System.Drawing.Color.Black;
            this.cmdSalvar.Grupo = "";
            this.cmdSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSalvar.Location = new System.Drawing.Point(361, 191);
            this.cmdSalvar.Name = "cmdSalvar";
            this.cmdSalvar.ReadOnly = false;
            this.cmdSalvar.Size = new System.Drawing.Size(75, 23);
            this.cmdSalvar.TabIndex = 5;
            this.cmdSalvar.TabStop = false;
            this.cmdSalvar.Text = "Incluir";
            this.cmdSalvar.UseVisualStyleBackColor = true;
            this.cmdSalvar.Click += new System.EventHandler(this.cmdSalvar_Click);
            // 
            // cmdExcluir
            // 
            this.cmdExcluir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcluir.ForeColor = System.Drawing.Color.Black;
            this.cmdExcluir.Grupo = "";
            this.cmdExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExcluir.Location = new System.Drawing.Point(438, 191);
            this.cmdExcluir.Name = "cmdExcluir";
            this.cmdExcluir.ReadOnly = false;
            this.cmdExcluir.Size = new System.Drawing.Size(75, 23);
            this.cmdExcluir.TabIndex = 6;
            this.cmdExcluir.TabStop = false;
            this.cmdExcluir.Text = "Excluir";
            this.cmdExcluir.UseVisualStyleBackColor = true;
            this.cmdExcluir.Click += new System.EventHandler(this.cmdExcluir_Click);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Descricao_Modulo";
            this.Column4.HeaderText = "Modulo";
            this.Column4.Name = "Column4";
            this.Column4.Width = 180;
            // 
            // grdModulos
            // 
            this.grdModulos.Allow_Alter_Value_All_StatusForm = false;
            this.grdModulos.AllowEditRow = true;
            this.grdModulos.AllowUserToAddRows = false;
            this.grdModulos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.grdModulos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdModulos.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdModulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdModulos.Cancel_OnClick = true;
            this.grdModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdModulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = "(nulo)";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdModulos.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdModulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdModulos.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdModulos.GridColor = System.Drawing.Color.DimGray;
            this.grdModulos.Location = new System.Drawing.Point(6, 18);
            this.grdModulos.MultiSelect = false;
            this.grdModulos.Name = "grdModulos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdModulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdModulos.RowHeadersWidth = 22;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.grdModulos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdModulos.RowTemplate.Height = 20;
            this.grdModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdModulos.ShowCellErrors = false;
            this.grdModulos.ShowCellToolTips = false;
            this.grdModulos.ShowEditingIcon = false;
            this.grdModulos.ShowRowErrors = false;
            this.grdModulos.Size = new System.Drawing.Size(240, 150);
            this.grdModulos.TabIndex = 1;
            this.grdModulos.TabStop = false;
            this.grdModulos.VirtualMode = true;
            this.grdModulos.SelectionChanged += new System.EventHandler(this.grdModulos_SelectionChanged);
            // 
            // f0046
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 395);
            this.Controls.Add(this.cmdExcluir);
            this.Controls.Add(this.cmdSalvar);
            this.Controls.Add(this.grdAcessos);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cboUsuarios);
            this.MainTabela = "usuarios_acessos";
            this.Name = "f0046";
            this.Text = "Permissões de acesso";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.f0046_FormClosed);
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0046_user_AfterRefreshData);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.f0046_user_FormStatus_Change);
            this.user_BeforeNew += new CompSoft.FormSet.BeforeNew(this.f0046_user_BeforeNew);
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.cf_GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAcessos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdModulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_ComboBox cboUsuarios;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_DataGrid grdAcessos;
        private CompSoft.cf_Bases.cf_Button cmdSalvar;
        private CompSoft.cf_Bases.cf_Button cmdExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private CompSoft.cf_Bases.cf_CheckBox chkPemissoaModulo;
        private CompSoft.cf_Bases.cf_ListBox lstMenus;
        private CompSoft.cf_Bases.cf_DataGrid grdModulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}