using CompSoft.Data;

namespace ERP.Forms
{
    public partial class f0057 : CompSoft.FormSet
    {
        public f0057()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Tipos_Documentos"
                , "select * from tipos_documentos"));

            InitializeComponent();
        }
    }
}