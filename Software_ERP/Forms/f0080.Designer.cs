namespace ERP.Forms
{
    partial class f0080
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
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox1 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_TextBox2 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdLocalizarLogo = new CompSoft.cf_Bases.cf_Button();
            this.foFile_Open = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(9, 15);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(68, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Núm. Banco:";
            // 
            // cf_TextBox1
            // 
            this.cf_TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox1.Coluna_LookUp = 0;
            this.cf_TextBox1.ControlSource = "banco";
            this.cf_TextBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox1.Grupo = "";
            this.cf_TextBox1.Incluir_QueryBy = true;
            this.cf_TextBox1.Location = new System.Drawing.Point(83, 12);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = false;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(72, 20);
            this.cf_TextBox1.SQLStatement = "";
            this.cf_TextBox1.Tabela = "bancos";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 1;
            this.cf_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Inteiro;
            this.cf_TextBox1.ValorAnterior = "";
            this.cf_TextBox1.Value = "";
            // 
            // cf_TextBox2
            // 
            this.cf_TextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox2.Coluna_LookUp = 0;
            this.cf_TextBox2.ControlSource = "descr_banco";
            this.cf_TextBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox2.Grupo = "";
            this.cf_TextBox2.Incluir_QueryBy = true;
            this.cf_TextBox2.Location = new System.Drawing.Point(83, 38);
            this.cf_TextBox2.LookUp = false;
            this.cf_TextBox2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox2.Name = "cf_TextBox2";
            this.cf_TextBox2.Obrigatorio = false;
            this.cf_TextBox2.Qtde_Casas_Decimais = 0;
            this.cf_TextBox2.Size = new System.Drawing.Size(203, 20);
            this.cf_TextBox2.SQLStatement = "";
            this.cf_TextBox2.Tabela = "bancos";
            this.cf_TextBox2.Tabela_INNER = null;
            this.cf_TextBox2.TabIndex = 3;
            this.cf_TextBox2.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox2.ValorAnterior = "";
            this.cf_TextBox2.Value = "";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(20, 41);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 2;
            this.cf_Label2.Text = "Descrição:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(128, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // cmdLocalizarLogo
            // 
            this.cmdLocalizarLogo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocalizarLogo.ForeColor = System.Drawing.Color.Black;
            this.cmdLocalizarLogo.Grupo = "";
            this.cmdLocalizarLogo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLocalizarLogo.Location = new System.Drawing.Point(47, 94);
            this.cmdLocalizarLogo.Name = "cmdLocalizarLogo";
            this.cmdLocalizarLogo.ReadOnly = false;
            this.cmdLocalizarLogo.Size = new System.Drawing.Size(75, 23);
            this.cmdLocalizarLogo.TabIndex = 5;
            this.cmdLocalizarLogo.Text = "Localizar";
            this.cmdLocalizarLogo.UseVisualStyleBackColor = true;
            this.cmdLocalizarLogo.Click += new System.EventHandler(this.cmdLocalizarLogo_Click);
            // 
            // foFile_Open
            // 
            this.foFile_Open.Filter = "Arquivos JPEG|*.jpg|Arquivos GIF|*.gif|Arquivos PNG|*.png|Todos os arquivos|*.*";
            this.foFile_Open.InitialDirectory = "c:\\";
            this.foFile_Open.RestoreDirectory = true;
            this.foFile_Open.Title = "Localizar logo do Banco";
            // 
            // f0080
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 128);
            this.Controls.Add(this.cmdLocalizarLogo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cf_TextBox2);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_TextBox1);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "bancos";
            this.Name = "f0080";
            this.Text = "Bancos";
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0080_user_AfterRefreshData);
            this.user_AfterClear += new CompSoft.FormSet.AfterClear(this.f0080_user_AfterClear);
            this.user_FormStatus_Change += new CompSoft.FormSet.FormStatus_Change(this.f0080_user_FormStatus_Change);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox2;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CompSoft.cf_Bases.cf_Button cmdLocalizarLogo;
        private System.Windows.Forms.OpenFileDialog foFile_Open;
    }
}