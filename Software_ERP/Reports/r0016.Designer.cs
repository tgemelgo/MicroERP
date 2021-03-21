namespace ERP.Reports
{
    partial class r0016
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
            this.cf_Report_Label1 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label2 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label3 = new CompSoft.cf_Bases.cf_Report_Label();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.cf_Report_Label4 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label5 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label6 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label7 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label8 = new CompSoft.cf_Bases.cf_Report_Label();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Location = new System.Drawing.Point(709, 8);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Location = new System.Drawing.Point(483, 8);
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cf_Report_Label3,
            this.cf_Report_Label2,
            this.cf_Report_Label1});
            this.Detail.Height = 25;
            this.Detail.KeepTogether = true;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Razao_Social", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            // 
            // PageHeader
            // 
            this.PageHeader.ParentStyleUsing.UseFont = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 25;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            // 
            // cf_Report_Label1
            // 
            this.cf_Report_Label1.ControlSource = "Razao_Social";
            this.cf_Report_Label1.FormatString = null;
            this.cf_Report_Label1.Location = new System.Drawing.Point(17, 0);
            this.cf_Report_Label1.Name = "cf_Report_Label1";
            this.cf_Report_Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label1.Size = new System.Drawing.Size(367, 25);
            this.cf_Report_Label1.Tabela = "Clientes_Vendedor";
            this.cf_Report_Label1.Text = "cf_Report_Label1";
            this.cf_Report_Label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label1.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label2
            // 
            this.cf_Report_Label2.ControlSource = "CPF_CNPJ";
            this.cf_Report_Label2.FormatString = "{0:00\\.000\\.000\\/0000\\-00}";
            this.cf_Report_Label2.Location = new System.Drawing.Point(392, 0);
            this.cf_Report_Label2.Name = "cf_Report_Label2";
            this.cf_Report_Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label2.Size = new System.Drawing.Size(200, 25);
            this.cf_Report_Label2.Tabela = "Clientes_Vendedor";
            this.cf_Report_Label2.Text = "cf_Report_Label1";
            this.cf_Report_Label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cf_Report_Label2.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Custom_Format;
            // 
            // cf_Report_Label3
            // 
            this.cf_Report_Label3.ControlSource = "DT_NF";
            this.cf_Report_Label3.FormatString = "{0:dd/MM/yyyy}";
            this.cf_Report_Label3.Location = new System.Drawing.Point(600, 0);
            this.cf_Report_Label3.Name = "cf_Report_Label3";
            this.cf_Report_Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label3.Size = new System.Drawing.Size(167, 25);
            this.cf_Report_Label3.Tabela = "Clientes_Vendedor";
            this.cf_Report_Label3.Text = "cf_Report_Label1";
            this.cf_Report_Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cf_Report_Label3.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Format;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.cf_Report_Label8,
            this.cf_Report_Label7,
            this.cf_Report_Label6,
            this.cf_Report_Label5,
            this.cf_Report_Label4});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("nome_vendedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage;
            this.GroupHeader1.Height = 66;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // cf_Report_Label4
            // 
            this.cf_Report_Label4.ControlSource = string.Empty;
            this.cf_Report_Label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label4.FormatString = string.Empty;
            this.cf_Report_Label4.Location = new System.Drawing.Point(600, 33);
            this.cf_Report_Label4.Name = "cf_Report_Label4";
            this.cf_Report_Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label4.ParentStyleUsing.UseFont = false;
            this.cf_Report_Label4.Size = new System.Drawing.Size(167, 25);
            this.cf_Report_Label4.Tabela = string.Empty;
            this.cf_Report_Label4.Text = "Dt. Ultima Compra";
            this.cf_Report_Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cf_Report_Label4.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Format;
            // 
            // cf_Report_Label5
            // 
            this.cf_Report_Label5.ControlSource = string.Empty;
            this.cf_Report_Label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label5.FormatString = string.Empty;
            this.cf_Report_Label5.Location = new System.Drawing.Point(392, 33);
            this.cf_Report_Label5.Name = "cf_Report_Label5";
            this.cf_Report_Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label5.ParentStyleUsing.UseFont = false;
            this.cf_Report_Label5.Size = new System.Drawing.Size(200, 25);
            this.cf_Report_Label5.Tabela = string.Empty;
            this.cf_Report_Label5.Text = "CPF / CNPJ";
            this.cf_Report_Label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cf_Report_Label5.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label6
            // 
            this.cf_Report_Label6.ControlSource = string.Empty;
            this.cf_Report_Label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label6.FormatString = null;
            this.cf_Report_Label6.Location = new System.Drawing.Point(17, 33);
            this.cf_Report_Label6.Name = "cf_Report_Label6";
            this.cf_Report_Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label6.ParentStyleUsing.UseFont = false;
            this.cf_Report_Label6.Size = new System.Drawing.Size(367, 25);
            this.cf_Report_Label6.Tabela = string.Empty;
            this.cf_Report_Label6.Text = "Razão Social";
            this.cf_Report_Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label6.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label7
            // 
            this.cf_Report_Label7.ControlSource = string.Empty;
            this.cf_Report_Label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label7.FormatString = null;
            this.cf_Report_Label7.Location = new System.Drawing.Point(33, 0);
            this.cf_Report_Label7.Name = "cf_Report_Label7";
            this.cf_Report_Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label7.ParentStyleUsing.UseFont = false;
            this.cf_Report_Label7.Size = new System.Drawing.Size(84, 25);
            this.cf_Report_Label7.Tabela = string.Empty;
            this.cf_Report_Label7.Text = "Vendedor:";
            this.cf_Report_Label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label7.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label8
            // 
            this.cf_Report_Label8.ControlSource = "Nome_Vendedor";
            this.cf_Report_Label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label8.FormatString = null;
            this.cf_Report_Label8.Location = new System.Drawing.Point(125, 0);
            this.cf_Report_Label8.Name = "cf_Report_Label8";
            this.cf_Report_Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label8.ParentStyleUsing.UseFont = false;
            this.cf_Report_Label8.Size = new System.Drawing.Size(642, 25);
            this.cf_Report_Label8.Tabela = "Clientes_Vendedor";
            this.cf_Report_Label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label8.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // xrLine2
            // 
            this.xrLine2.Location = new System.Drawing.Point(0, 58);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(783, 8);
            // 
            // r0016
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.GroupHeader1});
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label1;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label2;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label3;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label6;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label5;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label4;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label8;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label7;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
    }
}
