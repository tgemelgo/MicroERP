using CompSoft.Data;
using System.Data;
using System.Text;

namespace ERP.Reports
{
    public partial class r0006 : CompSoft.Reports.ReportBase
    {
        public r0006()
        {
            InitializeComponent();
        }

        private string Filtro_PK()
        {
            string sRetorno = string.Empty;
            DataRow[] fRow = this.Report_DataSet.Tables["Romaneios"].Select();
            foreach (DataRow row in fRow)
            {
                if (!string.IsNullOrEmpty(sRetorno))
                    sRetorno += " OR ";

                string sCondicao = string.Empty;
                foreach (DataColumn dc in this.Report_DataSet.Tables["Romaneios"].PrimaryKey)
                {
                    if (!string.IsNullOrEmpty(sCondicao))
                        sCondicao += " AND ";

                    sCondicao += dc.ColumnName + " = '" + row[dc.ColumnName].ToString() + "'";
                }

                sRetorno += sCondicao;
            }

            return sRetorno;
        }

        public override void Set_DataMember_DetailReports()
        {
            StringBuilder sb = new StringBuilder(5000);
            sb.AppendLine("select ");
            sb.AppendLine("   romaneios_itens.Romaneio");
            sb.AppendLine(" , cl.Razao_Social");
            sb.AppendLine(" , cl.Endereco_Entrega");
            sb.AppendLine(" , cl.Numero_Entrega");
            sb.AppendLine(" , cl.Complemento_Entrega");
            sb.AppendLine(" , cl.Bairro_Entrega");
            sb.AppendLine(" , cl.Cidade_Entrega");
            sb.AppendLine(" , cl.Estado_Entrega");
            sb.AppendLine(" , pedi.Produto");
            sb.AppendLine(" , pro.desc_produto");
            sb.AppendLine(" , sum(pedi.qtde) as 'Qtde'");
            sb.AppendLine(" , um.desc_unidade");
            sb.AppendLine(" , romaneios_itens.Observacao");
            sb.AppendLine(" , romaneios_itens.Ordem");
            sb.AppendLine("   from romaneios_itens");
            sb.AppendLine("  inner join pedidos ped on romaneios_itens.Pedido = ped.pedido");
            sb.AppendLine("  inner join pedidos_itens pedi on pedi.Pedido = ped.pedido");
            sb.AppendLine("     inner join clientes cl on cl.cliente = romaneios_itens.Cliente");
            sb.AppendLine("  inner join produtos pro on pro.produto = pedi.produto");
            sb.AppendLine("  inner join unidades_medidas um on um.unidade_medida = pro.unidade_medida");
            sb.AppendFormat("   where {0}\r\n", this.Filtro_PK());
            sb.AppendLine("   group by ");
            sb.AppendLine("    romaneios_itens.Romaneio");
            sb.AppendLine("  , cl.Razao_Social");
            sb.AppendLine("  , cl.Endereco_Entrega");
            sb.AppendLine("  , cl.Numero_Entrega");
            sb.AppendLine("  , cl.Complemento_Entrega");
            sb.AppendLine("  , cl.Bairro_Entrega");
            sb.AppendLine("  , cl.Cidade_Entrega");
            sb.AppendLine("  , cl.Estado_Entrega");
            sb.AppendLine("  , pedi.Produto");
            sb.AppendLine("  , pro.desc_produto");
            sb.AppendLine("  , um.desc_unidade");
            sb.AppendLine("     , romaneios_itens.Observacao");
            sb.AppendLine("     , romaneios_itens.Ordem");
            this.ADD_Tabela(SQL.Select(sb.ToString(), "x", false));

            sb.Clear();
            sb.AppendLine("select ");
            sb.AppendLine("   romaneios_itens.Romaneio");
            sb.AppendLine(" , pro.desc_produto");
            sb.AppendLine(" , sum(pedi.qtde) as 'Qtde'");
            sb.AppendLine("   from romaneios_itens");
            sb.AppendLine("  inner join pedidos ped on romaneios_itens.Pedido = ped.pedido");
            sb.AppendLine("  inner join pedidos_itens pedi on pedi.Pedido = ped.pedido");
            sb.AppendLine("  inner join clientes cl on cl.cliente = romaneios_itens.Cliente");
            sb.AppendLine("  inner join produtos pro on pro.produto = pedi.produto");
            sb.AppendLine("  inner join unidades_medidas um on um.unidade_medida = pro.unidade_medida");
            sb.AppendFormat("   where {0}\r\n", this.Filtro_PK());
            sb.AppendLine("   group by ");
            sb.AppendLine("   romaneios_itens.Romaneio");
            sb.AppendLine(" , pro.desc_produto");
            this.ADD_Tabela(SQL.Select(sb.ToString(), "x2", false));
        }

        private void DetailReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
    }
}