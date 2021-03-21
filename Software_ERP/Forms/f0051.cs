using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0051 : CompSoft.FormSet
    {
        public f0051()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Categorias_Produtos"
                , "select * from Categorias_Produtos"));

            InitializeComponent();
        }
    }
}