using CompSoft.Data;
using ERP.Impostos;
using System;
using System.Data;

namespace ERP.Reports
{
    public partial class r0004 : CompSoft.Reports.ReportBase
    {
        public r0004()
        {
            InitializeComponent();
        }

        private void Calcular()
        {
            try
            {
                decimal dPeso_Bruto = 0,
                        dPeso_Liquido = 0,
                        dPeso_BrutoProv = 0,
                        dPeso_LiquidoProv = 0,
                        dValorST = 0,
                        dValorTotal = 0;

                bool bGeraNF = Convert.ToBoolean(this.GetCurrentColumnValue("Gera_NF"));

                foreach (DataRowView row in ((DataRowView)this.DetailReport.GetCurrentRow()).DataView)
                {
                    if (row["Peso_Bruto"] != DBNull.Value)
                        dPeso_BrutoProv = (decimal)row["Peso_Bruto"];

                    if (row["Peso_Liquido"] != DBNull.Value)
                        dPeso_LiquidoProv = (decimal)row["Peso_Liquido"];

                    int iQtde = Convert.ToInt32(row["Qtde"]);

                    dPeso_Bruto += dPeso_BrutoProv * iQtde;
                    dPeso_Liquido += dPeso_LiquidoProv * iQtde;

                    if (bGeraNF)
                    {
                        dValorST += this.CalculaST(Convert.ToInt32(row["Produto"]), Convert.ToDecimal(row["Valor_Total"]));
                        dValorTotal += Convert.ToDecimal(row["Valor_Total"]);
                    }
                }

                this.lblPesoBruto.Text = dPeso_Bruto.ToString();
                this.lblPesoLiquido.Text = dPeso_Liquido.ToString();
                if (Convert.ToBoolean(this.GetCurrentColumnValue("Gera_NF")))
                {
                    this.cf_Report_Label62.Text = dValorST.ToString();
                    this.cf_Report_Label64.Text = (dValorST + dValorTotal).ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// Calcula ST do produto
        /// </summary>
        /// <param name="iProduto">int com o código do produto</param>
        /// <param name="dValor_Total_Produto">decimal com o valor total dos produtos</param>
        /// <returns>decimal com o valor da ST</returns>
        private decimal CalculaST(int iProduto, decimal dValor_Total_Produto)
        {
            decimal dValor_Base_Substituicao_Tributaria = 0
                    , dAliquota_Reducao_ST = 0
                    , dValor_Com_Reducao = 0
                    , dAlicotaReducao_ICMS = 0
                    , dValor_ICMS = 0
                    , dAliquota_ICMS = 0
                    , dAliquota_Substituicao_Tributaria = 0
                    , dValor_ST;

            string sDestino = string.Empty;

            DataRowView row = (DataRowView)this.GetCurrentRow();

            //-- Busca impostos dos tributos do produto
            DataRow row_prodTributos = Impostos_NotaFiscal.Dados_Produtos_Tributos(iProduto
                                                                                    , Convert.ToInt32(Convert.ToInt32(row["empresa"]))
                                                                                    , Convert.ToInt32(Convert.ToInt32(row["cliente"])));

            dValor_Com_Reducao = Impostos_NotaFiscal.Calcula_Reducao_ICMS(dValor_Total_Produto
                                                                                    , Convert.ToInt32(Convert.ToInt32(row["cliente"]))
                                                                                    , out dAlicotaReducao_ICMS
                                                                                    , ref row_prodTributos);

            sDestino = SQL.ExecuteScalar(string.Format("select Estado_Entrega from clientes where cliente = {0}", row["cliente"])).ToString();

            dValor_ICMS = Impostos_NotaFiscal.Calculo_ICMS(Convert.ToInt32(row["empresa"])
                                                            , sDestino
                                                            , dValor_Com_Reducao
                                                            , ref dAliquota_ICMS
                                                            , ref row_prodTributos);

            bool Regime_Normal_RPA = Convert.ToBoolean(SQL.ExecuteScalar(string.Format("select Regime_Normal_RPA from clientes where cliente = {0}", row["cliente"])));
            dValor_ST = Impostos_NotaFiscal.Calcula_Subs_Trib(dValor_Com_Reducao
                                                                , dAliquota_ICMS
                                                                , dValor_ICMS
                                                                , ref dAliquota_Substituicao_Tributaria
                                                                , ref row_prodTributos
                                                                , Regime_Normal_RPA
                                                                , out dValor_Base_Substituicao_Tributaria
                                                                , out dAliquota_Reducao_ST);

            return dValor_ST;
        }

        private void lblPesoBruto_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.Calcular();
        }

        private void cf_Report_Label53_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.cf_Report_Label53.Text.Length <= 11)
                this.cf_Report_Label53.FormatString = @"{0:000\.###\.###\-##}";
            else
                this.cf_Report_Label53.FormatString = @"{0:00\.000\.###\/####\-##}";
        }
    }
}