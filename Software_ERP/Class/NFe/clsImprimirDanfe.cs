using CompSoft.NFe;
using System;
using System.Collections.Generic;

namespace ERP.NFe
{
    internal struct Impressao_Danfe
    {
        public void Imprimir_Danfe(Dados_Arquivo_NFe daNFe, bool bPreview)
        {
            ERP.NFe.GerarDadosNFe gd = new GerarDadosNFe();

            IList<Dados_Arquivo_NFe> il = new List<Dados_Arquivo_NFe>();
            il.Add(daNFe);
            gd.Gerar_Dados_NFe(il);

            //-- Faz a impressão do danfe.
            ERP.Reports.rDanfe r = new ERP.Reports.rDanfe(gd.DataSet_NFe);
            r.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
            CompSoft.compFrameWork.Impressoras imp;
            if (bPreview)
                r.ShowPreviewDialog();
            else
                r.Print(imp.Impressora_Padrao);

            //-- Cria diretório e salva em PDF.
            if (!string.IsNullOrEmpty(daNFe.Arquivo_XML))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(daNFe.Arquivo_XML);
                string sPathPDF = fi.DirectoryName;
                if (!sPathPDF.EndsWith(@"\"))
                    sPathPDF += @"\";

                sPathPDF += @"PDF\";

                System.IO.DriveInfo di = new System.IO.DriveInfo(sPathPDF.Substring(0, 1));
                if (di.IsReady)
                {
                    if (!System.IO.Directory.Exists(sPathPDF))
                        System.IO.Directory.CreateDirectory(sPathPDF);

                    string sFile = gd.DataSet_NFe.Tables["Notas_Fiscais"].Rows[0]["Numero_nota"].ToString();
                    sFile += ".pdf";

                    //-- Exporta em PDF.
                    r.ExportToPdf(sPathPDF + sFile);
                }
            }
        }

        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            CompSoft.compFrameWork.Funcoes func;
            string sValor = func.Busca_Propriedade("CopiasDanfe");
            int iNumeroCopias = 1;

            if (!string.IsNullOrEmpty(sValor))
                iNumeroCopias = Convert.ToInt32(sValor);

            e.PrintDocument.PrinterSettings.Copies = (short)iNumeroCopias;
        }
    }
}