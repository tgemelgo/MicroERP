using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0023 : CompSoft.FormSet
    {
        public f0023()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "CFOPS"
                , "select * from CFOPS"));

            InitializeComponent();
        }
    }
}