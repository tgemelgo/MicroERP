using DevExpress.XtraReports.UI;
using System;

namespace ERP.Reports
{
    public partial class r0018 : CompSoft.Reports.ReportBase_Retrato
    {
        private decimal dFaturado = 0
            , dVista = 0;

        public r0018()
        {
            InitializeComponent();
        }

        private void lblTotalAvista_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = dVista.ToString("n2");
        }

        private void lblTotalFaturado_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = dFaturado.ToString("n2");
        }

        private void cf_Report_Label15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal dValorNota = Convert.ToDecimal(this.GetCurrentColumnValue("Valor_Total_Nota"));
            if (this.GetCurrentColumnValue("Parcelado").ToString() == "F")
                dFaturado += dValorNota;
            else
                dVista += dValorNota;
        }

        private void lblGrupoRelatorio_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sTitulo = string.Empty;

            if (Convert.ToBoolean(this.GetCurrentColumnValue("Cancelada")))
                sTitulo = "Notas Fiscais / Cupom - Cancelados";
            else
                sTitulo = "Notas Fiscais / Cupom - Efetivados";

            ((XRLabel)sender).Text = sTitulo;
        }
    }
}