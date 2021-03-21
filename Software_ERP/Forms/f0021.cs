using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0021 : CompSoft.FormSet
    {
        public f0021()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Departamentos"
                , "select * from Departamentos"));
            InitializeComponent();
        }
    }
}