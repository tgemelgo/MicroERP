namespace ERP.Forms
{
    partial class f0022
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
            this.chkInativo = new CompSoft.cf_Bases.cf_CheckBox();
            this.txtDescricao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtCodigo = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.SuspendLayout();
            // 
            // chkInativo
            // 
            this.chkInativo.AutoSize = true;
            this.chkInativo.ControlSource = "Inativo";
            this.chkInativo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInativo.Grupo = string.Empty;
            this.chkInativo.Location = new System.Drawing.Point(262, 13);
            this.chkInativo.Name = "chkInativo";
            this.chkInativo.Size = new System.Drawing.Size(67, 17);
            this.chkInativo.Tabela = "Escolaridades";
            this.chkInativo.Tabela_INNER = null;
            this.chkInativo.TabIndex = 4;
            this.chkInativo.Text = "Inativo";
            this.chkInativo.UseVisualStyleBackColor = true;
            this.chkInativo.ValorAnterior = false;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Coluna_LookUp = 0;
            this.txtDescricao.ControlSource = "Desc_Escolaridade";
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricao.Grupo = string.Empty;
            this.txtDescricao.Incluir_QueryBy = true;
            this.txtDescricao.Location = new System.Drawing.Point(71, 36);
            this.txtDescricao.LookUp = false;
            this.txtDescricao.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Obrigatorio = false;
            this.txtDescricao.Size = new System.Drawing.Size(258, 20);
            this.txtDescricao.SQLStatement = string.Empty;
            this.txtDescricao.Tabela = "Escolaridades";
            this.txtDescricao.Tabela_INNER = null;
            this.txtDescricao.TabIndex = 3;
            this.txtDescricao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao.ValorAnterior = string.Empty;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(8, 39);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Descrição:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Coluna_LookUp = 0;
            this.txtCodigo.ControlSource = "Escolaridade";
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodigo.Grupo = string.Empty;
            this.txtCodigo.Incluir_QueryBy = true;
            this.txtCodigo.Location = new System.Drawing.Point(71, 10);
            this.txtCodigo.LookUp = false;
            this.txtCodigo.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Obrigatorio = false;
            this.txtCodigo.Size = new System.Drawing.Size(50, 20);
            this.txtCodigo.SQLStatement = string.Empty;
            this.txtCodigo.Tabela = "Escolaridades";
            this.txtCodigo.Tabela_INNER = null;
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigo.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtCodigo.ValorAnterior = string.Empty;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(21, 13);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(44, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Código:";
            // 
            // f0022
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 67);
            this.Controls.Add(this.chkInativo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "Escolaridades";
            this.Name = "f0022";
            this.Text = "Escolaridade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_CheckBox chkInativo;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtCodigo;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
    }
}