using System;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0088 : CompSoft.formBase
    {
        public f0088()
        {
            InitializeComponent();
        }

        private void cmdLocalizarArquivo_Click(object sender, EventArgs e)
        {
            if (dgFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFile.Text = dgFile.FileName;
            }
        }

        private void cmdCarregar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (this.cboBanco.SelectedIndex <= 0)
                sb.AppendLine("   -Selecione o banco para que o arquivo seja carregado no layout correto.");

            if (string.IsNullOrEmpty(this.txtFile.Text))
                sb.AppendLine("   -Selecione o arquivo de retorno do CNAB para carregar.");

            if (sb.Length > 0)
            {
                sb.Insert(0, "PREENCHIMENTO OBRIGATÓRIO\r\n\r\n");

                CompSoft.compFrameWork.MsgBox.Show(sb.ToString()
                            , "Atenção"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
            }
            else
            {
                //-- Define o bancos
                BoletoNet.IBanco banco = new BoletoNet.Banco(Convert.ToInt32(this.cboBanco.SelectedValue));

                CNAB.CNAB cnab = new CNAB.CNAB();
                cnab.Arquivo_Retorno_Banco(this.txtFile.Text, banco);
            }
        }
    }
}