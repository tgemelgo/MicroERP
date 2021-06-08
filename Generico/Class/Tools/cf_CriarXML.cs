using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CompSoft.Tools
{
    public class CriarXML : IDisposable
    {
        private XmlDocument xml = new XmlDocument();

        public XmlDocument DocumentoXML
        {
            get { return xml; }
            set { xml = value; }
        }

        #region Cria declaração inicial do XML

        /// <summary>
        /// Cria a declaração do XML
        /// </summary>
        /// <param name="versao">Número da versão</param>
        /// <param name="encoding">Nome do encoding utilizado no XML.</param>
        public void Criar_Declaracao(string versao, string encoding)
        {
            //-- Cria a declaração do XML.
            XmlDeclaration declare = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(declare);
        }

        #endregion Cria declaração inicial do XML

        #region Cria Elemento pai

        /// <summary>
        /// Cria o elemento
        /// </summary>
        /// <param name="sNome">Nome do elemento</param>
        public void Criar_Elemento(string sNome)
        {
            XmlElement elemento = xml.CreateElement(sNome);
            xml.AppendChild(elemento);
        }

        #endregion Cria Elemento pai

        #region Cria elemento filho

        /// <summary>
        /// Cria o elemento com referencia ao elemento pai
        /// </summary>
        /// <param name="sXPath_Elemento">XPath do elemento ex. /Nivel 1/Nivel 2</param>
        /// <param name="sNome">Nome do novo elemento</param>
        public void Criar_Elemento(string sXPath_Elemento, string sNome)
        {
            XmlNodeList list = xml.SelectNodes(sXPath_Elemento);
            foreach (XmlNode node in list)
            {
                XmlElement elemento = xml.CreateElement(sNome);
                node.AppendChild((XmlNode)elemento);
            }
        }

        #endregion Cria elemento filho

        #region Seta atributos

        /// <summary>
        /// Seta atributo para elemento
        /// </summary>
        /// <param name="sXPath_Elemento">XPath do elemento para setar atributo</param>
        /// <param name="sNome_Atributo">Nome do atributo</param>
        /// <param name="sValor_Atributo">Valor do atributo</param>
        public void Setar_Atributo(string sXPath_Elemento, string sNome_Atributo, string sValor_Atributo)
        {
            XmlNodeList list = xml.SelectNodes(sXPath_Elemento);
            foreach (XmlNode node in list)
            {
                XmlElement element_pai = ((XmlElement)node);

                if (!element_pai.HasAttribute(sNome_Atributo))
                {
                    XmlAttribute atributo = xml.CreateAttribute(sNome_Atributo);
                    atributo.Value = sValor_Atributo;
                    node.Attributes.Append(atributo);
                }
            }
        }

        #endregion Seta atributos

        #region Inclusão dos campos

        /// <summary>
        /// Cria campo para elemento
        /// </summary>
        /// <param name="sXPath_Elemento">XPath do elemento para criar campo</param>
        /// <param name="sNome_Campo">Nome do campo</param>
        /// <param name="sValor_Campo">String Valor do campo</param>
        public void Criar_Campo(string sXPath_Elemento, string sNome_Campo, string sValor_Campo)
        {
            XmlNodeList list = xml.SelectNodes(sXPath_Elemento);

            foreach (XmlNode node in list)
            {
                compFrameWork.Funcoes func;
                XmlElement elemento = xml.CreateElement(sNome_Campo);
                XmlText texto = xml.CreateTextNode(func.Tira_Acento(sValor_Campo, 60));
                elemento.AppendChild(texto);

                node.AppendChild((XmlNode)elemento);
            }
        }

        /// <summary>
        /// Cria campo para elemento
        /// </summary>
        /// <param name="sXPath_Elemento">XPath do elemento para criar campo</param>
        /// <param name="sNome_Campo">Nome do campo</param>
        /// <param name="sValor_Campo">String Valor do campo</param>
        /// <param name="iQtdeCaract">Quantidade de caracteres máximos no registro</param>
        public void Criar_Campo(string sXPath_Elemento, string sNome_Campo, string sValor_Campo, int iQtdeCaract)
        {
            XmlNodeList list = xml.SelectNodes(sXPath_Elemento);

            foreach (XmlNode node in list)
            {
                compFrameWork.Funcoes func;
                XmlElement elemento = xml.CreateElement(sNome_Campo);
                XmlText texto = xml.CreateTextNode(func.Tira_Acento(sValor_Campo, iQtdeCaract));
                elemento.AppendChild(texto);

                node.AppendChild((XmlNode)elemento);
            }
        }

        /// <summary>
        /// Cria campo para elemento
        /// </summary>
        /// <param name="sXPath_Elemento">XPath do elemento para criar campo</param>
        /// <param name="sNome_Campo">Nome do campo</param>
        /// <param name="oValor_Campo">Object valor do campo</param>
        public void Criar_Campo(string sXPath_Elemento, string sNome_Campo, object oValor_Campo)
        {
            XmlNodeList list = xml.SelectNodes(sXPath_Elemento);
            foreach (XmlNode node in list)
            {
                compFrameWork.Funcoes func;
                XmlElement elemento = xml.CreateElement(sNome_Campo);
                XmlText texto = xml.CreateTextNode(func.Tira_Acento(oValor_Campo.ToString(), 60));
                elemento.AppendChild(texto);

                node.AppendChild((XmlNode)elemento);
            }
        }

        /// <summary>
        /// Cria campo para elemento
        /// </summary>
        /// <param name="sXPath_Elemento">XPath do elemento para criar campo</param>
        /// <param name="sNome_Campo">Nome do campo</param>
        /// <param name="dValor_Campo">datetime valor do campo</param>
        public void Criar_Campo(string sXPath_Elemento, string sNome_Campo, DateTime dValor_Campo)
        {
            XmlNodeList list = xml.SelectNodes(sXPath_Elemento);
            foreach (XmlNode node in list)
            {
                XmlElement elemento = xml.CreateElement(sNome_Campo);
                XmlText texto = xml.CreateTextNode(dValor_Campo.ToString("yyyy-MM-dd"));
                elemento.AppendChild(texto);

                node.AppendChild((XmlNode)elemento);
            }
        }

        /// <summary>
        /// Cria campo para elemento
        /// </summary>
        /// <param name="sXPath_Elemento">XPath do elemento para criar campo</param>
        /// <param name="sNome_Campo">Nome do campo</param>
        /// <param name="dValor_Campo">Valor em decimal</param>
        /// <param name="iQtdeCasasDecimal">quantidade de casas decimais</param>
        public void Criar_Campo(string sXPath_Elemento, string sNome_Campo, decimal dValor_Campo, int iQtdeCasasDecimal)
        {
            XmlNodeList list = xml.SelectNodes(sXPath_Elemento);
            foreach (XmlNode node in list)
            {
                XmlElement elemento = xml.CreateElement(sNome_Campo);
                XmlText texto = xml.CreateTextNode(string.Format("{0:n" + iQtdeCasasDecimal.ToString() + "}", dValor_Campo).Replace(".", "").Replace(",", "."));
                elemento.AppendChild(texto);

                node.AppendChild(elemento);
            }
        }

        #endregion Inclusão dos campos

        #region Salva arquivo em disco

        /// <summary>
        /// Salva XML em disco
        /// </summary>
        /// <param name="sFile">Caminho com o nome do arquivo</param>
        public void Salvar(string sFile)
        {
            xml.Save(sFile);
        }

        #endregion Salva arquivo em disco

        #region IDisposable Members

        public void Dispose()
        {
            xml = null;
        }

        #endregion IDisposable Members
    }
}