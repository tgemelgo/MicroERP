using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0027 : CompSoft.FormSet
    {
        public f0027()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "ICMS_Estados"
                    , "select * from ICMS_Estados"));

            InitializeComponent();
        }
    }
}