using CompSoft.Data;
using System.Text;

namespace ERP.Forms
{
    public partial class f0074 : CompSoft.FormSet
    {
        public f0074()
        {
            StringBuilder sb = new StringBuilder(200);
            sb.AppendLine("select ");
            sb.AppendLine("   mif.Menu_Item_Favorito");
            sb.AppendLine(" , mif.Grupo_Favorito");
            sb.AppendLine(" , gf.Desc_Grupo_Favorito");
            sb.AppendLine(" , mif.Menu_Item");
            sb.AppendLine(" , mi.Descricao");
            sb.AppendLine(" , mif.Usuario");
            sb.AppendLine(" , u.Nome_Usuario");
            sb.AppendLine(" from menus_itens_favoritos mif");
            sb.AppendLine("  inner join grupos_favoritos gf on gf.grupo_favorito = mif.grupo_favorito");
            sb.AppendLine("  inner join menus_itens mi on mi.menu_item = mif.menu_item");
            sb.AppendLine("  inner join usuarios u on u.usuario = mif.usuario");

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "menus_itens_favoritos"
                    , sb.ToString()
                    , "Menu_Item_Favorito"));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            StringBuilder sb = new StringBuilder(50);

            sb.AppendFormat("u.usuario = {0}", this.cboUsuario.SelectedValue);

            return sb.ToString();
        }

        private void f0074_user_AfterRefreshData_1()
        {
            this.grdFavoritos.DataSource = this.DataSetLocal.Tables[0];
        }

        private void f0074_user_AfterNew()
        {
            this.grdFavoritos.CurrentRow["Usuario"] = this.cboUsuario.SelectedValue;
            this.grdFavoritos.CurrentRow["Nome_usuario"] = this.cboUsuario.Text;
        }
    }
}