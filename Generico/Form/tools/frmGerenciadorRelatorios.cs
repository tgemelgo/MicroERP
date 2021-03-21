using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Tools
{
    public partial class frmGerenciadorRelatorios : CompSoft.formBase
    {
        private string sNamespace = string.Empty,
            sRelatorio = string.Empty,
            sNomeRelatorio = string.Empty;

        public frmGerenciadorRelatorios()
        {
            InitializeComponent();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Alimenta_Lista_Relatorios()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select mir.Menu_Item_Relatorio, mir.Nome_Relatorio, mir.NameSpace, mir.Relatorio, mir.Descricao_Relatorio, mir.TodosReg_Enable, mir.RegAtual_Enable, mir.Value_Enable");
            sb.Append(" from menus_itens_relatorios mir");
            sb.Append("  inner join Menus_Itens mi on mi.Menu_item = mir.Menu_Item");
            sb.Append(" where");
            sb.AppendFormat("      mi.formulario = '{0}'", Propriedades.FormMain.ActiveMdiChild.Name);
            sb.Append("  and mir.Ativo = 1");
            DataRow[] fRow = SQL.Select(sb.ToString(), "xTemp", false).Select("", "Nome_Relatorio asc");

            foreach (DataRow row in fRow)
            {
                cf_Bases.cf_ImageListBoxItem li = new CompSoft.cf_Bases.cf_ImageListBoxItem();

                li.Id_Relatorio = Convert.ToInt32(row["Menu_Item_Relatorio"]);
                li.Descricao = row["Descricao_Relatorio"].ToString();
                li.NameSpace = row["NameSpace"].ToString();
                li.Relatorio = row["Relatorio"].ToString();
                li.Value = row["Nome_Relatorio"].ToString();

                li.Todos_Reg = (bool)row["TodosReg_Enable"];
                li.Reg_Atual = (bool)row["RegAtual_Enable"];
                li.Tipo_Selecionado = Convert.ToInt32(row["Value_Enable"]);

                li.ImageIndex = 0;

                this.lstRelatorio.Items.Add(li);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            // base.OnLoad(e);
            this.lblDescricaoRelatorio.Text = string.Empty;

            //-- Alimenta os relatorios disponiveis para o formulário aberto.
            this.Alimenta_Lista_Relatorios();
        }

        private void Abrir_Report()
        {
            if (this.lstRelatorio.SelectedIndex >= 0)
            {
                try
                {
                    bool bRegistroAtual = true;

                    if (!this.optRegistroAtual.Checked)
                        bRegistroAtual = false;

                    Assembly obj1;
                    Reports.ReportBase obj2;

                    obj1 = Assembly.LoadFrom(Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost.", "."));
                    obj2 = (Reports.ReportBase)obj1.CreateInstance(sNamespace + "." + sRelatorio);
                    obj2.Nome_Relatorio = sNomeRelatorio;
                    obj2.Descricao_Relatorio = sNomeRelatorio;
                    obj2.Imprimi_Registro_Atual = bRegistroAtual;
                    obj2.ShowPreview();
                }
                catch (Exception ex)
                {
                    MsgBox.Show(string.Format("Não foi possivel abrir o relatório selecionado [{0}].\n" + ex.Message, this.sRelatorio.ToString())
                        , "Aviso"
                        , System.Windows.Forms.MessageBoxButtons.OK
                        , System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            else
                MsgBox.Show("Selecione um relatório para preview", "Impressão", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void lstRelatorios_DoubleClick(object sender, EventArgs e)
        {
            this.Abrir_Report();
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            this.Abrir_Report();
        }

        private void lstRelatorio_SelectedValueChanged(object sender, EventArgs e)
        {
            cf_Bases.cf_ImageListBoxItem li = (cf_Bases.cf_ImageListBoxItem)this.lstRelatorio.Items[this.lstRelatorio.SelectedIndex];
            this.lblDescricaoRelatorio.Text = li.Descricao;
            sRelatorio = li.Relatorio;
            sNamespace = li.NameSpace;
            sNomeRelatorio = li.Value.ToString();

            this.optRegistroAtual.Enabled = li.Reg_Atual;
            this.optTodosRegistros.Enabled = li.Todos_Reg;

            switch (li.Tipo_Selecionado)
            {
                case 1:
                    this.optRegistroAtual.Checked = true;
                    this.optTodosRegistros.Checked = false;
                    break;

                case 2:
                    this.optRegistroAtual.Checked = false;
                    this.optTodosRegistros.Checked = true;
                    break;
            }
        }

        private void frmGerenciadorRelatorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
                this.Close();
        }
    }
}