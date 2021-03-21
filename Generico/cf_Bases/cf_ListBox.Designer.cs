namespace CompSoft.cf_Bases
{
    partial class cf_ListBox
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

            if (this.DataSource != null)
            {
                switch (this.DataSource.GetType().Name)
                { 
                    case "DataTable":
                        ((System.Data.DataTable)this.DataSource).Dispose();
                        break;

                    case "DataView":
                        ((System.Data.DataView)this.DataSource).Dispose();
                        break;
                }

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
            // cf_ListBox
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.UseTabStops = false;
            this.Leave += new System.EventHandler(this.cf_ListBox_Leave);
            this.Enter += new System.EventHandler(this.cf_ListBox_Enter);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.cf_ListBox_Layout);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
