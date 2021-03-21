using CompSoft.Data;
using System;
using System.Text;

namespace ERP.Forms
{
    public partial class f0089 : CompSoft.FormSet
    {
        public f0089()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.AppendLine("SELECT ");
            sb.AppendLine("   nf.Nota_Fiscal");
            sb.AppendLine(" , nf.Data_Emissao");
            sb.AppendLine(" , nf.Pedido");
            sb.AppendLine(" , CASE ");
            sb.AppendLine("  WHEN p.Gera_NF = 1 THEN CONVERT(VARCHAR(10), nf.Numero_Nota)");
            sb.AppendLine("  ELSE 'Cupom'");
            sb.AppendLine("   END AS 'Numero_Nota'");
            sb.AppendLine(" , cl.cliente");
            sb.AppendLine(" , cl.Razao_Social");
            sb.AppendLine(" , nf.Valor_Total_Produtos");
            sb.AppendLine(" , nf.Valor_Total_Nota");
            sb.AppendLine(" , nf.Valor_Substituicao_ICMS");
            sb.AppendLine(" , cpp.Desc_Cond_Pgto");
            sb.AppendLine(" , CASE ");
            sb.AppendLine("  WHEN cpp.Parcelado = 1 THEN 'F'");
            sb.AppendLine("  ELSE 'V'");
            sb.AppendLine("   END AS 'Parcelado'");
            sb.AppendLine(" , nf.Cancelada");
            sb.AppendLine(" , nf.Exportacao_NFe");
            sb.AppendLine(" FROM Condicoes_Pagamento_Pedido cpp");
            sb.AppendLine("  INNER JOIN Notas_Fiscais nf ON nf.Condicao_Pagamento_Pedido = cpp.Condicao_Pagamento_Pedido");
            sb.AppendLine("  INNER JOIN Pedidos p ON p.pedido = nf.Pedido");
            sb.AppendLine("  INNER JOIN Clientes cl ON cl.cliente = nf.cliente");
            sb.AppendLine(" where 1=1");

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Notas_Fiscais",
                sb.ToString()
                , "Nota_Fiscal,Pedido"));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            StringBuilder sb = new StringBuilder(100);

            if (this.chkAtivarEmpresa.Checked)
                sb.AppendFormat("     nf.Empresa = {0}\r\n", this.cboEmpresa.SelectedValue);

            if (this.chkAtivarDataEmissao.Checked)
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendFormat("     nf.Data_Emissao between '{0}' and '{1}'\r\n"
                    , this.prdDataEmissao.Data_Inicial_SQL
                    , this.prdDataEmissao.Data_Termino_SQL);
            }

            //-- se não estivar marcado para incluir canceladas... selecionar apenas as não canceladas.
            if (!this.chkApenasCancelada.Checked)
            {
                if (!this.chkCancelada.Checked)
                {
                    if (sb.Length > 0)
                        sb.Append(" AND ");

                    sb.AppendLine("     nf.Cancelada = 0 AND p.Cancelado = 0 ");
                }
            }
            else
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendLine("     nf.Cancelada = 1");
            }

            //-- se não estivar marcado para incluir nfe não exportaads... selecionar apenas as exportadas.
            if (!this.chkNfeNaoExportada.Checked)
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendLine("     nf.Exportacao_NFe = 1");
            }

            if (this.chkAtivarTipoDocumento.Checked)
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                if (this.rdoNotaFiscal.Checked)
                    sb.Append(" p.gera_nf = 1 ");

                if (this.rdoCupom.Checked)
                    sb.Append(" p.gera_nf = 0 ");
            }

            return sb.ToString();
        }

        private void f0089_user_AfterRefreshData()
        {
            this.grdDados.DataSource = this.DataSetLocal.Tables[0];
            this.grdDados.BindingSource.Sort = "Data_Emissao";

            decimal dFaturado = 0;
            decimal dAVista = 0;
            decimal dTotalGeral = 0;

            //-- Faturado
            object oValor = this.DataSetLocal.Tables[0].Compute("sum(Valor_Total_Nota)", "Parcelado = 'F'");
            if (oValor != DBNull.Value && oValor != null)
                dFaturado = Convert.ToDecimal(oValor);

            //-- A Vista
            oValor = this.DataSetLocal.Tables[0].Compute("sum(Valor_Total_Nota)", "Parcelado = 'V'");
            if (oValor != DBNull.Value && oValor != null)
                dAVista = Convert.ToDecimal(oValor);

            this.lblTotalAPrazo.Text = dFaturado.ToString("n2");
            this.lblTotaAVista.Text = dAVista.ToString("n2");

            dTotalGeral = dAVista + dFaturado;

            this.lblTotalGeral.Text = dTotalGeral.ToString("n2");
        }

        private void f0089_user_AfterClear()
        {
            this.lblTotalAPrazo.Text = "R$ 0,00";
            this.lblTotaAVista.Text = "R$ 0,00";
            this.lblTotalGeral.Text = "R$ 0,00";
        }

        private void chkAtivarEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            this.cboEmpresa.Enabled = this.chkAtivarEmpresa.Checked;
        }

        private void chkAtivarDataEmissao_CheckedChanged(object sender, EventArgs e)
        {
            this.prdDataEmissao.Enabled = this.chkAtivarDataEmissao.Checked;
        }

        private void chkApenasCancelada_CheckedChanged(object sender, EventArgs e)
        {
            this.chkCancelada.Enabled = !this.chkApenasCancelada.Checked;
            this.chkCancelada.Checked = false;
        }

        private void chkAtivarTipoDocumento_CheckedChanged(object sender, EventArgs e)
        {
            this.rdoCupom.Enabled = this.chkAtivarTipoDocumento.Checked;
            this.rdoNotaFiscal.Enabled = this.chkAtivarTipoDocumento.Checked;

            this.rdoNotaFiscal.Checked = false;
            this.rdoCupom.Checked = false;

            if (this.chkAtivarTipoDocumento.Checked)
                this.rdoNotaFiscal.Checked = true;
        }

        private void f0089_Load(object sender, EventArgs e)
        {
            this.chkApenasCancelada_CheckedChanged(this, EventArgs.Empty);
            this.chkAtivarDataEmissao_CheckedChanged(this, EventArgs.Empty);
            this.chkAtivarEmpresa_CheckedChanged(this, EventArgs.Empty);
            this.chkAtivarTipoDocumento_CheckedChanged(this, EventArgs.Empty);
        }
    }
}