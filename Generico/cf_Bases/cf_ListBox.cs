using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(ListBox)), ToolboxItem(true)]
    public partial class cf_ListBox : ListBox
    {
        private string sSQLStatement = string.Empty;

        //-- Propriedades do objeto.
        private Color cOldBackColor,
            cOldForeColor;

        /// <summary>
        /// Query que alimentará os dados do controle
        /// </summary>
        [Category("CompSoft")]
        public string SQLStatement
        {
            get { return sSQLStatement; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    sSQLStatement = value;

                    this.Carregar_List();
                }
            }
        }

        public void Carregar_List()
        {
            if (!string.IsNullOrEmpty(compFrameWork.Propriedades.StringConexao))
            {
                DataTable dt = Data.SQL.Select(sSQLStatement, "x", false);
                this.DataSource = dt;
                this.DisplayMember = dt.Columns[1].Caption;
                this.ValueMember = dt.Columns[0].Caption;
            }
        }

        public cf_ListBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        private void cf_ListBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = cOldBackColor;
            this.ForeColor = cOldForeColor;
        }

        private void cf_ListBox_Enter(object sender, EventArgs e)
        {
            //-- Salva a configuração inicial
            cOldBackColor = this.BackColor;
            cOldForeColor = this.ForeColor;

            //-- Muda para a cor definida.
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
        }

        private void cf_ListBox_Layout(object sender, LayoutEventArgs e)
        {
            this.ForeColor = Color.DimGray;
            this.BackColor = Color.WhiteSmoke;
        }
    }
}