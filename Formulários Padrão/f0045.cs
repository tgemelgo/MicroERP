using CompSoft.compFrameWork;
using CompSoft.Data;
using System.Data;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0045 : CompSoft.FormSet
    {
        public f0045()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Usuarios"
                , "Select * from usuarios"));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            string squery = string.Empty;
            squery = " usuario != 1 ";
            return squery;
        }

        private bool f0045_user_BeforeSave()
        {
            if (!string.IsNullOrEmpty(this.txtSenha.Text))
            {
                Crypt c = new Crypt(CryptProvider.TripleDES);
                c.Key = "CompSoft";

                ((DataRowView)this.BindingSource[this.MainTabela].Current)["Senha"] = c.Encrypt(this.txtSenha.Text);
                return true;
            }
            else
            {
                CompSoft.compFrameWork.MsgBox.Show("Todo usuário tem que possuir uma senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void f0045_user_AfterRefreshData()
        {
            if (this.DataSetLocal.Tables["Usuarios"].Rows.Count >= 1)
            {
                string sSenha = ((DataRowView)this.BindingSource[this.MainTabela].Current)["Senha"].ToString();
                if (!string.IsNullOrEmpty(sSenha))
                {
                    Crypt c = new Crypt(CryptProvider.TripleDES);
                    c.Key = "CompSoft";

                    this.txtSenha.Text = c.Decrypt(sSenha);
                }
            }
        }

        private void f0045_user_AfterNew()
        {
            this.txtSenha.Text = string.Empty;
        }
    }
}