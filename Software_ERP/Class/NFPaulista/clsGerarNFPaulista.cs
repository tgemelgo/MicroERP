using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ERP.NFPaulista
{
    public class GerarNFPaulista : IDisposable
    {
        private DataSet ds = new DataSet();
        private StringBuilder sb_NF = new StringBuilder();
        private string sCaminhoArquivo = string.Empty;
        private IList<int> ilLotes = new List<int>();

        private bool bNF_Cancelamento = false;

        private int iTipoReg_20 = 0,
            iTipoReg_30 = 0,
            iTipoReg_40 = 0,
            iTipoReg_50 = 0,
            iTipoReg_60 = 0;

        #region Construtor

        public GerarNFPaulista(string sCaminho_Arquivo)
        {
            sCaminhoArquivo = sCaminho_Arquivo;
        }

        #endregion Construtor

        #region Propriedades

        public DataSet dataset
        {
            get { return ds; }
            set { ds = value; }
        }

        public IList<int> Lotes_Gerados
        {
            get { return ilLotes; }
        }

        #endregion Propriedades

        #region Adiciona valores no StringBuilder

        private string Tira_Acento(string sValor)
        {
            char[] cComAcento = "ÁÂÃÀÉÈÊÍÌÎÔÕÓÒÚÙÛ".ToCharArray();
            char[] cSemAcento = "AAAAEEEIIIOOOOUUU".ToCharArray();

            if (!string.IsNullOrEmpty(sValor))
            {
                sValor = sValor.ToUpper();
                for (int i = 0; i < cComAcento.Length; i++)
                    sValor.Replace(cComAcento[i], cSemAcento[i]);
            }

            return sValor;
        }

        private void Pula_Linha()
        {
            sb_NF.AppendLine(string.Empty);
        }

        private void Adicionar(string sValor)
        {
            sb_NF.Append("|");
            sb_NF.Append(this.Tira_Acento(sValor));
        }

        private void Adicionar(string sValor, int iTamanho)
        {
            if (sValor.Length > iTamanho)
                sValor = sValor.Substring(0, iTamanho);

            sb_NF.Append("|");
            sb_NF.Append(this.Tira_Acento(sValor));
        }

        private void Adicionar(string sValor, int iTamanho, bool bTamanhoFixo, char cCharEsquerda)
        {
            if (sValor.Length > iTamanho)
                sValor = sValor.Substring(0, iTamanho);
            else
            {
                if (bTamanhoFixo)
                    sValor = this.Tira_Acento(sValor).PadLeft(iTamanho, cCharEsquerda);
            }

            sb_NF.Append("|");
            sb_NF.Append(sValor);
        }

        private void Adicionar(decimal dValor, int iQtdeCasasDecimais)
        {
            System.Globalization.CultureInfo ci = (System.Globalization.CultureInfo)(new System.Globalization.CultureInfo("pt-br").Clone());
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.NumberGroupSeparator = "";

            sb_NF.Append("|");
            sb_NF.AppendFormat(ci, "{0:N" + iQtdeCasasDecimais + "}", new object[] { dValor });
        }

        private void Adicionar(DateTime dtValor, bool bComHora)
        {
            sb_NF.Append("|");
            if (!bComHora)
                sb_NF.Append(dtValor.ToString("dd/MM/yyyy"));
            else
            {
                sb_NF.Append(dtValor.ToString("dd/MM/yyyy"));
                sb_NF.Append(" 00:00:00");
            }
        }

        #endregion Adiciona valores no StringBuilder

        #region Salva o arquivo e limpa os registro para um novo arquivo

        private void Salvar_Arquivo(DataRow row_Empresa, int iNumArquivo)
        {
            //-- Encontra o número do lote.
            CompSoft.compFrameWork.Funcoes func;
            int iNumero_Lote = Convert.ToInt32(func.Contador("IdLote_NFp", true));

            //-- Cria lote para identificação.
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert notas_fiscais_lotes(Tipo_NFP, empresa, numero_lote) values(1, {0}, {1});\r\n"
                    , row_Empresa["Empresa"]
                    , iNumero_Lote);
            sb.AppendLine("select IDENT_CURRENT('notas_fiscais_lotes')");
            int iIdentity = Convert.ToInt32(CompSoft.Data.SQL.ExecuteScalar(sb.ToString()));

            //-- Adiciona no controle de lote.
            ilLotes.Add(iIdentity);

            //-- Sava informações do arquivo em disco.
            string sNomeArquivo = string.Empty;
            if (sCaminhoArquivo.EndsWith(@"\"))
                sNomeArquivo = @"{0}{1}NFp{2}.txt";
            else
                sNomeArquivo = @"{0}\{1}NFp{2}.txt";

            sNomeArquivo = string.Format(sNomeArquivo
                    , sCaminhoArquivo
                    , row_Empresa["Empresa"].ToString().PadLeft(3, '0') //-- codigo da empresa
                    , iNumero_Lote.ToString().PadLeft(8, '0')); //-- se for gerar mais de um arquivo.

            //-- Salva o arquivo em disco.
            StreamWriter sw = new StreamWriter(sNomeArquivo, false, Encoding.UTF8);
            sw.Write(sb_NF.ToString());
            sw.Close();
            sw.Dispose();
            sw = null;

            //-- Atualiza com o nome do arquivo o lote.
            sb.Remove(0, sb.Length);
            sb.AppendFormat("update notas_fiscais_lotes set Arquivo_Envio = '{0}' where nota_fiscal_lote = {1}"
                    , sNomeArquivo
                    , iIdentity);
            CompSoft.Data.SQL.Execute(sb.ToString());

            //-- Marca registros como exportado no DB
            DataRow[] fRow = ds.Tables["Notas_Fiscais"].Select("Exportacao_NFp = 1 and NumArquivo = " + iNumArquivo.ToString());
            foreach (DataRow row in fRow)
            {
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("insert notas_fiscais_lotes_itens values(");
                sb1.Append(iIdentity);
                sb1.Append(',');
                sb1.Append(row["Nota_Fiscal"]);
                sb1.Append(')');
                CompSoft.Data.SQL.Execute(sb1.ToString());
            }

            sb_NF.Remove(0, sb_NF.Length);
            iTipoReg_20 = 0;
            iTipoReg_30 = 0;
            iTipoReg_40 = 0;
            iTipoReg_50 = 0;
            iTipoReg_60 = 0;
        }

        #endregion Salva o arquivo e limpa os registro para um novo arquivo

        #region Metodos para criar a Nota fiscal Paulista.

        public bool Criar_NFPaulista()
        {
            bool bRetorno = false;

            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, gerando e enviando arquivo da Nota Fiscal Paulista.\r\nEste processo poderá levar alguns minutos.", CompSoft.Tools.frmWait.Tipo_Imagem.Atencao);

            foreach (DataRow row_Empresa in ds.Tables["Empresas"].Select())
            {
                int iQtdeNF = 0;
                int iQtdeMaxNF = 300;
                int iNumArquivo = 1;

                string sFilter = string.Format("Empresa = {0}", row_Empresa["empresa"]);
                DataRow[] fRow_NFs = ds.Tables["Notas_Fiscais"].Select(sFilter);
                foreach (DataRow row_NF in fRow_NFs)
                {
                    if (iQtdeNF == iQtdeMaxNF && iQtdeNF != fRow_NFs.Length)
                    {
                        //-- Gera rodape do arquivo
                        this.Rodape_Arquivo();

                        //-- gera o cabecalho do arquivo.
                        this.Cabecalho_Arquivo(row_Empresa, iNumArquivo);

                        //-- Salva arquivo em disco.
                        this.Salvar_Arquivo(row_Empresa, iNumArquivo);

                        iNumArquivo++;
                        iQtdeNF = 0;
                    }

                    //-- Gera notas fiscais
                    this.Gera_Capa_NF(row_NF, iNumArquivo);

                    //-- Verifica se o registro de NF é cancelamento caso seja não cria itens desnecessários nest situação.
                    if (!bNF_Cancelamento)
                    {
                        //-- Gera itens da nota fiscal
                        this.Gera_Itens_NF(Convert.ToInt32(row_NF["nota_fiscal"]));

                        //-- Gera totais da NF
                        this.Gera_Totais_NF(row_NF);

                        //-- Gera dados frete da NF.
                        this.Gera_Dados_Frete(row_NF);
                    }

                    //-- Acrecenta um no contador de NF assim será mais fácil controlar a impressão da NF.
                    iQtdeNF++;
                }

                //-- Final das NF fecha o Arquivo e salva em disco.
                if (iQtdeNF >= fRow_NFs.Length)
                {
                    //-- Gera rodape do arquivo
                    this.Rodape_Arquivo();

                    //-- gera o cabecalho do arquivo.
                    this.Cabecalho_Arquivo(row_Empresa, iNumArquivo);

                    //-- Salva arquivo em disco.
                    this.Salvar_Arquivo(row_Empresa, iNumArquivo);
                }

                //-- processo para envio de dados.
                NFPaulista.NFP_TrataWS ed = new NFPaulista.NFP_TrataWS();
                bRetorno = ed.Enviar_Arquivos(Convert.ToInt32(row_Empresa["Empresa"]), ilLotes);

                ilLotes.Clear();
            }

            f.Close();

            return bRetorno;
        }

        #endregion Metodos para criar a Nota fiscal Paulista.

        #region Gera cabecalho - Tipo Registro 10

        private void Cabecalho_Arquivo(DataRow row_Empresa, int iNumArquivo)
        {
            //-- Armazena informações temporariamente em variavel para tramento do cabecalho.
            string sValores = sb_NF.ToString();
            sb_NF.Remove(0, sb_NF.Length);

            //-- tipo de registro 10
            sb_NF.Append("10");
            this.Adicionar("1,00");
            this.Adicionar(row_Empresa["cnpj"].ToString(), 14, true, '0');

            //-- Fazer verificação... da menor e da maior data.

            string sFilter = "Empresa = {0} and numArquivo = {1}";

            //-- Menor data
            DateTime dt = (DateTime)this.ds.Tables["Notas_Fiscais"].Compute("min(Data_Emissao)", string.Format(sFilter
                , row_Empresa["Empresa"]
                , iNumArquivo));
            this.Adicionar(dt.ToString("dd/MM/yyyy"));

            //-- maior data
            dt = (DateTime)this.ds.Tables["Notas_Fiscais"].Compute("max(Data_Emissao)", string.Format(sFilter
                , row_Empresa["Empresa"]
                , iNumArquivo));
            this.Adicionar(dt.ToString("dd/MM/yyyy"));

            this.Pula_Linha();

            sb_NF.Append(sValores);
        }

        #endregion Gera cabecalho - Tipo Registro 10

        #region Gera Nota Fiscal - Tipo Registro 20

        private void Gera_Capa_NF(DataRow row, int iNumArquivo)
        {
            iTipoReg_20++;

            //-- Tipo de registro 20
            sb_NF.Append("20");

            //-- Verifica o tipo de NF gerada.
            if ((bool)row["Cancelada"])
            {
                this.Adicionar("C");
                this.Adicionar("NF gerada incorretamente.");
                bNF_Cancelamento = true;
            }
            else
            {
                if (!(bool)row["Exportacao_NFp"])
                    this.Adicionar("I");
                else
                    this.Adicionar("R");

                this.Adicionar("");
                bNF_Cancelamento = false;
            }

            this.Adicionar("Venda");
            this.Adicionar(row["Serie_Nota"].ToString());
            this.Adicionar(row["Numero_Nota"].ToString());
            this.Adicionar(Convert.ToDateTime(row["Data_Emissao"]), true);
            this.Adicionar(Convert.ToDateTime(row["Data_Emissao"]), true);
            this.Adicionar(row["Tipo_Documento_Fiscal"].ToString());
            this.Adicionar(row["cfop"].ToString());
            this.Adicionar(string.Empty);
            this.Adicionar(string.Empty);
            if ((bool)row["Pessoa_Juridica"])
                this.Adicionar(row["cpf_cnpj"].ToString(), 14, true, '0');
            else
                this.Adicionar(row["cpf_cnpj"].ToString(), 11, true, '0');

            this.Adicionar(row["Razao_Social_Cliente"].ToString(), 60);
            this.Adicionar(row["endereco_correspondencia"].ToString(), 60);

            if (string.IsNullOrEmpty(row["numero_correspondencia"].ToString()))
                this.Adicionar("0");
            else
                this.Adicionar(row["numero_correspondencia"].ToString(), 60);

            this.Adicionar(row["complemento_correspondencia"].ToString(), 60);
            this.Adicionar(row["bairro_correspondencia"].ToString(), 60);
            this.Adicionar(row["cidade_correspondencia"].ToString(), 60);
            this.Adicionar(row["estado_correspondencia"].ToString());
            this.Adicionar(row["cep_correspondencia"].ToString(), 8, true, '0');
            this.Adicionar(row["Pais_Correspondencia"].ToString(), 60);

            this.Adicionar(row["Telefone_Cliente"].ToString().Trim().Replace(".", "0").Replace(",", "0").Replace("(", "0").Replace(")", "0"), 10);
            this.Adicionar(row["RG_IE_Cliente"].ToString(), 14);

            this.Pula_Linha();

            row.BeginEdit();
            row["Exportacao_NFp"] = true;
            row["NumArquivo"] = iNumArquivo;
            row.EndEdit();
        }

        #endregion Gera Nota Fiscal - Tipo Registro 20

        #region Inclui itens - Tipo Registro 30

        private void Gera_Itens_NF(int iCodNF)
        {
            DataRow[] fRow = ds.Tables["Notas_Fiscais_Itens"].Select("nota_Fiscal = " + iCodNF.ToString());
            foreach (DataRow row in fRow)
            {
                sb_NF.Append("30");
                this.Adicionar(row["Produto"].ToString());
                this.Adicionar(row["cfop"].ToString() + " - " + row["desc_produto"].ToString(), 120);
                this.Adicionar("");
                this.Adicionar(row["Desc_Unidade_Abrevidado"].ToString());
                this.Adicionar(Convert.ToDecimal(row["Quantidade"]), 4);
                this.Adicionar(Convert.ToDecimal(row["Valor_Unitario"]), 4);
                this.Adicionar(Convert.ToDecimal(row["Valor_Total_Item"]), 2);
                this.Adicionar(row["Situacao_Tributaria"].ToString(), 4);
                if (row["Aliquota_ICMS"] != DBNull.Value)
                    this.Adicionar(Convert.ToDecimal(row["Aliquota_ICMS"]), 2);
                else
                    this.Adicionar("0,00");

                if (row["Aliquota_IPI"] != DBNull.Value)
                    this.Adicionar(Convert.ToInt32(row["Aliquota_IPI"]).ToString());
                else
                    this.Adicionar("");

                if (row["Valor_IPI"] != DBNull.Value)
                    this.Adicionar(Convert.ToDecimal(row["Valor_IPI"]), 2);
                else
                    this.Adicionar("");

                this.Pula_Linha();
                iTipoReg_30++;
            }
        }

        #endregion Inclui itens - Tipo Registro 30

        #region Gera totais da NF - Tipo Registro 40

        private void Gera_Totais_NF(DataRow row_NF)
        {
            sb_NF.Append("40");

            if (row_NF["Valor_Base_ICMS"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_Base_ICMS"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Valor_ICMS"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_ICMS"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Valor_Base_Substituicao_ICMS"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_Base_Substituicao_ICMS"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Valor_Substituicao_ICMS"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_Substituicao_ICMS"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Valor_Total_Produtos"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_Total_Produtos"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Valor_Frete"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_Frete"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Valor_Seguro"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_Seguro"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Valor_Desconto"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_Desconto"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Valor_IPI"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_IPI"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Outros_Valores"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Outros_Valores"]), 2);
            else
                this.Adicionar("0,00");

            if (row_NF["Valor_Total_Nota"] != DBNull.Value)
                this.Adicionar(Convert.ToDecimal(row_NF["Valor_Total_Nota"]), 2);
            else
                this.Adicionar("0,00");

            this.Adicionar("");
            this.Adicionar("");
            this.Adicionar("");
            this.Pula_Linha();

            iTipoReg_40++;
        }

        #endregion Gera totais da NF - Tipo Registro 40

        #region Gera dados frete - Tipo Registro 50

        private void Gera_Dados_Frete(DataRow row_NF)
        {
            sb_NF.Append("50");
            this.Adicionar(row_NF["Tipo_Frete_NFe"].ToString());

            if (row_NF["CNPJ"].ToString().Length > 11)
                this.Adicionar(row_NF["CNPJ"].ToString(), 14, true, '0');
            else
                this.Adicionar(row_NF["CNPJ"].ToString(), 11, true, '0');

            this.Adicionar(row_NF["Razao_Social_Transportadora"].ToString(), 60);
            this.Adicionar(row_NF["IE_Transportadora"].ToString(), 14);
            this.Adicionar(row_NF["Endereco_Transportadora"].ToString(), 60);
            this.Adicionar(row_NF["Cidade_Transportadora"].ToString(), 60);
            this.Adicionar(row_NF["Estado_Transportadora"].ToString(), 2);
            this.Adicionar(row_NF["Placa_Transporte"].ToString());
            this.Adicionar(row_NF["UF_Placa_Transporte"].ToString());
            this.Adicionar(row_NF["Quantidade_Itens"].ToString());
            this.Adicionar(row_NF["Especie"].ToString());

            this.Adicionar("");
            this.Adicionar("");

            this.Adicionar(Convert.ToDecimal(row_NF["Peso_Liquido"]), 3);
            this.Adicionar(Convert.ToDecimal(row_NF["Peso_Bruto"]), 3);

            this.Pula_Linha();
            iTipoReg_50++;
        }

        #endregion Gera dados frete - Tipo Registro 50

        #region Rodape do arquivo - Tipo Registro 90

        private void Rodape_Arquivo()
        {
            sb_NF.Append("90");
            this.Adicionar(iTipoReg_20.ToString(), 5, true, '0');
            this.Adicionar(iTipoReg_30.ToString(), 5, true, '0');
            this.Adicionar(iTipoReg_40.ToString(), 5, true, '0');
            this.Adicionar(iTipoReg_50.ToString(), 5, true, '0');
            this.Adicionar(iTipoReg_60.ToString(), 5, true, '0');
        }

        #endregion Rodape do arquivo - Tipo Registro 90

        #region IDisposable Members

        public void Dispose()
        {
            ds.Clear();
            ds.Dispose();
            ds = null;
        }

        #endregion IDisposable Members
    }
}