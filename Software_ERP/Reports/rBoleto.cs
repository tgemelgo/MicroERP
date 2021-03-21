using BoletoNet;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace ERP.Reports
{
    public partial class rBoleto : XtraReport
    {
        private BoletoNet.BoletoBancario bb;
        private Dictionary<int, BoletoBancario> ilBB = new Dictionary<int, BoletoBancario>();
        private Dictionary<int, Image> ilLogos = new Dictionary<int, Image>();

        public rBoleto(DataTable dtReport, Dictionary<int, BoletoBancario> boletos, Dictionary<int, Image> logos)
        {
            ilBB = boletos;
            ilLogos = logos;

            InitializeComponent();

            this.DataSource = dtReport;
        }

        private void rBoleto_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            int iNota_Fiscal_Duplicata = Convert.ToInt32(GetCurrentColumnValue("Nota_Fiscal_Duplicata"));

            if (ilBB.ContainsKey(iNota_Fiscal_Duplicata))
            {
                bb = ilBB[iNota_Fiscal_Duplicata];

                //-- Seta o boleto como impresso.
                CNAB.CNAB.Grava_Boleto_Impresso(iNota_Fiscal_Duplicata);
            }
            else
                bb = null;
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel3.Text = bb.Banco.Codigo.ToString() + "-" + bb.Banco.Digito.ToString();
        }

        private void xrLabel21_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel21.Text = bb.Banco.Codigo.ToString() + "-" + bb.Banco.Digito.ToString();
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int iBanco = Convert.ToInt32(GetCurrentColumnValue("Banco"));
            if (ilLogos.ContainsKey(iBanco))
                this.xrPictureBox1.Image = ilLogos[iBanco];
        }

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int iBanco = Convert.ToInt32(GetCurrentColumnValue("Banco"));
            if (ilLogos.ContainsKey(iBanco))
                this.xrPictureBox2.Image = ilLogos[iBanco];
        }

        private void xrLabel71_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel71.Text = bb.Boleto.EspecieDocumento.Sigla;
        }

        private void xrLabel76_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel76.Text = bb.Boleto.Especie;
        }

        private void xrLabel52_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel52.Text = bb.Boleto.Especie;
        }

        private void xrLabel82_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!bb.Cedente.DigitoCedente.Equals(-1))
            {
                this.xrLabel82.Text = string.Format("{0}/{1:000000}-{2}"
                            , bb.Cedente.ContaBancaria.Agencia
                            , bb.Cedente.Codigo
                            , bb.Cedente.DigitoCedente);
            }
            else
            {
                this.xrLabel82.Text = string.Format("{0}{1}/{2}{3}"
                            , bb.Cedente.ContaBancaria.Agencia
                            , !string.IsNullOrEmpty(bb.Cedente.ContaBancaria.DigitoAgencia) ? "-" + bb.Cedente.ContaBancaria.DigitoAgencia : string.Empty
                            , bb.Cedente.ContaBancaria.Conta
                            , !string.IsNullOrEmpty(bb.Cedente.ContaBancaria.DigitoConta) ? "-" + bb.Cedente.ContaBancaria.DigitoConta : string.Empty);
            }
        }

        private void xrLabel83_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel83.Text = bb.Boleto.NossoNumero;
        }

        private void xrLabel92_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel92.Text += "/" + GetCurrentColumnValue("Estado_Correspondencia").ToString();
        }

        private void xrLabel90_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sEndereco = string.Empty;

            sEndereco = ", " + GetCurrentColumnValue("Numero_Correspondencia").ToString();
            if (GetCurrentColumnValue("Numero_Correspondencia") != DBNull.Value)
                sEndereco += " - " + GetCurrentColumnValue("Complemento_Correspondencia").ToString();

            this.xrLabel90.Text += sEndereco;
        }

        private void xrLabel68_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double dCNPJ = Convert.ToDouble(this.xrLabel68.Text);
            if (this.xrLabel68.Text.Length <= 11)
            {
                this.xrLabel68.Text = "CPF: " + dCNPJ.ToString(@"000\.000\.000\-00");
            }
            else
            {
                this.xrLabel68.Text = "CNPJ: " + dCNPJ.ToString(@"00\.000\.000\/0000\-00");
            }
        }

        private void xrLabel56_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double dCNPJ = Convert.ToDouble(this.xrLabel56.Text);
            this.xrLabel56.Text = dCNPJ.ToString(@"00\.000\.000\/0000\-00");
        }

        private void xrLabel93_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel93.Text = "CEP: " + Convert.ToDecimal(this.xrLabel93.Text).ToString(@"00000\-000");
        }

        private void xrLabel94_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double dCNPJ = Convert.ToDouble(this.xrLabel94.Text);
            if (this.xrLabel94.Text.Length <= 11)
            {
                this.xrLabel94.Text = "CPF: " + dCNPJ.ToString(@"000\.000\.000\-00");
            }
            else
            {
                this.xrLabel94.Text = "CNPJ: " + dCNPJ.ToString(@"00\.000\.000\/0000\-00");
            }
        }

        private void xrLabel95_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sEndereco = string.Empty;

            sEndereco = ", " + GetCurrentColumnValue("Numero_Correspondencia").ToString();
            if (GetCurrentColumnValue("Numero_Correspondencia") != DBNull.Value)
                sEndereco += " - " + GetCurrentColumnValue("Complemento_Correspondencia").ToString();

            this.xrLabel95.Text += sEndereco;
        }

        private void xrLabel97_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel97.Text += "/" + GetCurrentColumnValue("Estado_Correspondencia").ToString();
        }

        private void xrLabel98_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel98.Text = "CEP: " + Convert.ToDecimal(this.xrLabel98.Text).ToString(@"00000\-000");
        }

        private void xrLabel51_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel51.Text = string.Format("{0}/{1}-{2}"
                            , bb.Cedente.ContaBancaria.Agencia
                            , bb.Cedente.ContaBancaria.Conta
                            , bb.Cedente.ContaBancaria.DigitoConta);
        }

        private void xrLabel54_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel54.Text = bb.Boleto.NossoNumero;
        }

        private void xrLabel72_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel72.Text = bb.Boleto.Aceite;
        }

        private void xrLabel67_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel67.Text = bb.Boleto.LocalPagamento;
        }

        private void xrLabel66_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (IInstrucao i in bb.Boleto.Instrucoes)
                sb.AppendLine(i.Descricao);

            xrLabel66.Text = sb.ToString();
        }

        private void xrLabel79_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (IInstrucao i in bb.Boleto.Instrucoes)
                sb.AppendLine(i.Descricao);

            xrLabel79.Text = sb.ToString();
        }

        private void xrLabel70_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel70.Text = bb.Boleto.NumeroDocumento;
        }

        private void xrLabel55_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel55.Text = bb.Boleto.NumeroDocumento;
        }

        private void xrLabel6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (bb.Banco.Codigo == 341)
            {
                this.xrLabel6.Text = "Instruções (Todas as informações deste bloqueto são de exclusiva responsabilidade do cedente)";
            }
        }

        private void xrLabel31_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (bb.Banco.Codigo == 341)
            {
                this.xrLabel31.Text = "Instruções (Todas as informações deste bloqueto são de exclusiva responsabilidade do cedente)";
            }
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel4.Text = this.GetCurrentColumnValue("Linha_Digitavel").ToString();
        }

        private void xrLabel22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel22.Text = this.GetCurrentColumnValue("Linha_Digitavel").ToString();
        }
    }
}