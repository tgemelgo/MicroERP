using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0058 : CompSoft.formBase
    {
        public f0058()
        {
            InitializeComponent();
        }

        #region Busca Notas Fiscais / Cupom para impressao.

        private void Buscar_Dados()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   convert(bit, 0) as 'Sel'");
            sb.AppendLine(" , nfd.Nota_fiscal_Duplicata");
            sb.AppendLine(" , nfd.Nota_Fiscal");
            sb.AppendLine(" , cl.Razao_Social as 'Cliente'");
            sb.AppendLine(" , e.razao_Social as 'Empresa'");
            sb.AppendLine(" , nf.Numero_Nota");
            sb.AppendLine(" , pe.Pedido");
            sb.AppendLine(" , nfd.Numero_Parcela");
            sb.AppendLine(" , nfd.Data_Vencimento");
            sb.AppendLine(" , nfd.Valor_Duplicata");
            sb.AppendLine(" , nfd.Impressa");
            sb.AppendLine(" from notas_fiscais_duplicatas nfd");
            sb.AppendLine("  inner join notas_fiscais nf on nf.Nota_fiscal = nfd.Nota_Fiscal");
            sb.AppendLine("  inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine(" where ");
            sb.AppendLine("      pe.gera_Nf = 1");
            sb.AppendLine("  and nf.Cancelada = 0");

            if (this.optNFImpressaSim.Checked)
                sb.AppendLine("  and nfd.Impressa = 1");

            if (this.optNFImpressaNao.Checked)
                sb.AppendLine("  and nfd.Impressa = 0");

            if (this.chkEmpresa.Checked)
                sb.AppendFormat("  and nf.Empresa = {0}\r\n", this.cboEmpresa.SelectedValue);

            if (this.chkPedido.Checked)
                sb.AppendFormat("  and pe.pedido = {0}\r\n", this.txtPedido.Text);

            if (this.chkNF.Checked)
                sb.AppendFormat("  and nf.Numero_Nota = {0}\r\n", this.txtNF.Text);

            if (this.chkData.Checked)
                sb.AppendFormat("  and nfd.Data_Vencimento between '{0}' and '{1}'\r\n"
                    , this.prdPeriodo.Data_Inicial_SQL
                    , this.prdPeriodo.Data_Termino_SQL);

            sb.AppendLine(" order by nf.Nota_Fiscal, nf.Numero_nota, nfd.numero_parcela ");
            DataTable dt = SQL.Select(sb.ToString(), "x", false);
            dt.Columns[0].ReadOnly = false;

            if (this.grdItens.DataSource != null)
            {
                this.grdItens.BindingSource.DataSource = dt;
            }
            else
            {
                BindingSource bs = new BindingSource(dt, null);
                this.grdItens.DataSource = bs;
            }
        }

        #endregion Busca Notas Fiscais / Cupom para impressao.

        private void cmdPesquisa_Click(object sender, EventArgs e)
        {
            string sMsg = string.Empty;

            if (this.chkData.Checked && (string.IsNullOrEmpty(this.prdPeriodo.Data_Inicial_SQL)
                || string.IsNullOrEmpty(this.prdPeriodo.Data_Termino_SQL)))
                sMsg += "   - A data de emissão tem que ser preenchida.\r\n";

            if (this.chkEmpresa.Checked && this.cboEmpresa.SelectedIndex < 0)
                sMsg += "   - A empresa tem que ser selecionada.\r\n";

            if (this.chkNF.Checked && string.IsNullOrEmpty(this.txtNF.Text))
                sMsg += "   - O número da nota fiscal / cupom tem que ser preenchido.\r\n";

            if (this.chkPedido.Checked && string.IsNullOrEmpty(this.txtPedido.Text))
                sMsg += "   - O número do pedido tem que ser preenchido.\r\n";

            if (!string.IsNullOrEmpty(sMsg))
            {
                sMsg = "ERRO AO PESQUISAR DUPLICATAS\r\n\r\n" + sMsg;
                MsgBox.Show(sMsg
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
            }
            else
            {
                this.Buscar_Dados();
                if (this.grdItens.BindingSource.Count > 0)
                    this.cmdImprimir.Visible = true;
                else
                    this.cmdImprimir.Visible = false;
            }
        }

        private void grdItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                this.grdItens.EditMode = DataGridViewEditMode.EditOnEnter;
            else
                this.grdItens.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void grdItens_EditModeChanged(object sender, EventArgs e)
        {
            this.grdItens.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            DataTable dt = this.grdItens.BindingSource.DataSource as DataTable;
            DataView dv = new DataView(dt, "sel = 1", "", DataViewRowState.CurrentRows);
            int iQtdeDV = dv.Count;

            if (iQtdeDV == 0)
            {
                MsgBox.Show("Não foram encontrados registros para esta pesquisa."
                    , "Pesquisa"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
            else
            {
                string sMensage = string.Empty;
                if (iQtdeDV == 1)
                    sMensage += "Será impresso um documento, você confirma?";
                else
                    sMensage += string.Format("Serão impressos {0} documentos, você confirma?", iQtdeDV);

                DialogResult dr = MsgBox.Show(sMensage
                    , "Impressão de Duplicatas"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    bool bPreview = this.optTela.Checked;
                    Funcoes func;

                    string sfileImpressao = Application.StartupPath + @"\Impressao.txt";
                    string sPorta = func.Busca_Propriedade("Porta_Padrao_Matricial");

                    foreach (DataRowView row in dv)
                    {
                        if (File.Exists(sfileImpressao))
                            File.Delete(sfileImpressao);

                        ERP.NotaFiscal.EmissaoNotaFiscal enf = new ERP.NotaFiscal.EmissaoNotaFiscal(true);
                        enf.Emitir_Duplicata(Convert.ToInt32(row["Nota_Fiscal"]), Convert.ToInt32(row["Numero_Parcela"]), !bPreview);

                        if (!bPreview)
                        {
                            using (StreamReader sr = new StreamReader(sfileImpressao))
                            {
                                RawPrinterHelper.SendStringToPrinter(sPorta, sr.ReadToEnd());
                            }
                        }
                    }

                    //-- Visualiza ou imprime em papel
                    if (bPreview)
                    {
                        CompSoft.Reports.Preview_Matricial pm = new CompSoft.Reports.Preview_Matricial();
                        pm.Visualizar();
                    }
                    else
                    {
                        ((DataTable)this.grdItens.BindingSource.DataSource).Clear();
                        this.cmdImprimir.Visible = false;
                    }
                }
            }
        }

        private void f0056_Load(object sender, EventArgs e)
        {
            this.optNFImpressaNao.Checked = true;
            this.optNFImpressaSim.Checked = false;
            this.optTela.Checked = true;
            this.optImpressora.Checked = false;
            this.chkPedido_CheckedChanged(sender, new EventArgs());
            this.chkEmpresa_CheckedChanged(sender, new EventArgs());
            this.chkData_CheckedChanged(sender, new EventArgs());
            this.chkNF_CheckedChanged(sender, new EventArgs());
        }

        private void chkPedido_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPedido.Enabled = this.chkPedido.Checked;
        }

        private void chkEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            this.cboEmpresa.Enabled = this.chkEmpresa.Checked;
        }

        private void chkData_CheckedChanged(object sender, EventArgs e)
        {
            this.prdPeriodo.Enabled = this.chkData.Checked;
        }

        private void chkNF_CheckedChanged(object sender, EventArgs e)
        {
            this.txtNF.Enabled = this.chkNF.Checked;
        }

        private void selecionarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in ((DataTable)this.grdItens.BindingSource.DataSource).Select())
            {
                row["sel"] = true;
                row.EndEdit();
            }
        }
    }
}