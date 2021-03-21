using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Reports
{
    public class Preview_Matricial
    {
        public void Visualizar()
        {
            StreamReader streamToPrint = new StreamReader(Application.StartupPath + @"\Impressao.txt", true);
            CompSoft.Reports.frmPreviewMatricial f = new frmPreviewMatricial(streamToPrint.ReadToEnd());
            streamToPrint.Close();
            streamToPrint.Dispose();
            File.Delete(Application.StartupPath + @"\Impressao.txt");

            /*try
            {
                try
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

                    PrintPreviewDialog pd1 = new PrintPreviewDialog();
                    pd1.Document = pd;
                    pd1.UseAntiAlias = true;
                    pd1.ShowDialog();
                }
                finally
                {
                    streamToPrint.Close();
                    File.Delete(Application.StartupPath + @"\Impressao.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        // The PrintPage event is raised for each page to be printed.
        /*private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = 0;
            float topMargin = 0;
            string line = null;

            Font printFont = new Font("Courier New", 8);

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }
        */
    }
}