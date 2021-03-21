namespace ERP.Reports
{
    partial class r0017
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
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.cf_Report_Label1 = new CompSoft.cf_Bases.cf_Report_Label();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.cf_Report_Label8 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label7 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label6 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label5 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label4 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label3 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label2 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label9 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label10 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label11 = new CompSoft.cf_Bases.cf_Report_Label();
            this.cf_Report_Label12 = new CompSoft.cf_Bases.cf_Report_Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cf_Report_Label12,
            this.cf_Report_Label11,
            this.cf_Report_Label10,
            this.cf_Report_Label9,
            this.cf_Report_Label2,
            this.cf_Report_Label1});
            this.Detail.Height = 25;
            // 
            // cf_Report_Label1
            // 
            this.cf_Report_Label1.ControlSource = "produto";
            this.cf_Report_Label1.FormatString = "{0:00000}";
            this.cf_Report_Label1.Location = new System.Drawing.Point(0, 0);
            this.cf_Report_Label1.Name = "cf_Report_Label1";
            this.cf_Report_Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label1.Size = new System.Drawing.Size(100, 25);
            this.cf_Report_Label1.StylePriority.UseTextAlignment = false;
            this.cf_Report_Label1.Tabela = "notas_fiscais";
            this.cf_Report_Label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cf_Report_Label1.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Custom_Format;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cf_Report_Label8,
            this.cf_Report_Label7,
            this.cf_Report_Label6,
            this.cf_Report_Label5,
            this.cf_Report_Label4,
            this.cf_Report_Label3});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Grupo_Produto", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("SubGrupo_Produto", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Categoria_Produto", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.Height = 25;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // cf_Report_Label8
            // 
            this.cf_Report_Label8.ControlSource = null;
            this.cf_Report_Label8.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label8.FormatString = null;
            this.cf_Report_Label8.Location = new System.Drawing.Point(992, 0);
            this.cf_Report_Label8.Name = "cf_Report_Label8";
            this.cf_Report_Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label8.Size = new System.Drawing.Size(133, 25);
            this.cf_Report_Label8.StylePriority.UseFont = false;
            this.cf_Report_Label8.StylePriority.UseTextAlignment = false;
            this.cf_Report_Label8.Tabela = "";
            this.cf_Report_Label8.Text = "Valor";
            this.cf_Report_Label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label8.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label7
            // 
            this.cf_Report_Label7.ControlSource = null;
            this.cf_Report_Label7.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label7.FormatString = null;
            this.cf_Report_Label7.Location = new System.Drawing.Point(867, 0);
            this.cf_Report_Label7.Name = "cf_Report_Label7";
            this.cf_Report_Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label7.Size = new System.Drawing.Size(125, 25);
            this.cf_Report_Label7.StylePriority.UseFont = false;
            this.cf_Report_Label7.StylePriority.UseTextAlignment = false;
            this.cf_Report_Label7.Tabela = "";
            this.cf_Report_Label7.Text = "Peso Liquido";
            this.cf_Report_Label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label7.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label6
            // 
            this.cf_Report_Label6.ControlSource = null;
            this.cf_Report_Label6.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label6.FormatString = null;
            this.cf_Report_Label6.Location = new System.Drawing.Point(742, 0);
            this.cf_Report_Label6.Name = "cf_Report_Label6";
            this.cf_Report_Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label6.Size = new System.Drawing.Size(125, 25);
            this.cf_Report_Label6.StylePriority.UseFont = false;
            this.cf_Report_Label6.StylePriority.UseTextAlignment = false;
            this.cf_Report_Label6.Tabela = "";
            this.cf_Report_Label6.Text = "Peso Bruto";
            this.cf_Report_Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label6.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label5
            // 
            this.cf_Report_Label5.ControlSource = null;
            this.cf_Report_Label5.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label5.FormatString = null;
            this.cf_Report_Label5.Location = new System.Drawing.Point(617, 0);
            this.cf_Report_Label5.Name = "cf_Report_Label5";
            this.cf_Report_Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label5.Size = new System.Drawing.Size(125, 25);
            this.cf_Report_Label5.StylePriority.UseFont = false;
            this.cf_Report_Label5.StylePriority.UseTextAlignment = false;
            this.cf_Report_Label5.Tabela = "";
            this.cf_Report_Label5.Text = "Quantidade";
            this.cf_Report_Label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label5.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label4
            // 
            this.cf_Report_Label4.ControlSource = null;
            this.cf_Report_Label4.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label4.FormatString = null;
            this.cf_Report_Label4.Location = new System.Drawing.Point(100, 0);
            this.cf_Report_Label4.Name = "cf_Report_Label4";
            this.cf_Report_Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label4.Size = new System.Drawing.Size(517, 25);
            this.cf_Report_Label4.StylePriority.UseFont = false;
            this.cf_Report_Label4.Tabela = "";
            this.cf_Report_Label4.Text = "Descrição Produto";
            this.cf_Report_Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label4.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label3
            // 
            this.cf_Report_Label3.ControlSource = null;
            this.cf_Report_Label3.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Report_Label3.FormatString = null;
            this.cf_Report_Label3.Location = new System.Drawing.Point(0, 0);
            this.cf_Report_Label3.Name = "cf_Report_Label3";
            this.cf_Report_Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label3.Size = new System.Drawing.Size(100, 25);
            this.cf_Report_Label3.StylePriority.UseFont = false;
            this.cf_Report_Label3.StylePriority.UseTextAlignment = false;
            this.cf_Report_Label3.Tabela = "";
            this.cf_Report_Label3.Text = "Produto";
            this.cf_Report_Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cf_Report_Label3.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label2
            // 
            this.cf_Report_Label2.ControlSource = "desc_produto";
            this.cf_Report_Label2.FormatString = "";
            this.cf_Report_Label2.Location = new System.Drawing.Point(100, 0);
            this.cf_Report_Label2.Name = "cf_Report_Label2";
            this.cf_Report_Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label2.Size = new System.Drawing.Size(517, 25);
            this.cf_Report_Label2.StylePriority.UseTextAlignment = false;
            this.cf_Report_Label2.Tabela = "notas_fiscais";
            this.cf_Report_Label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cf_Report_Label2.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Custom_Format;
            // 
            // cf_Report_Label9
            // 
            this.cf_Report_Label9.ControlSource = "Quantidade";
            this.cf_Report_Label9.FormatString = null;
            this.cf_Report_Label9.Location = new System.Drawing.Point(617, 0);
            this.cf_Report_Label9.Name = "cf_Report_Label9";
            this.cf_Report_Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label9.Size = new System.Drawing.Size(125, 25);
            this.cf_Report_Label9.StylePriority.UseTextAlignment = false;
            this.cf_Report_Label9.Tabela = "notas_fiscais";
            this.cf_Report_Label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label9.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Default_Text;
            // 
            // cf_Report_Label10
            // 
            this.cf_Report_Label10.ControlSource = "Peso_Bruto";
            this.cf_Report_Label10.FormatString = "{0:n3}";
            this.cf_Report_Label10.Location = new System.Drawing.Point(742, 0);
            this.cf_Report_Label10.Name = "cf_Report_Label10";
            this.cf_Report_Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label10.Size = new System.Drawing.Size(125, 25);
            this.cf_Report_Label10.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n3}";
            xrSummary3.IgnoreNullValues = true;
            this.cf_Report_Label10.Summary = xrSummary3;
            this.cf_Report_Label10.Tabela = "notas_fiscais";
            this.cf_Report_Label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label10.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Format;
            // 
            // cf_Report_Label11
            // 
            this.cf_Report_Label11.ControlSource = "Peso_Liquido";
            this.cf_Report_Label11.FormatString = "{0:n3}";
            this.cf_Report_Label11.Location = new System.Drawing.Point(867, 0);
            this.cf_Report_Label11.Name = "cf_Report_Label11";
            this.cf_Report_Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label11.Size = new System.Drawing.Size(125, 25);
            this.cf_Report_Label11.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n3}";
            xrSummary2.IgnoreNullValues = true;
            this.cf_Report_Label11.Summary = xrSummary2;
            this.cf_Report_Label11.Tabela = "notas_fiscais";
            this.cf_Report_Label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label11.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Format;
            // 
            // cf_Report_Label12
            // 
            this.cf_Report_Label12.ControlSource = "Valor_Total_Item";
            this.cf_Report_Label12.FormatString = "{0:n2}";
            this.cf_Report_Label12.Location = new System.Drawing.Point(992, 0);
            this.cf_Report_Label12.Name = "cf_Report_Label12";
            this.cf_Report_Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cf_Report_Label12.Size = new System.Drawing.Size(133, 25);
            this.cf_Report_Label12.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.IgnoreNullValues = true;
            this.cf_Report_Label12.Summary = xrSummary1;
            this.cf_Report_Label12.Tabela = "notas_fiscais";
            this.cf_Report_Label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cf_Report_Label12.Tipo_Controle = CompSoft.cf_Bases.cf_Report_Label.Tipos_Controles.Format;
            // 
            // r0017
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.GroupHeader1});
            this.Version = "8.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label2;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label4;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label3;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label12;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label11;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label10;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label9;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label8;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label7;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label6;
        private CompSoft.cf_Bases.cf_Report_Label cf_Report_Label5;

    }
}
