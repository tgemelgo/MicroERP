using CompSoft;

namespace ERP.Forms
{
    public partial class f0008 : FormSet
    {
        public f0008()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                    , "Moedas"
                    , "select * from Moedas"));

            InitializeComponent();
        }
    }
}