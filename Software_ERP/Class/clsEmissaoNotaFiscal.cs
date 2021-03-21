using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ERP.NotaFiscal
{
    internal class EmissaoNotaFiscal : IDisposable
    {
        private Imprime_Matricial im = new Imprime_Matricial();

        public EmissaoNotaFiscal(bool bDebug)
        {
            im.Debug = bDebug;
        }

        public EmissaoNotaFiscal()
        {
            im.Debug = false;
        }

        #region Querys para busca dos dados.

        #region Dados da capa da NF.

        /// <summary>
        /// Busca dados da capa da nota fiscal.
        /// </summary>
        /// <param name="iCodigoNF">Código da Nota fiscal.</param>
        /// <returns>DataTable com dados da campa.</returns>
        private DataRow Dados_CapaNF(int iCodigoNF)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   nf.Nota_Fiscal");
            sb.AppendLine(" , nf.Empresa");
            sb.AppendLine(" , e.Razao_Social as 'Razao_Social_Empresa'");
            sb.AppendLine(" , e.endereco as 'Endereco_Empresa'");
            sb.AppendLine(" , e.numero as 'Numero_Empresa'");
            sb.AppendLine(" , e.Bairro as 'Bairro_empresa'");
            sb.AppendLine(" , nf.Pedido");
            sb.AppendLine(" , nf.Numero_Nota");
            sb.AppendLine(" , nf.Serie_Nota");
            sb.AppendLine(" , nf.Tipo_Entrada");
            sb.AppendLine(" , nf.Tipo_Saida");
            sb.AppendLine(" , nf.Impressa");
            sb.AppendLine(" , nf.Cancelada");
            sb.AppendLine(" , nf.Data_Emissao");
            sb.AppendLine(" , nf.CFOP");
            sb.AppendLine(" , case when nf.Nota_Fiscal_Referencia is not null then coalesce(nf.Descricao_CFOP_Complementar, 'Complementar') else cfops.Desc_CFOP end as 'desc_cfop'");
            sb.AppendLine(" , nf.Cliente");
            sb.AppendLine(" , cl.Razao_Social as 'Razao_Social_Cliente'");
            sb.AppendLine(" , cl.CPF_CNPJ as 'CPF_CNPJ_Cliente'");
            sb.AppendLine(" , cl.Pessoa_Juridica");
            sb.AppendLine(" , cl.RG_IE as 'RG_IE_Cliente'");
            sb.AppendLine(" , cl.DDD1 as 'DDD1_Cliente'");
            sb.AppendLine(" , cl.Fone1 as 'Fone1_Cliente'");
            sb.AppendLine(" , cl.Endereco_Correspondencia");
            sb.AppendLine(" , cl.Numero_Correspondencia");
            sb.AppendLine(" , cl.Complemento_Correspondencia");
            sb.AppendLine(" , cl.Bairro_Correspondencia");
            sb.AppendLine(" , cl.Cidade_Correspondencia");
            sb.AppendLine(" , cl.Estado_Correspondencia");
            sb.AppendLine(" , cl.CEP_Correspondencia");
            sb.AppendLine(" , cl.Observacoes_Nota");
            sb.AppendLine(" , nf.Transportadora");
            sb.AppendLine(" , t.Razao_Social as 'Razao_Social_Transportadora'");
            sb.AppendLine(" , t.CNPJ as 'CNPJ_Transportadora'");
            sb.AppendLine(" , t.Endereco as 'Endereco_Transportadora'");
            sb.AppendLine(" , t.Numero as 'Numero_Transportadora'");
            sb.AppendLine(" , t.Complemento as 'Complemento_Transportadora'");
            sb.AppendLine(" , t.Bairro as 'Bairro_Transportadora'");
            sb.AppendLine(" , t.Cidade as 'Cidade_Transportadora'");
            sb.AppendLine(" , t.Estado as 'Estado_Transportadora'");
            sb.AppendLine(" , t.CEP as 'CEP_Transportadora'");
            sb.AppendLine(" , t.DDD1 as 'DDD1_Transportadora'");
            sb.AppendLine(" , t.Fone1 as 'Fone1_Transportadora'");
            sb.AppendLine(" , nf.Condicao_Pagamento_Pedido");
            sb.AppendLine(" , cpp.Desc_Cond_Pgto");
            sb.AppendLine(" , nf.Valor_Base_ICMS");
            sb.AppendLine(" , nf.Valor_ICMS");
            sb.AppendLine(" , nf.Valor_Base_Substituicao_ICMS");
            sb.AppendLine(" , nf.Valor_Substituicao_ICMS");
            sb.AppendLine(" , nf.Valor_IPI");
            sb.AppendLine(" , nf.Valor_Frete");
            sb.AppendLine(" , nf.ICMS_Frete");
            sb.AppendLine(" , nf.Valor_Seguro");
            sb.AppendLine(" , nf.ICMS_Seguro");
            sb.AppendLine(" , nf.Outros_Valores");
            sb.AppendLine(" , nf.Valor_Desconto");
            sb.AppendLine(" , nf.Valor_Total_Produtos");
            sb.AppendLine(" , nf.Valor_Total_Nota");
            sb.AppendLine(" , nf.Tipo_Frete");
            sb.AppendLine(" , nf.Quantidade_Itens");
            sb.AppendLine(" , nf.Especie");
            sb.AppendLine(" , nf.Marca");
            sb.AppendLine(" , nf.Numero");
            sb.AppendLine(" , nf.Peso_Bruto");
            sb.AppendLine(" , nf.Peso_Liquido");
            sb.AppendLine(" , v.Nome_Vendedor");
            sb.AppendLine(" , nf.Observacao");
            sb.AppendLine(" , pe.Gera_NF");
            sb.AppendLine(" from notas_fiscais nf");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join transportadoras t on t.transportadora = nf.transportadora");
            sb.AppendLine("  inner join condicoes_pagamento_pedido cpp on cpp.condicao_pagamento_pedido = nf.condicao_pagamento_pedido");
            sb.AppendLine("  inner join pedidos pe on pe.pedido = nf.pedido");
            sb.AppendLine("  inner join vendedores v on v.vendedor = pe.vendedor");
            sb.AppendLine("  left outer join cfops on cfops.cfop = nf.cfop");
            sb.AppendLine(" where nf.nota_fiscal = {0}");

            string sQuery = string.Format(sb.ToString()
                , iCodigoNF);

            DataRow row = SQL.Select(sQuery, "Notas_Fiscais", false).Rows[0];

            return row;
        }

        #endregion Dados da capa da NF.

        #region Dados dos itens da nota fiscal.

        /// <summary>
        /// Busca dados do item da nota fiscal.
        /// </summary>
        /// <param name="iCodigoNF">Código da Nota fiscal.</param>
        /// <returns>DataTable com dados da campa.</returns>
        private DataTable Dados_ItensNF(int iCodigoNF)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   notas_fiscais_itens.Nota_Fiscal_Item");
            sb.AppendLine(" , notas_fiscais_itens.Nota_Fiscal");
            sb.AppendLine(" , notas_fiscais_itens.Produto");
            sb.AppendLine(" , notas_fiscais_itens.Desc_Produto");
            sb.AppendLine(" , notas_fiscais_itens.Desc_Unidade_Abrevidado");
            sb.AppendLine(" , notas_fiscais_itens.Quantidade");
            sb.AppendLine(" , notas_fiscais_itens.Valor_Unitario");
            sb.AppendLine(" , notas_fiscais_itens.Valor_Total_Item");
            sb.AppendLine(" , notas_fiscais_itens.Peso_Bruto");
            sb.AppendLine(" , notas_fiscais_itens.Peso_Liquido");
            sb.AppendLine(" , notas_fiscais_itens.Classificacao_Fiscal");
            sb.AppendLine(" , cf.Classificacao_Fiscal_Nota");
            sb.AppendLine(" , notas_fiscais_itens.Situacao_Tributaria");
            sb.AppendLine(" , notas_fiscais_itens.Aliquota_ICMS");
            sb.AppendLine(" , notas_fiscais_itens.Valor_Base_ICMS");
            sb.AppendLine(" , notas_fiscais_itens.Valor_ICMS");
            sb.AppendLine(" , notas_fiscais_itens.Aliquota_IPI");
            sb.AppendLine(" , notas_fiscais_itens.Valor_IPI");
            sb.AppendLine(" , notas_fiscais_itens.Aliquota_Substituicao_Tributaria");
            sb.AppendLine(" , notas_fiscais_itens.Valor_Base_Substituicao_Tributaria");
            sb.AppendLine(" , notas_fiscais_itens.Valor_Substituicao_Tributaria");
            sb.AppendLine(" from notas_fiscais_itens");
            sb.AppendLine("  left outer join Classificacoes_fiscais cf on cf.classificacao_fiscal = notas_fiscais_itens.Classificacao_fiscal");
            sb.AppendLine(" where notas_fiscais_itens.Nota_Fiscal = {0}");

            string sQuery = string.Format(sb.ToString()
                , iCodigoNF);

            DataTable dt = SQL.Select(sQuery, "Notas_Fiscais_Itens", false);

            return dt;
        }

        #endregion Dados dos itens da nota fiscal.

        #region Dados dos vencimentos da nota fiscal.

        /// <summary>
        /// Busca dados do vencimento da nota fiscal.
        /// </summary>
        /// <param name="iCodigoNF">Código da Nota fiscal.</param>
        /// <returns>DataTable com dados da campa.</returns>
        private DataTable Dados_VencimentosNF(int iCodigoNF)
        {
            StringBuilder sb = new StringBuilder();
            string sQuery = "select * from notas_fiscais_duplicatas where nota_fiscal = {0} order by Numero_Parcela";

            sQuery = string.Format(sQuery
                , iCodigoNF);

            DataTable dt = SQL.Select(sQuery, "Notas_Fiscais_Duplicatas", false);

            return dt;
        }

        #endregion Dados dos vencimentos da nota fiscal.

        #endregion Querys para busca dos dados.

        #region Metodos para nota fiscal

        #region Imprimi Header da nota fiscal

        private void Gerar_Header(ref DataRow row_Capa)
        {
            im.Pula(2); //-- Pula 2 linhas
            if ((bool)row_Capa["Tipo_Saida"])
                im.Imp("X".PadLeft(95)); //-- Linha 4

            if ((bool)row_Capa["Tipo_Entrada"])
                im.Imp("X".PadLeft(109)); //-- Linha 4

            if (Convert.ToInt32(row_Capa["Empresa"]) == 1)
            {
                im.ImpCol(130, string.Format("{0:00000000}", row_Capa["Numero_nota"]));
            }
            im.ImpLF("");

            im.Pula(5); //-- Pula 5 linhas

            im.ImpCol(2, Funcoes_Matricial.PadR(row_Capa["Desc_CFOP"].ToString(), 44)); //-- Linha 9
            im.ImpColLF(49, row_Capa["CFOP"].ToString()); //-- Linha 9

            im.Pula(2); //-- Pula 2 linhas

            im.ImpCol(2, Funcoes_Matricial.PadR(row_Capa["Razao_Social_Cliente"].ToString(), 88)); //-- Linha 12
            im.Imp("".PadLeft(6));

            string sCNPJ = Funcoes_Matricial.Formata_CNPJ_CPF(row_Capa["CPF_CNPJ_Cliente"].ToString());
            im.Imp(sCNPJ); //-- linha 12
            im.Imp("".PadLeft(129 - (sCNPJ.Length + 96))); //-- alterar de 127 para 129
            im.ImpLF(" " + Convert.ToDateTime(row_Capa["Data_Emissao"]).ToShortDateString()); //-- linha 12

            im.Pula(1);

            //-- Linha 13
            string sEndereco = row_Capa["Endereco_Correspondencia"].ToString();
            if (row_Capa["Numero_Correspondencia"] != DBNull.Value)
                sEndereco += row_Capa["Numero_Correspondencia"].ToString();

            im.ImpCol(2, Funcoes_Matricial.PadR(sEndereco, 73));
            im.Imp("".PadLeft(5));
            im.Imp(Funcoes_Matricial.PadR(row_Capa["Bairro_Correspondencia"].ToString(), 23));
            im.Imp("".PadLeft(6));

            if (row_Capa["CEP_Correspondencia"] != DBNull.Value)
                im.ImpLF(Funcoes_Matricial.PadL(Funcoes_Matricial.Formata_CEP(row_Capa["CEP_Correspondencia"].ToString()), 9));
            else
                im.ImpLF("00000-000");

            //-- Pula uma linha.
            im.Pula(1);

            //-- Linha 16
            im.ImpCol(2, Funcoes_Matricial.PadR(row_Capa["Cidade_Correspondencia"].ToString(), 54));
            im.Imp("".PadLeft(4));
            string sFone = Funcoes_Matricial.Formata_Telefone(row_Capa["ddd1_cliente"].ToString(), row_Capa["fone1_cliente"].ToString());
            im.Imp(Funcoes_Matricial.PadR(sFone, 27));
            im.Imp(Funcoes_Matricial.PadR(row_Capa["Estado_Correspondencia"].ToString(), 9));
            im.ImpLF(Funcoes_Matricial.Formata_IE(row_Capa["RG_IE_Cliente"].ToString()));

            //-- Pula 2 linhas para iniciar vencimentos da NF
            im.Pula(2);
        }

        #endregion Imprimi Header da nota fiscal

        #region Imprimi vencimentos / duplicatas da nota fiscal

        private void Gerar_Vencimentos(ref DataRow row_Capa, ref DataTable dt_Vencimento)
        {
            //-- Define o nْmero das duplicatas da NF.
            string sFormato_Venc = row_Capa["Numero_Nota"].ToString() + "/{0}";
            sFormato_Venc = string.Format(sFormato_Venc, dt_Vencimento.Rows.Count);

            //-- Loop nos dados para gerar
            for (int i = 0; i <= (dt_Vencimento.Rows.Count - 1); i++)
            {
                decimal dValor_Pula_Linha = ((i + 1) % 2);

                //-- Inicia a impressão.
                if (dValor_Pula_Linha > 0)
                {
                    im.ImpCol(21, sFormato_Venc);
                    im.Imp((i + 1).ToString());
                    im.ImpCol(43, Convert.ToDateTime(dt_Vencimento.Rows[i]["Data_Vencimento"]).ToShortDateString());
                    im.ImpCol(62, dt_Vencimento.Rows[i]["Valor_Duplicata"].ToString());
                }
                else
                {
                    im.ImpCol(84, sFormato_Venc);
                    im.Imp((i + 1).ToString());
                    im.ImpCol(102, Convert.ToDateTime(dt_Vencimento.Rows[i]["Data_Vencimento"]).ToShortDateString());
                    im.ImpColLF(123, dt_Vencimento.Rows[i]["Valor_Duplicata"].ToString());
                }
            }

            im.Pula(23 - im.Numero_Linhas_Impressao_Atual);
        }

        #endregion Imprimi vencimentos / duplicatas da nota fiscal

        #region Gera itens da nota fiscal

        private void Gerar_Itens(ref DataTable row_Itens, ref DataRow row_Capa)
        {
            int iNotaFiscal = 0;

            foreach (DataRow row in row_Itens.Select("", "Situacao_Tributaria"))
            {
                im.Imp(row["produto"].ToString());
                im.ImpCol(8, row["Desc_Produto"].ToString());
                //-- im.ImpColRight(59, row["Peso_Bruto"].ToString());
                im.ImpCol(62, row["Classificacao_Fiscal_Nota"].ToString());
                im.ImpCol(68, row["Situacao_Tributaria"].ToString());
                im.ImpCol(75, row["Desc_Unidade_Abrevidado"].ToString());
                im.ImpCol(82, row["Quantidade"].ToString());
                im.ImpColRight(100, row["Valor_Unitario"].ToString());
                im.ImpColRight(119, row["Valor_Total_Item"].ToString());
                if (Convert.ToInt32(row_Capa["Empresa"]) == 1)
                    im.ImpCol(125, Funcoes_Matricial.Zero_Branco(row["Aliquota_ICMS"], Funcoes_Matricial.Tipo_Zero.Inteiro));
                else
                    im.ImpCol(123, Funcoes_Matricial.Zero_Branco(row["Aliquota_ICMS"], Funcoes_Matricial.Tipo_Zero.Inteiro));

                im.ImpCol(127, Funcoes_Matricial.Zero_Branco(row["Aliquota_IPI"], Funcoes_Matricial.Tipo_Zero.Inteiro));
                im.ImpColRightLF(137, Funcoes_Matricial.Zero_Branco(row["Valor_IPI"], Funcoes_Matricial.Tipo_Zero.Decimal));
                iNotaFiscal = Convert.ToInt32(row["Nota_Fiscal"]);
            }

            //-- Imprime mensagens...
            IList<string> ilMens = this.Captura_Mensagem(iNotaFiscal);

            //-- Pula linhas para impressão das notas fiscais.
            if (Convert.ToInt32(row_Capa["Empresa"]) == 1)
                im.Pula((36 - ilMens.Count) - im.Numero_Linhas_Impressao_Atual);
            else
                im.Pula((37 - ilMens.Count) - im.Numero_Linhas_Impressao_Atual);

            foreach (string sMensagem in ilMens)
                im.ImpColLF(2, sMensagem);

            im.Pula(39 - im.Numero_Linhas_Impressao_Atual);
        }

        #endregion Gera itens da nota fiscal

        #region Gera Fooder da nota fiscal

        private void Gerar_Fooder(ref DataRow row_Capa)
        {
            //-- Calculos dos impostos (impressão)
            im.ImpColRight(20, Funcoes_Matricial.Zero_Branco(row_Capa["Valor_Base_ICMS"], Funcoes_Matricial.Tipo_Zero.Decimal));
            im.ImpColRight(45, Funcoes_Matricial.Zero_Branco(row_Capa["Valor_ICMS"], Funcoes_Matricial.Tipo_Zero.Decimal));
            im.ImpColRight(77, Funcoes_Matricial.Zero_Branco(row_Capa["Valor_Base_Substituicao_ICMS"], Funcoes_Matricial.Tipo_Zero.Decimal));
            im.ImpColRight(112, Funcoes_Matricial.Zero_Branco(row_Capa["Valor_Substituicao_ICMS"], Funcoes_Matricial.Tipo_Zero.Decimal));
            im.ImpColRightLF(133, Funcoes_Matricial.Zero_Branco(row_Capa["Valor_Total_Produtos"], Funcoes_Matricial.Tipo_Zero.Decimal));

            im.Pula(1);

            im.ImpColRight(20, Funcoes_Matricial.Zero_Branco(row_Capa["Valor_Frete"], Funcoes_Matricial.Tipo_Zero.Decimal));
            im.ImpColRight(45, Funcoes_Matricial.Zero_Branco(row_Capa["Valor_Seguro"], Funcoes_Matricial.Tipo_Zero.Decimal));
            im.ImpColRight(77, Funcoes_Matricial.Zero_Branco(row_Capa["Outros_Valores"], Funcoes_Matricial.Tipo_Zero.Decimal));
            im.ImpColRight(112, Funcoes_Matricial.Zero_Branco(row_Capa["Valor_IPI"], Funcoes_Matricial.Tipo_Zero.Decimal));
            im.ImpColRightLF(133, Funcoes_Matricial.Zero_Branco(row_Capa["Valor_Total_Nota"], Funcoes_Matricial.Tipo_Zero.Decimal));

            im.Pula(2);

            //-- Dados da transportadora.
            im.ImpCol(2, row_Capa["Razao_Social_Transportadora"].ToString());
            im.ImpCol(87, row_Capa["Tipo_Frete"].ToString());
            if (row_Capa["CNPJ_Transportadora"] != DBNull.Value)
                im.ImpColLF(122, Funcoes_Matricial.Formata_CNPJ_CPF(row_Capa["CNPJ_Transportadora"].ToString()));
            else
                im.ImpLF("");

            im.Pula(1);

            //-- Endereço da transportadora
            string sEndereco = row_Capa["Endereco_Transportadora"].ToString();
            if (row_Capa["Numero_Transportadora"] != DBNull.Value)
                sEndereco += ", " + row_Capa["Numero_Transportadora"].ToString();

            im.ImpCol(2, sEndereco);
            im.ImpCol(70, row_Capa["Cidade_Transportadora"].ToString());
            im.ImpColLF(113, row_Capa["Estado_Transportadora"].ToString());

            im.Pula(1);

            im.ImpCol(2, row_Capa["Quantidade_Itens"].ToString());
            im.ImpCol(20, row_Capa["Especie"].ToString());
            im.ImpCol(43, row_Capa["Marca"].ToString());
            im.ImpCol(68, row_Capa["Numero"].ToString());
            im.ImpColRight(104, row_Capa["Peso_Bruto"].ToString());
            im.ImpColRight(134, row_Capa["Peso_Liquido"].ToString());

            //-- Mostra as mensagens
            im.Pula(54 - im.Numero_Linhas_Impressao_Atual);

            IList<string> ilObs = new List<string>();

            string sObservacao = row_Capa["Observacao"].ToString();

            if (sObservacao.Length > 55)
            {
                //-- Loop para quebrar nota em linhas.
                while (sObservacao.Length > 55)
                {
                    string sobs = sObservacao.Substring(0, 55);
                    sObservacao = sObservacao.Replace(sobs, "");
                    sobs = sobs.Replace(Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(), "\r\n".PadRight(23));
                    ilObs.Add(sobs);
                }

                if (sObservacao.Length > 0)
                    ilObs.Add(sObservacao.Replace(Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(), "\r\n".PadRight(23)));
            }
            else
            {
                if (sObservacao.Length > 0)
                    ilObs.Add(sObservacao.Replace(Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(), "\r\n".PadRight(23)));
            }

            //-- Verifica e imprimi valores.
            bool bImprimir_Pedido = true;
            if (ilObs.Count > 0)
            {
                int iTotal_Linhas_Pedido = ((im.Numero_Linhas_Impressao_Atual - 1) + ilObs.Count);

                foreach (string sObs in ilObs)
                {
                    if (iTotal_Linhas_Pedido >= 57)
                    {
                        bImprimir_Pedido = false;
                        if (im.Numero_Linhas_Impressao_Atual == 57)
                            im.ImpCol(8, "PED. (" + row_Capa["Pedido"].ToString() + ")");
                    }
                    else
                        bImprimir_Pedido = true;

                    im.ImpColLF(21, sObs);
                }
            }

            if (bImprimir_Pedido)
            {
                im.Pula(56 - im.Numero_Linhas_Impressao_Atual);
                im.ImpCol(8, "PED. (" + row_Capa["Pedido"].ToString() + ")");
            }

            if (Convert.ToInt32(row_Capa["Empresa"]) == 1)
            {
                im.Pula(4);
                im.ImpCol(5, string.Format("{0:00000000}", row_Capa["Numero_nota"]));
            }
        }

        #endregion Gera Fooder da nota fiscal

        #region Atualiza registro como impresso.

        private void Marcar_NF_Impressa(int iCodigoNF)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("update Notas_Fiscais ");
            sb.AppendLine(" set impressa = 1 ");
            sb.AppendFormat(" where Nota_Fiscal = {0}", iCodigoNF);
            SQL.Execute(sb.ToString());
        }

        #endregion Atualiza registro como impresso.

        #endregion Metodos para nota fiscal

        #region Metodos para emissão do cupom n?o fiscal.

        #region Gera o header do cupom

        private void Gerar_Header_Cupom(ref DataRow row_Capa)
        {
            im.ImpLF(Funcoes_Matricial.Centralizar(136, "CUPOM SEM VALOR FISCAL"));
            im.ImpLF("");
            im.Imp(Funcoes_Matricial.PadL("Pedido: ", 10));
            im.Imp(row_Capa["Pedido"].ToString());
            im.ImpCol(25, "Data: ");
            im.ImpLF(Convert.ToDateTime(row_Capa["Data_Emissao"]).ToShortDateString());

            im.Imp(Funcoes_Matricial.PadL("Empresa: ", 10));
            im.ImpLF(row_Capa["Razao_Social_Empresa"].ToString());

            im.Imp(Funcoes_Matricial.PadL("Cliente: ", 10));
            im.Imp("(");
            im.Imp(row_Capa["Cliente"].ToString());
            im.Imp(") ");
            im.ImpLF(row_Capa["Razao_Social_Cliente"].ToString());

            im.Imp(Funcoes_Matricial.PadL("End: ", 10));
            im.Imp(row_Capa["Endereco_Correspondencia"].ToString());
            if (row_Capa["Numero_Correspondencia"] != DBNull.Value)
            {
                im.Imp(", ");
                im.Imp(row_Capa["Numero_Correspondencia"].ToString());
            }
            im.ImpLF("");

            im.Imp(Funcoes_Matricial.PadL("Bairro: ", 10));
            im.Imp(row_Capa["Bairro_Correspondencia"].ToString());
            im.ImpCol(40, "Cidade: ");
            im.Imp(row_Capa["Cidade_Correspondencia"].ToString());
            im.ImpCol(75, "UF: ");
            im.ImpLF(row_Capa["Estado_Correspondencia"].ToString());

            im.Imp(Funcoes_Matricial.PadL("Telefone: ", 10));
            im.ImpLF(Funcoes_Matricial.Formata_Telefone(row_Capa["DDD1_Cliente"].ToString(), row_Capa["Fone1_Cliente"].ToString()));

            im.Imp(Funcoes_Matricial.PadL("Vendedor: ", 10));
            im.Imp(row_Capa["Nome_Vendedor"].ToString());
            im.ImpCol(50, "Cond.Pag.: ");
            im.ImpLF(row_Capa["Desc_Cond_Pgto"].ToString());
        }

        #endregion Gera o header do cupom

        #region Gera vencimentos do cupom.

        private void Gerar_Vencimentos_Cupom(ref DataTable dt_Vencimento)
        {
            im.Pula(1);
            im.Imp("N. Venc."); //-- 8
            im.ImpCol(10, "Vencimento"); //-- 10
            im.Imp("  "); //-- 2
            im.ImpLF("Valor do vencimento"); //-- 19

            foreach (DataRow row in dt_Vencimento.Select())
            {
                im.Imp(Funcoes_Matricial.Centralizar(8, Funcoes_Matricial.PadL(row["Numero_Parcela"].ToString(), 2, "0")));
                im.ImpCol(10, Convert.ToDateTime(row["Data_Vencimento"]).ToShortDateString());
                im.ImpColLF(22, Funcoes_Matricial.PadL(row["Valor_Duplicata"].ToString(), 19));
            }
        }

        #endregion Gera vencimentos do cupom.

        #region Gera Itens do cupom.

        private void Gerar_Itens_Cupom(ref DataTable dt_Itens)
        {
            im.Pula(1);
            im.Imp("Codigo");
            im.ImpCol(10, "Produto");
            im.ImpCol(60, "UM");
            im.ImpCol(65, "Qtde");
            im.ImpCol(73, "Val. Unitario");
            im.ImpColLF(90, "Val. Total");

            foreach (DataRow row in dt_Itens.Select())
            {
                im.Imp(row["Produto"].ToString());
                im.ImpCol(10, row["Desc_Produto"].ToString());
                im.ImpCol(60, row["Desc_Unidade_Abrevidado"].ToString());
                im.ImpCol(65, row["Quantidade"].ToString());
                im.ImpCol(73, Funcoes_Matricial.PadL(row["Valor_Unitario"].ToString(), 13));
                im.ImpColLF(90, Funcoes_Matricial.PadL(row["Valor_Total_Item"].ToString(), 10));
            }
        }

        #endregion Gera Itens do cupom.

        #region Gera Fooder do cupom

        private void Gerar_Fooder_Cupom(ref DataRow row_Capa)
        {
            im.Imp(Funcoes_Matricial.PadL("Cx/Pcte: ", 65));
            im.Imp(row_Capa["Quantidade_Itens"].ToString());
            im.ImpCol(73, Funcoes_Matricial.PadL("Total:", 13));
            im.ImpColLF(90, Funcoes_Matricial.PadL(row_Capa["Valor_Total_Produtos"].ToString(), 10));

            im.Pula(1);
            im.ImpLF("OBSERVACAO");
            im.ImpLF(row_Capa["Observacao"].ToString());
            im.ImpLF(row_Capa["Observacoes_Nota"].ToString());
        }

        #endregion Gera Fooder do cupom

        #endregion Metodos para emissão do cupom n?o fiscal.

        #region Metodos para emiss?o de duplicatas

        private void Gerar_Dados_Duplicatas(ref DataRow row_Capa, ref DataRow row_Vencimento)
        {
            im.Pula(5);
            im.ImpCol(153, DateTime.Now.ToShortDateString());
            im.ImpColLF(181, Convert.ToDateTime(row_Vencimento["Data_Vencimento"]).ToShortDateString());
            im.ImpCol(93, DateTime.Now.ToShortDateString());

            im.Pula(3);
            im.ImpCol(150, row_Capa["Numero_Nota"].ToString());
            im.Imp("/");
            im.Imp(row_Vencimento.Table.Rows.Count.ToString());
            im.Imp(row_Vencimento["Numero_Parcela"].ToString());
            im.ImpColLF(186, row_Capa["Cliente"].ToString());

            im.ImpColRight(27, row_Capa["Valor_Total_Nota"].ToString());
            im.ImpCol(36, row_Capa["Numero_Nota"].ToString());
            im.ImpColRight(70, row_Vencimento["Valor_Duplicata"].ToString());
            im.ImpCol(80, row_Capa["Numero_Nota"].ToString());
            im.Imp("/");
            im.Imp(row_Vencimento.Table.Rows.Count.ToString());
            im.Imp(row_Vencimento["Numero_Parcela"].ToString());
            im.ImpColLF(97, Convert.ToDateTime(row_Vencimento["Data_Vencimento"]).ToShortDateString());

            string sSacado1 = row_Capa["Razao_Social_Cliente"].ToString(),
                sSacado2 = "";

            if (sSacado1.Length > 34)
            {
                sSacado2 = sSacado1.Substring(34, (sSacado1.Length - 34));
                sSacado1 = sSacado1.Substring(0, 33);
            }

            im.ImpColLF(164, sSacado1);
            im.ImpColLF(150, sSacado2);

            string sEndereco1 = row_Capa["Endereco_Correspondencia"].ToString(),
                sEndereco2 = "";

            if (row_Capa["Numero_Correspondencia"] != DBNull.Value)
                sEndereco1 += ", " + row_Capa["Numero_Correspondencia"].ToString();

            if (sEndereco1.Length > 38)
            {
                sEndereco2 = sEndereco1.Substring(38, (sEndereco1.Length - 38));
                sEndereco1 = sEndereco1.Substring(0, 37);
            }
            im.ImpColLF(158, sEndereco1);
            im.ImpColLF(150, sEndereco2);

            im.ImpColLF(158, row_Capa["Cidade_Correspondencia"].ToString());

            im.ImpLF("");

            im.ImpCol(39, Funcoes_Matricial.PadR(row_Capa["Razao_Social_Cliente"].ToString(), 70));
            im.ImpColLF(120, row_Capa["Cliente"].ToString());

            sEndereco1 = row_Capa["Endereco_Correspondencia"].ToString();
            if (row_Capa["Numero_Correspondencia"] != DBNull.Value)
                sEndereco1 += ", " + row_Capa["Numero_Correspondencia"].ToString();

            im.ImpCol(39, sEndereco1);
            im.ImpColLF(166, row_Capa["Nome_Vendedor"].ToString());

            im.ImpCol(39, row_Capa["Cidade_Correspondencia"].ToString());
            im.ImpCol(106, row_Capa["Estado_Correspondencia"].ToString());
            im.ImpColLF(122, Funcoes_Matricial.Formata_CEP(row_Capa["CEP_Correspondencia"].ToString()));

            //-- Praça de pagamento
            im.ImpColLF(39, sEndereco1);
            im.ImpLF("");

            im.ImpCol(39, Funcoes_Matricial.Formata_CNPJ_CPF(row_Capa["CPF_CNPJ_Cliente"].ToString()));
            im.ImpCol(108, Funcoes_Matricial.Formata_IE(row_Capa["RG_IE_Cliente"].ToString()));

            im.Pula(2);

            Extenso ext = new Extenso();
            string sValor_Extenso = "(*" + ext.Extenso_Valor(Convert.ToDecimal(row_Vencimento["Valor_Duplicata"])) + "*)";
            string sValor_Extenso2 = "";
            if (sValor_Extenso.Length > 80)
            {
                sValor_Extenso2 = "(*" + sValor_Extenso.Substring(75, sValor_Extenso.Length - 75);
                sValor_Extenso = sValor_Extenso.Substring(0, 75) + "*)";
            }

            im.ImpCol(36, sValor_Extenso);
            im.ImpColLF(169, row_Vencimento["Valor_Duplicata"].ToString());

            im.ImpColLF(36, sValor_Extenso2);

            int iPula = 36 - im.Numero_Linhas_Impressao_Atual;

            im.Pula(iPula);
        }

        #region Marta duplitaca como impressa

        private void Marcar_Duplicata_Impressa(int iCodDuplicata)
        {
            string sSQL = "";
            sSQL += "update notas_fiscais_duplicatas set impressa = 1 where nota_fiscal_duplicata = {0}";
            sSQL = string.Format(sSQL, iCodDuplicata);

            SQL.Execute(sSQL);
        }

        #endregion Marta duplitaca como impressa

        #endregion Metodos para emiss?o de duplicatas

        #region Metodos para emissão de boleto

        private void Gerar_Dados_Boletos(ref DataRow row_Capa, ref DataRow row_Vencimento)
        {
            im.Pula(1);
            im.ImpCol(7, "Pagavel em qualquer banco até a data do vencimento.");
            im.ImpColLF(97, Convert.ToDateTime(row_Vencimento["Data_Vencimento"]).ToShortDateString());
            im.Pula(3);

            im.ImpCol(7, DateTime.Now.ToString("dd/MM/yyyy"));
            if (Convert.ToBoolean(row_Capa["Gera_NF"]))
                im.ImpCol(21, row_Capa["Numero_Nota"].ToString().PadLeft(10, '0'));
            else
                im.ImpCol(21, row_Capa["Pedido"].ToString().PadLeft(10, '0'));

            im.ImpCol(60, row_Capa["Boleto_EspecieDoc"].ToString());
            im.ImpCol(70, Convert.ToBoolean(row_Capa["Boleto_Aceite"]) ? "S" : "N");
            im.ImpColLF(78, DateTime.Now.ToString("dd/MM/yyyy"));

            im.ImpCol(28, row_Capa["Boleto_Carteira"].ToString());
            im.ImpCol(42, row_Capa["Sigla_Moeda"].ToString());
            im.ImpColRightLF(114, row_Vencimento["Valor_Duplicata"].ToString());

            im.Pula(1);

            //-- Instruções.
            im.ImpColLF(8, "Sr. caixa não receber após o vencimento.");

            im.Pula(6);

            //-- Sacado
            im.ImpCol(8, Funcoes_Matricial.PadR(row_Capa["Razao_Social_Cliente"].ToString(), 40, " "));
            im.ImpColLF(55, Funcoes_Matricial.Formata_CNPJ_CPF(row_Capa["CPF_CNPJ_Cliente"].ToString()));

            im.ImpCol(8, row_Capa["Endereco_Correspondencia"].ToString().ToUpper());
            im.Imp(",");
            im.ImpLF(row_Capa["Numero_Correspondencia"].ToString());

            im.ImpCol(8, Funcoes_Matricial.Formata_CEP(row_Capa["cep_correspondencia"].ToString()));
            im.ImpCol(25, row_Capa["cidade_correspondencia"].ToString().ToUpper());
            im.Imp("/");
            im.Imp(row_Capa["Estado_Correspondencia"].ToString().ToUpper());

            im.Fim(); //-- Finaliza o processo de impressão...
            im.Dispose(); //-- Destroi todos os componentes...
        }

        #endregion Metodos para emissão de boleto

        #region Imprimi a duplicata em formulário continuo.

        public bool Emitir_Duplicata(int iCodigoNF, int iNumero_Parcela, bool bMarcarImpresso = false)
        {
            bool bRetorno = true;

            try
            {
                Funcoes func;
                string sPorta = func.Busca_Propriedade("Porta_Padrao_Matricial");
                if (!string.IsNullOrEmpty(sPorta))
                    bRetorno = im.Inicio(sPorta);
                else
                {
                    bRetorno = false;
                    CompSoft.compFrameWork.MsgBox.Show("Porta para impressão matricial não foi definida."
                    , "Erro"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Stop);
                }
            }
            catch
            {
                bRetorno = false;
                CompSoft.compFrameWork.MsgBox.Show("Não foi possivel abrir a porta LPT1 para impressão"
                    , "Erro"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Stop);
            }

            if (bRetorno)
            {
                im.Imp(im.Comprimido);

                //-- Busca dados da nota fiscal.
                DataRow row_Capa = this.Dados_CapaNF(iCodigoNF);
                DataTable dt_Vencimento = this.Dados_VencimentosNF(iCodigoNF);

                DataRow row_Venc = null;

                foreach (DataRow row in dt_Vencimento.Select("Numero_Parcela = " + iNumero_Parcela.ToString()))
                {
                    row_Venc = row;

                    //-- Imprimi a duplicata em formulário continuo.
                    this.Gerar_Dados_Duplicatas(ref row_Capa, ref row_Venc);

                    if (bMarcarImpresso)
                    {
                        //-- Marca duplicata como impressa
                        this.Marcar_Duplicata_Impressa(Convert.ToInt32(row["Nota_Fiscal_Duplicata"]));
                    }
                }

                //-- Fecha conexão com a porta LPT1 da impressara
                im.Fim();
                im.Dispose();
                im = null;
            }

            return bRetorno;
        }

        #endregion Imprimi a duplicata em formulário continuo.

        #region Imprimi a boleto em formulário continuo.

        public bool Emitir_Boleto(int iCodigoNF, int iNumero_Parcela)
        {
            bool bRetorno = true;

            try
            {
                Funcoes func;
                string sPorta = func.Busca_Propriedade("Porta_Padrao_Matricial");
                if (!string.IsNullOrEmpty(sPorta))
                    bRetorno = im.Inicio(sPorta);
                else
                {
                    bRetorno = false;
                    CompSoft.compFrameWork.MsgBox.Show("Porta para impressão matricial não foi definida."
                    , "Erro"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Stop);
                }
            }
            catch
            {
                bRetorno = false;
                CompSoft.compFrameWork.MsgBox.Show("Não foi possivel abrir a porta LPT1 para impressão"
                    , "Erro"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Stop);
            }

            if (bRetorno)
            {
                im.Imp(im.Comprimido);

                //-- Busca dados da nota fiscal.
                DataRow row_Capa = this.Dados_CapaNF(iCodigoNF);
                DataTable dt_Vencimento = this.Dados_VencimentosNF(iCodigoNF);

                DataRow row_Venc = null;

                foreach (DataRow row in dt_Vencimento.Select("Numero_Parcela = " + iNumero_Parcela.ToString()))
                {
                    row_Venc = row;

                    //-- Imprimi a boleto em formulário continuo.
                    this.Gerar_Dados_Boletos(ref row_Capa, ref row_Venc);
                }

                //-- Fecha conexão com a porta LPT1 da impressara
                im.Fim();
                im.Dispose();
                im = null;
            }

            return bRetorno;
        }

        #endregion Imprimi a boleto em formulário continuo.

        #region Imprimi nota fiscal e cupom nao fiscal

        public bool Imprimir_NF(int iCodigoNF, bool bImprimirNota, bool bMarcarImpresso = false)
        {
            bool bRetorno = true;

            try
            {
                Funcoes func;
                string sPorta = func.Busca_Propriedade("Porta_Padrao_Matricial");
                if (!string.IsNullOrEmpty(sPorta))
                    bRetorno = im.Inicio(sPorta);
                else
                {
                    bRetorno = false;
                    CompSoft.compFrameWork.MsgBox.Show("Porta para impressão matricial não foi definida."
                    , "Erro"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Stop);
                }
            }
            catch
            {
                bRetorno = false;
                CompSoft.compFrameWork.MsgBox.Show("Não foi possivel abrir a porta LPT1 para impressão"
                    , "Erro"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Stop);
            }

            //-- Instancia e seta valores para impressão
            if (bRetorno)
            {
                im.Imp(im.Comprimido);

                //-- Busca dados da nota fiscal.
                DataRow row_Capa = this.Dados_CapaNF(iCodigoNF);
                DataTable dt_Vencimento = this.Dados_VencimentosNF(iCodigoNF);
                DataTable dt_Itens = this.Dados_ItensNF(iCodigoNF);

                //-- Imprimi nota fiscal.
                if (bImprimirNota)
                {
                    //-- Gera header da nota fiscal.
                    this.Gerar_Header(ref row_Capa);

                    //-- Gera os vencimentos da nota fiscal.
                    this.Gerar_Vencimentos(ref row_Capa, ref dt_Vencimento);

                    //-- Gera itens da nota fiscal.
                    this.Gerar_Itens(ref dt_Itens, ref row_Capa);

                    //-- Gera fooder da nota fiscal.
                    this.Gerar_Fooder(ref row_Capa);
                }
                else  //-- Imprime cupom.
                {
                    this.Gerar_Header_Cupom(ref row_Capa);

                    this.Gerar_Vencimentos_Cupom(ref dt_Vencimento);

                    this.Gerar_Itens_Cupom(ref dt_Itens);

                    this.Gerar_Fooder_Cupom(ref row_Capa);
                }

                //-- Ejeta o papel e prepara para uma nova impressão caso exista.
                im.Eject();

                //-- Fecha conexão com a porta LPT1 da impressara
                im.Fim();

                if (bMarcarImpresso)
                {
                    //-- Marca registro como impresso.
                    this.Marcar_NF_Impressa(iCodigoNF);
                }

                im.Dispose();
                im = null;
            }

            //-- Retorno.
            return bRetorno;
        }

        #endregion Imprimi nota fiscal e cupom nao fiscal

        #region IDisposable Members

        public void Dispose()
        {
            if (im != null)
            {
                im.Dispose();
                im = null;
            }
        }

        #endregion IDisposable Members

        public IList<string> Captura_Mensagem(int iCodigoNF)
        {
            IList<string> il = new List<string>();

            //-- Query para buscar todas as mensagens da NF
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select 999 as mensagem_nota, Mensagem_padrao_nota as 'mensagem'");
            sb.AppendLine(" from empresas e");
            sb.AppendLine("  inner join notas_fiscais nf on nf.empresa = e.empresa");
            sb.AppendFormat(" where nf.nota_fiscal = {0}", iCodigoNF);
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
                    if (Convert.ToInt32(row["Mensagem_Nota"]) == 999)
                        bIncluirMensagem = true;
                    else
                        bIncluirMensagem = false;
                }

                if (bIncluirMensagem)
                    il.Add(sMensagem); //-- Adiciona a query.
            }

            return il;
        }
    }
}