using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    public partial class cf_Report_Label : DevExpress.XtraReports.UI.XRLabel
    {
        private string sControlSource,
            sTabela,
            sFormatString;

        private Tipos_Controles tp_Controle = Tipos_Controles.Default_Text;

        public enum Tipos_Controles
        {
            Default_Text,
            Custom_Format,
            Format
        }

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
            get { return string.IsNullOrEmpty(sTabela) ? string.Empty : sTabela.ToLower(); }
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

        [Category("CompSoft")]
        public Tipos_Controles Tipo_Controle
        {
            get { return tp_Controle; }
            set { tp_Controle = value; }
        }

        #endregion Propriedades

        public cf_Report_Label()
        {
            InitializeComponent();
        }

        protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
        {
            base.OnBeforePrint(e);
            try
            {
                if (!string.IsNullOrEmpty(this.Text) && !string.IsNullOrEmpty(sFormatString) && tp_Controle != Tipos_Controles.Default_Text)
                {
                    switch (this.tp_Controle)
                    {
                        case Tipos_Controles.Custom_Format:
                            try
                            {
                                this.Text = string.Format(sFormatString, Convert.ToDecimal(this.Text));
                            }
                            catch { }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}