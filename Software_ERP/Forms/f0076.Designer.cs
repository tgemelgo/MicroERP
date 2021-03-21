namespace ERP.Forms
{
    partial class f0076
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
            this.cboBanco = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox3 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox4 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label5 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox5 = new CompSoft.cf_Bases.cf_TextBox();
            this.txtFone2 = new CompSoft.cf_Bases.cf_MaskedBox();
            this.cf_Label6 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox6 = new CompSoft.cf_Bases.cf_TextBox();
            this.txtFone1 = new CompSoft.cf_Bases.cf_MaskedBox();
            this.cf_Label7 = new CompSoft.cf_Bases.cf_Label();
            this.SuspendLayout();
            // 
            // cf_TextBox1
            // 
            this.cf_TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox1.Coluna_LookUp = 0;
            this.cf_TextBox1.ControlSource = "banco";
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = "";
            this.cf_TextBox1.Incluir_QueryBy = true;
            this.cf_TextBox1.Location = new System.Drawing.Point(79, 41);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = true;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(102, 20);
            this.cf_TextBox1.SQLStatement = "";
            this.cf_TextBox1.Tabela = "bancos";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 7;
            this.cf_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Inteiro;
            this.cf_TextBox1.ValorAnterior = "";
            this.cf_TextBox1.Value = "";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(21, 43);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(52, 13);
            this.cf_Label1.TabIndex = 6;
            this.cf_Label1.Text = "Agência :";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(187, 43);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(41, 13);
            this.cf_Label2.TabIndex = 8;
            this.cf_Label2.Text = "Digito :";
            // 
            // cf_TextBox2
            // 
            this.cf_TextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox2.Coluna_LookUp = 0;
            this.cf_TextBox2.ControlSource = "banco";
            this.cf_TextBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox2.Grupo = "";
            this.cf_TextBox2.Incluir_QueryBy = true;
            this.cf_TextBox2.Location = new System.Drawing.Point(234, 41);
            this.cf_TextBox2.LookUp = false;
            this.cf_TextBox2.MaxLength = 1;
            this.cf_TextBox2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox2.Name = "cf_TextBox2";
            this.cf_TextBox2.Obrigatorio = true;
            this.cf_TextBox2.Qtde_Casas_Decimais = 0;
            this.cf_TextBox2.Size = new System.Drawing.Size(24, 20);
            this.cf_TextBox2.SQLStatement = "";
            this.cf_TextBox2.Tabela = "bancos";
            this.cf_TextBox2.Tabela_INNER = null;
            this.cf_TextBox2.TabIndex = 9;
            this.cf_TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox2.TipoControles = CompSoft.TipoControle.Inteiro;
            this.cf_TextBox2.ValorAnterior = "";
            this.cf_TextBox2.Value = "";
            // 
            // cboBanco
            // 
            this.cboBanco.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboBanco.ControlSource = "banco";
            this.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanco.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboBanco.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBanco.ForeColor = System.Drawing.Color.DimGray;
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Grupo = "";
            this.cboBanco.Incluir_QueryBy = true;
            this.cboBanco.Location = new System.Drawing.Point(79, 12);
            this.cboBanco.MensagemObrigatorio = "Campo obrigatório";
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Obrigatorio = false;
            this.cboBanco.ReadOnly = false;
            this.cboBanco.Size = new System.Drawing.Size(276, 21);
            this.cboBanco.SQLStatement = "Select * from Bancos order by Banco";
            this.cboBanco.Tabela = "agencias";
            this.cboBanco.Tabela_INNER = null;
            this.cboBanco.TabIndex = 10;
            this.cboBanco.ValorAnterior = null;
            this.cboBanco.Value = null;
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(21, 15);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(43, 13);
            this.cf_Label3.TabIndex = 11;
            this.cf_Label3.Text = "Banco :";
            // 
            // cf_TextBox3
            // 
            this.cf_TextBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox3.Coluna_LookUp = 0;
            this.cf_TextBox3.ControlSource = "banco";
            this.cf_TextBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox3.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox3.Grupo = "";
            this.cf_TextBox3.Incluir_QueryBy = true;
            this.cf_TextBox3.Location = new System.Drawing.Point(79, 67);
            this.cf_TextBox3.LookUp = false;
            this.cf_TextBox3.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox3.Name = "cf_TextBox3";
            this.cf_TextBox3.Obrigatorio = true;
            this.cf_TextBox3.Qtde_Casas_Decimais = 0;
            this.cf_TextBox3.Size = new System.Drawing.Size(276, 20);
            this.cf_TextBox3.SQLStatement = "";
            this.cf_TextBox3.Tabela = "bancos";
            this.cf_TextBox3.Tabela_INNER = null;
            this.cf_TextBox3.TabIndex = 13;
            this.cf_TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox3.TipoControles = CompSoft.TipoControle.Inteiro;
            this.cf_TextBox3.ValorAnterior = "";
            this.cf_TextBox3.Value = "";
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(21, 69);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(41, 13);
            this.cf_Label4.TabIndex = 12;
            this.cf_Label4.Text = "Nome :";
            // 
            // cf_TextBox4
            // 
            this.cf_TextBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox4.Coluna_LookUp = 0;
            this.cf_TextBox4.ControlSource = "banco";
            this.cf_TextBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox4.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox4.Grupo = "";
            this.cf_TextBox4.Incluir_QueryBy = true;
            this.cf_TextBox4.Location = new System.Drawing.Point(79, 93);
            this.cf_TextBox4.LookUp = false;
            this.cf_TextBox4.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox4.Name = "cf_TextBox4";
            this.cf_TextBox4.Obrigatorio = true;
            this.cf_TextBox4.Qtde_Casas_Decimais = 0;
            this.cf_TextBox4.Size = new System.Drawing.Size(276, 20);
            this.cf_TextBox4.SQLStatement = "";
            this.cf_TextBox4.Tabela = "bancos";
            this.cf_TextBox4.Tabela_INNER = null;
            this.cf_TextBox4.TabIndex = 15;
            this.cf_TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox4.TipoControles = CompSoft.TipoControle.Inteiro;
            this.cf_TextBox4.ValorAnterior = "";
            this.cf_TextBox4.Value = "";
            // 
            // cf_Label5
            // 
            this.cf_Label5.AutoSize = true;
            this.cf_Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label5.Location = new System.Drawing.Point(21, 95);
            this.cf_Label5.Name = "cf_Label5";
            this.cf_Label5.Size = new System.Drawing.Size(53, 13);
            this.cf_Label5.TabIndex = 14;
            this.cf_Label5.Text = "Contato :";
            // 
            // cf_TextBox5
            // 
            this.cf_TextBox5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox5.Coluna_LookUp = 0;
            this.cf_TextBox5.ControlSource = "ddd2";
            this.cf_TextBox5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox5.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox5.Grupo = "";
            this.cf_TextBox5.Incluir_QueryBy = true;
            this.cf_TextBox5.Location = new System.Drawing.Point(240, 119);
            this.cf_TextBox5.LookUp = false;
            this.cf_TextBox5.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox5.Name = "cf_TextBox5";
            this.cf_TextBox5.Obrigatorio = false;
            this.cf_TextBox5.Qtde_Casas_Decimais = 0;
            this.cf_TextBox5.Size = new System.Drawing.Size(27, 20);
            this.cf_TextBox5.SQLStatement = "";
            this.cf_TextBox5.Tabela = "clientes";
            this.cf_TextBox5.Tabela_INNER = null;
            this.cf_TextBox5.TabIndex = 23;
            this.cf_TextBox5.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox5.ValorAnterior = "";
            this.cf_TextBox5.Value = "";
            // 
            // txtFone2
            // 
            this.txtFone2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFone2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFone2.ControlSource = "fone2";
            this.txtFone2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtFone2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone2.ForeColor = System.Drawing.Color.DimGray;
            this.txtFone2.Grupo = "";
            this.txtFone2.HidePromptOnLeave = true;
            this.txtFone2.Incluir_QueryBy = true;
            this.txtFone2.Length = 32767;
            this.txtFone2.Location = new System.Drawing.Point(273, 119);
            this.txtFone2.MensagemObrigatorio = "Campo obrigatório";
            this.txtFone2.Name = "txtFone2";
            this.txtFone2.Obrigatorio = false;
            this.txtFone2.Size = new System.Drawing.Size(82, 20);
            this.txtFone2.Tabela = "clientes";
            this.txtFone2.Tabela_INNER = null;
            this.txtFone2.TabIndex = 24;
            this.txtFone2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtFone2.ValorAnterior = "";
            this.txtFone2.Value = "";
            // 
            // cf_Label6
            // 
            this.cf_Label6.AutoSize = true;
            this.cf_Label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label6.Location = new System.Drawing.Point(205, 122);
            this.cf_Label6.Name = "cf_Label6";
            this.cf_Label6.Size = new System.Drawing.Size(29, 13);
            this.cf_Label6.TabIndex = 22;
            this.cf_Label6.Text = "Fax:";
            // 
            // cf_TextBox6
            // 
            this.cf_TextBox6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox6.Coluna_LookUp = 0;
            this.cf_TextBox6.ControlSource = "ddd1";
            this.cf_TextBox6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox6.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox6.Grupo = "";
            this.cf_TextBox6.Incluir_QueryBy = true;
            this.cf_TextBox6.Location = new System.Drawing.Point(79, 119);
            this.cf_TextBox6.LookUp = false;
            this.cf_TextBox6.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox6.Name = "cf_TextBox6";
            this.cf_TextBox6.Obrigatorio = true;
            this.cf_TextBox6.Qtde_Casas_Decimais = 0;
            this.cf_TextBox6.Size = new System.Drawing.Size(27, 20);
            this.cf_TextBox6.SQLStatement = "";
            this.cf_TextBox6.Tabela = "clientes";
            this.cf_TextBox6.Tabela_INNER = null;
            this.cf_TextBox6.TabIndex = 20;
            this.cf_TextBox6.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox6.ValorAnterior = "";
            this.cf_TextBox6.Value = "";
            // 
            // txtFone1
            // 
            this.txtFone1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFone1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFone1.ControlSource = "fone1";
            this.txtFone1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtFone1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone1.ForeColor = System.Drawing.Color.DimGray;
            this.txtFone1.Grupo = "";
            this.txtFone1.HidePromptOnLeave = true;
            this.txtFone1.Incluir_QueryBy = true;
            this.txtFone1.Length = 32767;
            this.txtFone1.Location = new System.Drawing.Point(112, 119);
            this.txtFone1.MensagemObrigatorio = "Campo obrigatório";
            this.txtFone1.Name = "txtFone1";
            this.txtFone1.Obrigatorio = true;
            this.txtFone1.Size = new System.Drawing.Size(81, 20);
            this.txtFone1.Tabela = "clientes";
            this.txtFone1.Tabela_INNER = null;
            this.txtFone1.TabIndex = 21;
            this.txtFone1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtFone1.ValorAnterior = "";
            this.txtFone1.Value = "";
            // 
            // cf_Label7
            // 
            this.cf_Label7.AutoSize = true;
            this.cf_Label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label7.Location = new System.Drawing.Point(21, 121);
            this.cf_Label7.Name = "cf_Label7";
            this.cf_Label7.Size = new System.Drawing.Size(53, 13);
            this.cf_Label7.TabIndex = 19;
            this.cf_Label7.Text = "Telefone:";
            // 
            // f0076
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(368, 154);
            this.Controls.Add(this.cf_TextBox5);
            this.Controls.Add(this.txtFone2);
            this.Controls.Add(this.cf_Label6);
            this.Controls.Add(this.cf_TextBox6);
            this.Controls.Add(this.txtFone1);
            this.Controls.Add(this.cf_Label7);
            this.Controls.Add(this.cf_TextBox4);
            this.Controls.Add(this.cf_Label5);
            this.Controls.Add(this.cf_TextBox3);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cboBanco);
            this.Controls.Add(this.cf_TextBox2);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_TextBox1);
            this.Controls.Add(this.cf_Label1);
            this.Name = "f0076";
            this.Text = "Cadastro de Agência";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox2;
        private CompSoft.cf_Bases.cf_ComboBox cboBanco;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox3;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox4;
        private CompSoft.cf_Bases.cf_Label cf_Label5;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox5;
        private CompSoft.cf_Bases.cf_MaskedBox txtFone2;
        private CompSoft.cf_Bases.cf_Label cf_Label6;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox6;
        private CompSoft.cf_Bases.cf_MaskedBox txtFone1;
        private CompSoft.cf_Bases.cf_Label cf_Label7;
    }
}
