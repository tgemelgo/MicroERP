using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0072 : CompSoft.formBase
    {
        public f0072()
        {
            InitializeComponent();
            this.grdNotasFiscais.AutoGenerateColumns = false;
        }

        private void Localizar_Registros()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine("   0 as 'sel'");
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
            sb.AppendLine(" where e.nfe_ativar_recurso = 1");
            sb.AppendLine("     AND pe.gera_nf = 1");
            sb.AppendLine("     AND nf.Cancelada = 0");
            sb.AppendLine("     AND nf.exportacao_NFe = 0");
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

        /// <summary>
        /// Gera arquivos da NF-e
        /// </summary>
        private void Gerar_NFe()
        {
            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, separando notas fiscais para transferência da NF-e.", CompSoft.Tools.frmWait.Tipo_Imagem.Informacao);
            f.Show();

            IList<CompSoft.NFe.Dados_Arquivo_NFe> ilNotas_Fiscais = new List<CompSoft.NFe.Dados_Arquivo_NFe>();

            DataRow[] fRow = ((DataTable)this.grdNotasFiscais.BindingSource.DataSource).Select("Sel = 1");
            foreach (DataRow row in fRow)
                ilNotas_Fiscais.Add(new CompSoft.NFe.Dados_Arquivo_NFe(Convert.ToInt32(row["Nota_Fiscal"])));

            f.Close();

            //-- Envia a NF-e
            ERP.NFe.NFe nfe = new ERP.NFe.NFe();
            nfe.Enviar_NFe(ilNotas_Fiscais, this.txtPasta.Text);
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            this.Localizar_Registros();

            this.cmdGerar.Enabled = true;
            this.cmdLocalizarPasta.Enabled = true;
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

        private void cmdLocalizarPasta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;

            if (fb.ShowDialog() == DialogResult.OK)
                this.txtPasta.Text = fb.SelectedPath;
            else
                this.txtPasta.Text = string.Empty;
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(this.txtPasta.Text))
                sb.AppendLine("   - A pasta tem que ser selecionada para geração dos arquivos da NF-e.");
            else
            {
                if (!this.txtPasta.Text.EndsWith(@"\"))
                    this.txtPasta.Text += @"\";

                //-- Caso o diretório não exista o sistema vai cria-lo.
                if (!System.IO.Directory.Exists(this.txtPasta.Text))
                    System.IO.Directory.CreateDirectory(this.txtPasta.Text);
            }

            if (((DataTable)this.grdNotasFiscais.BindingSource.DataSource).Select("Sel = 1").Length == 0)
                sb.AppendLine("   - Selecione as notas fiscais que você deseja enviar para Secretária da Fazenda.");

            if (sb.Length > 0)
            {
                sb.Insert(0, "ERRO AO GERAR NOTA FISCAL ELETRÔNICA\r\n\r\n");
                MsgBox.Show(sb.ToString()
                        , "Erro ao gerar NF-e"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Asterisk);
            }
            else
            {
                this.Gerar_NFe();
                ((DataTable)this.grdNotasFiscais.BindingSource.DataSource).Clear();
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
        }

        private void cboImpressora_Leave(object sender, EventArgs e)
        {
            CompSoft.compFrameWork.Impressoras imp;
            imp.Impressora_Padrao = this.cboImpressora.SelectedValue.ToString();
        }
    }
}