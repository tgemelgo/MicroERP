namespace CompSoft.cf_Bases
{
    partial class cf_Periodo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTermino = new CompSoft.cf_Bases.cf_DateEdit();
            this.txtInicial = new CompSoft.cf_Bases.cf_DateEdit();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cboPeriodo = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtTermino.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTermino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInicial.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInicial.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTermino
            // 
            this.txtTermino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTermino.ControlSource = null;
            this.txtTermino.EditValue = null;
            this.txtTermino.Grupo = string.Empty;
            this.txtTermino.Location = new System.Drawing.Point(183, 29);
            this.txtTermino.MensagemObrigatorio = "Campo obrigatório";
            this.txtTermino.Name = "txtTermino";
            this.txtTermino.Obrigatorio = false;
            this.txtTermino.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTermino.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtTermino.Properties.Appearance.Options.UseBackColor = true;
            this.txtTermino.Properties.Appearance.Options.UseForeColor = true;
            this.txtTermino.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtTermino.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)))});
            this.txtTermino.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTermino.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTermino.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtTermino.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTermino.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.txtTermino.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTermino.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.txtTermino.Properties.Mask.BeepOnError = true;
            this.txtTermino.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtTermino.Properties.Mask.SaveLiteral = false;
            this.txtTermino.Properties.MaxValue = new System.DateTime(2158, 6, 30, 0, 0, 0, 0);
            this.txtTermino.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.txtTermino.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtTermino.Size = new System.Drawing.Size(79, 20);
            this.txtTermino.Tabela = null;
            this.txtTermino.Tabela_INNER = null;
            this.txtTermino.TabIndex = 7;
            this.txtTermino.ValorAnterior = null;
            this.txtTermino.EditValueChanged += new System.EventHandler(this.txtTermino_EditValueChanged);
            this.txtTermino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTermino_KeyPress);
            // 
            // txtInicial
            // 
            this.txtInicial.ControlSource = null;
            this.txtInicial.EditValue = null;
            this.txtInicial.Grupo = string.Empty;
            this.txtInicial.Location = new System.Drawing.Point(52, 29);
            this.txtInicial.MensagemObrigatorio = "Campo obrigatório";
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Obrigatorio = false;
            this.txtInicial.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtInicial.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtInicial.Properties.Appearance.Options.UseBackColor = true;
            this.txtInicial.Properties.Appearance.Options.UseForeColor = true;
            this.txtInicial.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtInicial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)))});
            this.txtInicial.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtInicial.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtInicial.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtInicial.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtInicial.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.txtInicial.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtInicial.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.txtInicial.Properties.Mask.BeepOnError = true;
            this.txtInicial.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtInicial.Properties.Mask.SaveLiteral = false;
            this.txtInicial.Properties.MaxValue = new System.DateTime(2158, 6, 30, 0, 0, 0, 0);
            this.txtInicial.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.txtInicial.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtInicial.Size = new System.Drawing.Size(79, 20);
            this.txtInicial.Tabela = null;
            this.txtInicial.Tabela_INNER = null;
            this.txtInicial.TabIndex = 6;
            this.txtInicial.ValorAnterior = null;
            this.txtInicial.EditValueChanged += new System.EventHandler(this.txtInicial_EditValueChanged);
            this.txtInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInicial_KeyPress);
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(3, 6);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(47, 13);
            this.cf_Label3.TabIndex = 5;
            this.cf_Label3.Text = "Período:";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPeriodo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboPeriodo.ControlSource = string.Empty;
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboPeriodo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodo.ForeColor = System.Drawing.Color.DimGray;
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Grupo = string.Empty;
            this.cboPeriodo.Items.AddRange(new object[] {
            "Nenhuma data",
            "Hoje",
            "Ontem",
            "Este mês",
            "Mês passado",
            "Este ano",
            "Ano passado",
            "Personalizado"});
            this.cboPeriodo.Location = new System.Drawing.Point(52, 3);
            this.cboPeriodo.MensagemObrigatorio = "Campo obrigatório";
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Obrigatorio = false;
            this.cboPeriodo.Size = new System.Drawing.Size(211, 21);
            this.cboPeriodo.SQLStatement = string.Empty;
            this.cboPeriodo.Tabela = string.Empty;
            this.cboPeriodo.Tabela_INNER = null;
            this.cboPeriodo.TabIndex = 4;
            this.cboPeriodo.ValorAnterior = string.Empty;
            this.cboPeriodo.SelectedIndexChanged += new System.EventHandler(this.cboPeriodo_SelectedIndexChanged);
            // 
            // cf_Label2
            // 
            this.cf_Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(134, 32);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(49, 13);
            this.cf_Label2.TabIndex = 3;
            this.cf_Label2.Text = "Término:";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(14, 32);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(36, 13);
            this.cf_Label1.TabIndex = 2;
            this.cf_Label1.Text = "Início:";
            // 
            // cf_Periodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTermino);
            this.Controls.Add(this.txtInicial);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cboPeriodo);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_Label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "cf_Periodo";
            this.Size = new System.Drawing.Size(264, 51);
            this.Load += new System.EventHandler(this.cf_Periodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTermino.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTermino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInicial.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInicial.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_ComboBox cboPeriodo;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private cf_DateEdit txtInicial;
        private cf_DateEdit txtTermino;
    }
}
