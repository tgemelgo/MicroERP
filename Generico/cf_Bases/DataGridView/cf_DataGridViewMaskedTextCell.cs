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
    internal class cf_DataGridViewMaskedTextCell : DataGridViewTextBoxCell
    {
        #region Fields

        private static Type cellType = typeof(cf_DataGridViewMaskedTextCell);
        private static Type valueType = typeof(string);
        private static Type editorType = typeof(cf_DataGridViewMaskedTextEditControl);

        #endregion Fields

        #region Constructor, Clone, ToString

        public cf_DataGridViewMaskedTextCell() : base()
        {
            Mask = String.Empty;
        }

        /// <summary>
        /// Creates a copy of a DGV-MaskedTextCell containing the DGV-Cell properties.
        /// </summary>
        /// <returns>Instance of a DGV-MaskedTextCell using the Mask string.</returns>
        public override object Clone()
        {
            cf_DataGridViewMaskedTextCell cell = base.Clone() as cf_DataGridViewMaskedTextCell;
            cell.Mask = this.Mask;
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
            builder.Append("DataGridViewMaskedTextCell { ColumnIndex=");
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

            cf_DataGridViewMaskedTextEditControl editingControl = dataGridView.EditingControl as cf_DataGridViewMaskedTextEditControl;
            if (editingControl != null)
            {
                editingControl.ClearUndo();
            }
            base.DetachEditingControl();
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            cf_DataGridViewMaskedTextEditControl editingControl = base.DataGridView.EditingControl as cf_DataGridViewMaskedTextEditControl;
            if (editingControl != null)
            {
                if (Value == null || Value is DBNull)
                    editingControl.Text = (string)DefaultNewRowValue;
                else
                    editingControl.Text = (string)Value;
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

        #region Additional Mask property

        private string mask;

        /// <summary>
        /// Input String that rules the possible input values in the current cell of the column.
        /// </summary>
        public string Mask
        {
            get { return mask == null ? String.Empty : mask; }
            set { mask = value; }
        }

        #endregion Additional Mask property
    }
}