namespace ERP.Forms
{
    partial class f0024
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
            this.txtRelatorio = new CompSoft.cf_Bases.cf_TextBox();
            this.txtFormulario = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtNomeRelatorio = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.txtDescricao_Formulario = new CompSoft.cf_Bases.cf_TextBox();
            this.txtNamespace = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.txtClasseReport = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label5 = new CompSoft.cf_Bases.cf_Label();
            this.txtDescricao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label6 = new CompSoft.cf_Bases.cf_Label();
            this.chkAtivo = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_CheckBox1 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cf_CheckBox2 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_ComboBox1 = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label7 = new CompSoft.cf_Bases.cf_Label();
            this.cf_GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(35, 11);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(54, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Relatório:";
            // 
            // txtRelatorio
            // 
            this.txtRelatorio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRelatorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRelatorio.Coluna_LookUp = 0;
            this.txtRelatorio.ControlSource = "Menu_Item_Relatorio";
            this.txtRelatorio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelatorio.ForeColor = System.Drawing.Color.DimGray;
            this.txtRelatorio.Grupo = string.Empty;
            this.txtRelatorio.Incluir_QueryBy = true;
            this.txtRelatorio.Location = new System.Drawing.Point(95, 8);
            this.txtRelatorio.LookUp = false;
            this.txtRelatorio.MensagemObrigatorio = "Campo obrigatório";
            this.txtRelatorio.Name = "txtRelatorio";
            this.txtRelatorio.Obrigatorio = false;
            this.txtRelatorio.Qtde_Casas_Decimais = 0;
            this.txtRelatorio.Size = new System.Drawing.Size(69, 20);
            this.txtRelatorio.SQLStatement = string.Empty;
            this.txtRelatorio.Tabela = "menus_itens_relatorios";
            this.txtRelatorio.Tabela_INNER = null;
            this.txtRelatorio.TabIndex = 1;
            this.txtRelatorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRelatorio.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtRelatorio.ValorAnterior = string.Empty;
            // 
            // txtFormulario
            // 
            this.txtFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtFormulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFormulario.Coluna_LookUp = 0;
            this.txtFormulario.ControlSource = "Menu_Item";
            this.txtFormulario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormulario.ForeColor = System.Drawing.Color.Black;
            this.txtFormulario.Grupo = string.Empty;
            this.txtFormulario.Incluir_QueryBy = true;
            this.txtFormulario.Location = new System.Drawing.Point(95, 60);
            this.txtFormulario.LookUp = true;
            this.txtFormulario.MensagemObrigatorio = "Campo obrigatório";
            this.txtFormulario.Name = "txtFormulario";
            this.txtFormulario.Obrigatorio = false;
            this.txtFormulario.Qtde_Casas_Decimais = 0;
            this.txtFormulario.Size = new System.Drawing.Size(69, 20);
            this.txtFormulario.SQLStatement = "select Menu_Item, Descricao, Formulario from menus_Itens where formulario not lik" +
                "e \'\' and Menu_Item@";
            this.txtFormulario.Tabela = "menus_itens_relatorios";
            this.txtFormulario.Tabela_INNER = null;
            this.txtFormulario.TabIndex = 6;
            this.txtFormulario.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtFormulario.ValorAnterior = string.Empty;
            this.txtFormulario.Validating += new System.ComponentModel.CancelEventHandler(this.txtFormulario_Validating);
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(28, 63);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(61, 13);
            this.cf_Label2.TabIndex = 5;
            this.cf_Label2.Text = "Formulário:";
            // 
            // txtNomeRelatorio
            // 
            this.txtNomeRelatorio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNomeRelatorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeRelatorio.Coluna_LookUp = 0;
            this.txtNomeRelatorio.ControlSource = "Nome_Relatorio";
            this.txtNomeRelatorio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeRelatorio.ForeColor = System.Drawing.Color.DimGray;
            this.txtNomeRelatorio.Grupo = string.Empty;
            this.txtNomeRelatorio.Incluir_QueryBy = true;
            this.txtNomeRelatorio.Location = new System.Drawing.Point(95, 34);
            this.txtNomeRelatorio.LookUp = false;
            this.txtNomeRelatorio.MensagemObrigatorio = "Campo obrigatório";
            this.txtNomeRelatorio.Name = "txtNomeRelatorio";
            this.txtNomeRelatorio.Obrigatorio = false;
            this.txtNomeRelatorio.Qtde_Casas_Decimais = 0;
            this.txtNomeRelatorio.Size = new System.Drawing.Size(320, 20);
            this.txtNomeRelatorio.SQLStatement = string.Empty;
            this.txtNomeRelatorio.Tabela = "menus_itens_relatorios";
            this.txtNomeRelatorio.Tabela_INNER = null;
            this.txtNomeRelatorio.TabIndex = 4;
            this.txtNomeRelatorio.TipoControles = CompSoft.TipoControle.Geral;
            this.txtNomeRelatorio.ValorAnterior = string.Empty;
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(8, 37);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(81, 13);
            this.cf_Label3.TabIndex = 3;
            this.cf_Label3.Text = "Nome relatório:";
            // 
            // txtDescricao_Formulario
            // 
            this.txtDescricao_Formulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtDescricao_Formulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao_Formulario.Coluna_LookUp = 1;
            this.txtDescricao_Formulario.ControlSource = "Descricao";
            this.txtDescricao_Formulario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao_Formulario.ForeColor = System.Drawing.Color.Black;
            this.txtDescricao_Formulario.Grupo = string.Empty;
            this.txtDescricao_Formulario.Incluir_QueryBy = true;
            this.txtDescricao_Formulario.Location = new System.Drawing.Point(170, 60);
            this.txtDescricao_Formulario.LookUp = true;
            this.txtDescricao_Formulario.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao_Formulario.Name = "txtDescricao_Formulario";
            this.txtDescricao_Formulario.Obrigatorio = false;
            this.txtDescricao_Formulario.Qtde_Casas_Decimais = 0;
            this.txtDescricao_Formulario.Size = new System.Drawing.Size(245, 20);
            this.txtDescricao_Formulario.SQLStatement = "select Menu_Item, Descricao, Formulario from menus_Itens where formulario not lik" +
                "e \'\' and Descricao@";
            this.txtDescricao_Formulario.Tabela = "menus_itens_relatorios";
            this.txtDescricao_Formulario.Tabela_INNER = "mi";
            this.txtDescricao_Formulario.TabIndex = 7;
            this.txtDescricao_Formulario.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao_Formulario.ValorAnterior = string.Empty;
            this.txtDescricao_Formulario.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescricao_Formulario_Validating);
            // 
            // txtNamespace
            // 
            this.txtNamespace.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNamespace.Coluna_LookUp = 0;
            this.txtNamespace.ControlSource = "NameSpace";
            this.txtNamespace.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamespace.ForeColor = System.Drawing.Color.DimGray;
            this.txtNamespace.Grupo = string.Empty;
            this.txtNamespace.Incluir_QueryBy = true;
            this.txtNamespace.Location = new System.Drawing.Point(95, 86);
            this.txtNamespace.LookUp = false;
            this.txtNamespace.MensagemObrigatorio = "Campo obrigatório";
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Obrigatorio = false;
            this.txtNamespace.Qtde_Casas_Decimais = 0;
            this.txtNamespace.Size = new System.Drawing.Size(136, 20);
            this.txtNamespace.SQLStatement = string.Empty;
            this.txtNamespace.Tabela = "menus_itens_relatorios";
            this.txtNamespace.Tabela_INNER = null;
            this.txtNamespace.TabIndex = 9;
            this.txtNamespace.TipoControles = CompSoft.TipoControle.Geral;
            this.txtNamespace.ValorAnterior = string.Empty;
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(22, 89);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(67, 13);
            this.cf_Label4.TabIndex = 8;
            this.cf_Label4.Text = "NameSpace:";
            // 
            // txtClasseReport
            // 
            this.txtClasseReport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtClasseReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClasseReport.Coluna_LookUp = 0;
            this.txtClasseReport.ControlSource = "Relatorio";
            this.txtClasseReport.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClasseReport.ForeColor = System.Drawing.Color.DimGray;
            this.txtClasseReport.Grupo = string.Empty;
            this.txtClasseReport.Incluir_QueryBy = true;
            this.txtClasseReport.Location = new System.Drawing.Point(331, 86);
            this.txtClasseReport.LookUp = false;
            this.txtClasseReport.MensagemObrigatorio = "Campo obrigatório";
            this.txtClasseReport.Name = "txtClasseReport";
            this.txtClasseReport.Obrigatorio = false;
            this.txtClasseReport.Qtde_Casas_Decimais = 0;
            this.txtClasseReport.Size = new System.Drawing.Size(84, 20);
            this.txtClasseReport.SQLStatement = string.Empty;
            this.txtClasseReport.Tabela = "menus_itens_relatorios";
            this.txtClasseReport.Tabela_INNER = null;
            this.txtClasseReport.TabIndex = 11;
            this.txtClasseReport.TipoControles = CompSoft.TipoControle.Geral;
            this.txtClasseReport.ValorAnterior = string.Empty;
            // 
            // cf_Label5
            // 
            this.cf_Label5.AutoSize = true;
            this.cf_Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label5.Location = new System.Drawing.Point(240, 89);
            this.cf_Label5.Name = "cf_Label5";
            this.cf_Label5.Size = new System.Drawing.Size(85, 13);
            this.cf_Label5.TabIndex = 10;
            this.cf_Label5.Text = "Classe relatório:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Coluna_LookUp = 0;
            this.txtDescricao.ControlSource = "Descricao_Relatorio";
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricao.Grupo = string.Empty;
            this.txtDescricao.Incluir_QueryBy = true;
            this.txtDescricao.Location = new System.Drawing.Point(95, 113);
            this.txtDescricao.LookUp = false;
            this.txtDescricao.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Obrigatorio = false;
            this.txtDescricao.Qtde_Casas_Decimais = 0;
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(320, 62);
            this.txtDescricao.SQLStatement = string.Empty;
            this.txtDescricao.Tabela = "menus_itens_relatorios";
            this.txtDescricao.Tabela_INNER = null;
            this.txtDescricao.TabIndex = 13;
            this.txtDescricao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao.ValorAnterior = string.Empty;
            // 
            // cf_Label6
            // 
            this.cf_Label6.AutoSize = true;
            this.cf_Label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label6.Location = new System.Drawing.Point(32, 116);
            this.cf_Label6.Name = "cf_Label6";
            this.cf_Label6.Size = new System.Drawing.Size(57, 13);
            this.cf_Label6.TabIndex = 12;
            this.cf_Label6.Text = "Descrição:";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.ControlSource = "Ativo";
            this.chkAtivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAtivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivo.Grupo = string.Empty;
            this.chkAtivo.Location = new System.Drawing.Point(361, 12);
            this.chkAtivo.MensagemObrigatorio = string.Empty;
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Obrigatorio = false;
            this.chkAtivo.Size = new System.Drawing.Size(54, 17);
            this.chkAtivo.Tabela = "menus_itens_relatorios";
            this.chkAtivo.Tabela_INNER = null;
            this.chkAtivo.TabIndex = 2;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            this.chkAtivo.ValorAnterior = false;
            // 
            // cf_CheckBox1
            // 
            this.cf_CheckBox1.AutoSize = true;
            this.cf_CheckBox1.ControlSource = "RegAtual_Enable";
            this.cf_CheckBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox1.Grupo = string.Empty;
            this.cf_CheckBox1.Location = new System.Drawing.Point(6, 20);
            this.cf_CheckBox1.MensagemObrigatorio = string.Empty;
            this.cf_CheckBox1.Name = "cf_CheckBox1";
            this.cf_CheckBox1.Obrigatorio = false;
            this.cf_CheckBox1.Size = new System.Drawing.Size(93, 17);
            this.cf_CheckBox1.Tabela = "menus_itens_relatorios";
            this.cf_CheckBox1.Tabela_INNER = null;
            this.cf_CheckBox1.TabIndex = 14;
            this.cf_CheckBox1.Text = "Registro atual";
            this.cf_CheckBox1.UseVisualStyleBackColor = true;
            this.cf_CheckBox1.ValorAnterior = false;
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.cf_CheckBox2);
            this.cf_GroupBox1.Controls.Add(this.cf_CheckBox1);
            this.cf_GroupBox1.ControlSource = string.Empty;
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(427, 8);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(124, 61);
            this.cf_GroupBox1.Tabela = string.Empty;
            this.cf_GroupBox1.TabIndex = 15;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Habilita as opções";
            this.cf_GroupBox1.Value = string.Empty;
            // 
            // cf_CheckBox2
            // 
            this.cf_CheckBox2.AutoSize = true;
            this.cf_CheckBox2.ControlSource = "TodosReg_Enable";
            this.cf_CheckBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox2.Grupo = string.Empty;
            this.cf_CheckBox2.Location = new System.Drawing.Point(6, 37);
            this.cf_CheckBox2.MensagemObrigatorio = string.Empty;
            this.cf_CheckBox2.Name = "cf_CheckBox2";
            this.cf_CheckBox2.Obrigatorio = false;
            this.cf_CheckBox2.Size = new System.Drawing.Size(114, 17);
            this.cf_CheckBox2.Tabela = "menus_itens_relatorios";
            this.cf_CheckBox2.Tabela_INNER = null;
            this.cf_CheckBox2.TabIndex = 15;
            this.cf_CheckBox2.Text = "Todos os registros";
            this.cf_CheckBox2.UseVisualStyleBackColor = true;
            this.cf_CheckBox2.ValorAnterior = false;
            // 
            // cf_ComboBox1
            // 
            this.cf_ComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_ComboBox1.ControlSource = "Value_Enable";
            this.cf_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cf_ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cf_ComboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_ComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_ComboBox1.FormattingEnabled = true;
            this.cf_ComboBox1.Grupo = string.Empty;
            this.cf_ComboBox1.Location = new System.Drawing.Point(430, 88);
            this.cf_ComboBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_ComboBox1.Name = "cf_ComboBox1";
            this.cf_ComboBox1.Obrigatorio = false;
            this.cf_ComboBox1.Size = new System.Drawing.Size(121, 21);
            this.cf_ComboBox1.SQLStatement = "select 1 as [Values], \'Registro atual\' as \'Desc\' union select 2 as [Values], \'Tod" +
                "os os registros\' as \'Desc\'";
            this.cf_ComboBox1.Tabela = "menus_itens_relatorios";
            this.cf_ComboBox1.Tabela_INNER = null;
            this.cf_ComboBox1.TabIndex = 16;
            this.cf_ComboBox1.ValorAnterior = string.Empty;
            // 
            // cf_Label7
            // 
            this.cf_Label7.AutoSize = true;
            this.cf_Label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label7.Location = new System.Drawing.Point(430, 72);
            this.cf_Label7.Name = "cf_Label7";
            this.cf_Label7.Size = new System.Drawing.Size(97, 13);
            this.cf_Label7.TabIndex = 17;
            this.cf_Label7.Text = "Opção selecionada";
            // 
            // f0024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 186);
            this.Controls.Add(this.cf_Label7);
            this.Controls.Add(this.cf_ComboBox1);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.txtFormulario);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cf_Label6);
            this.Controls.Add(this.txtClasseReport);
            this.Controls.Add(this.cf_Label5);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.txtDescricao_Formulario);
            this.Controls.Add(this.txtNomeRelatorio);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtRelatorio);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "menus_itens_relatorios";
            this.Name = "f0024";
            this.Text = "Relatórios disponiveis no sistema";
            this.user_AfterNew += new CompSoft.FormSet.AfterNew(this.f0024_user_AfterNew);
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtRelatorio;
        private CompSoft.cf_Bases.cf_TextBox txtFormulario;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtNomeRelatorio;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao_Formulario;
        private CompSoft.cf_Bases.cf_TextBox txtNamespace;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_TextBox txtClasseReport;
        private CompSoft.cf_Bases.cf_Label cf_Label5;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao;
        private CompSoft.cf_Bases.cf_Label cf_Label6;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivo;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox1;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox2;
        private CompSoft.cf_Bases.cf_ComboBox cf_ComboBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label7;
    }
}