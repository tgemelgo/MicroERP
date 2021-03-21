using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases.cf_DataGridView
{
    /// <summary>
    /// DataGridViewMaskedTextColumn hosts a DGV-MaskedTextCell collection
    /// containing a Mask property.
    /// </summary>
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.MaskedTextBox))]
    public class cf_DataGridViewMaskedTextColumn : DataGridViewColumn
    {
        private static Type columnType = typeof(cf_DataGridViewMaskedTextColumn);

        #region Constructors

        /// <summary>
        /// Standard constructor without arguments
        /// </summary>
        public cf_DataGridViewMaskedTextColumn() : this(String.Empty)
        {
        }

        /// <summary>
        /// Constructor using a Mask string
        /// </summary>
        /// <param name="maskString">Mask string used in the EditingControl</param>
        public cf_DataGridViewMaskedTextColumn(string maskString) : base(new cf_DataGridViewMaskedTextCell())
        {
            Mask = maskString;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Converting the current DGV-MaskedTextColumn instance to a string value.
        /// </summary>
        /// <returns>String value of the instance containing the name
        /// and column index.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x40);
            builder.Append("DataGridViewMaskedTextColumn { Name=");
            builder.Append(base.Name);
            builder.Append(", Index=");
            builder.Append(base.Index.ToString());
            builder.Append(" }");
            return builder.ToString();
        }

        /// <summary>
        /// Creates a copy of a DGV-MaskedTextColumn containing the DGV-Column properties.
        /// </summary>
        /// <returns>Instance of a DGV-MaskedTextColumn using the Mask string.</returns>
        public override object Clone()
        {
            cf_DataGridViewMaskedTextColumn col = (cf_DataGridViewMaskedTextColumn)base.Clone();
            col.Mask = Mask;
            col.CellTemplate = (cf_DataGridViewMaskedTextCell)this.CellTemplate.Clone();
            return col;
        }

        #endregion Methods

        #region Derived properties

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if ((value != null) && !(value is cf_DataGridViewMaskedTextCell))
                {
                    throw new InvalidCastException("Não é Masked");
                }
                base.CellTemplate = value;
            }
        }

        [DefaultValue(1)]
        public new DataGridViewColumnSortMode SortMode
        {
            get { return base.SortMode; }
            set { base.SortMode = value; }
        }

        private cf_DataGridViewMaskedTextCell MaskedTextCellTemplate
        {
            get { return (cf_DataGridViewMaskedTextCell)CellTemplate; }
        }

        #endregion Derived properties

        #region Mask property

        /// <summary>
        /// Input String that rules the possible input values in each cell of the column.
        /// </summary>
        [Category("CompSoft")]
        public string Mask
        {
            get
            {
                if (MaskedTextCellTemplate == null)
                {
                    throw new InvalidOperationException("CellTemplate NULL");
                }

                return MaskedTextCellTemplate.Mask;
            }
            set
            {
                if (Mask != value)
                {
                    // If the mask is changed, the cell template has to be changed,
                    // and each cell of the column has to be adapted.
                    MaskedTextCellTemplate.Mask = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            cf_DataGridViewMaskedTextCell cell = rows.SharedRow(i).Cells[base.Index] as cf_DataGridViewMaskedTextCell;
                            if (cell != null)
                            {
                                cell.Mask = value;
                            }
                        }
                    }
                }
            }
        }

        #endregion Mask property
    }
}