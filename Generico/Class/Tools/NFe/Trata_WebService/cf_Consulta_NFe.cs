using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace CompSoft.NFe.TrataWebService
{
    public partial class NFeWebService
    {
        /// <summary>
        /// Consulta situação atual da NF-e na Secretária da Fazenda.
        /// </summary>
        /// <param name="daNFe">Dados_Arquivo_NFe com todos os paramentros necessários para NF-e</param>
        /// <returns>XmlDocument com o resultado da pesquisa.</returns>
        public XmlDocument Consulta_NFe(Dados_Arquivo_NFe daNFe)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            NFe.Dados_DocumentosNFe doc = new Dados_DocumentosNFe(Tipos_Servicos.NfeConsultaProtocolo, daNFe.Estado_Emissor);
            nfeconsultaprotocolo4.NFeConsultaProtocolo4 nfe = new nfeconsultaprotocolo4.NFeConsultaProtocolo4();

            //-- Busca a URL correta para trabalalho de acordo com o Estado e o nome do serviço
            nfe.Url = doc.Url_WebService;

            //-- Encontra o serial number do Certificado e adiciona ao web service.
            nfe.ClientCertificates.Add(Funcoes_NFe.Certificado_Digital(daNFe.Empresa));

            //-- Cria o XMl para envio.
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><consSitNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=");
            sb.Append('"');
            sb.Append(doc.Versao_Dados);
            sb.Append('"');
            sb.Append("><tpAmb>");
            sb.Append((int)daNFe.Ambiente);
            sb.Append("</tpAmb><xServ>CONSULTAR</xServ><chNFe>");
            sb.Append(daNFe.Chave_Acesso);
            sb.Append("</chNFe></consSitNFe>");

            //-- Verifica status do serviço
            XmlNode sRetornoXML = nfe.nfeConsultaNF(Funcoes_NFe.StringXmlToXMLDocument(sb.ToString()).DocumentElement);
            XmlDocument xml = Funcoes_NFe.StringXmlToXMLDocument(sRetornoXML.OuterXml);

            return xml;
        }
    }
}