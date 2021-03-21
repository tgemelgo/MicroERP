using CompSoft.Data;
using CompSoft.NFe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ERP.NFe
{
    internal partial class NFe
    {
        public void Cancelar_NFe(IList<Dados_Arquivo_NFe> ilNotas)
        {
            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, cancelando NF-e no SEFAZ.", true, ilNotas.Count);

            foreach (Dados_Arquivo_NFe daNFe in ilNotas)
            {
                //-- Busca informações no WebService
                CompSoft.NFe.TrataWebService.NFeWebService wb_NFe = new CompSoft.NFe.TrataWebService.NFeWebService();
                XmlDocument doc = wb_NFe.Cancelar_NFe(daNFe);

                StringBuilder sb = new StringBuilder(300);

                //-- Verifica se a mensagem é de confirmação do cancelamento da NF-e
                if (Convert.ToInt32(doc.GetElementsByTagName("cStat")[0].InnerText) == 101)
                {
                    sb.Append("update notas_fiscais_lotes set ");
                    sb.AppendFormat("     codigo_mensagem_retorno_nfe = {0}", doc.GetElementsByTagName("cStat")[0].InnerText);
                    sb.AppendFormat("   , protocolo_cancelamento_nfe = '{0}'", doc.GetElementsByTagName("nProt")[0].InnerText);
                    sb.AppendFormat("   , data_cancelamento_Nfe = '{0}'", doc.GetElementsByTagName("dhRecbto")[0].InnerText.Replace("T", " ").Replace("-", "").Substring(0, 17));
                    sb.AppendFormat("   where nota_fiscal_lote = {0}", daNFe.Cod_Nota_Fiscal_Lote);
                    SQL.ExecuteNonQuery(sb.ToString());

                    sb.Clear();
                    sb.AppendFormat("update notas_fiscais set cancelada = 1 where nota_fiscal = {0}", daNFe.Nota_Fiscal);
                    SQL.ExecuteNonQuery(sb.ToString());

                    ERP.NFe.Enviar_XML_Email envMail_Nfe;
                    envMail_Nfe.Cancelar_NF(daNFe, doc.GetElementsByTagName("nProt")[0].InnerText);
                }
                else
                {
                    int iStatusExiste = Convert.ToInt32(SQL.ExecuteScalar(string.Format("SELECT COUNT(*) FROM MENSAGENS_RETORNO_NFE WHERE CODIGO_MENSAGEM_RETORNO = {0}", doc.GetElementsByTagName("cStat")[1].InnerText)));

                    if (iStatusExiste == 0)
                    {
                        string sQuery = string.Format(@"insert MENSAGENS_RETORNO_NFE values({0}, '{1}')"
                                                        , doc.GetElementsByTagName("cStat")[1].InnerText
                                                        , doc.GetElementsByTagName("xMotivo")[1].InnerText.Replace("'", " "));

                        SQL.ExecuteNonQuery(sQuery);
                    }

                    sb.Append("update notas_fiscais_lotes set ");
                    sb.AppendFormat("     codigo_mensagem_retorno_nfe = {0}", doc.GetElementsByTagName("cStat")[1].InnerText);
                    sb.AppendFormat("   where nota_fiscal_lote = {0}", daNFe.Cod_Nota_Fiscal_Lote);
                    SQL.ExecuteNonQuery(sb.ToString());
                }

                f.Atual_Progresso++;
            }

            f.Close();
            f.Dispose();
        }
    }
}