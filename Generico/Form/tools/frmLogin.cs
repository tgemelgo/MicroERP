using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Tools
{
    internal partial class frmLogin : formBase
    {
        private RegistroWindows reg = new RegistroWindows();
        private Crypt c = new Crypt(CryptProvider.TripleDES);

        public string Servidor
        {
            get { return this.txtServidor.Text; }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void ValidarLogin()
        {
            string sMSG = string.Empty;

            if (string.IsNullOrEmpty(this.txtUsuario.Text))
                sMSG += "- O usuário tem que ser preenchido.\r\n";

            if (string.IsNullOrEmpty(this.txtSenha.Text))
                sMSG += "- A senha tem que ser preenchida.\r\n";

            if (string.IsNullOrEmpty(sMSG))
            {
                string sSenha = string.Empty;
                Crypt cr = new Crypt(CryptProvider.TripleDES);
                cr.Key = "CompSoft";

                //-- Criptograva o menu.
                sSenha = cr.Encrypt(this.txtSenha.Text);

                //-- Monta query para localizar senha.
                string sSQL = string.Empty;
                sSQL += "Select * from Usuarios ";
                sSQL += "   where Nome_Usuario = '{0}' ";
                sSQL += "       and senha = '{1}' ";
                sSQL = string.Format(sSQL, txtUsuario.Text, sSenha);

                //-- Executa a query.
                try
                {
                    DataRow[] fRow = SQL.Select(sSQL, "Usuarios", false).Select();

                    //-- Verifica se foram encontrados registros.
                    foreach (DataRow row in fRow)
                    {
                        Propriedades.CodigoUsuario = Convert.ToInt32(row["Usuario"].ToString());
                        Propriedades.NomeUsuario = row["Nome_Usuario"].ToString();
                        Propriedades.Usuario_ADM = (bool)row["ADM"];
                    }

                    //-- Caso seja encontrata algum registro o login está valido.
                    if (fRow.Length >= 1)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                        try
                        {
                            string sPathINI = Application.StartupPath + "\\CompSoft.ini";
                            if (File.Exists(sPathINI))
                            {
                                CompSoft.compFrameWork.IniFile ini = new IniFile(sPathINI);
                                string sFileServer = ini.IniReadValue("Configuracoes", "Folder_Server");
                                if (!sFileServer.EndsWith(@"\"))
                                    sFileServer += @"\";

                                sFileServer += "CompSoft - Starter.exe";

                                string sFileLocal = Application.StartupPath + "\\CompSoft - Starter.exe";
                                if (File.Exists(sFileServer))
                                {
                                    if (!File.Exists(sFileLocal) || !File.GetLastWriteTime(sFileServer).Equals(File.GetLastWriteTime(sFileLocal)))
                                        File.Copy(sFileServer, sFileLocal, true);
                                }
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        CompSoft.compFrameWork.MsgBox.Show("Usuário ou senha invalido"
                            , "Atenção"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Stop);

                        this.txtUsuario.Focus();
                    }
                }
                catch
                {
                    CompSoft.compFrameWork.MsgBox.Show("O usuário do sistema está em branco, o preencha para continuar."
                        , "Aviso"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                }
            }
            else
                CompSoft.compFrameWork.MsgBox.Show(sMSG
                    , "Login"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void cmdEntrar_Click(object sender, EventArgs e)
        {
            Propriedades.StringConexao = string.Format("Server={0};uid={1};pwd={2};Application Name=CompSoft Sistemas"
                    , this.txtServidor.Text
                    , this.txtUsuarioDB.Text
                    , this.txtSenhaDB.Text);

            Propriedades.DataBase = this.cboDataBase.Text;

            this.ValidarLogin();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                Propriedades.StringConexao = string.Format("Server={0};uid={1};pwd={2};Application Name=CompSoft Sistemas"
                        , this.txtServidor.Text
                        , this.txtUsuarioDB.Text
                        , this.txtSenhaDB.Text);

                Propriedades.DataBase = this.cboDataBase.Text;

                this.ValidarLogin();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                Propriedades.StringConexao = string.Format("Server={0};uid={1};pwd={2};Application Name=CompSoft Sistemas"
                        , this.txtServidor.Text
                        , this.txtUsuarioDB.Text
                        , this.txtSenhaDB.Text);

                Propriedades.DataBase = this.cboDataBase.Text;

                this.ValidarLogin();
            }
        }

        private void chkOpcoes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOpcoes.Checked)
            {
                int iheigth = (this.grpOpcoes.Height + this.grpOpcoes.Top);
                iheigth = iheigth + ((iheigth * 15) / 100);
                this.Size = new Size(this.cf_GroupBox1.Size.Width + 110, iheigth);
                this.grpOpcoes.Visible = true;
            }
            else
            {
                int iheigth = this.cf_GroupBox1.Top + this.cf_GroupBox1.Size.Height;
                iheigth = iheigth + ((iheigth * 30) / 100);
                this.grpOpcoes.Visible = false;
                this.Size = new Size(this.cf_GroupBox1.Size.Width + 110, iheigth);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            c.Key = "CompSoft - Geral";
            if (!string.IsNullOrEmpty(reg.LocalizaRegistro("ServerDB").ToString()))
                this.txtServidor.Text = c.Decrypt(reg.LocalizaRegistro("ServerDB").ToString());

            if (!string.IsNullOrEmpty(reg.LocalizaRegistro("UsuarioDB").ToString()))
                this.txtUsuarioDB.Text = c.Decrypt(reg.LocalizaRegistro("UsuarioDB").ToString());

            if (!string.IsNullOrEmpty(reg.LocalizaRegistro("SenhaDB").ToString()))
                this.txtSenhaDB.Text = c.Decrypt(reg.LocalizaRegistro("SenhaDB").ToString());

            string sDB = string.Empty;
            if (!string.IsNullOrEmpty(reg.LocalizaRegistro("BaseDadosDB").ToString()))
                sDB = c.Decrypt(reg.LocalizaRegistro("BaseDadosDB").ToString());

            if (!string.IsNullOrEmpty(sDB)
                && !string.IsNullOrEmpty(this.txtServidor.Text)
                && !string.IsNullOrEmpty(this.txtUsuarioDB.Text)
                && !string.IsNullOrEmpty(this.txtSenhaDB.Text))
            {
                Propriedades.StringConexao = string.Format("Server={0};uid={1};pwd={2}"
                    , this.txtServidor.Text
                    , this.txtUsuarioDB.Text
                    , this.txtSenhaDB.Text);

                Propriedades.DataBase = sDB;
                try
                {
                    DataTable dt = SQL.Select("select convert(varchar(30), Name) as 'Name' from master.dbo.sysdatabases where dbid > 4 order by name"
                    , "xTabela"
                    , false);
                    this.cboDataBase.DataSource = dt;
                    this.cboDataBase.DisplayMember = "Name";

                    this.cboDataBase.Text = sDB;
                }
                catch { }
            }

            this.grpOpcoes.Visible = false;

            int iheigth = this.cf_GroupBox1.Top + this.cf_GroupBox1.Size.Height;
            iheigth = iheigth + ((iheigth * 30) / 100);
            this.grpOpcoes.Visible = false;
            this.Size = new Size(this.cf_GroupBox1.Size.Width + 110, iheigth);
        }

        private void txtServidor_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtServidor.Text))
                reg.GravarRegistro("ServerDB", c.Encrypt(this.txtServidor.Text.Trim()));
            else
                reg.GravarRegistro("ServerDB", "");

            this.Atualiza_String();
        }

        private void txtUsuarioDB_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtUsuarioDB.Text))
                reg.GravarRegistro("UsuarioDB", c.Encrypt(this.txtUsuarioDB.Text.Trim()));
            else
                reg.GravarRegistro("UsuarioDB", "");

            this.Atualiza_String();
        }

        private void txtSenhaDB_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSenhaDB.Text))
                reg.GravarRegistro("SenhaDB", c.Encrypt(this.txtSenhaDB.Text.Trim()));
            else
                reg.GravarRegistro("SenhaDB", "");

            this.Atualiza_String();
        }

        private void cboDataBase_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cboDataBase.Text))
                reg.GravarRegistro("BaseDadosDB", c.Encrypt(this.cboDataBase.Text.Trim()));
            else
                reg.GravarRegistro("BaseDadosDB", "");

            this.Atualiza_String();
        }

        private void cboDataBase_Enter(object sender, EventArgs e)
        {
            this.Atualiza_String();
        }

        private void cmdAtualizarBases_Click(object sender, EventArgs e)
        {
            Propriedades.StringConexao = string.Format("Server={0};uid={1};pwd={2}"
                    , this.txtServidor.Text
                    , this.txtUsuarioDB.Text
                    , this.txtSenhaDB.Text);

            Propriedades.DataBase = string.Empty;

            DataTable dt = SQL.Select("select convert(varchar(30), Name) as 'Name' from master.dbo.sysdatabases where dbid > 4 order by name"
                , "xTabela"
                , false);
            this.cboDataBase.DataSource = dt;
            this.cboDataBase.DisplayMember = "Name";
        }

        private void Atualiza_String()
        {
            Propriedades.StringConexao = string.Format("Server={0};uid={1};pwd={2}"
                , this.txtServidor.Text
                , this.txtUsuarioDB.Text
                , this.txtSenhaDB.Text);

            Propriedades.DataBase = this.cboDataBase.Text;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.txtUsuario.Focus();
        }
    }
}