using CompSoft.compFrameWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace CompSoft.NFe
{
    public class AssinaXML
    {
        /// <summary>
        /// Assina arquivo XML
        /// </summary>
        /// <param name="_arquivo">Path completo do arquivo que será assinado.</param>
        /// <param name="_uri">URI a ser assinada (Ex.: infCanc, infNFe, infInut, etc.)</param>
        /// <param name="sSerialNumber">string com o Serial number para localizar o Certificado Digital</param>
        /// <returns></returns>
        public bool AssinarArquivoXML(string _arquivo, string _uri, string sSerialNumber)
        {
            bool bRetorno = false;

            if (string.IsNullOrEmpty(_arquivo) || !File.Exists(_arquivo))
                bRetorno = false;
            else
            {
                if (_uri == null)
                    bRetorno = false;
                else
                {
                    string _stringXml;

                    //-- Le o arquivo xml
                    StreamReader SR;
                    SR = File.OpenText(_arquivo);
                    _stringXml = SR.ReadToEnd();
                    SR.Close();

                    //-- Realiza assinatura
                    AssinaturaDigital AD = new AssinaturaDigital();
                    X509Certificate2 cert = new X509Certificate2();

                    //-- Seleciona certificado do repositório MY do windows ou um certificado previamento selecionado.
                    Certificado certificado = new Certificado();
                    if (string.IsNullOrEmpty(sSerialNumber))
                        cert = certificado.Buscar_Certificado_Digital();
                    else
                        cert = certificado.Buscar_Certificado_Digital(sSerialNumber, X509FindType.FindBySerialNumber);

                    //-- Caso o certificado digital seja selecionado.
                    if (certificado.Certificado_Selecionado)
                    {
                        //-- Avisa usuário sobre vencimento do certificado digital.
                        this.Verifica_Vencimento_Certificado(cert);

                        //-- Assina o XML.
                        AssinaturaDigital.Retorno_Assinatura resultado = AD.Assinar(_stringXml, _uri, cert);
                        if (resultado == AssinaturaDigital.Retorno_Assinatura.Sucesso)
                        {
                            //-- grava arquivo assinado
                            StreamWriter SW;
                            SW = File.CreateText(_arquivo.Trim());
                            SW.Write(AD.XMLStringAssinado);
                            SW.Close();
                            bRetorno = true;
                        }
                        else
                        {
                            MsgBox.Show(AD.mensagemResultado);
                            bRetorno = false;
                        }
                    }
                    else
                        bRetorno = false;
                }
            }

            return bRetorno;
        }

        private void Verifica_Vencimento_Certificado(X509Certificate2 cert)
        {
            Funcoes func;
            DateTime dt_Expira = Convert.ToDateTime(cert.GetExpirationDateString());
            int iDias_Para_Renovacao = Convert.ToInt32(func.DateDiff(Funcoes.DateInterval.Day, DateTime.Now, dt_Expira));
            //-- Verifica se a data de vencimento é menor que dois meses
            if (iDias_Para_Renovacao <= 60)
            {
                CompSoft.compFrameWork.RegistroWindows rw = new RegistroWindows();
                object oValor = rw.LocalizaRegistro("Notificacao_DataExpiracao_Certificado");
                if (string.IsNullOrEmpty(oValor.ToString()))
                {
                    oValor = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                }

                int iPeriodo_Aviso = 0;
                if (iDias_Para_Renovacao >= 50)
                    iPeriodo_Aviso = 15;
                else if (iDias_Para_Renovacao >= 30 && iDias_Para_Renovacao <= 49)
                    iPeriodo_Aviso = 7;
                else if (iDias_Para_Renovacao >= 15 && iDias_Para_Renovacao <= 29)
                    iPeriodo_Aviso = 3;
                else if (iDias_Para_Renovacao <= 14)
                    iPeriodo_Aviso = 1;

                rw.GravarRegistro("Notificacao_DataExpiracao_Certificado", DateTime.Now.AddDays(iPeriodo_Aviso).ToString("dd/MM/yyyy hh:mm:ss"));

                string sMensagem = string.Empty;
                if (iDias_Para_Renovacao >= 0)
                    sMensagem = "Seu certificado digital vencerá no dia '{0}', providencie a renovação.";
                else
                    sMensagem = "Seu certificado digital venceu no dia '{0}', providencie a renovação.";

                sMensagem = string.Format(sMensagem, dt_Expira.ToString("dd/MM/yyyy"));
                MsgBox.Show(sMensagem
                    , "Atenção"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Warning);
            }
        }
    }
}