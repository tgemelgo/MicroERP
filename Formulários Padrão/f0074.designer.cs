namespace ERP.Forms
{
    partial class f0074
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
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.grdFavoritos = new CompSoft.cf_Bases.cf_DataGrid();
            this.cboUsuario = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.Column1 = new CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFavoritos)).BeginInit();
            this.SuspendLayout();
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.cf_Label1);
            this.cf_GroupBox1.Controls.Add(this.cboUsuario);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(12, 7);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(289, 55);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 0;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Filtro";
            this.cf_GroupBox1.Value = "";
            // 
            // grdFavoritos
            // 
            this.grdFavoritos.Allow_Alter_Value_All_StatusForm = false;
            this.grdFavoritos.AllowEditRow = true;
            this.grdFavoritos.AllowUserToDeleteRows = false;
            this.grdFavoritos.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdFavoritos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdFavoritos.Cancel_OnClick = true;
            this.grdFavoritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFavoritos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.grdFavoritos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdFavoritos.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdFavoritos.GridColor = System.Drawing.Color.DimGray;
            this.grdFavoritos.Location = new System.Drawing.Point(0, 68);
            this.grdFavoritos.MultiSelect = false;
            this.grdFavoritos.Name = "grdFavoritos";
            this.grdFavoritos.RowHeadersWidth = 24;
            this.grdFavoritos.ShowCellErrors = false;
            this.grdFavoritos.ShowCellToolTips = false;
            this.grdFavoritos.ShowRowErrors = false;
            this.grdFavoritos.Size = new System.Drawing.Size(544, 265);
            this.grdFavoritos.TabIndex = 1;
            this.grdFavoritos.TabStop = false;
            this.grdFavoritos.VirtualMode = true;
            // 
            // cboUsuario
            // 
            this.cboUsuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboUsuario.ControlSource = "";
            this.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboUsuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Grupo = "";
            this.cboUsuario.Incluir_QueryBy = true;
            this.cboUsuario.Location = new System.Drawing.Point(60, 20);
            this.cboUsuario.MensagemObrigatorio = "Campo obrigatório";
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Obrigatorio = false;
            this.cboUsuario.ReadOnly = false;
            this.cboUsuario.Size = new System.Drawing.Size(212, 21);
            this.cboUsuario.SQLStatement = "select Usuario, Nome_usuario from usuarios where ativo = 1 order by nome_usuario";
            this.cboUsuario.Tabela = "";
            this.cboUsuario.Tabela_INNER = null;
            this.cboUsuario.TabIndex = 0;
            this.cboUsuario.ValorAnterior = null;
            this.cboUsuario.Value = null;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(7, 24);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(47, 13);
            this.cf_Label1.TabIndex = 1;
            this.cf_Label1.Text = "Usuário:";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Grupo_Favorito";
            this.Column1.HeaderText = "Grupo Favorito";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Retorno_Lookup = null;
            this.Column1.ReturnColumn = "Grupo_Favorito";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.SQLStatement = "select * from grupos_favoritos where grupo_favorito@";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Desc_Grupo_Favorito";
            this.Column2.HeaderText = "Desc. Grupo Favorito";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Menu_Item";
            this.Column3.HeaderText = "Menu item";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Retorno_Lookup = null;
            this.Column3.ReturnColumn = "Menu_item";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.SQLStatement = "select menu_item, descricao, namespace + \'.\' + formulario as \'Formulário\' from me" +
                "nus_itens where formulario is not null and menu_item@";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Descricao";
            this.Column4.HeaderText = "Desc. Menu Item";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Usuario";
            this.Column5.HeaderText = "Usuário";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.Retorno_Lookup = null;
            this.Column5.ReturnColumn = "Usuario";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.SQLStatement = "select Usuario, Nome_usuario from usuarios where ativo = 1 and usuario@";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Nome_Usuario";
            this.Column6.HeaderText = "Nome Usuário";
            this.Column6.Name = "Column6";
            // 
            // f0074
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(544, 333);
            this.Controls.Add(this.grdFavoritos);
            this.Controls.Add(this.cf_GroupBox1);
            this.MainTabela = "menus_itens_favoritos";
            this.Name = "f0074";
            this.Text = "Itens Favoritos";
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0074_user_AfterRefreshData_1);
            this.user_AfterNew += new CompSoft.FormSet.AfterNew(this.f0074_user_AfterNew);
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFavoritos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_ComboBox cboUsuario;
        private CompSoft.cf_Bases.cf_DataGrid grdFavoritos;
        private CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}