using CompSoft.compFrameWork;
using CompSoft.Data;
using ERP.Class;
using ERP.Financeiro;
using ERP.Impostos;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0037 : CompSoft.FormSet
    {
        private bool bCliente_Inadimplente = false
                , bMotrou_Inadimplente = false
                , bCliente_TituloAberto_NaoSalvar = false
                , bMotrou_TituloAberto = false;

        private clsControleEstoque ce = new clsControleEstoque();

        #region Contrutores

        public f0037()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   pe.Pedido");
            sb.AppendLine(" , pe.Empresa");
            sb.AppendLine(" , e.Razao_Social as 'Razao_Empresa'");
            sb.AppendLine(" , pe.Cliente");
            sb.AppendLine(" , cl.razao_Social as 'Razao_Cliente'");
            sb.AppendLine(" , cl.CPF_CNPJ");
            sb.AppendLine(" , pe.Vendedor");
            sb.AppendLine(" , v.Nome_Vendedor");
            sb.AppendLine(" , pe.Transportadora");
            sb.AppendLine(" , t.Nome_Fantasia as 'Nome_Transportadora'");
            sb.AppendLine(" , pe.Condicao_Pagamento_Pedido");
            sb.AppendLine(" , cpp.Desc_Cond_Pgto");
            sb.AppendLine(" , pe.Tabela_Preco");
            sb.AppendLine(" , tp.Desc_Tabela_Preco");
            sb.AppendLine(" , pe.Gera_NF");
            sb.AppendLine(" , pe.NF_Gerada");
            sb.AppendLine(" , pe.Cancelado");
            sb.AppendLine(" , pe.Data_Pedido");
            sb.AppendLine(" , pe.Data_Entrega");
            sb.AppendLine(" , pe.Bonificacao");
            sb.AppendLine(" , pe.Remessa_Deposito");
            sb.AppendLine(" , pe.Devolucao");
            sb.AppendLine(" , cl.Endereco_Correspondencia");
            sb.AppendLine(" , cl.Numero_Correspondencia");
            sb.AppendLine(" , cl.Complemento_Correspondencia");
            sb.AppendLine(" , cl.Bairro_Correspondencia");
            sb.AppendLine(" , cl.Cidade_Correspondencia");
            sb.AppendLine(" , cl.Estado_Correspondencia");
            sb.AppendLine(" , cl.CEP_Correspondencia");
            sb.AppendLine(" , cl.DDD1");
            sb.AppendLine(" , cl.Fone1");
            sb.AppendLine(" , cl.DDD2");
            sb.AppendLine(" , cl.Fone2");
            sb.AppendLine(" from pedidos pe");
            sb.AppendLine("  inner join empresas e on e.empresa = pe.empresa");
            sb.AppendLine("  inner join vendedores v on v.Vendedor = pe.Vendedor");
            sb.AppendLine("  inner join Condicoes_Pagamento_Pedido cpp on cpp.Condicao_Pagamento_Pedido = pe.Condicao_Pagamento_Pedido");
            sb.AppendLine("  left outer join clientes cl on cl.cliente = pe.cliente");
            sb.AppendLine("  left outer join Transportadoras t on t.transportadora = pe.transportadora");
            sb.AppendLine("  left outer join tabelas_precos tp on tp.tabela_preco = pe.tabela_preco");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Pedidos"
                    , sb.ToString()));

            sb.Remove(0, sb.Length - 1);
            sb.AppendLine("select ");
            sb.AppendLine("   pedidos_itens.Pedido_Item");
            sb.AppendLine(" , pedidos_itens.Pedido");
            sb.AppendLine(" , class.*");
            sb.AppendLine(" , pedidos_itens.Porcentagem_Desconto");
            sb.AppendLine(" , pedidos_itens.Valor_Desconto");
            sb.AppendLine(" , pedidos_itens.Qtde");
            sb.AppendLine(" , pedidos_itens.Valor_Unitario");
            sb.AppendLine(" , pedidos_itens.Valor_Total");
            sb.AppendLine(" , pedidos_itens.Porcentagem_Comissao");
            sb.AppendLine(" , pedidos_itens.Valor_Comissao");
            sb.AppendLine(" , pr.Peso_Bruto");
            sb.AppendLine(" , pr.Peso_Liquido");
            sb.AppendLine(" , 0000000.00 as 'ST'");
            sb.AppendLine(" from pedidos_itens");
            sb.AppendLine("  inner join produtos pr on pr.produto = pedidos_itens.produto");
            sb.AppendLine("  inner join vw_Class_Produto class on class.produto = pr.produto");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                    , "Pedidos_itens"
                    , sb.ToString()
                    , "Pedido_Item"));

            InitializeComponent();
        }

        #endregion Contrutores

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

            //-- Busca impostos dos tributos do produto
            DataRow row_prodTributos = Impostos_NotaFiscal.Dados_Produtos_Tributos(iProduto
                                                                                    , Convert.ToInt32(this.txtCodEmpresa.Text)
                                                                                    , Convert.ToInt32(this.txtCodCliente.Text));

            dValor_Com_Reducao = Impostos_NotaFiscal.Calcula_Reducao_ICMS(dValor_Total_Produto
                                                                                    , Convert.ToInt32(this.txtCodCliente.Text)
                                                                                    , out dAlicotaReducao_ICMS
                                                                                    , ref row_prodTributos);

            sDestino = SQL.ExecuteScalar(string.Format("select Estado_Entrega from clientes where cliente = {0}", this.txtCodCliente.Text)).ToString();
            bool Regime_Normal_RPA = Convert.ToBoolean(SQL.ExecuteScalar(string.Format("select Regime_Normal_RPA from clientes where cliente = {0}", this.txtCodCliente.Text)));

            dValor_ICMS = Impostos_NotaFiscal.Calculo_ICMS(Convert.ToInt32(this.txtCodEmpresa.Text)
                                                            , sDestino
                                                            , dValor_Com_Reducao
                                                            , ref dAliquota_ICMS
                                                            , ref row_prodTributos);

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

        #region Busca preço do produto

        /// <summary>
        /// Busca valor vigente do produto de acordo com a tabela de preço selecionada.
        /// </summary>
        /// <param name="iTabela_Preco">Código da tabela de preço.</param>
        /// <param name="iProduto">Código do produto.</param>
        /// <returns>DataRow contendo informações necessárias para controlar produto</returns>
        private DataRow Busca_Preco_Produto(int iTabela_Preco, int iProduto)
        {
            DataRow row = null;
            try
            {
                //-- Query para busca dos produtos
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select ");
                sb.AppendLine("   class.* ");
                sb.AppendLine(" , isnull(tpi.Valor_Venda, pr.Valor_Venda) as 'Valor_Venda' ");
                sb.AppendLine(" , pr.Comissionado ");
                sb.AppendLine(" , pr.Porcentagem_Comissao   ");
                sb.AppendLine(" , pr.Peso_Bruto ");
                sb.AppendLine(" , pr.Peso_Liquido ");
                sb.AppendLine("from produtos pr");
                sb.AppendLine(" inner join vw_Class_Produto class on class.produto = pr.produto");
                sb.AppendFormat(" left outer join tabelas_precos_itens tpi on tpi.produto = pr.produto and tpi.Tabela_Preco = {0}", iTabela_Preco);
                sb.AppendLine(" left outer join tabelas_precos tp on tp.tabela_preco = tpi.Tabela_preco");
                sb.AppendFormat(" where pr.Produto = {0}", iProduto);

                //-- executa a query e retorna o registro.
                row = SQL.Select(sb.ToString(), "x", false).Rows[0];

                return row;
            }
            catch
            {
                return null;
            }
        }

        #endregion Busca preço do produto

        #region Verifica estoque

        private bool Verifica_Estoque()
        {
            bool bExiste_Estoque = ce.Verifica_Estoque_Disponivel_Item(Convert.ToInt32(this.txtCodEmpresa.Text),
                                                Convert.ToInt32(this.txtCodProduto.Text),
                                                Convert.ToInt32(this.txtQtde.Text));
            bool bContinuar = true;

            //-- Verifica se existe estoque e se o usuário permite a inclusão do mesmo.
            if (!bExiste_Estoque)
            {
                string sMensagem = "A quantidade no estoque do produto '{0}' não é suficiente para este pedido, deseja continuar?";
                sMensagem = string.Format(sMensagem, this.txtProduto.Text);
                DialogResult dr = MsgBox.Show(sMensagem, "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr != DialogResult.Yes)
                    bContinuar = false;
            }

            return bContinuar;
        }

        #endregion Verifica estoque

        #region Inclui registro do produto.

        public virtual void Incluir_Produto(string sMsg)
        {
            //-- Verifica campos obrigatórios.
            if (string.IsNullOrEmpty(this.txtCodProduto.Text))
                sMsg += "  - O produto tem que ser preenchido.\r\n";

            if (string.IsNullOrEmpty(this.txtQtde.Text))
                sMsg += "  - A quantidade tem que ser preenchida.\r\n";

            if (!string.IsNullOrEmpty(this.txtQtde.Text) && Convert.ToInt32(this.txtQtde.Text) <= 0)
                sMsg += "  - A quantidade tem que ser maior que 0(zero).\r\n";

            if (string.IsNullOrEmpty(this.txtValorProduto.Text))
                sMsg += "  - O valor de venda do produto tem que ser preenchido.\r\n";

            if (!string.IsNullOrEmpty(this.txtValorProduto.Text) && Convert.ToDecimal(this.txtValorProduto.Text) <= 0)
                sMsg += "  - O valor de venda do produto que ser maior que 0(zero).\r\n";

            //-- Verifica a possibilidade de incluir os itens.
            if (!string.IsNullOrEmpty(sMsg))
            {
                sMsg = "Erro ao incluir item no pedido\r\n" + sMsg;
                MsgBox.Show(sMsg
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
            }
            else
            {
                int iTabela_Preco = 0,
                    iProduto = Convert.ToInt32(this.txtCodProduto.Text);

                if (this.cboTabela_Preco.SelectedIndex >= 0)
                    iTabela_Preco = Convert.ToInt32(this.cboTabela_Preco.SelectedValue);

                //-- Retorna o valor do produto de acordo com a tabela de preço.
                //-- Caso o sistema não encontre nenhum produto para esta tabela
                //-- será utilizado o valor cadastrado na tabela de produtos.
                DataRow row_Produto = this.Busca_Preco_Produto(iTabela_Preco, iProduto);

                if (row_Produto != null)
                {
                    decimal dValor_Unitario = Convert.ToDecimal(this.txtValorProduto.Text)
                        , dValor_Total_Produto = 0
                        , dPercentual_Comissao = 0
                        , dValor_Comissao = 0
                        , dValorST = 0;

                    int iQtde = Convert.ToInt32(this.txtQtde.Text);

                    //-- Verifica se existe estoque.
                    if (this.Verifica_Estoque())
                    {
                        //-- Realiza calculos.
                        dValor_Total_Produto = dValor_Unitario * iQtde;

                        //-- Calcula ST
                        dValorST = this.CalculaST(iProduto, dValor_Total_Produto);

                        //-- Verifica se o produto é comissionado e realiza o calculo
                        if ((bool)row_Produto["Comissionado"])
                        {
                            dPercentual_Comissao = Convert.ToDecimal(row_Produto["Porcentagem_Comissao"]);
                            dValor_Comissao = decimal.Round(((dValor_Total_Produto * dPercentual_Comissao) / 100), 2, MidpointRounding.AwayFromZero);
                        }

                        DataRow[] fRow = this.DataSetLocal.Tables["Pedidos_itens"].Select("Produto = " + iProduto.ToString());
                        if (fRow.Length > 0)
                        {
                            foreach (DataRow row in fRow)
                            {
                                row["Qtde"] = Convert.ToInt32(row["Qtde"]) + iQtde;
                                row["Valor_Total"] = Convert.ToDecimal(row["Valor_Total"]) + dValor_Total_Produto;
                                row["Valor_Comissao"] = Convert.ToDecimal(row["Valor_Comissao"]) + dValor_Comissao;
                            }

                            this.grdProdutos.BindingSource.EndEdit();
                        }
                        else
                        {
                            //-- Inicia o processo de inclusão do item.
                            DataRowView row = this.grdProdutos.BindingSource.AddNew() as DataRowView;

                            row["Produto"] = iProduto;
                            row["Desc_Produto"] = this.txtProduto.Text;
                            row["Grupo_Produto"] = row_Produto["Grupo_Produto"];
                            row["Desc_Grupo_Produto"] = row_Produto["Desc_Grupo_Produto"];

                            row["Peso_Bruto"] = row_Produto["Peso_Bruto"] == DBNull.Value ? 0 : row_Produto["Peso_Bruto"];
                            row["Peso_Liquido"] = row_Produto["Peso_Liquido"] == DBNull.Value ? 0 : row_Produto["Peso_Liquido"];

                            row["Porcentagem_Desconto"] = 0;
                            row["Valor_Desconto"] = 0;
                            row["Qtde"] = iQtde;
                            row["Valor_Unitario"] = dValor_Unitario;
                            row["Valor_Total"] = dValor_Total_Produto;
                            row["ST"] = dValorST;
                            row["Porcentagem_Comissao"] = dPercentual_Comissao;
                            row["Valor_Comissao"] = dValor_Comissao;

                            this.grdProdutos.BindingSource.EndEdit();
                        }

                        //-- Calcula os totais do pedido e motra em tela.
                        this.Calcula_Totais();

                        this.txtCodProduto.Text = string.Empty;
                        this.txtProduto.Text = string.Empty;
                        this.txtQtde.Text = string.Empty;
                        this.txtValorProduto.Text = string.Empty;
                        this.txtCodProduto.Focus();
                    }
                    else
                    {
                        MsgBox.Show("A inclusão do item foi cancelada pelo usuário."
                            , "Atenção"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MsgBox.Show("Produto não encontrado, tente novamente."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                }
            }
        }

        #endregion Inclui registro do produto.

        #region Mostra todos os totais

        private void Calcula_Totais()
        {
            object oValor;
            decimal dDesconto = 0;

            //-- Calcula o total de desconto.
            oValor = this.DataSetLocal.Tables["Pedidos_Itens"].Compute("sum(Valor_Desconto)", "");
            if (oValor == DBNull.Value)
                this.lblDesconto.Text = string.Format(this.lblDesconto.Tag.ToString(), 0);
            else
            {
                dDesconto = Convert.ToDecimal(oValor);
                this.lblDesconto.Text = string.Format(this.lblDesconto.Tag.ToString(), dDesconto);
            }

            //-- Calcula o total de comissão.
            oValor = this.DataSetLocal.Tables["Pedidos_Itens"].Compute("sum(Valor_Comissao)", "");
            if (oValor == DBNull.Value)
                this.lblComissao.Text = string.Format(this.lblComissao.Tag.ToString(), 0);
            else
                this.lblComissao.Text = string.Format(this.lblComissao.Tag.ToString(), Convert.ToDecimal(oValor));

            //-- Calcula o total do pedido.
            oValor = this.DataSetLocal.Tables["Pedidos_Itens"].Compute("sum(Valor_Total)", "");
            if (oValor == DBNull.Value)
                this.lblTotal.Text = string.Format(this.lblTotal.Tag.ToString(), 0);
            else
            {
                decimal dTotal = Convert.ToDecimal(oValor) - dDesconto;
                this.lblTotal.Text = string.Format(this.lblTotal.Tag.ToString(), dTotal);
            }

            //-- Calcula o total de ST do pedido
            oValor = this.DataSetLocal.Tables["Pedidos_Itens"].Compute("sum(ST)", string.Empty);
            if (oValor == DBNull.Value)
                this.lblST.Text = string.Format(this.lblST.Tag.ToString(), 0);
            else
            {
                decimal dTotal = Convert.ToDecimal(oValor);
                this.lblST.Text = string.Format(this.lblST.Tag.ToString(), dTotal);
            }

            //-- Verifica se pode alterar a tabela de preço.
            if (this.DataSetLocal.Tables["pedidos_itens"].Rows.Count <= 0)
                this.cboTabela_Preco.Enabled = false;
            else
                this.cboTabela_Preco.Enabled = true;
        }

        #endregion Mostra todos os totais

        private void txtCodEmpresa_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodEmpresa.LookUpRetorno != null)
                this.txtEmpresa.Text = this.txtCodEmpresa.LookUpRetorno[1].ToString();
        }

        private void txtEmpresa_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtEmpresa.LookUpRetorno != null)
                this.txtCodEmpresa.Text = this.txtEmpresa.LookUpRetorno[0].ToString();
        }

        private void txtCodCliente_Validating(object sender, CancelEventArgs e)
        {
            if ((this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando) && this.txtCodCliente.LookUpRetorno != null)
            {
                this.txtCliente.Text = this.txtCodCliente.LookUpRetorno[1].ToString();
                this.txtTransportadora.Text = this.txtCodCliente.LookUpRetorno["Razao_Transportadora"].ToString();
                this.txtCodTransportadora.Text = this.txtCodCliente.LookUpRetorno["Transportadora"].ToString();
                this.cboVendedor.SelectedValue = this.txtCodCliente.LookUpRetorno["Vendedor"];

                if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
                {
                    DataRowView row = this.BindingSource[this.MainTabela].Current as DataRowView;
                    row["Endereco_Correspondencia"] = this.txtCodCliente.LookUpRetorno["Endereco_Correspondencia"];
                    row["numero_Correspondencia"] = this.txtCodCliente.LookUpRetorno["numero_Correspondencia"];
                    row["complemento_Correspondencia"] = this.txtCodCliente.LookUpRetorno["complemento_Correspondencia"];
                    row["Bairro_Correspondencia"] = this.txtCodCliente.LookUpRetorno["Bairro_Correspondencia"];
                    row["Cidade_Correspondencia"] = this.txtCodCliente.LookUpRetorno["Cidade_Correspondencia"];
                    row["Estado_Correspondencia"] = this.txtCodCliente.LookUpRetorno["Estado_Correspondencia"];
                    row["CEP_Correspondencia"] = this.txtCodCliente.LookUpRetorno["CEP_Correspondencia"];
                    row["CEP_Correspondencia"] = this.txtCodCliente.LookUpRetorno["CEP_Correspondencia"];
                    row["CPF_CNPJ"] = this.txtCodCliente.LookUpRetorno["CPF_CNPJ"];
                    row["DDD1"] = this.txtCodCliente.LookUpRetorno["DDD1"];
                    row["Fone1"] = this.txtCodCliente.LookUpRetorno["Fone1"];
                    row["DDD2"] = this.txtCodCliente.LookUpRetorno["DDD2"];
                    row["Fone2"] = this.txtCodCliente.LookUpRetorno["Fone2"];
                }

                if (this.txtCodCliente.LookUpRetorno["Tabela_Preco"] != DBNull.Value)
                    this.cboTabela_Preco.SelectedValue = this.txtCodCliente.LookUpRetorno["Tabela_Preco"];

                bCliente_Inadimplente = (bool)this.txtCodCliente.LookUpRetorno["Inadimplente"];
                if (bCliente_Inadimplente && !bMotrou_Inadimplente)
                {
                    MsgBox.Show("Este cliente foi marcado como inadimplente ou bloqueado para venda."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);

                    bMotrou_Inadimplente = true;
                }

                //-- Verifica se o cliente possui titulos vencido em aberto...
                if (!bMotrou_TituloAberto)
                {
                    VerificacoesFinanceiras vf = new VerificacoesFinanceiras();
                    if (vf.TitulosNaoPagosAtrasados(Convert.ToInt32(this.txtCodCliente.Text)))
                    {
                        DialogResult dr = MsgBox.Show("Este cliente possui titulos em atraso, deseja continuar com este pedido?\r\nNÃO SERÁ PERMITIDO SALVAR O PEDIDO."
                                    , "Atenção - Titulos em aberto"
                                    , MessageBoxButtons.YesNo
                                    , MessageBoxIcon.Question);

                        if (dr == System.Windows.Forms.DialogResult.No)
                        {
                            bCliente_TituloAberto_NaoSalvar = true;
                        }

                        bMotrou_TituloAberto = true;
                    }
                }
            }
        }

        private void txtCliente_Validating(object sender, CancelEventArgs e)
        {
            if ((this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando) && this.txtCliente.LookUpRetorno != null)
            {
                this.txtCodCliente.Text = this.txtCliente.LookUpRetorno[0].ToString();
                this.txtTransportadora.Text = this.txtCliente.LookUpRetorno["Razao_Transportadora"].ToString();
                this.txtCodTransportadora.Text = this.txtCliente.LookUpRetorno["Transportadora"].ToString();
                this.cboVendedor.SelectedValue = this.txtCliente.LookUpRetorno["Vendedor"];

                if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
                {
                    DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
                    row["Endereco_Correspondencia"] = this.txtCliente.LookUpRetorno["Endereco_Correspondencia"];
                    row["numero_Correspondencia"] = this.txtCliente.LookUpRetorno["numero_Correspondencia"];
                    row["complemento_Correspondencia"] = this.txtCliente.LookUpRetorno["complemento_Correspondencia"];
                    row["Bairro_Correspondencia"] = this.txtCliente.LookUpRetorno["Bairro_Correspondencia"];
                    row["Cidade_Correspondencia"] = this.txtCliente.LookUpRetorno["Cidade_Correspondencia"];
                    row["Estado_Correspondencia"] = this.txtCliente.LookUpRetorno["Estado_Correspondencia"];
                    row["CEP_Correspondencia"] = this.txtCliente.LookUpRetorno["CEP_Correspondencia"];
                    row["CEP_Correspondencia"] = this.txtCliente.LookUpRetorno["CEP_Correspondencia"];
                    row["CPF_CNPJ"] = this.txtCliente.LookUpRetorno["CPF_CNPJ"];
                    row["DDD1"] = this.txtCliente.LookUpRetorno["DDD1"];
                    row["Fone1"] = this.txtCliente.LookUpRetorno["Fone1"];
                    row["DDD2"] = this.txtCliente.LookUpRetorno["DDD2"];
                    row["Fone2"] = this.txtCliente.LookUpRetorno["Fone2"];
                }

                if (this.txtCliente.LookUpRetorno["Tabela_Preco"] != DBNull.Value)
                    this.cboTabela_Preco.SelectedValue = this.txtCliente.LookUpRetorno["Tabela_Preco"];

                bCliente_Inadimplente = (bool)this.txtCliente.LookUpRetorno["Inadimplente"];
                if (bCliente_Inadimplente && !bMotrou_Inadimplente)
                {
                    MsgBox.Show("Este cliente foi marcado como inadimplente ou bloqueado para venda."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);

                    bMotrou_Inadimplente = true;
                }

                //-- Verifica se o cliente possui titulos vencido em aberto...
                if (!bMotrou_TituloAberto)
                {
                    VerificacoesFinanceiras vf = new VerificacoesFinanceiras();
                    if (vf.TitulosNaoPagosAtrasados(Convert.ToInt32(this.txtCodCliente.Text)))
                    {
                        DialogResult dr = MsgBox.Show("Este cliente possui titulos em atraso, deseja continuar com este pedido?\r\nNÃO SERÁ PERMITIDO SALVAR O PEDIDO."
                                    , "Atenção - Titulos em aberto"
                                    , MessageBoxButtons.YesNo
                                    , MessageBoxIcon.Question);

                        if (dr == System.Windows.Forms.DialogResult.No)
                        {
                            bCliente_TituloAberto_NaoSalvar = true;
                        }

                        bMotrou_TituloAberto = true;
                    }
                }
            }
        }

        private void txtCodTransportadora_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodTransportadora.LookUpRetorno != null)
                this.txtTransportadora.Text = this.txtCodTransportadora.LookUpRetorno[1].ToString();
        }

        private void txtTransportadora_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtTransportadora.LookUpRetorno != null)
                this.txtCodTransportadora.Text = this.txtTransportadora.LookUpRetorno[0].ToString();
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodProduto.LookUpRetorno != null)
            {
                this.txtProduto.Text = this.txtCodProduto.LookUpRetorno[1].ToString();

                //-- Inicia o processo de busca do preço do produto.
                if (!string.IsNullOrEmpty(this.txtCodProduto.Text))
                {
                    int iProduto = Convert.ToInt32(this.txtCodProduto.Text),
                        iTabPreco = 0;

                    if (this.cboTabela_Preco.SelectedIndex >= 0)
                        iTabPreco = Convert.ToInt32(this.cboTabela_Preco.SelectedValue);

                    //-- Metodo que retorna os valores do preço do produto.
                    DataRow row_preco = this.Busca_Preco_Produto(iTabPreco, iProduto);

                    this.txtValorProduto.Text = Convert.ToDecimal(row_preco["Valor_Venda"]).ToString();
                }
            }
        }

        private void txtProduto_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtProduto.LookUpRetorno != null)
            {
                this.txtCodProduto.Text = this.txtProduto.LookUpRetorno[0].ToString();

                //-- Inicia o processo de busca do preço do produto.
                if (!string.IsNullOrEmpty(this.txtCodProduto.Text))
                {
                    int iProduto = Convert.ToInt32(this.txtCodProduto.Text),
                        iTabPreco = 0;

                    if (this.cboTabela_Preco.SelectedIndex >= 0)
                        iTabPreco = Convert.ToInt32(this.cboTabela_Preco.SelectedValue);

                    //-- Metodo que retorna os valores do preço do produto.
                    DataRow row_preco = this.Busca_Preco_Produto(iTabPreco, iProduto);

                    this.txtValorProduto.Text = Convert.ToDecimal(row_preco["Valor_Venda"]).ToString();
                }
            }
        }

        private void f0037_user_AfterRefreshData()
        {
            if (Propriedades.FormMain != null)
            {
                foreach (DataRow row in this.DataSetLocal.Tables["Pedidos_Itens"].Select())
                {
                    row.BeginEdit();
                    row["ST"] = this.CalculaST(Convert.ToInt32(row["produto"]), Convert.ToDecimal(row["Valor_Total"]));
                    row.EndEdit();
                }

                this.grdProdutos.DataSource = this.DataSetLocal.Tables["Pedidos_itens"];
                this.Calcula_Totais();

                this.DataSetLocal.Tables["Pedidos_Itens"].Columns["ST"].ReadOnly = false;
            }
        }

        private void f0037_user_AfterNew()
        {
            this.txtDataPedido.EditValue = DateTime.Now;
            this.txtDataEntrega.EditValue = DateTime.Now.AddDays(1);
            this.txtCodEmpresa.Focus();

            Funcoes func;
            this.txtCodEmpresa.Text = func.Busca_Propriedade("Codigo_Filial");
            this.txtCodCliente.Focus();
            if (Convert.ToBoolean(func.Busca_Propriedade("GERA_NF")) != this.chkGeraNota.Checked)
                this.chkGeraNota.Checked = Convert.ToBoolean(func.Busca_Propriedade("GERA_NF"));

            bCliente_Inadimplente = false;
            bMotrou_Inadimplente = false;
            bCliente_TituloAberto_NaoSalvar = false;
            bMotrou_TituloAberto = false;
        }

        private void f0037_user_FormStatus_Change()
        {
            this.txtCodProduto.MaxLength = 9;
            this.grpOpcoesPedido.Visible = false;

            if (this.FormStatus != CompSoft.TipoFormStatus.Limpar)
                this.txtDataPedido.Enabled = false;
            else
                this.txtDataPedido.Enabled = true;
        }

        private void f0037_Load(object sender, EventArgs e)
        {
            this.lblTotal.Text = string.Format(this.lblTotal.Tag.ToString(), 0);
            this.lblDesconto.Text = string.Format(this.lblDesconto.Tag.ToString(), 0);
            this.lblComissao.Text = string.Format(this.lblComissao.Tag.ToString(), 0);
            this.grdProdutos.AllowUserToDeleteRows = true;
        }

        private void txtCodProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13 && (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando))
                this.Incluir_Produto(string.Empty);
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13 && (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando))
                this.Incluir_Produto(string.Empty);
        }

        private void txtProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13 && (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando))
                this.Incluir_Produto(string.Empty);
        }

        private void grdProdutos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MsgBox.Show("Deseja excluir este item do pedido?"
                , "Excluir item"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);

            if (dr == DialogResult.No)
                e.Cancel = true;
        }

        private void grdProdutos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.Calcula_Totais();
        }

        private void grdProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grdProdutos.SelectedRows.Count > 0)
            {
                if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
                {
                    DataRowView row = (DataRowView)this.grdProdutos.BindingSource.Current;
                    f0038 f = new f0038();

                    f.CodProduto = Convert.ToInt32(row["Produto"]);
                    f.Produto = row["Desc_Produto"].ToString();
                    f.Quantidade = Convert.ToInt32(row["Qtde"]);
                    f.Desconto_Porcentagem = Convert.ToDecimal(row["Porcentagem_Desconto"]);
                    f.Desconto_Valor = Convert.ToDecimal(row["Valor_Desconto"]);
                    f.Comissao_Porcentagem = Convert.ToDecimal(row["Porcentagem_Comissao"]);
                    f.Comissao_Valor = Convert.ToDecimal(row["Valor_Comissao"]);
                    f.Valor_Unitario = Convert.ToDecimal(row["Valor_Unitario"]);

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        row["Valor_Unitario"] = f.Valor_Unitario;
                        row["Qtde"] = f.Quantidade;
                        row["Porcentagem_Desconto"] = f.Desconto_Porcentagem;
                        row["Valor_Desconto"] = f.Desconto_Valor;
                        row["Porcentagem_Comissao"] = f.Comissao_Porcentagem;
                        row["Valor_Comissao"] = f.Comissao_Valor;
                        row["Valor_Total"] = (Convert.ToDecimal(row["Valor_Unitario"]) * f.Quantidade) - f.Desconto_Valor;

                        this.grdProdutos.BindingSource.EndEdit();

                        //-- Recalcula totais para atualizar tela.
                        this.Calcula_Totais();
                    }
                }
            }
            else
            {
                MsgBox.Show("Selecione um item para realizar alterar."
                    , "Alerta"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
        }

        public bool f0037_user_BeforeSave()
        {
            bool bContinuar = true;

            if (bContinuar && bCliente_TituloAberto_NaoSalvar)
            {
                DialogResult dr = MsgBox.Show("Este cliente possui titulos em atraso e você informou que não é possível realizar a venda, confirma esta informação?"
                    , "Permitir a venda"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                    bContinuar = false;
            }

            if (bContinuar && bCliente_Inadimplente)
            {
                DialogResult dr = MsgBox.Show("Este cliente está marcado como inadimplente ou bloqueado para venda, deseja continuar?"
                    , "Permitir a venda"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                    bContinuar = false;
            }

            //-- Verifica se foi incluido produtos no pedido.
            if (bContinuar && this.grdProdutos.BindingSource.Count <= 0)
            {
                MsgBox.Show("Não é possivel salvar este pedido porque não existem produtos associados."
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);

                bContinuar = false;
            }
            else
            {
                //-- Processo para salvar dados.
                DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;

                row["Nome_Vendedor"] = this.cboVendedor.Text;
                row["Desc_Cond_Pgto"] = this.cboCondicao_Pagamento.Text;
                row["Desc_Tabela_Preco"] = this.cboTabela_Preco.Text;
            }

            return bContinuar;
        }

        private void f0037_user_AfterSave()
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo)
            {
                //-- Reserva estoque para este pedido.
                DataView dv = new DataView(this.DataSetLocal.Tables["Pedidos_Itens"], "", "", DataViewRowState.CurrentRows);
                foreach (DataRowView row in dv)
                {
                    int iEmpresa = Convert.ToInt32(this.txtCodEmpresa.Text),
                        iProduto = Convert.ToInt32(row["Produto"]),
                        iQtde = Convert.ToInt32(row["Qtde"]);

                    //-- Chama classe que controla estoque.
                    clsControleEstoque c = new clsControleEstoque();
                    c.Inclusao_Item_Pedido(iEmpresa, iProduto, iQtde);
                }
            }
        }

        private void cboTabela_Preco_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando) && this.cboTabela_Preco.SelectedIndex > -1)
            {
                DataRow[] fRow = ((DataTable)this.cboTabela_Preco.DataSource).Select("Tabela_Preco = " + this.cboTabela_Preco.SelectedValue.ToString());
                foreach (DataRow row in fRow)
                    this.cboCondicao_Pagamento.SelectedValue = row["Condicao_Pagamento_Pedido"];
            }
        }

        private void txtValorProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13 && (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando))
                this.Incluir_Produto("");
        }

        private void txtCodProduto_Enter(object sender, EventArgs e)
        {
            string sSQLStatement = "select pr.Produto, pr.Desc_Produto, tp.Desc_Tabela_Preco as 'Valor com base na tabela' from produtos pr left outer join tabelas_precos_itens tpi on tpi.produto = pr.produto and tpi.Tabela_preco = 0 left outer join tabelas_precos tp on tp.tabela_preco = tpi.tabela_preco where pr.produto@";
            if (this.cboTabela_Preco.SelectedIndex >= 0)
                sSQLStatement = string.Format(sSQLStatement, this.cboTabela_Preco.SelectedValue);
            else
                sSQLStatement = string.Format(sSQLStatement, 0);

            this.txtCodProduto.SQLStatement = sSQLStatement;
        }

        private void txtProduto_Enter(object sender, EventArgs e)
        {
            string sSQLStatement = "select pr.Produto, pr.Desc_Produto, tp.Desc_Tabela_Preco as 'Valor com base na tabela' from produtos pr left outer join tabelas_precos_itens tpi on tpi.produto = pr.produto and tpi.Tabela_preco = 0 left outer join tabelas_precos tp on tp.tabela_preco = tpi.tabela_preco where pr.Desc_produto@";
            if (this.cboTabela_Preco.SelectedIndex >= 0)
                sSQLStatement = string.Format(sSQLStatement, this.cboTabela_Preco.SelectedValue);
            else
                sSQLStatement = string.Format(sSQLStatement, 0);

            this.txtProduto.SQLStatement = sSQLStatement;
        }

        private void txtCodProduto_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtCodProduto_Enter(this, new EventArgs());
        }

        private void txtProduto_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtProduto_Enter(this, new EventArgs());
        }

        private void txtCodCliente_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                bMotrou_Inadimplente = false;
        }

        private void txtCliente_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                bMotrou_Inadimplente = false;
        }

        private void cmdOpcoesPedidos_Click(object sender, EventArgs e)
        {
            this.grpOpcoesPedido.Visible = !this.grpOpcoesPedido.Visible;
        }
    }
}