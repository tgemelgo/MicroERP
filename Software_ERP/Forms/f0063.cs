using CompSoft.Data;
using CompSoft.Tools;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0063 : CompSoft.FormSet
    {
        private DataTable dt = new DataTable();

        private enum Tipos_Agrupamentos
        {
            Mes,
            Semana
        }

        public f0063()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Fluxo"
                , this.Monta_Query_FluxoCaixa(false)
                , "Referencia"));

            InitializeComponent();
        }

        #region Altera query para buscar dados.

        private bool f0063_user_BeforeSearch()
        {
            //-- Altera a query para os dados selecionados...
            this.Tabelas[0].SQLStatement = this.Monta_Query_FluxoCaixa(true);

            return true;
        }

        #endregion Altera query para buscar dados.

        #region Cria clausula In da query.

        private string Filtra_Empresa_Sel()
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRowView row in this.lstEmpresasSel.Items)
            {
                if (sb.Length > 0)
                    sb.Append(", ");

                sb.Append(row["Empresa"].ToString());
            }

            return sb.ToString();
        }

        #endregion Cria clausula In da query.

        #region Monta query para fluxo de caixa

        private string Monta_Query_FluxoCaixa(bool bPermiteFiltro)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   isnull(a.data_vencimento, b.data_vencimento) as 'Referencia'");
            sb.AppendLine(" , isnull(a.Valor_Receber, 0) as 'Valor_Receber'");
            sb.AppendLine(" , isnull(b.Valor_Pagar, 0) as 'Valor_Pagar'");
            sb.AppendLine(" , convert(numeric(18,2), 0) as 'Saldo'");
            sb.AppendLine("from");
            sb.AppendLine("(select ");
            sb.AppendLine("   crp.data_vencimento");
            sb.AppendLine(" , sum(case crp.parcela_paga");
            sb.AppendLine("  when 1 then crp.valor_receber");
            sb.AppendLine("  else crp.valor_original");
            sb.AppendLine("   end) as 'valor_receber'");
            sb.AppendLine(" from contas_receber cr");
            sb.AppendLine("  inner join contas_receber_parcela crp on crp.conta_receber = cr.conta_receber");

            if (bPermiteFiltro)
            {
                sb.AppendLine(" where ");
                sb.AppendFormat("  crp.Data_vencimento between '{0}' and '{1}'\r\n", this.prdPeriodo.Data_Inicial_SQL, this.prdPeriodo.Data_Termino_SQL);

                if (this.lstEmpresasSel.Items.Count > 0)
                    sb.AppendFormat("  and cr.empresa in ({0}) \r\n", this.Filtra_Empresa_Sel());
            }

            sb.AppendLine(" group by crp.data_vencimento) a");
            sb.AppendLine("");
            sb.AppendLine("full join ");
            sb.AppendLine("");
            sb.AppendLine("(select ");
            sb.AppendLine("   cpp.data_vencimento");
            sb.AppendLine(" , sum(case cpp.parcela_paga");
            sb.AppendLine("  when 1 then cpp.valor_pagar");
            sb.AppendLine("  else cpp.valor_original");
            sb.AppendLine("   end) as 'valor_pagar'");
            sb.AppendLine(" from contas_pagar cp");
            sb.AppendLine("  inner join contas_pagar_parcela cpp on cpp.conta_pagar = cp.conta_pagar");

            if (bPermiteFiltro)
            {
                sb.AppendLine(" where ");
                sb.AppendFormat("  cpp.Data_vencimento between '{0}' and '{1}'\r\n", this.prdPeriodo.Data_Inicial_SQL, this.prdPeriodo.Data_Termino_SQL);
                if (this.lstEmpresasSel.Items.Count > 0)
                    sb.AppendFormat("  and cp.empresa in ({0}) \r\n", this.Filtra_Empresa_Sel());
            }

            sb.AppendLine(" group by cpp.data_vencimento) b on b.data_vencimento = a.data_vencimento");

            return sb.ToString();
        }

        #endregion Monta query para fluxo de caixa

        #region Calcula o saldo

        private void Calcula_Saldo(DataTable dt)
        {
            decimal dSaldoInicial = 0;

            DataView dv = null;
            if (dt.TableName.ToLower() == "fluxo")
                dv = new DataView(dt, "", "Referencia", DataViewRowState.CurrentRows);
            else
                dv = new DataView(dt, "", "data", DataViewRowState.CurrentRows);

            foreach (DataRowView row in dv)
            {
                dSaldoInicial += Convert.ToDecimal(row["Valor_Receber"]) - Convert.ToDecimal(row["Valor_Pagar"]);
                row["Saldo"] = dSaldoInicial;
            }
        }

        #endregion Calcula o saldo

        #region Carregar listas

        private void Carregar_Listas()
        {
            dt = SQL.Select("select Empresa, Razao_Social, convert(bit, 0) as 'sel' from empresas where inativo = 0", "x", false);
            dt.Columns["Sel"].ReadOnly = false;

            DataView dv_1 = new DataView(dt, "sel = 0", "Razao_Social", DataViewRowState.CurrentRows);
            DataView dv_2 = new DataView(dt, "sel = 1", "Razao_Social", DataViewRowState.CurrentRows);

            this.lstEmpresas.DataSource = dv_1;
            this.lstEmpresas.DisplayMember = "Razao_Social";
            this.lstEmpresas.ValueMember = "Empresa";

            this.lstEmpresasSel.DataSource = dv_2;
            this.lstEmpresasSel.DisplayMember = "Razao_Social";
            this.lstEmpresasSel.ValueMember = "Empresa";
        }

        #endregion Carregar listas

        #region Gera agrupamentos para o fluxo de caixa

        private DataTable Gerar_Agrupamentos(Tipos_Agrupamentos tp_Agrupamento)
        {
            DataTable dt = new DataTable(tp_Agrupamento.ToString());

            DataColumn dc1 = new DataColumn("Referencia", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("Valor_Receber", Type.GetType("System.Decimal"));
            DataColumn dc3 = new DataColumn("Valor_Pagar", Type.GetType("System.Decimal"));
            DataColumn dc4 = new DataColumn("Saldo", Type.GetType("System.Decimal"));
            DataColumn dc5 = new DataColumn("Data", Type.GetType("System.Int32"));

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);

            //-- Varre registros
            foreach (DataRow row in this.DataSetLocal.Tables[0].Select())
            {
                string sFilter = "Referencia = '{0}'";
                DataRow newrow;
                DataRow[] fRow;
                string sNovaReferencia = string.Empty;
                int iNovaReferencia = 0;

                //-- Verifica o tipo de agrupamento e identifica o filtro.
                switch (tp_Agrupamento)
                {
                    case Tipos_Agrupamentos.Mes:
                        string[] sMes = System.Globalization.CultureInfo.GetCultureInfo("pt-br").DateTimeFormat.MonthNames;
                        iNovaReferencia = Convert.ToDateTime(row["Referencia"]).Month - 1;
                        sNovaReferencia = sMes[iNovaReferencia];
                        sNovaReferencia = sNovaReferencia.Substring(0, 1).ToUpper() + sNovaReferencia.Substring(1, sNovaReferencia.Length - 1);
                        sNovaReferencia += "/" + Convert.ToDateTime(row["Referencia"]).Year.ToString();
                        iNovaReferencia = Convert.ToInt32(Convert.ToDateTime(row["Referencia"]).ToString("yyyyMM"));

                        sFilter = string.Format(sFilter, sNovaReferencia);
                        break;

                    case Tipos_Agrupamentos.Semana:
                        string[] sSemana = System.Globalization.CultureInfo.GetCultureInfo("pt-br").DateTimeFormat.DayNames;
                        iNovaReferencia = (int)Convert.ToDateTime(row["Referencia"]).DayOfWeek;
                        sNovaReferencia = sSemana[iNovaReferencia];
                        sFilter = string.Format(sFilter, sNovaReferencia);
                        break;
                }

                //-- Verifica se já existe um item para este filtro.
                fRow = dt.Select(sFilter);
                if (fRow.Length == 0)
                {
                    newrow = dt.NewRow();

                    newrow["Data"] = iNovaReferencia;
                    newrow["Referencia"] = sNovaReferencia;
                    newrow["Valor_Receber"] = row["Valor_Receber"];
                    newrow["Valor_Pagar"] = row["Valor_Pagar"];
                    newrow["Saldo"] = 0;

                    dt.Rows.Add(newrow);
                }
                else
                {
                    newrow = fRow[0];

                    newrow.BeginEdit();
                    newrow["Valor_Receber"] = Convert.ToDecimal(newrow["Valor_Receber"]) + Convert.ToDecimal(row["Valor_Receber"]);
                    newrow["Valor_Pagar"] = Convert.ToDecimal(newrow["Valor_Pagar"]) + Convert.ToDecimal(row["Valor_Pagar"]);
                    newrow.EndEdit();
                }
            }

            return dt;
        }

        #endregion Gera agrupamentos para o fluxo de caixa

        private void f0063_user_AfterRefreshData()
        {
            frmWait f = new frmWait("Aguarde, gerando fluxo de caixa do periodo selecionado.", CompSoft.Tools.frmWait.Tipo_Imagem.Atencao);

            //-- Faz apresentação em formas diferente.
            DataTable dt_mes = this.Gerar_Agrupamentos(Tipos_Agrupamentos.Mes);
            DataTable dt_semana = this.Gerar_Agrupamentos(Tipos_Agrupamentos.Semana);

            if (!this.BindingSource.ContainsKey(dt_mes.TableName.ToLower()))
                this.BindingSource.Add(dt_mes.TableName.ToLower(), new BindingSource(dt_mes, null));

            if (!this.BindingSource.ContainsKey(dt_semana.TableName.ToLower()))
                this.BindingSource.Add(dt_semana.TableName.ToLower(), new BindingSource(dt_semana, null));

            this.Adicionar_DataSet(ref dt_mes);
            this.Adicionar_DataSet(ref dt_semana);

            //-- Calcula o saldo dia-a-dia.
            this.Calcula_Saldo(this.DataSetLocal.Tables["Fluxo"]);
            this.Calcula_Saldo(this.DataSetLocal.Tables["Mes"]);
            this.Calcula_Saldo(this.DataSetLocal.Tables["Semana"]);

            //-- Carrega dados...
            this.grdFluxoData.DataSource = this.DataSetLocal.Tables["Fluxo"];
            this.grdFluxoData.BindingSource.Sort = "Referencia asc";

            this.grdFluxoMes.DataSource = this.DataSetLocal.Tables["Mes"];
            this.grdFluxoMes.BindingSource.Sort = "data asc";

            this.grdFluxoSemana.DataSource = this.DataSetLocal.Tables["Semana"];
            this.grdFluxoSemana.BindingSource.Sort = "data asc";

            f.Close();
        }

        private void f0063_Load(object sender, EventArgs e)
        {
            this.DataSetLocal.Tables["Fluxo"].Columns["Saldo"].ReadOnly = false;

            this.Carregar_Listas();
        }

        private void grdFluxo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.grdFluxoData.Columns[3].Width = 80;
        }

        private void cmdIncluirTudo_Click(object sender, EventArgs e)
        {
            DataRow[] fRow = dt.Select("Sel = 0");
            foreach (DataRow row in fRow)
            {
                row.BeginEdit();
                row["Sel"] = true;
                row.EndEdit();
            }
        }

        private void cmdIncluir_Click(object sender, EventArgs e)
        {
            if (this.lstEmpresas.Items.Count > 0)
            {
                DataRow[] fRow = dt.Select(string.Format("Empresa = {0}", this.lstEmpresas.SelectedValue));
                foreach (DataRow row in fRow)
                {
                    row.BeginEdit();
                    row["Sel"] = true;
                    row.EndEdit();
                }
            }
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            if (this.lstEmpresasSel.Items.Count > 0)
            {
                DataRow[] fRow = dt.Select(string.Format("Empresa = {0}", this.lstEmpresasSel.SelectedValue));
                foreach (DataRow row in fRow)
                {
                    row.BeginEdit();
                    row["Sel"] = false;
                    row.EndEdit();
                }
            }
        }

        private void cmdExcluirTudo_Click(object sender, EventArgs e)
        {
            DataRow[] fRow = dt.Select("Sel = 1");
            foreach (DataRow row in fRow)
            {
                row.BeginEdit();
                row["Sel"] = false;
                row.EndEdit();
            }
        }

        private void f0063_user_AfterClear()
        {
            if (this.DataSetLocal.Tables["Mes"] != null)
                this.DataSetLocal.Tables["Mes"].Clear();

            if (this.DataSetLocal.Tables["Semana"] != null)
                this.DataSetLocal.Tables["Semana"].Clear();
        }
    }
}