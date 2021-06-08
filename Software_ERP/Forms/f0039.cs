using CompSoft.compFrameWork;
using CompSoft.Data;
using ERP.Class;
using ERP.Impostos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0039 : CompSoft.FormSet
    {
        #region Enum

        private enum Tipos_Selecoes
        {
            Tudo,
            Notas_Fiscais,
            Cupom
        }

        #endregion Enum

        #region Variaveis membro da classe

        //-- Variaveis para geracao de nota fiscal
        private DataTable dt_pedidos;

        private int iNumero_NF = 0;
        private string sSerie_NF = string.Empty;
        private IList<decimal> il_Aliquota_ICMS = new List<decimal>();

        //-- Variaveis para controle de estoque
        private clsControleEstoque ceEstoque = new clsControleEstoque();

        private int iCodigo_mov_estoque = 0;

        #endregion Variaveis membro da classe

        #region Construtor

        public f0039()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Notas_Fiscais"
                , "select * from notas_fiscais"));

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "notas_fiscais_itens"
                , "select * from notas_fiscais_itens"));

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "notas_fiscais_duplicatas"
                , "select * from notas_fiscais_duplicatas"));

            InitializeComponent();
        }

        #endregion Construtor

        #region Trabalha com os números da nota fiscal.

        private void Numero_NF(bool bRegistraNota, int iEmpresa)
        {
            string sSQL = string.Empty;

            //-- Encontra o número da nota.
            sSQL += "select proxima_nota_fiscal, Serie_Nota_Fiscal from empresas where empresa = {0}";
            sSQL = string.Format(sSQL, iEmpresa);
            DataRow[] fRow = SQL.Select(sSQL, "x", bRegistraNota).Select();

            foreach (DataRow row in fRow)
            {
                iNumero_NF = Convert.ToInt32(row["proxima_nota_fiscal"]);
                sSerie_NF = row["Serie_Nota_Fiscal"].ToString();
            }

            //-- Verifica se o número será registrado.
            if (bRegistraNota)
            {
                sSQL = string.Empty;
                sSQL += "update empresas set Proxima_nota_fiscal = Proxima_nota_fiscal + 1 where empresa = {0}";
                sSQL = string.Format(sSQL, iEmpresa);
                SQL.Execute(sSQL, false);
            }
        }

        #endregion Trabalha com os números da nota fiscal.

        #region Selecionar itens no Grid de acordo com a escolha

        private void Selecinar_Itens_Grid(Tipos_Selecoes tipo_Selecao)
        {
            DataTable dt = (DataTable)this.grdPedidos.BindingSource.DataSource;
            string sFilter = string.Empty;
            switch (tipo_Selecao)
            {
                case Tipos_Selecoes.Notas_Fiscais:
                    sFilter = "Gera_NF = 1";
                    break;

                case Tipos_Selecoes.Cupom:
                    sFilter = "Gera_NF = 0";
                    break;
            }

            DataRow[] fRow = dt.Select(sFilter);
            foreach (DataRow row in fRow)
                row["Sel"] = true;

            this.grdPedidos.BindingSource.EndEdit();
        }

        #endregion Selecionar itens no Grid de acordo com a escolha

        #region Busca pedidos livre para realização de notas fiscais.

        private void Buscar_Pedidos()
        {
            string sSQL = string.Empty;

            sSQL = string.Empty;
            sSQL += "select ";
            sSQL += "   convert(bit, 0) as 'Sel'";
            sSQL += " , pe.Pedido";
            sSQL += " , pe.Empresa";
            sSQL += " , e.Nome_Fantasia as 'Nome_empresa'";
            sSQL += " , pe.Cliente";
            sSQL += " , cl.Razao_Social as 'Nome_Cliente'";
            sSQL += " , pe.Vendedor";
            sSQL += " , pe.Transportadora";
            sSQL += " , pe.Condicao_Pagamento_Pedido";
            sSQL += " , pe.Gera_NF";
            sSQL += " , case Gera_NF";
            sSQL += "     when 1 then 'Nota Fiscal'";
            sSQL += "     else 'Cupom'";
            sSQL += "   end as 'Tipo_Documento'";
            sSQL += " , pe.NF_Gerada";
            sSQL += " , pe.Tabela_Preco";
            sSQL += " , pe.Data_Pedido";
            sSQL += " , pe.Data_Entrega";
            sSQL += " , pe.Cancelado";
            sSQL += " , cl.Estado_Correspondencia as 'Estado_Entrega'";
            sSQL += " , pe.Bonificacao";
            sSQL += " , pe.Remessa_Deposito";
            sSQL += " , pe.Devolucao";
            sSQL += " from pedidos pe";
            sSQL += "  inner join clientes cl on cl.cliente = pe.cliente";
            sSQL += "  inner join empresas e on e.empresa = pe.empresa";
            sSQL += " where ";

            //-- Filtro padrão para pedidos.
            //--sSQL += " gera_nf = 1";
            sSQL += "     nf_gerada = 0";
            sSQL += " and cancelado = 0";

            //-- filtro especifico pelo cliente.
            if (this.chkCliente.Checked)
            {
                if (!string.IsNullOrEmpty(this.txtCodCliente.Text))
                    sSQL += "   and pe.cliente = " + this.txtCodCliente.Text;

                if (!string.IsNullOrEmpty(this.txtCliente.Text))
                    sSQL += string.Format("   and cl.Razao_Social like '%{0}%' ", this.txtCliente.Text);
            }

            if (this.chkEmpresa.Checked && this.cboEmpresa.SelectedIndex >= 0)
                sSQL += "   and pe.Empresa = " + this.cboEmpresa.SelectedValue;

            if (this.chkData.Checked)
            {
                if (this.optEntrega.Checked)
                    sSQL += "   and pe.Data_Entrega between '{0}' and '{1}'";

                if (this.optPedido.Checked)
                    sSQL += "   and pe.Data_Pedido between '{0}' and '{1}'";

                sSQL = string.Format(sSQL
                    , this.prdPeriodo.Data_Inicial_SQL
                    , this.prdPeriodo.Data_Termino_SQL);
            }

            dt_pedidos = SQL.Select(sSQL, "Pedidos", false);
            dt_pedidos.Columns[0].ReadOnly = false;

            if (this.grdPedidos.DataSource != null)
            {
                this.grdPedidos.BindingSource.DataSource = dt_pedidos;
            }
            else
            {
                this.grdPedidos.DataSource = new BindingSource(dt_pedidos, null);
            }
        }

        #endregion Busca pedidos livre para realização de notas fiscais.

        #region Busca dados da transportadora.

        private DataRow Dados_Transportadora(int iTransportadora)
        {
            string sSQL = string.Empty;
            sSQL += "select ";
            sSQL += "   Transportadora";
            sSQL += " , Razao_Social";
            sSQL += " , CNPJ";
            sSQL += " , Inscricao_Estadual ";
            sSQL += " , Endereco";
            sSQL += " , Numero";
            sSQL += " , Complemento";
            sSQL += " , Bairro";
            sSQL += " , Cidade";
            sSQL += " , Estado";
            sSQL += " , ddd1";
            sSQL += " , fone1";
            sSQL += " , Tipo_Frete";
            sSQL += " , Reg_Nacional_Transportador";
            sSQL += " , Placa";
            sSQL += " , UF_PLaca";
            sSQL += " from transportadoras";
            sSQL += " where transportadora = {0}";
            sSQL = string.Format(sSQL, iTransportadora);
            DataRow row = SQL.Select(sSQL, "x", false).Rows[0];

            return row;
        }

        #endregion Busca dados da transportadora.

        #region Encontra CFOP

        /// <summary>
        /// Encontra o CFOP de acordo com os parametros passados.
        /// </summary>
        /// <param name="iEmpresa">Código da empresa do pedido</param>
        /// <param name="iCliente">Código do cliente do pedido</param>
        /// <param name="row_prodTributos">Parametros dos tributos do produto</param>
        /// <returns>Object com o código do cfop ou DBNull.Value</returns>
        private object Encontrar_CFOP(int iEmpresa, int iCliente, ref DataRow row_prodTributos, bool bBonificacao, bool bRemessa_Deposito, bool bDevolucao)
        {
            //-- Cria a alimenta variaveis para pesquisa.
            string sEstadoDestino = string.Empty;
            bool bConsumidor_Final = false;
            bool bST = false;
            bool bReducao = false;
            DataRow row_Cliente = Impostos_NotaFiscal.Dados_Cliente(iCliente);

            if (row_prodTributos != null && (bool)row_prodTributos["Substituicao_Tributaria"])
                bST = true;

            if (row_prodTributos != null && (bool)row_prodTributos["Reducao_ICMS"])
            {
                if ((bool)row_prodTributos["Reducao_ICMS_Geral"])
                    bReducao = true;

                if ((bool)row_prodTributos["Reducao_ICMS_Cliente"] && (bool)row_Cliente["Reducao_ICMS"])
                    bReducao = true;
            }

            sEstadoDestino = row_Cliente["estado_correspondencia"].ToString();
            bConsumidor_Final = (bool)row_Cliente["consumidor_final"];

            //-- Encontra o CFOP para o estado.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select cfop from cfops_regras");
            sb.AppendLine(" where ");
            sb.AppendFormat("           empresa = {0}\r\n", iEmpresa);
            sb.AppendFormat("       and estado = '{0}'\r\n", sEstadoDestino);

            //-- Identifica se tem ST ou não.
            if (bST)
                sb.AppendLine("     and com_st = 1");
            else
                sb.AppendLine("     and sem_st = 1");

            //-- Identifica se tem Redução de ICMS ou não.
            if (bReducao)
                sb.AppendLine("     and com_Reducao = 1");
            else
                sb.AppendLine("     and sem_Reducao = 1");

            //-- Identifica se é Consumidor_Final ou Revenda
            if (bConsumidor_Final)
                sb.AppendLine("     and consumidor_final = 1");
            else
                sb.AppendLine("     and revenda = 1");

            //-- Identifica se é bonificação
            if (bBonificacao)
                sb.AppendLine("     and bonificacao = 1");
            else
                sb.AppendLine("     and bonificacao = 0");

            //-- Identifica se é Remessa Deposito
            if (bRemessa_Deposito)
                sb.AppendLine("     and remessa_deposito = 1");
            else
                sb.AppendLine("     and remessa_deposito = 0");

            //-- Identifica se é Devolucao
            if (bDevolucao)
                sb.AppendLine("     and Devolucao = 1");
            else
                sb.AppendLine("     and devolucao = 0");

            object oCFOP = SQL.ExecuteScalar(sb.ToString());

            //-- Caso não tenha encontrado para o estado desejado... busque para todos os estados.
            if (oCFOP == DBNull.Value || oCFOP == null)
            {
                sb.Remove(0, sb.Length);
                sb.AppendLine("select cfop from cfops_regras");
                sb.AppendLine(" where ");
                sb.AppendFormat("      empresa = {0}\r\n", iEmpresa);
                sb.AppendLine("  and estado is null");

                //-- Identifica se tem ST ou não.
                if (bST)
                    sb.AppendLine("  and com_st = 1");
                else
                    sb.AppendLine("     and sem_st = 1");

                //-- Identifica se tem Redução de ICMS ou não.
                if (bReducao)
                    sb.AppendLine("  and com_Reducao = 1");
                else
                    sb.AppendLine("     and sem_Reducao = 1");

                //-- Identifica se é Consumidor_Final ou Revenda
                if (bConsumidor_Final)
                    sb.AppendLine("  and consumidor_final = 1");
                else
                    sb.AppendLine("  and revenda = 1");

                //-- Identifica se é bonificação
                if (bBonificacao)
                    sb.AppendLine("     and bonificacao = 1");
                else
                    sb.AppendLine("     and bonificacao = 0");

                //-- Identifica se é Remessa Deposito
                if (bRemessa_Deposito)
                    sb.AppendLine("     and remessa_deposito = 1");
                else
                    sb.AppendLine("     and remessa_deposito = 0");

                //-- Identifica se é Devolucao
                if (bDevolucao)
                    sb.AppendLine("     and Devolucao = 1");
                else
                    sb.AppendLine("     and devolucao = 0");

                oCFOP = SQL.ExecuteScalar(sb.ToString());
            }

            return oCFOP;
        }

        #endregion Encontra CFOP

        #region Cria capa da nota fiscal.

        /// <summary>
        /// Gera capa da nota fiscal de acordo com o pedido.
        /// </summary>
        /// <param name="row_ped">DataRow com dados da capa do pedido.</param>
        private bool Cria_Capa_Nota_Fiscal(DataRow row_ped)
        {
            bool bRetorno = true;

            //-- Captura e alimenta dados para capa da nota.
            DataRow row_cliente = Impostos_NotaFiscal.Dados_Cliente((int)row_ped["cliente"]);
            DataRow row_frete = this.Dados_Transportadora((int)row_ped["Transportadora"]);

            //-- Alimenta dados da nota.
            DataRow newrow = this.DataSetLocal.Tables["Notas_Fiscais"].NewRow();
            newrow["Numero_Nota"] = iNumero_NF;
            newrow["Serie_Nota"] = sSerie_NF;

            newrow["Empresa"] = row_ped["Empresa"];
            newrow["cliente"] = row_ped["cliente"];
            newrow["Pedido"] = row_ped["Pedido"];

            if ((bool)row_ped["gera_nf"])
                newrow["CFOP"] = this.Encontra_CFOP_Nota();

            newrow["Tipo_Entrada"] = false;
            newrow["Tipo_Saida"] = true;
            newrow["Impressa"] = false;
            newrow["Cancelada"] = false;

            //-- Trata data
            DateTime dtEmis = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            DateTime dtSaiEnt = Convert.ToDateTime(row_ped["Data_Entrega"]);
            if (dtSaiEnt < dtEmis)
                dtSaiEnt = dtEmis;

            newrow["Data_Emissao"] = dtEmis;
            newrow["Data_Entrega"] = dtSaiEnt;

            newrow["Condicao_Pagamento_Pedido"] = row_ped["Condicao_Pagamento_Pedido"];
            newrow["Tipo_Frete"] = row_frete["Tipo_Frete"];
            newrow["Transportadora"] = row_frete["Transportadora"];

            newrow["Chave_Acesso"] = DBNull.Value;
            newrow["Placa_Transporte"] = row_frete["Placa"];
            newrow["UF_Placa_Transporte"] = row_frete["UF_PLaca"];
            newrow["Reg_Nacional_Transportador"] = row_frete["Reg_Nacional_Transportador"];

            //-- Calculos
            object oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_Base_ICMS)", "Nota_Fiscal is null");
            decimal dValorBaseICMS = oValor == DBNull.Value ? 0 : Convert.ToDecimal(oValor);
            newrow["Valor_Base_ICMS"] = oValor;

            oValor = DBNull.Value;
            decimal dValorICMS = this.Calcula_Aliquota_ICMS(dValorBaseICMS);
            if (dValorICMS > 0)
                oValor = dValorICMS;
            newrow["Valor_ICMS"] = oValor;

            oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_Base_Substituicao_Tributaria)", "Nota_Fiscal is null");
            //decimal dValor_Base_SubsTr = oValor == DBNull.Value ? 0 : Convert.ToDecimal(oValor);
            newrow["Valor_Base_Substituicao_ICMS"] = oValor;
            if (oValor != DBNull.Value)
            {
                newrow["Valor_ICMS"] = DBNull.Value;
                newrow["Valor_Base_ICMS"] = DBNull.Value;
            }

            oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_Substituicao_Tributaria)", "Nota_Fiscal is null");
            decimal dValorSubsTrib = oValor == DBNull.Value ? 0 : Convert.ToDecimal(oValor);
            newrow["Valor_Substituicao_ICMS"] = oValor;

            oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_Cred_SN)", "Nota_Fiscal is null");
            newrow["Valor_Cred_Simples_Nacional"] = oValor;

            oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_IPI)", "Nota_Fiscal is null");
            newrow["Valor_IPI"] = oValor;

            oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_PIS)", "Nota_Fiscal is null");
            newrow["Valor_PIS"] = oValor;

            oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_COFINS)", "Nota_Fiscal is null");
            newrow["Valor_COFINS"] = oValor;

            oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_Total_Item)", "Nota_Fiscal is null");
            //decimal dValorProduto = oValor == DBNull.Value ? 0 : Convert.ToDecimal(oValor);
            newrow["Valor_Total_Produtos"] = oValor;

            newrow["Valor_Total_Nota"] = Convert.ToDecimal(newrow["Valor_Total_Produtos"]) + dValorSubsTrib;

            int iQtde = Convert.ToInt32(this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Qtde_Por_Caixa)", "Nota_Fiscal is null"));
            newrow["Quantidade_Itens"] = iQtde;

            Funcoes func;
            newrow["Especie"] = func.Busca_Propriedade("Especie_NF");

            //-- newrow["ICMS_Seguro"] = 0;
            //-- newrow["Valor_Desconto"] = 0;
            //-- newrow["Numero"] = string.Empty;

            //-- Verifica se será calculado o crédito do ICMS.

            newrow["Reg_Nacional_Transportador"] = row_frete["Reg_Nacional_Transportador"];

            oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Peso_Bruto)", "Nota_Fiscal is null");
            newrow["Peso_Bruto"] = oValor == DBNull.Value ? 0 : Convert.ToDecimal(oValor); ;

            oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Peso_Liquido)", "Nota_Fiscal is null");
            newrow["Peso_Liquido"] = oValor == DBNull.Value ? 0 : Convert.ToDecimal(oValor); ;

            //-- Identifica se a nota vai ser baixada automaticamente.
            newrow["Estoque_Baixado"] = clsControleEstoque.Baixa_estoque_manual;

            this.DataSetLocal.Tables["Notas_Fiscais"].Rows.Add(newrow);

            return bRetorno;
        }

        #endregion Cria capa da nota fiscal.

        #region Cria itens para nota fiscal.

        /// <summary>
        /// Gera capa da nota fiscal de acordo com o pedido.
        /// </summary>
        /// <param name="row_ped">DataRow com dados dos itens do pedido.</param>
        private bool Cria_Itens_Nota_Fiscal(DataRow row_Iped, DataRow row_Ped)
        {
            bool bRetorno = true;
            int iProduto = (int)row_Iped["produto"]
                , iEmpresa = (int)row_Ped["Empresa"]
                , iModalidade_Calculo_ICMS = -1;

            string sDestino = row_Ped["Estado_Entrega"].ToString()
                , sSituacao_Tributaria = "---";

            bool bRegime_RPA = (bool)Impostos_NotaFiscal.Dados_Cliente(Convert.ToInt32(row_Ped["cliente"]))["Regime_Normal_RPA"];
            bool bCalcular_Credito_ICMS = false;

            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select rt.Calcular_Credito_ICMS");
                sb.AppendLine(" from empresas e");
                sb.AppendLine("  inner join regimes_tributarios rt on rt.regime_tributario = e.regime_tributario");
                sb.AppendFormat(" where empresa = {0}", row_Ped["empresa"]);
                bCalcular_Credito_ICMS = Convert.ToBoolean(SQL.ExecuteScalar(sb.ToString()));
            }

            DataRow row_produto = Impostos_NotaFiscal.Dados_Produto(iProduto);
            DataRow row_prodTributos = Impostos_NotaFiscal.Dados_Produtos_Tributos(iProduto, iEmpresa, (Int32)row_Ped["Cliente"]);

            //-- Adiciona nova registro para nota fiscal.
            DataRow newrow = this.DataSetLocal.Tables["Notas_Fiscais_itens"].NewRow();

            //-- Realiza calculos para itens da nota.
            decimal dAliquota_ICMS = 0
                , dAliquota_IPI = 0
                , dAliquota_Substituicao_Tributaria = 0
                , dValor_Com_Reducao = 0
                , dValor_ICMS = 0
                , dValor_IPI = 0
                , dValor_Substituicao_Tributaria = 0
                , dValor_Base_Substituicao_Tributaria = 0
                , dValor_Base_PIS = 0
                , dValor_Base_COFINS = 0
                , dAliquota_PIS = 0
                , dAliquota_COFINS = 0
                , dValor_PIS = 0
                , dValor_COFINS = 0
                , dAliquota_Reducao_ST = 0
                , dAliquota_Credito_ICMS = 0
                , dValor_Credito_ICMS = 0
                , dAlicotaReducao_ICMS = 0
                , dAliquota_CredSN = 0
                , dValor_CredSN = 0;

            //-- Verifica se é NF para calculo dos impostos.
            if ((bool)row_Ped["Gera_NF"])
            {
                //-- Localiza o tipo de situação tributária que será utilizado.
                sSituacao_Tributaria = Impostos_NotaFiscal.Localiza_Situacao_Tributaria(ref row_prodTributos
                    , (int)row_Ped["cliente"]
                    , ref iModalidade_Calculo_ICMS);

                //-- Encontra o CFOP da NF e atualiza no campo.
                newrow["CFOP"] = this.Encontrar_CFOP(iEmpresa
                    , Convert.ToInt32(row_Ped["Cliente"])
                    , ref row_prodTributos
                    , (bool)row_Ped["Bonificacao"]
                    , (bool)row_Ped["Remessa_Deposito"]
                    , (bool)row_Ped["Devolucao"]);

                //-- Calcula o valor do crédito do icms para o regime Simples Nacional
                dValor_CredSN = Impostos_NotaFiscal.Calcula_CreditoICMS_SimplesNacional(iEmpresa
                                    , (int)row_Ped["cliente"]
                                    , (decimal)row_Iped["Valor_Total"]
                                    , ref dAliquota_CredSN, (bool)row_prodTributos["Substituicao_Tributaria"]);

                //-- Redução de ICMS e Valor do ICMS.
                dValor_Com_Reducao = Impostos_NotaFiscal.Calcula_Reducao_ICMS((decimal)row_Iped["Valor_Total"], (int)row_Ped["cliente"], out dAlicotaReducao_ICMS, ref row_prodTributos);

                //-- Calcula o ICMS do produto.
                dValor_ICMS = Impostos_NotaFiscal.Calculo_ICMS(iEmpresa, sDestino, dValor_Com_Reducao, ref dAliquota_ICMS, ref row_prodTributos);

                if (row_prodTributos != null && row_prodTributos["IPI"] != DBNull.Value)
                {
                    //-- Calcula o IPI.
                    dValor_IPI = ((decimal)row_Iped["Valor_Total"] * (decimal)row_prodTributos["IPI"]) / 100;
                    dValor_IPI = Math.Round(dValor_IPI, 2, MidpointRounding.AwayFromZero);
                }

                ////------ Verificar como irá calculo PIS e COFINS caso o produto selecionado não possua Produtos_Tributos.
                //-- Calculo PIS
                if (row_prodTributos["Porcentagem_PIS"] != null & row_prodTributos["Porcentagem_PIS"] != DBNull.Value)
                {
                    dValor_Base_PIS = (decimal)row_Iped["Valor_Total"];
                    dAliquota_PIS = (decimal)row_prodTributos["Porcentagem_PIS"];
                    dValor_PIS = (dValor_Base_PIS * dAliquota_PIS) / 100;
                    dValor_PIS = Math.Round(dValor_PIS, 2, MidpointRounding.AwayFromZero);
                }

                if (row_prodTributos["Porcentagem_COFINS"] != DBNull.Value)
                {
                    //-- Calculo COFINS
                    dValor_Base_COFINS = (decimal)row_Iped["Valor_Total"];
                    dAliquota_COFINS = (decimal)row_prodTributos["Porcentagem_COFINS"];
                    dValor_COFINS = (dValor_Base_COFINS * dAliquota_COFINS) / 100;
                    dValor_COFINS = Math.Round(dValor_COFINS, 2, MidpointRounding.AwayFromZero);
                }
                ////------  FIM

                //-- Calcula a Substituição tributária.
                bool Regime_Normal_RPA = Convert.ToBoolean(SQL.ExecuteScalar(string.Format("select Regime_Normal_RPA from clientes where cliente = {0}", row_Ped["cliente"])));

                dValor_Substituicao_Tributaria = Impostos_NotaFiscal.Calcula_Subs_Trib(dValor_Com_Reducao
                                , dAliquota_ICMS
                                , dValor_ICMS
                                , ref dAliquota_Substituicao_Tributaria
                                , ref row_prodTributos
                                , Regime_Normal_RPA
                                , out dValor_Base_Substituicao_Tributaria
                                , out dAliquota_Reducao_ST);

                //-- Calcula o crédito do ICMS
                if (row_prodTributos["Porcentagem_Credito_ICMS"] != DBNull.Value)
                {
                    decimal dValor_Produtos_tmp = Convert.ToDecimal(row_Iped["Valor_Total"]) + dValor_Substituicao_Tributaria;

                    dAliquota_Credito_ICMS = Convert.ToDecimal(row_prodTributos["Porcentagem_Credito_ICMS"]);

                    dValor_Credito_ICMS = (dValor_Produtos_tmp * dAliquota_Credito_ICMS) / 100;
                    dValor_Credito_ICMS = Math.Round(dValor_Credito_ICMS, 2, MidpointRounding.AwayFromZero);
                }

                //-- Adiciona em IList
                this.Aliquota_Array(dAliquota_ICMS);

                if (!sSituacao_Tributaria.Equals("---"))
                {
                    if (row_prodTributos != null && Convert.ToBoolean(row_prodTributos["Cobranca_ICMS"]))
                    {
                        iModalidade_Calculo_ICMS = Convert.ToInt32(row_prodTributos["Modalidade_Calculo_ICMS"]);
                        newrow["Modalidade_Calculo_ICMS"] = iModalidade_Calculo_ICMS;
                    }

                    newrow["Situacao_Tributaria"] = sSituacao_Tributaria;
                    newrow["Classificacao_Fiscal"] = row_produto["Classificacao_fiscal"];
                }

                if (!bRegime_RPA)
                    newrow["CSOSN"] = row_prodTributos["CSOSN"];
                else
                    newrow["CSOSN"] = row_prodTributos["CSOSN_RPA"];
            }

            //-- Dados da nota.
            newrow["Produto"] = row_Iped["Produto"];
            newrow["Desc_Produto"] = row_produto["desc_produto"];
            newrow["Desc_Unidade_Abrevidado"] = row_produto["Desc_Unidade_abreviado"];
            newrow["Quantidade"] = row_Iped["qtde"];

            //-- Verifica se faz o calculo por caixa ou geral.
            if ((bool)row_produto["Qtde_Caixa"])
            {
                decimal iQtdePorCaixa = Convert.ToDecimal(row_Iped["qtde"]) / Convert.ToDecimal(row_produto["Qtde_Por_Caixa"]);
                iQtdePorCaixa = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(iQtdePorCaixa)));
                newrow["Qtde_Por_Caixa"] = iQtdePorCaixa;
            }
            else
            {
                newrow["Qtde_Por_Caixa"] = row_Iped["qtde"];
            }

            newrow["Valor_Unitario"] = row_Iped["Valor_Unitario"];
            newrow["Valor_Total_Item"] = row_Iped["Valor_Total"];
            newrow["Peso_Bruto"] = Convert.ToDecimal(row_produto["Peso_Bruto"]) * Convert.ToInt32(row_Iped["qtde"]);
            newrow["Peso_Liquido"] = Convert.ToDecimal(row_produto["Peso_Liquido"]) * Convert.ToInt32(row_Iped["qtde"]);
            newrow["Percentual_Adicionado_Substituicao_Tributaria"] = DBNull.Value;

            if (dAliquota_Substituicao_Tributaria > 0)
                newrow["Aliquota_Substituicao_Tributaria"] = dAliquota_Substituicao_Tributaria;

            if (dValor_Substituicao_Tributaria > 0)
                newrow["Valor_Substituicao_Tributaria"] = dValor_Substituicao_Tributaria;

            if (dValor_Base_Substituicao_Tributaria > 0)
                newrow["Valor_Base_Substituicao_Tributaria"] = dValor_Base_Substituicao_Tributaria;

            if (dAliquota_Substituicao_Tributaria > 0)
                newrow["Modalidade_Calculo_ICMS_ST"] = row_prodTributos["Modalidade_Calculo_ICMS_ST"];

            if (dAliquota_Reducao_ST > 0)
                newrow["Percentual_Reducao_Substituicao_Tributaria"] = dAliquota_Reducao_ST;

            if (dAliquota_Substituicao_Tributaria > 0)
                newrow["Modalidade_Calculo_ICMS_ST"] = row_prodTributos["Modalidade_Calculo_ICMS_ST"];

            if (dAliquota_IPI > 0)
                newrow["Aliquota_IPI"] = dAliquota_IPI;

            if (dValor_IPI > 0)
                newrow["Valor_IPI"] = dValor_IPI;

            if (dAliquota_Credito_ICMS > 0)
                newrow["Percentual_Credito_ICMS"] = dAliquota_Credito_ICMS;

            if (dValor_Credito_ICMS > 0)
                newrow["Valor_Credito_ICMS"] = dValor_Credito_ICMS;

            if (dAlicotaReducao_ICMS > 0)
                newrow["Percentual_Reducao_ICMS"] = dAlicotaReducao_ICMS;

            if (dAliquota_CredSN > 0)
                newrow["Aliquota_Cred_SN"] = dAliquota_CredSN;

            if (dValor_CredSN > 0)
                newrow["Valor_Cred_SN"] = dValor_CredSN;

            //-- ICMS
            if (!(bRegime_RPA && bCalcular_Credito_ICMS) && dValor_Substituicao_Tributaria <= 0 && sSituacao_Tributaria != "041")
            {
                if (dAliquota_ICMS > 0)
                    newrow["Aliquota_ICMS"] = dAliquota_ICMS;

                //-- caso a aliquota for maior que zero o sistema permite guardar a informação da base de calculo ICMS
                if (dAliquota_ICMS > 0 && dValor_Com_Reducao > 0)
                    newrow["Valor_Base_ICMS"] = dValor_Com_Reducao;

                if (dAliquota_ICMS > 0 && dValor_ICMS > 0)
                    newrow["Valor_ICMS"] = dValor_ICMS;
            }

            //-- PIS
            if (row_prodTributos["Situacao_Tributaria_PIS"] != null || row_prodTributos["Situacao_Tributaria_PIS"] != DBNull.Value)
            {
                if (Convert.ToInt32(row_prodTributos["Situacao_Tributaria_PIS"]) == 99)
                    dValor_Base_PIS = 0;

                newrow["Situacao_Tributaria_PIS"] = row_prodTributos["Situacao_Tributaria_PIS"];
                newrow["Valor_Base_PIS"] = dValor_Base_PIS;
                newrow["Aliquota_PIS"] = dAliquota_PIS;
                newrow["QTDE_PIS"] = DBNull.Value;
                newrow["Valor_Aliquota_PIS"] = DBNull.Value;
                newrow["Valor_PIS"] = dValor_PIS;
            }

            //-- COFINS
            if (row_prodTributos["Situacao_Tributaria_COFINS"] != null && row_prodTributos["Situacao_Tributaria_COFINS"] != DBNull.Value)
            {
                if (Convert.ToInt32(row_prodTributos["Situacao_Tributaria_COFINS"]) == 99)
                    dValor_Base_COFINS = 0;

                newrow["Situacao_Tributaria_COFINS"] = row_prodTributos["Situacao_Tributaria_COFINS"];
                newrow["Valor_Base_COFINS"] = dValor_Base_COFINS;
                newrow["Aliquota_COFINS"] = dAliquota_COFINS;
                newrow["QTDE_COFINS"] = DBNull.Value;
                newrow["Valor_Aliquota_COFINS"] = DBNull.Value;
                newrow["Valor_COFINS"] = dValor_COFINS;
            }

            this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Rows.Add(newrow);

            return bRetorno;
        }

        #endregion Cria itens para nota fiscal.

        #region Cria itens para duplicatas da nota fiscal

        /// <summary>
        /// Cria duplicatas da ultima nota fiscal criada.
        /// </summary>
        /// <returns>True/False indicando se o processo foi concluido.</returns>
        private bool Cria_Duplicatas_Nota_Fiscal(DataRow row_ped)
        {
            bool bRetorno = true;
            decimal dValorTotalNota = 0;
            int iParcela = 1;
            string sSQL = string.Empty;

            //-- Encontra dias para gerar os desdobramentos dos vencimentos
            sSQL = "select * from condicoes_pagamento_pedido_itens  where condicao_pagamento_pedido = {0}";
            sSQL = string.Format(sSQL, row_ped["condicao_pagamento_pedido"]);
            DataRow[] fRow_Condicao = SQL.Select(sSQL, "x", false).Select();

            //-- Encontra ao valor total da nota.
            DataRow[] fRow = this.DataSetLocal.Tables["Notas_Fiscais"].Select("pedido = " + row_ped["pedido"].ToString());
            foreach (DataRow row in fRow)
                dValorTotalNota = (decimal)row["Valor_Total_Nota"];

            decimal dValor_Parcela = Math.Round(dValorTotalNota / (fRow_Condicao.Length == 0 ? 1 : fRow_Condicao.Length), 2, MidpointRounding.AwayFromZero);

            //-- Gera as parcelas.
            foreach (DataRow row_condicao in fRow_Condicao)
            {
                DataRow newrow = this.DataSetLocal.Tables["Notas_Fiscais_Duplicatas"].NewRow();

                newrow["Numero_Parcela"] = iParcela;
                newrow["Data_Vencimento"] = Convert.ToDateTime(this.txtDataBaseVencimento.EditValue).AddDays(Convert.ToInt32(row_condicao["Prazo_dias"]));
                if (iParcela == fRow_Condicao.Length)
                {
                    object oValor = this.DataSetLocal.Tables["Notas_Fiscais_Duplicatas"].Compute("sum(Valor_Duplicata)", "Nota_Fiscal is null");
                    if (oValor == DBNull.Value)
                        newrow["Valor_Duplicata"] = dValor_Parcela;
                    else
                        newrow["Valor_Duplicata"] = dValorTotalNota - Convert.ToDecimal(oValor);
                }
                else
                    newrow["Valor_Duplicata"] = dValor_Parcela;

                this.DataSetLocal.Tables["Notas_Fiscais_Duplicatas"].Rows.Add(newrow);
                iParcela++;
            }

            return bRetorno;
        }

        #endregion Cria itens para duplicatas da nota fiscal

        #region Marca o pedido como NF gerada.

        /// <summary>
        /// Marca o pedido como NF gerada.
        /// </summary>
        /// <param name="iNumero_Pedido">Númedo do pedido que deve ser atualizado.</param>
        private void Atualiza_NF_Gerada(int iNumero_Pedido)
        {
            string sSQL = string.Empty;
            sSQL += "update Pedidos set ";
            sSQL += "  NF_Gerada = 1";
            sSQL += " where Pedido = {0}";
            sSQL = string.Format(sSQL, iNumero_Pedido);

            SQL.Execute(sSQL);
        }

        #endregion Marca o pedido como NF gerada.

        #region Calculos dos totais de aliquotas de ICMS.

        #region Adiciona aliquotas em array para calculo

        private void Aliquota_Array(decimal dValor)
        {
            if (dValor > 0 && !il_Aliquota_ICMS.Contains(dValor))
                il_Aliquota_ICMS.Add(dValor);
        }

        #endregion Adiciona aliquotas em array para calculo

        #region Calcula o ICMS com base na aliquota

        private decimal Calcula_Aliquota_ICMS(decimal dValorBaseICMS)
        {
            decimal dValorICMS_TotalItens = 0,
                dValorICMS_TotalRecalculo = 0;

            //-- Varre todas as aliquotas encontradas no sistema.
            foreach (decimal dAliquotaICMS in il_Aliquota_ICMS)
            {
                decimal dValorICMS_Itens = 0,
                    dValorICMS_Recalculo = 0;

                //-- Busca soma do ICMS dos itens por aliquota de ICMS
                try
                {
                    object oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_ICMS)"
                        , string.Format("Nota_Fiscal is null and Aliquota_ICMS = {0}", dAliquotaICMS));
                    dValorICMS_Itens = oValor == DBNull.Value ? 0 : Convert.ToDecimal(oValor);

                    //-- Calcula novo valor.
                    dValorICMS_Recalculo = Math.Round(((dValorBaseICMS * dAliquotaICMS) / 100), 2, MidpointRounding.AwayFromZero);

                    //-- Acumula os totais
                    dValorICMS_TotalItens += dValorICMS_Itens;
                    dValorICMS_TotalRecalculo += dValorICMS_Recalculo;

                    //-- Verifica se o valor do recalculo é maior que o valor calculado nos itens.
                    if (dValorICMS_Recalculo > dValorICMS_Itens)
                    {
                        DataView dv = new DataView(this.DataSetLocal.Tables["Notas_Fiscais_Itens"]
                            , string.Format("Nota_Fiscal is null and Aliquota_ICMS = {0}", dAliquotaICMS)
                            , ""
                            , DataViewRowState.CurrentRows);

                        decimal dDiferenca = dValorICMS_Recalculo - dValorICMS_Itens;

                        //-- altera o valor do item.
                        dv[dv.Count - 1].BeginEdit();
                        dv[dv.Count - 1]["Valor_ICMS"] = Convert.ToDecimal(dv[dv.Count - 1]["Valor_ICMS"]) + dDiferenca;
                        dv[dv.Count - 1].EndEdit();
                    }
                }
                catch
                { }
            }

            if (dValorICMS_TotalRecalculo > dValorICMS_TotalItens)
                return dValorICMS_TotalRecalculo;
            else
                return dValorICMS_TotalItens;
        }

        #endregion Calcula o ICMS com base na aliquota

        #endregion Calculos dos totais de aliquotas de ICMS.

        #region Encontra o CFOP com o maior valor na NF

        private int Encontra_CFOP_Nota()
        {
            int iCFOP = 0;

            DataTable dt = new DataTable("x");
            dt.Columns.Add("CFOP", typeof(System.Int32));
            dt.Columns.Add("Valor", typeof(System.Decimal));

            DataRow[] fRow = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Select("Nota_Fiscal is null");
            foreach (DataRow row in fRow)
            {
                dt.DefaultView.RowFilter = string.Format("cfop = {0}", row["cfop"]);
                if (dt.DefaultView.Count == 0)
                {
                    DataRow newrow = dt.NewRow();
                    newrow["cfop"] = row["cfop"];
                    newrow["valor"] = row["Valor_Total_Item"];
                    dt.Rows.Add(newrow);
                }
                else
                {
                    DataRowView selrow = dt.DefaultView[0];
                    selrow.BeginEdit();
                    selrow["Valor"] = Convert.ToDecimal(selrow["Valor"]) + Convert.ToDecimal(row["Valor_Total_Item"]);
                    selrow.EndEdit();
                }
            }

            dt.DefaultView.RowFilter = string.Empty;
            dt.DefaultView.Sort = "valor asc";
            if (dt.DefaultView.Count > 0)
            {
                iCFOP = Convert.ToInt32(dt.DefaultView[0]["CFOP"]);
            }

            return iCFOP;
        }

        #endregion Encontra o CFOP com o maior valor na NF

        private void chkData_CheckedChanged(object sender, EventArgs e)
        {
            this.optEntrega.Enabled = this.chkData.Checked;
            this.optPedido.Enabled = this.chkData.Checked;
            this.prdPeriodo.Enabled = this.chkData.Checked;
        }

        private void chkEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            this.cboEmpresa.Enabled = chkEmpresa.Checked;
        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCliente.Enabled = this.chkCliente.Checked;
            this.txtCodCliente.Enabled = this.chkCliente.Checked;
        }

        private void f0039_Shown(object sender, EventArgs e)
        {
            this.txtCliente.Enabled = false;
            this.txtCodCliente.Enabled = false;
            this.cboEmpresa.Enabled = false;
            this.optEntrega.Enabled = false;
            this.optPedido.Enabled = false;
            this.prdPeriodo.Enabled = false;
            this.txtDataBaseVencimento.Visible = false;
            this.lblDataBaseVencimento.Visible = false;

            this.FormStatus = CompSoft.TipoFormStatus.Nenhum;
        }

        private void grdPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                this.grdPedidos.EditMode = DataGridViewEditMode.EditOnEnter;
            else
                this.grdPedidos.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private bool f0039_user_BeforeSave()
        {
            bool bContinuar = true;

            DataRow[] fRow_Pedidos = dt_pedidos.Select("Sel = 1");
            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, gerando notas fiscais dos pedidos selecionados.", true, fRow_Pedidos.Length, 0);

            int iContador = 1;
            //-- Inicia o processo de geração da nota fiscal.
            foreach (DataRow row_ped in fRow_Pedidos)
            {
                //-- Limpa Aliquotas para nova nota fiscal.
                il_Aliquota_ICMS.Clear();

                //-- Encontra número da NF.
                if ((bool)row_ped["Gera_NF"])
                    this.Numero_NF(false, (int)row_ped["Empresa"]);
                else
                    iNumero_NF = 0;

                //-- Encontra todos os itens do pedido selecionado.
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select * from pedidos_itens where pedido = {0}", row_ped["Pedido"]);
                DataRow[] fRow_Itens = SQL.Select(sb.ToString(), "x", false).Select();

                foreach (DataRow row_Iped in fRow_Itens)
                {
                    if (!this.Cria_Itens_Nota_Fiscal(row_Iped, row_ped))
                    {
                        bContinuar = false;
                        goto Finalizar;
                    }
                }

                //-- Processo de criação da capa do pedido.
                if (!this.Cria_Capa_Nota_Fiscal(row_ped))
                {
                    bContinuar = false;
                    goto Finalizar;
                }

                //-- Processo de criação das duplicatas da nota
                if (!this.Cria_Duplicatas_Nota_Fiscal(row_ped))
                {
                    bContinuar = false;
                    goto Finalizar;
                }

                //-- Envia todos os registros para o banco de dados.
                ManipulaRegistros mr = new ManipulaRegistros();
                if (!mr.Salvar_Dados(this))
                {
                    bContinuar = false;
                    goto Finalizar;
                }

                //-- Marca o pedido como NF Gerada
                this.Atualiza_NF_Gerada((int)row_ped["Pedido"]);

                //-- Atualiza o número da nota.
                if ((bool)row_ped["Gera_NF"])
                    this.Numero_NF(true, (int)row_ped["Empresa"]);

                //-- Gravacao de movimento estoque
                {
                    string sDescricao = string.Format("Saída Nota fiscal ", iNumero_NF);
                    object oValor = this.DataSetLocal.Tables["Notas_Fiscais_Itens"].Compute("Sum(Valor_Total_Item)", "Nota_Fiscal is null");

                    //-- Gravacao de movimento estoque capa
                    iCodigo_mov_estoque = this.ceEstoque.Registra_Movimento_Estoque(
                                            (int)clsControleEstoque.Tipo_Movimento_Estoque.Saida,
                                            Convert.ToInt32(row_ped["Empresa"]),
                                            Convert.ToInt32(row_ped["cliente"]),
                                            iNumero_NF.ToString(),
                                            sDescricao,
                                            DateTime.Now,
                                            oValor == DBNull.Value ? 0 : Convert.ToDecimal(oValor));

                    //-- Encontra todos os itens do pedido selecionado.
                    sb.Remove(0, sb.Length);
                    sb.AppendFormat("select * from pedidos_itens where pedido = {0}", row_ped["Pedido"]);
                    DataRow[] fRow_Itens_mov = SQL.Select(sb.ToString(), "x", false).Select();

                    foreach (DataRow row_Iped in fRow_Itens_mov)
                    {
                        //-- Gravacao de movimento estoque item
                        this.ceEstoque.Registra_Movimento_Estoque_Item(
                            iCodigo_mov_estoque,
                            Convert.ToInt32(row_Iped["produto"]),
                            Convert.ToDecimal(row_Iped["Valor_Unitario"]),
                            Convert.ToInt32(row_Iped["qtde"]),
                            Convert.ToDecimal(row_Iped["Valor_Total"]));

                        if (!clsControleEstoque.Baixa_estoque_manual)
                        {
                            //-- Retirada do item do estoque
                            this.ceEstoque.Inclusao_Item_Nota_Fiscal(
                                Convert.ToInt32(row_ped["Empresa"]),
                                Convert.ToInt32(row_Iped["produto"]),
                                Convert.ToInt32(row_Iped["qtde"]));
                        }
                    }
                }

                f.Atual_Progresso = iContador;
                iContador++;
            }

        //-- Possibilidade de chamar um GOTO para finalizar processo.
        Finalizar:

            f.Close();
            return bContinuar;
        }

        private void f0039_user_FormStatus_Change()
        {
            this.chkCliente.Enabled = true;
            this.chkData.Enabled = true;
            this.chkEmpresa.Enabled = true;
            this.cmdPesquisar.Enabled = true;
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            this.Buscar_Pedidos();

            if (this.dt_pedidos.Rows.Count > 0)
            {
                this.cmdGerar.Enabled = true;
                this.txtDataBaseVencimento.Visible = true;
                this.lblDataBaseVencimento.Visible = true;
                this.txtDataBaseVencimento.Enabled = true;
            }
            else
            {
                this.cmdGerar.Enabled = false;
                this.txtDataBaseVencimento.Visible = false;
                this.lblDataBaseVencimento.Visible = false;
                this.txtDataBaseVencimento.Enabled = false;
            }
        }

        private void grdPedidos_EditModeChanged(object sender, EventArgs e)
        {
            this.grdPedidos.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            string sMsg = string.Empty;

            if (this.txtDataBaseVencimento.EditValue == null)
                sMsg += "   - A data base para o calculo do vencimento tem que ser preenchida.\r\n";

            DataRow[] fRow = dt_pedidos.Select("sel = 1");
            if (fRow.Length == 0)
                sMsg += "   - Não existem pedidos para geração da nota fiscal.";

            if (!string.IsNullOrEmpty(sMsg))
            {
                sMsg = "ERRO AO GERAR DOCUMENTOS\r\n" + sMsg;
                MsgBox.Show(sMsg
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Asterisk);
            }
            else
            {
                string sMSG = string.Empty;
                if (fRow.Length == 1)
                    sMSG = "Será gerado {0} documento, você confirma?";
                else
                    sMSG = "Serão gerados {0} documentos, você confirma?";

                sMSG = string.Format(sMSG, fRow.Length);
                DialogResult dr = MsgBox.Show(sMSG
                    , "Confirmar"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    this.Salvar();
                    dt_pedidos.Clear();
                    this.lblDataBaseVencimento.Visible = false;
                    this.txtDataBaseVencimento.Visible = false;

                    MsgBox.Show("Documento(s) gerados com sucesso!"
                        , "Confirmação"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
                }
            }
        }

        private void selecionarTodasNotasFiscaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selecinar_Itens_Grid(Tipos_Selecoes.Notas_Fiscais);
        }

        private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selecinar_Itens_Grid(Tipos_Selecoes.Tudo);
        }

        private void selecionarTodosCuponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selecinar_Itens_Grid(Tipos_Selecoes.Cupom);
        }

        private void f0039_user_AfterSave()
        {
            Funcoes func;
            bool bGerarConsiliacao = Convert.ToBoolean(func.Busca_Propriedade("Gera_Consiliacao_Automatica"));

            if (bGerarConsiliacao)
            {
                Financeiro.ConsiliacaoFinanceira cf = new Financeiro.ConsiliacaoFinanceira();

                foreach (DataRow row in this.DataSetLocal.Tables[0].Select())
                {
                    cf.Gerar_Consiliacao(Convert.ToInt32(row["Nota_Fiscal"]));
                }
            }
        }
    }
}