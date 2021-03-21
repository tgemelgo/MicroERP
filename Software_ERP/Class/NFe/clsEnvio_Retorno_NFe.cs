using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.NFe;
using CompSoft.NFe.TrataWebService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ERP.NFe
{
    internal partial class NFe
    {
        #region Enviar_NFe

        /// <summary>
        /// Envia nota fiscal atravéz do WebService
        /// </summary>
        /// <param name="ilNotas_Fiscais">IList<Dados_Arquivos_NFe> com todas as notas para exportação.</param>
        /// <param name="sFolder">string com a Path completa para envio da NF-e.</param>
        public void Enviar_NFe(IList<CompSoft.NFe.Dados_Arquivo_NFe> ilNotas_Fiscais, string sFolder)
        {
            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, buscando informações no banco de dados.");
            f.Show();

            //-- Busca dados para geração da NF-e
            ERP.NFe.GerarDadosNFe dados_NFe = new ERP.NFe.GerarDadosNFe();
            dados_NFe.Gerar_Dados_NFe(ilNotas_Fiscais);

            f.Mensagem = "Aguarde, gerando arquivos XML da NF-e.";

            //-- Gera NF-e em uma pasta especifica para envio ao cliente.
            ERP.NFe.XML_NFe nfe = new ERP.NFe.XML_NFe(sFolder, dados_NFe.DataSet_NFe, ilNotas_Fiscais);
            nfe.Gerar_XML_NFe();

            f.Progresso = true;
            f.Maximo_Progresso = ilNotas_Fiscais.Count;
            f.Mensagem = "Aguarde, o sistema está assinando, transfêrindo e imprimindo o DANFE das notas fiscais autorizadas.";

            //-- Instancia classe de tratamento do WebService NF-e
            //-- Verifica se o WebService está ativo.
            NFeWebService wb_Nfe = new NFeWebService();
            if (wb_Nfe.Status_WebService(ilNotas_Fiscais[0]))
            {
                //-- Assina o XML.
                foreach (Dados_Arquivo_NFe daNFe in ilNotas_Fiscais)
                {
                    //-- Assina NF-e
                    CompSoft.NFe.AssinaXML assinar = new CompSoft.NFe.AssinaXML();
                    assinar.AssinarArquivoXML(daNFe.Arquivo_XML, "infNFe", this.Retorna_SerialNumber(daNFe.Empresa));

                    //-- Envia o Lote da NF-e.
                    this.SalvaXML_DB(daNFe, false);
                    XmlDocument doc = wb_Nfe.Enviar_LoteNFe(daNFe);
                    int iAguardar = this.Trata_Arquivo_Retorno_NFe(doc, daNFe); //-- Faz o tratamento dos dados e envia para o banco de dados.

                    //-- Aguarda 3 vezes o tempo necessário para garentir a recepção do retorno dos dados.
                    System.Threading.Thread.Sleep(5000);

                    //-- Captura o resultado de processamento.
                    this.Resultado_Processamento_NFe(daNFe);

                    //-- avança um na barra de progresso.
                    f.Atual_Progresso++;
                }
            }
            else
            {
                MsgBox.Show("O WebService está fora do ar, tente novamente mais tarde."
                        , "Atenção"
                        , System.Windows.Forms.MessageBoxButtons.OK
                        , System.Windows.Forms.MessageBoxIcon.Error);
            }

            f.Close();
            f.Dispose();
        }

        #endregion Enviar_NFe

        #region verifica se o arquivo fisico XML existe, caso não exista o sistema busca o XML e salva o do banco de dados.

        /// <summary>
        /// Verifica se o arquivo fisico XML existe, caso não exista o sistema busca o XML e salva o do banco de dados.
        /// </summary>
        /// <param name="daNFe">Dados_Arquivo_NFe contendo as informações da NF-e</param>
        private void Verifica_XML_Existe(Dados_Arquivo_NFe daNFe)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(daNFe.Arquivo_XML);
            if (!fi.Exists)
            {
                //-- Busca no bando de dados as informações.
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select nfe_documentoxml from notas_fiscais");
                sb.AppendFormat("   where nota_fiscal = {0}", daNFe.Nota_Fiscal);
                string sXML = SQL.ExecuteScalar(sb.ToString()).ToString();

                //-- Verifica se existe o conteudo XML.
                if (!string.IsNullOrEmpty(sXML))
                {
                    if (!System.IO.Directory.Exists(fi.DirectoryName))
                        System.IO.Directory.CreateDirectory(fi.DirectoryName);

                    //-- Salva o arquivo em disco no mesmo diretório onde o arquivo ele foi criado originalmente
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(daNFe.Arquivo_XML);
                    sw.Write(sXML);
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        #endregion verifica se o arquivo fisico XML existe, caso não exista o sistema busca o XML e salva o do banco de dados.

        #region salva NF-e no banco de dados

        /// <summary>
        /// Salva o arquivo XML no banco de dados na tabela de notas fiscais.
        /// </summary>
        /// <param name="daNFe"></param>
        private void SalvaXML_DB(Dados_Arquivo_NFe daNFe, bool bMarca_Exportado)
        {
            if (System.IO.File.Exists(daNFe.Arquivo_XML))
            {
                //-- Le o arquivo XML e aloca em memoria.
                System.IO.StreamReader sr = new System.IO.StreamReader(daNFe.Arquivo_XML);
                string sXML = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                //-- Declara parametros para inclusão.
                IList<System.Data.SqlClient.SqlParameter> ilParameters = new List<System.Data.SqlClient.SqlParameter>();

                System.Data.SqlClient.SqlParameter p = new System.Data.SqlClient.SqlParameter("@docxml", System.Data.SqlDbType.Text);
                p.Value = sXML;
                ilParameters.Add(p);

                p = new System.Data.SqlClient.SqlParameter("@notafiscal", System.Data.SqlDbType.Int);
                p.Value = daNFe.Nota_Fiscal;
                ilParameters.Add(p);

                //-- Indica se a nota será marcada como exportada.
                string sQuery = "update notas_fiscais set nfe_documentoxml = @docxml {0} where nota_fiscal = @notafiscal";
                string sMarca_Exportacao = string.Empty;
                if (bMarca_Exportado)
                    sMarca_Exportacao = ", exportacao_NFe = 1";

                sQuery = string.Format(sQuery, sMarca_Exportacao);

                //-- executa o comando.
                SQL.Execute(sQuery, ilParameters);
            }
        }

        #endregion salva NF-e no banco de dados

        #region Trata o protocolo de envio do lote da NF-e.

        /// <summary>
        /// Trata o arquivo de retorno da NF-e
        /// </summary>
        /// <param name="doc">XMLDocument com os dados do retorno</param>
        /// <returns>int em segundos indicando quanto tempo o sistema deve aguardar para pesquisar o resultado do envio do lote.</returns>
        private int Trata_Arquivo_Retorno_NFe(XmlDocument doc, CompSoft.NFe.Dados_Arquivo_NFe daNFe)
        {
            string dt_Envio = doc.GetElementsByTagName("dhRecbto")[0].InnerText.Replace("T", " ").Replace("-", "").Substring(0, 17);
            string sProtocolo = doc.GetElementsByTagName("nRec")[0].InnerText;
            string sCodigo_Retorno = doc.GetElementsByTagName("cStat")[0].InnerText;
            string sMensagem_Retorno = doc.GetElementsByTagName("xMotivo")[0].InnerText;
            if (!sCodigo_Retorno.Trim().Equals("999"))
                sMensagem_Retorno = "NULL";
            else
                sMensagem_Retorno = "'" + sMensagem_Retorno + "'";

            //-- Inclui o lote.
            StringBuilder sb = new StringBuilder();
            sb.Append("insert notas_fiscais_lotes(Empresa, Numero_Lote, Data_Envio_Lote, Protocolo, Tipo_NFe, ");
            sb.Append("Arquivo_Envio, Ambiente_NFe, Codigo_Mensagem_Retorno_NFe, Mensagem_Retorno_NFe, Tipo_Emissao_NFe) ");
            sb.AppendFormat("values({0}, {1}, '{2}', '{3}', 1, '{4}', {5}, {6}, {7}, {8});\r\n"
                        , daNFe.Empresa
                        , daNFe.Numero_Lote
                        , dt_Envio
                        , sProtocolo
                        , daNFe.Arquivo_XML
                        , (int)daNFe.Ambiente
                        , sCodigo_Retorno
                        , sMensagem_Retorno
                        , Convert.ToInt32(daNFe.Forma_Emissao));

            sb.Append("select IDENT_CURRENT('notas_fiscais_lotes')");

            //-- envia comando para o banco de dados.
            object oIdentity = SQL.ExecuteScalar(sb.ToString());

            daNFe.Cod_Nota_Fiscal_Lote = Convert.ToInt32(oIdentity);
            daNFe.Numero_Recibo = sProtocolo;

            //-- Inclui os itens do lote.
            sb.Remove(0, sb.Length);
            sb.AppendFormat("insert notas_fiscais_lotes_itens values({0}, {1})"
                    , daNFe.Cod_Nota_Fiscal_Lote
                    , daNFe.Nota_Fiscal);
            SQL.ExecuteNonQuery(sb.ToString());

            //-- retorna o tempo médio.
            return Convert.ToInt32(doc.GetElementsByTagName("tMed")[0].InnerText);
        }

        #endregion Trata o protocolo de envio do lote da NF-e.

        #region Captura o numero de serie da NF-e

        /// <summary>
        /// Captura o numero de serie do certificado digital da NF-e.
        /// </summary>
        /// <param name="Empresa">Cod da empresa para pesquisa.</param>
        /// <returns>string com o serial number cadastrado.</returns>
        private string Retorna_SerialNumber(int Empresa)
        {
            string sQuery = "select Serial_Number_Certifica_Digital from empresas where empresa = " + Empresa.ToString();

            string sCertificado = SQL.ExecuteScalar(sQuery).ToString();

            return sCertificado;
        }

        #endregion Captura o numero de serie da NF-e

        #region Captura o resultado processamento do lote na SEFAZ

        /// <summary>
        /// Captura o resultado do processamento do lote na Secretária da Fazenda.
        /// </summary>
        /// <param name="daNFe">Dados_Arquivo_NFe</param>
        internal void Resultado_Processamento_NFe(Dados_Arquivo_NFe daNFe)
        {
            bool bImprimiDanfe = false;
            NFeWebService wb_NFe = new NFeWebService();

            //-- Verifica se o arquivo XML da NF-e existe, caso não exista o sistema salva o existente no DB para envio ao cliente.
            this.Verifica_XML_Existe(daNFe);

            //-- Busca o resultado do processamento do lote.
            XmlDocument doc = wb_NFe.Resultado_Processamento_NFe(daNFe);

            //-- Verifica se o status é regsitrado como lote processado.
            if (doc.GetElementsByTagName("cStat")[0].InnerText.Equals("104"))
            {
                string sCodigo_Mensagem_Retorno = doc.GetElementsByTagName("cStat")[1].InnerText;
                string sMensagem_Retorno = doc.GetElementsByTagName("xMotivo")[1].InnerText;

                if (!sCodigo_Mensagem_Retorno.Trim().Equals("999"))
                    sMensagem_Retorno = "NULL";
                else
                    sMensagem_Retorno = "'" + sMensagem_Retorno + "'";

                //-- Caso a mensagem de retorno for de autorização de uso.
                string sProt = string.Empty;
                if (sCodigo_Mensagem_Retorno.Equals("100"))
                    bImprimiDanfe = true;

                //-- Verifica se a mensagem de erro existe e inclui
                bool bExiste_MensRet = (int.Parse(SQL.ExecuteScalar(string.Format("select count(codigo_mensagem_retorno) from dbo.Mensagens_Retorno_NFe where codigo_mensagem_retorno = {0}"
                    , sCodigo_Mensagem_Retorno)).ToString()) > 0);

                if (!bExiste_MensRet)
                {
                    //-- inclui a mensagem.
                    SQL.Execute(string.Format("insert Mensagens_Retorno_NFe values({0}, '{1}')"
                            , sCodigo_Mensagem_Retorno
                            , doc.GetElementsByTagName("xMotivo")[1].InnerText.Replace("'", "")));
                }

                //-- Monta query para atualização do lote da NF-e
                StringBuilder sb = new StringBuilder();
                sb.Append("update notas_fiscais_lotes set ");
                sb.AppendFormat("       Data_Processamento = '{0}'", doc.GetElementsByTagName("dhRecbto")[0].InnerText.Replace("T", " ").Replace("-", "").Substring(0, 17));
                sb.AppendFormat("     , Codigo_Mensagem_Retorno_NFe = {0}", sCodigo_Mensagem_Retorno);
                sb.AppendFormat("     , Mensagem_retorno_NFe = {0}", sMensagem_Retorno);
                sb.Append("     , Retorno_Capturado = 1");
                sb.AppendFormat("{0}", sProt);
                sb.AppendFormat(" where nota_fiscal_lote = {0}", daNFe.Cod_Nota_Fiscal_Lote);
                SQL.ExecuteNonQuery(sb.ToString());

                //-- Marca a NF como exportada.
                if (bImprimiDanfe)
                {
                    //-- Atualiza o número do protocolo de autenticação
                    sb.Remove(0, sb.Length);
                    sb.AppendLine("update notas_fiscais set ");
                    sb.AppendFormat("   NFe_Protocolo = '{0}'\r\n", doc.GetElementsByTagName("nProt")[0].InnerText);
                    sb.AppendFormat(" , NFe_Protocolo_Data = '{0}'\r\n", doc.GetElementsByTagName("dhRecbto")[0].InnerText.Replace("T", " ").Replace("-", "").Substring(0, 17));
                    sb.AppendFormat(" where Nota_Fiscal = {0}", daNFe.Nota_Fiscal);
                    SQL.ExecuteNonQuery(sb.ToString());

                    //-- Salva Xml no Banco de dados.
                    this.SalvaXML_DB(daNFe, true);
                }
            }
            else
            {
                string sCodigo_Mensagem_Retorno = doc.GetElementsByTagName("cStat")[0].InnerText;
                string sMensagem_Retorno = doc.GetElementsByTagName("xMotivo")[0].InnerText;

                if (!sCodigo_Mensagem_Retorno.Trim().Equals("999"))
                    sMensagem_Retorno = "NULL";
                else
                    sMensagem_Retorno = "'" + sMensagem_Retorno + "'";

                //-- Atualiza mensagens do lote da NF-e
                StringBuilder sb = new StringBuilder();
                sb.Append("update notas_fiscais_lotes set ");
                sb.AppendFormat("       Codigo_Mensagem_Retorno_NFe = {0}", sCodigo_Mensagem_Retorno);
                sb.AppendFormat("     , Mensagem_retorno_NFe = {0}", sMensagem_Retorno);
                sb.Append("     , Retorno_Capturado = 1");
                sb.AppendFormat(" where nota_fiscal_lote = {0}", daNFe.Cod_Nota_Fiscal_Lote);
                SQL.ExecuteNonQuery(sb.ToString());
            }

            //-- Imprimi danfe.
            if (bImprimiDanfe)
            {
                //-- Faz a impressão do DANFE
                Impressao_Danfe imp_danfe;
                imp_danfe.Imprimir_Danfe(daNFe, false);

                //-- Envia a NF-e por e-mail
                Enviar_XML_Email envMail_NFe;
                envMail_NFe.Enviar_XML(daNFe);
            }
        }

        #endregion Captura o resultado processamento do lote na SEFAZ
    }
}