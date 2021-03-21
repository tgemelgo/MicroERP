namespace CompSoft.cf_Bases
{
    partial class cf_ComboBox
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

            if (ep != null)
            {
                ep.Dispose();
                ep = null;
            }

            if (this.DataSource != null)
            {
                ((System.Data.DataTable)this.DataSource).Dispose();
                this.DataSource = null;
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
            this.SuspendLayout();
            // 
            // cf_ComboBox
            // 
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Validating += new System.ComponentModel.CancelEventHandler(this.cf_ComboBox_Validating);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.cf_ComboBox_Layout);
            this.Leave += new System.EventHandler(this.cf_ComboBox_Leave);
            this.Enter += new System.EventHandler(this.cf_ComboBox_Enter);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
