using CompSoft;
using CompSoft.Data;
using System.ComponentModel;

namespace ERP.Forms
{
    public partial class f0003 : FormSet
    {
        public f0003()
        {
            string sSQL = string.Empty;
            sSQL += "Select Menus_Itens.*, mi.Descricao 'Desc_Parent'";
            sSQL += " from Menus_Itens ";
            sSQL += "  inner join menus_itens mi on mi.Menu_Item = menus_Itens.Parentnivel";

            this.Tabelas.Add(new Controle_Tabelas(
                Controle_Tabelas.TiposTabelas.Pai
                , "Menus_Itens"
                , sSQL));

            InitializeComponent();
        }

        private void frmCadMenu_Item_user_AfterRefreshData()
        {
            this.txtDescParent.ReadOnly = false;
        }

        private void txtParentNivel_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtParentNivel.LookUpRetorno != null)
                this.txtDescParent.Text = this.txtParentNivel.LookUpRetorno[1].ToString();
        }

        private void f0003_user_AfterNew()
        {
            this.txtNameSpace.Text = "ERP.Forms";
            this.cf_CheckBox1.Checked = true;
        }
    }
}