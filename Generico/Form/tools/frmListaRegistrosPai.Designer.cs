namespace CompSoft.Tools
{
    partial class frmListaRegistrosPai
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

            f = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdLista = new CompSoft.cf_Bases.cf_DataGrid();
            this.cboColunas = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.txtValor = new CompSoft.cf_Bases.cf_TextBox();
            this.chkValorBool = new CompSoft.cf_Bases.cf_CheckBox();
            this.txtValorDateTime = new CompSoft.cf_Bases.cf_DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDateTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDateTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLista
            // 
            this.grdLista.Allow_Alter_Value_All_StatusForm = false;
            this.grdLista.AllowEditRow = false;
            this.grdLista.AllowUserToAddRows = false;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLista.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdLista.Cancel_OnClick = true;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLista.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdLista.GridColor = System.Drawing.Color.DimGray;
            this.grdLista.Location = new System.Drawing.Point(0, 33);
            this.grdLista.MultiSelect = false;
            this.grdLista.Name = "grdLista";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdLista.RowHeadersWidth = 24;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.grdLista.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdLista.RowTemplate.Height = 20;
            this.grdLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLista.ShowCellErrors = false;
            this.grdLista.ShowCellToolTips = false;
            this.grdLista.ShowEditingIcon = false;
            this.grdLista.ShowRowErrors = false;
            this.grdLista.Size = new System.Drawing.Size(632, 369);
            this.grdLista.TabIndex = 0;
            this.grdLista.TabStop = false;
            this.grdLista.VirtualMode = true;
            this.grdLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLista_CellDoubleClick);
            this.grdLista.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdLista_ColumnHeaderMouseClick);
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
            this.cboColunas.Incluir_Reg_Selecione = false;
            this.cboColunas.Location = new System.Drawing.Point(49, 6);
            this.cboColunas.MensagemObrigatorio = "Campo obrigatório";
            this.cboColunas.Name = "cboColunas";
            this.cboColunas.Obrigatorio = false;
            this.cboColunas.ReadOnly = false;
            this.cboColunas.Size = new System.Drawing.Size(197, 21);
            this.cboColunas.SQLStatement = "";
            this.cboColunas.Tabela = "";
            this.cboColunas.Tabela_INNER = null;
            this.cboColunas.TabIndex = 1;
            this.cboColunas.ValorAnterior = null;
            this.cboColunas.Value = null;
            this.cboColunas.SelectedValueChanged += new System.EventHandler(this.cboColunas_SelectedValueChanged);
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(8, 9);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(35, 13);
            this.cf_Label1.TabIndex = 2;
            this.cf_Label1.Text = "Filtro:";
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Coluna_LookUp = 0;
            this.txtValor.ControlSource = "";
            this.txtValor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.ForeColor = System.Drawing.Color.DimGray;
            this.txtValor.Grupo = "";
            this.txtValor.Incluir_QueryBy = true;
            this.txtValor.Location = new System.Drawing.Point(252, 7);
            this.txtValor.LookUp = false;
            this.txtValor.MensagemObrigatorio = "Campo obrigatório";
            this.txtValor.Name = "txtValor";
            this.txtValor.Obrigatorio = false;
            this.txtValor.Qtde_Casas_Decimais = 0;
            this.txtValor.Size = new System.Drawing.Size(368, 20);
            this.txtValor.SQLStatement = "";
            this.txtValor.Tabela = "";
            this.txtValor.Tabela_INNER = null;
            this.txtValor.TabIndex = 3;
            this.txtValor.TipoControles = CompSoft.TipoControle.Geral;
            this.txtValor.ValorAnterior = "";
            this.txtValor.Value = "";
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // chkValorBool
            // 
            this.chkValorBool.AutoSize = true;
            this.chkValorBool.ControlSource = "";
            this.chkValorBool.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkValorBool.Grupo = "";
            this.chkValorBool.Incluir_QueryBy = false;
            this.chkValorBool.Location = new System.Drawing.Point(254, 10);
            this.chkValorBool.MensagemObrigatorio = "";
            this.chkValorBool.Name = "chkValorBool";
            this.chkValorBool.Obrigatorio = false;
            this.chkValorBool.ReadOnly = false;
            this.chkValorBool.Size = new System.Drawing.Size(15, 14);
            this.chkValorBool.Tabela = "";
            this.chkValorBool.Tabela_INNER = null;
            this.chkValorBool.TabIndex = 4;
            this.chkValorBool.UseVisualStyleBackColor = true;
            this.chkValorBool.ValorAnterior = false;
            this.chkValorBool.Value = false;
            this.chkValorBool.CheckedChanged += new System.EventHandler(this.chkValorBool_CheckedChanged);
            // 
            // txtValorDateTime
            // 
            this.txtValorDateTime.ControlSource = null;
            this.txtValorDateTime.EditValue = null;
            this.txtValorDateTime.Grupo = "";
            this.txtValorDateTime.Incluir_QueryBy = true;
            this.txtValorDateTime.Location = new System.Drawing.Point(252, 7);
            this.txtValorDateTime.MensagemObrigatorio = "Campo obrigatório";
            this.txtValorDateTime.Name = "txtValorDateTime";
            this.txtValorDateTime.Obrigatorio = false;
            this.txtValorDateTime.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValorDateTime.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtValorDateTime.Properties.Appearance.Options.UseBackColor = true;
            this.txtValorDateTime.Properties.Appearance.Options.UseForeColor = true;
            this.txtValorDateTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtValorDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)), serializableAppearanceObject2, "", null, null, false)});
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
            this.txtValorDateTime.Size = new System.Drawing.Size(198, 20);
            this.txtValorDateTime.Tabela = "";
            this.txtValorDateTime.Tabela_INNER = null;
            this.txtValorDateTime.TabIndex = 5;
            this.txtValorDateTime.ValorAnterior = null;
            this.txtValorDateTime.Value = null;
            this.txtValorDateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDateTime_KeyPress);
            // 
            // frmListaRegistrosPai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 402);
            this.Controls.Add(this.chkValorBool);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cboColunas);
            this.Controls.Add(this.grdLista);
            this.Controls.Add(this.txtValorDateTime);
            this.Controls.Add(this.txtValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.KeyPreview = true;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "frmListaRegistrosPai";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de registros";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListaRegistrosPai_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListaRegistrosPai_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDateTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDateTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_DataGrid grdLista;
        private cf_Bases.cf_ComboBox cboColunas;
        private cf_Bases.cf_Label cf_Label1;
        private cf_Bases.cf_TextBox txtValor;
        private cf_Bases.cf_CheckBox chkValorBool;
        private cf_Bases.cf_DateEdit txtValorDateTime;
    }
}