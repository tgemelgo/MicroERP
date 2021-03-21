using CompSoft.Data;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ERP.Reports
{
    public partial class r0016 : CompSoft.Reports.ReportBase_Retrato
    {
        public r0016()
        {
            InitializeComponent();

            DataTable dt = SQL.Select(this.Criar_Query(false, string.Empty), "Clientes_Vendedor", true);
            this.ADD_Tabela(dt);

            this.DataMember = "Clientes_Vendedor";
        }

        private string Criar_Query(bool bBuscar_Clientes, string sCondicao)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   cl.cliente");
            sb.AppendLine(" , cl.Razao_Social");
            sb.AppendLine(" , cl.Cpf_CNPJ");
            sb.AppendLine(" , v.nome_vendedor");
            sb.AppendLine(" , max(nf.Data_Emissao) as 'Dt_NF'");
            sb.AppendLine(" from clientes cl");
            sb.AppendLine("  left outer join vendedores v on v.vendedor = cl.vendedor");
            sb.AppendLine("  left outer join notas_fiscais nf on nf.cliente = cl.cliente");
            sb.AppendLine(" where isnull(nf.cancelada, 0) = 0 and isnull(nf.impressa, 1) = 1");
            if (bBuscar_Clientes)
                sb.AppendFormat(" and ({0})\r\n", sCondicao);
            sb.AppendLine(" group by   ");
            sb.AppendLine("   cl.cliente");
            sb.AppendLine(" , cl.Razao_Social");
            sb.AppendLine(" , cl.Cpf_CNPJ");
            sb.AppendLine(" , v.nome_vendedor");

            return sb.ToString();
        }

        public override void Set_DataMember_DetailReports()
        {
            //-- Define entre chaves para a variavel ser destruida após esta execução.
            {
                DataRow[] fRow = this.Report_DataSet.Tables["clientes"].Select();
                string sQuery = this.Criar_Query(true, this.Monta_Condicao_AllRecords(fRow));
                this.ADD_Tabela(SQL.Select(sQuery.Replace("%Tabela%", "cl"), this.DataMember, false));
            }

            //-- Encontra os DataTables não utilizados.
            IList<string> ilTables = new List<string>();
            foreach (DataTable dt in this.Report_DataSet.Tables)
            {
                if (dt.TableName.ToLower() != "clientes_vendedor")
                    ilTables.Add(dt.TableName);
            }

            //-- remove DataTables que não será utilizados.
            foreach (string sTable in ilTables)
                this.Report_DataSet.Tables.Remove(sTable);
        }
    }
}