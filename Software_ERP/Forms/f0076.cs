namespace ERP.Forms
{
    public partial class f0076 : CompSoft.FormSet
    {
        public f0076()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                    , "Agencias"
                    , "select * from Bancos"));
            InitializeComponent();
        }
    }
}