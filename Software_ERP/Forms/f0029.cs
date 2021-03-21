using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0029 : CompSoft.FormSet
    {
        public f0029()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Sexos"
                , "Select * from Sexos"));

            InitializeComponent();
        }
    }
}