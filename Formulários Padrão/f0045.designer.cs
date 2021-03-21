namespace ERP.Forms
{
    partial class f0045
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
            this.txtUsuario = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtNome_Usuario = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.txtSenha = new CompSoft.cf_Bases.cf_TextBox();
            this.chkAtivo = new CompSoft.cf_Bases.cf_CheckBox();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Coluna_LookUp = 0;
            this.txtUsuario.ControlSource = "Usuario";
            this.txtUsuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsuario.Grupo = string.Empty;
            this.txtUsuario.Incluir_QueryBy = true;
            this.txtUsuario.Location = new System.Drawing.Point(97, 12);
            this.txtUsuario.LookUp = false;
            this.txtUsuario.MensagemObrigatorio = "Campo obrigatório";
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Obrigatorio = false;
            this.txtUsuario.Size = new System.Drawing.Size(72, 20);
            this.txtUsuario.SQLStatement = string.Empty;
            this.txtUsuario.Tabela = "Usuarios";
            this.txtUsuario.Tabela_INNER = null;
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtUsuario.ValorAnterior = string.Empty;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(44, 15);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(47, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Usuário:";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(15, 40);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(76, 13);
            this.cf_Label2.TabIndex = 3;
            this.cf_Label2.Text = "Nome usuário:";
            // 
            // txtNome_Usuario
            // 
            this.txtNome_Usuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNome_Usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome_Usuario.Coluna_LookUp = 0;
            this.txtNome_Usuario.ControlSource = "Nome_Usuario";
            this.txtNome_Usuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome_Usuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtNome_Usuario.Grupo = string.Empty;
            this.txtNome_Usuario.Incluir_QueryBy = true;
            this.txtNome_Usuario.Location = new System.Drawing.Point(97, 37);
            this.txtNome_Usuario.LookUp = false;
            this.txtNome_Usuario.MensagemObrigatorio = "Campo obrigatório";
            this.txtNome_Usuario.Name = "txtNome_Usuario";
            this.txtNome_Usuario.Obrigatorio = false;
            this.txtNome_Usuario.Size = new System.Drawing.Size(250, 20);
            this.txtNome_Usuario.SQLStatement = string.Empty;
            this.txtNome_Usuario.Tabela = "Usuarios";
            this.txtNome_Usuario.Tabela_INNER = null;
            this.txtNome_Usuario.TabIndex = 4;
            this.txtNome_Usuario.TipoControles = CompSoft.TipoControle.Geral;
            this.txtNome_Usuario.ValorAnterior = string.Empty;
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(50, 66);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(41, 13);
            this.cf_Label3.TabIndex = 5;
            this.cf_Label3.Text = "Senha:";
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenha.Coluna_LookUp = 0;
            this.txtSenha.ControlSource = string.Empty;
            this.txtSenha.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.ForeColor = System.Drawing.Color.DimGray;
            this.txtSenha.Grupo = string.Empty;
            this.txtSenha.Incluir_QueryBy = true;
            this.txtSenha.Location = new System.Drawing.Point(97, 63);
            this.txtSenha.LookUp = false;
            this.txtSenha.MensagemObrigatorio = "Campo obrigatório";
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Obrigatorio = false;
            this.txtSenha.Size = new System.Drawing.Size(250, 20);
            this.txtSenha.SQLStatement = string.Empty;
            this.txtSenha.Tabela = string.Empty;
            this.txtSenha.Tabela_INNER = null;
            this.txtSenha.TabIndex = 6;
            this.txtSenha.TipoControles = CompSoft.TipoControle.Geral;
            this.txtSenha.ValorAnterior = string.Empty;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.ControlSource = "Ativo";
            this.chkAtivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAtivo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivo.Grupo = string.Empty;
            this.chkAtivo.Location = new System.Drawing.Point(175, 15);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(49, 17);
            this.chkAtivo.Tabela = "Usuarios";
            this.chkAtivo.Tabela_INNER = null;
            this.chkAtivo.TabIndex = 2;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            this.chkAtivo.ValorAnterior = false;
            // 
            // f0045
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 97);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtNome_Usuario);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.txtUsuario);
            this.MainTabela = "Usuarios";
            this.Name = "f0045";
            this.Text = "Usuários";
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0045_user_AfterRefreshData);
            this.user_BeforeSave += new CompSoft.FormSet.BeforeSave(this.f0045_user_BeforeSave);
            this.user_AfterNew += new CompSoft.FormSet.AfterNew(this.f0045_user_AfterNew);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_TextBox txtUsuario;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtNome_Usuario;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox txtSenha;
        private CompSoft.cf_Bases.cf_CheckBox chkAtivo;
    }
}