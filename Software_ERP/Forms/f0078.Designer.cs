namespace ERP.Forms
{
    partial class f0078
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
            this.cf_ComboBox1 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox2 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cf_CheckBox1 = new CompSoft.cf_Bases.cf_CheckBox();
            this.SuspendLayout();
            // 
            // cf_TextBox1
            // 
            this.cf_TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox1.Coluna_LookUp = 0;
            this.cf_TextBox1.ControlSource = "EspecieDoc";
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = "";
            this.cf_TextBox1.Incluir_QueryBy = true;
            this.cf_TextBox1.Location = new System.Drawing.Point(84, 39);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = false;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(74, 20);
            this.cf_TextBox1.SQLStatement = "";
            this.cf_TextBox1.Tabela = "boletos_especies_documentos";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 4;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox1.ValorAnterior = "";
            this.cf_TextBox1.Value = "";
            // 
            // cf_ComboBox1
            // 
            this.cf_ComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox1.ControlSource = "Banco";
            this.cf_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox1.FormattingEnabled = true;
            this.cf_ComboBox1.Grupo = "";
            this.cf_ComboBox1.Incluir_QueryBy = true;
            this.cf_ComboBox1.Location = new System.Drawing.Point(84, 12);
            this.cf_ComboBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox1.Name = "cf_ComboBox1";
            this.cf_ComboBox1.Obrigatorio = false;
            this.cf_ComboBox1.ReadOnly = false;
            this.cf_ComboBox1.Size = new System.Drawing.Size(195, 21);
            this.cf_ComboBox1.SQLStatement = "select banco, convert(char(3), banco) + \' - \' + descr_banco as \'desc\' from bancos" +
                " order by descr_banco";
            this.cf_ComboBox1.Tabela = "boletos_especies_documentos";
            this.cf_ComboBox1.Tabela_INNER = null;
            this.cf_ComboBox1.TabIndex = 1;
            this.cf_ComboBox1.ValorAnterior = null;
            this.cf_ComboBox1.Value = null;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(6, 42);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(72, 13);
            this.cf_Label1.TabIndex = 3;
            this.cf_Label1.Text = "Especie Doc.:";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(38, 15);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(40, 13);
            this.cf_Label2.TabIndex = 0;
            this.cf_Label2.Text = "Banco:";
            // 
            // cf_TextBox2
            // 
            this.cf_TextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox2.Coluna_LookUp = 0;
            this.cf_TextBox2.ControlSource = "Desc_EspecieDoc";
            this.cf_TextBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox2.Grupo = "";
            this.cf_TextBox2.Incluir_QueryBy = true;
            this.cf_TextBox2.Location = new System.Drawing.Point(84, 65);
            this.cf_TextBox2.LookUp = false;
            this.cf_TextBox2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox2.Name = "cf_TextBox2";
            this.cf_TextBox2.Obrigatorio = false;
            this.cf_TextBox2.Qtde_Casas_Decimais = 0;
            this.cf_TextBox2.Size = new System.Drawing.Size(310, 20);
            this.cf_TextBox2.SQLStatement = "";
            this.cf_TextBox2.Tabela = "boletos_especies_documentos";
            this.cf_TextBox2.Tabela_INNER = null;
            this.cf_TextBox2.TabIndex = 6;
            this.cf_TextBox2.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox2.ValorAnterior = "";
            this.cf_TextBox2.Value = "";
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(21, 68);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(57, 13);
            this.cf_Label3.TabIndex = 5;
            this.cf_Label3.Text = "Descrição:";
            // 
            // cf_CheckBox1
            // 
            this.cf_CheckBox1.AutoSize = true;
            this.cf_CheckBox1.ControlSource = "Inativo";
            this.cf_CheckBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox1.Grupo = "";
            this.cf_CheckBox1.Incluir_QueryBy = false;
            this.cf_CheckBox1.Location = new System.Drawing.Point(327, 16);
            this.cf_CheckBox1.MensagemObrigatorio = "";
            this.cf_CheckBox1.Name = "cf_CheckBox1";
            this.cf_CheckBox1.Obrigatorio = false;
            this.cf_CheckBox1.ReadOnly = false;
            this.cf_CheckBox1.Size = new System.Drawing.Size(67, 17);
            this.cf_CheckBox1.Tabela = "boletos_especies_documentos";
            this.cf_CheckBox1.Tabela_INNER = null;
            this.cf_CheckBox1.TabIndex = 2;
            this.cf_CheckBox1.Text = "Inativo";
            this.cf_CheckBox1.UseVisualStyleBackColor = true;
            this.cf_CheckBox1.ValorAnterior = false;
            this.cf_CheckBox1.Value = false;
            // 
            // f0078
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 95);
            this.Controls.Add(this.cf_CheckBox1);
            this.Controls.Add(this.cf_TextBox2);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_ComboBox1);
            this.Controls.Add(this.cf_TextBox1);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "boletos_especies_documentos";
            this.Name = "f0078";
            this.Text = "Especie do documento - Boleto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox2;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox1;

    }
}