using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0041 : CompSoft.FormSet
    {
        public f0041()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "SubGrupos_Produtos"
                , "select * from Subgrupos_produtos"));

            InitializeComponent();
        }
    }
}