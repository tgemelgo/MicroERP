namespace ERP.Forms
{
    partial class f0079
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
            this.lstEmpresas = new CompSoft.cf_Bases.cf_ListBox();
            this.cmdSelecionar = new CompSoft.cf_Bases.cf_Button();
            this.SuspendLayout();
            // 
            // lstEmpresas
            // 
            this.lstEmpresas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEmpresas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstEmpresas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstEmpresas.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmpresas.ForeColor = System.Drawing.Color.DimGray;
            this.lstEmpresas.ItemHeight = 23;
            this.lstEmpresas.Location = new System.Drawing.Point(2, 6);
            this.lstEmpresas.Name = "lstEmpresas";
            this.lstEmpresas.Size = new System.Drawing.Size(602, 255);
            this.lstEmpresas.SQLStatement = "Select empresa, nome_fantasia from empresas order by nome_fantasia";
            this.lstEmpresas.TabIndex = 0;
            this.lstEmpresas.UseTabStops = false;
            this.lstEmpresas.DoubleClick += new System.EventHandler(this.lstEmpresas_DoubleClick);
            this.lstEmpresas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstEmpresas_KeyPress);
            // 
            // cmdSelecionar
            // 
            this.cmdSelecionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelecionar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelecionar.ForeColor = System.Drawing.Color.Black;
            this.cmdSelecionar.Grupo = "";
            this.cmdSelecionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSelecionar.Location = new System.Drawing.Point(505, 264);
            this.cmdSelecionar.Name = "cmdSelecionar";
            this.cmdSelecionar.ReadOnly = false;
            this.cmdSelecionar.Size = new System.Drawing.Size(99, 23);
            this.cmdSelecionar.TabIndex = 1;
            this.cmdSelecionar.TabStop = false;
            this.cmdSelecionar.Text = "Selecionar";
            this.cmdSelecionar.UseVisualStyleBackColor = true;
            this.cmdSelecionar.Click += new System.EventHandler(this.cf_Button1_Click);
            // 
            // f0079
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 290);
            this.ControlBox = false;
            this.Controls.Add(this.cmdSelecionar);
            this.Controls.Add(this.lstEmpresas);
            this.Name = "f0079";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresas disponiveis";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private CompSoft.cf_Bases.cf_ListBox lstEmpresas;
        private CompSoft.cf_Bases.cf_Button cmdSelecionar;

    }
}