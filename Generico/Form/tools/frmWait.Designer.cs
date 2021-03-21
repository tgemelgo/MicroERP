namespace CompSoft.Tools
{
    partial class frmWait
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
            this.lblTextoMensagem = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pProgressBar = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pProgressBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTextoMensagem
            // 
            this.lblTextoMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextoMensagem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoMensagem.Location = new System.Drawing.Point(96, 1);
            this.lblTextoMensagem.Name = "lblTextoMensagem";
            this.lblTextoMensagem.Size = new System.Drawing.Size(386, 82);
            this.lblTextoMensagem.TabIndex = 2;
            this.lblTextoMensagem.Text = "lblTextoMensagem";
            this.lblTextoMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTextoMensagem.UseWaitCursor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CompSoft.Properties.Resources.Wait_Silver;
            this.pictureBox1.InitialImage = global::CompSoft.Properties.Resources.Wait_Silver;
            this.pictureBox1.Location = new System.Drawing.Point(12, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // pProgressBar
            // 
            this.pProgressBar.Location = new System.Drawing.Point(12, 91);
            this.pProgressBar.Name = "pProgressBar";
            this.pProgressBar.Properties.AllowFocused = false;
            this.pProgressBar.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.pProgressBar.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.pProgressBar.Properties.ShowTitle = true;
            this.pProgressBar.ShowToolTips = false;
            this.pProgressBar.Size = new System.Drawing.Size(461, 23);
            this.pProgressBar.TabIndex = 4;
            this.pProgressBar.UseWaitCursor = true;
            this.pProgressBar.Visible = false;
            // 
            // frmWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 84);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pProgressBar);
            this.Controls.Add(this.lblTextoMensagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmWait";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pProgressBar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTextoMensagem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.ProgressBarControl pProgressBar;
    }
}