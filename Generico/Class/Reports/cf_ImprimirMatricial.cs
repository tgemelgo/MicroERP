using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CompSoft.Reports
{
    /// <summary>
    /// Classe para impressão de textos diretamente para a porta da impressora.
    /// </summary>
    public class Imprime_Matricial : IDisposable
    {
        private int GENERIC_WRITE = 0x40000000; // indica a operação de gravação
        private int OPEN_EXISTING = 3; // abre mesmo existindo o arquivo
        private int FILE_SHARE_WRITE = 0x2; // define como escrita em modo compartilhado
        private string sPorta; // armazena a porta que está sendo usada
        private int hPort; // handle para a porta
        private FileStream outFile; // objeto que indica a porta
        private StreamWriter fileWriter; // objeto usado para escrever na porta
        private bool lOK = false; // indica se conseguiu abrir a porta da impressora
        private bool bDebug = false; // Indica que a aplicação está rodando em debug.
        private int iColunas = 0; //-- Indica a quantidade de caracteres a linha possui.
        private int iLinhas = 0; //-- Indica a quantidade de linhas

        /// <summary>
        /// Retorna o caracter ASC indicado.
        /// </summary>
        /// <param name="asc">número do caracter na tabela ASCII</param>
        /// <returns></returns>
        private string Chr(int asc)
        {
            string ret = string.Empty;
            ret += (char)asc;
            return ret;
        }

        [DllImport("kernel32.dll", EntryPoint = "CreateFileA")]
        private static extern int CreateFileA(string lpFileName, int dwDesiredAccess, int dwShareMode,
         int lpSecurityAttributes,
         int dwCreationDisposition, int dwFlagsAndAttributes,
         int hTemplateFile);

        [DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
        private static extern int CloseHandle(int hObject);

        /// <summary>
        /// Retorna a quantidade de caracteres
        /// </summary>
        public int Numero_Colunas_Linha_Atual
        {
            get { return iColunas; }
        }

        /// <summary>
        /// Indica se o arquivo será enviado para a impressora.
        /// </summary>
        public bool Debug
        {
            get { return bDebug; }
            set { bDebug = value; }
        }

        /// <summary>
        /// Retorna o número de linhas que a impressão atual possui.
        /// </summary>
        public int Numero_Linhas_Impressao_Atual
        {
            get { return iLinhas; }
        }

        /// <summary>
        /// Configura a impressora para impressão normal.
        /// </summary>
        public string Normal
        {
            get { return Chr(18); }
        }

        /// <summary>
        /// Configura a impressora para impressão em modo condensado.
        /// </summary>
        public string Comprimido
        {
            get { return Chr(15); }
        }

        /// <summary>
        /// Configura a impressora para impressão em modo expandido.
        /// </summary>
        public string Expandido
        {
            get { return Chr(14); }
        }

        /// <summary>
        /// Configura a impressora para impressão em modo expandido normal.
        /// </summary>
        public string ExpandidoNormal
        {
            get { return Chr(20); }
        }

        /// <summary>
        /// Ativa o modo negrito da impressora.
        /// </summary>
        public string NegritoOn
        {
            get { return Chr(27) + Chr(69); }
        }

        /// <summary>
        /// Desativa o modo negrito da impressora.
        /// </summary>
        public string NegritoOff
        {
            get { return Chr(27) + Chr(70); }
        }

        /// <summary>
        /// Tira os caracteres especiais para impressão.
        /// </summary>
        /// <param name="sTexto_Imprimir">Texto para impressão.</param>
        /// <returns>Texto corrigido para impressão.</returns>
        private string Tira_Caracter_Especial(string sTexto_Imprimir)
        {
            string sChar_Special = "áéíóúâêîôûãõçàèìòù´`'^~ªº";
            string sChar_Natural = "aeiouaeiouaocaeiou       ";

            //-- Verra e substitui caracteres para impressão.
            for (int i = 0; i < sChar_Special.ToCharArray().Length; i++)
            {
                char cCharSpecial = sChar_Special[i];
                char cCharNatual = sChar_Natural[i];

                //-- converte minusculo
                sTexto_Imprimir = sTexto_Imprimir.Replace(cCharSpecial, cCharNatual);

                //-- converte maiusculo
                sTexto_Imprimir = sTexto_Imprimir.Replace(cCharSpecial.ToString().ToUpper(), cCharNatual.ToString().ToUpper());
            }

            return sTexto_Imprimir;
        }

        /// <summary>
        /// Inicia a impressão em modo texto.
        /// </summary>
        /// <param name="sPortaInicio">Especifica a porta da impressora (LPT1,LPT2,LPT3,LPT4,...)</param>
        /// <returns>Retorna true se inciar a impressora e false caso contrário</returns>
        public bool Inicio(string sPortaInicio)
        {
            iLinhas = 0;

            if (!bDebug)
            {
                //#if (!DEBUG)
                //                if (sPortaInicio.ToUpper().Substring(0, 3) != "LPT")
                //                {
                //                    lOK = false;
                //                    throw new Exception("Porta LPT inválida.");
                //                }
                //#endif
                sPorta = sPortaInicio.ToUpper();
                hPort = CreateFileA(sPorta, GENERIC_WRITE, FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
                if (hPort != -1)
                {
                    SafeFileHandle sfh = new SafeFileHandle(new IntPtr(hPort), true);
                    outFile = new FileStream(sfh, FileAccess.Write);
                    fileWriter = new StreamWriter(outFile);
                    lOK = true;
                }
                else
                {
                    lOK = false;
                }
            }
            else
            {
                fileWriter = new StreamWriter(System.Windows.Forms.Application.StartupPath + @"\Impressao.txt", true);
                lOK = true;
            }

            return lOK;
        }

        /// <summary>
        /// Finaliza a Impressao.
        /// </summary>
        public void Fim()
        {
            iLinhas = 0;
            if (lOK)
            {
                fileWriter.Close();
                if (outFile != null)
                    outFile.Close();

                CloseHandle(hPort);

                lOK = false;
            }
        }

        /// <summary>
        /// Imprime uma string.
        /// </summary>
        /// <param name="sLinha">String a ser impressa</param>
        public void Imp(string sLinha)
        {
            if (lOK)
            {
                iColunas += sLinha.Length;
                fileWriter.Write(this.Tira_Caracter_Especial(sLinha));
                fileWriter.Flush();
            }
        }

        /// <summary>
        /// Imprime uma string e pula uma linha.
        /// </summary>
        /// <param name="sLinha">String a ser impressa</param>
        public void ImpLF(string sLinha)
        {
            if (lOK)
            {
                iLinhas++;
                iColunas = 0;
                fileWriter.WriteLine(this.Tira_Caracter_Especial(sLinha));
                fileWriter.Flush();
            }
        }

        /// <summary>
        /// Imprime uma string em uma determinada coluna.
        /// </summary>
        /// <param name="nCol">Coluna a ser posicionada</param>
        /// <param name="sLinha">String a ser impressa</param>
        public void ImpCol(int nCol, string sLinha)
        {
            if (nCol > iColunas)
            {
                int i = nCol - iColunas;
                Imp("".PadLeft(i));
            }

            Imp(sLinha);
        }

        /// <summary>
        /// Imprime uma string em uma determinada coluna.
        /// </summary>
        /// <param name="nCol">Coluna a ser posicionada</param>
        /// <param name="sLinha">String a ser impressa</param>
        public void ImpColRight(int nCol, string sLinha)
        {
            if (nCol > iColunas)
            {
                int i = nCol - iColunas;
                i = i - sLinha.Length;
                Imp("".PadRight(i));
            }

            Imp(sLinha);
        }

        /// <summary>
        /// Imprime uma string em uma determinada coluna e pula uma linha.
        /// </summary>
        /// <param name="nCol">Coluna a ser posicionada</param>
        /// <param name="sLinha">String a ser impressa</param>
        public void ImpColRightLF(int nCol, string sLinha)
        {
            this.ImpColRight(nCol, sLinha);
            ImpLF("");
        }

        /// <summary>
        /// Imprime uma string em uma determinada coluna e pula uma linha.
        /// </summary>
        /// <param name="nCol">Coluna a ser posicionada</param>
        /// <param name="sLinha">String a ser impressa</param>
        public void ImpColLF(int nCol, string sLinha)
        {
            this.ImpCol(nCol, sLinha);
            ImpLF("");
        }

        /// <summary>
        /// Pula uma numero determinado de linhas.
        /// </summary>
        /// <param name="nLinha">Número de linhas a serem puladas</param>
        public void Pula(int nLinha)
        {
            for (int i = 0; i < nLinha; i++)
            {
                ImpLF("");
            }
        }

        /// <summary>
        /// Ejeta uma página.
        /// </summary>
        public void Eject()
        {
            iLinhas = 0;
            iColunas = 0;
            Imp(Chr(12));
        }

        #region IDisposable Members

        public void Dispose()
        {
            CloseHandle(hPort); //-- Fecha handle da conexão com a impressora.

            if (outFile != null)
            {
                outFile.Close(); //-- Fecha out file
                outFile.Dispose(); //-- Dispose out file
                outFile = null; //-- Fecha out file
            }

            if (fileWriter != null)
            {
                fileWriter.Close();
                fileWriter.Dispose();
                fileWriter = null;
            }

            lOK = false;
        }

        #endregion IDisposable Members
    }
}