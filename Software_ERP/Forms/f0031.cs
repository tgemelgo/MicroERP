using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0031 : CompSoft.FormSet
    {
        public f0031()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Tipos_Movimentos_Estoque"
                , "select * from Tipos_Movimentos_Estoque"));

            InitializeComponent();
        }
    }
}