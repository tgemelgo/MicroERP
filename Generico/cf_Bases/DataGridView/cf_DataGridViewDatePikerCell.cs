using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CompSoft.cf_Bases.cf_DataGridView
{
    internal class cf_DataGridViewDatePikerCell : DataGridViewTextBoxCell
    {
        private cf_DataGridViewDatePikerEditControl _DatePiker;

        public cf_DataGridViewDatePikerCell() : base()
        {
        }

        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.ComponentModel.TypeConverter valueTypeConverter)
        {
            object oValor = null;
            if (formattedValue != null && formattedValue != DBNull.Value)
            {
                oValor = formattedValue;
            }
            else
                oValor = DBNull.Value;

            return oValor;
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            _DatePiker = DataGridView.EditingControl as cf_DataGridViewDatePikerEditControl;

            if (_DatePiker != null)
            {
                if (string.IsNullOrEmpty(initialFormattedValue.ToString()) || (initialFormattedValue == null && initialFormattedValue == DBNull.Value))
                    _DatePiker.EditValue = DefaultNewRowValue;
                else
                    _DatePiker.EditValue = Convert.ToDateTime(initialFormattedValue);
            }
        }

        public override Type EditType
        {
            get { return typeof(cf_DataGridViewDatePikerEditControl); }
        }

        public override Type ValueType
        {
            get { return typeof(object); }
        }

        public override object DefaultNewRowValue
        {
            get { return null; }
        }
    }
}