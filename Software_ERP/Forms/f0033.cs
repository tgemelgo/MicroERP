using CompSoft.Data;
using System;
using System.Data;

namespace ERP.Forms
{
    public partial class f0033 : CompSoft.FormSet
    {
        public f0033()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Tabelas_Precos"
                , "select * from tabelas_precos"));

            string sSQL = string.Empty;
            sSQL += "select tabelas_precos_itens.*, pr.desc_Produto, pr.Valor_Venda as 'Valor_Original'";
            sSQL += " from tabelas_precos_itens ";
            sSQL += "  inner join produtos pr on pr.produto = tabelas_precos_itens.produto";
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "tabelas_precos_itens"
                , sSQL));

            InitializeComponent();
        }

        private void f0033_user_FormStatus_Change()
        {
            this.acTabela.Status_Form = this.FormStatus;
        }

        private void f0033_user_AfterRefreshData()
        {
            this.grdItens.DataSource = this.DataSetLocal.Tables["tabelas_precos_itens"];
        }

        private void f0033_Load(object sender, EventArgs e)
        {
            this.acTabela.Grid_Trabalho = this.grdItens;
        }

        private void cmdListaProdutos_Click(object sender, EventArgs e)
        {
            string sSQL = string.Empty;
            sSQL += "select produto, desc_Produto, Valor_Venda from produtos order by desc_produto";
            DataTable dt_Prod = CompSoft.Data.SQL.Select(sSQL, "x", false);

            //-- Varre todos os produtos encontrados.
            foreach (DataRow row_p in dt_Prod.Select())
            {
                //--
                int iExiste = (int)this.DataSetLocal.Tables["Tabelas_precos_itens"].Compute("count(produto)", string.Format("produto = {0}", row_p["produto"]));
                if (iExiste <= 0)
                {
                    this.grdItens.BindingSource.AddNew();

                    this.grdItens.CurrentRow["desc_Produto"] = row_p["desc_Produto"];
                    this.grdItens.CurrentRow["Produto"] = row_p["Produto"];
                    this.grdItens.CurrentRow["Valor_Original"] = row_p["Valor_Venda"];
                    this.grdItens.CurrentRow["Valor_Venda"] = 0;

                    this.grdItens.BindingSource.EndEdit();
                }
            }
        }
    }
}