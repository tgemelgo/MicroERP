using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0066 : CompSoft.FormSet
    {
        public f0066()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Situacoes_Tributaria_COFINS"
                    , "Select * from Situacoes_Tributaria_COFINS"));

            InitializeComponent();
        }
    }
}