namespace CompSoft.Tools
{
    partial class frmAdvancedSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pgfTrabalho = new CompSoft.cf_Bases.cf_Pageframe();
            this.tabFiltros = new System.Windows.Forms.TabPage();
            this.cmdLocalizar = new CompSoft.cf_Bases.cf_Button();
            this.cmdNovaBusca = new CompSoft.cf_Bases.cf_Button();
            this.cmdOK = new CompSoft.cf_Bases.cf_Button();
            this.grdResultado = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdVoltar = new CompSoft.cf_Bases.cf_Button();
            this.pgfTrabalho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // pgfTrabalho
            // 
            this.pgfTrabalho.Controls.Add(this.tabFiltros);
            this.pgfTrabalho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgfTrabalho.HotTrack = true;
            this.pgfTrabalho.Location = new System.Drawing.Point(7, 7);
            this.pgfTrabalho.Name = "pgfTrabalho";
            this.pgfTrabalho.SelectedIndex = 0;
            this.pgfTrabalho.Size = new System.Drawing.Size(488, 238);
            this.pgfTrabalho.TabIndex = 0;
            // 
            // tabFiltros
            // 
            this.tabFiltros.Location = new System.Drawing.Point(4, 22);
            this.tabFiltros.Name = "tabFiltros";
            this.tabFiltros.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiltros.Size = new System.Drawing.Size(480, 212);
            this.tabFiltros.TabIndex = 0;
            this.tabFiltros.Text = "Filtros";
            this.tabFiltros.UseVisualStyleBackColor = true;
            // 
            // cmdLocalizar
            // 
            this.cmdLocalizar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocalizar.ForeColor = System.Drawing.Color.Black;
            this.cmdLocalizar.Grupo = "";
            this.cmdLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLocalizar.Location = new System.Drawing.Point(501, 29);
            this.cmdLocalizar.Name = "cmdLocalizar";
            this.cmdLocalizar.Size = new System.Drawing.Size(79, 23);
            this.cmdLocalizar.TabIndex = 1;
            this.cmdLocalizar.TabStop = false;
            this.cmdLocalizar.Text = "&Localizar";
            this.cmdLocalizar.UseVisualStyleBackColor = true;
            this.cmdLocalizar.Click += new System.EventHandler(this.cmdLocalizar_Click);
            // 
            // cmdNovaBusca
            // 
            this.cmdNovaBusca.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNovaBusca.ForeColor = System.Drawing.Color.Black;
            this.cmdNovaBusca.Grupo = "";
            this.cmdNovaBusca.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNovaBusca.Location = new System.Drawing.Point(501, 58);
            this.cmdNovaBusca.Name = "cmdNovaBusca";
            this.cmdNovaBusca.Size = new System.Drawing.Size(79, 23);
            this.cmdNovaBusca.TabIndex = 2;
            this.cmdNovaBusca.TabStop = false;
            this.cmdNovaBusca.Text = "&Nova busca";
            this.cmdNovaBusca.UseVisualStyleBackColor = true;
            this.cmdNovaBusca.Click += new System.EventHandler(this.cmdNovaBusca_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.ForeColor = System.Drawing.Color.Black;
            this.cmdOK.Grupo = "";
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdOK.Location = new System.Drawing.Point(501, 222);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(79, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.TabStop = false;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // grdResultado
            // 
            this.grdResultado.Allow_Alter_Value_All_StatusForm = false;
            this.grdResultado.AllowEditRow = true;
            this.grdResultado.AllowUserToAddRows = false;
            this.grdResultado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "(nulo)";
            this.grdResultado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdResultado.BackgroundColor = System.Drawing.Color.Gray;
            this.grdResultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdResultado.Cancel_OnClick = true;
            this.grdResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.NullValue = "(nulo)";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResultado.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdResultado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdResultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdResultado.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdResultado.GridColor = System.Drawing.Color.DimGray;
            this.grdResultado.Location = new System.Drawing.Point(0, 252);
            this.grdResultado.MultiSelect = false;
            this.grdResultado.Name = "grdResultado";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResultado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdResultado.RowHeadersWidth = 15;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.grdResultado.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdResultado.RowTemplate.Height = 20;
            this.grdResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultado.ShowCellErrors = false;
            this.grdResultado.ShowCellToolTips = false;
            this.grdResultado.ShowEditingIcon = false;
            this.grdResultado.ShowRowErrors = false;
            this.grdResultado.Size = new System.Drawing.Size(582, 252);
            this.grdResultado.TabIndex = 4;
            this.grdResultado.TabStop = false;
            this.grdResultado.VirtualMode = true;
            this.grdResultado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResultado_CellClick);
            this.grdResultado.EditModeChanged += new System.EventHandler(this.grdResultado_EditModeChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.DataPropertyName = "Sel";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "false";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.FalseValue = "false";
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "[  ]";
            this.Column1.IndeterminateValue = "false";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.ThreeState = true;
            this.Column1.TrueValue = "true";
            this.Column1.Width = 32;
            // 
            // cmdVoltar
            // 
            this.cmdVoltar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdVoltar.ForeColor = System.Drawing.Color.Black;
            this.cmdVoltar.Grupo = "";
            this.cmdVoltar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdVoltar.Location = new System.Drawing.Point(501, 87);
            this.cmdVoltar.Name = "cmdVoltar";
            this.cmdVoltar.Size = new System.Drawing.Size(79, 23);
            this.cmdVoltar.TabIndex = 5;
            this.cmdVoltar.TabStop = false;
            this.cmdVoltar.Text = "&Voltar";
            this.cmdVoltar.UseVisualStyleBackColor = true;
            this.cmdVoltar.Click += new System.EventHandler(this.cmdVoltar_Click);
            // 
            // frmAdvancedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 504);
            this.ControlBox = false;
            this.Controls.Add(this.cmdVoltar);
            this.Controls.Add(this.grdResultado);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdNovaBusca);
            this.Controls.Add(this.cmdLocalizar);
            this.Controls.Add(this.pgfTrabalho);
            this.MainTabela = "xresultado";
            this.Name = "frmAdvancedSearch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busca avançada";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdvancedSearch_FormClosed);
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.frmAdvancedSearch_user_AfterRefreshData);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.frmAdvancedSearch_user_FormStatus_Change);
            this.pgfTrabalho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public CompSoft.cf_Bases.cf_Pageframe pgfTrabalho;
        public System.Windows.Forms.TabPage tabFiltros;
        public CompSoft.cf_Bases.cf_Button cmdLocalizar;
        public CompSoft.cf_Bases.cf_Button cmdNovaBusca;
        public CompSoft.cf_Bases.cf_Button cmdOK;
        public CompSoft.cf_Bases.cf_DataGrid grdResultado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        public CompSoft.cf_Bases.cf_Button cmdVoltar;
    }
}