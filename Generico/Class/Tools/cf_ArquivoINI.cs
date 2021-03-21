using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.compFrameWork
{
    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    internal class IniFile
    {
        private string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// <summary>
        /// Inicia o arquivo INI de acordo com o parametro.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public IniFile(string INIPath)
        {
            path = INIPath;
        }

        /// <summary>
        /// Inicia o arquivo INI padrão, Diretorio da aplicação\CompSoft.ini.
        /// </summary>
        public IniFile()
        {
            path = Application.StartupPath + "\\CompSoft.ini";
        }

        /// <summary>
        /// Escreve no arquivo INI
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Nome da Sessão
        /// <PARAM name="Key"></PARAM>
        /// Nome da Chave
        /// <PARAM name="Value"></PARAM>
        /// Valor a Gravar
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// Lê o arquivo INI e retorna o valor
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();
        }
    }
}