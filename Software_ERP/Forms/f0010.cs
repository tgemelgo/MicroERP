using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0010 : CompSoft.FormSet
    {
        public f0010()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Formas_Pagamentos", "select * from Formas_Pagamentos"));

            InitializeComponent();
        }
    }
}