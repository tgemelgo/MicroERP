using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.NFe;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ERP.NFe
{
    internal struct Enviar_XML_Email
    {
        public void Cancelar_NF(Dados_Arquivo_NFe daNFe, string sProtCancelamento)
        {
            StringBuilder sb = new StringBuilder(300);
            string sFileName = Path.Combine(Path.GetTempPath(), "NFe" + daNFe.Chave_Acesso + ".xml");
            try
            {
                //-- Encontra o XML e salva em disco para envio.
                sb.AppendLine("SELECT NFe_DocumentoXML ");
                sb.AppendLine(" FROM notas_fiscais ");
                sb.AppendFormat(" WHERE Nota_Fiscal = {0}", daNFe.Nota_Fiscal);
                object oDocXML = CompSoft.Data.SQL.ExecuteScalar(sb.ToString());
                StreamWriter sw = new StreamWriter(sFileName);
                sw.Write(oDocXML.ToString());
                sw.Close();
                sw.Dispose();
            }
            catch { }

            //-- Encontra os dados para envio da NF-e (XML) por e-mail
            sb.Clear();
            sb.AppendLine("select ");
            sb.AppendLine("   NFE_EnvioXML_Ativar_Recurso");
            sb.AppendLine(" , NFE_EnvioXML_Servidor");
            sb.AppendLine(" , NFE_EnvioXML_Servidor_Porta");
            sb.AppendLine(" , NFE_EnvioXML_Servidor_Autenticacao");
            sb.AppendLine(" , NFE_EnvioXML_EMail");
            sb.AppendLine(" , NFE_EnvioXML_Usuario");
            sb.AppendLine(" , NFE_EnvioXML_Senha");
            sb.AppendLine(" , NFE_EnvioXML_Mensagem");
            sb.AppendLine(" , Razao_Social");
            sb.AppendLine(" from empresas ");
            sb.AppendLine(" where ");
            sb.AppendFormat("  empresa = {0}", daNFe.Empresa);
            DataTable dt = CompSoft.Data.SQL.Select(sb.ToString(), "x", false);

            foreach (DataRow row in dt.Select())
            {
                //-- Se o recurso de envio de mensagem por e-mail estivar ativo.
                if ((bool)row["NFE_EnvioXML_Ativar_Recurso"])
                {
                    sb.Remove(0, sb.Length);
                    sb.AppendLine("select cl.email as 'eMail_Cliente', t.email as 'eMail_Transp'");
                    sb.AppendLine(" from clientes cl");
                    sb.AppendLine("   inner join notas_fiscais nf on nf.cliente = cl.cliente");
                    sb.AppendLine("   inner join transportadoras t on t.transportadora = nf.transportadora");
                    sb.AppendFormat("  where nf.Nota_fiscal = {0}", daNFe.Nota_Fiscal);
                    DataRow row_mail = SQL.Select(sb.ToString(), "x", false).Rows[0];

                    object oEMail_Cli = row_mail[0]; //-- EMail Cliente
                    object oEMail_Tra = row_mail[1]; //-- EMail Transportadora

                    //-- Verifica se o e-mail não é nulo ou em branco.
                    if ((oEMail_Cli != DBNull.Value && !string.IsNullOrEmpty(oEMail_Cli.ToString()))
                        ||
                        (oEMail_Tra != DBNull.Value && !string.IsNullOrEmpty(oEMail_Tra.ToString())))
                    {
                        bool bContinuar = true;

                        //-- Verifica se o e-mail á valido.
                        Funcoes func;
                        if (!func.Validar_EMail(oEMail_Cli.ToString().Trim().ToLower()))
                            oEMail_Cli = string.Empty;

                        if (!func.Validar_EMail(oEMail_Tra.ToString().Trim().ToLower()))
                            oEMail_Tra = string.Empty;

                        if (string.IsNullOrEmpty(oEMail_Cli.ToString()) && string.IsNullOrEmpty(oEMail_Tra.ToString()))
                            bContinuar = false;

                        //-- Continuar a enviar e-mail.
                        if (bContinuar)
                        {
                            Email mail = new Email();
                            mail.Server = row["NFE_EnvioXML_Servidor"].ToString();
                            mail.Port = Convert.ToInt32(row["NFE_EnvioXML_Servidor_Porta"]);

                            bool bRequer_Autenticacao = (bool)row["NFE_EnvioXML_Servidor_Autenticacao"];
                            if (bRequer_Autenticacao)
                            {
                                mail.Requer_Autenticacao = bRequer_Autenticacao;
                                mail.Usuario = row["NFE_EnvioXML_Usuario"].ToString();
                                mail.Senha = row["NFE_EnvioXML_Senha"].ToString();
                            }

                            if (!string.IsNullOrEmpty(oEMail_Cli.ToString()))
                            {
                                foreach (string sMail in oEMail_Cli.ToString().Trim().ToLower().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    if (!string.IsNullOrEmpty(sMail))
                                        mail.To.Add(sMail);
                                }
                            }

                            if (!string.IsNullOrEmpty(oEMail_Tra.ToString()))
                                mail.To.Add(oEMail_Tra.ToString());

                            mail.From = new System.Net.Mail.MailAddress(row["NFE_EnvioXML_EMail"].ToString());
                            mail.Prioridade = System.Net.Mail.MailPriority.High;

                            mail.Subject = string.Format("Cancelamento da NF-e: {0}", row["Razao_social"].ToString());
                            mail.Body = "A nota fiscal foi cancelada com sucesso.\r\n\r\nNº: " + sProtCancelamento;

                            //-- Envia e-mail.
                            mail.SendMail();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Envia o arquivo XML por e-mail para o cliente.
        /// </summary>
        /// <param name="daNFe">Dados_Arquivo_NFe com informações para envio do XML</param>
        public void Enviar_XML(Dados_Arquivo_NFe daNFe)
        {
            StringBuilder sb = new StringBuilder(300);
            string sFileName = Path.Combine(Path.GetTempPath(), "NFe" + daNFe.Chave_Acesso + ".xml");
            try
            {
                //-- Encontra o XML e salva em disco para envio.
                sb.AppendLine("SELECT NFe_DocumentoXML ");
                sb.AppendLine(" FROM notas_fiscais ");
                sb.AppendFormat(" WHERE Nota_Fiscal = {0}", daNFe.Nota_Fiscal);
                object oDocXML = CompSoft.Data.SQL.ExecuteScalar(sb.ToString());
                StreamWriter sw = new StreamWriter(sFileName);
                sw.Write(oDocXML.ToString());
                sw.Close();
                sw.Dispose();
            }
            catch { }

            //-- Encontra os dados para envio da NF-e (XML) por e-mail
            sb.Clear();
            sb.AppendLine("select ");
            sb.AppendLine("   NFE_EnvioXML_Ativar_Recurso");
            sb.AppendLine(" , NFE_EnvioXML_Servidor");
            sb.AppendLine(" , NFE_EnvioXML_Servidor_Porta");
            sb.AppendLine(" , NFE_EnvioXML_Servidor_Autenticacao");
            sb.AppendLine(" , NFE_EnvioXML_EMail");
            sb.AppendLine(" , NFE_EnvioXML_Usuario");
            sb.AppendLine(" , NFE_EnvioXML_Senha");
            sb.AppendLine(" , NFE_EnvioXML_Mensagem");
            sb.AppendLine(" , Razao_Social");
            sb.AppendLine(" from empresas ");
            sb.AppendLine(" where ");
            sb.AppendFormat("  empresa = {0}", daNFe.Empresa);
            DataTable dt = CompSoft.Data.SQL.Select(sb.ToString(), "x", false);

            foreach (DataRow row in dt.Select())
            {
                //-- Se o recurso de envio de mensagem por e-mail estivar ativo.
                if ((bool)row["NFE_EnvioXML_Ativar_Recurso"])
                {
                    sb.Remove(0, sb.Length);
                    sb.AppendLine("select cl.email as 'eMail_Cliente', t.email as 'eMail_Transp'");
                    sb.AppendLine(" from clientes cl");
                    sb.AppendLine("   inner join notas_fiscais nf on nf.cliente = cl.cliente");
                    sb.AppendLine("   inner join transportadoras t on t.transportadora = nf.transportadora");
                    sb.AppendFormat("  where nf.Nota_fiscal = {0}", daNFe.Nota_Fiscal);
                    DataRow row_mail = SQL.Select(sb.ToString(), "x", false).Rows[0];

                    object oEMail_Cli = row_mail[0]; //-- EMail Cliente
                    object oEMail_Tra = row_mail[1]; //-- EMail Transportadora

                    //-- Verifica se o e-mail não é nulo ou em branco.
                    if ((oEMail_Cli != DBNull.Value && !string.IsNullOrEmpty(oEMail_Cli.ToString()))
                        ||
                        (oEMail_Tra != DBNull.Value && !string.IsNullOrEmpty(oEMail_Tra.ToString())))
                    {
                        bool bContinuar = true;

                        //-- Verifica se o e-mail á valido.
                        Funcoes func;
                        if (!func.Validar_EMail(oEMail_Cli.ToString().Trim().ToLower()))
                            oEMail_Cli = string.Empty;

                        if (!func.Validar_EMail(oEMail_Tra.ToString().Trim().ToLower()))
                            oEMail_Tra = string.Empty;

                        if (string.IsNullOrEmpty(oEMail_Cli.ToString()) && string.IsNullOrEmpty(oEMail_Tra.ToString()))
                            bContinuar = false;

                        //-- Continuar a enviar e-mail.
                        if (bContinuar)
                        {
                            Email mail = new Email();
                            mail.Server = row["NFE_EnvioXML_Servidor"].ToString();
                            mail.Port = Convert.ToInt32(row["NFE_EnvioXML_Servidor_Porta"]);

                            bool bRequer_Autenticacao = (bool)row["NFE_EnvioXML_Servidor_Autenticacao"];
                            if (bRequer_Autenticacao)
                            {
                                mail.Requer_Autenticacao = bRequer_Autenticacao;
                                mail.Usuario = row["NFE_EnvioXML_Usuario"].ToString();
                                mail.Senha = row["NFE_EnvioXML_Senha"].ToString();
                            }

                            if (!string.IsNullOrEmpty(oEMail_Cli.ToString()))
                            {
                                foreach (string sMail in oEMail_Cli.ToString().Trim().ToLower().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    if (!string.IsNullOrEmpty(sMail))
                                        mail.To.Add(sMail);
                                }
                            }

                            if (!string.IsNullOrEmpty(oEMail_Tra.ToString()))
                                mail.To.Add(oEMail_Tra.ToString());

                            mail.From = new System.Net.Mail.MailAddress(row["NFE_EnvioXML_EMail"].ToString());
                            mail.Prioridade = System.Net.Mail.MailPriority.High;

                            mail.Subject = string.Format("Envio de NF-e da {0}", row["Razao_social"].ToString());
                            mail.Body = row["NFE_EnvioXML_Mensagem"].ToString();

                            //-- Adiciona arquivos em anexo.
                            List<string> ilFilesAttach = new List<string>();
                            ilFilesAttach.Add(sFileName);
                            mail.Arquivo_Anexo = ilFilesAttach;

                            //-- Envia e-mail.
                            mail.SendMail();
                        }
                    }
                }
            }
        }
    }
}