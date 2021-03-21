using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0043 : CompSoft.FormSet
    {
        public f0043()
        {
            string sSQL = string.Empty;
            sSQL = "SELECT ";
            sSQL += "   *";
            sSQL += " FROM Situacoes_Tributaria";
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Situacoes_Tributaria"
                    , sSQL));

            InitializeComponent();
        }
    }
}