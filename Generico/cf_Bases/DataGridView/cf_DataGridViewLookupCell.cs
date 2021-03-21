#region Usings

using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

#endregion Usings

namespace CompSoft.cf_Bases.cf_DataGridView
{
    /// <summary>
    /// DataGridViewMaskedTextCell is derived from DGV-TextBoxCell using all TextBox
    /// properties and containing the Mask property to host a MaskedTextBox.
    /// </summary>
    internal class cf_DataGridViewLookupCell : DataGridViewTextBoxCell
    {
        private static Type cellType = typeof(cf_DataGridViewLookupCell);
        private static Type valueType = typeof(string);
        private static Type editorType = typeof(cf_DataGridViewLookupEditControl);
        private string sSQLStatement;
        private string sReturnColumn;
        private System.Data.DataRow dtLookUp_Retorno;

        #region Constructor, Clone, ToString

        public cf_DataGridViewLookupCell() : base()
        {
            sSQLStatement = string.Empty;
            sReturnColumn = string.Empty;
        }

        /// <summary>
        /// Query para consulta no banco de dados.
        /// </summary>
        public string SQLStatement
        {
            get { return sSQLStatement; }
            set { sSQLStatement = value; }
        }

        /// <summary>
        /// Nome da coluna do DataTable que será retornada para o campo selecionado.
        /// </summary>
        public string ReturnColumn
        {
            get { return sReturnColumn; }
            set { sReturnColumn = value; }
        }

        /// <summary>
        /// DataRow de retorno do lookup
        /// </summary>
        public System.Data.DataRow Retorno_Lookup
        {
            get { return dtLookUp_Retorno; }
            set { dtLookUp_Retorno = value; }
        }

        /// <summary>
        /// Creates a copy of a LookupCell containing the Cell properties.
        /// </summary>
        /// <returns>Instance of a LookupCell using the Mask string.</returns>
        public override object Clone()
        {
            cf_DataGridViewLookupCell cell = base.Clone() as cf_DataGridViewLookupCell;
            cell.SQLStatement = this.SQLStatement;
            cell.ReturnColumn = this.ReturnColumn;
            return cell;
        }

        /// <summary>
        /// Converting the current DGV-MaskedTextCell instance to a string value.
        /// </summary>
        /// <returns>String value of the instance containing the type name,
        /// column index, and row index.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x40);
            builder.Append("DataGridViewLookupCell { ColumnIndex=");
            builder.Append(base.ColumnIndex.ToString());
            builder.Append(", RowIndex=");
            builder.Append(base.RowIndex.ToString());
            builder.Append(" }");
            return builder.ToString();
        }

        #endregion Constructor, Clone, ToString

        #region Derived methods

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override void DetachEditingControl()
        {
            DataGridView dataGridView = base.DataGridView;
            if ((dataGridView == null) || (dataGridView.EditingControl == null))
            {
                throw new InvalidOperationException();
            }

            cf_DataGridViewLookupEditControl editingControl = dataGridView.EditingControl as cf_DataGridViewLookupEditControl;
            if (editingControl != null)
            {
                editingControl.ClearUndo();
            }
            base.DetachEditingControl();
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            cf_DataGridViewLookupEditControl editingControl = base.DataGridView.EditingControl as cf_DataGridViewLookupEditControl;
            if (editingControl != null)
            {
                editingControl.SQLStatement = sSQLStatement;
                editingControl.ReturnColumn = sReturnColumn;

                if (Value == null || Value is DBNull)
                    editingControl.Text = (string)DefaultNewRowValue;
                else
                    editingControl.Text = Value.ToString();
            }
        }

        #endregion Derived methods

        #region Derived properties

        public override Type EditType
        {
            get { return editorType; }
        }

        public override Type ValueType
        {
            get { return valueType; }
        }

        #endregion Derived properties
    }
}