using CompSoft.Data;
using System.ComponentModel;

namespace ERP.Forms
{
    public partial class f0024 : CompSoft.FormSet
    {
        public f0024()
        {
            string sSQL = string.Empty;
            sSQL += "select menus_itens_relatorios.*, mi.Descricao";
            sSQL += " from menus_itens_relatorios";
            sSQL += "  inner join menus_itens mi on menus_itens_relatorios.Menu_Item = mi.Menu_Item";

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "menus_itens_relatorios"
                , sSQL));

            InitializeComponent();
        }

        private void txtFormulario_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtFormulario.LookUpRetorno != null)
                this.txtDescricao_Formulario.Text = this.txtFormulario.LookUpRetorno["Descricao"].ToString();
        }

        private void txtDescricao_Formulario_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtDescricao.LookUpRetorno != null)
                this.txtFormulario.Text = this.txtDescricao_Formulario.LookUpRetorno["Menu_Item"].ToString();
        }

        private void f0024_user_AfterNew()
        {
            this.chkAtivo.Checked = true;
            this.txtNamespace.Text = "ERP.Reports";
        }
    }
}