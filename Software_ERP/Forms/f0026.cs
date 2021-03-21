using CompSoft.compFrameWork;
using System;

namespace ERP.Forms
{
    public partial class f0026 : CompSoft.Tools.frmAdvancedSearch
    {
        public f0026()
        {
            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            string sRetorno = string.Empty;

            if (!string.IsNullOrEmpty(sRetorno))
                sRetorno += " AND ";
            sRetorno += " Valor_Receber_Parcela > 0 ";

            return sRetorno;
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {
            this.grdResultado.Columns[1].Visible = false;
            this.grdResultado.Columns[2].Visible = false;
        }

        private void f0025_Load(object sender, EventArgs e)
        {
            try
            {
                Funcoes func;
                this.cboTipoMovimento.SelectedValue = Convert.ToInt32(func.Busca_Propriedade("Movimento_Padrao_CR"));
            }
            catch { }
        }
    }
}