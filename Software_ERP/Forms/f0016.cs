using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0016 : CompSoft.FormSet
    {
        public f0016()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Grupos_Produtos"
                , "select * from grupos_produtos"));

            InitializeComponent();
        }
    }
}