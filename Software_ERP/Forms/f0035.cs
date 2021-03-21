using CompSoft.Data;
using System;

namespace ERP.Forms
{
    public partial class f0035 : CompSoft.FormSet
    {
        public f0035()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "condicoes_pagamento_pedido"
                , "select * from condicoes_pagamento_pedido"));

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "condicoes_pagamento_pedido_itens"
                , "select * from condicoes_pagamento_pedido_itens"));

            InitializeComponent();
        }

        private void f0035_user_FormStatus_Change()
        {
            this.acPrazo.Status_Form = this.FormStatus;
        }

        private void f0035_user_AfterRefreshData()
        {
            this.grdPrazo.DataSource = this.DataSetLocal.Tables["condicoes_pagamento_pedido_itens"];
        }

        private void f0035_Load(object sender, EventArgs e)
        {
            this.acPrazo.Grid_Trabalho = this.grdPrazo;
        }
    }
}