using CompSoft.Data;
using CompSoft.NFe;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ERP.NFe
{
    internal partial class NFe
    {
        public void Consultar_Situacao_NFe(IList<Dados_Arquivo_NFe> ilNotas)
        {
            foreach (Dados_Arquivo_NFe daNFe in ilNotas)
            {
                //-- Busca informações no WebService
                CompSoft.NFe.TrataWebService.NFeWebService wb_NFe = new CompSoft.NFe.TrataWebService.NFeWebService();
                XmlDocument doc = wb_NFe.Consulta_NFe(daNFe);
                string sStatus_Retorno = doc.GetElementsByTagName("cStat")[0].InnerText;

                StringBuilder sb = new StringBuilder();
                sb.Append("update notas_fiscais_lotes set ");
                sb.AppendFormat("   codigo_mensagem_retorno_nfe = {0}", sStatus_Retorno);
                if (sStatus_Retorno == "100" || sStatus_Retorno == "101" || sStatus_Retorno == "110")
                {
                    //-- Atualiza flag de NF-e Exportada.
                    SQL.Execute(string.Format("update notas_fiscais set exportacao_Nfe = 1, nfe_protocolo = '{1}', nfe_protocolo_data = '{2}' where nota_fiscal = {0}"
                            , daNFe.Nota_Fiscal
                            , doc.GetElementsByTagName("nProt")[0].InnerText
                            , doc.GetElementsByTagName("dhRecbto")[0].InnerText.Replace("T", " ").Replace("-", "").Substring(0, 17)));
                }
                sb.AppendFormat("   where nota_fiscal_lote = {0}", daNFe.Cod_Nota_Fiscal_Lote);

                SQL.ExecuteNonQuery(sb.ToString());
            }
        }
    }
}