using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0049 : CompSoft.FormSet
    {
        public f0049()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Tipos_Pagamentos"
                , "select * from Tipos_Pagamentos"));

            InitializeComponent();
        }
    }
}