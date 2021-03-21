using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ERP.NFe
{
    internal class Mensagens_NFe
    {
        #region Encontra mensagens da nota

        public IList<string> Captura_Mensagem(int iCodigoNF)
        {
            IList<string> il = new List<string>();

            //-- Query para buscar todas as mensagens da NF
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select 999 as mensagem_nota, cl.Observacoes_Nota as 'mensagem'");
            sb.AppendLine(" from clientes cl");
            sb.AppendLine("  inner join notas_fiscais nf on nf.cliente = cl.cliente");
            sb.AppendFormat(" where nf.nota_fiscal = {0} ", iCodigoNF);
            sb.AppendLine("union");
            sb.AppendLine("select 998 as mensagem_nota, Mensagem_padrao_nota as 'mensagem'");
            sb.AppendLine(" from empresas e");
            sb.AppendLine("  inner join notas_fiscais nf on nf.empresa = e.empresa");
            sb.AppendFormat(" where nf.nota_fiscal = {0} ", iCodigoNF);
            sb.AppendLine("union");
            sb.AppendLine("select distinct mn.mensagem_nota, mn.mensagem");
            sb.AppendLine(" from produtos_tributos pt");
            sb.AppendLine("  inner join produtos_tributos_mensagens ptm on ptm.produto_tributo = pt.produto_tributo");
            sb.AppendLine("  inner join mensagens_notas mn on mn.mensagem_nota = ptm.mensagem_nota");
            sb.AppendLine("  inner join notas_fiscais_itens nfi on nfi.produto = pt.produto");
            sb.AppendLine("  inner join notas_fiscais nf on nf.nota_fiscal = nfi.nota_fiscal");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine(" where ");
            sb.AppendLine("      pt.produto = nfi.produto");
            sb.AppendLine("  AND pt.empresa = nf.empresa");
            sb.AppendLine("  AND pt.origem = e.estado");
            sb.AppendLine("  AND pt.destino = cl.estado_Correspondencia");
            sb.AppendLine("  AND ((pt.reducao_icms_geral = 1 OR (pt.reducao_icms_cliente = 1 AND cl.reducao_icms = 1)) OR pt.Reducao_ICMS = 0)");
            sb.AppendFormat("  AND nf.Nota_Fiscal = {0}", iCodigoNF);

            DataTable dt = SQL.Select(sb.ToString(), "x", false);

            //-- Encontrar regras.
            foreach (DataRow row in dt.Select())
            {
                bool bIncluirMensagem = true;

                //-- Encontra regra para utilização.
                string sQuery = "select Query_Verifica_Utilizacao, Query_Substituicao from mensagens_notas where mensagem_nota = {0}";
                sQuery = string.Format(sQuery, row["Mensagem_Nota"]);
                DataTable dt_Verifica = SQL.Select(sQuery, "x", false);

                string sMensagem = row["mensagem"].ToString();

                if (dt_Verifica.Rows.Count >= 1)
                {
                    //-- Verifica se existe regra para aplicar esta mensagem.
                    if (dt_Verifica.Rows[0]["Query_Verifica_Utilizacao"] != DBNull.Value)
                    {
                        sQuery = dt_Verifica.Rows[0]["Query_Verifica_Utilizacao"].ToString();
                        sQuery = string.Format(sQuery, iCodigoNF);
                        int iRegEncontrado = Convert.ToInt32(SQL.ExecuteScalar(sQuery));

                        //-- Verifica se existe dados para substiuição
                        if (iRegEncontrado > 0 && dt_Verifica.Rows[0]["Query_Substituicao"] != DBNull.Value)
                        {
                            sQuery = dt_Verifica.Rows[0]["Query_Substituicao"].ToString();
                            sQuery = string.Format(sQuery, iCodigoNF);
                            DataTable dt_subsituicao = SQL.Select(sQuery, "x", false);

                            if (dt_subsituicao.Rows.Count > 0)
                            {
                                //-- Trata colunas
                                object[] oObject = new object[dt_subsituicao.Columns.Count];
                                for (int i = 0; i <= dt_subsituicao.Columns.Count - 1; i++)
                                {
                                    oObject[i] = dt_subsituicao.Rows[0][i];
                                }

                                sMensagem = string.Format(sMensagem, oObject);
                            }
                        }
                        else
                        {
                            bIncluirMensagem = false;
                        }
                    }
                }
                else
                {
                    if (Convert.ToInt32(row["Mensagem_Nota"]) == 999 || Convert.ToInt32(row["Mensagem_Nota"]) == 998)
                        bIncluirMensagem = true;
                    else
                        bIncluirMensagem = false;
                }

                if (bIncluirMensagem)
                    il.Add(sMensagem); //-- Adiciona a query.
            }

            return il;
        }

        #endregion Encontra mensagens da nota
    }
}