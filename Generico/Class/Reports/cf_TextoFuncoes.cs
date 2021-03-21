using System;
using System.Collections.Generic;
using System.Text;

namespace CompSoft.Reports
{
    public struct Funcoes_Matricial
    {
        public enum Tipo_Zero
        {
            Inteiro,
            Decimal
        }

        public static string Zero_Branco(object oValor, Tipo_Zero tp_zero)
        {
            if (oValor != DBNull.Value && Convert.ToDecimal(oValor) > 0)
            {
                if (tp_zero == Tipo_Zero.Inteiro)
                    return Convert.ToInt32(oValor).ToString();
                else
                    return Convert.ToDecimal(oValor).ToString();
            }
            else
                return "";
        }

        public static string Centralizar(int iTotalColunas, string sTexto)
        {
            int iMetade_Coluna = iTotalColunas / 2;
            iMetade_Coluna = iMetade_Coluna - (sTexto.Length / 2);

            string sRetorno = string.Empty.PadRight(iMetade_Coluna);
            sRetorno += sTexto;

            return sRetorno;
        }

        public static string PadL(string sValor, int iTamanho, string sCaracter)
        {
            if (sValor.Length > iTamanho)
                sValor = sValor.Substring(0, iTamanho);
            else
                sValor = sValor.PadLeft(iTamanho, Convert.ToChar(sCaracter));

            return sValor;
        }

        public static string PadL(string sValor, int iTamanho)
        {
            if (sValor.Length > iTamanho)
                sValor = sValor.Substring(0, iTamanho);
            else
                sValor = sValor.PadLeft(iTamanho, Convert.ToChar(' '));

            return sValor;
        }

        public static string PadR(string sValor, int iTamanho, string sCaracter)
        {
            if (sValor.Length > iTamanho)
                sValor = sValor.Substring(0, iTamanho);
            else
                sValor = sValor.PadRight(iTamanho, Convert.ToChar(sCaracter));

            return sValor;
        }

        public static string PadR(string sValor, int iTamanho)
        {
            if (sValor.Length > iTamanho)
                sValor = sValor.Substring(0, iTamanho);
            else
                sValor = sValor.PadRight(iTamanho, Convert.ToChar(' '));

            return sValor;
        }

        public static string Formata_CNPJ_CPF(string sValor)
        {
            decimal dValor = 0;
            decimal.TryParse(sValor, out dValor);
            if (dValor != 0)
            {
                if (sValor.Length <= 11)
                    return dValor.ToString(@"000\.###\.###\-##");
                else
                    return dValor.ToString(@"00\.###\.###\/####\-##");
            }
            else
                return sValor;
        }

        public static string Formata_CEP(string sValor)
        {
            decimal dValor = 0;
            decimal.TryParse(sValor, out dValor);
            if (dValor == 0)
                return sValor;
            else
                return dValor.ToString(@"00000\-000");
        }

        public static string Formata_IE(string sValor)
        {
            string sRetorno = string.Empty;

            decimal dValor = 0;
            decimal.TryParse(sValor, out dValor);
            if (dValor == 0)
                sRetorno = sValor;
            else
                sRetorno = dValor.ToString(@"000\.000\.000\.000");

            return sRetorno;
        }

        public static string Formata_Telefone(string DDD, string Telefone)
        {
            string sFone = string.Empty;
            if (!string.IsNullOrEmpty(DDD))
                sFone = string.Format("({0:0##})", DDD);

            decimal dTelefone = 0;
            decimal.TryParse(Telefone, out dTelefone);
            sFone += dTelefone.ToString(@"0000\-0000");

            return sFone;
        }
    }
}