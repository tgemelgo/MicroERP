using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0040 : CompSoft.FormSet
    {
        public f0040()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "classificacoes_fiscais", "select * from classificacoes_fiscais"));

            InitializeComponent();
        }
    }
}