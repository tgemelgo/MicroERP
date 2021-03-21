namespace ERP.Forms
{
    partial class f0010
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
            this.txtFormaPgto = new CompSoft.cf_Bases.cf_TextBox();
            this.txtDescPgto = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtNum_Parcela = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(37, 9);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(66, 13);
            this.cf_Label1.TabIndex = 1;
            this.cf_Label1.Text = "Forma Pgto:";
            // 
            // txtFormaPgto
            // 
            this.txtFormaPgto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFormaPgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFormaPgto.Coluna_LookUp = 0;
            this.txtFormaPgto.ControlSource = "Forma_Pagamento";
            this.txtFormaPgto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormaPgto.ForeColor = System.Drawing.Color.DimGray;
            this.txtFormaPgto.Grupo = string.Empty;
            this.txtFormaPgto.Incluir_QueryBy = true;
            this.txtFormaPgto.Location = new System.Drawing.Point(109, 5);
            this.txtFormaPgto.LookUp = false;
            this.txtFormaPgto.MensagemObrigatorio = "Campo obrigatório";
            this.txtFormaPgto.Name = "txtFormaPgto";
            this.txtFormaPgto.Obrigatorio = false;
            this.txtFormaPgto.Size = new System.Drawing.Size(67, 20);
            this.txtFormaPgto.SQLStatement = string.Empty;
            this.txtFormaPgto.Tabela = "Formas_Pagamentos";
            this.txtFormaPgto.Tabela_INNER = null;
            this.txtFormaPgto.TabIndex = 0;
            this.txtFormaPgto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFormaPgto.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtFormaPgto.ValorAnterior = string.Empty;
            // 
            // txtDescPgto
            // 
            this.txtDescPgto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescPgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescPgto.Coluna_LookUp = 0;
            this.txtDescPgto.ControlSource = "Desc_Forma_Pgto";
            this.txtDescPgto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescPgto.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescPgto.Grupo = string.Empty;
            this.txtDescPgto.Incluir_QueryBy = true;
            this.txtDescPgto.Location = new System.Drawing.Point(109, 28);
            this.txtDescPgto.LookUp = false;
            this.txtDescPgto.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescPgto.Name = "txtDescPgto";
            this.txtDescPgto.Obrigatorio = false;
            this.txtDescPgto.Size = new System.Drawing.Size(241, 20);
            this.txtDescPgto.SQLStatement = string.Empty;
            this.txtDescPgto.Tabela = "Formas_Pagamentos";
            this.txtDescPgto.Tabela_INNER = null;
            this.txtDescPgto.TabIndex = 3;
            this.txtDescPgto.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescPgto.ValorAnterior = string.Empty;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(46, 32);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Descrição:";
            // 
            // txtNum_Parcela
            // 
            this.txtNum_Parcela.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNum_Parcela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNum_Parcela.Coluna_LookUp = 0;
            this.txtNum_Parcela.ControlSource = "Numero_Parcelas";
            this.txtNum_Parcela.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum_Parcela.ForeColor = System.Drawing.Color.DimGray;
            this.txtNum_Parcela.Grupo = string.Empty;
            this.txtNum_Parcela.Incluir_QueryBy = true;
            this.txtNum_Parcela.Location = new System.Drawing.Point(109, 51);
            this.txtNum_Parcela.LookUp = false;
            this.txtNum_Parcela.MensagemObrigatorio = "Campo obrigatório";
            this.txtNum_Parcela.Name = "txtNum_Parcela";
            this.txtNum_Parcela.Obrigatorio = false;
            this.txtNum_Parcela.Size = new System.Drawing.Size(67, 20);
            this.txtNum_Parcela.SQLStatement = string.Empty;
            this.txtNum_Parcela.Tabela = "Formas_Pagamentos";
            this.txtNum_Parcela.Tabela_INNER = null;
            this.txtNum_Parcela.TabIndex = 5;
            this.txtNum_Parcela.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtNum_Parcela.ValorAnterior = string.Empty;
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(12, 55);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(91, 13);
            this.cf_Label3.TabIndex = 4;
            this.cf_Label3.Text = "Número parcelas:";
            // 
            // f0010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 77);
            this.Controls.Add(this.txtNum_Parcela);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.txtDescPgto);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtFormaPgto);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "Formas_Pagamentos";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "f0010";
            this.Text = "Formas de pagamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtFormaPgto;
        private CompSoft.cf_Bases.cf_TextBox txtDescPgto;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtNum_Parcela;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
    }
}