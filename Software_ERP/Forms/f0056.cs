using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0056 : CompSoft.formBase
    {
        #region Enum

        private enum Tipos_Selecoes
        {
            Tudo,
            Notas_Fiscais,
            Cupom
        }

        #endregion Enum

        public f0056()
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
            sb.AppendLine(" , nf.Numero_Nota");
            sb.AppendLine(" , nf.Pedido");
            sb.AppendLine(" , nf.Data_Emissao");
            sb.AppendLine(" , e.Razao_Social as 'Razao_Social_Empresa'");
            sb.AppendLine(" , cl.razao_Social as 'Razao_Social_Cliente'");
            sb.AppendLine(" , cl.Nome_Fantasia as 'Nome_Fantasia_Cliente'");
            sb.AppendLine(" , nf.Valor_Total_Nota");
            sb.AppendLine(" , pe.gera_nf");
            sb.AppendLine(" , Case pe.gera_nf");
            sb.AppendLine("  when 1 then 'Nota Fiscal'");
            sb.AppendLine("  when 0 then 'Cupom'");
            sb.AppendLine("   end as 'Tipo_Documento'");
            sb.AppendLine(" , nf.Observacao");
            sb.AppendLine(" from notas_fiscais nf ");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendLine(" where ");
            sb.AppendLine("      nf.Cancelada = 0");
            sb.AppendLine("  and ((pe.gera_NF = 1 and nf.cfop is not null) or (pe.gera_nf = 0 and nf.cfop is null))");
            //sb.AppendLine("  and e.nfe_ativar_recurso = 0");

            if (this.optNFImpressaSim.Checked)
                sb.AppendLine("  and nf.Impressa = 1");

            if (this.optNFImpressaNao.Checked)
                sb.AppendLine("  and nf.Impressa = 0");

            if (this.chkEmpresa.Checked)
                sb.AppendFormat("  and nf.Empresa = {0}\r\n", this.cboEmpresa.SelectedValue);

            if (this.chkTipoDocumento.Checked)
                sb.AppendFormat("  and pe.gera_nf = {0}\r\n", this.cboTipoDocumento.SelectedValue);

            if (this.chkPedido.Checked)
                sb.AppendFormat("  and pe.pedido = {0}\r\n", this.txtPedido.Text);

            if (this.chkData.Checked)
                sb.AppendFormat("  and nf.Data_Emissao between '{0}' and '{1}'\r\n"
                    , this.prdPeriodo.Data_Inicial_SQL
                    , this.prdPeriodo.Data_Termino_SQL);

            sb.AppendLine("  order by nf.data_emissao");
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

        #region Selecionar itens no Grid de acordo com a escolha

        private void Selecinar_Itens_Grid(Tipos_Selecoes tipo_Selecao)
        {
            DataTable dt = (DataTable)this.grdItens.BindingSource.DataSource;
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

            this.grdItens.BindingSource.EndEdit();
        }

        #endregion Selecionar itens no Grid de acordo com a escolha

        private void cmdPesquisa_Click(object sender, EventArgs e)
        {
            string sMsg = string.Empty;

            if (this.chkData.Checked && (string.IsNullOrEmpty(this.prdPeriodo.Data_Inicial_SQL)
                || string.IsNullOrEmpty(this.prdPeriodo.Data_Termino_SQL)))
                sMsg += "   - A data de emissão tem que ser preenchida.\r\n";

            if (this.chkEmpresa.Checked && this.cboEmpresa.SelectedIndex < 0)
                sMsg += "   - A empresa tem que ser selecionada.\r\n";

            if (this.chkTipoDocumento.Checked && this.cboTipoDocumento.SelectedIndex < 0)
                sMsg += "   - O tipo de documento para impressão tem que ser selecionado.\r\n";

            if (this.chkPedido.Checked && string.IsNullOrEmpty(this.txtPedido.Text))
                sMsg += "   - O número do pedido tem que ser preenchido.\r\n";

            if (!string.IsNullOrEmpty(sMsg))
            {
                sMsg = "ERRO AO PESQUISAR NOTAS FISCAIS / CUPOM\r\n\r\n" + sMsg;
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
            if (e.ColumnIndex == 0 || e.ColumnIndex == 2 || e.ColumnIndex == 4 || e.ColumnIndex == 8)
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
            DataView dv = new DataView((DataTable)this.grdItens.BindingSource.DataSource, "sel = 1", "", DataViewRowState.CurrentRows);
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
                    , "Impressão de NF / Copom"
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
                        enf.Imprimir_NF(Convert.ToInt32(row["Nota_Fiscal"]), (bool)row["gera_nf"], !bPreview);

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
            this.chkTipoDocumento_CheckedChanged(sender, new EventArgs());
            this.chkPedido_CheckedChanged(sender, new EventArgs());
            this.chkEmpresa_CheckedChanged(sender, new EventArgs());
            this.chkData_CheckedChanged(sender, new EventArgs());
        }

        private void chkTipoDocumento_CheckedChanged(object sender, EventArgs e)
        {
            this.cboTipoDocumento.Enabled = this.chkTipoDocumento.Checked;
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

        private void grdItens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grdItens.BindingSource.Position >= 0)
            {
                string sQuery = null;
                //-- Encontra linha atual selecionada.
                DataRowView row = (DataRowView)this.grdItens.CurrentRow;

                switch (e.ColumnIndex)
                {
                    case 2: //-- número nf
                        sQuery = "update Notas_Fiscais set Numero_nota = {0} where Nota_fiscal = {1}";
                        sQuery = string.Format(sQuery
                                , this.grdItens.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                                , row["Nota_Fiscal"]);

                        SQL.Execute(sQuery);
                        break;

                    case 4: //-- Data emissão.
                        sQuery = "update Notas_Fiscais set data_Emissao = '{0}' where Nota_fiscal = {1}";
                        DateTime dt = Convert.ToDateTime(this.grdItens.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        string sData = dt.Year.ToString()
                                        + dt.Month.ToString().PadLeft(2, Convert.ToChar("0"))
                                        + dt.Day.ToString().PadLeft(2, Convert.ToChar("0"));

                        sQuery = string.Format(sQuery
                                , sData
                                , row["Nota_Fiscal"]);

                        SQL.Execute(sQuery);
                        break;

                    case 8:
                        sQuery = "update Notas_Fiscais set Observacao = '{0}' where Nota_fiscal = {1}";
                        sQuery = string.Format(sQuery
                                , this.grdItens.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                                , row["Nota_Fiscal"]);

                        SQL.Execute(sQuery);
                        break;
                }
            }
        }

        private void grdItens_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            switch (e.Context)
            {
                case DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.CurrentCellChange:
                    MsgBox.Show("Valor digitado na celula é muito grande ou incompativel com o banco de dados, tente novamente."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Stop);

                    break;
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
    }
}