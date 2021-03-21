namespace ERP.Forms
{
    partial class f0027
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
            this.cf_ComboBox1 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cf_ComboBox2 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox1 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cf_ComboBox1
            // 
            this.cf_ComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox1.ControlSource = "Origem";
            this.cf_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox1.FormattingEnabled = true;
            this.cf_ComboBox1.Grupo = string.Empty;
            this.cf_ComboBox1.Location = new System.Drawing.Point(58, 17);
            this.cf_ComboBox1.MaxDropDownItems = 15;
            this.cf_ComboBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox1.Name = "cf_ComboBox1";
            this.cf_ComboBox1.Obrigatorio = false;
            this.cf_ComboBox1.Size = new System.Drawing.Size(55, 21);
            this.cf_ComboBox1.SQLStatement = "select Estado, Estado as \'E1\' from estados";
            this.cf_ComboBox1.Tabela = "ICMS_Estados";
            this.cf_ComboBox1.Tabela_INNER = null;
            this.cf_ComboBox1.TabIndex = 1;
            this.cf_ComboBox1.ValorAnterior = string.Empty;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(7, 20);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(45, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Origem:";
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.cf_ComboBox2);
            this.cf_GroupBox1.Controls.Add(this.cf_Label2);
            this.cf_GroupBox1.Controls.Add(this.cf_ComboBox1);
            this.cf_GroupBox1.Controls.Add(this.cf_Label1);
            this.cf_GroupBox1.ControlSource = string.Empty;
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(12, 5);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(248, 50);
            this.cf_GroupBox1.Tabela = string.Empty;
            this.cf_GroupBox1.TabIndex = 0;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Value = string.Empty;
            // 
            // cf_ComboBox2
            // 
            this.cf_ComboBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox2.ControlSource = "Destino";
            this.cf_ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox2.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox2.FormattingEnabled = true;
            this.cf_ComboBox2.Grupo = string.Empty;
            this.cf_ComboBox2.Location = new System.Drawing.Point(178, 17);
            this.cf_ComboBox2.MaxDropDownItems = 15;
            this.cf_ComboBox2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox2.Name = "cf_ComboBox2";
            this.cf_ComboBox2.Obrigatorio = false;
            this.cf_ComboBox2.Size = new System.Drawing.Size(55, 21);
            this.cf_ComboBox2.SQLStatement = "select Estado, Estado as \'E1\' from estados";
            this.cf_ComboBox2.Tabela = "ICMS_Estados";
            this.cf_ComboBox2.Tabela_INNER = null;
            this.cf_ComboBox2.TabIndex = 3;
            this.cf_ComboBox2.ValorAnterior = string.Empty;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(125, 20);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(47, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Destino:";
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(24, 64);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(71, 13);
            this.cf_Label3.TabIndex = 1;
            this.cf_Label3.Text = "Alicota ICMS:";
            // 
            // cf_TextBox1
            // 
            this.cf_TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox1.Coluna_LookUp = 0;
            this.cf_TextBox1.ControlSource = "Icms";
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = string.Empty;
            this.cf_TextBox1.Incluir_QueryBy = true;
            this.cf_TextBox1.Location = new System.Drawing.Point(101, 61);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MaxLength = 5;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = false;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(100, 20);
            this.cf_TextBox1.SQLStatement = string.Empty;
            this.cf_TextBox1.Tabela = "ICMS_Estados";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 2;
            this.cf_TextBox1.Text = null;
            this.cf_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Moeda;
            this.cf_TextBox1.ValorAnterior = string.Empty;
            // 
            // f0027
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 91);
            this.Controls.Add(this.cf_TextBox1);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_GroupBox1);
            this.MainTabela = "ICMS_Estados";
            this.Name = "f0027";
            this.Text = "ICMS por Estado";
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox2;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        public CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        public CompSoft.cf_Bases.cf_Label cf_Label3;
        public CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
    }
}