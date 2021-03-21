using CompSoft;
using CompSoft.compFrameWork;
using System;
using System.Data;
using System.Drawing;

namespace ERP.Reports
{
    public partial class r0012 : CompSoft.Reports.ReportBase_Retrato
    {
        public r0012()
        {
            InitializeComponent();

            this.DataMember = "Mes";
        }

        public override void Set_DataMember_DetailReports()
        {
            this.Report_DataSet.Tables.Remove("Fluxo");
            this.Report_DataSet.Tables.Remove("Semana");

            //-- Importa dados.
            if (Propriedades.FormMain != null && Propriedades.FormMain.ActiveMdiChild != null)
            {
                FormSet f = ((FormSet)Propriedades.FormMain.ActiveMdiChild);
                DataView dv = new DataView(f.DataSetLocal.Tables[this.DataMember], "", "Data", DataViewRowState.CurrentRows);
                this.Report_DataSet.Tables[this.DataMember].Merge(dv.ToTable(this.DataMember), false, MissingSchemaAction.AddWithKey);

                dv.Dispose();
            }
        }

        private void cf_Report_Label8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal dValor = Convert.ToDecimal(this.cf_Report_Label8.Text.Replace(".", "").Replace(",", "."));
            if (dValor < 0)
                this.cf_Report_Label8.ForeColor = Color.Red;
            else if (dValor > 0)
                this.cf_Report_Label8.ForeColor = Color.Blue;
        }
    }
}