namespace CompSoft.Tools
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtUsuario = new CompSoft.cf_Bases.cf_TextBox();
            this.txtSenha = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.chkOpcoes = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmdFechar = new CompSoft.cf_Bases.cf_Button();
            this.cmdEntrar = new CompSoft.cf_Bases.cf_Button();
            this.grpOpcoes = new CompSoft.cf_Bases.cf_GroupBox();
            this.cf_Label5 = new CompSoft.cf_Bases.cf_Label();
            this.txtSenhaDB = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.txtUsuarioDB = new CompSoft.cf_Bases.cf_TextBox();
            this.cboDataBase = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label6 = new CompSoft.cf_Bases.cf_Label();
            this.cmdAtualizarBases = new System.Windows.Forms.PictureBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.txtServidor = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.grpOpcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAtualizarBases)).BeginInit();
            this.cf_GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Coluna_LookUp = 0;
            this.txtUsuario.ControlSource = "";
            this.txtUsuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsuario.Grupo = "";
            this.txtUsuario.Incluir_QueryBy = true;
            this.txtUsuario.Location = new System.Drawing.Point(43, 39);
            this.txtUsuario.LookUp = false;
            this.txtUsuario.MensagemObrigatorio = "Campo obrigatório";
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Obrigatorio = false;
            this.txtUsuario.Qtde_Casas_Decimais = 0;
            this.txtUsuario.Size = new System.Drawing.Size(180, 20);
            this.txtUsuario.SQLStatement = "";
            this.txtUsuario.Tabela = "";
            this.txtUsuario.Tabela_INNER = null;
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TipoControles = CompSoft.TipoControle.Geral;
            this.txtUsuario.ValorAnterior = "";
            this.txtUsuario.Value = "";
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenha.Coluna_LookUp = 0;
            this.txtSenha.ControlSource = "";
            this.txtSenha.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.ForeColor = System.Drawing.Color.DimGray;
            this.txtSenha.Grupo = "";
            this.txtSenha.Incluir_QueryBy = true;
            this.txtSenha.Location = new System.Drawing.Point(43, 76);
            this.txtSenha.LookUp = false;
            this.txtSenha.MensagemObrigatorio = "Campo obrigatório";
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Obrigatorio = false;
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Qtde_Casas_Decimais = 0;
            this.txtSenha.Size = new System.Drawing.Size(180, 20);
            this.txtSenha.SQLStatement = "";
            this.txtSenha.Tabela = "";
            this.txtSenha.Tabela_INNER = null;
            this.txtSenha.TabIndex = 3;
            this.txtSenha.TipoControles = CompSoft.TipoControle.Geral;
            this.txtSenha.ValorAnterior = "";
            this.txtSenha.Value = "";
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.ForeColor = System.Drawing.Color.White;
            this.cf_Label1.Location = new System.Drawing.Point(40, 62);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(45, 13);
            this.cf_Label1.TabIndex = 2;
            this.cf_Label1.Text = "Senha:";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.ForeColor = System.Drawing.Color.White;
            this.cf_Label2.Location = new System.Drawing.Point(40, 25);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(53, 13);
            this.cf_Label2.TabIndex = 0;
            this.cf_Label2.Text = "Usuário:";
            // 
            // chkOpcoes
            // 
            this.chkOpcoes.AutoSize = true;
            this.chkOpcoes.ForeColor = System.Drawing.Color.White;
            this.chkOpcoes.Location = new System.Drawing.Point(6, 139);
            this.chkOpcoes.Name = "chkOpcoes";
            this.chkOpcoes.Size = new System.Drawing.Size(117, 17);
            this.chkOpcoes.TabIndex = 6;
            this.chkOpcoes.Text = "Opções avançadas";
            this.chkOpcoes.UseVisualStyleBackColor = true;
            this.chkOpcoes.CheckedChanged += new System.EventHandler(this.chkOpcoes_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CompSoft.Properties.Resources.Imagem_Login;
            this.pictureBox2.Location = new System.Drawing.Point(25, 97);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // cmdFechar
            // 
            this.cmdFechar.BackColor = System.Drawing.Color.Transparent;
            this.cmdFechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdFechar.BackgroundImage")));
            this.cmdFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdFechar.FlatAppearance.BorderSize = 0;
            this.cmdFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cmdFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cmdFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFechar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.ForeColor = System.Drawing.Color.Black;
            this.cmdFechar.Grupo = "";
            this.cmdFechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdFechar.Location = new System.Drawing.Point(245, 199);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.ReadOnly = false;
            this.cmdFechar.Size = new System.Drawing.Size(40, 30);
            this.cmdFechar.TabIndex = 4;
            this.cmdFechar.TabStop = false;
            this.toolTip1.SetToolTip(this.cmdFechar, "Fechar a aplicação");
            this.cmdFechar.UseVisualStyleBackColor = false;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // cmdEntrar
            // 
            this.cmdEntrar.BackColor = System.Drawing.Color.Transparent;
            this.cmdEntrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdEntrar.BackgroundImage")));
            this.cmdEntrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdEntrar.FlatAppearance.BorderSize = 0;
            this.cmdEntrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cmdEntrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cmdEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEntrar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEntrar.ForeColor = System.Drawing.Color.Black;
            this.cmdEntrar.Grupo = "";
            this.cmdEntrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdEntrar.Location = new System.Drawing.Point(205, 199);
            this.cmdEntrar.Name = "cmdEntrar";
            this.cmdEntrar.ReadOnly = false;
            this.cmdEntrar.Size = new System.Drawing.Size(40, 30);
            this.cmdEntrar.TabIndex = 3;
            this.cmdEntrar.TabStop = false;
            this.cmdEntrar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.cmdEntrar, "Validar login e entrar na aplicação");
            this.cmdEntrar.UseVisualStyleBackColor = false;
            this.cmdEntrar.Click += new System.EventHandler(this.cmdEntrar_Click);
            // 
            // grpOpcoes
            // 
            this.grpOpcoes.Controls.Add(this.cf_Label5);
            this.grpOpcoes.Controls.Add(this.txtSenhaDB);
            this.grpOpcoes.Controls.Add(this.cf_Label4);
            this.grpOpcoes.Controls.Add(this.txtUsuarioDB);
            this.grpOpcoes.ControlSource = "";
            this.grpOpcoes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOpcoes.ForeColor = System.Drawing.Color.Black;
            this.grpOpcoes.Location = new System.Drawing.Point(53, 235);
            this.grpOpcoes.Name = "grpOpcoes";
            this.grpOpcoes.Size = new System.Drawing.Size(243, 104);
            this.grpOpcoes.Tabela = "";
            this.grpOpcoes.TabIndex = 5;
            this.grpOpcoes.TabStop = false;
            this.grpOpcoes.Value = "";
            this.grpOpcoes.Visible = false;
            // 
            // cf_Label5
            // 
            this.cf_Label5.AutoSize = true;
            this.cf_Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label5.ForeColor = System.Drawing.Color.White;
            this.cf_Label5.Location = new System.Drawing.Point(22, 57);
            this.cf_Label5.Name = "cf_Label5";
            this.cf_Label5.Size = new System.Drawing.Size(131, 13);
            this.cf_Label5.TabIndex = 2;
            this.cf_Label5.Text = "Senha do banco de dados";
            // 
            // txtSenhaDB
            // 
            this.txtSenhaDB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSenhaDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenhaDB.Coluna_LookUp = 0;
            this.txtSenhaDB.ControlSource = "";
            this.txtSenhaDB.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaDB.ForeColor = System.Drawing.Color.DimGray;
            this.txtSenhaDB.Grupo = "";
            this.txtSenhaDB.Incluir_QueryBy = true;
            this.txtSenhaDB.Location = new System.Drawing.Point(23, 75);
            this.txtSenhaDB.LookUp = false;
            this.txtSenhaDB.MensagemObrigatorio = "Campo obrigatório";
            this.txtSenhaDB.Name = "txtSenhaDB";
            this.txtSenhaDB.Obrigatorio = false;
            this.txtSenhaDB.PasswordChar = '*';
            this.txtSenhaDB.Qtde_Casas_Decimais = 0;
            this.txtSenhaDB.Size = new System.Drawing.Size(200, 20);
            this.txtSenhaDB.SQLStatement = "";
            this.txtSenhaDB.Tabela = "";
            this.txtSenhaDB.Tabela_INNER = null;
            this.txtSenhaDB.TabIndex = 3;
            this.txtSenhaDB.TipoControles = CompSoft.TipoControle.Geral;
            this.txtSenhaDB.ValorAnterior = "";
            this.txtSenhaDB.Value = "";
            this.txtSenhaDB.Validated += new System.EventHandler(this.txtSenhaDB_Validated);
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.ForeColor = System.Drawing.Color.White;
            this.cf_Label4.Location = new System.Drawing.Point(22, 17);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(137, 13);
            this.cf_Label4.TabIndex = 0;
            this.cf_Label4.Text = "Usuário do banco de dados";
            // 
            // txtUsuarioDB
            // 
            this.txtUsuarioDB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsuarioDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioDB.Coluna_LookUp = 0;
            this.txtUsuarioDB.ControlSource = "";
            this.txtUsuarioDB.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioDB.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsuarioDB.Grupo = "";
            this.txtUsuarioDB.Incluir_QueryBy = true;
            this.txtUsuarioDB.Location = new System.Drawing.Point(23, 35);
            this.txtUsuarioDB.LookUp = false;
            this.txtUsuarioDB.MensagemObrigatorio = "Campo obrigatório";
            this.txtUsuarioDB.Name = "txtUsuarioDB";
            this.txtUsuarioDB.Obrigatorio = false;
            this.txtUsuarioDB.Qtde_Casas_Decimais = 0;
            this.txtUsuarioDB.Size = new System.Drawing.Size(200, 20);
            this.txtUsuarioDB.SQLStatement = "";
            this.txtUsuarioDB.Tabela = "";
            this.txtUsuarioDB.Tabela_INNER = null;
            this.txtUsuarioDB.TabIndex = 1;
            this.txtUsuarioDB.TipoControles = CompSoft.TipoControle.Geral;
            this.txtUsuarioDB.ValorAnterior = "";
            this.txtUsuarioDB.Value = "";
            this.txtUsuarioDB.Validated += new System.EventHandler(this.txtUsuarioDB_Validated);
            // 
            // cboDataBase
            // 
            this.cboDataBase.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboDataBase.ControlSource = "";
            this.cboDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDataBase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDataBase.ForeColor = System.Drawing.Color.DimGray;
            this.cboDataBase.FormattingEnabled = true;
            this.cboDataBase.Grupo = "";
            this.cboDataBase.Incluir_QueryBy = true;
            this.cboDataBase.Location = new System.Drawing.Point(43, 116);
            this.cboDataBase.MensagemObrigatorio = "Campo obrigatório";
            this.cboDataBase.Name = "cboDataBase";
            this.cboDataBase.Obrigatorio = false;
            this.cboDataBase.ReadOnly = false;
            this.cboDataBase.Size = new System.Drawing.Size(180, 21);
            this.cboDataBase.SQLStatement = "";
            this.cboDataBase.Tabela = "";
            this.cboDataBase.Tabela_INNER = null;
            this.cboDataBase.TabIndex = 5;
            this.cboDataBase.ValorAnterior = "";
            this.cboDataBase.Value = null;
            this.cboDataBase.Enter += new System.EventHandler(this.cboDataBase_Enter);
            this.cboDataBase.Validated += new System.EventHandler(this.cboDataBase_Validated);
            // 
            // cf_Label6
            // 
            this.cf_Label6.AutoSize = true;
            this.cf_Label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.cf_Label6.ForeColor = System.Drawing.Color.White;
            this.cf_Label6.Location = new System.Drawing.Point(40, 100);
            this.cf_Label6.Name = "cf_Label6";
            this.cf_Label6.Size = new System.Drawing.Size(88, 13);
            this.cf_Label6.TabIndex = 4;
            this.cf_Label6.Text = "Base de dados";
            // 
            // cmdAtualizarBases
            // 
            this.cmdAtualizarBases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAtualizarBases.Image = global::CompSoft.Properties.Resources.Atualizar_DBs;
            this.cmdAtualizarBases.Location = new System.Drawing.Point(277, 288);
            this.cmdAtualizarBases.Name = "cmdAtualizarBases";
            this.cmdAtualizarBases.Size = new System.Drawing.Size(40, 37);
            this.cmdAtualizarBases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cmdAtualizarBases.TabIndex = 17;
            this.cmdAtualizarBases.TabStop = false;
            this.toolTip1.SetToolTip(this.cmdAtualizarBases, "Atualizar listagem de base de dados do servidor");
            this.cmdAtualizarBases.Click += new System.EventHandler(this.cmdAtualizarBases_Click);
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.ForeColor = System.Drawing.Color.White;
            this.cf_Label3.Location = new System.Drawing.Point(93, 22);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(55, 13);
            this.cf_Label3.TabIndex = 1;
            this.cf_Label3.Text = "Servidor";
            // 
            // txtServidor
            // 
            this.txtServidor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtServidor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServidor.Coluna_LookUp = 0;
            this.txtServidor.ControlSource = "";
            this.txtServidor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServidor.ForeColor = System.Drawing.Color.DimGray;
            this.txtServidor.Grupo = "";
            this.txtServidor.Incluir_QueryBy = true;
            this.txtServidor.Location = new System.Drawing.Point(96, 36);
            this.txtServidor.LookUp = false;
            this.txtServidor.MensagemObrigatorio = "Campo obrigatório";
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Obrigatorio = false;
            this.txtServidor.Qtde_Casas_Decimais = 0;
            this.txtServidor.Size = new System.Drawing.Size(180, 20);
            this.txtServidor.SQLStatement = "";
            this.txtServidor.Tabela = "";
            this.txtServidor.Tabela_INNER = null;
            this.txtServidor.TabIndex = 2;
            this.txtServidor.TabStop = false;
            this.txtServidor.TipoControles = CompSoft.TipoControle.Geral;
            this.txtServidor.ValorAnterior = "";
            this.txtServidor.Value = "";
            this.txtServidor.Validated += new System.EventHandler(this.txtServidor_Validated);
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.cboDataBase);
            this.cf_GroupBox1.Controls.Add(this.cf_Label6);
            this.cf_GroupBox1.Controls.Add(this.chkOpcoes);
            this.cf_GroupBox1.Controls.Add(this.txtUsuario);
            this.cf_GroupBox1.Controls.Add(this.txtSenha);
            this.cf_GroupBox1.Controls.Add(this.cf_Label1);
            this.cf_GroupBox1.Controls.Add(this.cf_Label2);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(53, 56);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(243, 160);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 0;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Value = "";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(344, 364);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.cmdAtualizarBases);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cmdEntrar);
            this.Controls.Add(this.cf_GroupBox1);
            this.Controls.Add(this.grpOpcoes);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.cf_Label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLogin";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompSoft Sistemas Integrados";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.grpOpcoes.ResumeLayout(false);
            this.grpOpcoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAtualizarBases)).EndInit();
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_TextBox txtUsuario;
        private CompSoft.cf_Bases.cf_TextBox txtSenha;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_Button cmdEntrar;
        private CompSoft.cf_Bases.cf_Button cmdFechar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkOpcoes;
        private CompSoft.cf_Bases.cf_GroupBox grpOpcoes;
        private CompSoft.cf_Bases.cf_Label cf_Label5;
        private CompSoft.cf_Bases.cf_TextBox txtSenhaDB;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_TextBox txtUsuarioDB;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox txtServidor;
        private System.Windows.Forms.PictureBox cmdAtualizarBases;
        private CompSoft.cf_Bases.cf_ComboBox cboDataBase;
        private CompSoft.cf_Bases.cf_Label cf_Label6;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
