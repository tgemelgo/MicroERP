using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0030 : CompSoft.FormSet
    {
        public f0030()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Unidades_Medidas"
                , "select * from Unidades_Medidas"));

            InitializeComponent();
        }
    }
}