namespace CompSoft.cf_Bases
{
    partial class cf_TextBox
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

            if (dtLookUp_Retorno != null)
            {
                dtLookUp_Retorno.Table.Dispose();
                dtLookUp_Retorno = null;
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
            // cf_TextBox
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.cf_TextBox_Layout);
            this.Leave += new System.EventHandler(this.cf_TextBox_Leave);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cf_TextBox_KeyPress);
            this.Enter += new System.EventHandler(this.cf_TextBox_Enter);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
