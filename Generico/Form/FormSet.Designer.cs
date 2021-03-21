namespace CompSoft
{
    partial class FormSet
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

            sMainTabela = null;
            sTituloForm = null;

            if (dtDataSetLocal != null && dtDataSetLocal.Tables.Count > 0)
            {
                for (int i = 1; i <= dtDataSetLocal.Tables.Count; i++)
                {
                    dtDataSetLocal.Tables[i - 1].Clear();
                    dtDataSetLocal.Tables[i - 1].Dispose();
                }

                dtDataSetLocal.Dispose();
            }

            dtDataSetLocal = null;

            iCodPrimaryKey = null;
            iTabelas = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 333);
            this.Name = "FormSet";
            this.ResumeLayout(false);

        }

        #endregion
    }
}