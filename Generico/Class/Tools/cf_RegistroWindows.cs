using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompSoft.compFrameWork
{
    /// <summary>
    /// Trabalha com o registro do windows nos padrões do sistema.
    /// </summary>
    public class RegistroWindows
    {
        /// <summary>
        /// Grava valores no registro.
        /// </summary>
        /// <param name="sChave">string Nome da chave.</param>
        /// <param name="sValor">string Valor para ser salvo</param>
        /// <returns>true/false se o registro foi salvo</returns>
        public bool GravarRegistro(string sChave, string sValor)
        {
            try
            {
                //-- Abre o registro para edição
                RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                RegistryKey newreg = reg.CreateSubKey("CompSoft");
                newreg.SetValue(sChave, sValor, RegistryValueKind.String);

                //-- Retorna verdadeiro caso não ocorra erro
                return true;
            }
            catch
            {
                //-- Caso ocorra erro exibe mensagem e retorna falso
                return false;
            }
        }

        /// <summary>
        /// Grava valores no registro.
        /// </summary>
        /// <param name="sChave">string Nome da chave.</param>
        /// <param name="bValor">Valor que será salvo no registro em bytes</param>
        /// <returns>true/false se o registro foi salvo</returns>
        public bool GravarRegistro(string sChave, byte[] bValor)
        {
            try
            {
                //-- Abre o registro para edição
                RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                RegistryKey newreg = reg.CreateSubKey("CompSoft");
                newreg.SetValue(sChave, bValor, RegistryValueKind.Binary);

                //-- Retorna verdadeiro caso não ocorra erro
                return true;
            }
            catch
            {
                //-- Caso ocorra erro exibe mensagem e retorna falso
                return false;
            }
        }

        public bool ExcluirRegistro(string sChave)
        {
            try
            {
                //-- Localiza o registro para exclusão.
                RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                reg.DeleteSubKey(sChave, true);

                //-- Retorna verdadeiro caso não ocorra erro.
                return true;
            }
            catch
            {
                //-- Caso ocorra erro exibe mensagem e retorna falso.
                return false;
            }
        }

        public object LocalizaRegistro(string sChave)
        {
            object oValor;

            try
            {
                //-- Abre o registro para edição
                RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\CompSoft");
                oValor = reg.GetValue(sChave, string.Empty, RegistryValueOptions.None);
            }
            catch
            {
                //-- Caso ocorra erro exibe mensagem e retorna falso
                oValor = string.Empty;
            }

            return oValor;
        }
    }
}