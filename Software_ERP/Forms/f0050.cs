using CompSoft.compFrameWork;
using CompSoft.Tools;
using System;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0050 : CompSoft.formBase
    {
        public f0050()
        {
            InitializeComponent();
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Confirma a geração da consiliação financeira do período");
            sb.Append(" '");
            sb.Append(this.prdDataEmissao.Data_Inicial.ToShortDateString());
            sb.Append("' a '");
            sb.Append(this.prdDataEmissao.Data_Termino.ToShortDateString());
            sb.Append("'?");

            DialogResult dr = MsgBox.Show(sb.ToString()
                , "Atenção"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                frmWait f = new frmWait("Aguarde, gerando consiliação financeira", frmWait.Tipo_Imagem.Wait);

                Financeiro.ConsiliacaoFinanceira cf = new Financeiro.ConsiliacaoFinanceira();
                cf.Gerar_Consiliacao(this.prdDataEmissao.Data_Inicial, this.prdDataEmissao.Data_Termino);

                f.Close();
                f.Dispose();

                MsgBox.Show("Consiliação financeira realizada com sucesso!"
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
        }
    }
}