using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0014 : CompSoft.FormSet
    {
        public f0014()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Tipos_Vinculos"
                , "select * from tipos_vinculos"));

            InitializeComponent();
        }
    }
}