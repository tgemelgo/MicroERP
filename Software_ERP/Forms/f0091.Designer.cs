namespace ERP.Forms
{
    partial class f0091
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cboEmpresa = new CompSoft.cf_Bases.cf_ComboBox();
            this.chkAtivar_Empresa = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_Pageframe1 = new CompSoft.cf_Bases.cf_Pageframe();
            this.cmdGerar = new CompSoft.cf_Bases.cf_Button();
            this.cf_TextBox1 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cmdDiretorio = new CompSoft.cf_Bases.cf_Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabPage1.SuspendLayout();
            this.cf_GroupBox2.SuspendLayout();
            this.cf_Pageframe1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmdDiretorio);
            this.tabPage1.Controls.Add(this.cf_Label1);
            this.tabPage1.Controls.Add(this.cf_TextBox1);
            this.tabPage1.Controls.Add(this.cmdGerar);
            this.tabPage1.Controls.Add(this.chkAtivar_Empresa);
            this.tabPage1.Controls.Add(this.cf_GroupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filtro avançado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.cboEmpresa);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(29, 33);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(465, 55);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 6;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Empresa";
            this.cf_GroupBox2.Value = "";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboEmpresa.ControlSource = "";
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.ForeColor = System.Drawing.Color.DimGray;
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Grupo = "";
            this.cboEmpresa.Incluir_QueryBy = true;
            this.cboEmpresa.Incluir_Reg_Selecione = false;
            this.cboEmpresa.Location = new System.Drawing.Point(10, 22);
            this.cboEmpresa.MensagemObrigatorio = "Campo obrigatório";
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Obrigatorio = false;
            this.cboEmpresa.ReadOnly = false;
            this.cboEmpresa.Size = new System.Drawing.Size(442, 21);
            this.cboEmpresa.SQLStatement = "SELECT EMPRESA, NOME_FANTASIA FROM EMPRESAS ORDER BY 2";
            this.cboEmpresa.Tabela = "";
            this.cboEmpresa.Tabela_INNER = null;
            this.cboEmpresa.TabIndex = 3;
            this.cboEmpresa.ValorAnterior = null;
            this.cboEmpresa.Value = null;
            // 
            // chkAtivar_Empresa
            // 
            this.chkAtivar_Empresa.AutoSize = true;
            this.chkAtivar_Empresa.ControlSource = "";
            this.chkAtivar_Empresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivar_Empresa.Grupo = "";
            this.chkAtivar_Empresa.Incluir_QueryBy = false;
            this.chkAtivar_Empresa.Location = new System.Drawing.Point(439, 23);
            this.chkAtivar_Empresa.MensagemObrigatorio = "";
            this.chkAtivar_Empresa.Name = "chkAtivar_Empresa";
            this.chkAtivar_Empresa.Obrigatorio = false;
            this.chkAtivar_Empresa.ReadOnly = false;
            this.chkAtivar_Empresa.Size = new System.Drawing.Size(55, 17);
            this.chkAtivar_Empresa.Tabela = "";
            this.chkAtivar_Empresa.Tabela_INNER = null;
            this.chkAtivar_Empresa.TabIndex = 5;
            this.chkAtivar_Empresa.Text = "Ativar";
            this.chkAtivar_Empresa.UseVisualStyleBackColor = true;
            this.chkAtivar_Empresa.ValorAnterior = false;
            this.chkAtivar_Empresa.Value = false;
            // 
            // cf_Pageframe1
            // 
            this.cf_Pageframe1.Controls.Add(this.tabPage1);
            this.cf_Pageframe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cf_Pageframe1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Pageframe1.HotTrack = true;
            this.cf_Pageframe1.Location = new System.Drawing.Point(0, 0);
            this.cf_Pageframe1.Name = "cf_Pageframe1";
            this.cf_Pageframe1.SelectedIndex = 0;
            this.cf_Pageframe1.Size = new System.Drawing.Size(557, 358);
            this.cf_Pageframe1.TabIndex = 1;
            // 
            // cmdGerar
            // 
            this.cmdGerar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGerar.ForeColor = System.Drawing.Color.Black;
            this.cmdGerar.Grupo = "";
            this.cmdGerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdGerar.Location = new System.Drawing.Point(384, 187);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.ReadOnly = false;
            this.cmdGerar.Size = new System.Drawing.Size(97, 23);
            this.cmdGerar.TabIndex = 7;
            this.cmdGerar.TabStop = false;
            this.cmdGerar.Text = "Gerar Arquivo";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // cf_TextBox1
            // 
            this.cf_TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox1.Coluna_LookUp = 0;
            this.cf_TextBox1.ControlSource = "";
            this.cf_TextBox1.Enabled = false;
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = "";
            this.cf_TextBox1.Incluir_QueryBy = false;
            this.cf_TextBox1.Location = new System.Drawing.Point(39, 127);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = false;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(407, 20);
            this.cf_TextBox1.SQLStatement = "";
            this.cf_TextBox1.Tabela = "";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 8;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Texto;
            this.cf_TextBox1.ValorAnterior = "";
            this.cf_TextBox1.Value = "";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(36, 111);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(48, 13);
            this.cf_Label1.TabIndex = 4;
            this.cf_Label1.Text = "Diretório";
            // 
            // cmdDiretorio
            // 
            this.cmdDiretorio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDiretorio.ForeColor = System.Drawing.Color.Black;
            this.cmdDiretorio.Grupo = "";
            this.cmdDiretorio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDiretorio.Location = new System.Drawing.Point(452, 126);
            this.cmdDiretorio.Name = "cmdDiretorio";
            this.cmdDiretorio.ReadOnly = false;
            this.cmdDiretorio.Size = new System.Drawing.Size(29, 23);
            this.cmdDiretorio.TabIndex = 9;
            this.cmdDiretorio.TabStop = false;
            this.cmdDiretorio.Text = "...";
            this.cmdDiretorio.UseVisualStyleBackColor = true;
            this.cmdDiretorio.Click += new System.EventHandler(this.cmdDiretorio_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Relatorio_Cliente_Vendedor";
            this.saveFileDialog1.Filter = "Arquivos CSV|*.csv";
            // 
            // f0091
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Barra_Ferramentas_Editar_Registro = false;
            this.Barra_Ferramentas_Excluir_Registro = false;
            this.Barra_Ferramentas_Limpar_Tela = false;
            this.Barra_Ferramentas_Novo_Registro = false;
            this.Barra_Ferramentas_Pesquisar_Registro = false;
            this.Barra_Ferramentas_Relatorios = false;
            this.ClientSize = new System.Drawing.Size(557, 358);
            this.Controls.Add(this.cf_Pageframe1);
            this.MainTabela = "notas_fiscais";
            this.Name = "f0091";
            this.Text = "Vendedor por Cliente";
            this.Tipo_Formulario = CompSoft.TipoForm.Consulta;
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0071_user_AfterRefreshData);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_Pageframe1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private CompSoft.cf_Bases.cf_Button cmdDiretorio;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
        private CompSoft.cf_Bases.cf_Button cmdGerar;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivar_Empresa;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_ComboBox cboEmpresa;
        private CompSoft.cf_Bases.cf_Pageframe cf_Pageframe1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}