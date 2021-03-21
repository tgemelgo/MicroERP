using CompSoft.Data;
using System;
using System.Text;

namespace ERP.Forms
{
    public partial class f0055 : CompSoft.FormSet
    {
        public f0055()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   nf.Numero_Nota");
            sb.AppendLine(" , cl.Razao_Social");
            sb.AppendLine(" , pe.Pedido");
            sb.AppendLine(" , v.Vendedor");
            sb.AppendLine(" , v.Nome_Vendedor");
            sb.AppendLine(" , pe.Data_pedido");
            sb.AppendLine(" , nf.Data_Emissao");
            sb.AppendLine(" , nf.Impressa");
            sb.AppendLine(" , sum(pi.Valor_Total) as 'Valor_Total'");
            sb.AppendLine(" , sum(pi.Valor_Comissao) as 'Valor_Comissao'");
            sb.AppendLine(" from notas_fiscais nf");
            sb.AppendLine("  inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendLine("  inner join pedidos_itens pi on pi.pedido = pe.pedido");
            sb.AppendLine("  inner join vendedores v on v.vendedor = pe.vendedor");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine(" group by nf.Numero_Nota, cl.Razao_Social, pe.Pedido, v.Vendedor, v.Nome_Vendedor, pe.Data_pedido, nf.Data_Emissao, nf.Impressa");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Comissao"
                , sb.ToString()));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            string sFilter = string.Empty;

            sFilter += " nf.cancelada = 0 AND pe.cancelado = 0 ";

            //-- Trata datas.
            if (this.chkAtivaData.Checked)
            {
                if (!string.IsNullOrEmpty(sFilter))
                    sFilter += " AND ";

                if (this.optDataPedido.Checked)
                    sFilter += " pe.Data_Pedido between '{0}' and '{1}' ";

                if (this.optDataNF.Checked)
                    sFilter += " nf.Data_Emissao between '{0}' and '{1}' ";

                sFilter = string.Format(sFilter
                    , this.prdPeriodo.Data_Inicial_SQL
                    , this.prdPeriodo.Data_Termino_SQL);
            }

            //-- Filtra o vendedor.
            if (this.chkVendedor.Checked)
            {
                if (!string.IsNullOrEmpty(sFilter))
                    sFilter += " AND ";

                sFilter += string.Format(" pe.Vendedor = {0}"
                    , this.cboVendedor.SelectedValue);
            }

            //-- Filtra se a nota fiscal já foi impressa
            if (this.chkAtivaNFImpressa.Checked)
            {
                if (!string.IsNullOrEmpty(sFilter))
                    sFilter += " AND ";

                if (this.optNFImpressaSim.Checked)
                    sFilter += " nf.Impressa = 1 ";

                if (this.optNFImpressaNao.Checked)
                    sFilter += " nf.impressa = 0 ";
            }

            return sFilter;
        }

        private void chkVendedor_CheckedChanged(object sender, EventArgs e)
        {
            this.cboVendedor.Enabled = this.chkVendedor.Checked;
        }

        private void chkAtivaData_CheckedChanged(object sender, EventArgs e)
        {
            this.optDataNF.Enabled = this.chkAtivaData.Checked;
            this.optDataPedido.Enabled = this.chkAtivaData.Checked;
            this.prdPeriodo.Enabled = this.chkAtivaData.Checked;
            if (!this.optDataPedido.Checked && !this.optDataNF.Checked)
                this.optDataPedido.Checked = true;
        }

        private void chkAtivaNFImpressa_CheckedChanged(object sender, EventArgs e)
        {
            this.optNFImpressaSim.Enabled = this.chkAtivaNFImpressa.Checked;
            this.optNFImpressaNao.Enabled = this.chkAtivaNFImpressa.Checked;
        }

        private void f0055_user_AfterRefreshData()
        {
            this.grdComissao.DataSource = this.DataSetLocal.Tables[this.MainTabela];
        }

        private void f0055_user_FormStatus_Change()
        {
            this.chkAtivaNFImpressa_CheckedChanged(this, new EventArgs());
            this.chkAtivaData_CheckedChanged(this, new EventArgs());
            this.chkVendedor_CheckedChanged(this, new EventArgs());
        }
    }
}