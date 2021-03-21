using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0069 : CompSoft.formBase
    {
        public f0069()
        {
            InitializeComponent();
        }

        private void Localizar_Registros()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine(" 0 as 'sel'");
            sb.AppendLine(" , e.Razao_Social as 'Nome_Empresa'");
            sb.AppendLine(" , cl.razao_Social as 'Nome_Cliente'");
            sb.AppendLine(" , nf.Numero_Nota");
            sb.AppendLine(" , nf.Pedido");
            sb.AppendLine(" , nf.data_emissao");
            sb.AppendLine(" , nf.nota_Fiscal");
            sb.AppendLine(" from notas_fiscais nf");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendLine(" where e.nfp_ativar_recurso = 1 and pe.gera_nf = 1 and nf.exportacao_NFp = 0");
            sb.AppendLine("     and ((nf.cancelada = 1 and nf.exportacao_NFp = 1) or (nf.cancelada = 0))");
            if (this.chkAtivarEmpresa.Checked && this.cboEmpresa.SelectedIndex >= 0)
                sb.AppendFormat("     AND e.empresa = {0}\r\n", this.cboEmpresa.SelectedValue);

            if (this.chkAtivarDataEmissao.Checked)
                sb.AppendFormat("       AND nf.data_emissao between '{0}' and '{1}'\r\n"
                        , this.prdDataEmissao.Data_Inicial_SQL
                        , this.prdDataEmissao.Data_Termino_SQL);

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
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            this.Localizar_Registros();

            this.cmdGerar.Enabled = true;
            this.cmdLocalizarPasta.Enabled = true;
        }

        private void chkAtivarEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAtivarEmpresa.Checked)
            {
                this.cboEmpresa.Enabled = true;
            }
            else
            {
                this.cboEmpresa.Enabled = false;
                this.cboEmpresa.SelectedIndex = -1;
            }
        }

        private void chkAtivarDataEmissao_CheckedChanged(object sender, EventArgs e)
        {
            this.prdDataEmissao.Enabled = this.chkAtivarDataEmissao.Checked;
        }

        private void cmdLocalizarPasta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Pasta para armazenamento das Nota Fiscal Paulista";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)
                this.txtPasta.Text = fbd.SelectedPath;
            else
                this.txtPasta.Text = string.Empty;
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(this.txtPasta.Text))
                sb.AppendLine("   - A pasta para salvar o arquivo TXT tem que ser selecionada.");

            DataView dv = new DataView((DataTable)this.grdNotasFiscais.BindingSource.DataSource);
            dv.RowFilter = "sel = 1";
            if (dv.Count == 0)
                sb.AppendLine("   - Selecione as Notas fiscais que deverão ser exportadas.");

            if (sb.Length > 0)
                MsgBox.Show("ERRO AO GERAR ARQUIVO\r\n\r\n" + sb.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                IList<int> ilNF = new List<int>();
                foreach (DataRowView row in dv)
                    ilNF.Add(Convert.ToInt32(row["Nota_fiscal"]));

                DialogResult dr = MsgBox.Show(string.Format("Deseja gerar o arquivo de Nota Fiscal Paulista para ({0}) Nota(s) Fiscai(s) selecionada(s)?", ilNF.Count)
                        , "Nota Fiscal Paulista"
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    ERP.NFPaulista.GerarDadosNFPaulista g = new ERP.NFPaulista.GerarDadosNFPaulista(this.txtPasta.Text);
                    g.Gerar_Dados_NFe(ilNF);

                    ((DataTable)this.grdNotasFiscais.BindingSource.DataSource).Clear();
                    this.lblPasta.Visible = false;
                    this.txtPasta.Visible = false;
                    this.cmdLocalizarPasta.Visible = false;
                    this.txtPasta.ReadOnly = true;
                    this.cmdGerar.Visible = false;
                }
            }
        }

        private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow[] fRow = ((DataTable)this.grdNotasFiscais.BindingSource.DataSource).Select();
            foreach (DataRow row in fRow)
            {
                row["sel"] = 1;
            }
            this.grdNotasFiscais.BindingSource.EndEdit();
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

        private void f0069_Load(object sender, EventArgs e)
        {
            this.cmdGerar.Enabled = false;
            this.cmdGerar.Enabled = false;
            this.cmdLocalizarPasta.Enabled = false;
            this.txtPasta.ReadOnly = true;
            this.grdNotasFiscais.AutoGenerateColumns = false;

            this.chkAtivarDataEmissao_CheckedChanged(this, new EventArgs());
            this.chkAtivarEmpresa_CheckedChanged(this, new EventArgs());
        }
    }
}