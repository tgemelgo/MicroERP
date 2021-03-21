#region Usings

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion Usings

namespace CompSoft.cf_Bases.cf_DataGridView
{
    /// <summary>
    /// DataGridViewMaskedTextEditingControl is the MaskedTextBox that is hosted
    /// in a DataGridViewMaskedTextColumn.
    /// </summary>
    internal class cf_DataGridViewMaskedTextEditControl : MaskedTextBox, IDataGridViewEditingControl
    {
        #region Fields

        private DataGridView dataGridView;
        private bool valueChanged;
        private int rowIndex;

        #endregion Fields

        #region Constructor

        public cf_DataGridViewMaskedTextEditControl()
        {
            Mask = String.Empty;
            this.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            this.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            base.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            base.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        #endregion Constructor

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
            cf_DataGridViewMaskedTextCell cell = dataGridView.CurrentCell as cf_DataGridViewMaskedTextCell;
            if (cell != null)
            {
                Mask = cell.Mask;
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
            if (selectAll)
                SelectAll();
        }

        #endregion Interface's methods

        #region MaskedTextBox event

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

        #endregion MaskedTextBox event
    }
}