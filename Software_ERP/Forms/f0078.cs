namespace ERP.Forms
{
    public partial class f0078 : CompSoft.FormSet
    {
        public f0078()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                    , "Boletos_Especies_Documentos"
                    , "select * from Boletos_Especies_Documentos"));

            InitializeComponent();
        }
    }
}