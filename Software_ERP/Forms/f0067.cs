using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0067 : CompSoft.FormSet
    {
        public f0067()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Modalidades_Calculo_ICMS_ST"
                    , "select * from Modalidades_Calculo_ICMS_ST"));

            InitializeComponent();
        }
    }
}