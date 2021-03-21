using BoletoNet;
using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0077 : CompSoft.formBase
    {
        public f0077()
        {
            InitializeComponent();
            this.grdNotasFiscais.AutoGenerateColumns = false;
        }

        #region Localiza registro.

        private void Localizar_Registros()
        {
            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, pesquisando dados...");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("  0 as 'sel'");
            sb.AppendLine("  , case pe.gera_nf");
            sb.AppendLine("   when 1 then 'Nota Fiscal'");
            sb.AppendLine("   else 'Cupom'");
            sb.AppendLine("    end as 'Tipo_Documento'");
            sb.AppendLine("  , e.Razao_Social as 'Razao_Social_Cendente'");
            sb.AppendLine("  , cl.Razao_Social as 'Razao_Social_Cliente'");
            sb.AppendLine("  , nf.Numero_Nota");
            sb.AppendLine("  , nf.Data_Emissao");
            sb.AppendLine("  , nfd.Numero_Parcela");
            sb.AppendLine("  , nfd.Valor_Duplicata");
            sb.AppendLine("  , nfd.Data_Vencimento");
            sb.AppendLine("  , nfd.Nota_Fiscal_Duplicata");
            sb.AppendLine("  , coalesce(b.Boleto_Impresso, 0) as 'Boleto_Impresso'");
            sb.AppendLine("  , coalesce(b.ArquivoRemessao_Enviado, 0) as 'ArquivoRemessao_Enviado'");
            sb.AppendLine(" from notas_fiscais nf");
            sb.AppendLine("  inner join notas_fiscais_duplicatas nfd on nf.nota_fiscal = nfd.nota_fiscal");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine("  inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendLine("  inner join contas_correntes cc on cc.empresa = e.empresa");
            sb.AppendLine("  left outer join Boletos_gerados b on b.Nota_Fiscal_Duplicata = nfd.Nota_Fiscal_Duplicata");
            sb.AppendLine(" where nf.Cancelada = 0 and (coalesce(b.Boleto_Impresso, 0) = 0 or coalesce(b.ArquivoRemessao_Enviado, 0) = 0)");
            if (this.chkAtivarEmpresa.Checked && this.cboEmpresa.SelectedIndex >= 0)
                sb.AppendFormat("     AND e.empresa = {0}\r\n", this.cboEmpresa.SelectedValue);

            if (this.chkAtivarDataEmissao.Checked)
                sb.AppendFormat("       AND nfd.data_vencimento between '{0}' and '{1}'\r\n"
                        , this.prdDataEmissao.Data_Inicial_SQL
                        , this.prdDataEmissao.Data_Termino_SQL);

            if (!string.IsNullOrEmpty(this.txtNumeroNF.Text))
                sb.AppendFormat("     AND nf.numero_nota = {0}\r\n", this.txtNumeroNF.Text);

            if (!string.IsNullOrEmpty(this.txtNumeroPedido.Text))
                sb.AppendFormat("     AND pe.pedido = {0}\r\n", this.txtNumeroPedido.Text);

            DataTable dt = SQL.Select(sb.ToString(), "x", false);
            dt.Columns["sel"].ReadOnly = false;

            if (this.grdNotasFiscais.DataSource != null)
            {
                this.grdNotasFiscais.BindingSource.DataSource = dt;
            }
            else
            {
                BindingSource bs = new BindingSource(dt, null);
                this.grdNotasFiscais.DataSource = bs;
            }

            f.Close();
            f.Dispose();
        }

        #endregion Localiza registro.

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            this.Localizar_Registros();
            this.cmdGerar.Enabled = true;
        }

        private void chkAtivarEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            this.cboEmpresa.Enabled = this.chkAtivarEmpresa.Checked;
        }

        private void chkAtivarDataEmissao_CheckedChanged(object sender, EventArgs e)
        {
            this.prdDataEmissao.Enabled = this.chkAtivarDataEmissao.Checked;
        }

        private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow[] fRow = ((DataTable)this.grdNotasFiscais.BindingSource.DataSource).Select();
            foreach (DataRow row in fRow)
                row["sel"] = 1;

            this.grdNotasFiscais.BindingSource.EndEdit();
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (this.grdNotasFiscais.BindingSource == null || ((DataTable)this.grdNotasFiscais.BindingSource.DataSource).Select("Sel = 1").Length == 0)
                sb.AppendLine("   - Selecione as duplicatas que você deseja gerar os boletos.");

            if (!this.chkGerarRemessa.Checked && !this.chkImprimirBoleto.Checked)
            {
                sb.AppendLine("   - Selecione uma ou mais ações:");
                sb.AppendLine("       - Imprimir boletos;");
                sb.AppendLine("       - Gerar arquivo de remessa.");
            }

            if (this.chkGerarRemessa.Checked && string.IsNullOrEmpty(this.txtArquivoRemessa.Text))
                sb.AppendLine("   - Selecione a pasta onde o arquivo de remessa vai ser gerado.");

            if (sb.Length > 0)
            {
                sb.Insert(0, "ERRO AO GERAR/IMPRIMIR BOLETOS.\r\n\r\n");
                MsgBox.Show(sb.ToString()
                        , "Erro ao gerar boleto"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Asterisk);
            }
            else
            {
                List<int> ilDuplicatas = new List<int>();
                foreach (DataRow row in ((DataTable)this.grdNotasFiscais.BindingSource.DataSource).Select("sel=1"))
                {
                    ilDuplicatas.Add(Convert.ToInt32(row["Nota_Fiscal_Duplicata"]));
                }

                CNAB.CNAB cnab = new CNAB.CNAB();

                Dictionary<int, BoletoBancario> ilBB = cnab.Gerar_Boleto(ilDuplicatas);

                //-- Faz a impressão dos boletos...
                if (this.chkImprimirBoleto.Checked)
                {
                    DataTable dt = cnab.Gerar_Dados_Boleto(ilDuplicatas);
                    Dictionary<int, Image> ilLogoBanco = cnab.Localizar_Logos_Bancos(ilDuplicatas);

                    ERP.Reports.rBoleto r = new Reports.rBoleto(dt, ilBB, ilLogoBanco);
                    r.ShowPreviewDialog();
                }

                //-- Gera o arquivo de remessa
                if (this.chkGerarRemessa.Checked)
                {
                    int iNumeroLote = 0;
                    bool bArquivoGerado = cnab.Gerar_Arquivo_Remessa(ilBB, this.txtArquivoRemessa.Text, ref iNumeroLote);

                    if (bArquivoGerado)
                    {
                        MsgBox.Show("Arquivo de remessa gerado com sucesso."
                            , "Arquivo de remessa"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);

                        //-- Marca duplicatas como gerada.
                        foreach (int iNota_Fiscal_Duplicata in ilBB.Keys)
                        {
                            CNAB.CNAB.Grava_Arquivo_Remessa(iNota_Fiscal_Duplicata, iNumeroLote);
                        }
                    }
                    else
                    {
                        MsgBox.Show("Erro ao gerar arquivo de remessa."
                            , "Arquivo de remessa"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                    }
                }

                ((DataTable)this.grdNotasFiscais.BindingSource.DataSource).Clear();
                this.txtNumeroNF.Text = string.Empty;
                this.txtNumeroPedido.Text = string.Empty;
            }
        }

        private void grdNotasFiscais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                this.grdNotasFiscais.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void grdNotasFiscais_EditModeChanged(object sender, EventArgs e)
        {
            this.grdNotasFiscais.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void f0072_Load(object sender, EventArgs e)
        {
            CompSoft.compFrameWork.Impressoras imp;
            this.cboImpressora.DataSource = imp.Impressoras_Disponiveis();
            this.cboImpressora.DisplayMember = "a";
            this.cboImpressora.ValueMember = "b";

            this.cboImpressora.SelectedValue = imp.Impressora_Padrao;

            this.chkGerarRemessa_CheckedChanged(this, EventArgs.Empty);
        }

        private void cboImpressora_Leave(object sender, EventArgs e)
        {
            CompSoft.compFrameWork.Impressoras imp;
            imp.Impressora_Padrao = this.cboImpressora.SelectedValue.ToString();
        }

        private void chkGerarRemessa_CheckedChanged(object sender, EventArgs e)
        {
            this.txtArquivoRemessa.ReadOnly = true;
            if (!this.chkGerarRemessa.Checked)
            {
                this.txtArquivoRemessa.Text = string.Empty;
                this.txtArquivoRemessa.Visible = false;
                this.cmdDefinirArquivo.Visible = false;
            }
            else
            {
                this.txtArquivoRemessa.Visible = true;
                this.cmdDefinirArquivo.Visible = true;
            }
        }

        private void cmdDefinirArquivo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.RootFolder = Environment.SpecialFolder.MyComputer;
            f.ShowNewFolderButton = true;
            f.Description = "Pasta paga gerar o arquivo de remessa CNAB";

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtArquivoRemessa.Text = f.SelectedPath;
            }
            else
            {
                this.txtArquivoRemessa.Text = string.Empty;
            }
        }
    }
}