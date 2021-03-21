using System;
using System.IO;
using System.Net;
using System.Text;

namespace CompSoft.compFrameWork
{
    /// <summary>
    /// Classe para transações em FTP
    /// </summary>
    public class FTP
    {
        private string ftpServerIP = "";
        private string ftpUserID = "";
        private string ftpPassword = "";
        private string ftpPathRemoto = "";
        private int buffLength = 128;

        #region Construtores

        public FTP()
        { }

        public FTP(string Servidor, string Usuario, string Senha)
        {
            ftpServerIP = Servidor;
            ftpUserID = Usuario;
            ftpPassword = Senha;
        }

        public FTP(string Servidor, string Usuario, string Senha, string PathRemoto)
        {
            ftpServerIP = Servidor;
            ftpUserID = Usuario;
            ftpPassword = Senha;
            ftpPathRemoto = PathRemoto;
        }

        #endregion Construtores

        #region Propriedades

        /// <summary>
        /// Endereço do servido FTP
        /// </summary>
        public string Host
        {
            get { return ftpServerIP; }
            set { ftpServerIP = value; }
        }

        /// <summary>
        /// Usuário para autenticação no Servidor FTP
        /// </summary>
        public string User
        {
            get { return ftpUserID; }
            set { ftpUserID = value; }
        }

        /// <summary>
        /// Senha para autenticação no Servidor FTP
        /// </summary>
        public string Password
        {
            get { return ftpPassword; }
            set { ftpPassword = value; }
        }

        /// <summary>
        /// Path Remoto onde o sistema fará Upload e Download dos arquivos.
        /// </summary>
        public string Path_Remoto
        {
            get { return ftpPathRemoto; }
            set { ftpPathRemoto = value; }
        }

        #endregion Propriedades

        #region Upload de arquivo

        /// <summary>
        /// Metodo especifico para upload de arquivo.
        /// </summary>
        /// <param name="filename">Caminho completo do arquivo que será envido para o servidor FTP</param>
        /// <returns>true/false indicando se o processo foi finalizado com sucesso</returns>
        public bool Upload(string filename)
        {
            bool bRetorno = false;

            FileInfo fileInf = new FileInfo(filename);

            string uri = "ftp://" + ftpServerIP + ftpPathRemoto + fileInf.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(uri);

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 128b
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = null;

            //-- Verifica se é possível abrir o arquivo para transferencia.
            try
            {
                bool bAbrirArquivo = false;
                DateTime dt_Termino = DateTime.Now.AddMinutes(3);

                while (!bAbrirArquivo & dt_Termino >= DateTime.Now)
                {
                    try
                    {
                        // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
                        fs = fileInf.Open(FileMode.Open, FileAccess.Read);
                        bAbrirArquivo = true;
                    }
                    catch
                    {
                        bAbrirArquivo = false;
                        if (fs != null)
                        {
                            fs.Close();
                            fs.Dispose();
                            fs = null;
                        }
                    }
                }

                if (bAbrirArquivo)
                {
                    // Stream to which the file to be upload is written
                    Stream strm = reqFTP.GetRequestStream();

                    // Read from the file stream 128b at a time
                    contentLen = fs.Read(buff, 0, buffLength);

                    // Till Stream content ends
                    while (contentLen != 0)
                    {
                        // Write Content from the file stream to the FTP Upload Stream
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }

                    // Close the file stream and the Request Stream
                    strm.Close();
                    fs.Close();

                    strm.Dispose();
                    fs.Dispose();

                    strm = null;
                    fs = null;

                    bRetorno = true;
                }
                else
                {
                    bRetorno = false;
                }
            }
            catch
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }

                bRetorno = false;
            }

            return bRetorno;
        }

        #endregion Upload de arquivo

        #region Exclusão de arquivo remoto

        /// <summary>
        /// Metodo responsável por excluir arquivos remotos no servidor.
        /// </summary>
        /// <param name="fileName">Path remoto completo identificando o arquivo para exclusão.</param>
        /// <returns>true/false indicando se o processo foi finalizado com sucesso.</returns>
        public bool DeleteFTP(string fileName)
        {
            bool bRetorno = true;

            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + fileName));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();

                sr.Close();
                datastream.Close();
                response.Close();

                sr.Dispose();
                datastream.Dispose();

                sr = null;
                datastream = null;
                response = null;
            }
            catch
            {
                bRetorno = false;
            }

            return bRetorno;
        }

        #endregion Exclusão de arquivo remoto

        #region Mostra detalhes dos arquivos por diretório

        /// <summary>
        /// Retorna o HTML contendo detalhes dos diretório dos arquivos.
        /// </summary>
        /// <param name="Path_Remoto">Path que será verificado</param>
        /// <returns>string[] contendo todos os arquivos encontrados</returns>
        public string[] GetFilesDetailList(string Path_Remoto)
        {
            ftpPathRemoto = Path_Remoto;

            string[] downloadFiles;
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + ftpPathRemoto));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }

                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();

                reader.Dispose();

                response = null;
                reader = null;

                return result.ToString().Split('\n');
            }
            catch
            {
                downloadFiles = null;
                return downloadFiles;
            }
        }

        #endregion Mostra detalhes dos arquivos por diretório

        #region Retorna Lista de arquivos.

        /// <summary>
        /// Retorno lista de arquivos
        /// </summary>
        /// <param name="Path_Remoto">Path para retorno dos dados</param>
        /// <returns>string[] contendo conteudo HTML </returns>
        public string[] GetFileList(string Path_Remoto)
        {
            ftpPathRemoto = Path_Remoto;

            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + ftpPathRemoto));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();

                reader.Dispose();

                response = null;
                reader = null;

                return result.ToString().Split('\n');
            }
            catch
            {
                downloadFiles = null;
                return downloadFiles;
            }
        }

        #endregion Retorna Lista de arquivos.

        #region Download de arquivo por FTP

        /// <summary>
        /// Faz o download de um arquivo por FTP
        /// </summary>
        /// <param name="fileName_Local">Caminho completo do arquivo (O nome do arquivo terá que ser o mesmo do remoto.</param>
        /// <param name="pathRemoto">Path remoto do arquivo.</param>
        /// <returns>true/false indicando se o processo foi finalizado com sucesso.</returns>
        public bool Download(string fileName_Local, string pathRemoto)
        {
            ftpPathRemoto = pathRemoto;

            bool bRetorno = true;
            FtpWebRequest reqFTP;
            try
            {
                FileInfo fileInf = new FileInfo(fileName_Local);

                //-- Verifica se o arquivo existe, caso exista o sistema deve exclui-lo.
                if (fileInf.Exists)
                    fileInf.Delete();

                FileStream outputStream = new FileStream(fileName_Local, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + ftpPathRemoto + fileInf.Name));

                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;

                reqFTP.UseBinary = true;

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                byte[] buffer = new byte[buffLength];

                int readCount;
                readCount = ftpStream.Read(buffer, 0, buffLength);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, buffLength);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();

                ftpStream.Dispose();
                outputStream.Dispose();

                response = null;
                ftpStream = null;
                outputStream = null;
            }
            catch
            {
                bRetorno = false;
            }

            return bRetorno;
        }

        #endregion Download de arquivo por FTP
    }
}