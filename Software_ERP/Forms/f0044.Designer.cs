namespace ERP.Forms
{
    partial class f0044
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
            this.cf_TextBox1 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox2 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox3 = new CompSoft.cf_Bases.cf_TextBox();
            this.SuspendLayout();
            // 
            // cf_TextBox1
            // 
            this.cf_TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox1.Coluna_LookUp = 0;
            this.cf_TextBox1.ControlSource = "Situacao_Tributaria_COFINS";
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = "";
            this.cf_TextBox1.Incluir_QueryBy = true;
            this.cf_TextBox1.Location = new System.Drawing.Point(79, 12);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = false;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(62, 20);
            this.cf_TextBox1.SQLStatement = "";
            this.cf_TextBox1.Tabela = "Situacoes_Tributaria_COFINS";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 1;
            this.cf_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox1.ValorAnterior = "";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(29, 14);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(44, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Código:";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(155, 14);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(67, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Sufixo NF-e:";
            // 
            // cf_TextBox2
            // 
            this.cf_TextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox2.Coluna_LookUp = 0;
            this.cf_TextBox2.ControlSource = "Sufixo_NFe";
            this.cf_TextBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox2.Grupo = "";
            this.cf_TextBox2.Incluir_QueryBy = true;
            this.cf_TextBox2.Location = new System.Drawing.Point(228, 12);
            this.cf_TextBox2.LookUp = false;
            this.cf_TextBox2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox2.Name = "cf_TextBox2";
            this.cf_TextBox2.Obrigatorio = false;
            this.cf_TextBox2.Qtde_Casas_Decimais = 0;
            this.cf_TextBox2.Size = new System.Drawing.Size(62, 20);
            this.cf_TextBox2.SQLStatement = "";
            this.cf_TextBox2.Tabela = "Situacoes_Tributaria_COFINS";
            this.cf_TextBox2.Tabela_INNER = null;
            this.cf_TextBox2.TabIndex = 3;
            this.cf_TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox2.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox2.ValorAnterior = "";
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(16, 40);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(57, 13);
            this.cf_Label3.TabIndex = 4;
            this.cf_Label3.Text = "Descrição:";
            // 
            // cf_TextBox3
            // 
            this.cf_TextBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox3.Coluna_LookUp = 0;
            this.cf_TextBox3.ControlSource = "Descricao_SitTrib_COFINS";
            this.cf_TextBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox3.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox3.Grupo = "";
            this.cf_TextBox3.Incluir_QueryBy = true;
            this.cf_TextBox3.Location = new System.Drawing.Point(79, 38);
            this.cf_TextBox3.LookUp = false;
            this.cf_TextBox3.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox3.Name = "cf_TextBox3";
            this.cf_TextBox3.Obrigatorio = false;
            this.cf_TextBox3.Qtde_Casas_Decimais = 0;
            this.cf_TextBox3.Size = new System.Drawing.Size(428, 20);
            this.cf_TextBox3.SQLStatement = "";
            this.cf_TextBox3.Tabela = "Situacoes_Tributaria_COFINS";
            this.cf_TextBox3.Tabela_INNER = null;
            this.cf_TextBox3.TabIndex = 5;
            this.cf_TextBox3.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox3.ValorAnterior = "";
            // 
            // f0044
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 65);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_TextBox3);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_TextBox2);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cf_TextBox1);
            this.MainTabela = "Situacoes_Tributaria_COFINS";
            this.Name = "f0044";
            this.Text = "Situação tributária COFINS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox2;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox3;
    }
}