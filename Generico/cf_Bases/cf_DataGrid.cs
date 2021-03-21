using CompSoft.compFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(DataGridView)), ToolboxItem(true)]
    public partial class cf_DataGrid : DataGridView
    {
        private string sFilter = string.Empty;
        private string sTabela_Grid = string.Empty;
        private BindingSource bSource;
        private FormSet f;
        private bool bAllowAlterAllStatusForm = false, bCancel = true;
        private bool bAllowEditRow = true;

        public cf_DataGrid()
        {
            InitializeComponent();
            this.AutoGenerateColumns = false;
        }

        private void Parametros_Visuais()
        {
            //-- Trata cores do grid
            this.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;
            this.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            this.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            this.DefaultCellStyle.SelectionForeColor = Color.White;
            this.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.Black;
            this.RowsDefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            this.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            this.RowsDefaultCellStyle.BackColor = Color.White;
            this.RowsDefaultCellStyle.ForeColor = Color.Black;

            //-- Trata propriedades do grid
            this.AllowUserToAddRows = false;
            this.AllowUserToResizeRows = true;
            this.AllowUserToResizeColumns = true;
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            this.ShowCellErrors = true;
            this.ShowCellToolTips = true;
            this.ShowEditingIcon = true;
            this.ShowRowErrors = true;
            this.VirtualMode = true;
            this.RowHeadersWidth = 24;

            //-- Trata Fontes do grid
            Font font = new Font(new FontFamily("Arial"), 8f, FontStyle.Regular);
            this.ColumnHeadersDefaultCellStyle.Font = font;
            this.Font = font;
            this.RowsDefaultCellStyle.Font = font;
            this.DefaultCellStyle.Font = font;
            this.AlternatingRowsDefaultCellStyle.Font = font;

            //-- Verifica se é permitido editar o grid.
            if (bAllowEditRow)
            {
                if (f != null)
                {
                    if (f.Tipo_Formulario == TipoForm.Geral)
                    {
                        this.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                        this.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    }
                    else
                    {
                        bAllowEditRow = false;
                        this.EditMode = DataGridViewEditMode.EditProgrammatically;
                        this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }
                }
                else
                {
                    bAllowEditRow = false;
                    this.EditMode = DataGridViewEditMode.EditProgrammatically;
                    this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            else
            {
                bAllowEditRow = false;
                this.EditMode = DataGridViewEditMode.EditProgrammatically;
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        #region Propriedades

        /// <summary>
        /// Ao navegar pelos registro o sistema deverá cancelar alterações caso tenha sido feitas.
        /// </summary>
        [Category("CompSoft")]
        public bool Cancel_OnClick
        {
            get { return bCancel; }
            set { bCancel = value; }
        }

        [Category("CompSoft"), Description("Permite edição no grid.")]
        public bool AllowEditRow
        {
            get { return bAllowEditRow; }
            set { bAllowEditRow = value; }
        }

        /// <summary>
        /// Retorna o Registro selecinado atualmente no grid.
        /// </summary>
        [Category("CompSoft"), Description("DataRowView da linha selecionada."), Browsable(false)]
        public new DataRowView CurrentRow
        {
            get
            {
                if (bSource.Position >= 0)
                    return (DataRowView)bSource.Current;
                else
                    return null;
            }
        }

        /// <summary>
        /// Tabela de trabalho do grid
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        internal string Tabela_GRID
        {
            get { return sTabela_Grid; }
        }

        /// <summary>
        /// Permite alterar valores em qualquer status do formulário.
        /// </summary>
        [Category("CompSoft")]
        public bool Allow_Alter_Value_All_StatusForm
        {
            get { return bAllowAlterAllStatusForm; }
            set { bAllowAlterAllStatusForm = value; }
        }

        /// <summary>
        /// BindingSource com a tabela atual.
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        public BindingSource BindingSource
        {
            get { return bSource; }
        }

        #endregion Propriedades

        #region Adiciona novo registro

        /// <summary>
        /// Adiciona novo registro no DataTable e posiciona a propriedade RegistroAtual para inclusão
        /// </summary>
        public virtual void AddNew()
        {
            bSource.AddNew();
        }

        #endregion Adiciona novo registro

        #region exclui registro

        /// <summary>
        /// Deleta a linha selecionada no DataGrid
        /// </summary>
        public virtual void Delete()
        {
            bSource.RemoveCurrent();
        }

        #endregion exclui registro

        #region Cancela Alterações

        /// <summary>
        /// Cancela ação atual do registro, no caso de novo registro ou alterações indesejadas.
        /// </summary>
        public virtual void Cancel()
        {
            bSource.CancelEdit();
        }

        #endregion Cancela Alterações

        #region Filtro de dados do grid

        /// <summary>
        /// Possibilita filtra o conteudo do grid.
        /// </summary>
        /// <param name="Condicao_Filtro">Condição de filtro.</param>
        public void Filtrar_Dados(string Condicao_Filtro)
        {
            bSource.Filter = Condicao_Filtro;
        }

        #endregion Filtro de dados do grid

        protected override void OnDataSourceChanged(EventArgs e)
        {
            if (bSource == null)
            {
                Funcoes func;
                if (func.Check_Extension(Propriedades.FormMain.ActiveMdiChild.GetType(), typeof(FormSet)))
                    f = (FormSet)Propriedades.FormMain.ActiveMdiChild;

                //-- Seta os parametros visuais do grid.
                this.Parametros_Visuais();

                if (this.DataSource.GetType() == typeof(DataTable) || this.DataSource.GetType() == typeof(DataView))
                {
                    switch (this.DataSource.GetType().Name)
                    {
                        case "DataTable":
                            sTabela_Grid = ((DataTable)this.DataSource).TableName.ToLower();
                            break;

                        case "DataView":
                            sTabela_Grid = ((DataView)this.DataSource).Table.TableName.ToLower();
                            break;
                    }

                    bSource = f.BindingSource[sTabela_Grid];
                    base.DataSource = bSource;
                }
                else if (this.DataSource.GetType() == typeof(BindingSource))
                {
                    bSource = this.DataSource as BindingSource;
                }

                base.OnDataSourceChanged(e);

                //-- Caso a auto geração de colunas estiver ativo
                //-- O sistema deverá retirar o _ das palavras.
                DataTable dt = ((DataTable)bSource.DataSource);
                foreach (DataGridViewColumn column in this.Columns)
                {
                    if (this.AutoGenerateColumns)
                    {
                        column.HeaderText = column.HeaderText.Replace("_", " ");
                    }
                    else
                    {
                        if (column.GetType() == typeof(DataGridViewTextBoxColumn))
                        {
                            DataGridViewTextBoxColumn cc = column as DataGridViewTextBoxColumn;
                            CompSoft.Data.ManipulaRegistros mr = new CompSoft.Data.ManipulaRegistros();
                            cc.MaxInputLength = mr.Captura_MaxCaracter(dt.Columns[column.DataPropertyName]);
                        }

                        if (column.GetType() == typeof(DataGridViewCheckBoxColumn))
                        {
                            DataGridViewCheckBoxColumn cc = column as DataGridViewCheckBoxColumn;
                            cc.FalseValue = false;
                            cc.IndeterminateValue = false;
                            cc.TrueValue = true;
                        }
                    }
                }
            }
            else
            {
                base.DataSource = bSource;
            }
        }

        private void cf_DataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                this.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch { }
        }

        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            if (bAllowEditRow)
            {
                if (f != null)
                {
                    if (!bAllowAlterAllStatusForm && (
                               f.FormStatus == CompSoft.TipoFormStatus.Novo
                            || f.FormStatus == CompSoft.TipoFormStatus.Modificando))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                if (this.EditMode == DataGridViewEditMode.EditProgrammatically)
                    e.Cancel = true;
            }

            base.OnCellBeginEdit(e);
        }

        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            displayErrorDialogIfNoHandler = false;
            e.Cancel = true;

            MsgBox.Show("Valor digitado na celula é incompativel com o banco de dados, tente novamente.\r\n\r\n" + e.Context.ToString()
                , "Atenção"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Stop);

            if (this.EditingControl != null)
                this.EditingControl.Focus();

            base.OnDataError(displayErrorDialogIfNoHandler, e);
        }
    }
}