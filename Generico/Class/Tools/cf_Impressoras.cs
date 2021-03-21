using CompSoft.compFrameWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Text;

namespace CompSoft.compFrameWork
{
    public struct Impressoras
    {
        /// <summary>
        /// Impressora padrão vinculada do sistema.
        /// </summary>
        public string Impressora_Padrao
        {
            get
            {
                string sDefault = string.Empty;
                bool bImpressora_Valida = false;

                RegistroWindows rw = new RegistroWindows();
                sDefault = rw.LocalizaRegistro("Default_Printer").ToString();
                if (!string.IsNullOrEmpty(sDefault))
                {
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = sDefault;
                    bImpressora_Valida = ps.IsValid;
                }

                if (!bImpressora_Valida)
                {
                    foreach (string sPrinter in PrinterSettings.InstalledPrinters)
                    {
                        PrinterSettings ps = new PrinterSettings();
                        ps.PrinterName = sPrinter;

                        if (ps.IsDefaultPrinter)
                        {
                            sDefault = sPrinter;
                            continue;
                        }
                    }
                }

                return sDefault;
            }

            set
            {
                RegistroWindows rw = new RegistroWindows();
                rw.GravarRegistro("Default_Printer", value);
            }
        }

        /// <summary>
        /// Retorna todas as impressoras disponiveis no computador.
        /// </summary>
        /// <returns>DataTable com as impressoras.</returns>
        public DataTable Impressoras_Disponiveis()
        {
            DataTable dt = new DataTable("x");
            dt.Columns.Add("a", typeof(System.String));
            dt.Columns.Add("b", typeof(System.String));

            foreach (string sPrinter in PrinterSettings.InstalledPrinters)
            {
                DataRow newRow = dt.NewRow();

                PrinterSettings ps = new PrinterSettings();
                newRow[0] = sPrinter;
                newRow[1] = sPrinter;

                dt.Rows.Add(newRow);
            }

            return dt;
        }
    }
}