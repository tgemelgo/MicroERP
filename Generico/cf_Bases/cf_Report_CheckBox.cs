using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    public partial class cf_Report_CheckBox : DevExpress.XtraReports.UI.XRCheckBox
    {
        private string sControlSource,
            sTabela,
            sFormatString;

        #region Propriedades

        [Category("CompSoft")]
        public string ControlSource
        {
            get { return sControlSource; }
            set { sControlSource = value; }
        }

        [Category("CompSoft")]
        public string Tabela
        {
            get
            {
                if (!string.IsNullOrEmpty(sTabela))
                    return sTabela.ToLower();
                else
                    return string.Empty;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    sTabela = value.ToLower();
                else
                    sTabela = value;
            }
        }

        [Category("CompSoft")]
        public string FormatString
        {
            get { return sFormatString; }
            set { sFormatString = value; }
        }

        #endregion Propriedades

        public cf_Report_CheckBox()
        {
            InitializeComponent();
        }
    }
}