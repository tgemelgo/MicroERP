using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CompSoft.cf_Bases.cf_DataGridView
{
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.DateTimePicker))]
    public class cf_DataGridViewDatePikerColumn : DataGridViewColumn
    {
        public cf_DataGridViewDatePikerColumn() : base(new cf_DataGridViewDatePikerCell())
        {
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if ((value != null) && !(value is cf_DataGridViewDatePikerCell))
                {
                    throw new InvalidCastException("Não é o combo.");
                }

                base.CellTemplate = value;
            }
        }

        private cf_DataGridViewDatePikerCell ComboCellTemplate
        {
            get { return (cf_DataGridViewDatePikerCell)CellTemplate; }
        }
    }
}