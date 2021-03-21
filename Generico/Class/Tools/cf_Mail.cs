using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CompSoft.compFrameWork
{
    public class Email : IDisposable
    {
        private MailMessage mm = new MailMessage();

        private string sServer = string.Empty,
            sUsuario = string.Empty,
            sSenha = string.Empty;

        private int iPort = 0;

        private IList<string> ilArquivos = new List<string>();

        private bool bRequer_Autenticacao = false;
        private MailPriority mp = MailPriority.Normal;

        #region Propriedades

        /// <summary>
        /// Identifica o arquivo em anexo.
        /// </summary>
        public IList<string> Arquivo_Anexo
        {
            get { return ilArquivos; }
            set { ilArquivos = value; }
        }

        /// <summary>
        /// Identifica a prioridade da mensagem.
        /// </summary>
        public MailPriority Prioridade
        {
            get { return mp; }
            set { mp = value; }
        }

        /// <summary>
        /// Servidor requer autenticação.
        /// </summary>
        public bool Requer_Autenticacao
        {
            get { return bRequer_Autenticacao; }
            set { bRequer_Autenticacao = value; }
        }

        /// <summary>
        /// Endereço do Servidor de e-mail
        /// </summary>
        public string Server
        {
            get { return sServer; }
            set { sServer = value; }
        }

        /// <summary>
        /// Porta de comunicação com o e-mail
        /// </summary>
        public int Port
        {
            get { return iPort; }
            set { iPort = value; }
        }

        /// <summary>
        /// Usuário para autenticação do servidor
        /// </summary>
        public string Usuario
        {
            get { return sUsuario; }
            set { sUsuario = value; }
        }

        /// <summary>
        /// Senha para autenticação do servidor
        /// </summary>
        public string Senha
        {
            get { return sSenha; }
            set { sSenha = value; }
        }

        /// <summary>
        /// E-Mail do remetente
        /// </summary>
        public MailAddress From
        {
            get { return mm.From; }
            set { mm.From = value; }
        }

        /// <summary>
        /// Assunto do e-mail
        /// </summary>
        public string Subject
        {
            get { return mm.Subject; }
            set { mm.Subject = value; }
        }

        /// <summary>
        /// Corpo da mensagem.
        /// </summary>
        public string Body
        {
            get { return mm.Body; }
            set { mm.Body = value; }
        }

        /// <summary>
        /// Lista de e-mail para envio do e-mail
        /// </summary>
        public MailAddressCollection To
        {
            get { return mm.To; }
        }

        /// <summary>
        /// Lista de e-mail para envio do e-mail com copia.
        /// </summary>
        public MailAddressCollection CC
        {
            get { return mm.CC; }
        }

        /// <summary>
        /// Lista de e-mail para envio do e-mail com copia oculta
        /// </summary>
        public MailAddressCollection Bcc
        {
            get { return mm.Bcc; }
        }

        #endregion Propriedades

        #region Envia e-mail

        /// <summary>
        /// Retina que enviará o e-mail
        /// </summary>
        /// <returns>Retorna true/false, se o processo de envio foi finalizado com sucesso.</returns>
        public bool SendMail()
        {
            bool bRetorno = true;

            try
            {
                mm.IsBodyHtml = true;
                mm.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mm.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                //-- Carrega arquivos e inclui no e-mail para envio.
                foreach (string sFileAttach in ilArquivos)
                {
                    if (!string.IsNullOrEmpty(sFileAttach) && System.IO.File.Exists(sFileAttach))
                        mm.Attachments.Add(new Attachment(sFileAttach));
                }

                mm.Priority = MailPriority.Normal;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;

                SmtpClient sc = null;
                if (iPort == 0)
                    sc = new SmtpClient(sServer);
                else
                    sc = new SmtpClient(sServer, iPort);

                //-- servidor requer autenticação
                if (bRequer_Autenticacao)
                    sc.Credentials = new System.Net.NetworkCredential(sUsuario, sSenha);

                sc.Send(mm);

                mm.Attachments.Clear();
                mm.Dispose();
                mm = null;
                sc = null;
            }
            catch (Exception ex)
            {
                bRetorno = false;
                MsgBox.Show("ERRO AO ENVIAR E-MAIL\r\n" + ex.Message
                    , "Erro ao enviar e-mail"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bRetorno;
        }

        #endregion Envia e-mail

        #region Trata E-mail para envio

        /// <summary>
        /// Trata e-mail removendo caracteres especiais.
        /// </summary>
        /// <param name="sEmail">E-Mail atual</param>
        /// <returns>E-mail com tratamento.</returns>
        public string Trata_Email(string sEmail)
        {
            string sAtualChar = "ãáàâéèêíìîõóòôûúùüç";
            string sNewChar = "aaaaeeeiiioooouuuuc";

            for (int i = 0; i < sAtualChar.Length; i++)
                sEmail = sEmail.Replace(sAtualChar.Substring(i, 1), sNewChar.Substring(i, 1));

            return sEmail;
        }

        #endregion Trata E-mail para envio

        #region IDisposable Members

        public void Dispose()
        {
            mm.Dispose();
            mm = null;
        }

        #endregion IDisposable Members
    }
}