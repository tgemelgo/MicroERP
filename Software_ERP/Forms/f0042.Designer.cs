namespace ERP.Forms
{
    partial class f0042
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
            this.cf_ComboBox1 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_ComboBox2 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cboEstado = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cf_CheckBox1 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_CheckBox2 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_CheckBox3 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_CheckBox4 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_CheckBox5 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cmdLimparEstado = new CompSoft.cf_Bases.cf_Button();
            this.cf_CheckBox6 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_CheckBox7 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_CheckBox8 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_CheckBox9 = new CompSoft.cf_Bases.cf_CheckBox();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(23, 16);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(38, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "CFOP:";
            // 
            // cf_ComboBox1
            // 
            this.cf_ComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox1.ControlSource = "CFOP";
            this.cf_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox1.FormattingEnabled = true;
            this.cf_ComboBox1.Grupo = "";
            this.cf_ComboBox1.Incluir_QueryBy = true;
            this.cf_ComboBox1.Location = new System.Drawing.Point(67, 12);
            this.cf_ComboBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox1.Name = "cf_ComboBox1";
            this.cf_ComboBox1.Obrigatorio = false;
            this.cf_ComboBox1.ReadOnly = false;
            this.cf_ComboBox1.Size = new System.Drawing.Size(430, 21);
            this.cf_ComboBox1.SQLStatement = "select cfop, convert(varchar(10), cfop) + \' - \' + desc_cfop from cfops where inat" +
                "ivo = 0 order by cfop";
            this.cf_ComboBox1.Tabela = "cfops_regras";
            this.cf_ComboBox1.Tabela_INNER = null;
            this.cf_ComboBox1.TabIndex = 1;
            this.cf_ComboBox1.ValorAnterior = null;
            this.cf_ComboBox1.Value = null;
            // 
            // cf_ComboBox2
            // 
            this.cf_ComboBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox2.ControlSource = "Empresa";
            this.cf_ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox2.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox2.FormattingEnabled = true;
            this.cf_ComboBox2.Grupo = "";
            this.cf_ComboBox2.Incluir_QueryBy = true;
            this.cf_ComboBox2.Location = new System.Drawing.Point(67, 39);
            this.cf_ComboBox2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox2.Name = "cf_ComboBox2";
            this.cf_ComboBox2.Obrigatorio = false;
            this.cf_ComboBox2.ReadOnly = false;
            this.cf_ComboBox2.Size = new System.Drawing.Size(430, 21);
            this.cf_ComboBox2.SQLStatement = "select empresa, nome_fantasia from empresas where inativo = 0 order by nome_fanta" +
                "sia";
            this.cf_ComboBox2.Tabela = "cfops_regras";
            this.cf_ComboBox2.Tabela_INNER = null;
            this.cf_ComboBox2.TabIndex = 3;
            this.cf_ComboBox2.ValorAnterior = null;
            this.cf_ComboBox2.Value = null;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(9, 43);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(52, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Empresa:";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboEstado.ControlSource = "Estado";
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEstado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.ForeColor = System.Drawing.Color.DimGray;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Grupo = "";
            this.cboEstado.Incluir_QueryBy = true;
            this.cboEstado.Location = new System.Drawing.Point(67, 66);
            this.cboEstado.MensagemObrigatorio = "Campo obrigatório";
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Obrigatorio = false;
            this.cboEstado.ReadOnly = false;
            this.cboEstado.Size = new System.Drawing.Size(66, 21);
            this.cboEstado.SQLStatement = "select estado, estado as \'e1\' from estados order by estado";
            this.cboEstado.Tabela = "cfops_regras";
            this.cboEstado.Tabela_INNER = null;
            this.cboEstado.TabIndex = 5;
            this.cboEstado.ValorAnterior = null;
            this.cboEstado.Value = null;
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(17, 70);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(44, 13);
            this.cf_Label3.TabIndex = 4;
            this.cf_Label3.Text = "Estado:";
            // 
            // cf_CheckBox1
            // 
            this.cf_CheckBox1.AutoSize = true;
            this.cf_CheckBox1.ControlSource = "Com_ST";
            this.cf_CheckBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox1.Grupo = "";
            this.cf_CheckBox1.Incluir_QueryBy = false;
            this.cf_CheckBox1.Location = new System.Drawing.Point(67, 93);
            this.cf_CheckBox1.MensagemObrigatorio = "";
            this.cf_CheckBox1.Name = "cf_CheckBox1";
            this.cf_CheckBox1.Obrigatorio = false;
            this.cf_CheckBox1.ReadOnly = false;
            this.cf_CheckBox1.Size = new System.Drawing.Size(154, 17);
            this.cf_CheckBox1.Tabela = "cfops_regras";
            this.cf_CheckBox1.Tabela_INNER = null;
            this.cf_CheckBox1.TabIndex = 7;
            this.cf_CheckBox1.Text = "Com substituição tributária";
            this.cf_CheckBox1.UseVisualStyleBackColor = true;
            this.cf_CheckBox1.ValorAnterior = false;
            this.cf_CheckBox1.Value = false;
            // 
            // cf_CheckBox2
            // 
            this.cf_CheckBox2.AutoSize = true;
            this.cf_CheckBox2.ControlSource = "Consumidor_Final";
            this.cf_CheckBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox2.Grupo = "";
            this.cf_CheckBox2.Incluir_QueryBy = false;
            this.cf_CheckBox2.Location = new System.Drawing.Point(365, 116);
            this.cf_CheckBox2.MensagemObrigatorio = "";
            this.cf_CheckBox2.Name = "cf_CheckBox2";
            this.cf_CheckBox2.Obrigatorio = false;
            this.cf_CheckBox2.ReadOnly = false;
            this.cf_CheckBox2.Size = new System.Drawing.Size(107, 17);
            this.cf_CheckBox2.Tabela = "cfops_regras";
            this.cf_CheckBox2.Tabela_INNER = null;
            this.cf_CheckBox2.TabIndex = 14;
            this.cf_CheckBox2.Text = "Consumidor Final";
            this.cf_CheckBox2.UseVisualStyleBackColor = true;
            this.cf_CheckBox2.ValorAnterior = false;
            this.cf_CheckBox2.Value = false;
            // 
            // cf_CheckBox3
            // 
            this.cf_CheckBox3.AutoSize = true;
            this.cf_CheckBox3.ControlSource = "Revenda";
            this.cf_CheckBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox3.Grupo = "";
            this.cf_CheckBox3.Incluir_QueryBy = false;
            this.cf_CheckBox3.Location = new System.Drawing.Point(365, 139);
            this.cf_CheckBox3.MensagemObrigatorio = "";
            this.cf_CheckBox3.Name = "cf_CheckBox3";
            this.cf_CheckBox3.Obrigatorio = false;
            this.cf_CheckBox3.ReadOnly = false;
            this.cf_CheckBox3.Size = new System.Drawing.Size(69, 17);
            this.cf_CheckBox3.Tabela = "cfops_regras";
            this.cf_CheckBox3.Tabela_INNER = null;
            this.cf_CheckBox3.TabIndex = 15;
            this.cf_CheckBox3.Text = "Revenda";
            this.cf_CheckBox3.UseVisualStyleBackColor = true;
            this.cf_CheckBox3.ValorAnterior = false;
            this.cf_CheckBox3.Value = false;
            // 
            // cf_CheckBox4
            // 
            this.cf_CheckBox4.AutoSize = true;
            this.cf_CheckBox4.ControlSource = "Bonificacao";
            this.cf_CheckBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox4.Grupo = "";
            this.cf_CheckBox4.Incluir_QueryBy = false;
            this.cf_CheckBox4.Location = new System.Drawing.Point(365, 93);
            this.cf_CheckBox4.MensagemObrigatorio = "";
            this.cf_CheckBox4.Name = "cf_CheckBox4";
            this.cf_CheckBox4.Obrigatorio = false;
            this.cf_CheckBox4.ReadOnly = false;
            this.cf_CheckBox4.Size = new System.Drawing.Size(80, 17);
            this.cf_CheckBox4.Tabela = "cfops_regras";
            this.cf_CheckBox4.Tabela_INNER = null;
            this.cf_CheckBox4.TabIndex = 13;
            this.cf_CheckBox4.Text = "Bonificação";
            this.cf_CheckBox4.UseVisualStyleBackColor = true;
            this.cf_CheckBox4.ValorAnterior = false;
            this.cf_CheckBox4.Value = false;
            // 
            // cf_CheckBox5
            // 
            this.cf_CheckBox5.AutoSize = true;
            this.cf_CheckBox5.ControlSource = "Sem_ST";
            this.cf_CheckBox5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox5.Grupo = "";
            this.cf_CheckBox5.Incluir_QueryBy = false;
            this.cf_CheckBox5.Location = new System.Drawing.Point(67, 116);
            this.cf_CheckBox5.MensagemObrigatorio = "";
            this.cf_CheckBox5.Name = "cf_CheckBox5";
            this.cf_CheckBox5.Obrigatorio = false;
            this.cf_CheckBox5.ReadOnly = false;
            this.cf_CheckBox5.Size = new System.Drawing.Size(153, 17);
            this.cf_CheckBox5.Tabela = "cfops_regras";
            this.cf_CheckBox5.Tabela_INNER = null;
            this.cf_CheckBox5.TabIndex = 8;
            this.cf_CheckBox5.Text = "Sem substituição tributária";
            this.cf_CheckBox5.UseVisualStyleBackColor = true;
            this.cf_CheckBox5.ValorAnterior = false;
            this.cf_CheckBox5.Value = false;
            // 
            // cmdLimparEstado
            // 
            this.cmdLimparEstado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLimparEstado.ForeColor = System.Drawing.Color.Black;
            this.cmdLimparEstado.Grupo = "";
            this.cmdLimparEstado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLimparEstado.Location = new System.Drawing.Point(139, 65);
            this.cmdLimparEstado.Name = "cmdLimparEstado";
            this.cmdLimparEstado.ReadOnly = false;
            this.cmdLimparEstado.Size = new System.Drawing.Size(82, 23);
            this.cmdLimparEstado.TabIndex = 6;
            this.cmdLimparEstado.TabStop = false;
            this.cmdLimparEstado.Text = "&Limpar Estado";
            this.cmdLimparEstado.UseVisualStyleBackColor = true;
            this.cmdLimparEstado.Click += new System.EventHandler(this.cmdLimparEstado_Click);
            // 
            // cf_CheckBox6
            // 
            this.cf_CheckBox6.AutoSize = true;
            this.cf_CheckBox6.ControlSource = "remessa_deposito";
            this.cf_CheckBox6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox6.Grupo = "";
            this.cf_CheckBox6.Incluir_QueryBy = false;
            this.cf_CheckBox6.Location = new System.Drawing.Point(67, 139);
            this.cf_CheckBox6.MensagemObrigatorio = "";
            this.cf_CheckBox6.Name = "cf_CheckBox6";
            this.cf_CheckBox6.Obrigatorio = false;
            this.cf_CheckBox6.ReadOnly = false;
            this.cf_CheckBox6.Size = new System.Drawing.Size(138, 17);
            this.cf_CheckBox6.Tabela = "cfops_regras";
            this.cf_CheckBox6.Tabela_INNER = null;
            this.cf_CheckBox6.TabIndex = 9;
            this.cf_CheckBox6.Text = "Remessa para deposito";
            this.cf_CheckBox6.UseVisualStyleBackColor = true;
            this.cf_CheckBox6.ValorAnterior = false;
            this.cf_CheckBox6.Value = false;
            // 
            // cf_CheckBox7
            // 
            this.cf_CheckBox7.AutoSize = true;
            this.cf_CheckBox7.ControlSource = "devolucao";
            this.cf_CheckBox7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox7.Grupo = "";
            this.cf_CheckBox7.Incluir_QueryBy = false;
            this.cf_CheckBox7.Location = new System.Drawing.Point(227, 139);
            this.cf_CheckBox7.MensagemObrigatorio = "";
            this.cf_CheckBox7.Name = "cf_CheckBox7";
            this.cf_CheckBox7.Obrigatorio = false;
            this.cf_CheckBox7.ReadOnly = false;
            this.cf_CheckBox7.Size = new System.Drawing.Size(76, 17);
            this.cf_CheckBox7.Tabela = "cfops_regras";
            this.cf_CheckBox7.Tabela_INNER = null;
            this.cf_CheckBox7.TabIndex = 12;
            this.cf_CheckBox7.Text = "Devolução";
            this.cf_CheckBox7.UseVisualStyleBackColor = true;
            this.cf_CheckBox7.ValorAnterior = false;
            this.cf_CheckBox7.Value = false;
            // 
            // cf_CheckBox8
            // 
            this.cf_CheckBox8.AutoSize = true;
            this.cf_CheckBox8.ControlSource = "Sem_Reducao";
            this.cf_CheckBox8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox8.Grupo = "";
            this.cf_CheckBox8.Incluir_QueryBy = false;
            this.cf_CheckBox8.Location = new System.Drawing.Point(227, 116);
            this.cf_CheckBox8.MensagemObrigatorio = "";
            this.cf_CheckBox8.Name = "cf_CheckBox8";
            this.cf_CheckBox8.Obrigatorio = false;
            this.cf_CheckBox8.ReadOnly = false;
            this.cf_CheckBox8.Size = new System.Drawing.Size(131, 17);
            this.cf_CheckBox8.Tabela = "cfops_regras";
            this.cf_CheckBox8.Tabela_INNER = null;
            this.cf_CheckBox8.TabIndex = 11;
            this.cf_CheckBox8.Text = "Sem redução de ICMS";
            this.cf_CheckBox8.UseVisualStyleBackColor = true;
            this.cf_CheckBox8.ValorAnterior = false;
            this.cf_CheckBox8.Value = false;
            // 
            // cf_CheckBox9
            // 
            this.cf_CheckBox9.AutoSize = true;
            this.cf_CheckBox9.ControlSource = "Com_Reducao";
            this.cf_CheckBox9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox9.Grupo = "";
            this.cf_CheckBox9.Incluir_QueryBy = false;
            this.cf_CheckBox9.Location = new System.Drawing.Point(227, 93);
            this.cf_CheckBox9.MensagemObrigatorio = "";
            this.cf_CheckBox9.Name = "cf_CheckBox9";
            this.cf_CheckBox9.Obrigatorio = false;
            this.cf_CheckBox9.ReadOnly = false;
            this.cf_CheckBox9.Size = new System.Drawing.Size(132, 17);
            this.cf_CheckBox9.Tabela = "cfops_regras";
            this.cf_CheckBox9.Tabela_INNER = null;
            this.cf_CheckBox9.TabIndex = 10;
            this.cf_CheckBox9.Text = "Com redução de ICMS";
            this.cf_CheckBox9.UseVisualStyleBackColor = true;
            this.cf_CheckBox9.ValorAnterior = false;
            this.cf_CheckBox9.Value = false;
            // 
            // f0042
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 170);
            this.Controls.Add(this.cf_CheckBox8);
            this.Controls.Add(this.cf_CheckBox9);
            this.Controls.Add(this.cf_CheckBox6);
            this.Controls.Add(this.cf_CheckBox7);
            this.Controls.Add(this.cmdLimparEstado);
            this.Controls.Add(this.cf_CheckBox5);
            this.Controls.Add(this.cf_CheckBox4);
            this.Controls.Add(this.cf_CheckBox3);
            this.Controls.Add(this.cf_CheckBox2);
            this.Controls.Add(this.cf_CheckBox1);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_ComboBox2);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_ComboBox1);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "cfops_regras";
            this.Name = "f0042";
            this.Text = "Regras para CFOP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox1;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox2;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_ComboBox cboEstado;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox1;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox2;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox3;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox4;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox5;
        private CompSoft.cf_Bases.cf_Button cmdLimparEstado;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox6;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox7;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox8;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox9;
    }
}