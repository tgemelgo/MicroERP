using CompSoft;

namespace ERP.Forms
{
    public partial class f0007 : FormSet
    {
        public f0007()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                    , "Grupos_Favoritos"
                    , "select * from Grupos_Favoritos"));

            InitializeComponent();
        }
    }
}