using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0060 : CompSoft.formBase
    {
        public f0060()
        {
            InitializeComponent();
        }

        #region Busca Notas Fiscais / Cupom para impressao.

        private void Buscar_Dados()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   convert(bit, 0) as 'Sel'");
            sb.AppendLine(" , nf.Nota_Fiscal");
            sb.AppendLine(" , case pe.gera_NF");
            sb.AppendLine("  when 1 then 'Nota Fiscal'");
            sb.AppendLine("  else 'Cupom'");
            sb.AppendLine("   end as 'Tipo_Documento'");
            sb.AppendLine(" , nf.Empresa");
            sb.AppendLine(" , e.Razao_Social as 'Razao_Social_Empresa'");
            sb.AppendLine(" , nf.Pedido");
            sb.AppendLine(" , nf.Numero_Nota");
            sb.AppendLine(" , nf.Impressa");
            sb.AppendLine(" , nf.Data_Emissao");
            sb.AppendLine(" , nf.Cliente");
            sb.AppendLine(" , cl.Razao_Social as 'Razao_Social_Cliente'");
            sb.AppendLine(" , nf.Valor_total_nota");
            sb.AppendLine(" from notas_fiscais nf ");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine("  inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendLine(" where nf.cancelada = 0");
            sb.AppendLine("     and nf.Estoque_Baixado = 0");

            if (this.chkEmpresa.Checked)
                sb.AppendFormat("  and nf.Empresa = {0}\r\n", this.cboEmpresa.SelectedValue);

            if (this.chkPedido.Checked)
                sb.AppendFormat("  and pe.pedido = {0}\r\n", this.txtPedido.Text);

            if (this.chkNF.Checked)
                sb.AppendFormat("  and nf.Numero_Nota = {0}\r\n", this.txtNF.Text);

            if (this.chkData.Checked)
                sb.AppendFormat("  and nf.Data_Emissao between '{0}' and '{1}'\r\n"
                    , this.prdPeriodo.Data_Inicial_SQL
                    , this.prdPeriodo.Data_Termino_SQL);

            sb.AppendLine(" order by nf.Pedido");

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
                sMsg = "ERRO AO PESQUISAR DOCUMENTOS\r\n\r\n" + sMsg;
                MsgBox.Show(sMsg
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
            }
            else
            {
                this.Buscar_Dados();
                if (this.grdItens.Rows.Count > 0)
                    this.cmdBaixarEstoque.Visible = true;
                else
                    this.cmdBaixarEstoque.Visible = false;
            }
        }

        private void grdItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                this.grdItens.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void grdItens_EditModeChanged(object sender, EventArgs e)
        {
            this.grdItens.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void f0056_Load(object sender, EventArgs e)
        {
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

        private void cmdBaixarEstoque_Click(object sender, EventArgs e)
        {
            DataRow[] fRow_doc = ((DataTable)this.grdItens.BindingSource.DataSource).Select("Sel = 1");

            if (fRow_doc.Length == 0)
            {
                MsgBox.Show("Selecione documentos para baixar o estoque."
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
            else
            {
                string sMensagem = string.Empty;
                if (fRow_doc.Length == 1)
                    sMensagem = "Será baixado 1 documento, você confirma?";
                else
                    sMensagem = string.Format("Serão baixados {0} documentos, você confirma?", fRow_doc.Length);

                DialogResult dr = MsgBox.Show(sMensagem
                    , "Atenção"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, baixando itens do estoque...", CompSoft.Tools.frmWait.Tipo_Imagem.Atencao);

                    ERP.Class.clsControleEstoque ce = new ERP.Class.clsControleEstoque();
                    foreach (DataRow row_doc in fRow_doc)
                    {
                        string sSQL = "select Produto, Quantidade from notas_fiscais_itens where nota_fiscal = {0} ";
                        sSQL = string.Format(sSQL, row_doc["Nota_Fiscal"]);
                        DataRow[] fRow_Itens = SQL.Select(sSQL, "", false).Select();

                        //-- Loop com todos os itens da nota.
                        foreach (DataRow row_itens in fRow_Itens)
                        {
                            //-- Movimenta estoque
                            ce.Inclusao_Item_Nota_Fiscal(Convert.ToInt32(row_doc["Empresa"])
                                , Convert.ToInt32(row_itens["Produto"])
                                , Convert.ToInt32(row_itens["Quantidade"]));
                        }

                        //-- Marca a nota fiscal como baixada para verificação no cancelamento para retornar itens para o estoque.
                        ce.Marca_Nota_Fiscal_Baixada(Convert.ToInt32(row_doc["Nota_Fiscal"]));
                    }

                    ((DataTable)this.grdItens.BindingSource.DataSource).Clear();
                    this.cmdBaixarEstoque.Visible = false;

                    f.Close();
                }
            }
        }
    }
}