using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace CompSoft.NFe.TrataWebService
{
    public partial class NFeWebService
    {
        #region Envia NF-e

        /// <summary>
        /// Envia arquivo de lote de NF-e
        /// </summary>
        /// <param name="daNFe">classe que contem todos os parametros do arquivo XML</param>
        /// <returns>XMLDocument com o recibo de envio</returns>
        public XmlDocument Enviar_LoteNFe(Dados_Arquivo_NFe daNFe)
        {
            NFe.Dados_DocumentosNFe doc = new Dados_DocumentosNFe(Tipos_Servicos.NfeRecepcao, daNFe.Estado_Emissor);

            var certificado = Funcoes_NFe.Certificado_Digital(daNFe.Empresa);

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            autorizeNFE.NFeAutorizacao4 nfe = new autorizeNFE.NFeAutorizacao4();
            nfe.Url = doc.Url_WebService; //--"https://nfe.fazenda.sp.gov.br/ws/nfeautorizacao4.asmx";
            nfe.ClientCertificates.Add(certificado);
            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;

            //-- Captura o XML do arquivo.
            XmlDocument xml = new XmlDocument();
            xml.Load(daNFe.Arquivo_XML);

            //-- Gera o número do lote.
            CompSoft.compFrameWork.Funcoes func;
            string sNum_Lote_NFe = func.Contador("IdLote_NFe", true);
            daNFe.Numero_Lote = Convert.ToInt32(sNum_Lote_NFe);

            ////-- Gera cabeçalho da NF-e
            //NFeRecepcao2.nfeCabecMsg cabecMsg = new NFeRecepcao2.nfeCabecMsg();
            //cabecMsg.cUF = daNFe.Codigo_Estado_Emissor.ToString();
            //cabecMsg.versaoDados = doc.Versao_Dados;
            //nfe.nfeCabecMsgValue = cabecMsg;

            //-- Gera capa do processo do lote
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=");
            sb.Append('"');
            sb.Append(doc.Versao_Dados);
            sb.Append('"');
            sb.Append("><idLote>");
            sb.Append(sNum_Lote_NFe);
            sb.Append("</idLote>");
            sb.Append("<indSinc>0</indSinc>");
            sb.Append(xml.GetElementsByTagName("NFe")[0].OuterXml);
            sb.Append("</enviNFe>");

            //-- Faz a comunicação com o servidor.
            XmlNode sRetorno_XML = nfe.nfeAutorizacaoLote(Funcoes_NFe.StringXmlToXMLDocument(sb.ToString()).DocumentElement);

            //-- XML de retorno.
            XmlDocument xml_Ret = Funcoes_NFe.StringXmlToXMLDocument(sRetorno_XML.OuterXml);

            return xml_Ret;
        }

        #endregion Envia NF-e

        #region Captura o resultado do processamento do lote NF-e

        /// <summary>
        /// Captura o retorno do processamento do lote da NF-e
        /// </summary>
        /// <param name="daNFe">Dados_Arquivo_NFe com os parametros da NF-e</param>
        /// <returns>XML com o resultado do processamento</returns>
        public XmlDocument Resultado_Processamento_NFe(Dados_Arquivo_NFe daNFe)
        {
            NFe.Dados_DocumentosNFe doc = new Dados_DocumentosNFe(Tipos_Servicos.NfeRetRecepcao, daNFe.Estado_Emissor);

            var certificado = Funcoes_NFe.Certificado_Digital(daNFe.Empresa);

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            nferetautorizacao4.NFeRetAutorizacao4 nfe = new nferetautorizacao4.NFeRetAutorizacao4();
            nfe.Url = doc.Url_WebService;
            nfe.ClientCertificates.Add(certificado);
            nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;

            //-- Consulta de dados.
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><consReciNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=");
            sb.Append('"');
            sb.Append(doc.Versao_Dados);
            sb.Append('"');
            sb.Append("><tpAmb>");
            sb.Append((int)daNFe.Ambiente);
            sb.Append("</tpAmb><nRec>");
            sb.Append(daNFe.Numero_Recibo);
            sb.Append("</nRec></consReciNFe>");

            //-- Faz a comunicação com o servidor.
            XmlNode sRetorno_XML = nfe.nfeRetAutorizacaoLote(Funcoes_NFe.StringXmlToXMLDocument(sb.ToString()).DocumentElement);

            //-- XML de retorno.
            XmlDocument xml = Funcoes_NFe.StringXmlToXMLDocument(sRetorno_XML.OuterXml);

            //-- Salva resultado do processamento no XML da NF-e.
            this.Salva_XML_Envio_Cliente(daNFe.Arquivo_XML, xml);

            return xml;
        }

        #endregion Captura o resultado do processamento do lote NF-e

        #region Sobre escreve o arquivo original com o protocolo de retorno

        /// <summary>
        /// Sobre escreve o arquivo original com o protocolo de retorno
        /// </summary>
        /// <param name="sFile_NFe">string com o path do arquivo da NF-e</param>
        /// <param name="xml_Retorno">XMLDocument com o protocolo de retorno do processamento.</param>
        private void Salva_XML_Envio_Cliente(string sFile_NFe, XmlDocument xml_Retorno)
        {
            if (xml_Retorno.GetElementsByTagName("protNFe").Count > 0)
            {
                NFe.Dados_DocumentosNFe doc = new Dados_DocumentosNFe(Tipos_Servicos.Sem_WebService_Arquivo_NFe_Cliente);

                //-- Captura o XML do arquivo.
                XmlDocument xml = new XmlDocument();
                xml.Load(sFile_NFe);

                //-- Cria o novo XML com base nas informações existentes.
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><nfeProc xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=");
                sb.Append('"');
                sb.Append(doc.Versao_Dados);
                sb.Append('"');
                sb.Append(">");
                sb.Append(xml.GetElementsByTagName("NFe")[0].OuterXml);
                sb.Append(xml_Retorno.GetElementsByTagName("protNFe")[0].OuterXml);
                sb.Append("</nfeProc>");

                //-- Salva o arquivo em disco...
                StreamWriter sw = new StreamWriter(sFile_NFe);
                sw.Write(sb.ToString());
                sw.Close();
                sw.Dispose();
            }
        }

        #endregion Sobre escreve o arquivo original com o protocolo de retorno
    }
}