using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0068 : CompSoft.FormSet
    {
        public f0068()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Modalidades_Calculo_ICMS"
                    , "select * from Modalidades_Calculo_ICMS"));

            InitializeComponent();
        }
    }
}