namespace ERP.Forms
{
    partial class f0088
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
            this.cmdLocalizarArquivo = new CompSoft.cf_Bases.cf_Button();
            this.txtFile = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_GroupBox1 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cboBanco = new CompSoft.cf_Bases.cf_ComboBox();
            this.cmdCarregar = new CompSoft.cf_Bases.cf_Button();
            this.dgFile = new System.Windows.Forms.OpenFileDialog();
            this.cf_DataGrid1 = new CompSoft.cf_Bases.cf_DataGrid();
            this.cf_GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdLocalizarArquivo
            // 
            this.cmdLocalizarArquivo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocalizarArquivo.ForeColor = System.Drawing.Color.Black;
            this.cmdLocalizarArquivo.Grupo = "";
            this.cmdLocalizarArquivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLocalizarArquivo.Location = new System.Drawing.Point(507, 28);
            this.cmdLocalizarArquivo.Name = "cmdLocalizarArquivo";
            this.cmdLocalizarArquivo.ReadOnly = false;
            this.cmdLocalizarArquivo.Size = new System.Drawing.Size(27, 20);
            this.cmdLocalizarArquivo.TabIndex = 2;
            this.cmdLocalizarArquivo.TabStop = false;
            this.cmdLocalizarArquivo.Text = "...";
            this.cmdLocalizarArquivo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLocalizarArquivo.UseVisualStyleBackColor = true;
            this.cmdLocalizarArquivo.Click += new System.EventHandler(this.cmdLocalizarArquivo_Click);
            // 
            // txtFile
            // 
            this.txtFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFile.Coluna_LookUp = 0;
            this.txtFile.ControlSource = "";
            this.txtFile.Enabled = false;
            this.txtFile.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile.ForeColor = System.Drawing.Color.DimGray;
            this.txtFile.Grupo = "";
            this.txtFile.Incluir_QueryBy = true;
            this.txtFile.Location = new System.Drawing.Point(69, 28);
            this.txtFile.LookUp = false;
            this.txtFile.MensagemObrigatorio = "Campo obrigatório";
            this.txtFile.Name = "txtFile";
            this.txtFile.Obrigatorio = false;
            this.txtFile.Qtde_Casas_Decimais = 0;
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(438, 20);
            this.txtFile.SQLStatement = "";
            this.txtFile.Tabela = "";
            this.txtFile.Tabela_INNER = null;
            this.txtFile.TabIndex = 1;
            this.txtFile.TipoControles = CompSoft.TipoControle.Geral;
            this.txtFile.ValorAnterior = "";
            this.txtFile.Value = "";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(15, 31);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(48, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Arquivo:";
            // 
            // cf_GroupBox1
            // 
            this.cf_GroupBox1.Controls.Add(this.cf_Label2);
            this.cf_GroupBox1.Controls.Add(this.cboBanco);
            this.cf_GroupBox1.Controls.Add(this.cmdCarregar);
            this.cf_GroupBox1.Controls.Add(this.cmdLocalizarArquivo);
            this.cf_GroupBox1.Controls.Add(this.cf_Label1);
            this.cf_GroupBox1.Controls.Add(this.txtFile);
            this.cf_GroupBox1.ControlSource = "";
            this.cf_GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox1.Location = new System.Drawing.Point(5, 4);
            this.cf_GroupBox1.Name = "cf_GroupBox1";
            this.cf_GroupBox1.Size = new System.Drawing.Size(540, 86);
            this.cf_GroupBox1.Tabela = "";
            this.cf_GroupBox1.TabIndex = 0;
            this.cf_GroupBox1.TabStop = false;
            this.cf_GroupBox1.Text = "Arquivo de retorno do CNAB";
            this.cf_GroupBox1.Value = "";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(23, 59);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(40, 13);
            this.cf_Label2.TabIndex = 3;
            this.cf_Label2.Text = "Banco:";
            // 
            // cboBanco
            // 
            this.cboBanco.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboBanco.ControlSource = "";
            this.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanco.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboBanco.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBanco.ForeColor = System.Drawing.Color.DimGray;
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Grupo = "";
            this.cboBanco.Incluir_QueryBy = true;
            this.cboBanco.Incluir_Reg_Selecione = true;
            this.cboBanco.Location = new System.Drawing.Point(69, 54);
            this.cboBanco.MensagemObrigatorio = "Campo obrigatório";
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Obrigatorio = false;
            this.cboBanco.ReadOnly = false;
            this.cboBanco.Size = new System.Drawing.Size(276, 21);
            this.cboBanco.SQLStatement = "select Banco, Descr_Banco from bancos where inativo = 0 order by descr_banco";
            this.cboBanco.Tabela = "";
            this.cboBanco.Tabela_INNER = null;
            this.cboBanco.TabIndex = 4;
            this.cboBanco.ValorAnterior = null;
            this.cboBanco.Value = null;
            // 
            // cmdCarregar
            // 
            this.cmdCarregar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCarregar.ForeColor = System.Drawing.Color.Black;
            this.cmdCarregar.Grupo = "";
            this.cmdCarregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCarregar.Location = new System.Drawing.Point(388, 52);
            this.cmdCarregar.Name = "cmdCarregar";
            this.cmdCarregar.ReadOnly = false;
            this.cmdCarregar.Size = new System.Drawing.Size(119, 23);
            this.cmdCarregar.TabIndex = 5;
            this.cmdCarregar.TabStop = false;
            this.cmdCarregar.Text = "Carregar Retorno";
            this.cmdCarregar.UseVisualStyleBackColor = true;
            this.cmdCarregar.Click += new System.EventHandler(this.cmdCarregar_Click);
            // 
            // dgFile
            // 
            this.dgFile.Filter = "Todos os arquivos (*.*)|*.*";
            this.dgFile.RestoreDirectory = true;
            this.dgFile.Title = "Arquivo de retorno CNAB";
            // 
            // cf_DataGrid1
            // 
            this.cf_DataGrid1.Allow_Alter_Value_All_StatusForm = false;
            this.cf_DataGrid1.AllowEditRow = true;
            this.cf_DataGrid1.AllowUserToDeleteRows = false;
            this.cf_DataGrid1.BackgroundColor = System.Drawing.Color.DimGray;
            this.cf_DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cf_DataGrid1.Cancel_OnClick = true;
            this.cf_DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cf_DataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cf_DataGrid1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cf_DataGrid1.GridColor = System.Drawing.Color.DimGray;
            this.cf_DataGrid1.Location = new System.Drawing.Point(0, 96);
            this.cf_DataGrid1.MultiSelect = false;
            this.cf_DataGrid1.Name = "cf_DataGrid1";
            this.cf_DataGrid1.RowHeadersWidth = 24;
            this.cf_DataGrid1.ShowCellErrors = false;
            this.cf_DataGrid1.ShowCellToolTips = false;
            this.cf_DataGrid1.ShowRowErrors = false;
            this.cf_DataGrid1.Size = new System.Drawing.Size(552, 273);
            this.cf_DataGrid1.TabIndex = 1;
            this.cf_DataGrid1.TabStop = false;
            this.cf_DataGrid1.VirtualMode = true;
            // 
            // f0088
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 369);
            this.Controls.Add(this.cf_DataGrid1);
            this.Controls.Add(this.cf_GroupBox1);
            this.Name = "f0088";
            this.Text = "Carregar retorno CNAB";
            this.cf_GroupBox1.ResumeLayout(false);
            this.cf_GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cf_DataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CompSoft.cf_Bases.cf_Button cmdLocalizarArquivo;
        private CompSoft.cf_Bases.cf_TextBox txtFile;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox1;
        private CompSoft.cf_Bases.cf_Button cmdCarregar;
        private System.Windows.Forms.OpenFileDialog dgFile;
        private CompSoft.cf_Bases.cf_DataGrid cf_DataGrid1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_ComboBox cboBanco;
    }
}