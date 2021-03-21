namespace ERP.Reports
{
    partial class r0001
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
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.cf_Report_Label1 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label3 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label4 = new CompSoft.cf_Bases.cf_Report_Label();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.cf_Report_Label5 = new CompSoft.cf_Bases.cf_Report_Label();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.cf_Report_Label6 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label7 = new CompSoft.cf_Bases.cf_Report_Label();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cf_Report_Label1,
            this.cf_Report_Label7,
            this.cf_Report_Label6,
            this.cf_Report_Label5,
            this.cf_Report_Label3,
            this.cf_Report_Label4});
            this.Detail.Height = 17;
            this.Detail.ParentStyleUsing.UseFont = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLabel5,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel4});
            this.PageHeader.Height = 126;
            this.PageHeader.ParentStyleUsing.UseFont = false;
            // 
            // PageFooter
            // 
            this.PageFooter.ParentStyleUsing.UseFont = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(0, 103);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(283, 17);
            this.xrLabel1.Text = "Nome do cliente";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.Location = new System.Drawing.Point(283, 103);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(283, 17);
            this.xrLabel4.Text = "Endereço";
            // 
            // cf_Report_Label1
            // 
            this.cf_Report_Label1.ControlSource = "Razao_Social";
            this.cf_Report_Label1.FormatString = null;
            this.cf_Report_Label1.Location = new System.Drawing.Point(0, 0);
            this.cf_Report_Label1.Name = "cf_Report_Label1";
            this.cf_Report_Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label1.Size = new System.Drawing.Size(283, 17);
            this.cf_Report_Label1.Tabela = "Clientes";
            this.cf_Report_Label1.Text = "cf_Report_Label1";
            this.cf_Report_Label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label1.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label3
            // 
            this.cf_Report_Label3.ControlSource = "Endereco_Cobranca";
            this.cf_Report_Label3.FormatString = null;
            this.cf_Report_Label3.Location = new System.Drawing.Point(283, 0);
            this.cf_Report_Label3.Name = "cf_Report_Label3";
            this.cf_Report_Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label3.Size = new System.Drawing.Size(283, 17);
            this.cf_Report_Label3.Tabela = "Clientes";
            this.cf_Report_Label3.Text = "cf_Report_Label1";
            this.cf_Report_Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label3.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label4
            // 
            this.cf_Report_Label4.ControlSource = "Cidade_Cobranca";
            this.cf_Report_Label4.FormatString = null;
            this.cf_Report_Label4.Location = new System.Drawing.Point(567, 0);
            this.cf_Report_Label4.Name = "cf_Report_Label4";
            this.cf_Report_Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label4.Size = new System.Drawing.Size(108, 17);
            this.cf_Report_Label4.Tabela = "Clientes";
            this.cf_Report_Label4.Text = "cf_Report_Label1";
            this.cf_Report_Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label4.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.Location = new System.Drawing.Point(567, 103);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(141, 17);
            this.xrLabel2.Text = "Cidade/UF";
            // 
            // cf_Report_Label5
            // 
            this.cf_Report_Label5.ControlSource = "Estado_Cobranca";
            this.cf_Report_Label5.FormatString = null;
            this.cf_Report_Label5.Location = new System.Drawing.Point(675, 0);
            this.cf_Report_Label5.Name = "cf_Report_Label5";
            this.cf_Report_Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label5.Size = new System.Drawing.Size(34, 17);
            this.cf_Report_Label5.Tabela = "Clientes";
            this.cf_Report_Label5.Text = "cf_Report_Label1";
            this.cf_Report_Label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label5.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(708, 103);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(184, 17);
            this.xrLabel3.Text = "E-Mail";
            // 
            // cf_Report_Label6
            // 
            this.cf_Report_Label6.ControlSource = "email";
            this.cf_Report_Label6.FormatString = null;
            this.cf_Report_Label6.Location = new System.Drawing.Point(708, 0);
            this.cf_Report_Label6.Name = "cf_Report_Label6";
            this.cf_Report_Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label6.Size = new System.Drawing.Size(184, 17);
            this.cf_Report_Label6.Tabela = "Clientes";
            this.cf_Report_Label6.Text = "cf_Report_Label1";
            this.cf_Report_Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label6.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label7
            // 
            this.cf_Report_Label7.ControlSource = "home_page";
            this.cf_Report_Label7.FormatString = null;
            this.cf_Report_Label7.Location = new System.Drawing.Point(892, 0);
            this.cf_Report_Label7.Name = "cf_Report_Label7";
            this.cf_Report_Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label7.Size = new System.Drawing.Size(175, 17);
            this.cf_Report_Label7.Tabela = "Clientes";
            this.cf_Report_Label7.Text = "cf_Report_Label1";
            this.cf_Report_Label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label7.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.Location = new System.Drawing.Point(892, 103);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(175, 17);
            this.xrLabel5.Text = "Home page";
            // 
            // xrLine2
            // 
            this.xrLine2.Location = new System.Drawing.Point(0, 118);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(1125, 8);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label1;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label5;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label4;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label6;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLine xrLine2;

    }
}
