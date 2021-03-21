namespace ERP.Forms
{
    public partial class f0082 : CompSoft.FormSet
    {
        public f0082()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                    , "CSOSN"
                    , "select * from CSOSN"));

            InitializeComponent();
        }
    }
}