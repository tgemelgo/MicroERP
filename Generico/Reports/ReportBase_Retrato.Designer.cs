namespace CompSoft.Reports
{
    partial class ReportBase_Retrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportBase_Retrato));
            this.picLogoCliente = new DevExpress.XtraReports.UI.XRPictureBox();
            this.lblNomeRelatorio = new CompSoft.cf_Bases.cf_Report_Label();
            this.picLogoEmpresa = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.lblInternet = new CompSoft.cf_Bases.cf_Report_Label();
            this.lblTelefone = new CompSoft.cf_Bases.cf_Report_Label();
            this.lblEnderecoEmpresa = new CompSoft.cf_Bases.cf_Report_Label();
            this.lblNomeEmpresa = new CompSoft.cf_Bases.cf_Report_Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 51F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblNomeEmpresa,
            this.lblNomeRelatorio,
            this.picLogoEmpresa,
            this.xrLine1,
            this.lblInternet,
            this.lblTelefone,
            this.lblEnderecoEmpresa,
            this.picLogoCliente});
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.PageFooter.HeightF = 17F;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 0F;
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 0F;
            // 
            // picLogoCliente
            // 
            this.picLogoCliente.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8F);
            this.picLogoCliente.Name = "picLogoCliente";
            this.picLogoCliente.SizeF = new System.Drawing.SizeF(117F, 75F);
            this.picLogoCliente.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // lblNomeRelatorio
            // 
            this.lblNomeRelatorio.ControlSource = null;
            this.lblNomeRelatorio.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeRelatorio.FormatString = null;
            this.lblNomeRelatorio.LocationFloat = new DevExpress.Utils.PointFloat(117F, 0F);
            this.lblNomeRelatorio.Name = "lblNomeRelatorio";
            this.lblNomeRelatorio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNomeRelatorio.SizeF = new System.Drawing.SizeF(575F, 25F);
            this.lblNomeRelatorio.Tabela = "";
            this.lblNomeRelatorio.Text = "lblNomeRelatorio";
            this.lblNomeRelatorio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblNomeRelatorio.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // picLogoEmpresa
            // 
            this.picLogoEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("picLogoEmpresa.Image")));
            this.picLogoEmpresa.LocationFloat = new DevExpress.Utils.PointFloat(692F, 8F);
            this.picLogoEmpresa.Name = "picLogoEmpresa";
            this.picLogoEmpresa.SizeF = new System.Drawing.SizeF(92F, 75F);
            this.picLogoEmpresa.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(482F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(226F, 17F);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(708F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(76F, 17F);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 92F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(783F, 8F);
            // 
            // lblInternet
            // 
            this.lblInternet.CanShrink = true;
            this.lblInternet.ControlSource = null;
            this.lblInternet.FormatString = null;
            this.lblInternet.LocationFloat = new DevExpress.Utils.PointFloat(117F, 75F);
            this.lblInternet.Name = "lblInternet";
            this.lblInternet.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblInternet.SizeF = new System.Drawing.SizeF(575F, 16F);
            this.lblInternet.Tabela = "";
            this.lblInternet.Text = "lblInternet";
            this.lblInternet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblInternet.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // lblTelefone
            // 
            this.lblTelefone.CanShrink = true;
            this.lblTelefone.ControlSource = null;
            this.lblTelefone.FormatString = null;
            this.lblTelefone.LocationFloat = new DevExpress.Utils.PointFloat(117F, 58F);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTelefone.SizeF = new System.Drawing.SizeF(575F, 16F);
            this.lblTelefone.Tabela = "";
            this.lblTelefone.Text = "lblTelefone";
            this.lblTelefone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblTelefone.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // lblEnderecoEmpresa
            // 
            this.lblEnderecoEmpresa.ControlSource = null;
            this.lblEnderecoEmpresa.FormatString = null;
            this.lblEnderecoEmpresa.LocationFloat = new DevExpress.Utils.PointFloat(117F, 42F);
            this.lblEnderecoEmpresa.Name = "lblEnderecoEmpresa";
            this.lblEnderecoEmpresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEnderecoEmpresa.SizeF = new System.Drawing.SizeF(575F, 16F);
            this.lblEnderecoEmpresa.Tabela = "";
            this.lblEnderecoEmpresa.Text = "lblEnderecoEmpresa";
            this.lblEnderecoEmpresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblEnderecoEmpresa.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // lblNomeEmpresa
            // 
            this.lblNomeEmpresa.ControlSource = null;
            this.lblNomeEmpresa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeEmpresa.FormatString = null;
            this.lblNomeEmpresa.LocationFloat = new DevExpress.Utils.PointFloat(117F, 25F);
            this.lblNomeEmpresa.Name = "lblNomeEmpresa";
            this.lblNomeEmpresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNomeEmpresa.SizeF = new System.Drawing.SizeF(575F, 16F);
            this.lblNomeEmpresa.Tabela = "";
            this.lblNomeEmpresa.Text = "lblNomeEmpresa";
            this.lblNomeEmpresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblNomeEmpresa.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // ReportBase_Retrato
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 0, 0);
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Report_Label lblNomeRelatorio;
        private DevExpress.XtraReports.UI.XRPictureBox picLogoCliente;
        private DevExpress.XtraReports.UI.XRPictureBox picLogoEmpresa;
        private CompSoft.cf_Bases.cf_Report_Label lblNomeEmpresa;
        private CompSoft.cf_Bases.cf_Report_Label lblEnderecoEmpresa;
        private CompSoft.cf_Bases.cf_Report_Label lblTelefone;
        private CompSoft.cf_Bases.cf_Report_Label lblInternet;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        public DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        public DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
    }
}
