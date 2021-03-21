namespace CompSoft.Tools
{
    partial class frmGerenciadorRelatorios
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGerenciadorRelatorios));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.lblDescricaoRelatorio = new System.Windows.Forms.Label();
            this.cmdFechar = new CompSoft.cf_Bases.cf_Button();
            this.optRegistroAtual = new CompSoft.cf_Bases.cf_RadioButton();
            this.optTodosRegistros = new CompSoft.cf_Bases.cf_RadioButton();
            this.cmdImprimir = new CompSoft.cf_Bases.cf_Button();
            this.lstRelatorio = new DevExpress.XtraEditors.ImageListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.lstRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "kghostview.png");
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(345, 12);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(95, 13);
            this.cf_Label2.TabIndex = 4;
            this.cf_Label2.Text = "Opções de filtro";
            // 
            // lblDescricaoRelatorio
            // 
            this.lblDescricaoRelatorio.BackColor = System.Drawing.Color.Transparent;
            this.lblDescricaoRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDescricaoRelatorio.Location = new System.Drawing.Point(345, 73);
            this.lblDescricaoRelatorio.Name = "lblDescricaoRelatorio";
            this.lblDescricaoRelatorio.Size = new System.Drawing.Size(203, 133);
            this.lblDescricaoRelatorio.TabIndex = 5;
            this.lblDescricaoRelatorio.Text = "lblDescricaoRelatorio";
            // 
            // cmdFechar
            // 
            this.cmdFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFechar.BackColor = System.Drawing.Color.Transparent;
            this.cmdFechar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.ForeColor = System.Drawing.Color.Black;
            this.cmdFechar.Grupo = string.Empty;
            this.cmdFechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdFechar.Location = new System.Drawing.Point(473, 212);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(75, 23);
            this.cmdFechar.TabIndex = 6;
            this.cmdFechar.TabStop = false;
            this.cmdFechar.Text = "&Fechar";
            this.cmdFechar.UseVisualStyleBackColor = false;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // optRegistroAtual
            // 
            this.optRegistroAtual.AutoSize = true;
            this.optRegistroAtual.Checked = true;
            this.optRegistroAtual.ControlSource = string.Empty;
            this.optRegistroAtual.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optRegistroAtual.Grupo = string.Empty;
            this.optRegistroAtual.Location = new System.Drawing.Point(352, 29);
            this.optRegistroAtual.Name = "optRegistroAtual";
            this.optRegistroAtual.Size = new System.Drawing.Size(92, 17);
            this.optRegistroAtual.Tabela = null;
            this.optRegistroAtual.Tabela_INNER = null;
            this.optRegistroAtual.TabIndex = 7;
            this.optRegistroAtual.TabStop = true;
            this.optRegistroAtual.Text = "Registro atual";
            this.optRegistroAtual.UseVisualStyleBackColor = true;
            this.optRegistroAtual.ValorAnterior = false;
            // 
            // optTodosRegistros
            // 
            this.optTodosRegistros.AutoSize = true;
            this.optTodosRegistros.ControlSource = string.Empty;
            this.optTodosRegistros.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTodosRegistros.Grupo = string.Empty;
            this.optTodosRegistros.Location = new System.Drawing.Point(352, 47);
            this.optTodosRegistros.Name = "optTodosRegistros";
            this.optTodosRegistros.Size = new System.Drawing.Size(167, 17);
            this.optTodosRegistros.Tabela = null;
            this.optTodosRegistros.Tabela_INNER = null;
            this.optTodosRegistros.TabIndex = 8;
            this.optTodosRegistros.Text = "Todos os registros localizados";
            this.optTodosRegistros.UseVisualStyleBackColor = true;
            this.optTodosRegistros.ValorAnterior = false;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImprimir.BackColor = System.Drawing.Color.Transparent;
            this.cmdImprimir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.ForeColor = System.Drawing.Color.Black;
            this.cmdImprimir.Grupo = string.Empty;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdImprimir.Location = new System.Drawing.Point(392, 212);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(75, 23);
            this.cmdImprimir.TabIndex = 9;
            this.cmdImprimir.TabStop = false;
            this.cmdImprimir.Text = "&Visualizar";
            this.cmdImprimir.UseVisualStyleBackColor = false;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // lstRelatorio
            // 
            this.lstRelatorio.ImageList = this.imageList1;
            this.lstRelatorio.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.lstRelatorio.Location = new System.Drawing.Point(12, 12);
            this.lstRelatorio.Name = "lstRelatorio";
            this.lstRelatorio.Size = new System.Drawing.Size(327, 223);
            this.lstRelatorio.TabIndex = 10;
            this.lstRelatorio.SelectedValueChanged += new System.EventHandler(this.lstRelatorio_SelectedValueChanged);
            // 
            // frmGerenciadorRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(559, 247);
            this.Controls.Add(this.lstRelatorio);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.optTodosRegistros);
            this.Controls.Add(this.optRegistroAtual);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.lblDescricaoRelatorio);
            this.Controls.Add(this.cf_Label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmGerenciadorRelatorios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Gerenciador de impressões";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGerenciadorRelatorios_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lstRelatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_Button cmdFechar;
        private System.Windows.Forms.Label lblDescricaoRelatorio;
        private CompSoft.cf_Bases.cf_RadioButton optRegistroAtual;
        private CompSoft.cf_Bases.cf_RadioButton optTodosRegistros;
        private System.Windows.Forms.ImageList imageList1;
        private CompSoft.cf_Bases.cf_Button cmdImprimir;
        private DevExpress.XtraEditors.ImageListBoxControl lstRelatorio;
    }
}