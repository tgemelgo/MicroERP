using CompSoft.Data;
using System;
using System.ComponentModel;
using System.Text;

namespace ERP.Forms
{
    public partial class f0090 : CompSoft.FormSet
    {
        public f0090()
        {
            StringBuilder sb = new StringBuilder(500);
            sb.AppendLine("SELECT ");
            sb.AppendLine("   ccp.Conta_Receber_Parcela");
            sb.AppendLine(" , e.Razao_Social AS 'Razao_Social_Empresa'");
            sb.AppendLine(" , cl.Razao_Social AS 'Razao_Social_Cliente'");
            sb.AppendLine(" , cr.Numero_Documento");
            sb.AppendLine(" , ccp.Data_Vencimento");
            sb.AppendLine(" , cr.Valor_Original AS 'Valor_Titulo'");
            sb.AppendLine(" , ccp.Valor_Original AS 'Valor_Parcela'");
            sb.AppendLine(" , crm.Valor_Pago");
            sb.AppendLine(" , ccp.Protesto");
            sb.AppendLine(" , COALESCE(crm.Protesto_Pago, 0) AS 'Protesto_Pago'");
            sb.AppendLine(" , crm.Protesto_Pago_Data");
            sb.AppendLine(" , COALESCE(ccp.Parcela_Paga, 0) AS 'Parcela_Paga'");
            sb.AppendLine(" FROM Contas_Receber_Parcela ccp");
            sb.AppendLine("  INNER JOIN Contas_Receber cr ON cr.Conta_receber = ccp.Conta_Receber");
            sb.AppendLine("  INNER JOIN Empresas e ON e.empresa = cr.Empresa");
            sb.AppendLine("  INNER JOIN clientes cl ON cl.cliente = cr.Cliente");
            sb.AppendLine("  LEFT OUTER JOIN Contas_Receber_mov crm ON crm.Conta_Receber_Parcela = ccp.Conta_Receber_Parcela");

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                        , "Contas_Receber_Parcela"
                        , sb.ToString()));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            StringBuilder sb = new StringBuilder(300);

            //-- Trata valores de datas inicias e finais
            if (!string.IsNullOrEmpty(this.prdPeriodo.Data_Inicial_SQL) && !string.IsNullOrEmpty(this.prdPeriodo.Data_Termino_SQL))
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendFormat(" ccp.Data_Vencimento between '{0}' and '{1}'\r\n"
                        , this.prdPeriodo.Data_Inicial_SQL
                        , this.prdPeriodo.Data_Termino_SQL);
            }

            //-- Trava tipos de documento
            if (this.optProtestado.Checked)
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendLine("   ccp.Protesto = 1");
            }

            if (this.optNaoProtestado.Checked)
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendLine("   ccp.Protesto = 0");
            }

            if (this.chkAtivaCliente.Checked)
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendFormat("   cl.cliente = {0}\r\n", this.txtCodCliente.Text);
            }

            return sb.ToString();
        }

        private void f0090_user_AfterRefreshData()
        {
            this.grdDados.DataSource = this.DataSetLocal.Tables[0];
            this.chkAtivaEmpresa_CheckedChanged(this, EventArgs.Empty);
            this.chAtivaCliente_CheckedChanged(this, EventArgs.Empty);
        }

        private void txtCodCliente_Validating(object sender, CancelEventArgs e)
        {
            this.txtNomeCliente.Text = this.txtCodCliente.LookUpRetorno["Razao_Social"].ToString();
        }

        private void chkAtivaEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            this.cboEmpresa.Enabled = this.chkAtivaEmpresa.Checked;

            this.cboEmpresa.SelectedIndex = -1;
        }

        private void chAtivaCliente_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCodCliente.Enabled = this.chkAtivaCliente.Checked;

            this.txtCodCliente.Text = string.Empty;
            this.txtNomeCliente.Text = string.Empty;
        }

        private void f0090_user_FormStatus_Change()
        {
            this.txtNomeCliente.Enabled = false;
        }
    }
}