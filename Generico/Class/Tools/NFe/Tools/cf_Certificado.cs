using CompSoft.compFrameWork;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace CompSoft.NFe
{
    /// <summary>
    /// Classe reponsável por gerenciar o certificado digital
    /// </summary>
    public class Certificado
    {
        private bool bCertificado_Selecionado = false;

        public bool Certificado_Selecionado
        {
            get { return bCertificado_Selecionado; }
        }

        #region Busca certificado por nome

        /// <summary>
        /// Retorna o certificado digital
        /// </summary>
        /// <param name="sValor_Busca">Valor que permite filtrar os dados do sertificado digital</param>
        /// <param name="Tipo_Busca">Tipo de buscar</param>
        /// <returns>Certificado digital responsável pela assinatura do NF-e</returns>
        public X509Certificate2 Buscar_Certificado_Digital(string sValor_Busca, X509FindType Tipo_Busca)
        {
            bCertificado_Selecionado = false;
            X509Certificate2 _X509Cert = new X509Certificate2();
            try
            {
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection collection2 = (X509Certificate2Collection)collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);

                X509Certificate2Collection scollection = (X509Certificate2Collection)collection2.Find(Tipo_Busca, sValor_Busca, false);
                if (scollection.Count == 0)
                {
                    MsgBox.Show("Nenhum certificado válido foi encontrado com o valor informado: '" + sValor_Busca + "'\r\nSelecione um novo certificado."
                        , "Atenção"
                        , System.Windows.Forms.MessageBoxButtons.OK
                        , System.Windows.Forms.MessageBoxIcon.Warning);

                    scollection = X509Certificate2UI.SelectFromCollection(collection2, "Certificado(s) Digital(is) disponível(is)", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);
                    if (scollection.Count == 0)
                    {
                        _X509Cert.Reset();
                        MsgBox.Show("Nenhum certificado escolhido", "Atenção");
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                        bCertificado_Selecionado = true;
                    }
                }
                else
                {
                    _X509Cert = scollection[0];
                    bCertificado_Selecionado = true;
                }

                store.Close();
                return _X509Cert;
            }
            catch (System.Exception ex)
            {
                MsgBox.Show(ex.Message);
                return _X509Cert;
            }
        }

        #endregion Busca certificado por nome

        #region Busca certificado digital sem filtro

        /// <summary>
        /// Retorna o certificado digital
        /// </summary>
        /// <returns>Certificado digital responsável pela assinatura do NF-e</returns>
        public X509Certificate2 Buscar_Certificado_Digital()
        {
            bCertificado_Selecionado = false;
            X509Certificate2 _X509Cert = new X509Certificate2();
            try
            {
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection collection2 = (X509Certificate2Collection)collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);

                //-- Busca certificados disponiveis
                X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection2, "Certificado(s) Digital(is) disponível(is)", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);
                if (scollection.Count == 0)
                {
                    _X509Cert.Reset();
                    MsgBox.Show("Nenhum certificado escolhido", "Atenção");
                }
                else
                {
                    _X509Cert = scollection[0];
                    bCertificado_Selecionado = true;
                }

                store.Close();
                return _X509Cert;
            }
            catch (System.Exception ex)
            {
                MsgBox.Show(ex.Message);
                return _X509Cert;
            }
        }

        #endregion Busca certificado digital sem filtro
    }
}