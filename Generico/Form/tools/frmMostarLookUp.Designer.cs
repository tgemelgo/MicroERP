
namespace CompSoft.Tools
{
 partial class frmMostarLookUp
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdLookup = new CompSoft.cf_Bases.cf_DataGrid();
            this.txtValorDateTime = new CompSoft.cf_Bases.cf_DateEdit();
            this.chkValorBool = new CompSoft.cf_Bases.cf_CheckBox();
            this.txtValor = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cboColunas = new CompSoft.cf_Bases.cf_ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDateTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDateTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLookup
            // 
            this.grdLookup.Allow_Alter_Value_All_StatusForm = false;
            this.grdLookup.AllowEditRow = false;
            this.grdLookup.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.grdLookup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLookup.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdLookup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdLookup.Cancel_OnClick = true;
            this.grdLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLookup.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdLookup.GridColor = System.Drawing.Color.DimGray;
            this.grdLookup.Location = new System.Drawing.Point(0, 33);
            this.grdLookup.MultiSelect = false;
            this.grdLookup.Name = "grdLookup";
            this.grdLookup.RowHeadersWidth = 24;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.grdLookup.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdLookup.RowTemplate.Height = 20;
            this.grdLookup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdLookup.ShowCellErrors = false;
            this.grdLookup.ShowCellToolTips = false;
            this.grdLookup.ShowRowErrors = false;
            this.grdLookup.Size = new System.Drawing.Size(538, 358);
            this.grdLookup.TabIndex = 0;
            this.grdLookup.TabStop = false;
            this.grdLookup.VirtualMode = true;
            this.grdLookup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLookup_CellDoubleClick);
            this.grdLookup.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdLista_ColumnHeaderMouseClick);
            // 
            // txtValorDateTime
            // 
            this.txtValorDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorDateTime.ControlSource = null;
            this.txtValorDateTime.EditValue = null;
            this.txtValorDateTime.Grupo = "";
            this.txtValorDateTime.Incluir_QueryBy = true;
            this.txtValorDateTime.Location = new System.Drawing.Point(248, 6);
            this.txtValorDateTime.MensagemObrigatorio = "Campo obrigatório";
            this.txtValorDateTime.Name = "txtValorDateTime";
            this.txtValorDateTime.Obrigatorio = false;
            this.txtValorDateTime.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValorDateTime.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtValorDateTime.Properties.Appearance.Options.UseBackColor = true;
            this.txtValorDateTime.Properties.Appearance.Options.UseForeColor = true;
            this.txtValorDateTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtValorDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)), serializableAppearanceObject1, "", null, null, false)});
            this.txtValorDateTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtValorDateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtValorDateTime.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtValorDateTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtValorDateTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtValorDateTime.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.txtValorDateTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtValorDateTime.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.txtValorDateTime.Properties.Mask.BeepOnError = true;
            this.txtValorDateTime.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtValorDateTime.Properties.Mask.SaveLiteral = false;
            this.txtValorDateTime.Properties.MaxValue = new System.DateTime(2160, 6, 30, 0, 0, 0, 0);
            this.txtValorDateTime.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.txtValorDateTime.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.txtValorDateTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtValorDateTime.ReadOnly = false;
            this.txtValorDateTime.Size = new System.Drawing.Size(178, 20);
            this.txtValorDateTime.Tabela = "";
            this.txtValorDateTime.Tabela_INNER = null;
            this.txtValorDateTime.TabIndex = 10;
            this.txtValorDateTime.ValorAnterior = null;
            this.txtValorDateTime.Value = null;
            this.txtValorDateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDateTime_KeyPress);
            // 
            // chkValorBool
            // 
            this.chkValorBool.AutoSize = true;
            this.chkValorBool.ControlSource = "";
            this.chkValorBool.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkValorBool.Grupo = "";
            this.chkValorBool.Incluir_QueryBy = false;
            this.chkValorBool.Location = new System.Drawing.Point(248, 8);
            this.chkValorBool.MensagemObrigatorio = "";
            this.chkValorBool.Name = "chkValorBool";
            this.chkValorBool.Obrigatorio = false;
            this.chkValorBool.ReadOnly = false;
            this.chkValorBool.Size = new System.Drawing.Size(15, 14);
            this.chkValorBool.Tabela = "";
            this.chkValorBool.Tabela_INNER = null;
            this.chkValorBool.TabIndex = 9;
            this.chkValorBool.UseVisualStyleBackColor = true;
            this.chkValorBool.ValorAnterior = false;
            this.chkValorBool.Value = false;
            this.chkValorBool.CheckedChanged += new System.EventHandler(this.chkValorBool_CheckedChanged);
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Coluna_LookUp = 0;
            this.txtValor.ControlSource = "";
            this.txtValor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.ForeColor = System.Drawing.Color.DimGray;
            this.txtValor.Grupo = "";
            this.txtValor.Incluir_QueryBy = true;
            this.txtValor.Location = new System.Drawing.Point(248, 7);
            this.txtValor.LookUp = false;
            this.txtValor.MensagemObrigatorio = "Campo obrigatório";
            this.txtValor.Name = "txtValor";
            this.txtValor.Obrigatorio = false;
            this.txtValor.Qtde_Casas_Decimais = 0;
            this.txtValor.Size = new System.Drawing.Size(290, 20);
            this.txtValor.SQLStatement = "";
            this.txtValor.Tabela = "";
            this.txtValor.Tabela_INNER = null;
            this.txtValor.TabIndex = 8;
            this.txtValor.TipoControles = CompSoft.TipoControle.Geral;
            this.txtValor.ValorAnterior = "";
            this.txtValor.Value = "";
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(4, 9);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(35, 13);
            this.cf_Label1.TabIndex = 7;
            this.cf_Label1.Text = "Filtro:";
            // 
            // cboColunas
            // 
            this.cboColunas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboColunas.ControlSource = "";
            this.cboColunas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColunas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboColunas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColunas.ForeColor = System.Drawing.Color.DimGray;
            this.cboColunas.FormattingEnabled = true;
            this.cboColunas.Grupo = "";
            this.cboColunas.Incluir_QueryBy = true;
            this.cboColunas.Location = new System.Drawing.Point(45, 6);
            this.cboColunas.MensagemObrigatorio = "Campo obrigatório";
            this.cboColunas.Name = "cboColunas";
            this.cboColunas.Obrigatorio = false;
            this.cboColunas.ReadOnly = false;
            this.cboColunas.Size = new System.Drawing.Size(197, 21);
            this.cboColunas.SQLStatement = "";
            this.cboColunas.Tabela = "";
            this.cboColunas.Tabela_INNER = null;
            this.cboColunas.TabIndex = 6;
            this.cboColunas.ValorAnterior = null;
            this.cboColunas.Value = null;
            this.cboColunas.SelectedValueChanged += new System.EventHandler(this.cboColunas_SelectedValueChanged);
            // 
            // frmMostarLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(538, 391);
            this.Controls.Add(this.txtValorDateTime);
            this.Controls.Add(this.chkValorBool);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cboColunas);
            this.Controls.Add(this.grdLookup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.KeyPreview = true;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "frmMostarLookUp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lookup";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMostarLookUp_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDateTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDateTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CompSoft.cf_Bases.cf_DataGrid grdLookup;
        private cf_Bases.cf_DateEdit txtValorDateTime;
        private cf_Bases.cf_CheckBox chkValorBool;
        private cf_Bases.cf_TextBox txtValor;
        private cf_Bases.cf_Label cf_Label1;
        private cf_Bases.cf_ComboBox cboColunas;
 }
}
