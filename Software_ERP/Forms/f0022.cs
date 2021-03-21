using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0022 : CompSoft.FormSet
    {
        public f0022()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Escolaridades"
                , "select * from Escolaridades"));

            InitializeComponent();
        }
    }
}