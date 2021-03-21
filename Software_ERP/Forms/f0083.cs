using System;

namespace ERP.Forms
{
    public partial class f0083 : CompSoft.FormSet
    {
        public f0083()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                        , "mensagens_notas"
                        , "select * from mensagens_notas"));
            InitializeComponent();
        }

        private void txtMensagem_TextChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
            {
                if (this.txtMensagem.Text.IndexOf("{0}") >= 0)
                    this.txtQuerySubstiuicao.Enabled = true;
                else
                    this.txtQuerySubstiuicao.Enabled = false;
            }
        }

        private bool f0083_user_BeforeSave()
        {
            if (this.txtMensagem.Text.IndexOf("{0}") == -1)
                this.txtQuerySubstiuicao.Text = string.Empty;

            return default(bool);
        }

        private void f0083_user_FormStatus_Change()
        {
            this.txtMensagem_TextChanged(this, EventArgs.Empty);
        }
    }
}