namespace ERP.Forms
{
    partial class f0043
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
            this.cbCobrancaICMS = new CompSoft.cf_Bases.cf_CheckBox();
            this.cbAplicacaoSubstituicaoTributaria = new CompSoft.cf_Bases.cf_CheckBox();
            this.cbAplicacaoReducaoICMS = new CompSoft.cf_Bases.cf_CheckBox();
            this.cbInativo = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtSituacaoTributaria = new CompSoft.cf_Bases.cf_TextBox();
            this.txtDescricao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_ComboBox1 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.SuspendLayout();
            // 
            // cbCobrancaICMS
            // 
            this.cbCobrancaICMS.AutoSize = true;
            this.cbCobrancaICMS.ControlSource = "Cobranca_ICMS";
            this.cbCobrancaICMS.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCobrancaICMS.Grupo = string.Empty;
            this.cbCobrancaICMS.Location = new System.Drawing.Point(143, 89);
            this.cbCobrancaICMS.MensagemObrigatorio = string.Empty;
            this.cbCobrancaICMS.Name = "cbCobrancaICMS";
            this.cbCobrancaICMS.Obrigatorio = false;
            this.cbCobrancaICMS.Size = new System.Drawing.Size(100, 17);
            this.cbCobrancaICMS.Tabela = "Situacoes_Tributaria";
            this.cbCobrancaICMS.Tabela_INNER = null;
            this.cbCobrancaICMS.TabIndex = 7;
            this.cbCobrancaICMS.Text = "Cobrança ICMS";
            this.cbCobrancaICMS.UseVisualStyleBackColor = true;
            this.cbCobrancaICMS.ValorAnterior = false;
            // 
            // cbAplicacaoSubstituicaoTributaria
            // 
            this.cbAplicacaoSubstituicaoTributaria.AutoSize = true;
            this.cbAplicacaoSubstituicaoTributaria.ControlSource = "Aplicacao_Reducao_ICMS";
            this.cbAplicacaoSubstituicaoTributaria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAplicacaoSubstituicaoTributaria.Grupo = string.Empty;
            this.cbAplicacaoSubstituicaoTributaria.Location = new System.Drawing.Point(143, 135);
            this.cbAplicacaoSubstituicaoTributaria.MensagemObrigatorio = string.Empty;
            this.cbAplicacaoSubstituicaoTributaria.Name = "cbAplicacaoSubstituicaoTributaria";
            this.cbAplicacaoSubstituicaoTributaria.Obrigatorio = false;
            this.cbAplicacaoSubstituicaoTributaria.Size = new System.Drawing.Size(181, 17);
            this.cbAplicacaoSubstituicaoTributaria.Tabela = "Situacoes_Tributaria";
            this.cbAplicacaoSubstituicaoTributaria.Tabela_INNER = null;
            this.cbAplicacaoSubstituicaoTributaria.TabIndex = 9;
            this.cbAplicacaoSubstituicaoTributaria.Text = "Aplicação Substituição Tributária";
            this.cbAplicacaoSubstituicaoTributaria.UseVisualStyleBackColor = true;
            this.cbAplicacaoSubstituicaoTributaria.ValorAnterior = false;
            // 
            // cbAplicacaoReducaoICMS
            // 
            this.cbAplicacaoReducaoICMS.AutoSize = true;
            this.cbAplicacaoReducaoICMS.ControlSource = "Aplicacao_Substituicao_Tributaria";
            this.cbAplicacaoReducaoICMS.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAplicacaoReducaoICMS.Grupo = string.Empty;
            this.cbAplicacaoReducaoICMS.Location = new System.Drawing.Point(143, 112);
            this.cbAplicacaoReducaoICMS.MensagemObrigatorio = string.Empty;
            this.cbAplicacaoReducaoICMS.Name = "cbAplicacaoReducaoICMS";
            this.cbAplicacaoReducaoICMS.Obrigatorio = false;
            this.cbAplicacaoReducaoICMS.Size = new System.Drawing.Size(156, 17);
            this.cbAplicacaoReducaoICMS.Tabela = "Situacoes_Tributaria";
            this.cbAplicacaoReducaoICMS.Tabela_INNER = null;
            this.cbAplicacaoReducaoICMS.TabIndex = 8;
            this.cbAplicacaoReducaoICMS.Text = "Aplicação redução de ICMS";
            this.cbAplicacaoReducaoICMS.UseVisualStyleBackColor = true;
            this.cbAplicacaoReducaoICMS.ValorAnterior = false;
            // 
            // cbInativo
            // 
            this.cbInativo.AutoSize = true;
            this.cbInativo.ControlSource = "Inativo";
            this.cbInativo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInativo.Grupo = string.Empty;
            this.cbInativo.Location = new System.Drawing.Point(368, 9);
            this.cbInativo.MensagemObrigatorio = string.Empty;
            this.cbInativo.Name = "cbInativo";
            this.cbInativo.Obrigatorio = false;
            this.cbInativo.Size = new System.Drawing.Size(67, 17);
            this.cbInativo.Tabela = "Situacoes_Tributaria";
            this.cbInativo.Tabela_INNER = null;
            this.cbInativo.TabIndex = 2;
            this.cbInativo.Text = "Inativo";
            this.cbInativo.UseVisualStyleBackColor = true;
            this.cbInativo.ValorAnterior = false;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(38, 9);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(99, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Situação tributária:";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(80, 35);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 3;
            this.cf_Label2.Text = "Descrição:";
            // 
            // txtSituacaoTributaria
            // 
            this.txtSituacaoTributaria.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSituacaoTributaria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSituacaoTributaria.Coluna_LookUp = 0;
            this.txtSituacaoTributaria.ControlSource = "Situacao_Tributaria";
            this.txtSituacaoTributaria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSituacaoTributaria.ForeColor = System.Drawing.Color.DimGray;
            this.txtSituacaoTributaria.Grupo = string.Empty;
            this.txtSituacaoTributaria.Incluir_QueryBy = true;
            this.txtSituacaoTributaria.Location = new System.Drawing.Point(143, 6);
            this.txtSituacaoTributaria.LookUp = false;
            this.txtSituacaoTributaria.MensagemObrigatorio = "Campo obrigatório";
            this.txtSituacaoTributaria.Name = "txtSituacaoTributaria";
            this.txtSituacaoTributaria.Obrigatorio = false;
            this.txtSituacaoTributaria.Qtde_Casas_Decimais = 0;
            this.txtSituacaoTributaria.Size = new System.Drawing.Size(54, 20);
            this.txtSituacaoTributaria.SQLStatement = string.Empty;
            this.txtSituacaoTributaria.Tabela = "Situacoes_Tributaria";
            this.txtSituacaoTributaria.Tabela_INNER = null;
            this.txtSituacaoTributaria.TabIndex = 1;
            this.txtSituacaoTributaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSituacaoTributaria.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtSituacaoTributaria.ValorAnterior = string.Empty;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Coluna_LookUp = 0;
            this.txtDescricao.ControlSource = "Descricao";
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricao.Grupo = string.Empty;
            this.txtDescricao.Incluir_QueryBy = true;
            this.txtDescricao.Location = new System.Drawing.Point(143, 32);
            this.txtDescricao.LookUp = false;
            this.txtDescricao.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Obrigatorio = false;
            this.txtDescricao.Qtde_Casas_Decimais = 0;
            this.txtDescricao.Size = new System.Drawing.Size(292, 20);
            this.txtDescricao.SQLStatement = string.Empty;
            this.txtDescricao.Tabela = "Situacoes_Tributaria";
            this.txtDescricao.Tabela_INNER = null;
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao.ValorAnterior = string.Empty;
            // 
            // cf_ComboBox1
            // 
            this.cf_ComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox1.ControlSource = "Modalidade_calculo_icms";
            this.cf_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox1.FormattingEnabled = true;
            this.cf_ComboBox1.Grupo = string.Empty;
            this.cf_ComboBox1.Location = new System.Drawing.Point(143, 59);
            this.cf_ComboBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox1.Name = "cf_ComboBox1";
            this.cf_ComboBox1.Obrigatorio = false;
            this.cf_ComboBox1.Size = new System.Drawing.Size(233, 21);
            this.cf_ComboBox1.SQLStatement = "select * from modalidades_calculo_icms order by descricao_modalidade";
            this.cf_ComboBox1.Tabela = "Situacoes_Tributaria";
            this.cf_ComboBox1.Tabela_INNER = null;
            this.cf_ComboBox1.TabIndex = 6;
            this.cf_ComboBox1.ValorAnterior = string.Empty;
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(6, 62);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(131, 13);
            this.cf_Label3.TabIndex = 5;
            this.cf_Label3.Text = "Modalide de calculo ICMS:";
            // 
            // f0043
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 156);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_ComboBox1);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtSituacaoTributaria);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.cbInativo);
            this.Controls.Add(this.cbAplicacaoReducaoICMS);
            this.Controls.Add(this.cbAplicacaoSubstituicaoTributaria);
            this.Controls.Add(this.cbCobrancaICMS);
            this.MainTabela = "Situacoes_Tributaria";
            this.Name = "f0043";
            this.Text = "Cadastro de Situações Tributárias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_CheckBox cbCobrancaICMS;
        private CompSoft.cf_Bases.cf_CheckBox cbAplicacaoSubstituicaoTributaria;
        private CompSoft.cf_Bases.cf_CheckBox cbAplicacaoReducaoICMS;
        private CompSoft.cf_Bases.cf_CheckBox cbInativo;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtSituacaoTributaria;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
    }
}