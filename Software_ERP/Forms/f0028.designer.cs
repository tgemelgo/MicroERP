namespace ERP.Forms
{
    partial class f0028
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
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtDescTelefone = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.txtTipoTelefone = new CompSoft.cf_Bases.cf_TextBox();
            this.SuspendLayout();
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(12, 11);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(80, 13);
            this.cf_Label2.TabIndex = 0;
            this.cf_Label2.Text = "Código estado:";
            // 
            // txtDescTelefone
            // 
            this.txtDescTelefone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescTelefone.Coluna_LookUp = 0;
            this.txtDescTelefone.ControlSource = "Desc_Estado_Civil";
            this.txtDescTelefone.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescTelefone.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescTelefone.Grupo = string.Empty;
            this.txtDescTelefone.Incluir_QueryBy = true;
            this.txtDescTelefone.Location = new System.Drawing.Point(98, 35);
            this.txtDescTelefone.LookUp = false;
            this.txtDescTelefone.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescTelefone.Name = "txtDescTelefone";
            this.txtDescTelefone.Obrigatorio = false;
            this.txtDescTelefone.Size = new System.Drawing.Size(255, 20);
            this.txtDescTelefone.SQLStatement = string.Empty;
            this.txtDescTelefone.Tabela = "Estados_Civis";
            this.txtDescTelefone.Tabela_INNER = null;
            this.txtDescTelefone.TabIndex = 3;
            this.txtDescTelefone.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescTelefone.ValorAnterior = "cf_TextBox1";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(35, 37);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(57, 13);
            this.cf_Label1.TabIndex = 2;
            this.cf_Label1.Text = "Descrição:";
            // 
            // txtTipoTelefone
            // 
            this.txtTipoTelefone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTipoTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoTelefone.Coluna_LookUp = 0;
            this.txtTipoTelefone.ControlSource = "Estado_Civil";
            this.txtTipoTelefone.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoTelefone.ForeColor = System.Drawing.Color.DimGray;
            this.txtTipoTelefone.Grupo = string.Empty;
            this.txtTipoTelefone.Incluir_QueryBy = true;
            this.txtTipoTelefone.Location = new System.Drawing.Point(98, 9);
            this.txtTipoTelefone.LookUp = false;
            this.txtTipoTelefone.MensagemObrigatorio = "Campo obrigatório";
            this.txtTipoTelefone.Name = "txtTipoTelefone";
            this.txtTipoTelefone.Obrigatorio = false;
            this.txtTipoTelefone.Size = new System.Drawing.Size(76, 20);
            this.txtTipoTelefone.SQLStatement = string.Empty;
            this.txtTipoTelefone.Tabela = "Estados_Civis";
            this.txtTipoTelefone.Tabela_INNER = null;
            this.txtTipoTelefone.TabIndex = 1;
            this.txtTipoTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTipoTelefone.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtTipoTelefone.ValorAnterior = "cf_TextBox1";
            // 
            // f0028
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 64);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtDescTelefone);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.txtTipoTelefone);
            this.MainTabela = "Estados_Civis";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "f0028";
            this.Text = "Estado civil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtDescTelefone;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtTipoTelefone;
    }
}