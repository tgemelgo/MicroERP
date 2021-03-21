namespace ERP.Forms
{
    partial class f0073
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
            this.cmdEnviarXMLEmail = new CompSoft.cf_Bases.cf_Button();
            this.cf_Label12 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox1 = new CompSoft.cf_Bases.cf_TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArquivo
            // 
            this.txtArquivo.ReadOnly = true;
            // 
            // cf_DateEdit1
            // 
            this.cf_DateEdit1.ControlSource = "nfe_protocolo_data";
            this.cf_DateEdit1.EditValue = null;
            this.cf_DateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_DateEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.cf_DateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.cf_DateEdit1.Properties.Appearance.Options.UseForeColor = true;
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
            this.cf_DateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // cmdEnviarXMLEmail
            // 
            this.cmdEnviarXMLEmail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnviarXMLEmail.ForeColor = System.Drawing.Color.Black;
            this.cmdEnviarXMLEmail.Grupo = "";
            this.cmdEnviarXMLEmail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdEnviarXMLEmail.Location = new System.Drawing.Point(656, 129);
            this.cmdEnviarXMLEmail.Name = "cmdEnviarXMLEmail";
            this.cmdEnviarXMLEmail.ReadOnly = false;
            this.cmdEnviarXMLEmail.Size = new System.Drawing.Size(117, 23);
            this.cmdEnviarXMLEmail.TabIndex = 33;
            this.cmdEnviarXMLEmail.TabStop = false;
            this.cmdEnviarXMLEmail.Text = "Enviar XML E-Mail";
            this.cmdEnviarXMLEmail.UseVisualStyleBackColor = true;
            this.cmdEnviarXMLEmail.Click += new System.EventHandler(this.cmdEnviarXMLEmail_Click);
            // 
            // cf_Label12
            // 
            this.cf_Label12.AutoSize = true;
            this.cf_Label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label12.Location = new System.Drawing.Point(218, 93);
            this.cf_Label12.Name = "cf_Label12";
            this.cf_Label12.Size = new System.Drawing.Size(119, 13);
            this.cf_Label12.TabIndex = 34;
            this.cf_Label12.Text = "Nº Autorização de Uso:";
            // 
            // cf_TextBox1
            // 
            this.cf_TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox1.Coluna_LookUp = 0;
            this.cf_TextBox1.ControlSource = "nfe_protocolo";
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = "";
            this.cf_TextBox1.Incluir_QueryBy = true;
            this.cf_TextBox1.Location = new System.Drawing.Point(343, 90);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = false;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(124, 20);
            this.cf_TextBox1.SQLStatement = "";
            this.cf_TextBox1.Tabela = "notas_fiscais_lotes";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 35;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox1.ValorAnterior = "";
            this.cf_TextBox1.Value = "";
            // 
            // f0073
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 495);
            this.Controls.Add(this.cf_Label12);
            this.Controls.Add(this.cf_TextBox1);
            this.Controls.Add(this.cmdEnviarXMLEmail);
            this.Name = "f0073";
            this.Text = "Consulta de lotes enviados NF-e";
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0073_user_AfterRefreshData);
            this.Controls.SetChildIndex(this.cf_DateEdit1, 0);
            this.Controls.SetChildIndex(this.txtLote, 0);
            this.Controls.SetChildIndex(this.txtArquivo, 0);
            this.Controls.SetChildIndex(this.cboCodMensagem_NFe, 0);
            this.Controls.SetChildIndex(this.cmdEnviarXMLEmail, 0);
            this.Controls.SetChildIndex(this.cf_TextBox1, 0);
            this.Controls.SetChildIndex(this.cf_Label12, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Button cmdEnviarXMLEmail;
        private CompSoft.cf_Bases.cf_Label cf_Label12;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
    }
}