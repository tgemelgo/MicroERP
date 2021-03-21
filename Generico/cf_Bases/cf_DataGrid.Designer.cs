namespace CompSoft.cf_Bases
{
    partial class cf_DataGrid
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

            try
            {
                f = null;
            }
            catch { }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cf_DataGrid
            // 
            this.AllowUserToDeleteRows = false;
            this.BackgroundColor = System.Drawing.Color.DimGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GridColor = System.Drawing.Color.DimGray;
            this.MultiSelect = false;
            this.RowHeadersWidth = 24;
            this.ShowCellErrors = false;
            this.ShowCellToolTips = false;
            this.ShowRowErrors = false;
            this.TabStop = false;
            this.VirtualMode = true;
            this.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.cf_DataGrid_DataBindingComplete);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
