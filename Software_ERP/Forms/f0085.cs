namespace ERP.Forms
{
    public partial class f0085 : CompSoft.FormSet
    {
        public f0085()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                        , "origens_Produtos"
                        , "select * from origens_Produtos"));

            InitializeComponent();
        }
    }
}