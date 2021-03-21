using System;

namespace ERP.Forms
{
    public partial class f0081 : CompSoft.FormSet
    {
        public f0081()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                    , "boletos_instrucoes"
                    , "select * from boletos_instrucoes"));

            InitializeComponent();
        }

        private void f0081_Load(object sender, EventArgs e)
        {
        }
    }
}