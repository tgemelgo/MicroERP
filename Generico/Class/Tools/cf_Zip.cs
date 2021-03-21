using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CompSoft.Tools
{
    public class Zip
    {
        #region Compactar um arquivo

        /// <summary>
        /// Compactar um unico arquivo.
        /// </summary>
        /// <param name="sOrigem">Caminho e nome do arquivo de origem</param>
        /// <param name="sDestino">Caminho e nome do arquivo de destino</param>
        /// <returns>True/False para conclusão do processo.</returns>
        public Boolean CompactarArq(String sOrigem, String sDestino)
        {
            try
            {
                if (File.Exists(sDestino))
                    File.Delete(sDestino);

                using (ZipOutputStream s = new ZipOutputStream(File.Create(sDestino)))
                {
                    s.SetLevel(9); // 0 - store only to 9 - means best compression

                    byte[] buffer = new byte[4096];

                    ZipEntry entry = new ZipEntry(Path.GetFileName(sOrigem));

                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(sOrigem))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }

                    s.Finish();
                    s.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during processing {0}", ex);
                return false;
            }
        }

        #endregion Compactar um arquivo

        #region Compactar arquivos do diretorio

        /// <summary>
        /// Compactar todos os arquivos do diretorio.
        /// </summary>
        /// <param name="sOrigem">Diretorio de origem</param>
        /// <param name="sDestino">Caminho e nome do arquivo de destino</param>
        /// <returns>True/False para conclusão do processo.</returns>
        public Boolean CompactarDir(String sOrigem, String sDestino)
        {
            try
            {
                if (!Directory.Exists(sOrigem.Substring(0, sOrigem.Length - 1)))
                    Directory.CreateDirectory(sOrigem);

                string[] filenames = Directory.GetFiles(sOrigem);

                // 'using' statements gaurantee the stream is closed properly which is a big source
                // of problems otherwise.  Its exception safe as well which is great.
                using (ZipOutputStream s = new ZipOutputStream(File.Create(sDestino)))
                {
                    s.SetLevel(9); // 0 - store only to 9 - means best compression

                    byte[] buffer = new byte[4096];

                    foreach (string file in filenames)
                    {
                        // Using GetFileName makes the result compatible with XP
                        // as the resulting path is not absolute.
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                        // Setup the entry data as required.

                        // Crc and size are handled by the library for seakable streams
                        // so no need to do them here.

                        // Could also use the last write time or similar for the file.
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {
                            // Using a fixed size buffer here makes no noticeable difference for output
                            // but keeps a lid on memory usage.
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }

                    // Finish/Close arent needed strictly as the using statement does this automatically

                    // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                    // the created file would be invalid.
                    s.Finish();

                    // Close is important to wrap things up and unlock the file.
                    s.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas ao gerar arquivo zip.", ex);
            }
        }

        #endregion Compactar arquivos do diretorio

        #region Descompactar arquivo ZIP

        /// <summary>
        /// Descompactar arquivos
        /// </summary>
        /// <param name="sOrigem">Arquivos Zip de origem</param>
        /// <param name="sDestino">Diretorio onde será descompactado o arquivo.</param>
        /// <returns>True/False para conclusão do processo.</returns>
        public Boolean Descompactar(String sOrigem, String sDestino)
        {
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(sOrigem)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    if (!string.IsNullOrEmpty(directoryName))
                        directoryName = sDestino.Trim() + @"\" + directoryName;
                    else
                        directoryName = sDestino.Trim();

                    string fileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (!Directory.Exists(directoryName))
                        Directory.CreateDirectory(directoryName);

                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(directoryName + "\\" + fileName))
                        {
                            int size = 2048;
                            byte[] data = new byte[size];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                    streamWriter.Write(data, 0, size);
                                else
                                    break;
                            }
                        }
                    }
                }
                return true;
            }
        }

        #endregion Descompactar arquivo ZIP
    }
}