namespace ERP.Forms
{
    partial class f0048
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
            this.txtCodigo = new CompSoft.cf_Bases.cf_TextBox();
            this.txtDescricao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.chkAtivo = new CompSoft.cf_Bases.cf_CheckBox();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(35, 15);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(34, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Cód.:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Coluna_LookUp = 0;
            this.txtCodigo.ControlSource = "Tipo_Movimento";
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodigo.Grupo = string.Empty;
            this.txtCodigo.Incluir_QueryBy = true;
            this.txtCodigo.Location = new System.Drawing.Point(75, 12);
            this.txtCodigo.LookUp = false;
            this.txtCodigo.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Obrigatorio = false;
            this.txtCodigo.Size = new System.Drawing.Size(64, 20);
            this.txtCodigo.SQLStatement = string.Empty;
            this.txtCodigo.Tabela = "Tipos_Movimentos";
            this.txtCodigo.Tabela_INNER = null;
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigo.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCodigo.ValorAnterior = string.Empty;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Coluna_LookUp = 0;
            this.txtDescricao.ControlSource = "Desc_Tipo_Movimento";
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricao.Grupo = string.Empty;
            this.txtDescricao.Incluir_QueryBy = true;
            this.txtDescricao.Location = new System.Drawing.Point(75, 38);
            this.txtDescricao.LookUp = false;
            this.txtDescricao.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Obrigatorio = false;
            this.txtDescricao.Size = new System.Drawing.Size(254, 20);
            this.txtDescricao.SQLStatement = string.Empty;
            this.txtDescricao.Tabela = "Tipos_Movimentos";
            this.txtDescricao.Tabela_INNER = null;
            this.txtDescricao.TabIndex = 3;
            this.txtDescricao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao.ValorAnterior = string.Empty;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(12, 41);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Descrição:";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.ControlSource = "Inativo";
            this.chkAtivo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivo.Grupo = string.Empty;
            this.chkAtivo.Location = new System.Drawing.Point(278, 15);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(60, 17);
            this.chkAtivo.Tabela = "Tipos_Movimentos";
            this.chkAtivo.Tabela_INNER = null;
            this.chkAtivo.TabIndex = 4;
            this.chkAtivo.Text = "Inativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            this.chkAtivo.ValorAnterior = false;
            // 
            // f0048
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 68);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "Tipos_Movimentos";
            this.Name = "f0048";
            this.Text = "Cadastro de tipo de movimento contabil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtCodigo;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivo;
    }
}