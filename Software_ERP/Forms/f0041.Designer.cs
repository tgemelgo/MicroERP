namespace ERP.Forms
{
    partial class f0041
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
            this.cf_TextBox2 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_CheckBox1 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_ComboBox1 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(26, 17);
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
            this.cf_TextBox1.ControlSource = "subGrupo_produto";
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = string.Empty;
            this.cf_TextBox1.Incluir_QueryBy = true;
            this.cf_TextBox1.Location = new System.Drawing.Point(76, 14);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = false;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(69, 20);
            this.cf_TextBox1.SQLStatement = string.Empty;
            this.cf_TextBox1.Tabela = "subGrupos_produtos";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 1;
            this.cf_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Inteiro;
            this.cf_TextBox1.ValorAnterior = string.Empty;
            // 
            // cf_TextBox2
            // 
            this.cf_TextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox2.Coluna_LookUp = 0;
            this.cf_TextBox2.ControlSource = "Desc_subGrupo_Produto";
            this.cf_TextBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox2.Grupo = string.Empty;
            this.cf_TextBox2.Incluir_QueryBy = true;
            this.cf_TextBox2.Location = new System.Drawing.Point(76, 68);
            this.cf_TextBox2.LookUp = false;
            this.cf_TextBox2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox2.Name = "cf_TextBox2";
            this.cf_TextBox2.Obrigatorio = false;
            this.cf_TextBox2.Qtde_Casas_Decimais = 0;
            this.cf_TextBox2.Size = new System.Drawing.Size(279, 20);
            this.cf_TextBox2.SQLStatement = string.Empty;
            this.cf_TextBox2.Tabela = "subGrupos_produtos";
            this.cf_TextBox2.Tabela_INNER = null;
            this.cf_TextBox2.TabIndex = 3;
            this.cf_TextBox2.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox2.ValorAnterior = string.Empty;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(13, 71);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Descrição:";
            // 
            // cf_CheckBox1
            // 
            this.cf_CheckBox1.AutoSize = true;
            this.cf_CheckBox1.ControlSource = "Inativo";
            this.cf_CheckBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox1.Grupo = string.Empty;
            this.cf_CheckBox1.Location = new System.Drawing.Point(295, 17);
            this.cf_CheckBox1.MensagemObrigatorio = string.Empty;
            this.cf_CheckBox1.Name = "cf_CheckBox1";
            this.cf_CheckBox1.Obrigatorio = false;
            this.cf_CheckBox1.Size = new System.Drawing.Size(60, 17);
            this.cf_CheckBox1.Tabela = "subGrupos_produtos";
            this.cf_CheckBox1.Tabela_INNER = null;
            this.cf_CheckBox1.TabIndex = 4;
            this.cf_CheckBox1.Text = "Inativo";
            this.cf_CheckBox1.UseVisualStyleBackColor = true;
            this.cf_CheckBox1.ValorAnterior = false;
            // 
            // cf_ComboBox1
            // 
            this.cf_ComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox1.ControlSource = "Grupo_produto";
            this.cf_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox1.FormattingEnabled = true;
            this.cf_ComboBox1.Grupo = string.Empty;
            this.cf_ComboBox1.Location = new System.Drawing.Point(76, 41);
            this.cf_ComboBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox1.Name = "cf_ComboBox1";
            this.cf_ComboBox1.Obrigatorio = false;
            this.cf_ComboBox1.Size = new System.Drawing.Size(279, 21);
            this.cf_ComboBox1.SQLStatement = "select * from grupos_produtos order by desc_grupo_produto";
            this.cf_ComboBox1.Tabela = "subgrupos_produtos";
            this.cf_ComboBox1.Tabela_INNER = null;
            this.cf_ComboBox1.TabIndex = 5;
            this.cf_ComboBox1.ValorAnterior = string.Empty;
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(30, 45);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(40, 13);
            this.cf_Label3.TabIndex = 6;
            this.cf_Label3.Text = "Grupo:";
            // 
            // f0041
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 99);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_ComboBox1);
            this.Controls.Add(this.cf_CheckBox1);
            this.Controls.Add(this.cf_TextBox2);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_TextBox1);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "SubGrupos_Produtos";
            this.Name = "f0041";
            this.Text = "Sub-grupos de produtos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox2;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox1;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
    }
}