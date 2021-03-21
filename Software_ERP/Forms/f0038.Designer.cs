namespace ERP.Forms
{
    partial class f0038
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
            this.lblProduto = new CompSoft.cf_Bases.cf_Label();
            this.lblCodProduto = new System.Windows.Forms.Label();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.txtDesconto_Valor = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtDesconto_Porcent = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.txtComissao_Valor = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.txtComissao_Porcent = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.txtQtde = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label5 = new CompSoft.cf_Bases.cf_Label();
            this.cmdCancelar = new CompSoft.cf_Bases.cf_Button();
            this.cmdConfirmar = new CompSoft.cf_Bases.cf_Button();
            this.txtValorUnitario = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label6 = new CompSoft.cf_Bases.cf_Label();
            this.cf_GroupBox1.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.ForeColor = System.Drawing.Color.Indigo;
            this.lblProduto.Location = new System.Drawing.Point(68, 9);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(147, 16);
            this.lblProduto.TabIndex = 1;
            this.lblProduto.Text = "Descrição do produto";
            // 
            // lblCodProduto
            // 
            this.lblCodProduto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProduto.ForeColor = System.Drawing.Color.Indigo;
            this.lblCodProduto.Location = new System.Drawing.Point(8, 9);
            this.lblCodProduto.Name = "lblCodProduto";
            this.lblCodProduto.Size = new System.Drawing.Size(54, 16);
            this.lblCodProduto.TabIndex = 0;
            this.lblCodProduto.Text = "CodProd";
            this.lblCodProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.txtDesconto_Valor);
            this.cf_GroupBox1.Controls.Add(this.cf_Label2);
            this.cf_GroupBox1.Controls.Add(this.txtDesconto_Porcent);
            this.cf_GroupBox1.Controls.Add(this.cf_Label1);
            this.cf_GroupBox1.ControlSource = string.Empty;
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(8, 64);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(204, 78);
            this.cf_GroupBox1.Tabela = string.Empty;
            this.cf_GroupBox1.TabIndex = 7;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Desconto";
            this.cf_GroupBox1.Value = string.Empty;
            // 
            // txtDesconto_Valor
            // 
            this.txtDesconto_Valor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDesconto_Valor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesconto_Valor.Coluna_LookUp = 0;
            this.txtDesconto_Valor.ControlSource = string.Empty;
            this.txtDesconto_Valor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto_Valor.ForeColor = System.Drawing.Color.DimGray;
            this.txtDesconto_Valor.Grupo = string.Empty;
            this.txtDesconto_Valor.Incluir_QueryBy = true;
            this.txtDesconto_Valor.Location = new System.Drawing.Point(85, 46);
            this.txtDesconto_Valor.LookUp = false;
            this.txtDesconto_Valor.MaxLength = 10;
            this.txtDesconto_Valor.MensagemObrigatorio = "Campo obrigatório";
            this.txtDesconto_Valor.Name = "txtDesconto_Valor";
            this.txtDesconto_Valor.Obrigatorio = false;
            this.txtDesconto_Valor.Qtde_Casas_Decimais = 0;
            this.txtDesconto_Valor.Size = new System.Drawing.Size(110, 20);
            this.txtDesconto_Valor.SQLStatement = string.Empty;
            this.txtDesconto_Valor.Tabela = null;
            this.txtDesconto_Valor.Tabela_INNER = null;
            this.txtDesconto_Valor.TabIndex = 3;
            this.txtDesconto_Valor.Text = null;
            this.txtDesconto_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDesconto_Valor.TipoControles = CompSoft.TipoControle.Moeda;
            this.txtDesconto_Valor.ValorAnterior = string.Empty;
            this.txtDesconto_Valor.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesconto_Valor_Validating);
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(44, 49);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(35, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Valor:";
            // 
            // txtDesconto_Porcent
            // 
            this.txtDesconto_Porcent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDesconto_Porcent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesconto_Porcent.Coluna_LookUp = 0;
            this.txtDesconto_Porcent.ControlSource = string.Empty;
            this.txtDesconto_Porcent.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto_Porcent.ForeColor = System.Drawing.Color.DimGray;
            this.txtDesconto_Porcent.Grupo = string.Empty;
            this.txtDesconto_Porcent.Incluir_QueryBy = true;
            this.txtDesconto_Porcent.Location = new System.Drawing.Point(85, 20);
            this.txtDesconto_Porcent.LookUp = false;
            this.txtDesconto_Porcent.MaxLength = 6;
            this.txtDesconto_Porcent.MensagemObrigatorio = "Campo obrigatório";
            this.txtDesconto_Porcent.Name = "txtDesconto_Porcent";
            this.txtDesconto_Porcent.Obrigatorio = false;
            this.txtDesconto_Porcent.Qtde_Casas_Decimais = 2;
            this.txtDesconto_Porcent.Size = new System.Drawing.Size(55, 20);
            this.txtDesconto_Porcent.SQLStatement = string.Empty;
            this.txtDesconto_Porcent.Tabela = null;
            this.txtDesconto_Porcent.Tabela_INNER = null;
            this.txtDesconto_Porcent.TabIndex = 1;
            this.txtDesconto_Porcent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDesconto_Porcent.TipoControles = CompSoft.TipoControle.Numerico;
            this.txtDesconto_Porcent.ValorAnterior = string.Empty;
            this.txtDesconto_Porcent.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesconto_Porcent_Validating);
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(5, 23);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(74, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Porcentagem:";
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.txtComissao_Valor);
            this.cf_GroupBox2.Controls.Add(this.cf_Label3);
            this.cf_GroupBox2.Controls.Add(this.txtComissao_Porcent);
            this.cf_GroupBox2.Controls.Add(this.cf_Label4);
            this.cf_GroupBox2.ControlSource = string.Empty;
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(218, 64);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(204, 78);
            this.cf_GroupBox2.Tabela = string.Empty;
            this.cf_GroupBox2.TabIndex = 8;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Comissão";
            this.cf_GroupBox2.Value = string.Empty;
            // 
            // txtComissao_Valor
            // 
            this.txtComissao_Valor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtComissao_Valor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComissao_Valor.Coluna_LookUp = 0;
            this.txtComissao_Valor.ControlSource = string.Empty;
            this.txtComissao_Valor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComissao_Valor.ForeColor = System.Drawing.Color.DimGray;
            this.txtComissao_Valor.Grupo = string.Empty;
            this.txtComissao_Valor.Incluir_QueryBy = true;
            this.txtComissao_Valor.Location = new System.Drawing.Point(85, 46);
            this.txtComissao_Valor.LookUp = false;
            this.txtComissao_Valor.MaxLength = 10;
            this.txtComissao_Valor.MensagemObrigatorio = "Campo obrigatório";
            this.txtComissao_Valor.Name = "txtComissao_Valor";
            this.txtComissao_Valor.Obrigatorio = false;
            this.txtComissao_Valor.Qtde_Casas_Decimais = 0;
            this.txtComissao_Valor.Size = new System.Drawing.Size(110, 20);
            this.txtComissao_Valor.SQLStatement = string.Empty;
            this.txtComissao_Valor.Tabela = null;
            this.txtComissao_Valor.Tabela_INNER = null;
            this.txtComissao_Valor.TabIndex = 3;
            this.txtComissao_Valor.Text = null;
            this.txtComissao_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtComissao_Valor.TipoControles = CompSoft.TipoControle.Moeda;
            this.txtComissao_Valor.ValorAnterior = string.Empty;
            this.txtComissao_Valor.Validating += new System.ComponentModel.CancelEventHandler(this.txtComissao_Valor_Validating);
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(44, 49);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(35, 13);
            this.cf_Label3.TabIndex = 2;
            this.cf_Label3.Text = "Valor:";
            // 
            // txtComissao_Porcent
            // 
            this.txtComissao_Porcent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtComissao_Porcent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComissao_Porcent.Coluna_LookUp = 0;
            this.txtComissao_Porcent.ControlSource = string.Empty;
            this.txtComissao_Porcent.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComissao_Porcent.ForeColor = System.Drawing.Color.DimGray;
            this.txtComissao_Porcent.Grupo = string.Empty;
            this.txtComissao_Porcent.Incluir_QueryBy = true;
            this.txtComissao_Porcent.Location = new System.Drawing.Point(85, 20);
            this.txtComissao_Porcent.LookUp = false;
            this.txtComissao_Porcent.MaxLength = 6;
            this.txtComissao_Porcent.MensagemObrigatorio = "Campo obrigatório";
            this.txtComissao_Porcent.Name = "txtComissao_Porcent";
            this.txtComissao_Porcent.Obrigatorio = false;
            this.txtComissao_Porcent.Qtde_Casas_Decimais = 2;
            this.txtComissao_Porcent.Size = new System.Drawing.Size(55, 20);
            this.txtComissao_Porcent.SQLStatement = string.Empty;
            this.txtComissao_Porcent.Tabela = null;
            this.txtComissao_Porcent.Tabela_INNER = null;
            this.txtComissao_Porcent.TabIndex = 1;
            this.txtComissao_Porcent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtComissao_Porcent.TipoControles = CompSoft.TipoControle.Numerico;
            this.txtComissao_Porcent.ValorAnterior = string.Empty;
            this.txtComissao_Porcent.Validating += new System.ComponentModel.CancelEventHandler(this.txtComissao_Porcent_Validating);
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(5, 23);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(74, 13);
            this.cf_Label4.TabIndex = 0;
            this.cf_Label4.Text = "Porcentagem:";
            // 
            // txtQtde
            // 
            this.txtQtde.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQtde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtde.Coluna_LookUp = 0;
            this.txtQtde.ControlSource = string.Empty;
            this.txtQtde.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtde.ForeColor = System.Drawing.Color.DimGray;
            this.txtQtde.Grupo = string.Empty;
            this.txtQtde.Incluir_QueryBy = true;
            this.txtQtde.Location = new System.Drawing.Point(93, 38);
            this.txtQtde.LookUp = false;
            this.txtQtde.MaxLength = 5;
            this.txtQtde.MensagemObrigatorio = "Campo obrigatório";
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Obrigatorio = false;
            this.txtQtde.Qtde_Casas_Decimais = 0;
            this.txtQtde.Size = new System.Drawing.Size(55, 20);
            this.txtQtde.SQLStatement = string.Empty;
            this.txtQtde.Tabela = null;
            this.txtQtde.Tabela_INNER = null;
            this.txtQtde.TabIndex = 3;
            this.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtde.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtQtde.ValorAnterior = string.Empty;
            this.txtQtde.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtde_Validating);
            // 
            // cf_Label5
            // 
            this.cf_Label5.AutoSize = true;
            this.cf_Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label5.Location = new System.Drawing.Point(20, 41);
            this.cf_Label5.Name = "cf_Label5";
            this.cf_Label5.Size = new System.Drawing.Size(67, 13);
            this.cf_Label5.TabIndex = 2;
            this.cf_Label5.Text = "Quantidade:";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.ForeColor = System.Drawing.Color.Black;
            this.cmdCancelar.Grupo = string.Empty;
            this.cmdCancelar.Image = global::ERP.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCancelar.Location = new System.Drawing.Point(357, 148);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(63, 53);
            this.cmdCancelar.TabIndex = 0;
            this.cmdCancelar.TabStop = false;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdConfirmar
            // 
            this.cmdConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConfirmar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConfirmar.ForeColor = System.Drawing.Color.Black;
            this.cmdConfirmar.Grupo = string.Empty;
            this.cmdConfirmar.Image = global::ERP.Properties.Resources.Confirmar;
            this.cmdConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdConfirmar.Location = new System.Drawing.Point(288, 148);
            this.cmdConfirmar.Name = "cmdConfirmar";
            this.cmdConfirmar.Size = new System.Drawing.Size(63, 53);
            this.cmdConfirmar.TabIndex = 9;
            this.cmdConfirmar.TabStop = false;
            this.cmdConfirmar.Text = "Confirmar";
            this.cmdConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdConfirmar.UseVisualStyleBackColor = true;
            this.cmdConfirmar.Click += new System.EventHandler(this.cmdConfirmar_Click);
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValorUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorUnitario.Coluna_LookUp = 0;
            this.txtValorUnitario.ControlSource = string.Empty;
            this.txtValorUnitario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorUnitario.ForeColor = System.Drawing.Color.DimGray;
            this.txtValorUnitario.Grupo = string.Empty;
            this.txtValorUnitario.Incluir_QueryBy = true;
            this.txtValorUnitario.Location = new System.Drawing.Point(249, 39);
            this.txtValorUnitario.LookUp = false;
            this.txtValorUnitario.MaxLength = 10;
            this.txtValorUnitario.MensagemObrigatorio = "Campo obrigatório";
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Obrigatorio = false;
            this.txtValorUnitario.Qtde_Casas_Decimais = 0;
            this.txtValorUnitario.Size = new System.Drawing.Size(110, 20);
            this.txtValorUnitario.SQLStatement = string.Empty;
            this.txtValorUnitario.Tabela = null;
            this.txtValorUnitario.Tabela_INNER = null;
            this.txtValorUnitario.TabIndex = 5;
            this.txtValorUnitario.Text = null;
            this.txtValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorUnitario.TipoControles = CompSoft.TipoControle.Moeda;
            this.txtValorUnitario.ValorAnterior = string.Empty;
            this.txtValorUnitario.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorUnitario_Validating);
            // 
            // cf_Label6
            // 
            this.cf_Label6.AutoSize = true;
            this.cf_Label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label6.Location = new System.Drawing.Point(169, 42);
            this.cf_Label6.Name = "cf_Label6";
            this.cf_Label6.Size = new System.Drawing.Size(74, 13);
            this.cf_Label6.TabIndex = 4;
            this.cf_Label6.Text = "Valor unitário:";
            // 
            // f0038
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 207);
            this.Controls.Add(this.txtValorUnitario);
            this.Controls.Add(this.cf_Label6);
            this.Controls.Add(this.txtQtde);
            this.Controls.Add(this.cf_Label5);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdConfirmar);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.lblCodProduto);
            this.Controls.Add(this.lblProduto);
            this.Name = "f0038";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alteração do item do pedido";
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label lblProduto;
        private System.Windows.Forms.Label lblCodProduto;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_TextBox txtDesconto_Valor;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtDesconto_Porcent;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_TextBox txtComissao_Valor;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox txtComissao_Porcent;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_Button cmdConfirmar;
        private CompSoft.cf_Bases.cf_Button cmdCancelar;
        private CompSoft.cf_Bases.cf_TextBox txtQtde;
        private CompSoft.cf_Bases.cf_Label cf_Label5;
        private CompSoft.cf_Bases.cf_TextBox txtValorUnitario;
        private CompSoft.cf_Bases.cf_Label cf_Label6;

    }
}