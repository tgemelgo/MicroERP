namespace CompSoft.Reports
{
    partial class ReportBase_Paisagem
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

            this.picLogoCliente.Image = null;
            this.picLogoEmpresa.Image = null;

            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportBase_Paisagem));
            this.lblNomeRelatorio = new CompSoft.cf_Bases.cf_Report_Label();
            this.picLogoCliente = new DevExpress.XtraReports.UI.XRPictureBox();
            this.lblNomeEmpresa = new CompSoft.cf_Bases.cf_Report_Label();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lblEnderecoEmpresa = new CompSoft.cf_Bases.cf_Report_Label();
            this.lblTelefone = new CompSoft.cf_Bases.cf_Report_Label();
            this.lblInternet = new CompSoft.cf_Bases.cf_Report_Label();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.picLogoEmpresa = new DevExpress.XtraReports.UI.XRPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            resources.ApplyResources(this.Detail, "Detail");
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.picLogoEmpresa,
            this.lblNomeRelatorio,
            this.xrLine1,
            this.lblNomeEmpresa,
            this.lblEnderecoEmpresa,
            this.lblTelefone,
            this.lblInternet,
            this.picLogoCliente});
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
            resources.ApplyResources(this.PageFooter, "PageFooter");
            // 
            // topMarginBand1
            // 
            resources.ApplyResources(this.topMarginBand1, "topMarginBand1");
            // 
            // bottomMarginBand1
            // 
            resources.ApplyResources(this.bottomMarginBand1, "bottomMarginBand1");
            // 
            // lblNomeRelatorio
            // 
            this.lblNomeRelatorio.ControlSource = null;
            resources.ApplyResources(this.lblNomeRelatorio, "lblNomeRelatorio");
            this.lblNomeRelatorio.FormatString = null;
            this.lblNomeRelatorio.Name = "lblNomeRelatorio";
            this.lblNomeRelatorio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNomeRelatorio.Tabela = "";
            this.lblNomeRelatorio.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // picLogoCliente
            // 
            resources.ApplyResources(this.picLogoCliente, "picLogoCliente");
            this.picLogoCliente.Name = "picLogoCliente";
            this.picLogoCliente.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // lblNomeEmpresa
            // 
            this.lblNomeEmpresa.ControlSource = null;
            resources.ApplyResources(this.lblNomeEmpresa, "lblNomeEmpresa");
            this.lblNomeEmpresa.FormatString = null;
            this.lblNomeEmpresa.Name = "lblNomeEmpresa";
            this.lblNomeEmpresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNomeEmpresa.Tabela = "";
            this.lblNomeEmpresa.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // xrPageInfo1
            // 
            resources.ApplyResources(this.xrPageInfo1, "xrPageInfo1");
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // xrPageInfo2
            // 
            resources.ApplyResources(this.xrPageInfo2, "xrPageInfo2");
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            // 
            // lblEnderecoEmpresa
            // 
            this.lblEnderecoEmpresa.ControlSource = null;
            this.lblEnderecoEmpresa.FormatString = null;
            resources.ApplyResources(this.lblEnderecoEmpresa, "lblEnderecoEmpresa");
            this.lblEnderecoEmpresa.Name = "lblEnderecoEmpresa";
            this.lblEnderecoEmpresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEnderecoEmpresa.Tabela = "";
            this.lblEnderecoEmpresa.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // lblTelefone
            // 
            this.lblTelefone.ControlSource = null;
            this.lblTelefone.FormatString = null;
            resources.ApplyResources(this.lblTelefone, "lblTelefone");
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTelefone.Tabela = "";
            this.lblTelefone.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // lblInternet
            // 
            this.lblInternet.ControlSource = null;
            this.lblInternet.FormatString = null;
            resources.ApplyResources(this.lblInternet, "lblInternet");
            this.lblInternet.Name = "lblInternet";
            this.lblInternet.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblInternet.Tabela = "";
            this.lblInternet.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // xrLine1
            // 
            resources.ApplyResources(this.xrLine1, "xrLine1");
            this.xrLine1.Name = "xrLine1";
            // 
            // picLogoEmpresa
            // 
            this.picLogoEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("picLogoEmpresa.Image")));
            resources.ApplyResources(this.picLogoEmpresa, "picLogoEmpresa");
            this.picLogoEmpresa.Name = "picLogoEmpresa";
            this.picLogoEmpresa.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // ReportBase_Paisagem
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Landscape = true;
            resources.ApplyResources(this, "$this");
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Report_Label lblNomeRelatorio;
        private DevExpress.XtraReports.UI.XRPictureBox picLogoCliente;
        private CompSoft.cf_Bases.cf_Report_Label lblNomeEmpresa;
        private CompSoft.cf_Bases.cf_Report_Label lblEnderecoEmpresa;
        private CompSoft.cf_Bases.cf_Report_Label lblInternet;
        private CompSoft.cf_Bases.cf_Report_Label lblTelefone;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRPictureBox picLogoEmpresa;
        public DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        public DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
    }
}
