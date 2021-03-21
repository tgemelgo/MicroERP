using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0028 : CompSoft.FormSet
    {
        public f0028()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Estados_Civis"
                , "Select * from Estados_Civis"));

            InitializeComponent();
        }
    }
}