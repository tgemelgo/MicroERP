using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Reports
{
    internal partial class frmPreviewMatricial : formBase
    {
        public string Arquivo_Impressao
        {
            set { this.txtImpressoa.Text = value; }
        }

        public frmPreviewMatricial()
        {
            InitializeComponent();
        }

        public frmPreviewMatricial(string sArquivo_Impressao)
        {
            InitializeComponent();

            this.txtImpressoa.Text = sArquivo_Impressao;
            this.txtImpressoa.SelectionLength = 0;
            this.txtImpressoa.SelectionStart = 0;
            this.txtImpressoa.SelectedText = string.Empty;
            this.ShowDialog();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}