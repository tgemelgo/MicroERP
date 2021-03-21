using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CompSoft.NFe.TrataWebService
{
    public partial class NFeWebService
    {
        public XmlDocument CartaCorrecao_NFe(Dados_Arquivo_NFe daNFe)
        {
            if (string.IsNullOrEmpty(daNFe.Texto_Carta_Correcao))
            {
                MessageBox.Show("O Texto da carta de correção não foi definido, por favor, edita a NFe e tente novamente.");
                return null;
            }

            NFe.Dados_DocumentosNFe doc = new Dados_DocumentosNFe(Tipos_Servicos.nfeRecepcaoEvento, daNFe.Estado_Emissor);
            nferecepcaoevento4.NFeRecepcaoEvento4 nfe = new nferecepcaoevento4.NFeRecepcaoEvento4();

            //-- Busca a URL correta para trabalalho de acordo com o Estado e o nome do serviço
            nfe.Url = doc.Url_WebService;

            //-- Encontra o serial number do Certificado e adiciona ao web service.
            System.Security.Cryptography.X509Certificates.X509Certificate2 cert = Funcoes_NFe.Certificado_Digital(daNFe.Empresa);
            nfe.ClientCertificates.Add(cert);

            int contador = 1;
            string evento = "110110";
            string _query = string.Format("select Contador from Notas_Fiscais_Lotes_Contagens where Nota_Fiscal_Lote = {0} and Codigo_Evento = '{1}'"
                , daNFe.Cod_Nota_Fiscal_Lote, evento);

            object objContador = SQL.ExecuteScalar(_query);
            if (objContador == null)
            {
                _query = "insert Notas_Fiscais_Lotes_Contagens(Nota_Fiscal_Lote, Codigo_Evento, Contador) VALUES({0}, '{1}', {2})";
                _query = string.Format(_query, daNFe.Cod_Nota_Fiscal_Lote, evento, contador);
            }
            else
            {
                contador = Convert.ToInt32(objContador) + 1;
                _query = "update Notas_Fiscais_Lotes_Contagens set Contador = {2} where Nota_Fiscal_Lote = {0} and Codigo_Evento = '{1}'";
                _query = string.Format(_query, daNFe.Cod_Nota_Fiscal_Lote, evento, contador);
            }
            SQL.ExecuteNonQuery(_query);

            StringBuilder sb = new StringBuilder(5000);
            sb.Append("<envEvento versao=\"1.00\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">");
            sb.AppendFormat("<idLote>{0}</idLote>", daNFe.Numero_Lote);
            sb.Append("<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\">");
            sb.AppendFormat("<infEvento Id=\"ID{1}{0}{2}\">", daNFe.Chave_Acesso, evento, contador.ToString().PadLeft(2, '0'));
            sb.Append("<cOrgao>35</cOrgao>");
            sb.AppendFormat("<tpAmb>{0}</tpAmb>", Convert.ToInt32(daNFe.Ambiente));
            sb.AppendFormat("<CNPJ>{0}</CNPJ>", daNFe.CNPJ);
            sb.AppendFormat("<chNFe>{0}</chNFe>", daNFe.Chave_Acesso);
            sb.AppendFormat("<dhEvento>{0:yyyy-MM-ddTHH:mm:sszzz}</dhEvento>", DateTime.Now);
            sb.AppendFormat("<tpEvento>{0}</tpEvento>", evento);
            sb.AppendFormat("<nSeqEvento>{0}</nSeqEvento>", contador);
            sb.Append("<verEvento>1.00</verEvento>");
            sb.Append("<detEvento versao=\"1.00\">");
            sb.Append("<descEvento>Carta de Correcao</descEvento>");

            sb.AppendFormat("<xCorrecao>{0}</xCorrecao>", daNFe.Texto_Carta_Correcao.Replace("\r\n", " "));

            sb.Append("<xCondUso>A Carta de Correcao e disciplinada pelo paragrafo 1o-A do art. 7o do Convenio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularizacao de erro ocorrido na emissao de documento fiscal, desde que o erro nao esteja relacionado com: I - as variaveis que determinam o valor do imposto tais como: base de calculo, aliquota, diferenca de preco, quantidade, valor da operacao ou da prestacao; II - a correcao de dados cadastrais que implique mudanca do remetente ou do destinatario; III - a data de emissao ou de saida.</xCondUso>");
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

            string sFile_tmp = sFolder_temp + daNFe.Chave_Acesso + "-cartacor.xml";
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