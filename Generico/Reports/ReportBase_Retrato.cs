using CompSoft.compFrameWork;
using CompSoft.Data;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

namespace CompSoft.Reports
{
    public partial class ReportBase_Retrato : CompSoft.Reports.ReportBase
    {
        #region Propriedades do relatório

        /// <summary>
        /// Nome da empresa para identificação no relatório.
        /// </summary>
        public string NomeEmpresa
        {
            get { return this.lblNomeEmpresa.Text; }
        }

        /// <summary>
        /// Endereço da empresa para identificação no relatório.
        /// </summary>
        public string EnderecoEmpresa
        {
            get { return this.lblEnderecoEmpresa.Text; }
        }

        /// <summary>
        /// Telefone da empresa para identificação no relatório.
        /// </summary>
        public string TelefoneEmpresa
        {
            get { return this.lblTelefone.Text; }
        }

        /// <summary>
        /// Endereço de internet para identificação da empresa.
        /// </summary>
        public string InternetEmpresa
        {
            get { return this.lblInternet.Text; }
        }

        #endregion Propriedades do relatório

        public ReportBase_Retrato()
        {
            InitializeComponent();
        }

        protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
        {
            base.OnBeforePrint(e);

            if (Propriedades.FormMain != null)
            {
                this.lblNomeRelatorio.Text = this.Nome_Relatorio;

                if (Propriedades.Imagem_Relatorio_Lado_Direito != null)
                    this.picLogoEmpresa.Image = Propriedades.Imagem_Relatorio_Lado_Direito;

                if (Propriedades.Imagem_Relatorio_Lado_Esquerdo != null)
                    this.picLogoCliente.Image = Propriedades.Imagem_Relatorio_Lado_Esquerdo;

                //-- Propriedades.
                if (!string.IsNullOrEmpty(Propriedades.Relatorio_NomeEmpresa))
                    this.lblNomeEmpresa.Text = Propriedades.Relatorio_NomeEmpresa;
                else
                    this.lblNomeEmpresa.Text = string.Empty;

                if (!string.IsNullOrEmpty(Propriedades.Relatorio_TelefoneEmpresa))
                    this.lblTelefone.Text = Propriedades.Relatorio_TelefoneEmpresa;
                else
                    this.lblTelefone.Text = string.Empty;

                if (!string.IsNullOrEmpty(Propriedades.Relatorio_EnderecoEmpresa))
                    this.lblEnderecoEmpresa.Text = Propriedades.Relatorio_EnderecoEmpresa;
                else
                    this.lblEnderecoEmpresa.Text = string.Empty;

                if (!string.IsNullOrEmpty(Propriedades.Relatorio_InternetEmpresa))
                    this.lblInternet.Text = Propriedades.Relatorio_InternetEmpresa;
                else
                    this.lblInternet.Text = string.Empty;
            }
        }
    }
}