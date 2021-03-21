using CompSoft.Data;
using System;
using System.Text;

namespace ERP.Forms
{
    public partial class f0064 : CompSoft.FormSet
    {
        public f0064()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   nf.Nota_Fiscal");
            sb.AppendLine(" , nf.Data_Emissao");
            sb.AppendLine(" , nf.Numero_Nota as 'Nro_NF'");
            sb.AppendLine(" , nf.CFOP");
            sb.AppendLine(" , cfop.Desc_CFOP");
            sb.AppendLine(" , cl.cpf_cnpj ");
            sb.AppendLine(" , nf.Valor_Base_Substituicao_ICMS");
            sb.AppendLine(" , nf.Valor_Substituicao_ICMS");
            sb.AppendLine(" , nf.Valor_Total_Produtos");
            sb.AppendLine(" , nf.Valor_Total_Nota");
            sb.AppendLine(" , nf.Empresa");
            sb.AppendLine(" , e.razao_social");
            sb.AppendLine(" from notas_fiscais nf");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine("  inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendLine("  left outer join cfops cfop on cfop.cfop = nf.cfop");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Notas_fiscais_Geradas"
                , sb.ToString()
                , "Nota_fiscal"));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            string sFilter = string.Empty;

            sFilter += " pe.Gera_NF = 1 and nf.cancelada = 0 AND pe.cancelado = 0 and nf.Exportacao_NFe = 1 ";

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

            if (this.chkFiltroEmpresa.Checked && this.cboEmpresa.SelectedIndex >= 0)
            {
                if (!string.IsNullOrEmpty(sFilter))
                    sFilter += " AND ";

                sFilter += string.Format(" nf.empresa = {0} ", this.cboEmpresa.SelectedValue);
            }

            return sFilter;
        }

        private void chkAtivaData_CheckedChanged(object sender, EventArgs e)
        {
            this.optDataNF.Enabled = this.chkAtivaData.Checked;
            this.optDataPedido.Enabled = this.chkAtivaData.Checked;
            this.prdPeriodo.Enabled = this.chkAtivaData.Checked;
            if (!this.optDataPedido.Checked && !this.optDataPedido.Checked)
                this.optDataNF.Checked = true;
        }

        private void chkAtivaNFImpressa_CheckedChanged(object sender, EventArgs e)
        {
            this.optNFImpressaSim.Enabled = this.chkAtivaNFImpressa.Checked;
            this.optNFImpressaNao.Enabled = this.chkAtivaNFImpressa.Checked;
            if (this.chkAtivaNFImpressa.Checked)
                this.optNFImpressaSim.Checked = true;
        }

        private void f0055_user_AfterRefreshData()
        {
            this.grdComissao.DataSource = this.DataSetLocal.Tables[this.MainTabela];
        }

        private void f0055_user_FormStatus_Change()
        {
            this.chkAtivaNFImpressa_CheckedChanged(this, new EventArgs());
            this.chkAtivaData_CheckedChanged(this, new EventArgs());
            this.chkFiltroEmpresa_CheckedChanged(this, new EventArgs());
        }

        private void chkFiltroEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            this.cboEmpresa.Enabled = this.chkFiltroEmpresa.Checked;
            if (!this.chkFiltroEmpresa.Checked)
                this.cboEmpresa.SelectedIndex = -1;
        }
    }
}