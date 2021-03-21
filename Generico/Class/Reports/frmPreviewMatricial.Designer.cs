namespace CompSoft.Reports
{
    partial class frmPreviewMatricial
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
            this.txtImpressoa = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtImpressoa
            // 
            this.txtImpressoa.BackColor = System.Drawing.Color.White;
            this.txtImpressoa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImpressoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImpressoa.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpressoa.Location = new System.Drawing.Point(0, 0);
            this.txtImpressoa.Multiline = true;
            this.txtImpressoa.Name = "txtImpressoa";
            this.txtImpressoa.ReadOnly = true;
            this.txtImpressoa.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtImpressoa.Size = new System.Drawing.Size(744, 525);
            this.txtImpressoa.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtImpressoa, "Para fechar a tela de PREVIEW precione ESC");
            this.txtImpressoa.WordWrap = false;
            // 
            // frmPreviewMatricial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 525);
            this.Controls.Add(this.txtImpressoa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.KeyPreview = true;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "frmPreviewMatricial";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview de impressões em modo texto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImpressoa;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}