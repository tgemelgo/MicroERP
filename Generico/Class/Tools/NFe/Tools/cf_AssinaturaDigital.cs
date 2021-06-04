using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace CompSoft.NFe
{
    internal class AssinaturaDigital
    {
        #region Enum

        /// <summary>
        /// Tipos de retornos ao assinar XML
        /// </summary>
        public enum Retorno_Assinatura
        {
            Sucesso = 0,
            Erro_Acessar_Certificado_digital = 1,
            Problema_Certificado_Digital = 2,
            XML_Mal_Formatado = 3,
            Tag_Assinatura_Inexistente = 4,
            Tag_Assinatura_Duplicada = 5,
            Erro_Assinar_Documento__ID_Deve_Ser_String,
            Erro_Assinar_Documento__Excesso
        }

        #endregion Enum

        #region Variaveis

        private string msgResultado;
        private XmlDocument XMLDoc;

        #endregion Variaveis

        #region Metodo responsável pela assinatura.

        /// <summary>
        /// Faz a assinatura digital do arquivo XML.
        /// </summary>
        /// <param name="XMLString">string XML a ser assinada</param>
        /// <param name="RefUri">Referência da URI a ser assinada (Ex. infNFe)</param>
        /// <param name="X509Cert">certificado digital a ser utilizado na assinatura digital</param>
        /// <returns>
        /// </returns>
        public Retorno_Assinatura Assinar(string XMLString, string RefUri, X509Certificate2 X509Cert)
        {
            int resultado = 0;
            msgResultado = "Assinatura realizada com sucesso";
            try
            {
                //   certificado para ser utilizado na assinatura
                //
                string _xnome = string.Empty;
                if (X509Cert != null)
                {
                    _xnome = X509Cert.Subject.ToString();
                }
                X509Certificate2 _X509Cert = new X509Certificate2();
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = store.Certificates;
                X509Certificate2Collection collection1 = collection.Find(X509FindType.FindBySubjectDistinguishedName, _xnome, false);
                if (collection1.Count == 0)
                {
                    resultado = 2;
                    msgResultado = "Problemas no certificado digital";
                }
                else
                {
                    // certificado ok
                    _X509Cert = collection1[0];
                    string x;
                    x = _X509Cert.GetKeyAlgorithm().ToString();
                    // Create a new XML document.
                    XmlDocument doc = new XmlDocument();

                    // Format the document to ignore white spaces.
                    doc.PreserveWhitespace = false;

                    // Load the passed XML file using it's name.
                    try
                    {
                        doc.LoadXml(XMLString);

                        // Verifica se a tag a ser assinada existe é única
                        int qtdeRefUri = doc.GetElementsByTagName(RefUri).Count;

                        if (qtdeRefUri == 0)
                        {
                            //  a URI indicada não existe
                            resultado = 4;
                            msgResultado = "A tag de assinatura " + RefUri.Trim() + " inexiste";
                        }
                        // Exsiste mais de uma tag a ser assinada
                        else
                        {
                            try
                            {
                                // Create a SignedXml object.
                                SignedXml signedXml = new SignedXml(doc);

                                // Add the key to the SignedXml document
                                signedXml.SigningKey = _X509Cert.PrivateKey;

                                for (int i = 0; i < doc.GetElementsByTagName(RefUri).Count; i++)
                                {
                                    // Create a reference to be signed
                                    Reference reference = new Reference();

                                    // pega o uri que deve ser assinada
                                    XmlAttributeCollection _Uri = doc.GetElementsByTagName(RefUri).Item(i).Attributes;
                                    reference.Uri = "#" + _Uri["Id"].InnerText;

                                    // Add an enveloped transformation to the reference.
                                    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                                    reference.AddTransform(env);

                                    XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                                    reference.AddTransform(c14);

                                    // Add the reference to the SignedXml object.
                                    signedXml.AddReference(reference);

                                    // Create a new KeyInfo object
                                    KeyInfo keyInfo = new KeyInfo();

                                    // Load the certificate into a KeyInfoX509Data object
                                    // and add it to the KeyInfo object.
                                    keyInfo.AddClause(new KeyInfoX509Data(_X509Cert));

                                    // Add the KeyInfo object to the SignedXml object.
                                    signedXml.KeyInfo = keyInfo;

                                    signedXml.ComputeSignature();

                                    // Get the XML representation of the signature and save
                                    // it to an XmlElement object.
                                    XmlElement xmlDigitalSignature = signedXml.GetXml();

                                    // Append the element to the XML document.
                                    doc.DocumentElement.GetElementsByTagName(RefUri).Item(i).ParentNode.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                                }

                                XMLDoc = new XmlDocument();
                                XMLDoc.PreserveWhitespace = false;
                                XMLDoc = doc;
                            }
                            catch (Exception caught)
                            {
                                resultado = 7;
                                msgResultado = "Erro: Ao assinar o documento - " + caught.Message;
                            }
                        }
                    }
                    catch (Exception caught)
                    {
                        resultado = 3;
                        msgResultado = "Erro: XML mal formado - " + caught.Message;
                    }
                }
            }
            catch (Exception caught)
            {
                resultado = 1;
                msgResultado = "Erro: Problema ao acessar o certificado digital" + caught.Message;
            }

            return (Retorno_Assinatura)resultado;
        }

        #endregion Metodo responsável pela assinatura.

        #region Proprieades

        /// <summary>
        /// Documento XML assinado.
        /// </summary>
        public XmlDocument XMLDocAssinado
        {
            get { return XMLDoc; }
        }

        /// <summary>
        /// string do xml assinado.
        /// </summary>
        public string XMLStringAssinado
        {
            get { return XMLDoc.OuterXml; }
        }

        /// <summary>
        /// string com a mensagem de retorno.
        /// </summary>
        public string mensagemResultado
        {
            get { return msgResultado; }
        }

        #endregion Proprieades
    }
}