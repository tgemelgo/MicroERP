using System.Data;

namespace ERP.Reports
{
    public partial class r0015 : CompSoft.Reports.ReportBase_Paisagem
    {
        public r0015()
        {
            InitializeComponent();
        }

        private void cf_Report_Label6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataRowView row = (DataRowView)this.GetCurrentRow();
            this.cf_Report_Label6.Text = string.Format("{0} - {1}", row["cfop"], row["desc_cfop"]);
        }
    }
}