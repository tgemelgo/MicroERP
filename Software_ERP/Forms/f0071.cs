using CompSoft;
using System;
using System.Text;

namespace ERP.Forms
{
    public partial class f0071 : FormSet
    {
        public f0071()
        {
            StringBuilder sb = new StringBuilder(700);
            sb.AppendLine(@"select
                               cp.Produto
                             , cp.Desc_Produto
                             , null as 'Grupo_Produto'
                             , null as 'Desc_Grupo_Produto'
                             , NULL as 'SubGrupo_Produto'
                             , NULL AS 'Desc_SubGrupo_Produto'
                             , null as 'Categoria_Produto'
                             , null as 'Desc_Categoria_Produto'
                             , sum(nfi.Quantidade) as Quantidade
                             , sum(nfi.Peso_Bruto) as Peso_Bruto
                             , sum(nfi.Peso_Liquido) as Peso_Liquido
                             , sum(nfi.Valor_Unitario) as Valor_Unitario
                             , sum(nfi.Valor_Total_Item) as Valor_Total_Item
                             from notas_fiscais nf
                              inner join pedidos pe on pe.pedido = nf.pedido
                              inner join notas_fiscais_itens nfi on nfi.Nota_Fiscal = nf.Nota_Fiscal
                              inner join produtos pr on pr.produto = nfi.Produto
                              inner join vw_class_produto cp on cp.produto = pr.produto
                             where
                              (nf.cancelada = 0 and pe.cancelado = 0)
                             group by cp.Produto, cp.Desc_Produto");

            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                        , "Notas_Fiscais"
                        , sb.ToString()
                        , "Produto"));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            StringBuilder sb = new StringBuilder();

            if (this.chkAtivar_DataEmissao.Checked)
            {
                if (sb.Length != 0)
                    sb.Append(" AND ");

                sb.AppendFormat(" nf.Data_Emissao between '{0}' and '{1}'"
                        , this.prdDataEmissao.Data_Inicial_SQL
                        , this.prdDataEmissao.Data_Termino_SQL);
            }

            if (this.chkAtivar_Empresa.Checked && this.cboEmpresa.SelectedIndex >= 0)
            {
                if (sb.Length != 0)
                    sb.Append(" AND ");

                sb.AppendFormat("nf.empresa = {0}", this.cboEmpresa.SelectedValue);
            }

            if (this.chkAtivar_TpDoc.Checked && !this.optTpDocAmbos.Checked)
            {
                if (sb.Length != 0)
                    sb.Append(" AND ");

                if (this.optTpDocCupom.Checked)
                    sb.AppendFormat(" pe.gera_nf = 0 ");

                if (this.optTpDocNotaFiscal.Checked)
                    sb.AppendFormat(" pe.gera_nf = 1 ");
            }

            return sb.ToString();
        }

        private void f0071_user_AfterRefreshData()
        {
            this.grdLista.DataSource = this.DataSetLocal.Tables[0];
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}