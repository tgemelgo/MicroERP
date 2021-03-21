using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CompSoft.NFe.TrataWebService
{
    public partial class NFeWebService
    {
        public XmlDocument Consulta_Cadastro_Cliente(string sEstado, string sEstado_Cliente, string sIE_Cliente, string sCpfCnpj_Cliente, int iEmpresa)
        {
            NFe.Dados_DocumentosNFe doc = new Dados_DocumentosNFe(Tipos_Servicos.NfeConsultaCadastro, sEstado);
            cadconsultacadastro4.CadConsultaCadastro4 nfe = new cadconsultacadastro4.CadConsultaCadastro4();

            //-- Busca a URL correta para trabalalho de acordo com o Estado e o nome do serviço
            nfe.Url = doc.Url_WebService;

            //-- Encontra o serial number do Certificado e adiciona ao web service.
            nfe.ClientCertificates.Add(Funcoes_NFe.Certificado_Digital(iEmpresa));

            //-- Cria o XMl para envio.
            StringBuilder sb = new StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><consCad><versao>1.01</versao><infCons><xServ>CONS-CAD</xServ><UF>SP</UF><CNPJ>62461140000117</CNPJ></infCons></consCad>");

            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"c:\teste.xml");
            sw.Write(sb.ToString());
            sw.Close();
            sw.Dispose();

            CompSoft.NFe.ValidadorXMLClass valida = new ValidadorXMLClass();
            valida.ValidarXML(@"c:\teste.xml", @"F:\NFe\Schemas\consCad_v1.01.xsd");

            //-- Verifica status do serviço
            XmlNode sRetornoXML = nfe.consultaCadastro(Funcoes_NFe.StringXmlToXMLDocument(sb.ToString()).DocumentElement);

            XmlDocument xml = Funcoes_NFe.StringXmlToXMLDocument(sRetornoXML.OuterXml);

            return xml;
        }
    }
}