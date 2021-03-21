using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CompSoft.cf_Bases.cf_DataGridView
{
    internal class cf_DataGridViewComboCell : DataGridViewTextBoxCell
    {
        private cf_DataGridViewComboEditControl _ComboEdit;
        private string sSQLstatement;

        public string SQLStatement
        {
            get { return sSQLstatement; }
            set { sSQLstatement = value; }
        }

        public cf_DataGridViewComboCell() : base()
        {
            SQLStatement = string.Empty;
        }

        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.ComponentModel.TypeConverter valueTypeConverter)
        {
            return base.ParseFormattedValue(formattedValue.ToString(), cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }

        protected override bool SetValue(int rowIndex, object value)
        {
            if (value == null)
                value = DBNull.Value;

            return base.SetValue(rowIndex, value);
        }

        public override object Clone()
        {
            cf_DataGridViewComboCell cell = base.Clone() as cf_DataGridViewComboCell;
            cell.SQLStatement = this.SQLStatement;
            return cell;
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            _ComboEdit = DataGridView.EditingControl as cf_DataGridViewComboEditControl;

            if (_ComboEdit != null)
            {
                if (!string.IsNullOrEmpty(CompSoft.compFrameWork.Propriedades.StringConexao) && !string.IsNullOrEmpty(sSQLstatement))
                {
                    System.Data.DataTable dt = CompSoft.Data.SQL.Select(sSQLstatement, "x", false);

                    _ComboEdit.DropDownStyle = ComboBoxStyle.DropDownList;
                    _ComboEdit.DataSource = dt;
                    _ComboEdit.ValueMember = dt.Columns[0].Caption;
                    _ComboEdit.DisplayMember = dt.Columns[1].Caption;
                }

                if (this.Value == null && this.Value == DBNull.Value)
                    _ComboEdit.SelectedValue = DefaultNewRowValue;
                else
                    _ComboEdit.SelectedValue = Value;
            }
        }

        public override void DetachEditingControl()
        {
            base.DetachEditingControl();
            ((System.Data.DataTable)_ComboEdit.DataSource).Dispose();
        }

        public override Type EditType
        {
            get { return typeof(cf_DataGridViewComboEditControl); }
        }

        public override Type ValueType
        {
            get { return typeof(System.Object); }
        }

        public override object DefaultNewRowValue
        {
            get { return DBNull.Value; }
        }
    }
}