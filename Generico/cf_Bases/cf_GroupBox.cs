using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(GroupBox)), ToolboxItem(true)]
    public partial class cf_GroupBox : GroupBox
    {
        private string sControlSource = string.Empty;
        private string sTabela = string.Empty;
        private string sValue = string.Empty;

        #region Propriedades

        public string ControlSource
        {
            get { return sControlSource; }
            set { sControlSource = value; }
        }

        public string Tabela
        {
            get { return sTabela.ToLower(); }
            set
            {
                if (value != null)
                    sTabela = value.ToLower();
                else
                    sTabela = value;
            }
        }

        public string Value
        {
            get { return sValue; }
            set { sValue = value; }
        }

        #endregion Propriedades

        public cf_GroupBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }
    }
}