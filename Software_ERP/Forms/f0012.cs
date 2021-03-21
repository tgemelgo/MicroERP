using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0012 : CompSoft.FormSet
    {
        public f0012()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Tipos_Produtos_Fornece"
                , "select * from Tipos_Produtos_Fornece"));

            InitializeComponent();
        }
    }
}