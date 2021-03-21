using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ERP.NFPaulista
{
    public class NFP_TrataWS : IDisposable
    {
        #region Retorna dados da empresa

        private DataRow Buscar_Dados_Empresa(int iEmpresa)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   cnpj");
            sb.AppendLine(" , NFP_Categoria_Usuario");
            sb.AppendLine(" , nfp_Ativar_recurso");
            sb.AppendLine(" , nfp_usuario");
            sb.AppendLine(" , nfp_senha");
            sb.AppendLine(" from empresas");
            sb.AppendFormat(" where empresa = {0}", iEmpresa);

            DataRow row = SQL.Select(sb.ToString(), "Empresa", false).Rows[0];
            return row;
        }

        #endregion Retorna dados da empresa

        #region Grava Informações do processo de envio

        private bool TrataRetorno_Enviar(int iLote, string sStringRetorno)
        {
            bool bRetorno = false;
            StringBuilder sb = new StringBuilder();
            string[] sCampos = sStringRetorno.Split(new char[] { '|' });

            string sCodigo_Retorno = sCampos[2];

            DateTime dt_Envio = Convert.ToDateTime(sCampos[0], System.Globalization.CultureInfo.GetCultureInfo("pt-br"));
            string sProtocolo = sCampos[1];
            if (string.IsNullOrEmpty(sProtocolo))
                sProtocolo = "NULL";
            else
                sProtocolo = "'" + sProtocolo + "'";

            string sMensagem_Retorno = sCampos[3];
            if (!sCampos[2].Equals("999"))
                sMensagem_Retorno = "NULL";
            else
            {
                sMensagem_Retorno = "'" + sMensagem_Retorno.Replace(Convert.ToChar("'"), '"') + "'";

                if (string.IsNullOrEmpty(sCodigo_Retorno))
                    sCodigo_Retorno = "NULL";
                else
                {
                    sb.Remove(0, sb.Length);
                    sb.AppendFormat("select count(codigo_mensagem_retorno) from mensagens_retorno_nfp where codigo_mensagem_retorno = {0}", sCodigo_Retorno);
                    int iQtde = Convert.ToInt32(SQL.ExecuteScalar(sb.ToString()));

                    //-- Caso a mensagem não exista o sistema incluirá na lista de mensagens de retorno.
                    if (iQtde == 0)
                    {
                        sb.Remove(0, sb.Length);
                        sb.Append("insert mensagens_retorno_nfp values(");
                        sb.Append(sCodigo_Retorno);
                        sb.Append(",");
                        sb.Append(sMensagem_Retorno);
                        sb.AppendLine(")");
                        SQL.ExecuteNonQuery(sb.ToString());
                    }
                }
            }

            sb.Remove(0, sb.Length);
            sb.AppendLine("update notas_fiscais_lotes set");
            sb.AppendFormat("    data_envio_lote = '{0}'\r\n", dt_Envio.ToString("yyyyMMdd hh:mm:ss"));
            sb.AppendFormat("  , Protocolo = {0}\r\n", sProtocolo);
            sb.AppendFormat("  , Codigo_Mensagem_Retorno_NFp = {0}\r\n", sCodigo_Retorno);
            sb.AppendFormat("  , Mensagem_Retorno_NFp = {0}\r\n", sMensagem_Retorno);
            sb.AppendFormat(" where Nota_fiscal_lote = {0}", iLote);

            try
            {
                SQL.ExecuteNonQuery(sb.ToString());
                if (!sCampos[2].Equals("999"))
                    bRetorno = true;
                else
                    bRetorno = false;
            }
            catch { }

            return bRetorno;
        }

        #endregion Grava Informações do processo de envio

        #region Enviar arquivos

        /// <summary>
        /// Enviar arquivos e dados para o WebService da Nota fiscal paulista
        /// </summary>
        /// <param name="iEmpresa">int com o código da empresa</param>
        /// <param name="ilLotes">IList(Int) com os lotes qua serão enviados.</param>
        /// <returns>true/false se o envio foi feito com sucesso.</returns>
        public bool Enviar_Arquivos(int iEmpresa, IList<int> ilLotes)
        {
            string sRetornoEnviar = string.Empty;
            bool bRetorno = true;

            //-- busca dados da empresa
            DataRow row_Empresa = this.Buscar_Dados_Empresa(iEmpresa);

            //-- Varre todos os lotes gerados
            foreach (int iLote in ilLotes)
            {
                string sQuery = "SELECT Arquivo_Envio FROM NOTAS_FISCAIS_LOTES where nota_fiscal_lote = {0}";
                sQuery = string.Format(sQuery, iLote);
                FileInfo fi = new FileInfo(SQL.ExecuteScalar(sQuery).ToString());

                //-- Verifica se o arquivo existe.
                if (fi.Exists)
                {
                    //-- Cria a instancia dos valores para envio.
                    CompSoft.NFpaulista_Mod1.Autenticacao autentic = new CompSoft.NFpaulista_Mod1.Autenticacao();
                    CompSoft.NFpaulista_Mod1.ArquivoNF_Mod1 nfp = new CompSoft.NFpaulista_Mod1.ArquivoNF_Mod1();
                    nfp.Timeout = 600000; //-- 10 minutos...

                    //-- Seta parametros para autenticação do usuário.
                    autentic.CategoriaUsuario = (byte)row_Empresa["NFP_Categoria_Usuario"];
                    autentic.CNPJ = row_Empresa["CNPJ"].ToString();
                    autentic.Usuario = row_Empresa["NFP_Usuario"].ToString();
                    autentic.Senha = row_Empresa["NFP_Senha"].ToString();
                    nfp.AutenticacaoValue = autentic;

                    //-- Abre o arquivo e captura dados para a variavel.
                    StreamReader sr = new StreamReader(fi.FullName, Encoding.UTF8);
                    string sConteudo = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    sr = null;

                    //-- faz o envio dos dados.
                    try
                    {
                        sRetornoEnviar = nfp.Enviar(fi.Name, sConteudo, string.Empty);
                    }
                    catch
                    {
                        sRetornoEnviar = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "||999|Erro ao conectar ao WebService";
                        bRetorno = false;

                        //-- Insere log
                        this.TrataRetorno_Enviar(iLote, sRetornoEnviar);
                        break;
                    }
                }
                else
                {
                    sRetornoEnviar = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "||999|Arquivo inexistente";
                    bRetorno = false;

                    //-- Insere log
                    this.TrataRetorno_Enviar(iLote, sRetornoEnviar);
                }

                //-- Trava o retorno do processo de envio.
                bool bTrataRetorno = this.TrataRetorno_Enviar(iLote, sRetornoEnviar);
                if (bRetorno)
                    bRetorno = bTrataRetorno;

                //-- Salva o arquivo de retorno em disco para eventuais excessões.
                try
                {
                    string sPath = System.Windows.Forms.Application.StartupPath;
                    if (!sPath.EndsWith(@"\"))
                        sPath += @"\";

                    StreamWriter sw = new StreamWriter(sPath + "RetornoNFP.txt");
                    sw.Write(sRetornoEnviar);
                }
                catch { }
            }

            //-- Verifica se o envio foi realizado com sucesso e tenta capturar o retorno
            if (bRetorno)
            {
                //-- Aguarda 10 segundos para tentativa de processamento do lote pela Secretária da Fazenda.
                System.Threading.Thread.Sleep(10000);

                //-- busca atualizações do lote.
                this.Buscar_Retorno_Lote(ilLotes);
            }

            return bRetorno;
        }

        #endregion Enviar arquivos

        #region Busca retorno de lote

        /// <summary>
        /// Busca retorno de lotes selecionados.
        /// </summary>
        /// <param name="ilLotes">IList(int) com lotes que deverão ser consultados.</param>
        /// <returns>true/false indicando se o busca foi realizado com sucesso.</returns>
        public bool Buscar_Retorno_Lote(IList<int> ilLotes)
        {
            bool bRetorno = false;

            foreach (int iLote in ilLotes)
            {
                string sQuery = string.Format("select protocolo, empresa from notas_fiscais_lotes where nota_fiscal_lote = {0}", iLote);
                DataRow row = SQL.Select(sQuery, "x", false).Rows[0];
                string sProtocolo = row["Protocolo"].ToString();
                int iEmpresa = Convert.ToInt32(row["Empresa"]);

                row.Table.Dispose();

                DataRow row_Empresa = this.Buscar_Dados_Empresa(iEmpresa); //-- busca dados da empresa

                //-- Cria a instancia dos valores para consulta.
                CompSoft.NFpaulista_Mod1.Autenticacao autentic = new CompSoft.NFpaulista_Mod1.Autenticacao();
                CompSoft.NFpaulista_Mod1.ArquivoNF_Mod1 nfp = new CompSoft.NFpaulista_Mod1.ArquivoNF_Mod1();

                //-- Seta parametros para autenticação do usuário.
                autentic.CategoriaUsuario = (byte)row_Empresa["NFP_Categoria_Usuario"];
                autentic.CNPJ = row_Empresa["CNPJ"].ToString();
                autentic.Usuario = row_Empresa["NFP_Usuario"].ToString();
                autentic.Senha = row_Empresa["NFP_Senha"].ToString();
                nfp.AutenticacaoValue = autentic;

                //-- consulta o protocolo
                try
                {
                    string sRetornoConsulta = nfp.Consultar(sProtocolo);
                    this.Grava_Informacoes_Consulta(iLote, sRetornoConsulta);
                }
                catch
                {
                    CompSoft.compFrameWork.MsgBox.Show("Não foi possível acessar o WebService da Nota Fiscal Paulista, aguarde alguns instantes e tente novamente"
                            , "Atençao"
                            , System.Windows.Forms.MessageBoxButtons.OK
                            , System.Windows.Forms.MessageBoxIcon.Warning);

                    bRetorno = false;
                    break;
                }
            }

            return bRetorno;
        }

        #endregion Busca retorno de lote

        #region Grava informações da busca do protocolo no banco de dados.

        private bool Grava_Informacoes_Consulta(int iLote, string sRetornoConsulta)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sRetornoConsulta));
            StreamReader sr = new StreamReader(ms);

            bool bLeuPrimeiraLinha = false;
            while (sr.Peek() > 0)
            {
                string[] sColunas = sr.ReadLine().Split(new char[] { '|' });
                StringBuilder sb = new StringBuilder();

                string sCodigo_Retorno = sColunas[1];

                if (!bLeuPrimeiraLinha)
                {
                    string sMensagem_Retorno = sColunas[2];
                    if (sColunas[1].Equals("999"))
                    {
                        sMensagem_Retorno = "'" + sMensagem_Retorno + "'";
                    }
                    else
                    {
                        sMensagem_Retorno = "NULL";

                        if (string.IsNullOrEmpty(sCodigo_Retorno))
                            sCodigo_Retorno = "NULL";
                        else
                        {
                            this.Verifica_Inseri_Motivo_NFp(Convert.ToInt32(sCodigo_Retorno), sColunas[2]);

                            string sMensagem_Insert = string.Empty;
                            if (!string.IsNullOrEmpty(sColunas[2]))
                                sMensagem_Insert = "'" + sColunas[2].Replace(Convert.ToChar("'"), '"') + "'";
                            else
                                sMensagem_Insert = "NULL";
                        }
                    }

                    string sData = string.Empty;
                    if (!string.IsNullOrEmpty(sColunas[12]))
                        sData = "'" + Convert.ToDateTime(sColunas[12], System.Globalization.CultureInfo.GetCultureInfo("pt-br")).ToString("yyyyMMdd hh:mm:ss") + "'";
                    else
                        sData = "NULL";

                    sb.AppendLine("update notas_fiscais_lotes set");
                    sb.AppendFormat("    Codigo_Mensagem_Retorno_NFp = {0}\r\n", string.IsNullOrEmpty(sColunas[0]) ? "NULL" : sCodigo_Retorno);
                    sb.AppendFormat("  , Mensagem_Retorno_NFp = {0}\r\n", sMensagem_Retorno);
                    sb.AppendFormat("  , Data_Processamento = {0}\r\n", sData);
                    sb.AppendLine("  , Retorno_Capturado = 1");
                    sb.AppendFormat(" where Nota_Fiscal_Lote = {0}", iLote);

                    SQL.ExecuteNonQuery(sb.ToString());

                    bLeuPrimeiraLinha = true;
                }
                else
                {
                    this.Verifica_Inseri_Motivo_NFp(Convert.ToInt32(sColunas[5]), sColunas[6]);
                    sb.AppendLine("insert notas_fiscais_lotes_mensagens(nota_fiscal_lote, Tipo_Mensagem, Numero_nota, Codigo_Mensagem_Retorno_NFp)");
                    sb.AppendFormat("values({0}, '{1}', {2}, {3})"
                            , iLote
                            , sColunas[0]
                            , sColunas[3]
                            , sColunas[5]);

                    SQL.ExecuteNonQuery(sb.ToString());
                }
            }

            return true;
        }

        #endregion Grava informações da busca do protocolo no banco de dados.

        private void Verifica_Inseri_Motivo_NFp(int iCodMotivo, string sMensagem_Motivo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select count(codigo_mensagem_retorno) from mensagens_retorno_nfp where codigo_mensagem_retorno = {0}"
                , iCodMotivo);
            int iQtde = Convert.ToInt32(SQL.ExecuteScalar(sb.ToString()));

            //-- Caso a mensagem não exista o sistema incluirá na lista de mensagens de retorno.
            if (iQtde == 0)
            {
                string sMensagem_Insert = string.Empty;

                sb.Remove(0, sb.Length);
                sb.Append("insert mensagens_retorno_nfp values(");
                sb.Append(iCodMotivo);
                sb.Append(",'");
                sb.Append(sMensagem_Motivo);
                sb.Append("')");
                SQL.ExecuteNonQuery(sb.ToString());
            }
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
        }

        #endregion IDisposable Members
    }
}