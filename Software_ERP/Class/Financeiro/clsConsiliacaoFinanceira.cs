using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Data;
using System.Globalization;
using System.Text;

namespace ERP.Financeiro
{
    internal class ConsiliacaoFinanceira
    {
        #region Marca notas fiscais como consiliadas para não efetuar novamente a consiliação

        private void Marca_NF_Consiliada(int iNotaFiscal)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update notas_fiscais set ");
            sb.Append("Consiliacao_Financeira_Realizada = 1 ");
            sb.AppendFormat("where nota_fiscal = {0}", iNotaFiscal);

            SQL.Execute(sb.ToString(), true);
        }

        #endregion Marca notas fiscais como consiliadas para não efetuar novamente a consiliação

        #region Processo que gera a consiliação

        /// <summary>
        /// Gera consiliação financeira a partir de um range de datas
        /// </summary>
        /// <param name="dtInicial">Data Inicial</param>
        /// <param name="dtFinal">Data Final</param>
        public void Gerar_Consiliacao(DateTime dtInicial, DateTime dtFinal)
        {
            DataTable dt = this.Buscar_NF(dtInicial, dtFinal); //-- Busca notas por data

            this.Consiliacao(dt); //-- Realiza a consiliação

            SQL.Fechar_Conexao(); //-- Fecha a conexão com o banco de dados.
        }

        /// <summary>
        /// Gera a consiliação financeira a partir de uma Nota Fiscal
        /// </summary>
        /// <param name="iNotaFiscal">int com o código da NF</param>
        public void Gerar_Consiliacao(int iNotaFiscal)
        {
            DataTable dt = this.Buscar_NF(iNotaFiscal); //-- Busca notas por data

            this.Consiliacao(dt); //-- Realiza a consiliação

            SQL.Fechar_Conexao(); //-- Fecha a conexão com o banco de dados.
        }

        /// <summary>
        /// Gera consiliação financeira
        /// </summary>
        /// <param name="dtNotasFiscais">DataTable com informações da NF</param>
        private void Consiliacao(DataTable dtNotasFiscais)
        {
            Funcoes func;

            //-- Busca Notas fiscais para integração com o contas a receber.
            DataView dv_NF = new DataView(dtNotasFiscais);

            foreach (DataRowView row_nf in dv_NF)
            {
                string sNumero_Documento;
                if (Convert.ToBoolean(row_nf["Gera_NF"]))
                    sNumero_Documento = row_nf["Numero_Nota"].ToString();
                else
                    sNumero_Documento = "PED.(" + row_nf["Pedido"].ToString() + ")";

                //-- Cria query para incluir registro
                StringBuilder sb = new StringBuilder(300);
                sb.Append("insert Contas_receber(Empresa, Cliente, Numero_Documento, Tipo_Documento");
                sb.AppendLine(", Tipo_Pagamento, Valor_Original, Valor_Pago, Data_Cadastro, Nota_Fiscal)");
                sb.AppendFormat(CultureInfo.GetCultureInfo("en-us")
                        , " values({0}, {1}, '{2}', {3}, {4}, {5}, {6}, '{7}', {8})"
                        , row_nf["Empresa"]
                        , row_nf["Cliente"]
                        , sNumero_Documento
                        , func.Busca_Propriedade("Tp_Doc_Cons_Financ_CR")
                        , func.Busca_Propriedade("Tp_Pag_Cons_Financ_CR")
                        , row_nf["Valor_total_nota"]
                        , row_nf["Valor_total_nota"]
                        , DateTime.Now.ToString("yyyyMMdd")
                        , row_nf["Nota_Fiscal"]);
                SQL.Execute(sb.ToString(), true);

                //-- Captura o Identity que foi inserido.
                object oValor = SQL.ExecuteScalar("select @@Identity", true);
                int iConta_Receber = ((oValor != DBNull.Value) ? Convert.ToInt32(oValor) : 0);

                //-- Captura duplicatas para inclusão das parcelas da conta a receber.
                DataView dv_DuplNF = new DataView(this.Buscar_DuplicatasNF(Convert.ToInt32(row_nf["Nota_Fiscal"])));
                foreach (DataRowView row_dup in dv_DuplNF)
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("insert contas_receber_parcela(Conta_Receber, Parcela, Data_Cadastro");
                    sb.Append(", Data_Emissao, Data_Vencimento, Valor_Original, Valor_Receber");
                    sb.AppendLine(", Parcela_Paga)");
                    sb.AppendFormat(CultureInfo.GetCultureInfo("en-us")
                            , " values({0}, {1}, '{2}', '{3}', '{4}', {5}, {6}, 0)"
                            , iConta_Receber
                            , row_dup["Numero_Parcela"]
                            , DateTime.Now.ToString("yyyyMMdd")
                            , Convert.ToDateTime(row_nf["Data_Emissao"]).ToString("yyyyMMdd")
                            , Convert.ToDateTime(row_dup["Data_Vencimento"]).ToString("yyyyMMdd")
                            , row_dup["Valor_Duplicata"]
                            , row_dup["Valor_Duplicata"]);
                    SQL.Execute(sb.ToString(), true);
                }

                //-- Marca a NF como consiliada evitando a geração de duplicidades.
                this.Marca_NF_Consiliada(Convert.ToInt32(row_nf["Nota_Fiscal"]));
            }
        }

        #endregion Processo que gera a consiliação

        #region Busca as notas fiscais e itens da Nota fiscal.

        private DataTable Buscar_NF(DateTime dtInicial, DateTime dtFinal)
        {
            StringBuilder sb = new StringBuilder(200);
            sb.AppendLine("select nf.*, pe.Gera_NF ");
            sb.AppendLine(" from notas_fiscais nf ");
            sb.AppendLine("     inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendFormat(" where nf.Data_emissao between '{0} 00:00:00' and '{1} 23:59:29'"
                    , dtInicial.ToString("yyyyMMdd")
                    , dtFinal.ToString("yyyyMMdd"));
            sb.AppendLine("   and nf.cancelada = 0");
            sb.AppendLine("   and nf.Consiliacao_Financeira_Realizada = 0");
            return SQL.Select(sb.ToString(), "Notas_Fiscais", false);
        }

        private DataTable Buscar_NF(int iNotaFiscal)
        {
            StringBuilder sb = new StringBuilder(200);
            sb.AppendLine("select nf.*, pe.Gera_NF ");
            sb.AppendLine(" from notas_fiscais nf ");
            sb.AppendLine("     inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendFormat(" where nf.Nota_Fiscal = {0}", iNotaFiscal);
            sb.AppendLine("   and nf.cancelada = 0");
            sb.AppendLine("   and nf.Consiliacao_Financeira_Realizada = 0");
            return SQL.Select(sb.ToString(), "Notas_Fiscais", false);
        }

        private DataTable Buscar_DuplicatasNF(int iNotaFiscal)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from Notas_Fiscais_Duplicatas");
            sb.AppendFormat(" where Nota_Fiscal = {0}", iNotaFiscal);

            return SQL.Select(sb.ToString(), "Notas_Fiscais_Duplicatas", false);
        }

        #endregion Busca as notas fiscais e itens da Nota fiscal.

        #region Exclui consiliação do contas a receber

        /// <summary>
        /// Exclui conta a receber conciliada
        /// </summary>
        /// <param name="iNotaFiscal">Codigo da tabela de Notas Fiscais (NOTA FISCAL)</param>
        public void Excluir_ContaReceber(int iNotaFiscal)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.AppendLine("DELETE crm ");
            sb.AppendLine(" FROM contas_receber cr");
            sb.AppendLine("  INNER JOIN Contas_Receber_mov crm ON crm.Conta_Receber = cr.Conta_receber");
            sb.AppendFormat(" WHERE cr.Nota_Fiscal = {0}", iNotaFiscal);
            SQL.ExecuteNonQuery(sb.ToString());

            sb.Remove(0, sb.Length);
            sb.AppendLine("DELETE crp");
            sb.AppendLine(" FROM contas_receber cr");
            sb.AppendLine("  INNER JOIN Contas_Receber_Parcela crp ON crp.Conta_Receber = cr.Conta_receber");
            sb.AppendFormat(" WHERE cr.Nota_Fiscal = {0}", iNotaFiscal);
            SQL.ExecuteNonQuery(sb.ToString());

            sb.Remove(0, sb.Length);
            sb.AppendFormat("DELETE Contas_Receber WHERE Nota_Fiscal = {0}", iNotaFiscal);
            SQL.ExecuteNonQuery(sb.ToString());
        }

        /// <summary>
        /// Cancela uma baixa de um titulo
        /// </summary>
        /// <param name="iNotaFiscal">Codigo da tabela de Notas Fiscais (NOTA FISCAL)</param>
        /// <param name="iConta_Receber_Parcela">Código da parcela</param>
        public void Cancelar_Baixa_ContaReceber(int iNotaFiscal, int iConta_Receber_Parcela)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.AppendLine("DELETE crm");
            sb.AppendLine(" FROM Contas_Receber cr");
            sb.AppendLine("  INNER JOIN Contas_Receber_Parcela crp ON cr.Conta_receber = crp.Conta_Receber");
            sb.AppendLine("  INNER JOIN Contas_Receber_mov crm ON crm.Conta_Receber_Parcela = crp.Conta_Receber_Parcela");
            sb.AppendLine(" WHERE ");
            sb.AppendFormat("      cr.Nota_Fiscal = {0}", iNotaFiscal);
            sb.AppendFormat("  AND crp.Conta_Receber_Parcela = {0}", iConta_Receber_Parcela);
            SQL.ExecuteNonQuery(sb.ToString());

            sb.Remove(0, sb.Length);
            sb.AppendLine("UPDATE Contas_Receber_Parcela SET");
            sb.AppendLine("  Parcela_Paga = 0");
            sb.AppendFormat(" WHERE Conta_Receber_Parcela = {0}", iConta_Receber_Parcela);
            SQL.ExecuteNonQuery(sb.ToString());
        }

        #endregion Exclui consiliação do contas a receber
    }
}