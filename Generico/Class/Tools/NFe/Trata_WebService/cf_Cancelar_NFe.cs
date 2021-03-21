using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CompSoft.NFe.TrataWebService
{
    public partial class NFeWebService
    {
        public XmlDocument Cancelar_NFe(Dados_Arquivo_NFe daNFe)
        {
            NFe.Dados_DocumentosNFe doc = new Dados_DocumentosNFe(Tipos_Servicos.nfeRecepcaoEvento, daNFe.Estado_Emissor);
            nferecepcaoevento4.NFeRecepcaoEvento4 nfe = new nferecepcaoevento4.NFeRecepcaoEvento4();

            //-- Busca a URL correta para trabalalho de acordo com o Estado e o nome do serviço
            nfe.Url = doc.Url_WebService;

            //-- Encontra o serial number do Certificado e adiciona ao web service.
            System.Security.Cryptography.X509Certificates.X509Certificate2 cert = Funcoes_NFe.Certificado_Digital(daNFe.Empresa);
            nfe.ClientCertificates.Add(cert);

            //nfeRecepcaoEvento.nfeCabecMsg cabecMsg  = new nfeRecepcaoEvento.nfeCabecMsg();
            //////-- Gera cabeçalho do cancelamento da NF-e
            ////NFeCancelamento2.nfeCabecMsg cabecMsg = new NFeCancelamento2.nfeCabecMsg();
            //cabecMsg.cUF = daNFe.Codigo_Estado_Emissor.ToString();
            //cabecMsg.versaoDados = doc.Versao_Dados;
            //nfe.nfeCabecMsgValue = cabecMsg;

            StringBuilder sb = new StringBuilder(5000);
            sb.Append("<envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\">");
            sb.AppendFormat("<idLote>{0}</idLote>", daNFe.Numero_Lote);
            sb.Append("<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\">");
            sb.AppendFormat("<infEvento Id=\"ID110111{0}01\">", daNFe.Chave_Acesso);
            sb.Append("<cOrgao>35</cOrgao>");
            sb.AppendFormat("<tpAmb>{0}</tpAmb>", Convert.ToInt32(daNFe.Ambiente));
            sb.AppendFormat("<CNPJ>{0}</CNPJ>", daNFe.CNPJ);
            sb.AppendFormat("<chNFe>{0}</chNFe>", daNFe.Chave_Acesso);
            sb.AppendFormat("<dhEvento>{0:yyyy-MM-ddTHH:mm:sszzz}</dhEvento>", DateTime.Now);
            sb.Append("<tpEvento>110111</tpEvento>");
            sb.Append("<nSeqEvento>1</nSeqEvento>");
            sb.Append("<verEvento>1.00</verEvento>");
            sb.Append("<detEvento versao=\"1.00\">");
            sb.Append("<descEvento>Cancelamento</descEvento>");
            sb.AppendFormat("<nProt>{0}</nProt>", daNFe.Numero_Autorizacao_Uso);
            sb.Append("<xJust>Compra cancelada pelo cliente</xJust>");
            sb.Append("</detEvento>");
            sb.Append("</infEvento>");
            sb.Append("</evento>");
            sb.Append("</envEvento>");

            //-- Salva XML temporariamente em disco.
            string sFolder_temp = System.Windows.Forms.Application.StartupPath;
            if (!sFolder_temp.EndsWith(@"\"))
                sFolder_temp += @"\";

            sFolder_temp += @"tmp\";

            if (!System.IO.Directory.Exists(sFolder_temp))
                System.IO.Directory.CreateDirectory(sFolder_temp);

            string sFile_tmp = sFolder_temp + daNFe.Chave_Acesso + "-canc.xml";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(sFile_tmp);
            sw.Write(sb.ToString());
            sw.Close();
            sw.Dispose();

            //-- Assina arquivo para envio.
            AssinaXML assinar = new AssinaXML();
            assinar.AssinarArquivoXML(sFile_tmp, "infEvento", cert.SerialNumber);

            //-- Limpa stringbuilder e carrega o arquivo assinado.
            System.IO.StreamReader sr = new System.IO.StreamReader(sFile_tmp);
            sb.Remove(0, sb.Length);
            sb.Append(sr.ReadToEnd()); //-- Adiciona o arquivo do inteiro no stringbuilder
            sr.Close();
            sr.Dispose();

            //-- apaga o arquivo criado.
            System.IO.Directory.Delete(sFolder_temp, true);

            //-- Verifica status do serviço
            XmlNode sRetornoXML = nfe.nfeRecepcaoEvento(Funcoes_NFe.StringXmlToXMLDocument(sb.ToString()).DocumentElement);
            XmlDocument xml = Funcoes_NFe.StringXmlToXMLDocument(sRetornoXML.OuterXml);

            return xml;
        }
    }
}