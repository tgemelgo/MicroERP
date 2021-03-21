namespace CompSoft.cf_Bases
{
    partial class cf_AcaoGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdExcluir = new CompSoft.cf_Bases.cf_Button();
            this.cmdNovo = new CompSoft.cf_Bases.cf_Button();
            this.SuspendLayout();
            // 
            // cmdExcluir
            // 
            this.cmdExcluir.BackColor = System.Drawing.Color.Transparent;
            this.cmdExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdExcluir.FlatAppearance.BorderSize = 0;
            this.cmdExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExcluir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcluir.ForeColor = System.Drawing.Color.Black;
            this.cmdExcluir.Grupo = "";
            this.cmdExcluir.Image = global::CompSoft.Properties.Resources.Grid_Delete;
            this.cmdExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExcluir.Location = new System.Drawing.Point(0, 25);
            this.cmdExcluir.Name = "cmdExcluir";
            this.cmdExcluir.ReadOnly = false;
            this.cmdExcluir.Size = new System.Drawing.Size(23, 27);
            this.cmdExcluir.TabIndex = 2;
            this.cmdExcluir.TabStop = false;
            this.cmdExcluir.UseVisualStyleBackColor = false;
            this.cmdExcluir.EnabledChanged += new System.EventHandler(this.cmdExcluir_EnabledChanged);
            this.cmdExcluir.Click += new System.EventHandler(this.cmdExcluir_Click);
            // 
            // cmdNovo
            // 
            this.cmdNovo.BackColor = System.Drawing.Color.Transparent;
            this.cmdNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdNovo.FlatAppearance.BorderSize = 0;
            this.cmdNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNovo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNovo.ForeColor = System.Drawing.Color.Black;
            this.cmdNovo.Grupo = "";
            this.cmdNovo.Image = global::CompSoft.Properties.Resources.Grid_Add;
            this.cmdNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNovo.Location = new System.Drawing.Point(0, 0);
            this.cmdNovo.Name = "cmdNovo";
            this.cmdNovo.ReadOnly = false;
            this.cmdNovo.Size = new System.Drawing.Size(23, 27);
            this.cmdNovo.TabIndex = 0;
            this.cmdNovo.TabStop = false;
            this.cmdNovo.UseVisualStyleBackColor = false;
            this.cmdNovo.Click += new System.EventHandler(this.cmdNovo_Click);
            // 
            // cf_AcaoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdExcluir);
            this.Controls.Add(this.cmdNovo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "cf_AcaoGrid";
            this.Size = new System.Drawing.Size(24, 55);
            this.ResumeLayout(false);

        }

        #endregion

        private CompSoft.cf_Bases.cf_Button cmdNovo;
        private CompSoft.cf_Bases.cf_Button cmdExcluir;
    }
}
