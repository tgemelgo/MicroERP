using CompSoft.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(Button)), ToolboxItem(true)]
    public partial class cf_Button : Button, IBaseControl
    {
        private string sGroup_Enable = string.Empty;

        #region Propriedades

        /// <summary>
        /// Identifica se o grupo ou grupos que o controle pertence.
        /// </summary>
        [Category("CompSoft")]
        public string Grupo
        {
            get { return sGroup_Enable; }
            set { sGroup_Enable = value; }
        }

        #endregion Propriedades

        public cf_Button()
        {
            InitializeComponent();
            this.UseVisualStyleBackColor = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        private void cf_Button_Layout(object sender, LayoutEventArgs e)
        {
            this.TabStop = false;
        }

        #region IBaseControl Members

        public bool ReadOnly
        {
            get { return !this.Enabled; }
            set { this.Enabled = !value; }
        }

        #endregion IBaseControl Members
    }
}