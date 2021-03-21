using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CompSoft.Tools
{
    /// <summary>
    /// Verifica erros e compila arquivo .CS, assim disponibilizando para utilização em execução.
    /// </summary>
    public class Object_Entrada
    {
        private Assembly a;
        private bool bDebug = false;

        #region Propriedades

        /// <summary>
        /// Arquivo compilado e carregado no assembly.
        /// </summary>
        public Assembly Assembly
        {
            get { return a; }
        }

        /// <summary>
        /// Compila com informações de debug.
        /// </summary>
        public bool Permite_Debug
        {
            get { return bDebug; }
            set { bDebug = value; }
        }

        #endregion Propriedades

        #region Carregar objeto de entrada.

        /// <summary>
        /// Carrega objeto dinamico para trabalho.
        /// </summary>
        /// <param name="sNome_Arquivo">string com o nome físico do arquivo.</param>
        /// <returns>true/false identificando se o arquivo foi compilou corretamente.</returns>
        public bool Carregar_Formulario(string sNome_Arquivo)
        {
            return this.Carregar(sNome_Arquivo);
        }

        /// <summary>
        /// Carrega objeto dinamico para trabalho.
        /// </summary>
        /// <param name="sNome_Arquivo">string com o nome físico do arquivo.</param>
        /// <param name="bDebugar">Identifica se o código permite o Debug</param>
        /// <returns>true/false identificando se o arquivo foi compilou corretamente.</returns>
        public bool Carregar_Formulario(string sNome_Arquivo, bool bDebugar)
        {
            bDebug = bDebugar;
            return this.Carregar(sNome_Arquivo);
        }

        #endregion Carregar objeto de entrada.

        #region Carrega e compila o arquivo.

        /// <summary>
        /// Carrega objeto dinamico para trabalho.
        /// </summary>
        /// <param name="sNomeArquivo">string com o nome físico do arquivo.</param>
        /// <returns>true/false identificando se o arquivo foi compilou corretamente.</returns>
        private bool Carregar(string sNomeArquivo)
        {
            bool bRetorno = false;
            string sPasta_Objeto = Application.StartupPath.ToLower(),
                sCaminho_Objeto = string.Empty;

            sPasta_Objeto = sPasta_Objeto.Replace("\\bin\\debug", "").Replace("\\bin\\release", "");
            sPasta_Objeto += @"\UserProgram";
            sCaminho_Objeto = sPasta_Objeto + "\\" + sNomeArquivo + ".cs";

            if (Directory.Exists(sPasta_Objeto) && File.Exists(sCaminho_Objeto))
            {
                //-- Cria a instancia do compilador.
                CodeDomProvider csCompiler = CodeDomProvider.CreateProvider("CSharp");

                //-- Atribui parametros do compilador e carrega todos os assembly de referencia.
                CompilerParameters compilerParams = new CompilerParameters();
                AssemblyName[] a_exec = System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies();
                foreach (AssemblyName an in a_exec)
                {
                    try
                    {
                        if (File.Exists(Application.StartupPath + "\\" + an.Name + ".dll"))
                            compilerParams.ReferencedAssemblies.Add(Application.StartupPath + "\\" + an.Name + ".dll");
                        else
                            compilerParams.ReferencedAssemblies.Add(an.Name + ".dll");
                    }
                    catch { }
                }

                compilerParams.ReferencedAssemblies.Add(Application.ExecutablePath); //-- Referencia o EXE da aplicação.
                compilerParams.ReferencedAssemblies.Add(Application.StartupPath + "\\compsoft.dll"); //-- Referencia o EXE da aplicação.compilerParams.ReferencedAssemblies.Add(Application.StartupPath + "\\cf_bases.dll"); //-- Referencia o EXE da aplicação.
                compilerParams.ReferencedAssemblies.Add("System.Xml.dll");

                //-- Não gera executavel.
                compilerParams.GenerateExecutable = false;

                //-- Compila em memoria
                compilerParams.GenerateInMemory = true;

                //-- Não inclui informações de DEBUG
                compilerParams.IncludeDebugInformation = bDebug;

                //-- Cria Assembly do código...
                CompilerResults cr = csCompiler.CompileAssemblyFromFile(compilerParams, sCaminho_Objeto);

                //-- Caso aconteca algum erro o sistema ignora o objeto e carrega o form normal.
                if (cr.Errors.Count > 0)
                {
                    string sErro = string.Empty;
                    for (int i = 0; i < cr.Errors.Count; i++)
                        sErro += cr.Errors[i].ErrorText + "\r\n";

                    CompSoft.compFrameWork.MsgBox.Show(sErro
                        , "Erro no objeto de entrada"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                    bRetorno = false;
                }
                else
                {
                    a = cr.CompiledAssembly;
                    bRetorno = true;
                }
            }
            else
                bRetorno = false;

            return bRetorno;
        }

        #endregion Carrega e compila o arquivo.
    }
}