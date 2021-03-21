using System;
using System.Collections.Generic;

namespace CompSoft.compFrameWork
{
    public class Extenso
    {   /*******************************************************************************
    * Função para escrever por extenso os valores em Real (em C# - suporta até R$ 9.999.999.999,99)     *
    * Rotina Criada para ler um número e transformá-lo em extenso                                       *
    * Limite máximo de 9 Bilhões (9.999.999.999,99)                                                     *
    * Não aceita números negativos......                                                                *
    ************************************************************************************/

        public string Extenso_Valor(decimal pdbl_Valor)
        {
            string strValorExtenso = string.Empty; //Variável que irá armazenar o valor por extenso do número informado
            string strNumero = string.Empty;       //Irá armazenar o número para exibir por extenso
            string strCentena = string.Empty;
            string strDezena = string.Empty;

            decimal dblCentavos = 0;
            decimal dblValorInteiro = 0;
            int intContador = 0;
            bool bln_Bilhao = false;
            bool bln_Milhao = false;
            bool bln_Mil = false;
            bool bln_Unidade = false;

            //Verificar se foi informado um dado indevido
            if (pdbl_Valor == 0 || pdbl_Valor <= 0)
                strValorExtenso = "Verificar se há valor negativo ou nada foi informado";

            if (pdbl_Valor > (decimal)9999999999.99)
            {
                strValorExtenso = "Valor não suportado pela Função";
            }
            else //Entrada padrão do método
            {
                //Gerar Extenso Centavos
                dblCentavos = pdbl_Valor - (int)pdbl_Valor;
                //Gerar Extenso parte Inteira
                dblValorInteiro = (int)pdbl_Valor;
                if (dblValorInteiro > 0)
                {
                    if (dblValorInteiro > 999)
                        bln_Mil = true;

                    if (dblValorInteiro > 999999)
                    {
                        bln_Milhao = true;
                        bln_Mil = false;
                    }

                    if (dblValorInteiro > 999999999)
                    {
                        bln_Mil = false;
                        bln_Milhao = false;
                        bln_Bilhao = true;
                    }

                    for (int i = (dblValorInteiro.ToString().Length) - 1; i >= 0; i--)
                    {
                        strNumero = dblValorInteiro.ToString().Substring((dblValorInteiro.ToString().Length - i) - 1, 1);
                        switch (i)
                        {            /*******/
                            case 9:  /*Bilhão*
                                 /*******/
                                {
                                    strValorExtenso = fcn_Numero_Unidade(strNumero) + ((Convert.ToInt32(strNumero) > 1) ? " Bilhões de" : " Bilhão de");
                                    bln_Bilhao = true;
                                    break;
                                }
                            case 8: /********/
                            case 5: //Centena*
                            case 2: /********/
                                {
                                    if (Convert.ToInt32(strNumero) > 0)
                                    {
                                        strCentena = dblValorInteiro.ToString().Substring((dblValorInteiro.ToString().Length - i) - 1, 3);

                                        if (Convert.ToInt32(strCentena) > 100 && Convert.ToInt32(strCentena) < 200)
                                            strValorExtenso = strValorExtenso + " Cento e ";
                                        else
                                            strValorExtenso = strValorExtenso + " " + fcn_Numero_Centena(strNumero);

                                        if (intContador == 8)
                                            bln_Milhao = true;
                                        else if (intContador == 5)
                                            bln_Mil = true;
                                    }
                                    break;
                                }
                            case 7: /*****************/
                            case 4: //Dezena de Milhão*
                            case 1: /*****************/
                                {
                                    if (Convert.ToInt32(strNumero) > 0)
                                    {
                                        strDezena = dblValorInteiro.ToString().Substring((dblValorInteiro.ToString().Length - i) - 1, 2);//

                                        if (Convert.ToInt32(strDezena) > 10 && Convert.ToInt32(strDezena) < 20)
                                        {
                                            strValorExtenso += (Right(strValorExtenso, 5).Trim() == "entos" ? " e " : " ");
                                            strValorExtenso += fcn_Numero_Dezena0(strDezena.Substring(1, 1));//corrigido

                                            bln_Unidade = true;
                                        }
                                        else
                                        {
                                            strValorExtenso += (Right(strValorExtenso, 5).Trim() == "entos" ? " e " : " ");
                                            strValorExtenso += fcn_Numero_Dezena1(strDezena.Substring(0, 1));//corrigido

                                            bln_Unidade = false;
                                        }

                                        if (intContador == 7)
                                            bln_Milhao = true;
                                        else if (intContador == 4)
                                            bln_Mil = true;
                                    }
                                    break;
                                }
                            case 6: /******************/
                            case 3: //Unidade de Milhão*
                            case 0: /******************/
                                {
                                    if (Convert.ToInt32(strNumero) > 0 && !bln_Unidade)
                                    {
                                        if ((Right(strValorExtenso, 5).Trim()) == "entos"
                                        || (Right(strValorExtenso, 3).Trim()) == "nte"
                                        || (Right(strValorExtenso, 3).Trim()) == "nta")
                                        {
                                            strValorExtenso += " e ";
                                        }
                                        else
                                        {
                                            strValorExtenso += " ";
                                        }
                                        strValorExtenso += fcn_Numero_Unidade(strNumero);
                                    }

                                    if (i == 6)
                                    {
                                        if (bln_Milhao || Convert.ToInt32(strNumero) > 0)
                                        {
                                            strValorExtenso += ((Convert.ToInt32(strNumero) == 1) && !bln_Unidade ? " Milhão de" : " Milhões de");
                                            bln_Milhao = true;
                                        }
                                    }

                                    if (i == 3)
                                    {
                                        if (bln_Mil || Convert.ToInt32(strNumero) > 0)
                                        {
                                            strValorExtenso += " Mil";
                                            bln_Mil = true;
                                        }
                                    }

                                    if (i == 0)
                                    {
                                        if ((bln_Bilhao && !bln_Milhao && !bln_Mil && Right((dblValorInteiro.ToString()), 3) == "0")
                                            || (!bln_Bilhao && bln_Milhao && !bln_Mil && Right((dblValorInteiro.ToString()), 3) == "0"))
                                        {
                                            strValorExtenso += " de ";
                                        }
                                        strValorExtenso += ((Convert.ToInt32(dblValorInteiro.ToString())) > 1 ? " Reais " : " Real ");
                                    }

                                    bln_Unidade = false;
                                    break;
                                }
                        }
                    }
                }

                if (dblCentavos > 0)
                {
                    if (dblCentavos > 0 && dblCentavos < (decimal)0.1)
                    {
                        strNumero = Right((Decimal.Round(dblCentavos, 2, MidpointRounding.AwayFromZero)).ToString(), 1);
                        strValorExtenso += (dblCentavos > 0) ? " e " : " ";
                        strValorExtenso += fcn_Numero_Unidade(strNumero) + ((Convert.ToInt32(strNumero) > 1) ? " Centavos " : " Centavo ");
                    }
                    else if (dblCentavos > (decimal)0.1 && dblCentavos < (decimal)0.2)
                    {
                        strNumero = Right(((Decimal.Round(dblCentavos, 2, MidpointRounding.AwayFromZero) - (decimal)0.1).ToString()), 1);
                        strValorExtenso += dblCentavos > 0 ? " " : " e ";
                        strValorExtenso += fcn_Numero_Dezena0(strNumero) + " Centavos ";
                    }
                    else
                    {
                        if (dblCentavos > 0) //0#
                        {
                            strNumero = Right(dblCentavos.ToString("#0.00"), 2);
                            strValorExtenso += ((Convert.ToInt32(strNumero) > 0) ? " e " : " ");
                            strValorExtenso += fcn_Numero_Dezena1(strNumero.Substring(0, 1));

                            if (strNumero.Length == 2 && Convert.ToInt32(strNumero.Substring(1, 1)) > 0)
                            {
                                strNumero = Right((Decimal.Round(dblCentavos, 2, MidpointRounding.AwayFromZero)).ToString(), 1);
                                if (Convert.ToInt32(strNumero) > 0)
                                {
                                    if (strValorExtenso.Trim().Substring(strValorExtenso.Trim().Length - 2, 1) == "e")
                                        strValorExtenso += " " + fcn_Numero_Unidade(strNumero);
                                    else
                                        strValorExtenso += " e " + fcn_Numero_Unidade(strNumero);
                                }
                            }

                            strValorExtenso += " Centavos ";
                        }
                    }
                }

                if (dblValorInteiro < 1)
                    strValorExtenso = strValorExtenso.Trim().Substring(2, strValorExtenso.Trim().Length - 2);
            }

            return strValorExtenso.Trim();
        }

        private string fcn_Numero_Dezena0(string pstrDezena0)
        {
            //Vetor que irá conter o número por extenso
            IList<string> array_Dezena0 = new List<string>();

            array_Dezena0.Add("Onze");
            array_Dezena0.Add("Doze");
            array_Dezena0.Add("Treze");
            array_Dezena0.Add("Quatorze");
            array_Dezena0.Add("Quinze");
            array_Dezena0.Add("Dezesseis");
            array_Dezena0.Add("Dezessete");
            array_Dezena0.Add("Dezoito");
            array_Dezena0.Add("Dezenove");

            return array_Dezena0[((Convert.ToInt32(pstrDezena0)) - 1)];
        }

        private string fcn_Numero_Dezena1(string pstrDezena1)
        {
            //Vetor que irá conter o número por extenso
            IList<string> array_Dezena1 = new List<string>();

            array_Dezena1.Add("Dez");
            array_Dezena1.Add("Vinte");
            array_Dezena1.Add("Trinta");
            array_Dezena1.Add("Quarenta");
            array_Dezena1.Add("Cinquenta");
            array_Dezena1.Add("Sessenta");
            array_Dezena1.Add("Setenta");
            array_Dezena1.Add("Oitenta");
            array_Dezena1.Add("Noventa");

            return array_Dezena1[((Convert.ToInt32(pstrDezena1)) - 1)];
        }

        private string fcn_Numero_Centena(string pstrCentena)
        {
            //Vetor que irá conter o número por extenso
            IList<string> array_Centena = new List<string>();

            array_Centena.Add("Cem");
            array_Centena.Add("Duzentos");
            array_Centena.Add("Trezentos");
            array_Centena.Add("Quatrocentos");
            array_Centena.Add("Quinhentos");
            array_Centena.Add("Seiscentos");
            array_Centena.Add("Setecentos");
            array_Centena.Add("Oitocentos");
            array_Centena.Add("Novecentos");

            return array_Centena[((Convert.ToInt32(pstrCentena)) - 1)];
        }

        private string fcn_Numero_Unidade(string pstrUnidade)
        {
            //Vetor que irá conter o número por extenso
            IList<string> array_Unidade = new List<string>();

            array_Unidade.Add("Um");
            array_Unidade.Add("Dois");
            array_Unidade.Add("Três");
            array_Unidade.Add("Quatro");
            array_Unidade.Add("Cinco");
            array_Unidade.Add("Seis");
            array_Unidade.Add("Sete");
            array_Unidade.Add("Oito");
            array_Unidade.Add("Nove");

            return array_Unidade[((Convert.ToInt32(pstrUnidade)) - 1)];
        }

        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            if (param == string.Empty)
                return "";
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }
    }
}