using CompSoft.Data;
using System;
using System.Data;
using System.Text;

namespace ERP.Impostos
{
    public static class Impostos_NotaFiscal
    {
        #region Busca dados do cliente.

        public static DataRow Dados_Cliente(int iCliente)
        {
            //-- captura e retorna dados cliente.
            string sSQL = string.Empty;

            sSQL += "select ";
            sSQL += "   pessoa_juridica";
            sSQL += " , Razao_Social";
            sSQL += " , cpf_cnpj";
            sSQL += " , rg_ie";
            sSQL += " , space(14) as 'Fone1'";
            sSQL += " , email ";
            sSQL += " , Reducao_ICMS ";
            sSQL += " , Nao_Incide_ST ";
            sSQL += " , Estado_Correspondencia ";
            sSQL += " , consumidor_final ";
            sSQL += " , Regime_Normal_RPA ";
            sSQL += " from clientes";
            sSQL += "   where cliente = {0}";
            sSQL = string.Format(sSQL, iCliente);
            DataTable dt = SQL.Select(sSQL, "x", false);
            DataRow row = dt.Rows[0];

            return row;
        }

        #endregion Busca dados do cliente.

        #region Calcula redução de ICMS

        /// <summary>
        /// Realiza o calculo do valor total do item com a redução do ICMS
        /// Rotina só poderá ser executada se o cliente permitir redução de ICMS
        /// </summary>
        /// <param name="dValorItemComDesconto">Valor do produto já com o desconto.</param>
        /// <param name="iCliente">Código do cliente</param>
        /// <param name="dAlicotaReducao_ICMS">Referen Alicota de redução</param>
        /// <param name="row_tributos">datarow da tabela de produtos tributos</param>
        /// <returns>decimal com o valor calculada da redução</returns>
        public static decimal Calcula_Reducao_ICMS(decimal dValorItemComDesconto, int iCliente, out decimal dAlicotaReducao_ICMS, ref DataRow row_tributos)
        {
            decimal dRetorno = dValorItemComDesconto;
            dAlicotaReducao_ICMS = 0;

            //-- Verifica se existe tributos com excessão para este produto.
            if (row_tributos != null && (bool)row_tributos["Reducao_ICMS"] && (bool)row_tributos["Cobranca_ICMS"])
            {
                bool bClienteReducaoICMS = (bool)Dados_Cliente(iCliente)["reducao_icms"];
                if ((bool)row_tributos["Reducao_ICMS_Geral"] || ((bool)row_tributos["Reducao_ICMS_Cliente"] && bClienteReducaoICMS))
                {
                    dAlicotaReducao_ICMS = (decimal)row_tributos["Porcentagem_Reducao_ICMS"];
                    dRetorno = dRetorno - ((dRetorno * dAlicotaReducao_ICMS) / 100);
                    dRetorno = Math.Round(dRetorno, 2, MidpointRounding.AwayFromZero);
                }
            }

            return dRetorno;
        }

        #endregion Calcula redução de ICMS

        #region Calculo do ICMS

        public static decimal Calculo_ICMS(int iEmpresa, string sDestino, decimal dValorItemReducao, ref decimal dAlicota_ICMS, ref DataRow row_tributo)
        {
            decimal dValor = 0;
            decimal dICMS = 0;

            //-- Verifica se existem excessões de tributos para este produto.
            if (row_tributo != null)
            {
                if (!(bool)row_tributo["ICMS_Estado"])
                    dICMS = (decimal)row_tributo["icms"];
                else
                    dICMS = ICMS_Estado(iEmpresa, sDestino);
            }
            else
            {
                dICMS = ICMS_Estado(iEmpresa, sDestino);
            }

            dAlicota_ICMS = dICMS;

            dValor = (dValorItemReducao * dICMS) / 100;
            dValor = Math.Round(dValor, 2, MidpointRounding.AwayFromZero);

            return dValor;
        }

        #endregion Calculo do ICMS

        #region Alicota de ICMS para Origem e destimo

        /// <summary>
        /// Retorna o ICMS padrão para cada estado.
        /// </summary>
        /// <param name="sOrigem">Estado de origem</param>
        /// <param name="sDestino">Estado de destino</param>
        /// <returns>Decimal com a alicota do ICMS</returns>
        public static decimal ICMS_Estado(int iEmpresa, string sDestino)
        {
            string sSQL = string.Empty,
                sOrigem = string.Empty;

            //-- Localiza o estado de origem da empresa.
            sSQL += "select estado from empresas where empresa = {0}";
            sSQL = string.Format(sSQL, iEmpresa);
            sOrigem = SQL.ExecuteScalar(sSQL).ToString();

            //-- Busca ICMS por estado.
            sSQL = string.Empty;
            sSQL += "select icms from icms_estados where origem = '{0}' and destino = '{1}'";
            sSQL = string.Format(sSQL, sOrigem, sDestino);
            decimal dValor = (decimal)SQL.ExecuteScalar(sSQL);

            return dValor;
        }

        #endregion Alicota de ICMS para Origem e destimo

        #region Calacula a Substituição tributária.

        ///<summary>
        /// Calcula a substituição tributária do item.
        /// </summary>
        /// <param name="dValorItemReducao">Decimal com o valor do item já com a redução do ICMS</param>
        /// <param name="dAliquota_ICMS">Decimal com a aliquota do ICMS aplicada.</param>
        /// <param name="dValor_ICMS">Decimal com o valor do ICMS</param>
        /// <param name="dAliquota_Sub_Trib">Decimal que retorna a alicota da substituição tributária.</param>
        /// <param name="row_ProdTributo">DataRow com os dados dos tributos do produtos.</param>
        /// <param name="dAliquota_Reducao_ST">Decimal com a aliquota de redução da substituição tributária</param>
        /// <returns>Decimal com o valor da substituição tributária.</returns>
        public static decimal Calcula_Subs_Trib(decimal dValorItemReducao
            , decimal dAliquota_ICMS
            , decimal dValor_ICMS
            , ref decimal dAliquota_Sub_Trib
            , ref DataRow row_ProdTributo
            , bool fl_cliente_rpa
            , out decimal dValor_Base_ST
            , out decimal dAliquota_Reducao_ST)
        {
            decimal dValor_Substituicao = 0;
            dValor_Base_ST = 0;
            dAliquota_Reducao_ST = 0;

            //-- Verifica se é possivel incluir substituição tributária.
            if (row_ProdTributo != null && (bool)row_ProdTributo["Substituicao_Tributaria"] && (decimal)row_ProdTributo["Porcentagem_Substituicao_Tributaria"] > 0)
            {
                dAliquota_Sub_Trib = (decimal)row_ProdTributo["Porcentagem_Substituicao_Tributaria"];
                decimal dValor1 = (dValorItemReducao * dAliquota_Sub_Trib) / 100;
                dValor1 = dValorItemReducao + Math.Round(dValor1, 2, MidpointRounding.AwayFromZero);
                dValor_Base_ST = dValor1;
                dValor1 = Math.Round((dValor1 * dAliquota_ICMS) / 100, 2, MidpointRounding.AwayFromZero);

                if ((bool)row_ProdTributo["Reducao_ST"])
                {
                    if (fl_cliente_rpa)
                    {
                        if (row_ProdTributo["Porcentagem_Reducao_ST_RPA"] != DBNull.Value)
                        {
                            dAliquota_Reducao_ST = Convert.ToDecimal(row_ProdTributo["Porcentagem_Reducao_ST_RPA"]);
                        }
                        else
                        {
                            dAliquota_Reducao_ST = Convert.ToDecimal(row_ProdTributo["porcentagem_reducao_st"]);
                        }
                    }
                    else
                    {
                        dAliquota_Reducao_ST = Convert.ToDecimal(row_ProdTributo["porcentagem_reducao_st"]);
                    }

                    /*string sQueryAliquota = "select aliquota_reducao_st from empresas where empresa = {0}";
                    sQueryAliquota = string.Format(sQueryAliquota, row_ProdTributo["Empresa"]);
                    dAliquota_Reducao_ST = Convert.ToDecimal(SQL.ExecuteScalar(sQueryAliquota));*/
                    //dAliquota_Reducao_ST = Convert.ToDecimal(row_ProdTributo["porcentagem_reducao_st"]);
                    dValor1 = dValor1 - Math.Round(((dValorItemReducao * dAliquota_Reducao_ST) / 100), 2, MidpointRounding.AwayFromZero); //-- Calcula a dedução da substituição tributária.
                }

                dValor_Substituicao = dValor1;
            }

            return dValor_Substituicao;
        }

        #endregion Calacula a Substituição tributária.

        #region Busca a situação tributária do produto caso não exista o sistema busca a situação padrão que cobra integralmente.

        /// <summary>
        /// Busca a situação tributária do produto caso não exista o sistema busca a situação padrão que cobra integralmente.
        /// </summary>
        /// <param name="row_TribProduto">DataRow dos tributos do produto.</param>
        /// <returns>String com a situação tributária correta.</returns>
        public static string Localiza_Situacao_Tributaria(ref DataRow row_TribProduto, int iCliente, ref int iModalidade_Calculo_ICMS)
        {
            string sRetorno = string.Empty;
            if (row_TribProduto != null)
            {
                //-- Verifica se o produto está cadastrado com a cobrança do ICMS e redução de ICMS
                if ((bool)row_TribProduto["Reducao_ICMS"] && (bool)row_TribProduto["Cobranca_ICMS"])
                {
                    //-- Verifica se o cliente possui redução ICMS.
                    bool bClienteReducaoICMS = (bool)Dados_Cliente(iCliente)["reducao_icms"];
                    if ((bool)row_TribProduto["Reducao_ICMS_Geral"] || ((bool)row_TribProduto["Reducao_ICMS_Cliente"] && bClienteReducaoICMS))
                    {
                        //-- Caso ele possua utilize o item cadastrado no sistema.
                        sRetorno = row_TribProduto["situacao_tributaria"].ToString();
                    }
                }
                else
                    sRetorno = row_TribProduto["situacao_tributaria"].ToString();
            }

            return sRetorno;
        }

        #endregion Busca a situação tributária do produto caso não exista o sistema busca a situação padrão que cobra integralmente.

        #region Calcula o crédito do ICMS do Simples Nacional

        /// <summary>
        /// Calcula o crédito do ICMS do Simples Nacional
        /// </summary>
        /// <param name="iEmpresa">Int - Código da Empresa</param>
        /// <param name="iCliente">Int - Código do Cliente</param>
        /// <param name="dValorProduto">Decimal - Valor Total dos Itens * Quantidade</param>
        /// <param name="dAliquotaCreditoSN">Ref Decimal - Aliquota de crédito Simples Nacional</param>
        /// <param name="bST">Ref Bool - Indicando se o produto tem calculo de ST</param>
        /// <returns>Decimal - Valor calculado do crédito ICMS Simples Nacional</returns>
        public static decimal Calcula_CreditoICMS_SimplesNacional(int iEmpresa, int iCliente, decimal dValorProduto, ref decimal dAliquotaCreditoSN, bool bST)
        {
            decimal dValor_Credito = 0;

            //-- Encontra o regime tributário RPA para verifica se é permitido o calculo do crédito do simples nacional.
            bool bRegime_RPA = Convert.ToBoolean(Dados_Cliente(iCliente)["Regime_Normal_RPA"]);

            //-- Localiza o código de regime tributário e a aliquota da empresa
            StringBuilder sb = new StringBuilder(500);
            sb.AppendLine("select rt.regime_tributario, e.Aliquota_Credito_Simples_Nacional");
            sb.AppendLine(" from empresas e ");
            sb.AppendLine("  inner join Regimes_Tributarios rt on rt.Regime_Tributario = e.regime_tributario");
            sb.AppendFormat(" where e.empresa = {0}", iEmpresa);
            DataRow row_Empresa = SQL.Select(sb.ToString(), "x", false).Rows[0];

            int iRegime_tributario = Convert.ToInt32(row_Empresa["regime_tributario"]);

            //-- Se Regime Normal RPA = TRUE e Substituicao Tributaria = FALSE e Regime Tributário = 1 (Simples Nacional)
            if (bRegime_RPA && iRegime_tributario == 1)
            {
                dAliquotaCreditoSN = Convert.ToDecimal(row_Empresa["Aliquota_Credito_Simples_Nacional"]);

                dValor_Credito = (dValorProduto * dAliquotaCreditoSN) / 100;
                dValor_Credito = Math.Round(dValor_Credito, 2, MidpointRounding.AwayFromZero);
            }

            return dValor_Credito;
        }

        #endregion Calcula o crédito do ICMS do Simples Nacional

        #region Busca dados do produto

        /// <summary>
        /// Retorna os dados do produto.
        /// </summary>
        /// <param name="iProduto"></param>
        /// <returns></returns>
        internal static DataRow Dados_Produto(int iProduto)
        {
            string sSQL = string.Empty;
            sSQL += "select ";
            sSQL += "   pr.Produto";
            sSQL += " , pr.Desc_Produto";
            sSQL += " , um.Desc_Unidade_abreviado";
            sSQL += " , pr.Classificacao_fiscal";
            sSQL += " , pr.Peso_Bruto";
            sSQL += " , pr.Peso_Liquido";
            sSQL += " , pr.Qtde_Caixa";
            sSQL += " , pr.Qtde_Por_Caixa";
            sSQL += " from produtos pr ";
            sSQL += "  inner join unidades_medidas um on um.unidade_medida = pr.unidade_medida";
            sSQL += " where pr.produto = {0}";
            sSQL = string.Format(sSQL, iProduto);
            DataRow row = SQL.Select(sSQL, "x", false).Rows[0];

            return row;
        }

        /// <summary>
        /// Retorna os valores e regras de calculos para determinados produtos.
        /// </summary>
        /// <param name="iProduto">Código do produto</param>
        /// <param name="iEmpresa">Código da empresa</param>
        /// <param name="sDestino">Estado de destino do produto</param>
        /// <returns></returns>
        internal static DataRow Dados_Produtos_Tributos(int iProduto, int iEmpresa, int iCliente)
        {
            string sOrigem = string.Empty;
            StringBuilder sb = new StringBuilder();

            //-- busca dados do cliente
            DataRow row_Cliente = Impostos_NotaFiscal.Dados_Cliente(iCliente);

            //-- Localiza o estado de origem da empresa.
            sb.AppendFormat("select estado from empresas where empresa = {0}", iEmpresa);
            sOrigem = SQL.ExecuteScalar(sb.ToString(), true).ToString();

            //-- Localiza o registro de tributo da empresa.
            sb.Remove(0, sb.Length);
            sb.AppendLine("select top 1");
            sb.AppendLine("     pt.*");
            sb.AppendLine("   , st.Cobranca_ICMS");
            sb.AppendLine("   , st.Aplicacao_Substituicao_Tributaria");
            sb.AppendLine("   , st.Aplicacao_Reducao_ICMS");
            sb.AppendLine("   , st.Cobranca_ICMS");
            sb.AppendLine(" from produtos_tributos pt");
            sb.AppendLine("  inner join situacoes_tributaria st on st.situacao_tributaria = pt.situacao_tributaria");
            sb.AppendFormat(" where produto = {0} \r\n", iProduto);
            sb.AppendFormat("     and empresa = {0} \r\n", iEmpresa);
            sb.AppendFormat("     and origem = '{0}' \r\n", sOrigem);
            sb.AppendFormat("     and destino = '{0}' \r\n", row_Cliente["Estado_Correspondencia"].ToString());
            sb.AppendLine("     and convert(varchar(10), getdate(), 112) >= inicio_vigencia");
            sb.AppendLine("     and st.Aplicacao_Reducao_ICMS = ");
            sb.AppendLine("     case ");
            sb.AppendFormat("  when pt.reducao_icms = 1 and ((pt.reducao_ICMS_Cliente = 1 and 1={0}) or (pt.reducao_icms_geral = 1)) then 1", Convert.ToInt32(row_Cliente["Reducao_ICMS"]));
            sb.AppendLine("  else 0");
            sb.AppendLine("  end");
            sb.AppendLine("  and st.Aplicacao_Substituicao_Tributaria = ");
            sb.AppendLine("     case ");
            sb.AppendFormat("  when pt.Substituicao_Tributaria = 1 and 1={0} then 1", Convert.ToInt32(!Convert.ToBoolean(row_Cliente["Nao_Incide_ST"])));
            sb.AppendLine("  else 0");
            sb.AppendLine("  end");

            DataTable dt = SQL.Select(sb.ToString(), "x", false, false);

            //-- Caso exista excessões para este produto, origem e destino.
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }

        #endregion Busca dados do produto
    }
}