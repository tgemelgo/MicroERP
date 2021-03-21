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
        /// Verifica se o WebService está ativo
        /// </summary>
        /// <param name="daNFe">Dados da NF-e para consuta do status do Webservice.</param>
        /// <returns>true/false Indicando se o serviço está Ativo</returns>
        public bool Status_WebService(Dados_Arquivo_NFe daNFe)
        {
            bool bRetorno = false;

            try
            {
                compFrameWork.Funcoes func;
                NFe.Dados_DocumentosNFe doc = new Dados_DocumentosNFe(Tipos_Servicos.NfeStatusServico, daNFe.Estado_Emissor);

                nfestatusservico4.NFeStatusServico4 nfe_Status = new nfestatusservico4.NFeStatusServico4();
                nfe_Status.Url = doc.Url_WebService;

                var certificado = Funcoes_NFe.Certificado_Digital(daNFe.Empresa);
                nfe_Status.ClientCertificates.Add(certificado);
                //nfe_Status.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.84 Safari/537.36";

                //-- Cria o XMl para envio.
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><consStatServ xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=");
                sb.Append('"');
                sb.Append(doc.Versao_Dados);
                sb.Append('"');
                sb.Append("><tpAmb>");
                sb.Append(func.Busca_Propriedade("Ambiente_NFe"));
                sb.Append("</tpAmb><cUF>");
                sb.Append(daNFe.Codigo_Estado_Emissor);
                sb.Append("</cUF><xServ>STATUS</xServ></consStatServ>");

                //-- Verifica status do serviço
                XmlNode sRetornoXML = nfe_Status.nfeStatusServicoNF(Funcoes_NFe.StringXmlToXMLDocument(sb.ToString()).DocumentElement);
                XmlDocument xml = Funcoes_NFe.StringXmlToXMLDocument(sRetornoXML.OuterXml);

                if (xml.GetElementsByTagName("cStat")[0].InnerText == "107")
                    bRetorno = true;
            }
            finally { }

            return bRetorno;
        }
    }
}