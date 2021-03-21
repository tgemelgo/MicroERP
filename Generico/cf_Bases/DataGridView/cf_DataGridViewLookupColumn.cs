using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases.cf_DataGridView
{
    /// <summary>
    /// Lookup Column DataGridView
    /// </summary>
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.TextBox))]
    public class cf_DataGridViewLookupColumn : DataGridViewColumn
    {
        private static Type columnType = typeof(cf_DataGridViewLookupColumn);
        private string sSQLStatement;
        private string sReturnColumn;
        private System.Data.DataRow dtLookUp_Retorno = null;

        #region Constructors

        /// <summary>
        /// Standard constructor without arguments
        /// </summary>
        public cf_DataGridViewLookupColumn() : this(String.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Construtor com os parametros para preenchimento do Lookup
        /// </summary>
        /// <param name="_SQLStatement">SQLStatement para preenchimento do lookup</param>
        /// <param name="_ReturnColumn">Nome da Coluna de retorno do DataTable</param>
        public cf_DataGridViewLookupColumn(string _SQLStatement, string _ReturnColumn) : base(new cf_DataGridViewLookupCell())
        {
            sSQLStatement = _SQLStatement;
            sReturnColumn = _ReturnColumn;
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
            cf_DataGridViewLookupColumn col = (cf_DataGridViewLookupColumn)base.Clone();
            col.SQLStatement = this.SQLStatement;
            col.ReturnColumn = this.ReturnColumn;
            col.CellTemplate = (cf_DataGridViewLookupCell)this.CellTemplate.Clone();
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
                if ((value != null) && !(value is cf_DataGridViewLookupCell))
                {
                    throw new InvalidCastException("Não é Lookup");
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

        private cf_DataGridViewLookupCell LookupCellTemplate
        {
            get { return (cf_DataGridViewLookupCell)CellTemplate; }
        }

        #endregion Derived properties

        #region Propriedades Lookup

        /// <summary>
        /// SQLStatement para preencimento do lookup
        /// </summary>
        [Category("CompSoft"), Description("SQLStatement para preencimento do lookup")]
        public string SQLStatement
        {
            get
            {
                if (LookupCellTemplate == null)
                {
                    throw new InvalidOperationException("CellTemplate NULL");
                }

                return LookupCellTemplate.SQLStatement;
            }
            set
            {
                if (sSQLStatement != value)
                {
                    // If the mask is changed, the cell template has to be changed,
                    // and each cell of the column has to be adapted.
                    LookupCellTemplate.SQLStatement = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            cf_DataGridViewLookupCell cell = rows.SharedRow(i).Cells[base.Index] as cf_DataGridViewLookupCell;
                            if (cell != null)
                            {
                                cell.SQLStatement = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// DataRow de retorno do lookup
        /// </summary>
        [Category("CompSoft"), Description("DataRow de retorno do lookup"), Browsable(false)]
        public System.Data.DataRow Retorno_Lookup
        {
            get
            {
                if (LookupCellTemplate == null)
                {
                    throw new InvalidOperationException("CellTemplate NULL");
                }

                return LookupCellTemplate.Retorno_Lookup;
            }
            set
            {
                if (dtLookUp_Retorno != value)
                {
                    // If the mask is changed, the cell template has to be changed,
                    // and each cell of the column has to be adapted.
                    LookupCellTemplate.Retorno_Lookup = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            cf_DataGridViewLookupCell cell = rows.SharedRow(i).Cells[base.Index] as cf_DataGridViewLookupCell;
                            if (cell != null)
                            {
                                cell.Retorno_Lookup = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Coluna de retorno do DataTable
        /// </summary>
        [Category("CompSoft"), Description("Coluna de retorno do DataTable")]
        public string ReturnColumn
        {
            get
            {
                if (LookupCellTemplate == null)
                {
                    throw new InvalidOperationException("CellTemplate NULL");
                }

                return LookupCellTemplate.ReturnColumn;
            }
            set
            {
                if (sReturnColumn != value)
                {
                    // If the mask is changed, the cell template has to be changed,
                    // and each cell of the column has to be adapted.
                    LookupCellTemplate.ReturnColumn = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            cf_DataGridViewLookupCell cell = rows.SharedRow(i).Cells[base.Index] as cf_DataGridViewLookupCell;
                            if (cell != null)
                            {
                                cell.ReturnColumn = value;
                            }
                        }
                    }
                }
            }
        }

        #endregion Propriedades Lookup
    }
}