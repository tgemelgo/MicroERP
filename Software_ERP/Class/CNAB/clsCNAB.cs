using BoletoNet;
using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;

namespace ERP.CNAB
{
    internal class CNAB
    {
        #region Gera datatable com os dados do boleto.

        /// <summary>
        /// Carregada dados para gerar boletos
        /// </summary>
        /// <param name="ilNota_Fiscal_Duplicata">List com código das duplicatas</param>
        /// <returns>DataTable com informações para gerar Boleto e CNAB</returns>
        public DataTable Gerar_Dados_Boleto(List<int> ilNota_Fiscal_Duplicata)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("    nfd.Nota_Fiscal_Duplicata");
            sb.AppendLine("  , nfd.Nota_Fiscal");
            sb.AppendLine("  , nf.Empresa");
            sb.AppendLine("  , nfd.Numero_Parcela");
            sb.AppendLine("  , nfd.Data_Vencimento");
            sb.AppendLine("  , nfd.Valor_Duplicata");
            sb.AppendLine("  , nf.Data_Emissao");
            sb.AppendLine("  , nf.Numero_Nota");
            sb.AppendLine("  , pe.Gera_NF");
            sb.AppendLine("  , nf.Numero_Nota");
            sb.AppendLine("  , pe.Pedido");
            sb.AppendLine("  , coalesce(bg.EspecieDoc, cc.Boleto_EspecieDoc) as Boleto_EspecieDoc");
            sb.AppendLine("  , nfd.Impressa");
            sb.AppendLine("  , e.cnpj as 'CNPJ_Cendente'");
            sb.AppendLine("  , e.Razao_Social as 'Razao_Social_Cendente'");
            sb.AppendLine("  , cc.Conta_Corrente");
            sb.AppendLine("  , e.Empresa");
            sb.AppendLine("  , coalesce(bg.Banco, cc.Banco) as 'Banco'");
            sb.AppendLine("  , cc.Agencia");
            sb.AppendLine("  , cc.Numero_Conta");
            sb.AppendLine("  , cc.Boleto_Carteira");
            sb.AppendLine("  , cc.Boleto_CodigoCedente");
            sb.AppendLine("  , cc.Boleto_Convenio");
            sb.AppendLine("  , cl.CPF_CNPJ as 'CNPJ_Sacado'");
            sb.AppendLine("  , cl.Razao_Social as 'Razao_Social_Sacado'");
            sb.AppendLine("  , cl.Endereco_Correspondencia");
            sb.AppendLine("  , cl.Numero_Correspondencia");
            sb.AppendLine("  , cl.Complemento_Correspondencia");
            sb.AppendLine("  , cl.Bairro_Correspondencia");
            sb.AppendLine("  , cl.Cidade_Correspondencia");
            sb.AppendLine("  , cl.Estado_Correspondencia");
            sb.AppendLine("  , cl.CEP_Correspondencia");
            sb.AppendLine("  , bg.Boleto_Gerado");
            sb.AppendLine("  , bg.Data_Documento");
            sb.AppendLine("  , bg.Codigo_Barras");
            sb.AppendLine("  , bg.Linha_Digitavel");
            sb.AppendLine("  , coalesce(bg.ArquivoRemessao_Enviado, 0) as 'ArquivoRemessao_Enviado'");
            sb.AppendLine("  , bg.ArquivoRemessa_Lote");
            sb.AppendLine("  , coalesce(bg.Boleto_Impresso, 0) as 'Boleto_Impresso'");
            sb.AppendLine("  , coalesce(bg.Data_Pagamento, convert(varchar(10), getdate(), 112))");
            sb.AppendLine(" from notas_fiscais nf");
            sb.AppendLine("  INNER JOIN pedidos pe ON pe.Pedido = nf.pedido");
            sb.AppendLine("  inner join notas_fiscais_duplicatas nfd on nf.nota_fiscal = nfd.nota_fiscal");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendLine("  inner join contas_correntes cc on cc.empresa = e.empresa");
            sb.AppendLine("  left outer join boletos_gerados bg on bg.nota_fiscal_duplicata = nfd.Nota_Fiscal_Duplicata");
            sb.AppendFormat(" where nfd.Nota_Fiscal_Duplicata in ({0})", this.ListToStringIn(ilNota_Fiscal_Duplicata));
            DataTable dt = CompSoft.Data.SQL.Select(sb.ToString(), "Boletos", false);

            return dt;
        }

        #endregion Gera datatable com os dados do boleto.

        #region Gera todas as regras do boleto bancário.

        /// <summary>
        /// Gera boleto bancário.
        /// </summary>
        /// <param name="ilNota_Fiscal_Duplicata">ILIST com os códigos das duplicatas</param>/
        public Dictionary<int, BoletoBancario> Gerar_Boleto(List<int> ilNota_Fiscal_Duplicata)
        {
            Dictionary<int, BoletoBancario> ilBB = new Dictionary<int, BoletoBancario>();
            CompSoft.compFrameWork.Funcoes func;

            //-- Seta parametros e captura todos os dados para salvar em banco de dados.
            foreach (int iNota_Fiscal_Duplicata in ilNota_Fiscal_Duplicata)
            {
                List<int> il_temp = new List<int>();
                il_temp.Add(iNota_Fiscal_Duplicata);
                DataTable dt = this.Gerar_Dados_Boleto(il_temp); //-- Gera DataTable com informações.

                if (dt.Rows.Count >= 1)
                {
                    DataRow row = dt.Rows[0]; //-- Seta Registro.

                    //-- Inicia o tratamento do boleto bancário.
                    BoletoBancario bb = new BoletoBancario();
                    bb.CodigoBanco = (short)row["Banco"];

                    //-- Define os dados do Cendente
                    Cedente c = new Cedente(
                              row["CNPJ_Cendente"].ToString()
                            , func.Tira_Acento(row["Razao_Social_Cendente"].ToString())
                            , row["Agencia"].ToString()
                            , row["Numero_Conta"].ToString());
                    c.Codigo = Convert.ToInt32(row["Boleto_CodigoCedente"].ToString());

                    //-- Seta dados do boleto.
                    Boleto b = new Boleto(
                                  Convert.ToDateTime(row["Data_Vencimento"])
                                , Convert.ToDouble(row["Valor_Duplicata"])
                                , row["Boleto_Carteira"].ToString()
                                , string.Empty
                                , c
                                , new EspecieDocumento(bb.CodigoBanco, Convert.ToInt32(row["Boleto_EspecieDoc"])));
                    b.NossoNumero = row["Nota_Fiscal_Duplicata"].ToString().PadLeft(8, '0');
                    b.NumeroDocumento = row["Nota_Fiscal_Duplicata"].ToString().PadLeft(6, '0');

                    //-- Define os dados do SACADO
                    Sacado s = new Sacado(row["CNPJ_Sacado"].ToString()
                                        , func.Tira_Acento(row["Razao_Social_Sacado"].ToString()));

                    string sEndereco = func.Tira_Acento(row["Endereco_Correspondencia"].ToString());
                    if (row["Numero_Correspondencia"] != DBNull.Value)
                        sEndereco += ", " + row["Numero_Correspondencia"].ToString();

                    s.Endereco.End = sEndereco;
                    s.Endereco.Bairro = func.Tira_Acento(row["Bairro_Correspondencia"].ToString());
                    s.Endereco.Cidade = func.Tira_Acento(row["Cidade_Correspondencia"].ToString());
                    s.Endereco.UF = row["Estado_Correspondencia"].ToString();
                    s.Endereco.CEP = row["CEP_Correspondencia"].ToString();
                    b.Sacado = s; //-- Seta sacado do boleto.

                    bb.GerarArquivoRemessa = true; //-- Permite gerar o arquivo de remessa

                    bb.Boleto = b;
                    bb.Boleto.Valida();

                    //-- Salva dados no banco de dados
                    this.Gravar_Dados_Boleto(b, row); //-- Grava dados do boleto
                    this.Gravar_Instrucoes_Boleto(b, row); //-- Grava instruções do boleto

                    this.Carregar_Instrucoes(b, row); //-- Carrega Instruções

                    ilBB.Add(Convert.ToInt32(row["Nota_Fiscal_Duplicata"]), bb); //-- Adiciona o boleto bancário a lista.
                }
            }

            return ilBB;
        }

        #endregion Gera todas as regras do boleto bancário.

        #region Carrega instruções do boleto bancário.

        /// <summary>
        /// Carrega instruções do boleto
        /// </summary>
        /// <param name="boleto">BOLETO com os dados processados.</param>
        /// <param name="Row_Duplicata">DATAROW com o registro da duplicata</param>
        private void Carregar_Instrucoes(Boleto boleto, DataRow Row_Duplicata)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.AppendLine("select ");
            sb.AppendLine("   bi.Codigo_Instrucao");
            sb.AppendLine(" , coalesce(nfdi.Mensagem_Customizada, bi.Desc_Boleto_Instrucao) as 'Desc_Boleto_Instrucao'");
            sb.AppendLine(" , bi.NumeroDias");
            sb.AppendLine(" , bi.Porcento");
            sb.AppendLine(" from Boletos_Gerados_Instrucoes nfdi");
            sb.AppendLine("  inner join boletos_instrucoes bi on bi.boleto_instrucao = nfdi.boleto_instrucao");
            sb.AppendFormat(" where nfdi.boleto_gerado = {0}", Row_Duplicata["boleto_gerado"]);
            DataTable dt = SQL.Select(sb.ToString(), "x", false);

            foreach (DataRow row in dt.Select())
            {
                decimal dPorcento = 0;
                int iNumeroDias = 0;

                Instrucao i = new Instrucao(Convert.ToInt32(Row_Duplicata["Banco"]));

                if (row["Codigo_Instrucao"] != DBNull.Value)
                    i.Codigo = Convert.ToInt32(row["Codigo_Instrucao"]);

                if (row["Desc_Boleto_Instrucao"] != DBNull.Value)
                    i.Descricao = row["Desc_Boleto_Instrucao"].ToString();

                if (row["NumeroDias"] != DBNull.Value)
                {
                    iNumeroDias = Convert.ToInt32(row["NumeroDias"]);
                    i.QuantidadeDias = iNumeroDias;
                }

                if (row["Porcento"] != DBNull.Value)
                {
                    dPorcento = Convert.ToDecimal(row["Porcento"]);
                    decimal dValor = Convert.ToDecimal(Row_Duplicata["Valor_Duplicata"]);

                    dPorcento = dValor - Math.Round(((dValor * dPorcento) / 100), 2, MidpointRounding.AwayFromZero);
                }

                //-- Verifica se existem dados para sobreposição.
                if (i.Descricao.IndexOf("{0}") >= 0)
                {
                    if (iNumeroDias > 0)
                        i.Descricao = string.Format(i.Descricao, iNumeroDias);

                    if (dPorcento > 0)
                        i.Descricao = string.Format(i.Descricao, dPorcento);
                }

                CompSoft.compFrameWork.Funcoes func;
                i.Descricao = func.Tira_Acento(i.Descricao);

                boleto.Instrucoes.Add(i); //-- Adiciona a instrução ao boleto
            }
        }

        #endregion Carrega instruções do boleto bancário.

        #region Verifica e inclui instruções padrão do boleto

        /// <summary>
        /// Salva instruções do boleto
        /// </summary>
        /// <param name="boleto"></param>
        /// <param name="Row_Duplicata"></param>
        private void Gravar_Instrucoes_Boleto(Boleto boleto, DataRow Row_Duplicata)
        {
            //-- Apaga as instruções geradas anteriormente.
            SQL.ExecuteNonQuery(string.Format("delete Boletos_Gerados_Instrucoes where Boleto_Gerado = {0}", Row_Duplicata["Boleto_Gerado"]));

            //-- Encontra todos as instruções para cadastro no boleto.
            StringBuilder sb = new StringBuilder(300);
            sb.AppendLine("select boleto_Instrucao");
            sb.AppendLine(" from contas_correntes_boletos_instrucoes ");
            sb.AppendFormat(" where inativo = 0 and conta_corrente = {0}", Row_Duplicata["Conta_Corrente"]);
            DataTable dt = SQL.Select(sb.ToString(), "x", false);

            //-- Salva informações no banco de dados.
            foreach (DataRow row in dt.Select())
            {
                SQL.ExecuteNonQuery(string.Format("insert Boletos_Gerados_Instrucoes(Boleto_Gerado, Boleto_Instrucao) values({0}, {1})"
                            , Row_Duplicata["Boleto_Gerado"]
                            , row["boleto_Instrucao"]));
            }
        }

        #endregion Verifica e inclui instruções padrão do boleto

        #region Encontra os logos dos boletos.

        /// <summary>
        /// Encontra os logos disponiveis para geração dos boletos.
        /// </summary>
        /// <param name="ilNota_Fiscal_Duplicata">LIST<INT>Inteiro com os códigos</INT>lista com os codigos da notas fiscais duplicatas</param>
        /// <returns>Dictionary<INT, IMAGE> com os logos encontrados.</returns>
        public Dictionary<int, Image> Localizar_Logos_Bancos(List<int> ilNota_Fiscal_Duplicata)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.AppendLine("select cc.Banco");
            sb.AppendLine(" from boletos_gerados bg");
            sb.AppendLine("  inner join Contas_Correntes cc on cc.Conta_Corrente = bg.Conta_Corrente");
            sb.AppendFormat("  inner join dbo.split('{0}', ',') i on bg.Nota_Fiscal_Duplicata = i.item\r\n", this.ListToStringIn(ilNota_Fiscal_Duplicata));
            sb.AppendLine(" group by cc.Banco");
            DataTable dt = SQL.Select(sb.ToString(), "x", false);

            Dictionary<int, Image> ilBanco = new Dictionary<int, Image>();
            foreach (DataRow row in dt.Select())
            {
                object oImage = SQL.ExecuteScalar(string.Format("select Logo_Banco from bancos where banco = {0}", row["Banco"]));
                MemoryStream ms = new MemoryStream((byte[])oImage);

                ilBanco.Add(Convert.ToInt32(row["Banco"]), Image.FromStream(ms));
            }

            return ilBanco;
        }

        #endregion Encontra os logos dos boletos.

        #region Seta boleto como impresso no banco de dados

        /// <summary>
        /// Seta boleto como impresso no banco de dados.
        /// </summary>
        /// <param name="iNotaFiscalDuplicata">INT com o código da tabela nota fiscal duplicata.</param>
        /// <returns>true/false indicando se registro foi marcado com sucesso.</returns>
        public static bool Grava_Boleto_Impresso(int iNotaFiscalDuplicata)
        {
            bool bRetorno = false;
            try
            {
                SQL.ExecuteNonQuery(string.Format("update Boletos_Gerados set Boleto_Impresso = 1 where Nota_Fiscal_duplicata = {0}", iNotaFiscalDuplicata));
            }
            catch { }

            return bRetorno;
        }

        #endregion Seta boleto como impresso no banco de dados

        #region Seta boleto arquivo de remessa como enviado no banco de dados

        /// <summary>
        /// Seta boleto arquivo de remessa como enviado no banco de dados.
        /// </summary>
        /// <param name="iNotaFiscalDuplicata">INT com o código da tabela nota fiscal duplicata.</param>
        /// <param name="iNumeroLote">INT com o número com o lote gerado.</param>
        /// <returns>true/false indicando se registro foi marcado com sucesso.</returns>
        public static bool Grava_Arquivo_Remessa(int iNotaFiscalDuplicata, int iNumeroLote)
        {
            bool bRetorno = false;
            try
            {
                StringBuilder sb = new StringBuilder(300);
                sb.AppendLine("update Boletos_Gerados set ");
                sb.AppendFormat("   ArquivoRemessa_Lote = {0}\r\n", iNumeroLote);
                sb.AppendLine(" , ArquivoRemessao_Enviado = 1");
                sb.AppendFormat(" where Nota_Fiscal_duplicata = {0}", iNotaFiscalDuplicata);

                SQL.ExecuteNonQuery(sb.ToString());
            }
            catch { }

            return bRetorno;
        }

        #endregion Seta boleto arquivo de remessa como enviado no banco de dados

        #region Gravar dados do boleto no banco de dados.

        /// <summary>
        /// Gravar dados do boleto no banco de dados.
        /// </summary>
        /// <param name="bBoleto">BOLETO Classe com os dados do boleto bancário</param>
        /// <param name="row">DATAROW com o registro </param>
        private void Gravar_Dados_Boleto(Boleto bBoleto, DataRow row)
        {
            bool bBolExiste = false;
            StringBuilder sb = new StringBuilder(300);

            if (row["boleto_gerado"] != DBNull.Value)
            {
                sb.AppendFormat("select count(boleto_gerado) from boletos_Gerados where Nota_Fiscal_Duplicata = {0}"
                    , row["Nota_Fiscal_Duplicata"]);

                //-- Verifica se existe o registro do boleto.
                bBolExiste = (Convert.ToInt32(SQL.ExecuteScalar(sb.ToString(), false)) >= 1);
            }

            sb.Remove(0, sb.Length);
            if (!bBolExiste)
            {
                sb.AppendLine("insert Boletos_Gerados(");
                sb.AppendLine("       Nota_Fiscal_Duplicata");
                sb.AppendLine("     , Conta_Corrente");
                sb.AppendLine("     , Codigo_Barras");
                sb.AppendLine("     , Linha_Digitavel");
                sb.AppendLine("     , Data_Documento");
                sb.AppendLine("     , Banco");
                sb.AppendLine("     , EspecieDoc");
                sb.AppendLine("     , Empresa");
                sb.AppendLine(")");
                sb.AppendFormat("values ({0}\r\n", row["Nota_Fiscal_Duplicata"]);
                sb.AppendFormat("       , {0}\r\n", row["Conta_Corrente"]);
                sb.AppendFormat("       , '{0}'\r\n", bBoleto.CodigoBarra.Codigo);
                sb.AppendFormat("       , '{0}'\r\n", bBoleto.CodigoBarra.LinhaDigitavel);
                sb.AppendFormat("       , '{0}'\r\n", DateTime.Now.ToString("yyyyMMdd"));
                sb.AppendFormat("       , {0}\r\n", bBoleto.Banco.Codigo);
                sb.AppendFormat("       , {0}", row["Boleto_EspecieDoc"]);
                sb.AppendFormat("       , {0}", row["Empresa"]);
                sb.Append(") select @@identity");

                row.BeginEdit();
                row.Table.Columns["boleto_gerado"].ReadOnly = false;
                row["Boleto_Gerado"] = SQL.ExecuteScalar(sb.ToString());
                row.EndEdit();
            }
            else
            {
                sb.AppendLine("update Boletos_Gerados set ");
                sb.AppendFormat("   Codigo_Barras = '{0}'\r\n", bBoleto.CodigoBarra.Codigo);
                sb.AppendFormat(" , Linha_Digitavel = '{0}'\r\n", bBoleto.CodigoBarra.LinhaDigitavel);
                sb.AppendFormat(" where Boleto_Gerado = {0}", row["Boleto_Gerado"]);

                SQL.ExecuteNonQuery(sb.ToString());
            }
        }

        #endregion Gravar dados do boleto no banco de dados.

        #region Gera o arquivo de remessa para o banco

        /// <summary>
        /// Gera o arquivo de remessa para o banco
        /// </summary>
        /// <param name="ilBB">Dictionary com os boletos bancários.</param>
        /// <param name="sFolderRemessa">Pasta de geração do arquivo.</param>
        /// <returns>true/false indicando se o arquivo foi gerado com sucesso.</returns>
        public bool Gerar_Arquivo_Remessa(Dictionary<int, BoletoBancario> ilBB, string sFolderRemessa, ref int iNumeroLote)
        {
            bool bRetorno = false;

            try
            {
                Boletos boletos = new Boletos();

                //-- Gera a list de Boletos para gerar o arquivo de remessa
                foreach (BoletoBancario bb in ilBB.Values)
                    boletos.Add(bb.Boleto);

                if (boletos.Count > 0)
                {
                    Cedente c = boletos[0].Cedente;
                    IBanco b = boletos[0].Banco;

                    //-- Carrega o contador
                    CompSoft.compFrameWork.Funcoes func = new Funcoes();
                    iNumeroLote = Convert.ToInt32(func.Contador("NumeroContadorCNAB", false)); //-- Pega o número do contador.

                    if (!sFolderRemessa.EndsWith(@"\"))
                        sFolderRemessa += @"\";

                    string sFileRemessa = sFolderRemessa
                        + "B"
                        + b.Codigo.ToString().PadLeft(3, '0')
                        + iNumeroLote.ToString().PadLeft(4, '0')
                        + ".REM";

                    FileInfo fi = new FileInfo(sFileRemessa);

                    //-- Processo o arquivo de remessa
                    ArquivoRemessa ar = new ArquivoRemessa(TipoArquivo.CNAB400);
                    ar.GerarArquivoRemessa(c.Codigo.ToString()  //-- Codigo Cedente
                                , b                             //-- Interface do Banco
                                , c                             //-- Classe do Cedente
                                , boletos                       //-- Classe com lista dos boletos
                                , fi.OpenWrite()                //-- Arquivos texto
                                , iNumeroLote);                 //-- Contador

                    func.Contador("NumeroContadorCNAB", true); //-- Atualiza contador.

                    bRetorno = true;
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show("ERRO AO GARAR ARQUIVO DE REMESSA\r\n\r\n" + ex.Message
                    , "Arquivo de Remessa"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bRetorno;
        }

        #endregion Gera o arquivo de remessa para o banco

        public bool Arquivo_Retorno_Banco(string sFile_Retorno, IBanco banco)
        {
            bool bRetorno = true;

            FileStream fs = new FileStream(sFile_Retorno, FileMode.Open);

            //-- Carrega e alimenta o arquivo.
            ArquivoRetornoCNAB400 file = new ArquivoRetornoCNAB400();
            file.LerArquivoRetorno(banco, fs);

            foreach (DetalheRetorno dr in file.ListaDetalhe)
            {
                try
                {
                    StringBuilder sb = new StringBuilder(300);
                    sb.AppendLine("update Boletos_Gerados set ");
                    sb.AppendLine("   Boleto_pago = 1");
                    sb.AppendFormat(" , Data_pagamento = '{0}'\r\n", dr.DataCredito.ToString("yyyyMMdd"));
                    sb.AppendFormat(" , Valor_Pago = {0}\r\n", dr.ValorPago.ToString("n2").Replace(',', '.'));
                    sb.AppendFormat(" where Nota_Fiscal_Duplicata = {0}", dr.NossoNumero);

                    SQL.Execute(sb.ToString());
                }
                catch
                {
                    bRetorno = false;
                    break;
                }
            }

            return bRetorno;
        }

        #region Convert LIST<INT> para STRING separado por virgula

        /// <summary>
        /// Transforma dados de um List<Int> em string separado por virgula
        /// </summary>
        /// <param name="il">Ilist<int>dados</int> com dados para concateação</param>
        /// <returns>String com resultados separados por virgula</returns>
        private string ListToStringIn(List<int> il)
        {
            StringBuilder sb = new StringBuilder(300);
            foreach (int i in il)
            {
                if (sb.Length > 0)
                    sb.Append(",");

                sb.Append(i);
            }

            if (sb.Length == 0)
                sb.Append("0");

            return sb.ToString();
        }

        #endregion Convert LIST<INT> para STRING separado por virgula
    }
}