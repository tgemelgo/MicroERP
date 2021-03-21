using CompSoft.compFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Tools
{
    public partial class frmAdvancedSearch : CompSoft.FormSet
    {
        private string sQuery_SQL = string.Empty;
        private string sPrimary_Key = string.Empty;

        #region Propriedades

        public string Query_Padrao
        {
            get { return sQuery_SQL; }
            set { sQuery_SQL = value; }
        }

        public string PrimaryKey
        {
            get { return sPrimary_Key; }
            set { sPrimary_Key = value; }
        }

        #endregion Propriedades

        public frmAdvancedSearch()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!string.IsNullOrEmpty(Propriedades.StringConexao))
            {
                this.Tabelas.Add(new Data.Controle_Tabelas(Data.Controle_Tabelas.TiposTabelas.Pai
                    , this.MainTabela
                    , sQuery_SQL
                    , sPrimary_Key));
            }

            base.OnLoad(e);

            this.Size = new Size(this.Width, 282);
            this.grdResultado.Visible = false;
            this.grdResultado.AutoGenerateColumns = true;
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.DataSetLocal.AcceptChanges();

            this.DialogResult = DialogResult.OK;
        }

        private void cmdNovaBusca_Click(object sender, EventArgs e)
        {
            this.Limpar();
            this.Size = new Size(this.Width, 282);
            this.grdResultado.Visible = false;
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {
            if (this.PesquisarDados())
            {
                this.Size = new Size(this.Width, 535);
                this.grdResultado.Visible = true;
            }
        }

        private void frmAdvancedSearch_user_AfterRefreshData()
        {
            if (!string.IsNullOrEmpty(Propriedades.StringConexao) && this.DataSetLocal.Tables.Count > 0)
            {
                this.DataSetLocal.Tables[this.MainTabela].Columns[0].ReadOnly = false;
                this.grdResultado.DataSource = this.BindingSource[this.MainTabela];
                this.grdResultado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.grdResultado.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void frmAdvancedSearch_user_FormStatus_Change()
        {
            this.Text = "Filtro avançado";
        }

        private void frmAdvancedSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormSet f = ((FormSet)Propriedades.FormMain.ActiveMdiChild);
            Funcoes func;
            func.TratarStatus_BarraFerramentas(f.FormStatus, f.Tipo_Formulario);
            f.Movimentar_Registro(Movimento.Atualizar_Atual);
        }

        private void cmdVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void grdResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(0))
            {
                this.grdResultado.EditMode = DataGridViewEditMode.EditOnEnter;
            }
        }

        private void grdResultado_EditModeChanged(object sender, EventArgs e)
        {
            this.grdResultado.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }
}