using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace CompSoft.NFe
{
    /// <summary>
    /// Classe responsável por validar XML de acordo com arquivo de Schema.
    /// </summary>
    public class ValidadorXMLClass
    {
        private Tipo_Retorno_Validacao tpRetorno = Tipo_Retorno_Validacao.Vazio;
        private string sRetornoString = string.Empty;
        private Tipo_Arquivo tpRetornoTipoArq = Tipo_Arquivo.Vazio;
        private string cRetornoTipoArq;
        private string cArquivoSchema;
        private string cErro;

        #region Enum

        /// <summary>
        /// Identifica os possiveis retornos para validação do XML
        /// </summary>
        public enum Tipo_Retorno_Validacao
        {
            Vazio = -1,
            Sucesso = 0,
            XML_Invalido = 1,
            XML_Inexistente = 2,
            XSD_Inexistente = 3
        }

        /// <summary>
        /// Identifica os possiveis arquivos XML
        /// </summary>
        public enum Tipo_Arquivo
        {
            Vazio = 0,
            NFe = 1,
            Lote_NFe = 2,
            Cancelamento_NFe = 3,
            Inutilização_Numero_NFe = 4,
            Consulta_Sit_Fiscal_NFe = 5,
            Consulta_Recibo_NFe = 6,
            Consulta_Status_Servico_NFe = 7,
            XML_Invalido = 100,
            Arquivo_Nao_Identificado = 101
        }

        #endregion Enum

        #region Propriedades

        /// <summary>
        /// Mensagem identificando o tipo do arquivo
        /// </summary>
        public string Mensagem_Tipo_Arquivo
        {
            get { return cRetornoTipoArq; }
        }

        /// <summary>
        /// Nome do arquivo XSD (schema)
        /// </summary>
        public string Nome_Arquivo_Schema
        {
            get { return cArquivoSchema; }
        }

        /// <summary>
        /// Status da validação do XML.
        /// </summary>
        public Tipo_Retorno_Validacao Retorno
        {
            get { return tpRetorno; }
        }

        /// <summary>
        /// String com o texto da validação em caso de erro.
        /// </summary>
        public string RetornoString
        {
            get { return sRetornoString; }
        }

        #endregion Propriedades

        #region Valida XML

        /// <summary>
        /// Valida XML de acordo com o arquivo de schema.
        /// </summary>
        /// <param name="cRotaArqXML">Caminho completo do arquivo XML</param>
        /// <param name="cRotaArqSchema">Caminho completo do arquivo XSD</param>
        public void ValidarXML(string cRotaArqXML, string cRotaArqSchema)
        {
            bool lArqXML = File.Exists(cRotaArqXML);
            bool lArqXSD = File.Exists(cRotaArqSchema);

            if (lArqXML && lArqXSD)
            {
                XmlSchemaSet schemaset = new XmlSchemaSet();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationEventHandler += new ValidationEventHandler(settings_ValidationEventHandler);

                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemaset;
                settings.Schemas.Add(null, cRotaArqSchema); //-- Adiciona o arquivo XSD para validação.

                //-- Abre o arquivo XML
                XmlReader validator = XmlReader.Create(cRotaArqXML, settings);

                this.cErro = string.Empty;
                try
                {
                    while (validator.Read()) { }
                }
                catch (XmlException err)
                {
                    this.cErro = err.Message;
                }
                finally
                {
                    validator.Close();
                }

                tpRetorno = Tipo_Retorno_Validacao.Sucesso;
                if (cErro != string.Empty)
                {
                    tpRetorno = Tipo_Retorno_Validacao.XML_Invalido;
                    sRetornoString = "Início da validação...\r\n\r\n";
                    sRetornoString += this.cErro;
                    sRetornoString += "\r\n...Final da validação";
                }
            }
            else
            {
                if (lArqXML == false)
                {
                    tpRetorno = Tipo_Retorno_Validacao.XML_Inexistente;
                    sRetornoString = "Arquivo XML não foi encontrato";
                }
                else if (lArqXSD == false)
                {
                    tpRetorno = Tipo_Retorno_Validacao.XSD_Inexistente;
                    sRetornoString = "Arquivo XSD (schema) não foi encontrato";
                }
            }
        }

        private void settings_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            this.cErro = "Linha: " + e.Exception.LineNumber + " Coluna: " + e.Exception.LinePosition + " Erro: " + e.Exception.Message + "\r\n";
        }

        #endregion Valida XML

        #region Identifica o tipo de arquivo XML

        /// <summary>
        /// Identifica o tipo de arquivo XML
        /// </summary>
        /// <param name="cRotaArqXML">Caminho completo do arquivo XML</param>
        public void TipoArquivoXML(string cRotaArqXML)
        {
            tpRetornoTipoArq = Tipo_Arquivo.Vazio;

            this.tpRetornoTipoArq = Tipo_Arquivo.Vazio;
            cArquivoSchema = string.Empty;

            if (File.Exists(cRotaArqXML))
            {
                //Carregar os dados do arquivo XML de configurações do UniNfe
                XmlTextReader oLerXml = new XmlTextReader(cRotaArqXML);

                while (oLerXml.Read())
                {
                    if (oLerXml.NodeType == XmlNodeType.Element)
                    {
                        switch (oLerXml.Name)
                        {
                            case "NFe":
                                tpRetornoTipoArq = Tipo_Arquivo.NFe;
                                this.cRetornoTipoArq = "XML de Nota Fiscal Eletrônica";
                                this.cArquivoSchema = "nfe_v1.10.xsd";
                                break;

                            case "enviNFe":
                                tpRetornoTipoArq = Tipo_Arquivo.Lote_NFe;
                                this.cRetornoTipoArq = "XML de Envio de Lote de Notas Fiscais Eletrônicas";
                                this.cArquivoSchema = "enviNFe_v1.10.xsd";
                                break;

                            case "cancNFe":
                                tpRetornoTipoArq = Tipo_Arquivo.Cancelamento_NFe;
                                this.cRetornoTipoArq = "XML de Cancelamento de Nota Fiscal Eletrônica";
                                this.cArquivoSchema = "cancNFe_v1.07.xsd";
                                break;

                            case "inutNFe":
                                tpRetornoTipoArq = Tipo_Arquivo.Inutilização_Numero_NFe;
                                this.cRetornoTipoArq = "XML de Inutilização de Numerações de Notas Fiscais Eletrônicas";
                                this.cArquivoSchema = "inutNFe_v1.07.xsd";
                                break;

                            case "consSitNFe":
                                tpRetornoTipoArq = Tipo_Arquivo.Consulta_Sit_Fiscal_NFe;
                                this.cRetornoTipoArq = "XML de Consulta da Situação da Nota Fiscal Eletrônica";
                                this.cArquivoSchema = "consSitNFe_v1.07.xsd";
                                break;

                            case "consReciNFe":
                                tpRetornoTipoArq = Tipo_Arquivo.Consulta_Recibo_NFe;
                                this.cRetornoTipoArq = "XML de Consulta do Recibo do Lote de Notas Fiscais Eletrônicas";
                                this.cArquivoSchema = "consReciNfe_v1.10.xsd";
                                break;

                            case "consStatServ":
                                tpRetornoTipoArq = Tipo_Arquivo.Consulta_Status_Servico_NFe;
                                this.cRetornoTipoArq = "XML de Consulta da Situação do Serviço da Nota Fiscal Eletrônica";
                                this.cArquivoSchema = "consStatServ_v1.07.xsd";
                                break;
                        }

                        //-- Arquivo já identificado.
                        if (tpRetornoTipoArq != Tipo_Arquivo.Vazio)
                            break;
                    }
                }
                oLerXml.Close();
            }
            else
            {
                tpRetornoTipoArq = Tipo_Arquivo.Arquivo_Nao_Identificado;
                this.cRetornoTipoArq = "Arquivo XML não foi encontrado";
            }

            if (tpRetornoTipoArq == Tipo_Arquivo.Vazio)
            {
                tpRetornoTipoArq = Tipo_Arquivo.XML_Invalido;
                this.cRetornoTipoArq = "Não foi possível identificar o arquivo XML";
            }
        }

        #endregion Identifica o tipo de arquivo XML
    }
}