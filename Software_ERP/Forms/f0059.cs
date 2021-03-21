using CompSoft;
using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0059 : CompSoft.FormSet
    {
        public f0059()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine("    cli.Cliente");
            sb.AppendLine("  , cli.Razao_Social");
            sb.AppendLine("  , cli.Nome_Fantasia");
            sb.AppendLine("  , cli.Pessoa_Juridica");
            sb.AppendLine("     , cli.CPF_CNPJ");
            sb.AppendLine("  , cli.RG_IE");
            sb.AppendLine("  , cli.Pessoa_Juridica");
            sb.AppendLine("  , cli.Endereco_Entrega");
            sb.AppendLine("  , cli.Numero_Entrega");
            sb.AppendLine("  , cli.Complemento_Entrega");
            sb.AppendLine("  , cli.Bairro_Entrega");
            sb.AppendLine("  , cli.Cidade_Entrega");
            sb.AppendLine("  , cli.Estado_Entrega");
            sb.AppendLine("  , cli.CEP_Entrega");
            sb.AppendLine("     , cli.DDD1");
            sb.AppendLine("     , cli.Fone1");
            sb.AppendLine("     , cli.DDD2");
            sb.AppendLine("     , cli.Fone2");
            sb.AppendLine("     , cli.DDD3");
            sb.AppendLine("     , cli.Fone3");
            sb.AppendLine("  , cli.Vendedor");
            sb.AppendLine("  , v.Nome_Vendedor");
            sb.AppendLine("  , cli.Inativo");
            sb.AppendLine("  , cli.Observacoes");
            sb.AppendLine(" from clientes cli ");
            sb.AppendLine("  left outer join vendedores v on v.vendedor = cli.vendedor");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Clientes"
                , sb.ToString()));

            sb.Remove(0, sb.Length - 1);
            sb.AppendLine("select");
            sb.AppendLine("       notas_fiscais.nota_fiscal");
            sb.AppendLine("       , case ");
            sb.AppendLine("         when  notas_fiscais.numero_nota > 0 then convert(varchar(100), notas_fiscais.numero_nota) ");
            sb.AppendLine("         else 'Cupom' ");
            sb.AppendLine("       end as 'numero_nota'");
            sb.AppendLine("     , ped.pedido");
            sb.AppendLine("     , notas_fiscais.valor_total_nota");
            sb.AppendLine("     , notas_fiscais.data_emissao");
            sb.AppendLine("     , notas_fiscais.Cliente");
            sb.AppendLine("     , cpp.condicao_Pagamento_pedido");
            sb.AppendLine("     , cpp.desc_cond_pgto");
            sb.AppendLine(" from notas_fiscais");
            sb.AppendLine("     inner join pedidos ped on ped.pedido = notas_fiscais.pedido");
            sb.AppendLine("     inner join condicoes_pagamento_pedido cpp on notas_fiscais.condicao_pagamento_pedido = cpp.condicao_pagamento_pedido");

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                    , "notas_fiscais"
                    , sb.ToString()
                    , "nota_fiscal"));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            string sQuery = string.Empty;

            if (TabelaAtual == "notas_fiscais")
                sQuery += " notas_fiscais.cancelada = 0 AND ped.cancelado = 0 ";

            return sQuery;
        }

        private void f0059_Load(object sender, EventArgs e)
        {
            Funcoes func;
            this.txtFone1.Mask = func.Busca_Propriedade("Telefone_Masc");
            this.txtFone2.Mask = func.Busca_Propriedade("Telefone_Masc");
            this.txtFone3.Mask = func.Busca_Propriedade("Telefone_Masc");
            this.txtCEP.Mask = func.Busca_Propriedade("cep_masc");
            this.lblMedia.Text = string.Empty;
            this.lblTotal.Text = string.Empty;
        }

        private void f0059_user_AfterRefreshData()
        {
            this.lblMedia.Text = string.Empty;
            this.lblTotal.Text = string.Empty;
            this.grdNotas.DataSource = this.DataSetLocal.Tables["notas_fiscais"];

            if (this.BindingSource[this.MainTabela].Position >= 0)
            {
                Funcoes func;
                DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
                if ((bool)row["Pessoa_juridica"])
                    this.txtCNPJ.Mask = func.Busca_Propriedade("CNPJ_Masc");
                else
                    this.txtCNPJ.Mask = func.Busca_Propriedade("CPF_Masc");
            }

            this.cmdLimparFiltro.Enabled = false;
            this.grdNotas.BindingSource.Filter = string.Empty;
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtNome.LookUpRetorno != null)
                this.txtCodigo.Text = this.txtNome.LookUpRetorno["cliente"].ToString();
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodigo.LookUpRetorno != null)
                this.txtNome.Text = this.txtCodigo.LookUpRetorno["razao_social"].ToString();
        }

        private void grdNotas_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdNotas.BindingSource.Position >= 0)
            {
                DataRowView row = (DataRowView)this.grdNotas.CurrentRow;
                int iNf = Convert.ToInt32(row["nota_fiscal"]);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select ");
                sb.AppendLine("   produto");
                sb.AppendLine(" , desc_produto");
                sb.AppendLine(" , desc_unidade_abrevidado");
                sb.AppendLine(" , quantidade");
                sb.AppendLine(" , valor_unitario");
                sb.AppendLine(" , valor_total_item");
                sb.AppendLine(" from notas_fiscais_itens");
                sb.AppendFormat(" where nota_fiscal = {0}", iNf);
                DataTable dt = SQL.Select(sb.ToString(), "notas_fiscais_itens", false);

                if (this.grdItensPedido.DataSource != null)
                {
                    this.grdItensPedido.BindingSource.DataSource = dt;
                }
                else
                {
                    BindingSource bs = new BindingSource(dt, null);
                    this.grdItensPedido.DataSource = bs;
                }

                this.cf_Pageframe1.SelectedTab = this.tabPage2;
            }
        }

        private void f0059_user_FormStatus_Change()
        {
            if (this.FormStatus == TipoFormStatus.Limpar && this.grdItensPedido.DataSource != null)
                ((DataTable)this.grdItensPedido.BindingSource.DataSource).Clear();

            if (this.FormStatus != TipoFormStatus.Pesquisar)
            {
                this.chkAtivarDtEmissao.Enabled = false;
                this.chkAtivarFormaPgto.Enabled = false;
                this.cmdFiltrarNotas.Enabled = false;
                this.cmdLimparFiltro.Enabled = false;
                this.chkAtivarDtEmissao.Checked = false;
                this.chkAtivarFormaPgto.Checked = false;
                this.prdNotas.Enabled = false;
                this.lstCondPgto.Enabled = false;

                if (this.grdNotas.BindingSource != null)
                    this.grdNotas.BindingSource.Filter = string.Empty;
            }
            else
            {
                this.chkAtivarDtEmissao.Enabled = true;
                this.chkAtivarFormaPgto.Enabled = true;
                this.cmdFiltrarNotas.Enabled = true;
            }
        }

        private void cmdLimparFiltro_Click(object sender, EventArgs e)
        {
            this.grdNotas.BindingSource.Filter = string.Empty;
            this.chkAtivarDtEmissao.Checked = false;
            this.chkAtivarFormaPgto.Checked = false;
        }

        private void cmdFiltrarNotas_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(300);
            if (this.chkAtivarDtEmissao.Checked)
            {
                sb.AppendFormat("Data_Emissao >= #{0}# AND Data_Emissao <= #{1}#"
                            , this.prdNotas.Data_Inicial.ToString("MM/dd/yyyy")
                            , this.prdNotas.Data_Termino.ToString("MM/dd/yyyy"));
            }

            if (this.chkAtivarFormaPgto.Checked)
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                int iContador = 0;
                sb.Append("condicao_Pagamento_pedido in (");

                foreach (DataRowView row in this.lstCondPgto.SelectedItems)
                {
                    if (iContador > 0)
                        sb.Append(",");

                    sb.Append(row[0]);
                    iContador++;
                }
                sb.Append(')');
            }

            this.grdNotas.BindingSource.Filter = sb.ToString();
            this.tabNotas.TabIndex = 1;
            this.cmdLimparFiltro.Enabled = true;
        }

        private void chkAtivarDtEmissao_CheckedChanged(object sender, EventArgs e)
        {
            this.prdNotas.Enabled = this.chkAtivarDtEmissao.Checked;
        }

        private void chkAtivarFormaPgto_CheckedChanged(object sender, EventArgs e)
        {
            this.lstCondPgto.Enabled = this.chkAtivarFormaPgto.Checked;
            this.lstCondPgto.SelectedIndices.Clear();
        }

        private void grdNotas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            string sFilter = this.grdNotas.BindingSource.Filter;
            DataTable dt = (DataTable)this.grdNotas.BindingSource.DataSource;

            object oValor = dt.Compute("sum(valor_total_nota)", sFilter);
            if (oValor != DBNull.Value && oValor != null)
                this.lblTotal.Text = Convert.ToDecimal(oValor).ToString("n2");

            oValor = dt.Compute("avg(valor_total_nota)", sFilter);
            if (oValor != DBNull.Value && oValor != null)
                this.lblMedia.Text = Convert.ToDecimal(oValor).ToString("n2");
        }
    }
}