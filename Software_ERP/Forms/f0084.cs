namespace ERP.Forms
{
    public partial class f0084 : CompSoft.FormSet
    {
        public f0084()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                        , "Regimes_Tributarios"
                        , "select * from Regimes_Tributarios"));

            InitializeComponent();
        }
    }
}