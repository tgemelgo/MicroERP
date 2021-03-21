using CompSoft.compFrameWork;
using System;
using System.Net;
using System.Windows.Forms;

namespace ERP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if !DEBUG
            Propriedades.Verificar_Copia = false;
            Propriedades.Verificar_Software = false;
#else
            Propriedades.Verificar_Copia = false;
            Propriedades.Verificar_Software = false;
#endif
            Propriedades.TituloMain = "ERP CompSoft - Gestão Empresárial Integrada";
            Propriedades.Carrega_Barra_Ferramentas_Modulos = true;
            Propriedades.Imagem_Relatorio_Lado_Direito = global::ERP.Properties.Resources.Logo_direito;
            Propriedades.Software = 1;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //-- Inicia a aplicação.
            Application.Run(new ERP.Forms.frmMain());
        }
    }
}