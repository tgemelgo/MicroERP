namespace ERP.Reports
{
    partial class r0010
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.cf_Report_Label8 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label4 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label3 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label2 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label6 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label7 = new CompSoft.cf_Bases.cf_Report_Label();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            // 
            // Detail
            // 
            this.Detail.Height = 0;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.PrintOnEmptyDataSource = false;
            // 
            // PageHeader
            // 
            this.PageHeader.ParentStyleUsing.UseFont = false;
            // 
            // PageFooter
            // 
            this.PageFooter.ParentStyleUsing.UseFont = false;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cf_Report_Label8,
            this.cf_Report_Label4,
            this.cf_Report_Label3,
            this.cf_Report_Label2});
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Produto", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Desc_Produto", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.Height = 25;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // cf_Report_Label8
            // 
            this.cf_Report_Label8.ControlSource = "Desc_Produto";
            this.cf_Report_Label8.FormatString = null;
            this.cf_Report_Label8.Location = new System.Drawing.Point(117, 0);
            this.cf_Report_Label8.Name = "cf_Report_Label8";
            this.cf_Report_Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label8.Size = new System.Drawing.Size(375, 25);
            this.cf_Report_Label8.Tabela = "Movimentos_Estoque";
            this.cf_Report_Label8.Text = "cf_Report_Label1";
            this.cf_Report_Label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label8.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label4
            // 
            this.cf_Report_Label4.ControlSource = "Qtde_Saida";
            this.cf_Report_Label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label4.FormatString = null;
            this.cf_Report_Label4.Location = new System.Drawing.Point(592, 0);
            this.cf_Report_Label4.Name = "cf_Report_Label4";
            this.cf_Report_Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label4.ParentStyleUsing.UseFont = false;
            this.cf_Report_Label4.Size = new System.Drawing.Size(83, 25);
            xrSummary1.FormatString = "{0:c}";
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.cf_Report_Label4.Summary = xrSummary1;
            this.cf_Report_Label4.Tabela = "Movimentos_Estoque";
            this.cf_Report_Label4.Text = "cf_Report_Label1";
            this.cf_Report_Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label4.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label3
            // 
            this.cf_Report_Label3.ControlSource = "Qtde_Entrada";
            this.cf_Report_Label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label3.FormatString = null;
            this.cf_Report_Label3.Location = new System.Drawing.Point(500, 0);
            this.cf_Report_Label3.Name = "cf_Report_Label3";
            this.cf_Report_Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label3.ParentStyleUsing.UseFont = false;
            this.cf_Report_Label3.Size = new System.Drawing.Size(83, 25);
            xrSummary2.FormatString = "{0:c}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.cf_Report_Label3.Summary = xrSummary2;
            this.cf_Report_Label3.Tabela = "Movimentos_Estoque";
            this.cf_Report_Label3.Text = "cf_Report_Label1";
            this.cf_Report_Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label3.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label2
            // 
            this.cf_Report_Label2.ControlSource = "Produto";
            this.cf_Report_Label2.FormatString = null;
            this.cf_Report_Label2.Location = new System.Drawing.Point(17, 0);
            this.cf_Report_Label2.Name = "cf_Report_Label2";
            this.cf_Report_Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label2.Size = new System.Drawing.Size(100, 25);
            this.cf_Report_Label2.Tabela = "Movimentos_Estoque";
            this.cf_Report_Label2.Text = "cf_Report_Label1";
            this.cf_Report_Label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cf_Report_Label2.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label6
            // 
            this.cf_Report_Label6.ControlSource = null;
            this.cf_Report_Label6.FormatString = null;
            this.cf_Report_Label6.Location = new System.Drawing.Point(500, 0);
            this.cf_Report_Label6.Name = "cf_Report_Label6";
            this.cf_Report_Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label6.Size = new System.Drawing.Size(84, 25);
            this.cf_Report_Label6.Tabela = null;
            this.cf_Report_Label6.Text = "Entrada";
            this.cf_Report_Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cf_Report_Label6.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label7
            // 
            this.cf_Report_Label7.ControlSource = null;
            this.cf_Report_Label7.FormatString = null;
            this.cf_Report_Label7.Location = new System.Drawing.Point(592, 0);
            this.cf_Report_Label7.Name = "cf_Report_Label7";
            this.cf_Report_Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label7.Size = new System.Drawing.Size(84, 25);
            this.cf_Report_Label7.Tabela = null;
            this.cf_Report_Label7.Text = "Saída";
            this.cf_Report_Label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cf_Report_Label7.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // xrLine2
            // 
            this.xrLine2.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.xrLine2.Location = new System.Drawing.Point(0, 0);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(783, 8);
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cf_Report_Label6,
            this.cf_Report_Label7});
            this.GroupHeader3.Height = 25;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2});
            this.GroupFooter2.Height = 15;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // r0010
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupFooter2});
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label2;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label4;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label3;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label7;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label6;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label8;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;

    }
}
