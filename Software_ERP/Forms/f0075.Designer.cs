namespace ERP.Forms
{
    partial class f0075
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
            this.cf_TextBox2 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.cf_TextBox1 = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.chkCliente = new CompSoft.cf_Bases.cf_CheckBox();
            this.cf_CheckBox1 = new CompSoft.cf_Bases.cf_CheckBox();
            this.cmdLocalizar = new CompSoft.cf_Bases.cf_Button();
            this.cf_Label14 = new CompSoft.cf_Bases.cf_Label();
            this.foFile_Open = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cf_TextBox2
            // 
            this.cf_TextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cf_TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cf_TextBox2.Coluna_LookUp = 0;
            this.cf_TextBox2.ControlSource = "desc_banco";
            this.cf_TextBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_TextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.cf_TextBox2.Grupo = "";
            this.cf_TextBox2.Incluir_QueryBy = true;
            this.cf_TextBox2.Location = new System.Drawing.Point(81, 35);
            this.cf_TextBox2.LookUp = false;
            this.cf_TextBox2.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox2.Name = "cf_TextBox2";
            this.cf_TextBox2.Obrigatorio = true;
            this.cf_TextBox2.Qtde_Casas_Decimais = 0;
            this.cf_TextBox2.Size = new System.Drawing.Size(274, 20);
            this.cf_TextBox2.SQLStatement = "";
            this.cf_TextBox2.Tabela = "bancos";
            this.cf_TextBox2.Tabela_INNER = null;
            this.cf_TextBox2.TabIndex = 7;
            this.cf_TextBox2.TipoControles = CompSoft.TipoControle.Geral;
            this.cf_TextBox2.ValorAnterior = "";
            this.cf_TextBox2.Value = "";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(20, 37);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 6;
            this.cf_Label2.Text = "Descrição:";
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
            this.cf_TextBox1.Location = new System.Drawing.Point(81, 8);
            this.cf_TextBox1.LookUp = false;
            this.cf_TextBox1.MensagemObrigatorio = "Campo obrigatório";
            this.cf_TextBox1.Name = "cf_TextBox1";
            this.cf_TextBox1.Obrigatorio = true;
            this.cf_TextBox1.Qtde_Casas_Decimais = 0;
            this.cf_TextBox1.Size = new System.Drawing.Size(69, 20);
            this.cf_TextBox1.SQLStatement = "";
            this.cf_TextBox1.Tabela = "bancos";
            this.cf_TextBox1.Tabela_INNER = null;
            this.cf_TextBox1.TabIndex = 5;
            this.cf_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cf_TextBox1.TipoControles = CompSoft.TipoControle.Inteiro;
            this.cf_TextBox1.ValorAnterior = "";
            this.cf_TextBox1.Value = "";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(20, 10);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(44, 13);
            this.cf_Label1.TabIndex = 4;
            this.cf_Label1.Text = "Código:";
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.ControlSource = "despresar_digito_Ag";
            this.chkCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCliente.Grupo = "";
            this.chkCliente.Incluir_QueryBy = false;
            this.chkCliente.Location = new System.Drawing.Point(81, 61);
            this.chkCliente.MensagemObrigatorio = "";
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Obrigatorio = false;
            this.chkCliente.ReadOnly = false;
            this.chkCliente.Size = new System.Drawing.Size(144, 17);
            this.chkCliente.Tabela = "bancos";
            this.chkCliente.Tabela_INNER = null;
            this.chkCliente.TabIndex = 8;
            this.chkCliente.Text = "Despresar digito agência";
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.ValorAnterior = false;
            this.chkCliente.Value = false;
            // 
            // cf_CheckBox1
            // 
            this.cf_CheckBox1.AutoSize = true;
            this.cf_CheckBox1.ControlSource = "despresar_digito_Cc";
            this.cf_CheckBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox1.Grupo = "";
            this.cf_CheckBox1.Incluir_QueryBy = false;
            this.cf_CheckBox1.Location = new System.Drawing.Point(81, 84);
            this.cf_CheckBox1.MensagemObrigatorio = "";
            this.cf_CheckBox1.Name = "cf_CheckBox1";
            this.cf_CheckBox1.Obrigatorio = false;
            this.cf_CheckBox1.ReadOnly = false;
            this.cf_CheckBox1.Size = new System.Drawing.Size(178, 17);
            this.cf_CheckBox1.Tabela = "bancos";
            this.cf_CheckBox1.Tabela_INNER = null;
            this.cf_CheckBox1.TabIndex = 9;
            this.cf_CheckBox1.Text = "Despresar digito conta corrente";
            this.cf_CheckBox1.UseVisualStyleBackColor = true;
            this.cf_CheckBox1.ValorAnterior = false;
            this.cf_CheckBox1.Value = false;
            // 
            // cmdLocalizar
            // 
            this.cmdLocalizar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocalizar.ForeColor = System.Drawing.Color.Black;
            this.cmdLocalizar.Grupo = "";
            this.cmdLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLocalizar.Location = new System.Drawing.Point(81, 175);
            this.cmdLocalizar.Name = "cmdLocalizar";
            this.cmdLocalizar.ReadOnly = false;
            this.cmdLocalizar.Size = new System.Drawing.Size(76, 23);
            this.cmdLocalizar.TabIndex = 45;
            this.cmdLocalizar.TabStop = false;
            this.cmdLocalizar.Text = "L&ocalizar";
            this.cmdLocalizar.UseVisualStyleBackColor = true;
            this.cmdLocalizar.Click += new System.EventHandler(this.cmdLocalizar_Click);
            // 
            // cf_Label14
            // 
            this.cf_Label14.AutoSize = true;
            this.cf_Label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label14.Location = new System.Drawing.Point(20, 107);
            this.cf_Label14.Name = "cf_Label14";
            this.cf_Label14.Size = new System.Drawing.Size(34, 13);
            this.cf_Label14.TabIndex = 46;
            this.cf_Label14.Text = "Logo:";
            // 
            // foFile_Open
            // 
            this.foFile_Open.Filter = "Arquivos de imagem|*.jpg;*.gif;*.bmp;*.png|Todos os arquivos|*.*";
            this.foFile_Open.Title = "Logo Banco";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(81, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // f0075
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(367, 210);
            this.Controls.Add(this.cmdLocalizar);
            this.Controls.Add(this.cf_Label14);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cf_CheckBox1);
            this.Controls.Add(this.chkCliente);
            this.Controls.Add(this.cf_TextBox2);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.cf_TextBox1);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "bancos";
            this.Name = "f0075";
            this.Text = "Cadastro de Bancos";
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0075_user_AfterRefreshData);
            this.user_AfterNew += new CompSoft.FormSet.AfterNew(this.f0075_user_AfterNew);
            this.user_AfterClear += new CompSoft.FormSet.AfterClear(this.f0075_user_AfterClear);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_TextBox cf_TextBox2;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox cf_TextBox1;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_CheckBox chkCliente;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox1;
        private CompSoft.cf_Bases.cf_Button cmdLocalizar;
        private CompSoft.cf_Bases.cf_Label cf_Label14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog foFile_Open;
    }
}
