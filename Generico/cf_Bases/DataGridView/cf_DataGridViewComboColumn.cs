using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CompSoft.cf_Bases.cf_DataGridView
{
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.ComboBox))]
    public class cf_DataGridViewComboColumn : DataGridViewColumn
    {
        public cf_DataGridViewComboColumn() : base(new cf_DataGridViewComboCell())
        {
        }

        public override object Clone()
        {
            cf_DataGridViewComboColumn col = (cf_DataGridViewComboColumn)base.Clone();
            col.SQLStatement = this.SQLStatement;
            col.CellTemplate = (cf_DataGridViewComboCell)this.CellTemplate.Clone();
            return col;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if ((value != null) && !(value is cf_DataGridViewComboCell))
                {
                    throw new InvalidCastException("Não é o combo.");
                }

                base.CellTemplate = value;
            }
        }

        private cf_DataGridViewComboCell ComboCellTemplate
        {
            get { return (cf_DataGridViewComboCell)CellTemplate; }
        }

        /// <summary>
        /// Query para montar combo 1º Coluna Valor 2º Coluna Display
        /// </summary>
        [Category("CompSoft"), Description("Query para montar combo 1º Coluna Valor 2º Coluna Display")]
        public string SQLStatement
        {
            get
            {
                if (ComboCellTemplate == null)
                {
                    throw new InvalidOperationException("DataGridViewColumn: CellTemplate required");
                }
                return ComboCellTemplate.SQLStatement;
            }
            set
            {
                if (this.SQLStatement != value)
                {
                    // If the mask is changed, the cell template has to be changed,
                    // and each cell of the column has to be adapted.
                    ComboCellTemplate.SQLStatement = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            cf_DataGridViewComboCell cell = rows.SharedRow(i).Cells[base.Index] as cf_DataGridViewComboCell;
                            if (cell != null)
                            {
                                cell.SQLStatement = value;
                            }
                        }
                    }
                }
            }
        }
    }
}