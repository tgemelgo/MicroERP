using CompSoft.Data;
using System;
using System.Text;

namespace ERP.Financeiro
{
    public class VerificacoesFinanceiras
    {
        /// <summary>
        /// Verifica se existem titulos não pagos vencidos.
        /// </summary>
        /// <param name="iCliente">Código do cliente</param>
        /// <returns>true/false indicando se existem titulos em aberto.</returns>
        internal bool TitulosNaoPagosAtrasados(int iCliente)
        {
            bool bRetorno = false;

            StringBuilder sb = new StringBuilder(500);
            sb.AppendLine("SELECT COUNT(cr.Conta_receber)");
            sb.AppendLine(" FROM Contas_Receber cr");
            sb.AppendLine("  INNER JOIN Contas_Receber_Parcela crp ON cr.Conta_receber = crp.Conta_Receber");
            sb.AppendLine(" WHERE       crp.Parcela_Paga = 0");
            sb.AppendLine("   AND crp.Data_Vencimento <= CONVERT(DATETIME, CONVERT(VARCHAR(10), GETDATE(), 112))");
            sb.AppendFormat("   AND cr.cliente = {0}", iCliente);

            int iQtdeEncontrado = Convert.ToInt32(SQL.ExecuteScalar(sb.ToString()));

            if (iQtdeEncontrado > 0)
                bRetorno = true;

            return bRetorno;
        }
    }
}