using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0015 : CompSoft.FormSet
    {
        public f0015()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "tipos_contas"
                , "select * from tipos_contas"));

            InitializeComponent();
        }
    }
}