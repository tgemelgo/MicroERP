using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace CompSoft.compFrameWork
{
    public struct Propriedades
    {
        #region Registras as variaveis

        private static string sConn = string.Empty;
        private static string sConn_Access = string.Empty;
        private static string sDatabase = string.Empty;
        private static string sNomeUsuario;
        private static string sVersao = string.Empty;
        private static string sCaptionMain = string.Empty;
        private static string sNomeEmpresa_Relatorio = string.Empty;
        private static string sEndereco_Relatorio = string.Empty;
        private static string sTelefone_Relatorio = string.Empty;
        private static string sInternet_Relatorio = string.Empty;
        private static string sUsuario_Ativacao = string.Empty;
        private static string sSenha_Ativacao = string.Empty;

        private static int iUsuario = 0;
        private static int iSoftware_Autetica = 0;

        private static bool bUserAdm = false;
        private static bool bVerificaComputador = false;
        private static bool bVerificaSoftware = false;
        private static bool bCarrega_Barra_Ferramentas_Modulos = false;
        private static bool bPermite_Traduzir_Controles = false;

        private static DataTable dt;

        private static frmMain fMain;
        private static Tools.frmWait fWait;

        private static Image imgRelatorio_Lado_Direito;
        private static Image imgRelatorio_Lado_Esquerdo;

        #endregion Registras as variaveis

        #region Crias todas as propriedades

        /// <summary>
        /// String de conexão com ACCESS para verificar estrutura do banco de dados.
        /// </summary>
        internal static string StringConexcao_Access
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(sConn_Access))
                    {
                        IniFile ini = new IniFile(System.Windows.Forms.Application.StartupPath + "\\compsoft.ini");
                        sConn_Access = ini.IniReadValue("Configuracoes", "Folder_Server");
                        sConn_Access += ini.IniReadValue("Configuracoes", "File_Config");
                    }

                    //-- Verifica se o caminho do arquivo não está invalido.
                    if (System.IO.File.Exists(sConn_Access))
                        return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sConn_Access;
                    else
                        return "";
                }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Titulo que será utilizando no form Main
        /// </summary>
        public static string TituloMain
        {
            get { return sCaptionMain; }
            set { sCaptionMain = value; }
        }

        /// <summary>
        /// Usuário logado é Administrador do sistema
        /// </summary>
        public static bool Usuario_ADM
        {
            get { return bUserAdm; }
            set { bUserAdm = value; }
        }

        /// <summary>
        /// String de conexão com o banco de dados SQL Server
        /// </summary>
        internal static string StringConexao
        {
            get
            {
                if (sDatabase != string.Empty)
                    return sConn + string.Format(";Database={0}", sDatabase);
                else
                    return sConn;
            }
            set { sConn = value; }
        }

        /// <summary>
        /// DataTable com as propriedades do sitema
        /// </summary>
        internal static DataTable Propriedades_Sist
        {
            get { return dt; }
            set { dt = value; }
        }

        /// <summary>
        /// Nome do banco de dados que o sistema acessará
        /// </summary>
        public static string DataBase
        {
            get { return sDatabase; }
            set { sDatabase = value; }
        }

        /// <summary>
        /// Código do usuário que está logado.
        /// </summary>
        public static int CodigoUsuario
        {
            get { return iUsuario; }
            set { iUsuario = value; }
        }

        /// <summary>
        /// Software para autenticação e validação da licença
        /// </summary>
        public static int Software
        {
            get { return iSoftware_Autetica; }
            set { iSoftware_Autetica = value; }
        }

        /// <summary>
        /// Nome do usuário que está logado.
        /// </summary>
        public static string NomeUsuario
        {
            get { return sNomeUsuario; }
            set { sNomeUsuario = value; }
        }

        /// <summary>
        /// Versão do aplicativo.
        /// </summary>
        public static string VersaoAPP
        {
            get { return sVersao; }
        }

        /// <summary>
        /// Referencia do form main.
        /// </summary>
        public static frmMain FormMain
        {
            get { return fMain; }
            set { fMain = value; }
        }

        /// <summary>
        /// Verifica se o computador pode executa o software instalado.
        /// </summary>
        public static bool Verificar_Copia
        {
            get { return bVerificaComputador; }
            set { bVerificaComputador = value; }
        }

        /// <summary>
        /// Verifica se o software está licenciado corretamente de acordo com a versão.
        /// </summary>
        public static bool Verificar_Software
        {
            get { return bVerificaSoftware; }
            set { bVerificaSoftware = value; }
        }

        /// <summary>
        /// Imagem que será adicionada no canto superior direito do relatório.
        /// </summary>
        public static Image Imagem_Relatorio_Lado_Direito
        {
            get { return imgRelatorio_Lado_Direito; }
            set { imgRelatorio_Lado_Direito = value; }
        }

        /// <summary>
        /// Imagem que será adicionada no canto superior esquerdo do relatório.
        /// </summary>
        public static Image Imagem_Relatorio_Lado_Esquerdo
        {
            get { return imgRelatorio_Lado_Esquerdo; }
            set { imgRelatorio_Lado_Esquerdo = value; }
        }

        /// <summary>
        /// Permite carregar a barra de ferramentas
        /// </summary>
        public static bool Carrega_Barra_Ferramentas_Modulos
        {
            get { return bCarrega_Barra_Ferramentas_Modulos; }
            set { bCarrega_Barra_Ferramentas_Modulos = value; }
        }

        /// <summary>
        /// Armazena o usuário para ativação
        /// </summary>
        internal static string Usuario_Ativacao
        {
            get { return sUsuario_Ativacao; }
            set { sUsuario_Ativacao = value; }
        }

        /// <summary>
        /// Armazena o senha do usário de ativação
        /// </summary>
        internal static string Senha_Ativacao
        {
            get { return sSenha_Ativacao; }
            set { sSenha_Ativacao = value; }
        }

        /// <summary>
        /// Identifica se o formulário está aberto.
        /// </summary>
        internal static Tools.frmWait Form_Wait
        {
            get { return fWait; }
            set { fWait = value; }
        }

        /// <summary>
        /// Identifica se é possivel traduzir os controles do sistema.
        /// </summary>
        public static bool Permite_traduzir
        {
            get { return bPermite_Traduzir_Controles; }
            set { bPermite_Traduzir_Controles = value; }
        }

        #endregion Crias todas as propriedades

        #region Propriedades do relatório

        /// <summary>
        /// Nome da empresa para identificação no relatório.
        /// </summary>
        public static string Relatorio_NomeEmpresa
        {
            get { return sNomeEmpresa_Relatorio; }
            set { sNomeEmpresa_Relatorio = value; }
        }

        /// <summary>
        /// Endereço da empresa para identificação no relatório.
        /// </summary>
        public static string Relatorio_EnderecoEmpresa
        {
            get { return sEndereco_Relatorio; }
            set { sEndereco_Relatorio = value; }
        }

        /// <summary>
        /// Telefone da empresa para identificação no relatório.
        /// </summary>
        public static string Relatorio_TelefoneEmpresa
        {
            get { return sTelefone_Relatorio; }
            set { sTelefone_Relatorio = value; }
        }

        /// <summary>
        /// Endereço de internet para identificação da empresa.
        /// </summary>
        public static string Relatorio_InternetEmpresa
        {
            get { return sInternet_Relatorio; }
            set { sInternet_Relatorio = value; }
        }

        #endregion Propriedades do relatório
    }
}