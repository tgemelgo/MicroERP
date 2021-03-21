namespace ERP.Forms
{
    partial class f0063
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.prdPeriodo = new CompSoft.cf_Bases.cf_Periodo();
            this.grdFluxoData = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstEmpresas = new CompSoft.cf_Bases.cf_ListBox();
            this.lstEmpresasSel = new CompSoft.cf_Bases.cf_ListBox();
            this.cmdIncluir = new CompSoft.cf_Bases.cf_Button();
            this.cmdExcluir = new CompSoft.cf_Bases.cf_Button();
            this.cmdIncluirTudo = new CompSoft.cf_Bases.cf_Button();
            this.cmdExcluirTudo = new CompSoft.cf_Bases.cf_Button();
            this.pageFrame = new CompSoft.cf_Bases.cf_Pageframe();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grdFluxoMes = new CompSoft.cf_Bases.cf_DataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grdFluxoSemana = new CompSoft.cf_Bases.cf_DataGrid();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxoData)).BeginInit();
            this.pageFrame.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxoMes)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxoSemana)).BeginInit();
            this.SuspendLayout();
            // 
            // prdPeriodo
            // 
            this.prdPeriodo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdPeriodo.Location = new System.Drawing.Point(8, 7);
            this.prdPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdPeriodo.Name = "prdPeriodo";
            this.prdPeriodo.Size = new System.Drawing.Size(264, 51);
            this.prdPeriodo.TabIndex = 0;
            // 
            // grdFluxoData
            // 
            this.grdFluxoData.Allow_Alter_Value_All_StatusForm = false;
            this.grdFluxoData.AllowEditRow = true;
            this.grdFluxoData.AllowUserToAddRows = false;
            this.grdFluxoData.AllowUserToDeleteRows = false;
            this.grdFluxoData.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdFluxoData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdFluxoData.Cancel_OnClick = true;
            this.grdFluxoData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFluxoData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.grdFluxoData.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdFluxoData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdFluxoData.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdFluxoData.GridColor = System.Drawing.Color.DimGray;
            this.grdFluxoData.Location = new System.Drawing.Point(3, 3);
            this.grdFluxoData.MultiSelect = false;
            this.grdFluxoData.Name = "grdFluxoData";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFluxoData.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdFluxoData.RowHeadersWidth = 22;
            this.grdFluxoData.RowTemplate.Height = 20;
            this.grdFluxoData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFluxoData.ShowCellErrors = false;
            this.grdFluxoData.ShowCellToolTips = false;
            this.grdFluxoData.ShowEditingIcon = false;
            this.grdFluxoData.ShowRowErrors = false;
            this.grdFluxoData.Size = new System.Drawing.Size(564, 309);
            this.grdFluxoData.TabIndex = 1;
            this.grdFluxoData.TabStop = false;
            this.grdFluxoData.VirtualMode = true;
            this.grdFluxoData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdFluxo_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Referencia";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Data de vencimento";
            this.Column1.Name = "Column1";
            this.Column1.Width = 133;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Valor_Receber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C";
            dataGridViewCellStyle2.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Valor a receber";
            this.Column2.Name = "Column2";
            this.Column2.Width = 112;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Valor_Pagar";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Valor a pagar";
            this.Column3.Name = "Column3";
            this.Column3.Width = 102;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Saldo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "c";
            dataGridViewCellStyle4.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "Saldo";
            this.Column4.Name = "Column4";
            this.Column4.Width = 65;
            // 
            // lstEmpresas
            // 
            this.lstEmpresas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstEmpresas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstEmpresas.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lstEmpresas.ForeColor = System.Drawing.Color.DimGray;
            this.lstEmpresas.FormattingEnabled = true;
            this.lstEmpresas.Location = new System.Drawing.Point(8, 94);
            this.lstEmpresas.Name = "lstEmpresas";
            this.lstEmpresas.Size = new System.Drawing.Size(226, 93);
            this.lstEmpresas.SQLStatement = "";
            this.lstEmpresas.TabIndex = 2;
            this.lstEmpresas.UseTabStops = false;
            // 
            // lstEmpresasSel
            // 
            this.lstEmpresasSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstEmpresasSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstEmpresasSel.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lstEmpresasSel.ForeColor = System.Drawing.Color.DimGray;
            this.lstEmpresasSel.FormattingEnabled = true;
            this.lstEmpresasSel.Location = new System.Drawing.Point(271, 94);
            this.lstEmpresasSel.Name = "lstEmpresasSel";
            this.lstEmpresasSel.Size = new System.Drawing.Size(222, 93);
            this.lstEmpresasSel.SQLStatement = "";
            this.lstEmpresasSel.TabIndex = 3;
            this.lstEmpresasSel.UseTabStops = false;
            // 
            // cmdIncluir
            // 
            this.cmdIncluir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIncluir.ForeColor = System.Drawing.Color.Black;
            this.cmdIncluir.Grupo = "";
            this.cmdIncluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdIncluir.Location = new System.Drawing.Point(237, 116);
            this.cmdIncluir.Name = "cmdIncluir";
            this.cmdIncluir.Size = new System.Drawing.Size(31, 23);
            this.cmdIncluir.TabIndex = 4;
            this.cmdIncluir.TabStop = false;
            this.cmdIncluir.Text = ">";
            this.cmdIncluir.UseVisualStyleBackColor = true;
            this.cmdIncluir.Click += new System.EventHandler(this.cmdIncluir_Click);
            // 
            // cmdExcluir
            // 
            this.cmdExcluir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcluir.ForeColor = System.Drawing.Color.Black;
            this.cmdExcluir.Grupo = "";
            this.cmdExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExcluir.Location = new System.Drawing.Point(237, 139);
            this.cmdExcluir.Name = "cmdExcluir";
            this.cmdExcluir.Size = new System.Drawing.Size(31, 23);
            this.cmdExcluir.TabIndex = 5;
            this.cmdExcluir.TabStop = false;
            this.cmdExcluir.Text = "<";
            this.cmdExcluir.UseVisualStyleBackColor = true;
            this.cmdExcluir.Click += new System.EventHandler(this.cmdExcluir_Click);
            // 
            // cmdIncluirTudo
            // 
            this.cmdIncluirTudo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIncluirTudo.ForeColor = System.Drawing.Color.Black;
            this.cmdIncluirTudo.Grupo = "";
            this.cmdIncluirTudo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdIncluirTudo.Location = new System.Drawing.Point(237, 93);
            this.cmdIncluirTudo.Name = "cmdIncluirTudo";
            this.cmdIncluirTudo.Size = new System.Drawing.Size(31, 23);
            this.cmdIncluirTudo.TabIndex = 6;
            this.cmdIncluirTudo.TabStop = false;
            this.cmdIncluirTudo.Text = ">>";
            this.cmdIncluirTudo.UseVisualStyleBackColor = true;
            this.cmdIncluirTudo.Click += new System.EventHandler(this.cmdIncluirTudo_Click);
            // 
            // cmdExcluirTudo
            // 
            this.cmdExcluirTudo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcluirTudo.ForeColor = System.Drawing.Color.Black;
            this.cmdExcluirTudo.Grupo = "";
            this.cmdExcluirTudo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExcluirTudo.Location = new System.Drawing.Point(237, 162);
            this.cmdExcluirTudo.Name = "cmdExcluirTudo";
            this.cmdExcluirTudo.Size = new System.Drawing.Size(31, 23);
            this.cmdExcluirTudo.TabIndex = 7;
            this.cmdExcluirTudo.TabStop = false;
            this.cmdExcluirTudo.Text = "<<";
            this.cmdExcluirTudo.UseVisualStyleBackColor = true;
            this.cmdExcluirTudo.Click += new System.EventHandler(this.cmdExcluirTudo_Click);
            // 
            // pageFrame
            // 
            this.pageFrame.Controls.Add(this.tabPage1);
            this.pageFrame.Controls.Add(this.tabPage2);
            this.pageFrame.Controls.Add(this.tabPage3);
            this.pageFrame.Controls.Add(this.tabPage4);
            this.pageFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageFrame.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageFrame.HotTrack = true;
            this.pageFrame.Location = new System.Drawing.Point(0, 0);
            this.pageFrame.Name = "pageFrame";
            this.pageFrame.SelectedIndex = 0;
            this.pageFrame.Size = new System.Drawing.Size(578, 375);
            this.pageFrame.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cf_Label1);
            this.tabPage1.Controls.Add(this.prdPeriodo);
            this.tabPage1.Controls.Add(this.cmdExcluirTudo);
            this.tabPage1.Controls.Add(this.lstEmpresas);
            this.tabPage1.Controls.Add(this.cmdIncluirTudo);
            this.tabPage1.Controls.Add(this.lstEmpresasSel);
            this.tabPage1.Controls.Add(this.cmdExcluir);
            this.tabPage1.Controls.Add(this.cmdIncluir);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados para filtro";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(9, 79);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(195, 13);
            this.cf_Label1.TabIndex = 8;
            this.cf_Label1.Text = "Selecione as empresas para filtro";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdFluxoData);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(570, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grdFluxoMes);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(570, 349);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Mês";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grdFluxoMes
            // 
            this.grdFluxoMes.Allow_Alter_Value_All_StatusForm = false;
            this.grdFluxoMes.AllowEditRow = true;
            this.grdFluxoMes.AllowUserToAddRows = false;
            this.grdFluxoMes.AllowUserToDeleteRows = false;
            this.grdFluxoMes.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdFluxoMes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdFluxoMes.Cancel_OnClick = true;
            this.grdFluxoMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFluxoMes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.grdFluxoMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdFluxoMes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdFluxoMes.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdFluxoMes.GridColor = System.Drawing.Color.DimGray;
            this.grdFluxoMes.Location = new System.Drawing.Point(3, 3);
            this.grdFluxoMes.MultiSelect = false;
            this.grdFluxoMes.Name = "grdFluxoMes";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFluxoMes.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdFluxoMes.RowHeadersWidth = 22;
            this.grdFluxoMes.RowTemplate.Height = 20;
            this.grdFluxoMes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFluxoMes.ShowCellErrors = false;
            this.grdFluxoMes.ShowCellToolTips = false;
            this.grdFluxoMes.ShowEditingIcon = false;
            this.grdFluxoMes.ShowRowErrors = false;
            this.grdFluxoMes.Size = new System.Drawing.Size(564, 309);
            this.grdFluxoMes.TabIndex = 2;
            this.grdFluxoMes.TabStop = false;
            this.grdFluxoMes.VirtualMode = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Referencia";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Data de vencimento";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 133;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Valor_Receber";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "Valor a receber";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 112;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Valor_Pagar";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Valor a pagar";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 102;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Saldo";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "c";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "Saldo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 65;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.grdFluxoSemana);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(570, 349);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Semana";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // grdFluxoSemana
            // 
            this.grdFluxoSemana.Allow_Alter_Value_All_StatusForm = false;
            this.grdFluxoSemana.AllowEditRow = true;
            this.grdFluxoSemana.AllowUserToAddRows = false;
            this.grdFluxoSemana.AllowUserToDeleteRows = false;
            this.grdFluxoSemana.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdFluxoSemana.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdFluxoSemana.Cancel_OnClick = true;
            this.grdFluxoSemana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFluxoSemana.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.grdFluxoSemana.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdFluxoSemana.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdFluxoSemana.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdFluxoSemana.GridColor = System.Drawing.Color.DimGray;
            this.grdFluxoSemana.Location = new System.Drawing.Point(3, 3);
            this.grdFluxoSemana.MultiSelect = false;
            this.grdFluxoSemana.Name = "grdFluxoSemana";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFluxoSemana.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.grdFluxoSemana.RowHeadersWidth = 22;
            this.grdFluxoSemana.RowTemplate.Height = 20;
            this.grdFluxoSemana.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFluxoSemana.ShowCellErrors = false;
            this.grdFluxoSemana.ShowCellToolTips = false;
            this.grdFluxoSemana.ShowEditingIcon = false;
            this.grdFluxoSemana.ShowRowErrors = false;
            this.grdFluxoSemana.Size = new System.Drawing.Size(564, 309);
            this.grdFluxoSemana.TabIndex = 2;
            this.grdFluxoSemana.TabStop = false;
            this.grdFluxoSemana.VirtualMode = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Referencia";
            dataGridViewCellStyle11.Format = "d";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn5.HeaderText = "Data de vencimento";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 133;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Valor_Receber";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "C";
            dataGridViewCellStyle12.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn6.HeaderText = "Valor a receber";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 112;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Valor_Pagar";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "C";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn7.HeaderText = "Valor a pagar";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 102;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Saldo";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "c";
            dataGridViewCellStyle14.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn8.HeaderText = "Saldo";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 65;
            // 
            // f0063
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 375);
            this.Controls.Add(this.pageFrame);
            this.MainTabela = "fluxo";
            this.Name = "f0063";
            this.Text = "Fluxo de caixa";
            this.Load += new System.EventHandler(this.f0063_Load);
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0063_user_AfterRefreshData);
            this.user_BeforeSearch += new CompSoft.FormSet.BeforeSearch(this.f0063_user_BeforeSearch);
            this.user_AfterClear += new CompSoft.FormSet.AfterClear(this.f0063_user_AfterClear);
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxoData)).EndInit();
            this.pageFrame.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxoMes)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxoSemana)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CompSoft.cf_Bases.cf_Periodo prdPeriodo;
        private CompSoft.cf_Bases.cf_DataGrid grdFluxoData;
        private CompSoft.cf_Bases.cf_ListBox lstEmpresas;
        private CompSoft.cf_Bases.cf_ListBox lstEmpresasSel;
        private CompSoft.cf_Bases.cf_Button cmdIncluir;
        private CompSoft.cf_Bases.cf_Button cmdExcluir;
        private CompSoft.cf_Bases.cf_Button cmdIncluirTudo;
        private CompSoft.cf_Bases.cf_Button cmdExcluirTudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private CompSoft.cf_Bases.cf_Pageframe pageFrame;
        private System.Windows.Forms.TabPage tabPage1;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private CompSoft.cf_Bases.cf_DataGrid grdFluxoMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TabPage tabPage4;
        private CompSoft.cf_Bases.cf_DataGrid grdFluxoSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}