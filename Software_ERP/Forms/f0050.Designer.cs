namespace ERP.Forms
{
    partial class f0050
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
            this.cmdGerar = new CompSoft.cf_Bases.cf_Button();
            this.prdDataEmissao = new CompSoft.cf_Bases.cf_Periodo();
            this.SuspendLayout();
            // 
            // cmdGerar
            // 
            this.cmdGerar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGerar.ForeColor = System.Drawing.Color.Black;
            this.cmdGerar.Grupo = string.Empty;
            this.cmdGerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdGerar.Location = new System.Drawing.Point(176, 68);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Size = new System.Drawing.Size(97, 23);
            this.cmdGerar.TabIndex = 0;
            this.cmdGerar.TabStop = false;
            this.cmdGerar.Text = "Gerar consiliação";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // prdDataEmissao
            // 
            this.prdDataEmissao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prdDataEmissao.Location = new System.Drawing.Point(9, 10);
            this.prdDataEmissao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prdDataEmissao.Name = "prdDataEmissao";
            this.prdDataEmissao.Size = new System.Drawing.Size(264, 51);
            this.prdDataEmissao.TabIndex = 1;
            // 
            // f0050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 98);
            this.Controls.Add(this.prdDataEmissao);
            this.Controls.Add(this.cmdGerar);
            this.Name = "f0050";
            this.Text = "Consiliação financeira";
            this.ResumeLayout(false);

        }

        #endregion

        private CompSoft.cf_Bases.cf_Button cmdGerar;
        private CompSoft.cf_Bases.cf_Periodo prdDataEmissao;
    }
}