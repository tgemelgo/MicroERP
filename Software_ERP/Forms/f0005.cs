using CompSoft.compFrameWork;
using CompSoft.Data;
using ERP.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0005 : CompSoft.FormSet
    {
        private clsControleEstoque ceEstoque = new clsControleEstoque();

        #region Construtor

        public f0005()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   nf.*");
            sb.AppendLine(" , e.Razao_Social as 'Razao_Social_Empresa'");
            sb.AppendLine(" , cfops.Desc_CFOP");
            sb.AppendLine(" , cl.Razao_Social as 'Razao_Social_Cliente'");
            sb.AppendLine(" , cl.CPF_CNPJ as 'CPF_CNPJ_Cliente'");
            sb.AppendLine(" , cl.Pessoa_Juridica");
            sb.AppendLine(" , cl.RG_IE as 'RG_IE_Cliente'");
            sb.AppendLine(" , cl.DDD1 as 'DDD1_Cliente'");
            sb.AppendLine(" , cl.Fone1 as 'Fone1_Cliente'");
            sb.AppendLine(" , cl.Endereco_Correspondencia");
            sb.AppendLine(" , cl.Numero_Correspondencia");
            sb.AppendLine(" , cl.Complemento_Correspondencia");
            sb.AppendLine(" , cl.Bairro_Correspondencia");
            sb.AppendLine(" , cl.Cidade_Correspondencia");
            sb.AppendLine(" , cl.Estado_Correspondencia");
            sb.AppendLine(" , cl.CEP_Correspondencia");
            sb.AppendLine(" , t.Razao_Social as 'Razao_Social_Transportadora'");
            sb.AppendLine(" , t.CNPJ as 'CNPJ_Transportadora'");
            sb.AppendLine(" , t.Endereco as 'Endereco_Transportadora'");
            sb.AppendLine(" , t.Numero as 'Numero_Transportadora'");
            sb.AppendLine(" , t.Complemento as 'Complemento_Transportadora'");
            sb.AppendLine(" , t.Bairro as 'Bairro_Transportadora'");
            sb.AppendLine(" , t.Cidade as 'Cidade_Transportadora'");
            sb.AppendLine(" , t.Estado as 'Estado_Transportadora'");
            sb.AppendLine(" , t.CEP as 'CEP_Transportadora'");
            sb.AppendLine(" , t.DDD1 as 'DDD1_Transportadora'");
            sb.AppendLine(" , t.Fone1 as 'Fone1_Transportadora'");
            sb.AppendLine(" , pe.Gera_NF");
            sb.AppendLine(" from notas_fiscais nf");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join transportadoras t on t.transportadora = nf.transportadora");
            sb.AppendLine("  inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendLine("  left outer join cfops on cfops.cfop = nf.cfop");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Notas_Fiscais"
                    , sb.ToString()
                    , "Nota_Fiscal"));

            //-- Limpa.
            sb.Remove(0, sb.Length);

            sb.AppendLine("select ");
            sb.AppendLine("   notas_fiscais_itens.*");
            sb.AppendLine(" , cf.Classificacao_Fiscal_Nota");
            sb.AppendLine(" from notas_fiscais_itens");
            sb.AppendLine("  left outer join Classificacoes_fiscais cf on cf.classificacao_fiscal = notas_fiscais_itens.Classificacao_fiscal");
            sb.AppendLine(" where 1=1");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                    , "Notas_Fiscais_Itens"
                    , sb.ToString()
                    , "Nota_Fiscal_Item"));

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                    , "Notas_Fiscais_Duplicatas"
                    , "select * from notas_fiscais_duplicatas"));

            InitializeComponent();
        }

        #endregion Construtor

        #region Filtro de registros

        public override string user_Query(string TabelaAtual)
        {
            string sFilter = string.Empty;

            if (TabelaAtual.ToLower() == "notas_fiscais")
            {
                if (this.chkImpressaAtivar.Checked)
                {
                    //-- Nota fiscal impressa
                    if (this.optNFImpressaSim.Checked)
                    {
                        if (!string.IsNullOrEmpty(sFilter))
                            sFilter += " AND ";

                        sFilter += " nf.impressa = 1 ";
                    }

                    if (this.optNFImpressaNao.Checked)
                    {
                        if (!string.IsNullOrEmpty(sFilter))
                            sFilter += " AND ";

                        sFilter += " nf.impressa = 0 ";
                    }
                }

                if (this.chkCancelarAtivar.Checked)
                {
                    //-- Nota fiscal cancelada
                    if (this.optNFCanceladaSim.Checked)
                    {
                        if (!string.IsNullOrEmpty(sFilter))
                            sFilter += " AND ";

                        sFilter += " nf.cancelada = 1 ";
                    }

                    if (this.optNFCanceladaNao.Checked)
                    {
                        if (!string.IsNullOrEmpty(sFilter))
                            sFilter += " AND ";

                        sFilter += " nf.cancelada = 0 ";
                    }
                }

                if (this.chkFiltroPeriodoDtEmissao.Checked)
                {
                    if (!string.IsNullOrEmpty(sFilter))
                        sFilter += " AND ";

                    sFilter += " Data_Emissao between {0} and {1} ";
                    sFilter = string.Format(sFilter
                        , this.prdDataEmissao.Data_Inicial_SQL
                        , this.prdDataEmissao.Data_Termino_SQL);
                }
            }

            return sFilter;
        }

        #endregion Filtro de registros

        private void f0005_user_AfterRefreshData()
        {
            this.grdVencimentos.DataSource = this.DataSetLocal.Tables["notas_fiscais_duplicatas"];
            this.grdProdutos.DataSource = this.DataSetLocal.Tables["Notas_Fiscais_Itens"];

            if (this.BindingSource[this.MainTabela].Position >= 0)
            {
                DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
                Funcoes func = new Funcoes();
                if ((bool)row["Pessoa_Juridica"])
                    this.txtCNPJCliente.Mask = func.Busca_Propriedade("CNPJ_Masc");
                else
                    this.txtCNPJCliente.Mask = func.Busca_Propriedade("CPF_Masc");

                this.cboCFOP.Obrigatorio = (bool)row["gera_NF"];
            }
        }

        private void f0005_user_FormStatus_Change()
        {
            //-- Desabilita todos os controles da page de clientes.
            foreach (Control ctrl in this.pagaframe.TabPages[1].Controls)
                ctrl.Enabled = false;

            //-- Desabilita todos os controles da page da transportadora.
            foreach (Control ctrl in this.pagaframe.TabPages[3].Controls)
                ctrl.Enabled = false;

            this.chkConsiliacaoFinanceira.Enabled = false;
            this.chkNFImpressa.Enabled = false;

            //-- Trabalha com os status do formulário.
            switch (this.FormStatus)
            {
                case CompSoft.TipoFormStatus.Pesquisar:
                    this.cmdImprimirDuplicata.Enabled = true;
                    break;

                case CompSoft.TipoFormStatus.Novo:
                case CompSoft.TipoFormStatus.Modificando:
                    this.cmdImprimirDuplicata.Enabled = false;
                    this.txtCodCliente.Enabled = true;
                    this.txtCodTransportadora.Enabled = true;
                    this.lblCliente.Enabled = true;
                    this.lblTransportadora.Enabled = true;
                    this.grpTransporte.Enabled = true;
                    this.txtPlacaTransporte.Enabled = true;
                    this.cboEstadoTransporte.Enabled = true;
                    this.txtRegTransportador.Enabled = true;
                    this.lblEstado.Enabled = true;
                    this.lblPlaca.Enabled = true;
                    this.lblRegTransportador.Enabled = true;
                    this.chkNFPxportada.Enabled = false;
                    this.chkNFExportada.Enabled = false;
                    this.txtChaveAcesso.Enabled = false;
                    break;

                default:
                    this.cmdImprimirDuplicata.Enabled = false;
                    break;
            }
        }

        private void f0005_Load(object sender, EventArgs e)
        {
            Funcoes func;
            string sCNPJ = func.Busca_Propriedade("CNPJ_Masc"),
                sTelefone = func.Busca_Propriedade("Telefone_Masc"),
                sCEP = func.Busca_Propriedade("CEP_Masc");

            this.txtCNPJCliente.Mask = sCNPJ;
            this.txtCNPJTransportadora.Mask = sCNPJ;
            this.txtTelefoneTransportadora.Mask = sTelefone;
            this.txtCEPCliente.Mask = sCEP;
            this.txtCEPTransportadora.Mask = sCEP;
        }

        private void txtCodCliente_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodCliente.LookUpRetorno != null)
            {
                //-- Carrega a mascara do CPF ou CNPJ de acordo com o cadastro do cliente.
                Funcoes func;
                if ((bool)this.txtCodCliente.LookUpRetorno["Pessoa_Juridica"])
                    this.txtCNPJCliente.Mask = func.Busca_Propriedade("CNPJ_Masc");
                else
                    this.txtCNPJCliente.Mask = func.Busca_Propriedade("CPF_Masc");

                this.txtNomeCliente.Text = this.txtCodCliente.LookUpRetorno["Razao_Social"].ToString();
                this.txtCNPJCliente.Text = this.txtCodCliente.LookUpRetorno["CPF_CNPJ"].ToString();
                this.txtIECliente.Text = this.txtCodCliente.LookUpRetorno["RG_IE"].ToString();
                this.txtEnderecoCliente.Text = this.txtCodCliente.LookUpRetorno["Endereco_Correspondencia"].ToString();
                this.txtNumeroCliente.Text = this.txtCodCliente.LookUpRetorno["Numero_Correspondencia"].ToString();
                this.txtComplCliente.Text = this.txtCodCliente.LookUpRetorno["Complemento_Correspondencia"].ToString();
                this.txtBairroCliente.Text = this.txtCodCliente.LookUpRetorno["Bairro_Correspondencia"].ToString();
                this.txtCidadeCliente.Text = this.txtCodCliente.LookUpRetorno["Cidade_Correspondencia"].ToString();
                this.txtCEPCliente.Text = this.txtCodCliente.LookUpRetorno["CEP_Correspondencia"].ToString();

                //-- Trata o Estado caso seja nulo não atualizar.
                if (this.txtCodCliente.LookUpRetorno["Estado_Correspondencia"] != DBNull.Value)
                    this.cboEstadoCliente.SelectedValue = this.txtCodCliente.LookUpRetorno["Estado_Correspondencia"];
                else
                    this.cboEstadoCliente.SelectedValue = DBNull.Value;

                //-- Atualiza o tipo de pessoa do cliente. PJ / PF
                DataRowView rView = (DataRowView)this.BindingSource[this.MainTabela].Current;
                rView["Pessoa_Juridica"] = this.txtCodCliente.LookUpRetorno["Pessoa_Juridica"];
            }
        }

        private void txtCodTransportadora_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodTransportadora.LookUpRetorno != null)
            {
                this.txtNomeTransportadora.Text = this.txtCodTransportadora.LookUpRetorno["Razao_Social"].ToString();
                this.txtEnderecoTransportadora.Text = this.txtCodTransportadora.LookUpRetorno["Endereco"].ToString();
                this.txtNumeroTransportadora.Text = this.txtCodTransportadora.LookUpRetorno["Numero"].ToString();
                this.txtComplTransportadora.Text = this.txtCodTransportadora.LookUpRetorno["Complemento"].ToString();
                this.txtBairroTransportadora.Text = this.txtCodTransportadora.LookUpRetorno["Bairro"].ToString();
                this.txtCidadeTransportadora.Text = this.txtCodTransportadora.LookUpRetorno["Cidade"].ToString();
                this.txtCEPTransportadora.Text = this.txtCodTransportadora.LookUpRetorno["CEP"].ToString();
                this.txtCNPJTransportadora.Text = this.txtCodTransportadora.LookUpRetorno["CNPJ"].ToString();
                this.txtEstadoTransportadora.Text = this.txtCodTransportadora.LookUpRetorno["Estado"].ToString();
            }
        }

        private void f0005_user_AfterClear()
        {
            this.optNFCanceladaNao.Checked = true;
            this.optNFCanceladaSim.Checked = false;
            this.optNFImpressaNao.Checked = true;
            this.optNFImpressaSim.Checked = false;
            this.chkFiltroPeriodoDtEmissao.Checked = false;
            this.prdDataEmissao.Enabled = false;
        }

        private void chkFiltroPeriodoDtEmissao_CheckedChanged(object sender, EventArgs e)
        {
            this.prdDataEmissao.Enabled = this.chkFiltroPeriodoDtEmissao.Checked;
        }

        private void f0005_user_AfterSave()
        {
            //-- Em caso de cancelamento de nota fiscal
            if (this.chkNFCancelada.Checked)
            {
                //clsControleEstoque ceEstoque = new clsControleEstoque();
                int iNumero_Pedido = 0,
                    iCodigo_mov_estoque = 0;
                string sQuery = string.Empty,
                       sDescricao = string.Empty;

                DataRowView rVnf = (DataRowView)this.BindingSource[this.MainTabela].Current;
                iNumero_Pedido = Convert.ToInt32(rVnf["Pedido"]);

                //-- cancelamento de pedido
                sQuery = string.Format("UPDATE pedidos SET cancelado = 1 WHERE pedido = {0}", iNumero_Pedido);
                SQL.Execute(sQuery);

                //-- Gravacao de movimento estoque capa
                sDescricao = string.Format("Cancelamento Nota fiscal ", rVnf["Numero_Nota"]);
                iCodigo_mov_estoque = this.ceEstoque.Registra_Movimento_Estoque(
                                        (int)clsControleEstoque.Tipo_Movimento_Estoque.Entrada,
                                        Convert.ToInt32(rVnf["Empresa"]),
                                        Convert.ToInt32(rVnf["Cliente"]),
                                        Convert.ToString(rVnf["Numero_Nota"]),
                                        sDescricao,
                                        DateTime.Now,
                                        Convert.ToDecimal(rVnf["Valor_Total_Nota"]));

                sQuery = string.Format("nota_fiscal = {0}", Convert.ToString(rVnf["Numero_Nota"]));

                //-- Filtra itens da nota fiscal atual
                DataView dvinf = new DataView(this.DataSetLocal.Tables["Notas_Fiscais_Itens"]
                                             , sQuery
                                             , "nota_fiscal_item"
                                             , DataViewRowState.CurrentRows);

                foreach (DataRowView datarowviewinf in dvinf)
                {
                    //-- Gravacao de movimento estoque item
                    this.ceEstoque.Registra_Movimento_Estoque_Item(
                        iCodigo_mov_estoque,
                        Convert.ToInt32(datarowviewinf["Produto"]),
                        Convert.ToDecimal(datarowviewinf["Valor_Unitario"]),
                        Convert.ToInt32(datarowviewinf["Quantidade"]),
                        Convert.ToDecimal(datarowviewinf["Valor_Total_Item"]));

                    if (clsControleEstoque.Baixa_estoque_manual)
                    {
                        //-- Reinsercao do item do estoque
                        this.ceEstoque.Cancelamento_Item_Nota_Fiscal(
                            Convert.ToInt32(rVnf["Empresa"]),
                            Convert.ToInt32(datarowviewinf["Produto"]),
                            Convert.ToInt32(datarowviewinf["Quantidade"]));
                    }
                }

                if (this.chkNFExportada.Checked)
                {
                    sQuery = string.Empty;
                    sQuery += "select nfl.Nota_Fiscal_Lote";
                    sQuery += " from notas_fiscais_lotes_itens nfli";
                    sQuery += "  inner join notas_fiscais nf on nf.nota_fiscal = nfli.nota_fiscal";
                    sQuery += "  inner join notas_fiscais_lotes nfl on nfl.nota_fiscal_lote = nfli.nota_fiscal_lote";
                    sQuery += " where ";
                    sQuery += "  nfl.tipo_nfe = 1";
                    sQuery += "  and nfl.codigo_mensagem_retorno_nfe = 100";
                    sQuery += "  and nf.nota_fiscal = " + rVnf["Nota_Fiscal"].ToString();
                    object oValor = SQL.ExecuteScalar(sQuery);

                    if (oValor != DBNull.Value)
                    {
                        //-- Cancela NF-e.
                        IList<CompSoft.NFe.Dados_Arquivo_NFe> ilNotas = new List<CompSoft.NFe.Dados_Arquivo_NFe>();
                        CompSoft.NFe.Dados_Arquivo_NFe daNFe = new CompSoft.NFe.Dados_Arquivo_NFe();
                        ERP.NFe.NFe nfe = new ERP.NFe.NFe();

                        daNFe.Carregar_Dados(Convert.ToInt32(oValor));
                        ilNotas.Add(daNFe);
                        nfe.Cancelar_NFe(ilNotas);
                    }
                }

                //-- Exclui o titulo a receber.
                Funcoes func;
                if (Convert.ToBoolean(func.Busca_Propriedade("Gera_Consiliacao_Automatica")))
                {
                    Financeiro.ConsiliacaoFinanceira cf = new Financeiro.ConsiliacaoFinanceira();
                    cf.Excluir_ContaReceber(Convert.ToInt32(rVnf["Nota_Fiscal"]));
                }
            }
        }

        private void chkNFCancelada_CheckedChanged(object sender, EventArgs e)
        {
            //-- Em caso de cancelamento de nota fiscal
            if (this.FormStatus == CompSoft.TipoFormStatus.Modificando && this.chkNFCancelada.Checked)
            {
                DialogResult dr = MsgBox.Show("Deseja cancelar a nota atual e todos os seus itens?"
                    , "Cancelamento de Nota Fiscal"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                    this.chkNFCancelada.Checked = false;
                else
                {
                    this.chkConsiliacaoFinanceira.Checked = false;
                }
            }
        }

        private void cmdImprimirDuplicata_Click(object sender, EventArgs e)
        {
            if (this.grdVencimentos.CurrentRow == null)
                MsgBox.Show("Selecione um vencimento", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (this.BindingSource[this.MainTabela].Position >= 0)
                {
                    string sMensagem = "Deseja imprimir a duplicata do vencimento em '{0}'";
                    sMensagem = string.Format(sMensagem, Convert.ToDateTime(this.grdVencimentos.CurrentRow["Data_Vencimento"]).ToShortDateString());
                    DialogResult dr = MsgBox.Show(sMensagem
                        , "Atenção"
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int iCodigoNF = Convert.ToInt32(this.grdVencimentos.CurrentRow["Nota_Fiscal"]);

                        Funcoes func;
                        func.Executar_ObjetoEntrada("EmissaoDuplicata"
                                , new object[] { false }
                                , new object[] { iCodigoNF, Convert.ToInt32(this.grdVencimentos.CurrentRow["Numero_Parcela"]) }
                                , new string[] { "iCodigoNF", "iNumero_Parcela" });

                        this.grdVencimentos.CurrentRow["Impressa"] = true;
                        this.grdVencimentos.EndEdit();
                    }
                }
            }
        }
    }
}