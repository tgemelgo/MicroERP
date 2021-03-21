using CompSoft.Data;
using System;

namespace ERP.Forms
{
    public partial class f0065 : CompSoft.FormSet
    {
        public f0065()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Objetos_Entrada"
                    , "select * from objetos_entrada"));

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //-- Envia nota para o ambiente de homologação
            CompSoft.NFe.TrataWebService.NFeWebService f = new CompSoft.NFe.TrataWebService.NFeWebService();

            /*
            IList<int> iNFe = new List<int>();
            //iNFe.Add(4083);
            iNFe.Add(4085);
            iNFe.Add(4090);

            //-- Gera dados da NF-e
            ERP.NFe.GerarDadosNFe dados = new ERP.NFe.GerarDadosNFe();
            dados.Gerar_Dados_NFe(iNFe);

            //-- Gera arquivo XML das notas selecionadas.
            ERP.NFe.XML_NFe nfe = new ERP.NFe.XML_NFe(@"c:\temp", dados.DataSet_NFe);
            nfe.Gerar_XML_NFe();

            CompSoft.NFe.ValidadorXMLClass v = new CompSoft.NFe.ValidadorXMLClass();

            foreach (string sFile in nfe.Arquivos_Gerados)
            {
                CompSoft.NFe.AssinaXML a = new CompSoft.NFe.AssinaXML();
                if (a.AssinarArquivoXML(sFile, "infNFe"))
                {
                    //-- Valida XML
                    v.ValidarXML(sFile, @"F:\NFe\Schemas\nfe_v1.10.xsd");
                    if (v.Retorno != CompSoft.NFe.ValidadorXMLClass.Tipo_Retorno_Validacao.Sucesso)
                        MessageBox.Show(v.RetornoString);
                }
                else
                    MessageBox.Show("Impossivel assinar");
            }

            //-- Gera lote.
            //nfe.Gerar_XML_Lote_NFe();

            //-- Consulta Status
            MessageBox.Show(f.Status_WebService("SP").ToString());

            System.Xml.XmlDocument xml = f.Enviar_LoteNFe("SP", nfe.Arquivos_Gerados[0]);

            System.Xml.XmlDocument xml_Ret = f.Resultado_Processamento_NFe("SP", xml.GetElementsByTagName("nRec")[0].InnerText);

            f.Salva_XML_Envio_Cliente(nfe.Arquivos_Gerados[0], xml_Ret);
            MessageBox.Show("fim");
            */
            //f.Consulta_NFe("35090602640575000285550000000003220000040854", CompSoft.NFe.Ambientes.Homologacao, "SP");

            //f.Consulta_Cadastro_Cliente("SP", "SP", "114776266112", "62461140000117");

            /*
            ERP.Reports.rDanfe r = new ERP.Reports.rDanfe(dados.DataSet_NFe);
            r.ShowPreviewDialog();
            */
        }
    }
}