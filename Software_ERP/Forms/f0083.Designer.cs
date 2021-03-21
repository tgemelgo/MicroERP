namespace ERP.Forms
{
    partial class f0083
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
            this.cf_TextBox1 = new CompSoft.cf_Bases.cf_TextBox();
            this.txtMensagem = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtQueryUtilizacao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.txtQuerySubstiuicao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(28, 15);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(44, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Código:";
            // 
            // cf_TextBox1
            // 
            this.cf_TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox1.Coluna_LookUp = 0;
            this.cf_TextBox1.ControlSource = "Mensagem_Nota";
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = "";
            this.cf_TextBox1.Incluir_QueryBy = true;
            this.cf_TextBox1.Location = new System.Drawing.Point(78, 12);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = false;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(72, 20);
            this.cf_TextBox1.SQLStatement = "";
            this.cf_TextBox1.Tabela = "mensagens_notas";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 1;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox1.ValorAnterior = "";
            this.cf_TextBox1.Value = "";
            // 
            // txtMensagem
            // 
            this.txtMensagem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensagem.Coluna_LookUp = 0;
            this.txtMensagem.ControlSource = "Mensagem";
            this.txtMensagem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensagem.ForeColor = System.Drawing.Color.DimGray;
            this.txtMensagem.Grupo = "";
            this.txtMensagem.Incluir_QueryBy = true;
            this.txtMensagem.Location = new System.Drawing.Point(78, 38);
            this.txtMensagem.LookUp = false;
            this.txtMensagem.MensagemObrigatorio = "Campo obrigatório";
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Obrigatorio = false;
            this.txtMensagem.Qtde_Casas_Decimais = 0;
            this.txtMensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensagem.Size = new System.Drawing.Size(563, 58);
            this.txtMensagem.SQLStatement = "";
            this.txtMensagem.Tabela = "mensagens_notas";
            this.txtMensagem.Tabela_INNER = null;
            this.txtMensagem.TabIndex = 3;
            this.txtMensagem.TipoControles = CompSoft.TipoControle.Geral;
            this.txtMensagem.ValorAnterior = "";
            this.txtMensagem.Value = "";
            this.txtMensagem.TextChanged += new System.EventHandler(this.txtMensagem_TextChanged);
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(10, 41);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(62, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Mensagem:";
            // 
            // txtQueryUtilizacao
            // 
            this.txtQueryUtilizacao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQueryUtilizacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQueryUtilizacao.Coluna_LookUp = 0;
            this.txtQueryUtilizacao.ControlSource = "Query_Verifica_Utilizacao";
            this.txtQueryUtilizacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueryUtilizacao.ForeColor = System.Drawing.Color.DimGray;
            this.txtQueryUtilizacao.Grupo = "";
            this.txtQueryUtilizacao.Incluir_QueryBy = true;
            this.txtQueryUtilizacao.Location = new System.Drawing.Point(78, 115);
            this.txtQueryUtilizacao.LookUp = false;
            this.txtQueryUtilizacao.MensagemObrigatorio = "Campo obrigatório";
            this.txtQueryUtilizacao.Multiline = true;
            this.txtQueryUtilizacao.Name = "txtQueryUtilizacao";
            this.txtQueryUtilizacao.Obrigatorio = false;
            this.txtQueryUtilizacao.Qtde_Casas_Decimais = 0;
            this.txtQueryUtilizacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQueryUtilizacao.Size = new System.Drawing.Size(563, 183);
            this.txtQueryUtilizacao.SQLStatement = "";
            this.txtQueryUtilizacao.Tabela = "mensagens_notas";
            this.txtQueryUtilizacao.Tabela_INNER = null;
            this.txtQueryUtilizacao.TabIndex = 5;
            this.txtQueryUtilizacao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtQueryUtilizacao.ValorAnterior = "";
            this.txtQueryUtilizacao.Value = "";
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(75, 99);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(215, 13);
            this.cf_Label3.TabIndex = 4;
            this.cf_Label3.Text = "Query para verificar se utiliza a mensagem:";
            // 
            // txtQuerySubstiuicao
            // 
            this.txtQuerySubstiuicao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQuerySubstiuicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuerySubstiuicao.Coluna_LookUp = 0;
            this.txtQuerySubstiuicao.ControlSource = "Query_Substituicao";
            this.txtQuerySubstiuicao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuerySubstiuicao.ForeColor = System.Drawing.Color.DimGray;
            this.txtQuerySubstiuicao.Grupo = "";
            this.txtQuerySubstiuicao.Incluir_QueryBy = true;
            this.txtQuerySubstiuicao.Location = new System.Drawing.Point(78, 319);
            this.txtQuerySubstiuicao.LookUp = false;
            this.txtQuerySubstiuicao.MensagemObrigatorio = "Campo obrigatório";
            this.txtQuerySubstiuicao.Multiline = true;
            this.txtQuerySubstiuicao.Name = "txtQuerySubstiuicao";
            this.txtQuerySubstiuicao.Obrigatorio = false;
            this.txtQuerySubstiuicao.Qtde_Casas_Decimais = 0;
            this.txtQuerySubstiuicao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuerySubstiuicao.Size = new System.Drawing.Size(563, 183);
            this.txtQuerySubstiuicao.SQLStatement = "";
            this.txtQuerySubstiuicao.Tabela = "mensagens_notas";
            this.txtQuerySubstiuicao.Tabela_INNER = null;
            this.txtQuerySubstiuicao.TabIndex = 7;
            this.txtQuerySubstiuicao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtQuerySubstiuicao.ValorAnterior = "";
            this.txtQuerySubstiuicao.Value = "";
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(75, 303);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(171, 13);
            this.cf_Label4.TabIndex = 6;
            this.cf_Label4.Text = "Query para substiuição de valores";
            // 
            // f0083
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 514);
            this.Controls.Add(this.txtQuerySubstiuicao);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.txtQueryUtilizacao);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_TextBox1);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "mensagens_notas";
            this.Name = "f0083";
            this.Text = "Mensagens Nota Fiscal";
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.f0083_user_FormStatus_Change);
            this.user_BeforeSave += new CompSoft.FormSet.BeforeSave(this.f0083_user_BeforeSave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
        private CompSoft.cf_Bases.cf_TextBox txtMensagem;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtQueryUtilizacao;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox txtQuerySubstiuicao;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
    }
}