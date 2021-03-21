using CompSoft.Data;
using System.Text;

namespace ERP.Reports
{
    public partial class r0009 : CompSoft.Reports.ReportBase_Retrato
    {
        public r0009()
        {
            InitializeComponent();
        }

        public override void Set_DataMember_DetailReports()
        {
            string sInQuery = this.Monta_Condicao_AllRecords(this.Report_DataSet.Tables[0].Select());
            sInQuery = sInQuery.Replace("%Tabela%", "me");

            this.Report_DataSet.Tables.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   me.Data_Movimento");
            sb.AppendLine(" , tme.Desc_Tipo_Movimento_Estoque");
            sb.AppendLine(" , mei.Produto");
            sb.AppendLine(" , pr.Desc_Produto");
            sb.AppendLine(" , case tme.Entrada ");
            sb.AppendLine("  when 1 then mei.quantidade");
            sb.AppendLine("  else null");
            sb.AppendLine("   end as 'Qtde_Entrada'");
            sb.AppendLine(" , case tme.Saida");
            sb.AppendLine("  when 1 then mei.quantidade");
            sb.AppendLine("  else null");
            sb.AppendLine("   end as 'Qtde_Saida'");
            sb.AppendLine(" FROM Movimentos_Estoque_itens mei");
            sb.AppendLine("  inner join movimentos_estoque me on me.movimento_estoque = mei.movimento_estoque");
            sb.AppendLine("  inner join tipos_movimentos_estoque tme on tme.Tipo_Movimento_Estoque = me.Tipo_Movimento_Estoque");
            sb.AppendLine("  INNER JOIN produtos pr ON pr.produto = mei.produto");
            sb.AppendFormat("   where {0}", sInQuery);

            this.ADD_Tabela(SQL.Select(sb.ToString(), "Movimentos_Estoque", false));
        }
    }
}