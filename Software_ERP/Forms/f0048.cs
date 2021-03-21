using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0048 : CompSoft.FormSet
    {
        public f0048()
        {
            this.Tabelas.Add(new Controle_Tabelas(
                Controle_Tabelas.TiposTabelas.Pai
                , "Tipos_Movimentos"
                , "select * from Tipos_Movimentos"));

            InitializeComponent();
        }
    }
}