
namespace ERP.Forms
{
 partial class f0004
 {
  /// <summary>
  /// Designer variable used to keep track of non-visual components.
  /// </summary>
  private System.ComponentModel.IContainer components = null;
  
  /// <summary>
  /// Disposes resources used by the form.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing)
  {
   if (disposing) {
    if (components != null) {
     components.Dispose();
    }
   }
   base.Dispose(disposing);
  }
  
  /// <summary>
  /// This method is required for Windows Forms designer support.
  /// Do not change the method contents inside the source code editor. The Forms designer might
  /// not be able to load this method if it was changed manually.
  /// </summary>
  private void InitializeComponent()
  {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkAtivo = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.lstMenus = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column3 = new CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.txtDesc_Modulo = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.txtModulo = new CompSoft.cf_Bases.cf_TextBox();
            this.acModulos_itens = new CompSoft.cf_Bases.cf_AcaoGrid();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdLocalizar = new CompSoft.cf_Bases.cf_Button();
            ((System.ComponentModel.ISupportInitialize)(this.lstMenus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.ControlSource = "Ativo";
            this.chkAtivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAtivo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivo.Grupo = "";
            this.chkAtivo.Incluir_QueryBy = false;
            this.chkAtivo.Location = new System.Drawing.Point(315, 10);
            this.chkAtivo.MensagemObrigatorio = "";
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Obrigatorio = false;
            this.chkAtivo.ReadOnly = false;
            this.chkAtivo.Size = new System.Drawing.Size(49, 17);
            this.chkAtivo.Tabela = "modulos";
            this.chkAtivo.Tabela_INNER = null;
            this.chkAtivo.TabIndex = 2;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            this.chkAtivo.ValorAnterior = false;
            this.chkAtivo.Value = false;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(26, 56);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(49, 13);
            this.cf_Label2.TabIndex = 5;
            this.cf_Label2.Text = "Imagem:";
            // 
            // lstMenus
            // 
            this.lstMenus.Allow_Alter_Value_All_StatusForm = false;
            this.lstMenus.AllowEditRow = true;
            this.lstMenus.AllowUserToAddRows = false;
            this.lstMenus.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.lstMenus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.lstMenus.BackgroundColor = System.Drawing.Color.Gray;
            this.lstMenus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMenus.Cancel_OnClick = true;
            this.lstMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstMenus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1});
            this.lstMenus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lstMenus.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lstMenus.GridColor = System.Drawing.Color.DimGray;
            this.lstMenus.Location = new System.Drawing.Point(33, 117);
            this.lstMenus.MultiSelect = false;
            this.lstMenus.Name = "lstMenus";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstMenus.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.lstMenus.RowHeadersWidth = 15;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.lstMenus.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.lstMenus.RowTemplate.Height = 20;
            this.lstMenus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstMenus.ShowCellErrors = false;
            this.lstMenus.ShowCellToolTips = false;
            this.lstMenus.ShowEditingIcon = false;
            this.lstMenus.ShowRowErrors = false;
            this.lstMenus.Size = new System.Drawing.Size(331, 197);
            this.lstMenus.TabIndex = 7;
            this.lstMenus.TabStop = false;
            this.lstMenus.VirtualMode = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Menu_Item";
            this.Column3.HeaderText = "Menu Item";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Retorno_Lookup = null;
            this.Column3.ReturnColumn = "Menu_Item";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.SQLStatement = "select Menu_Item, Descricao as \'Descricao_Menu\', NameSpace, Formulario from menus" +
                "_itens where Menu_Item@";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Descricao_Menu";
            this.Column1.HeaderText = "Descrição menu";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(4, 33);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(71, 13);
            this.cf_Label1.TabIndex = 3;
            this.cf_Label1.Text = "Desc Modulo:";
            // 
            // txtDesc_Modulo
            // 
            this.txtDesc_Modulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDesc_Modulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc_Modulo.Coluna_LookUp = 0;
            this.txtDesc_Modulo.ControlSource = "Descricao_Modulo";
            this.txtDesc_Modulo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc_Modulo.ForeColor = System.Drawing.Color.DimGray;
            this.txtDesc_Modulo.Grupo = "";
            this.txtDesc_Modulo.Incluir_QueryBy = true;
            this.txtDesc_Modulo.Location = new System.Drawing.Point(81, 30);
            this.txtDesc_Modulo.LookUp = false;
            this.txtDesc_Modulo.MensagemObrigatorio = "O nome do módulo é obrigatório";
            this.txtDesc_Modulo.Name = "txtDesc_Modulo";
            this.txtDesc_Modulo.Obrigatorio = true;
            this.txtDesc_Modulo.Qtde_Casas_Decimais = 0;
            this.txtDesc_Modulo.Size = new System.Drawing.Size(283, 20);
            this.txtDesc_Modulo.SQLStatement = "";
            this.txtDesc_Modulo.Tabela = "modulos";
            this.txtDesc_Modulo.Tabela_INNER = null;
            this.txtDesc_Modulo.TabIndex = 4;
            this.txtDesc_Modulo.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDesc_Modulo.ValorAnterior = "";
            this.txtDesc_Modulo.Value = "";
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(30, 10);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(45, 13);
            this.cf_Label4.TabIndex = 0;
            this.cf_Label4.Text = "Módulo:";
            // 
            // txtModulo
            // 
            this.txtModulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModulo.Coluna_LookUp = 0;
            this.txtModulo.ControlSource = "Modulo";
            this.txtModulo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModulo.ForeColor = System.Drawing.Color.DimGray;
            this.txtModulo.Grupo = "";
            this.txtModulo.Incluir_QueryBy = true;
            this.txtModulo.Location = new System.Drawing.Point(81, 7);
            this.txtModulo.LookUp = false;
            this.txtModulo.MensagemObrigatorio = "O nome do módulo é obrigatório";
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Obrigatorio = true;
            this.txtModulo.Qtde_Casas_Decimais = 0;
            this.txtModulo.Size = new System.Drawing.Size(82, 20);
            this.txtModulo.SQLStatement = "";
            this.txtModulo.Tabela = "modulos";
            this.txtModulo.Tabela_INNER = null;
            this.txtModulo.TabIndex = 1;
            this.txtModulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtModulo.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtModulo.ValorAnterior = "";
            this.txtModulo.Value = "";
            // 
            // acModulos_itens
            // 
            this.acModulos_itens.BackColor = System.Drawing.Color.Transparent;
            this.acModulos_itens.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acModulos_itens.Location = new System.Drawing.Point(3, 140);
            this.acModulos_itens.Name = "acModulos_itens";
            this.acModulos_itens.Permitir_Alteracao = true;
            this.acModulos_itens.Permitir_Exclusao = true;
            this.acModulos_itens.Permitir_Inclusao = true;
            this.acModulos_itens.Size = new System.Drawing.Size(23, 47);
            this.acModulos_itens.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(81, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // cmdLocalizar
            // 
            this.cmdLocalizar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocalizar.ForeColor = System.Drawing.Color.Black;
            this.cmdLocalizar.Grupo = "";
            this.cmdLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLocalizar.Location = new System.Drawing.Point(150, 88);
            this.cmdLocalizar.Name = "cmdLocalizar";
            this.cmdLocalizar.Size = new System.Drawing.Size(58, 23);
            this.cmdLocalizar.TabIndex = 12;
            this.cmdLocalizar.TabStop = false;
            this.cmdLocalizar.Text = "Localizar";
            this.cmdLocalizar.UseVisualStyleBackColor = true;
            this.cmdLocalizar.Click += new System.EventHandler(this.cmdLocalizar_Click);
            // 
            // f0004
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 322);
            this.Controls.Add(this.cmdLocalizar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.acModulos_itens);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.txtModulo);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.lstMenus);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.txtDesc_Modulo);
            this.MainTabela = "modulos";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "f0004";
            this.Text = "Cadastro de módulos";
            this.Load += new System.EventHandler(this.f0004_Load);
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.FrmCadModulosuser_AfterRefreshData);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.frmCadModulos_user_FormStatus_Change);
            this.user_AfterNew += new CompSoft.FormSet.AfterNew(this.f0004_user_AfterNew);
            ((System.ComponentModel.ISupportInitialize)(this.lstMenus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

  }
  private CompSoft.cf_Bases.cf_TextBox txtDesc_Modulo;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_DataGrid lstMenus;
  private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivo;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_TextBox txtModulo;
        private CompSoft.cf_Bases.cf_AcaoGrid acModulos_itens;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CompSoft.cf_Bases.cf_Button cmdLocalizar;
        private CompSoft.cf_Bases.cf_DataGridView.cf_DataGridViewLookupColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
 }
}
