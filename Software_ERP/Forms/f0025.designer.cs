namespace ERP.Forms
{
    partial class f0025
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
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.pageDadoPadrao = new System.Windows.Forms.TabPage();
            this.cboTipoMovimento = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.cf_ComboBox1 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_DateEdit2 = new CompSoft.cf_Bases.cf_DateEdit();
            this.cf_DateEdit1 = new CompSoft.cf_Bases.cf_DateEdit();
            this.pgfTrabalho.SuspendLayout();
            this.tabFiltros.SuspendLayout();
            this.pageDadoPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pgfTrabalho
            // 
            this.pgfTrabalho.Controls.Add(this.pageDadoPadrao);
            this.pgfTrabalho.Controls.SetChildIndex(this.pageDadoPadrao, 0);
            this.pgfTrabalho.Controls.SetChildIndex(this.tabFiltros, 0);
            // 
            // tabFiltros
            // 
            this.tabFiltros.Controls.Add(this.cf_ComboBox1);
            this.tabFiltros.Controls.Add(this.cf_DateEdit2);
            this.tabFiltros.Controls.Add(this.cf_DateEdit1);
            this.tabFiltros.Controls.Add(this.cf_Label3);
            this.tabFiltros.Controls.Add(this.cf_Label2);
            this.tabFiltros.Controls.Add(this.cf_Label1);
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(5, 9);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(92, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Data vencimento:";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(22, 35);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(75, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Data emissão:";
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(45, 61);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(52, 13);
            this.cf_Label3.TabIndex = 4;
            this.cf_Label3.Text = "Empresa:";
            // 
            // pageDadoPadrao
            // 
            this.pageDadoPadrao.Controls.Add(this.cboTipoMovimento);
            this.pageDadoPadrao.Controls.Add(this.cf_Label4);
            this.pageDadoPadrao.Location = new System.Drawing.Point(4, 22);
            this.pageDadoPadrao.Name = "pageDadoPadrao";
            this.pageDadoPadrao.Padding = new System.Windows.Forms.Padding(3);
            this.pageDadoPadrao.Size = new System.Drawing.Size(480, 212);
            this.pageDadoPadrao.TabIndex = 1;
            this.pageDadoPadrao.Text = "Valor padrão";
            this.pageDadoPadrao.UseVisualStyleBackColor = true;
            // 
            // cboTipoMovimento
            // 
            this.cboTipoMovimento.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboTipoMovimento.ControlSource = "";
            this.cboTipoMovimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovimento.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTipoMovimento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoMovimento.ForeColor = System.Drawing.Color.DimGray;
            this.cboTipoMovimento.FormattingEnabled = true;
            this.cboTipoMovimento.Grupo = "";
            this.cboTipoMovimento.Incluir_QueryBy = true;
            this.cboTipoMovimento.Location = new System.Drawing.Point(118, 42);
            this.cboTipoMovimento.MensagemObrigatorio = "Campo obrigatório";
            this.cboTipoMovimento.Name = "cboTipoMovimento";
            this.cboTipoMovimento.Obrigatorio = false;
            this.cboTipoMovimento.ReadOnly = false;
            this.cboTipoMovimento.Size = new System.Drawing.Size(246, 21);
            this.cboTipoMovimento.SQLStatement = "select Tipo_Movimento, Desc_Tipo_Movimento from tipos_movimentos where inativo = " +
                "0 order by Desc_Tipo_Movimento";
            this.cboTipoMovimento.Tabela = "";
            this.cboTipoMovimento.Tabela_INNER = null;
            this.cboTipoMovimento.TabIndex = 1;
            this.cboTipoMovimento.ValorAnterior = "";
            this.cboTipoMovimento.Value = null;
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(11, 46);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(101, 13);
            this.cf_Label4.TabIndex = 0;
            this.cf_Label4.Text = "Tipo de movimento:";
            // 
            // cf_ComboBox1
            // 
            this.cf_ComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox1.ControlSource = "empresa";
            this.cf_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox1.FormattingEnabled = true;
            this.cf_ComboBox1.Grupo = "";
            this.cf_ComboBox1.Incluir_QueryBy = true;
            this.cf_ComboBox1.Location = new System.Drawing.Point(103, 58);
            this.cf_ComboBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox1.Name = "cf_ComboBox1";
            this.cf_ComboBox1.Obrigatorio = false;
            this.cf_ComboBox1.ReadOnly = false;
            this.cf_ComboBox1.Size = new System.Drawing.Size(346, 21);
            this.cf_ComboBox1.SQLStatement = "select empresa, Nome_Fantasia from empresas order by Nome_Fantasia";
            this.cf_ComboBox1.Tabela = "xresultado";
            this.cf_ComboBox1.Tabela_INNER = "vw_Contas_Pagar_Abertas";
            this.cf_ComboBox1.TabIndex = 5;
            this.cf_ComboBox1.ValorAnterior = null;
            this.cf_ComboBox1.Value = null;
            // 
            // cf_DateEdit2
            // 
            this.cf_DateEdit2.ControlSource = "Data_Emissao";
            this.cf_DateEdit2.EditValue = null;
            this.cf_DateEdit2.Grupo = "";
            this.cf_DateEdit2.Incluir_QueryBy = true;
            this.cf_DateEdit2.Location = new System.Drawing.Point(103, 32);
            this.cf_DateEdit2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_DateEdit2.Name = "cf_DateEdit2";
            this.cf_DateEdit2.Obrigatorio = false;
            this.cf_DateEdit2.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_DateEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.cf_DateEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.cf_DateEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.cf_DateEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cf_DateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)))});
            this.cf_DateEdit2.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.cf_DateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cf_DateEdit2.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.cf_DateEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cf_DateEdit2.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.cf_DateEdit2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cf_DateEdit2.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.cf_DateEdit2.Properties.Mask.BeepOnError = true;
            this.cf_DateEdit2.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.cf_DateEdit2.Properties.Mask.SaveLiteral = false;
            this.cf_DateEdit2.Properties.MaxValue = new System.DateTime(2159, 10, 31, 0, 0, 0, 0);
            this.cf_DateEdit2.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.cf_DateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cf_DateEdit2.ReadOnly = false;
            this.cf_DateEdit2.Size = new System.Drawing.Size(100, 20);
            this.cf_DateEdit2.Tabela = "xresultado";
            this.cf_DateEdit2.Tabela_INNER = "vw_Contas_Pagar_Abertas";
            this.cf_DateEdit2.TabIndex = 3;
            this.cf_DateEdit2.ValorAnterior = null;
            this.cf_DateEdit2.Value = null;
            // 
            // cf_DateEdit1
            // 
            this.cf_DateEdit1.ControlSource = "Data_Vencimento";
            this.cf_DateEdit1.EditValue = null;
            this.cf_DateEdit1.Grupo = "";
            this.cf_DateEdit1.Incluir_QueryBy = true;
            this.cf_DateEdit1.Location = new System.Drawing.Point(103, 6);
            this.cf_DateEdit1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_DateEdit1.Name = "cf_DateEdit1";
            this.cf_DateEdit1.Obrigatorio = false;
            this.cf_DateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_DateEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.cf_DateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.cf_DateEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.cf_DateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cf_DateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)))});
            this.cf_DateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.cf_DateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cf_DateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.cf_DateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cf_DateEdit1.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.cf_DateEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cf_DateEdit1.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.cf_DateEdit1.Properties.Mask.BeepOnError = true;
            this.cf_DateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.cf_DateEdit1.Properties.Mask.SaveLiteral = false;
            this.cf_DateEdit1.Properties.MaxValue = new System.DateTime(2159, 10, 31, 0, 0, 0, 0);
            this.cf_DateEdit1.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.cf_DateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cf_DateEdit1.ReadOnly = false;
            this.cf_DateEdit1.Size = new System.Drawing.Size(100, 20);
            this.cf_DateEdit1.Tabela = "xresultado";
            this.cf_DateEdit1.Tabela_INNER = "vw_Contas_Pagar_Abertas";
            this.cf_DateEdit1.TabIndex = 1;
            this.cf_DateEdit1.ValorAnterior = null;
            this.cf_DateEdit1.Value = null;
            // 
            // f0025
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 250);
            this.Name = "f0025";
            this.Load += new System.EventHandler(this.f0025_Load);
            this.pgfTrabalho.ResumeLayout(false);
            this.tabFiltros.ResumeLayout(false);
            this.tabFiltros.PerformLayout();
            this.pageDadoPadrao.ResumeLayout(false);
            this.pageDadoPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private System.Windows.Forms.TabPage pageDadoPadrao;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        public CompSoft.cf_Bases.cf_ComboBox cboTipoMovimento;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox1;
        private CompSoft.cf_Bases.cf_DateEdit cf_DateEdit2;
        private CompSoft.cf_Bases.cf_DateEdit cf_DateEdit1;


    }
}