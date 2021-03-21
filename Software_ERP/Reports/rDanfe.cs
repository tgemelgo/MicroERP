using System;
using System.Collections.Generic;
using System.Data;

namespace ERP.Reports
{
    public partial class rDanfe : DevExpress.XtraReports.UI.XtraReport
    {
        private string sNota_Fiscal = string.Empty;

        public rDanfe(DataSet dataset)
        {
            InitializeComponent();

            this.DataSource = dataset;
            this.DataMember = "Notas_Fiscais";
            this.DetailReport1.DataMember = "Notas_Fiscais.vw_DadosCapa_DANFE_vw_DadosItens_DANFE";
        }

        private void imgLogo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (CompSoft.compFrameWork.Propriedades.Imagem_Relatorio_Lado_Esquerdo != null)
                this.imgLogo.Image = CompSoft.compFrameWork.Propriedades.Imagem_Relatorio_Lado_Esquerdo;
        }

        private void lblNumeroPagina_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void lblFatura_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int iNota_Fiscal = (Int32)GetCurrentColumnValue("Nota_Fiscal");
            DataRow[] fRow = ((DataSet)this.DataSource).Tables["Notas_Fiscais_Duplicatas"].Select("Nota_Fiscal = " + iNota_Fiscal.ToString());

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (DataRow row in fRow)
            {
                if (sb.Length > 0)
                    sb.Append(" | ");

                sb.Append(row["Numero_Duplicata"]);
                sb.Append(" R$ ");
                sb.Append(Convert.ToDecimal(row["Valor_Duplicata"]).ToString("n2"));
                sb.Append(" ");
                sb.Append(Convert.ToDateTime(row["Data_Vencimento"]).ToString("dd/MM/yyyy"));
            }
            this.lblFatura.Text = sb.ToString();
        }

        private void lblEmpresaRecibo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sRazao_Social = GetCurrentColumnValue("Razao_Social_Empresa").ToString();
            this.lblEmpresaRecibo.Text = "RECEBEMOS DE " + sRazao_Social.Trim().ToUpper() + " OS PRODUTOS CONSTANTES DA NOTA FISCAL INDICADA ABAIXO";
        }

        private void xrLabel122_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sObs = "Pedido: " + GetCurrentColumnValue("Pedido").ToString();
            if (!string.IsNullOrEmpty(GetCurrentColumnValue("Observacao").ToString()))
                sObs += " " + GetCurrentColumnValue("Observacao").ToString();

            //-- Captura as mensagens NF-e
            ERP.NFe.Mensagens_NFe mens_nfe = new ERP.NFe.Mensagens_NFe();
            IList<string> ilMensagens = mens_nfe.Captura_Mensagem(Convert.ToInt32(GetCurrentColumnValue("Nota_Fiscal")));
            foreach (string sMensagem in ilMensagens)
                sObs += " - " + sMensagem;

            this.xrLabel122.Text = sObs;

            //-- Marca como impressa.
            CompSoft.Data.SQL.ExecuteNonQuery(string.Format("update notas_fiscais set Impressa = 1 where nota_fiscal = {0}"
                    , GetCurrentColumnValue("Nota_Fiscal")));
        }

        private void lblProtocoloAutorizacao_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lblProtocoloAutorizacao.Text = string.Format("{0} - {1}"
                    , GetCurrentColumnValue("NFe_Protocolo")
                    , Convert.ToDateTime(GetCurrentColumnValue("NFe_Protocolo_Data")).ToString("dd/MM/yyyy HH:mm:ss"));
        }

        private void xrLabel55_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("Valor_Base_Substituicao_ICMS") != DBNull.Value)
            {
                this.xrLabel55.Text = string.Empty;
            }
        }

        private void xrLabel56_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("Valor_Base_Substituicao_ICMS") != DBNull.Value)
            {
                this.xrLabel56.Text = string.Empty;
            }
        }

        private void xrLabel87_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrLabel87.Text.Length <= 11)
                xrLabel87.Text = Convert.ToDouble(xrLabel87.Text).ToString(@"000\.000\.000\-00");
            else
                xrLabel87.Text = Convert.ToDouble(xrLabel87.Text).ToString(@"00\.000\.000\/0000\-00");
        }

        private void xrLabel41_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel41.Text = xrLabel41.Text.ToUpper();
        }

        private void xrLabel40_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrLabel40.Text))
                xrLabel40.Text = Convert.ToDecimal(xrLabel40.Text).ToString(@"00000\-000");
        }

        private void xrLabel39_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel39.Text = xrLabel39.Text.ToUpper();
        }

        private void xrLabel38_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel38.Text += ", " + GetCurrentColumnValue("Numero_Correspondencia").ToString();
        }

        private void xrLabel34_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrLabel34.Text.Length <= 11)
                xrLabel34.Text = Convert.ToDouble(xrLabel34.Text).ToString(@"000\.000\.000\-00");
            else
                xrLabel34.Text = Convert.ToDouble(xrLabel34.Text).ToString(@"00\.000\.000\/0000\-00");
        }

        private void xrLabel21_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrLabel21.Text.Length <= 11)
                xrLabel21.Text = Convert.ToDouble(xrLabel21.Text).ToString(@"000\.000\.000\-00");
            else
                xrLabel21.Text = Convert.ToDouble(xrLabel21.Text).ToString(@"00\.000\.000\/0000\-00");
        }

        private void xrLabel19_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sValor = xrLabel19.Text;
            string sNewValue = string.Empty;
            int iQtdeCaract = 0;

            while (iQtdeCaract < 44)
            {
                sNewValue += sValor.Substring(iQtdeCaract, 4) + " ";
                iQtdeCaract += 4;
            }
            this.xrLabel19.Text = sNewValue;
        }

        private void xrLabel18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel18.Text = xrLabel18.Text.ToUpper();
        }

        private void xrLabel17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel17.Text = xrLabel17.Text.ToUpper();
        }

        private void lblEndereco_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sEndereco = GetCurrentColumnValue("Endereco_Empresa").ToString();
            sEndereco += ", " + GetCurrentColumnValue("Numero_Empresa").ToString();
            if (GetCurrentColumnValue("Complemento_Empresa") != DBNull.Value)
                sEndereco += " - " + GetCurrentColumnValue("Complemento_Empresa").ToString();

            sEndereco += " - " + GetCurrentColumnValue("Bairro_empresa").ToString();
            sEndereco += " - " + GetCurrentColumnValue("Cidade_Empresa").ToString();
            sEndereco += "/" + GetCurrentColumnValue("Estado_Empresa").ToString();
            sEndereco += " - CEP: " + Convert.ToDecimal(GetCurrentColumnValue("CEP_Empresa")).ToString("00000-000");
            sEndereco += string.Format(" - Telefone: ({0}) {1}"
                    , GetCurrentColumnValue("DDD_Empresa")
                    , GetCurrentColumnValue("Fone_Empresa"));

            this.lblEndereco.Text = sEndereco.ToUpper();
        }

        private void xrLabel118_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (Convert.ToInt32(this.GetCurrentColumnValue("Regime_Tributario")) != 3)
            {
                this.xrLabel118.Text = this.DetailReport1.GetCurrentColumnValue("CSOSN").ToString();
            }
        }

        private void xrLabel101_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (Convert.ToInt32(this.GetCurrentColumnValue("Regime_Tributario")) != 3)
            {
                this.xrLabel101.Text = "CSO";
            }
        }
    }
}