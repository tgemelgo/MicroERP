using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CompSoft.cf_Bases.cf_DataGridView
{
    /// <summary>
    /// DataGridViewMaskedTextEditingControl is the MaskedTextBox that is hosted
    /// in a DataGridViewMaskedTextColumn.
    /// </summary>
    internal class cf_DataGridViewLookupEditControl : TextBox, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private bool valueChanged;
        private int rowIndex;
        private string sSQLStatement;
        private string sReturnColumn;
        private DataRow dtLookUp_Retorno;
        private DataTable dtLookup;

        #region Constructor

        public cf_DataGridViewLookupEditControl()
        {
            sSQLStatement = string.Empty;
            sReturnColumn = string.Empty;
        }

        #endregion Constructor

        #region Propriedades

        /// <summary>
        /// DataRow de retorno do lookup
        /// </summary>
        [Category("CompSoft"), Description("DataRow de retorno do lookup")]
        public DataRow Retorno_Lookup
        {
            get { return dtLookUp_Retorno; }
            set { dtLookUp_Retorno = value; }
        }

        /// <summary>
        /// Query para realização do lookup
        /// </summary>
        [Category("CompSoft"), Description("Query para realização do lookup")]
        public string SQLStatement
        {
            get { return sSQLStatement; }
            set { sSQLStatement = value; }
        }

        /// <summary>
        /// Coluna de Retorno do lookup para o controle
        /// </summary>
        [Category("CompSoft"), Description("Coluna de Retorno do lookup para o controle")]
        public string ReturnColumn
        {
            get { return sReturnColumn; }
            set { sReturnColumn = value; }
        }

        #endregion Propriedades

        #region Interface's properties

        public DataGridView EditingControlDataGridView
        {
            get { return dataGridView; }
            set { dataGridView = value; }
        }

        public object EditingControlFormattedValue
        {
            get { return Text; }
            set
            {
                if (value is string)
                    Text = (string)value;
            }
        }

        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        #endregion Interface's properties

        #region Interface's methods

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            // get the current cell to use the specific mask string
            cf_DataGridViewLookupCell cell = dataGridView.CurrentCell as cf_DataGridViewLookupCell;
            if (cell != null)
            {
                sSQLStatement = cell.SQLStatement;
                sReturnColumn = cell.ReturnColumn;
            }
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            //  Note: In a DataGridView, one could prefer to change the row using
            // the up/down keys.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                    return true;

                default:
                    return false;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            this.SelectAll();
        }

        #endregion Interface's methods

        #region LookUp

        /// <summary>
        /// Faz o lookup e retorna o registro localizado com o dado digitado no campo
        /// </summary>
        /// <param name="MostrarLOOK">bool indicando se o form com o conteudo será mostrado.</param>
        /// <returns></returns>
        public bool FazerLookUp(bool MostrarLOOK)
        {
            bool bRetorno = true;
            if (!string.IsNullOrEmpty(Propriedades.StringConexao) && !string.IsNullOrEmpty(sSQLStatement))
            {
                if (Propriedades.FormMain != null && Propriedades.FormMain.ActiveMdiChild != null)
                {
                    FormSet fForm = ((FormSet)Propriedades.FormMain.ActiveMdiChild);
                    if (fForm.FormStatus == TipoFormStatus.Novo || fForm.FormStatus == TipoFormStatus.Modificando)
                    {
                        if (MostrarLOOK || (!MostrarLOOK && !string.IsNullOrEmpty(this.Text)))
                        {
                            frmMostarLookUp f = new frmMostarLookUp(this.SQLStatement, this.Text, this.ReturnColumn);
                            int iTotalReg = f.CriarLookUp_Estrutura();
                            dtLookup = f.DataTable;

                            switch (iTotalReg)
                            {
                                case 0:
                                    bRetorno = false;
                                    dtLookUp_Retorno = null;
                                    break;

                                case 1:
                                    dtLookUp_Retorno = f.RegistroSelecionado;
                                    this.Text = f.ValorSelecionado;
                                    break;

                                default:
                                    if (MostrarLOOK)
                                    {
                                        if (f.ShowDialog() == DialogResult.OK)
                                        {
                                            if (!string.IsNullOrEmpty(f.ValorSelecionado))
                                            {
                                                this.dtLookUp_Retorno = f.RegistroSelecionado;
                                                this.Text = f.ValorSelecionado;
                                            }
                                            else
                                            {
                                                bRetorno = false;
                                            }
                                        }
                                        else
                                        {
                                            bRetorno = false;
                                        }
                                    }
                                    break;
                            }

                            f.Dispose();
                        }
                    }
                }
            }

            return bRetorno;
        }

        #endregion LookUp

        #region Lookup event

        protected override void OnValidating(CancelEventArgs e)
        {
            if (!this.FazerLookUp(false))
            {
                base.OnValidating(e);
                e.Cancel = true;
            }

            cf_DataGrid grid = dataGridView as cf_DataGrid;

            if (!string.IsNullOrEmpty(sSQLStatement))
            {
                //-- Varre todas as colunas da tabela do lookup.
                foreach (System.Data.DataColumn dc in dtLookup.Columns)
                {
                    //-- Verifica se a coluna da com o nome do look up existe no grid.
                    string sDataProperty = grid.Columns[grid.CurrentCell.ColumnIndex].DataPropertyName;
                    try
                    {
                        if (!dc.Caption.ToLower().Equals(sDataProperty.ToLower()) && grid.CurrentRow.Row.Table.Columns.Contains(dc.Caption))
                        {
                            if (dtLookUp_Retorno != null)
                                grid.CurrentRow[dc.Caption] = dtLookUp_Retorno[dc.Caption];
                            else
                                grid.CurrentRow[dc.Caption] = DBNull.Value;

                            this.EditingControlValueChanged = true;
                        }
                    }
                    catch { }
                }
            }

            grid.Refresh();
            this.NotifyDataGridViewOfValueChange();

            base.OnValidating(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
            {
                this.FazerLookUp(true);
            }
        }

        private void ValidarLookup()
        {
            if (!string.IsNullOrEmpty(Propriedades.StringConexao) && !string.IsNullOrEmpty(this.SQLStatement))
            {
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            EditingControlValueChanged = true;
            this.NotifyDataGridViewOfValueChange();
        }

        protected virtual void NotifyDataGridViewOfValueChange()
        {
            this.valueChanged = true;
            if (this.dataGridView != null)
            {
                this.dataGridView.NotifyCurrentCellDirty(true);
            }
        }

        #endregion Lookup event
    }
}