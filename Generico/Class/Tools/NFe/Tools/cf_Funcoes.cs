using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace CompSoft.NFe
{
    /// <summary>
    /// Ambientes disponiveis para utilização
    /// </summary>
    public enum Ambientes
    {
        Producao = 1,
        Homologacao = 2
    }

    public struct Funcoes_NFe
    {
        #region Verifica se a chave de NF-e é válida.

        /// <summary>
        /// Verifica se a chave da NF-e é valida.
        /// </summary>
        /// <param name="sChave">String com a chave da NF-e (44 caracteres).</param>
        /// <returns>true/false indicando se a chave é verdadeira.</returns>
        public bool Valida_ChaveNFe(string sChave)
        {
            bool bRetorno = false;

            sChave = sChave.Trim();

            //-- Inicia a verificação dos caracteres da chave.
            if (sChave.Length == 44)
            {
                int iSomatoria = 0;
                int iMultiplicador = 4;
                foreach (char cCaracter in sChave.Substring(0, 43).ToCharArray())
                {
                    iSomatoria += Convert.ToInt32(cCaracter.ToString()) * iMultiplicador;

                    iMultiplicador--;
                    if (iMultiplicador == 1)
                        iMultiplicador = 9;
                }

                int iResto = (iSomatoria % 11);
                int iDV = 0;
                if (iResto > 1) //-- Caso o DV = 0 ou 1 considerar 0
                    iDV = 11 - iResto;

                if (iDV == Convert.ToInt32(sChave.Substring(43, 1)))
                    bRetorno = true;
            }

            return bRetorno;
        }

        #endregion Verifica se a chave de NF-e é válida.

        #region Calcula o DV da chave da Nf-e.

        /// <summary>
        /// Faz o calculo do DV da NF-e.
        /// </summary>
        /// <param name="sChave_SemDV">String com a chave da NF-e (43 caracteres).</param>
        /// <returns>String com a chave completa.</returns>
        public string Calcula_DV_ChaveNFe(string sChave_SemDV)
        {
            string sRetorno = string.Empty;

            sChave_SemDV = sChave_SemDV.Trim();

            //-- Inicia a verificação dos caracteres da chave.
            if (sChave_SemDV.Length == 43)
            {
                int iSomatoria = 0;
                int iMultiplicador = 4;
                foreach (char cCaracter in sChave_SemDV.ToCharArray())
                {
                    iSomatoria += Convert.ToInt32(cCaracter.ToString()) * iMultiplicador;
                    iMultiplicador--;
                    if (iMultiplicador == 1)
                        iMultiplicador = 9;
                }

                int iResto = (iSomatoria % 11);
                int iDV = 0;
                if (iResto > 1) //-- Caso o DV = 0 ou 1 considerar 0
                    iDV = 11 - iResto;

                sRetorno = sChave_SemDV + iDV.ToString();
            }

            return sRetorno;
        }

        #endregion Calcula o DV da chave da Nf-e.

        #region Convert StringXML em MemoryStream para leitura do XMLDocument

        /// <summary>
        /// Método responsável por converter uma String contendo a estrutura de um XML em um XMLDocument
        /// </summary>
        /// <returns>XMLDocument com o retorno</returns>
        internal static XmlDocument StringXmlToXMLDocument(string strXml)
        {
            byte[] byteArray = new byte[strXml.Length];
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byteArray = encoding.GetBytes(strXml);
            MemoryStream memoryStream = new MemoryStream(byteArray);
            memoryStream.Seek(0, SeekOrigin.Begin);

            XmlDocument xml = new XmlDocument();
            xml.Load(memoryStream);

            return xml;
        }

        #endregion Convert StringXML em MemoryStream para leitura do XMLDocument

        #region Localiza e retorna o Certificado digital selecinado nas configurações

        /// <summary>
        /// Localizar o certificado digital previamente selecionado nas configurações.
        /// </summary>
        /// <returns>X509Certificate2 - Certificado selecionado para NF-e</returns>
        internal static X509Certificate2 Certificado_Digital(int iEmpresa)
        {
            Certificado cert = new Certificado();
            string sQuery = "select Serial_Number_Certifica_Digital from empresas where empresa = " + iEmpresa;
            string sSerial_Number_Certificado = CompSoft.Data.SQL.ExecuteScalar(sQuery).ToString();
            X509Certificate2 X509Cert = cert.Buscar_Certificado_Digital(sSerial_Number_Certificado, X509FindType.FindBySerialNumber);

            return X509Cert;
        }

        #endregion Localiza e retorna o Certificado digital selecinado nas configurações
    }
}