namespace ERP.Forms
{
    partial class f0040
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
            this.txtClassFisc = new CompSoft.cf_Bases.cf_TextBox();
            this.txtCodClassFisc = new CompSoft.cf_Bases.cf_TextBox();
            this.txtClassFiscNF = new CompSoft.cf_Bases.cf_TextBox();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(128, 11);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(44, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Código:";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(73, 37);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(99, 13);
            this.cf_Label2.TabIndex = 1;
            this.cf_Label2.Text = "Classificação fiscal:";
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(11, 63);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(161, 13);
            this.cf_Label3.TabIndex = 2;
            this.cf_Label3.Text = "Classificação fiscal - Nota Fiscal:";
            // 
            // txtClassFisc
            // 
            this.txtClassFisc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtClassFisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassFisc.Coluna_LookUp = 0;
            this.txtClassFisc.ControlSource = "Classificacao_Fiscal";
            this.txtClassFisc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassFisc.ForeColor = System.Drawing.Color.DimGray;
            this.txtClassFisc.Grupo = string.Empty;
            this.txtClassFisc.Incluir_QueryBy = true;
            this.txtClassFisc.Location = new System.Drawing.Point(178, 8);
            this.txtClassFisc.LookUp = false;
            this.txtClassFisc.MensagemObrigatorio = "Campo obrigatório";
            this.txtClassFisc.Name = "txtClassFisc";
            this.txtClassFisc.Obrigatorio = false;
            this.txtClassFisc.Qtde_Casas_Decimais = 0;
            this.txtClassFisc.Size = new System.Drawing.Size(39, 20);
            this.txtClassFisc.SQLStatement = string.Empty;
            this.txtClassFisc.Tabela = "classificacoes_fiscais";
            this.txtClassFisc.Tabela_INNER = null;
            this.txtClassFisc.TabIndex = 3;
            this.txtClassFisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClassFisc.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtClassFisc.ValorAnterior = string.Empty;
            // 
            // txtCodClassFisc
            // 
            this.txtCodClassFisc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodClassFisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodClassFisc.Coluna_LookUp = 0;
            this.txtCodClassFisc.ControlSource = "Cod_Classificacao_Fiscal";
            this.txtCodClassFisc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodClassFisc.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodClassFisc.Grupo = string.Empty;
            this.txtCodClassFisc.Incluir_QueryBy = true;
            this.txtCodClassFisc.Location = new System.Drawing.Point(178, 34);
            this.txtCodClassFisc.LookUp = false;
            this.txtCodClassFisc.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodClassFisc.Name = "txtCodClassFisc";
            this.txtCodClassFisc.Obrigatorio = false;
            this.txtCodClassFisc.Qtde_Casas_Decimais = 0;
            this.txtCodClassFisc.Size = new System.Drawing.Size(104, 20);
            this.txtCodClassFisc.SQLStatement = string.Empty;
            this.txtCodClassFisc.Tabela = "classificacoes_fiscais";
            this.txtCodClassFisc.Tabela_INNER = null;
            this.txtCodClassFisc.TabIndex = 4;
            this.txtCodClassFisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodClassFisc.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCodClassFisc.ValorAnterior = string.Empty;
            // 
            // txtClassFiscNF
            // 
            this.txtClassFiscNF.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtClassFiscNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassFiscNF.Coluna_LookUp = 0;
            this.txtClassFiscNF.ControlSource = "Classificacao_Fiscal_Nota";
            this.txtClassFiscNF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassFiscNF.ForeColor = System.Drawing.Color.DimGray;
            this.txtClassFiscNF.Grupo = string.Empty;
            this.txtClassFiscNF.Incluir_QueryBy = true;
            this.txtClassFiscNF.Location = new System.Drawing.Point(178, 60);
            this.txtClassFiscNF.LookUp = false;
            this.txtClassFiscNF.MensagemObrigatorio = "Campo obrigatório";
            this.txtClassFiscNF.Name = "txtClassFiscNF";
            this.txtClassFiscNF.Obrigatorio = false;
            this.txtClassFiscNF.Qtde_Casas_Decimais = 0;
            this.txtClassFiscNF.Size = new System.Drawing.Size(39, 20);
            this.txtClassFiscNF.SQLStatement = string.Empty;
            this.txtClassFiscNF.Tabela = "classificacoes_fiscais";
            this.txtClassFiscNF.Tabela_INNER = null;
            this.txtClassFiscNF.TabIndex = 5;
            this.txtClassFiscNF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClassFiscNF.TipoControles = CompSoft.TipoControle.Geral;
            this.txtClassFiscNF.ValorAnterior = string.Empty;
            // 
            // f0040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 87);
            this.Controls.Add(this.txtClassFiscNF);
            this.Controls.Add(this.txtCodClassFisc);
            this.Controls.Add(this.txtClassFisc);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "classificacoes_fiscais";
            this.Name = "f0040";
            this.Text = "Classificação Fiscal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox txtClassFisc;
        private CompSoft.cf_Bases.cf_TextBox txtCodClassFisc;
        private CompSoft.cf_Bases.cf_TextBox txtClassFiscNF;
    }
}