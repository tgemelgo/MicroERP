using CompSoft.NFe;
using CompSoft.Tools;
using System;
using System.Data;
using System.Text;

namespace ERP.Forms
{
    public partial class f0073 : ERP.Forms.f0070
    {
        public f0073()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   notas_fiscais_lotes.*");
            sb.AppendLine(" , mrn.descricao as 'Descricao_NFp'");
            sb.AppendLine(" , mrnfe.descricao as 'Descricao_NFe'");
            sb.AppendLine(" , nf.nfe_protocolo");
            sb.AppendLine(" , nf.nfe_protocolo_data");
            sb.AppendLine(" from notas_fiscais_lotes");
            sb.AppendLine("     left outer join notas_fiscais_lotes_itens nfli on nfli.nota_fiscal_lote = notas_fiscais_lotes.nota_fiscal_lote");
            sb.AppendLine("     left outer join notas_fiscais nf on nf.nota_fiscal = nfli.nota_fiscal");
            sb.AppendLine("  left outer join mensagens_retorno_nfp mrn on mrn.codigo_mensagem_retorno = notas_fiscais_lotes.codigo_mensagem_retorno_NFP");
            sb.AppendLine("  left outer join mensagens_retorno_nfe mrnfe on mrnfe.codigo_mensagem_retorno = notas_fiscais_lotes.codigo_mensagem_retorno_NFE");
            this.Tabelas[0].SQLStatement = sb.ToString();

            InitializeComponent();
        }

        private void f0073_user_AfterRefreshData()
        {
            if (this.chkNFe.Checked)
                this.cmdEnviarXMLEmail.Visible = true;
            else
                this.cmdEnviarXMLEmail.Visible = false;

            if (this.cboCodMensagem_NFe.SelectedValue != null && this.cboCodMensagem_NFe.SelectedValue.ToString() == "100")
                this.cmdEnviarXMLEmail.Enabled = true;
            else
                this.cmdEnviarXMLEmail.Enabled = false;
        }

        private void cmdEnviarXMLEmail_Click(object sender, EventArgs e)
        {
            frmWait f = new frmWait("Aguarde, enviando e-mail com NF-e em anexo...", frmWait.Tipo_Imagem.Informacao);

            foreach (DataRow row in this.DataSetLocal.Tables["Notas_Fiscais_Lotes_Itens"].Select())
            {
                Dados_Arquivo_NFe daNFe = new Dados_Arquivo_NFe();
                daNFe.Carregar_Dados(Convert.ToInt32(row["Nota_fiscal_Lote"]));

                ERP.NFe.Enviar_XML_Email envMail_Nfe;
                envMail_Nfe.Enviar_XML(daNFe);
            }

            f.Close();
            f.Dispose();
        }
    }
}