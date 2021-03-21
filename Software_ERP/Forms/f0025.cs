using CompSoft.compFrameWork;
using System;

namespace ERP.Forms
{
    public partial class f0025 : CompSoft.Tools.frmAdvancedSearch
    {
        public f0025()
        {
            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            string sRetorno = string.Empty;

            if (!string.IsNullOrEmpty(sRetorno))
                sRetorno += " AND ";
            sRetorno += " Valor_Pagar_Parcela > 0 ";

            return sRetorno;
        }

        private void f0025_Load(object sender, EventArgs e)
        {
            try
            {
                Funcoes func;
                this.cboTipoMovimento.SelectedValue = Convert.ToInt32(func.Busca_Propriedade("Movimento_Padrao_CP"));
            }
            catch { }
        }
    }
}