namespace ERP.Forms
{
    partial class f0012
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
            this.txtTipo_Produto = new CompSoft.cf_Bases.cf_TextBox();
            this.txtDescProduto = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(8, 12);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(72, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Tipo produto:";
            // 
            // txtTipo_Produto
            // 
            this.txtTipo_Produto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTipo_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipo_Produto.Coluna_LookUp = 0;
            this.txtTipo_Produto.ControlSource = "Tipo_Produto_Fornece";
            this.txtTipo_Produto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo_Produto.ForeColor = System.Drawing.Color.DimGray;
            this.txtTipo_Produto.Grupo = string.Empty;
            this.txtTipo_Produto.Incluir_QueryBy = true;
            this.txtTipo_Produto.Location = new System.Drawing.Point(86, 8);
            this.txtTipo_Produto.LookUp = false;
            this.txtTipo_Produto.MensagemObrigatorio = "Campo obrigatório";
            this.txtTipo_Produto.Name = "txtTipo_Produto";
            this.txtTipo_Produto.Obrigatorio = false;
            this.txtTipo_Produto.Size = new System.Drawing.Size(62, 20);
            this.txtTipo_Produto.SQLStatement = string.Empty;
            this.txtTipo_Produto.Tabela = "Tipos_Produtos_Fornece";
            this.txtTipo_Produto.Tabela_INNER = null;
            this.txtTipo_Produto.TabIndex = 1;
            this.txtTipo_Produto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTipo_Produto.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtTipo_Produto.ValorAnterior = string.Empty;
            // 
            // txtDescProduto
            // 
            this.txtDescProduto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescProduto.Coluna_LookUp = 0;
            this.txtDescProduto.ControlSource = "Desc_Tipo_Produto";
            this.txtDescProduto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescProduto.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescProduto.Grupo = string.Empty;
            this.txtDescProduto.Incluir_QueryBy = true;
            this.txtDescProduto.Location = new System.Drawing.Point(86, 32);
            this.txtDescProduto.LookUp = false;
            this.txtDescProduto.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescProduto.Name = "txtDescProduto";
            this.txtDescProduto.Obrigatorio = false;
            this.txtDescProduto.Size = new System.Drawing.Size(315, 20);
            this.txtDescProduto.SQLStatement = string.Empty;
            this.txtDescProduto.Tabela = "Tipos_Produtos_Fornece";
            this.txtDescProduto.Tabela_INNER = null;
            this.txtDescProduto.TabIndex = 3;
            this.txtDescProduto.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescProduto.ValorAnterior = string.Empty;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(23, 36);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Descrição:";
            // 
            // f0012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 58);
            this.Controls.Add(this.txtDescProduto);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtTipo_Produto);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "Tipos_Produtos_Fornece";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "f0012";
            this.Text = "Tipos de produtos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtTipo_Produto;
        private CompSoft.cf_Bases.cf_TextBox txtDescProduto;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
    }
}