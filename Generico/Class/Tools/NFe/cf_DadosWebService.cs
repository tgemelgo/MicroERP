using System;
using System.Collections.Generic;
using System.Text;

namespace CompSoft.NFe
{
    /// <summary>
    /// Web Services disponiveis
    /// </summary>
    public enum Tipos_Servicos
    {
        //NfeCancelamento,
        NfeConsultaCadastro,

        NfeConsultaProtocolo,
        NfeInutilizacao,
        NfeRecepcao,
        NfeRetRecepcao,
        NfeStatusServico,
        RecepcaoDPEC,
        ConsultaDPEC,
        Sem_WebService_Arquivo_NFe,
        Sem_WebService_Arquivo_NFe_Cliente,
        nfeRecepcaoEvento
    }

    public class Dados_DocumentosNFe : IDisposable
    {
        private Tipos_Servicos tp_servicos = Tipos_Servicos.NfeRecepcao;
        private string sVersao_Dados = string.Empty;
        private string sArquivo_XSD = string.Empty;
        private string sWebService = string.Empty;

        #region Propriedades

        /// <summary>
        /// Tipo de serviço selecionado.
        /// </summary>
        public Tipos_Servicos Tipo_Servico
        {
            get { return tp_servicos; }
        }

        /// <summary>
        /// Versão do layout XML.
        /// </summary>
        public string Versao_Dados
        {
            get { return sVersao_Dados; }
        }

        /// <summary>
        /// Arquivo XSD para validação do layout
        /// </summary>
        public string Arquivo_XSD
        {
            get { return sArquivo_XSD + ".xsd"; }
        }

        /// <summary>
        /// Url para trabalho do webservice.
        /// </summary>
        public string Url_WebService
        {
            get { return sWebService; }
        }

        #endregion Propriedades

        #region contrutor

        /// <summary>
        /// Contrutor
        /// Não retorna a URL do WebService
        /// </summary>
        /// <param name="tp_Servico">Tipo de serviço</param>
        public Dados_DocumentosNFe(Tipos_Servicos tp_Servico)
        {
            tp_servicos = tp_Servico;

            //-- Carreta os parametos do WebService
            this.Setar_Paramentros();
        }

        /// <summary>
        /// Contrutor
        /// Retorna a URL do WebService
        /// </summary>
        /// <param name="tp_Servico">Tipo de serviço</param>
        /// <param name="sEstado">Estado para transmissão dos dados.</param>
        public Dados_DocumentosNFe(Tipos_Servicos tp_Servico, string sEstado)
        {
            tp_servicos = tp_Servico;

            //-- Carreta os parametos do WebService
            this.Setar_Paramentros();

            //-- Busca o Webservice que será utilizado;
            sWebService = this.Busca_URL_WebService(sEstado);
        }

        #endregion contrutor

        #region Seta variaveis para retorno nas propriedades

        /// <summary>
        /// Seta os valores das variaveis para retorno nas propriedades.
        /// </summary>
        private void Setar_Paramentros()
        {
            //-- Seleciona a versão do layout XML
            switch (tp_servicos)
            {
                case Tipos_Servicos.ConsultaDPEC:
                    sVersao_Dados = "";
                    break;

                case Tipos_Servicos.nfeRecepcaoEvento:
                    sVersao_Dados = "1.00";
                    sArquivo_XSD = "envEventoCancNFe_v" + sVersao_Dados;
                    break;

                case Tipos_Servicos.NfeConsultaCadastro:
                    sVersao_Dados = "4.00";
                    break;

                case Tipos_Servicos.NfeConsultaProtocolo:
                    sVersao_Dados = "4.00";
                    sArquivo_XSD = "consSitNFe_v" + sVersao_Dados;
                    break;

                case Tipos_Servicos.NfeInutilizacao:
                    sVersao_Dados = "4.00";
                    sArquivo_XSD = "inutNFe_v" + sVersao_Dados;
                    break;

                case Tipos_Servicos.NfeRecepcao:
                    sVersao_Dados = "4.00";
                    sArquivo_XSD = "enviNFe_v" + sVersao_Dados;
                    break;

                case Tipos_Servicos.NfeRetRecepcao:
                    sVersao_Dados = "4.00";
                    sArquivo_XSD = "consReciNFe_v" + sVersao_Dados;
                    break;

                case Tipos_Servicos.NfeStatusServico:
                    sVersao_Dados = "4.00";
                    sArquivo_XSD = "consStatServ_v" + sVersao_Dados;
                    break;

                case Tipos_Servicos.RecepcaoDPEC:
                    sVersao_Dados = "";
                    break;

                case Tipos_Servicos.Sem_WebService_Arquivo_NFe:
                    sVersao_Dados = "4.00";
                    sArquivo_XSD = "nfe_v" + sVersao_Dados;
                    break;

                case Tipos_Servicos.Sem_WebService_Arquivo_NFe_Cliente:
                    sVersao_Dados = "4.00";
                    break;
            }
        }

        #endregion Seta variaveis para retorno nas propriedades

        #region Busca URL do Webservice

        /// <summary>
        /// Retorna a URL do Web-Service que será utilizado.
        /// </summary>
        /// <param name="sEstado">Estado de origem do WebService</param>
        /// <returns>string com a URL do WebService</returns>
        private string Busca_URL_WebService(string sEstado)
        {
            compFrameWork.Funcoes func;
            string sAmbiente = func.Busca_Propriedade("Ambiente_NFe");

            ////-- Verifica se o ambiente a ser utilizado é o do estado ou o virtual
            //switch (sEstado)
            //{
            //    //-- SEFAZ VIRTUAL RS (RIO GRANDE DO SUL)
            //    case "AC":
            //    case "AL":
            //    case "AM":
            //    case "AP":
            //    case "DF":
            //    case "MS":
            //    case "PB":
            //    case "RJ":
            //    case "RO":
            //    case "RR":
            //    case "SC":
            //    case "SE":
            //    case "TO":
            //        sEstado = "SVRS";
            //        break;

            //    //-- SEFAZ VIRTUAL AN (AMBIENTE NACIONAL)
            //    case "CE":
            //    case "ES":
            //    case "MA":
            //    case "PA":
            //    case "PI":
            //    case "RN":
            //        sEstado = "SVAN";
            //        break;
            //}

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select WebService, 0 from Enderecos_WebService_Nfe");
            sb.Append(" where Estado = '");
            sb.Append(sEstado);
            sb.AppendLine("'");
            sb.Append(" and Ambiente = ");
            sb.AppendLine(sAmbiente);
            sb.Append(" and servico = '");
            sb.Append(tp_servicos.ToString());
            sb.AppendLine("'");

            return Data.SQL.ExecuteScalar(sb.ToString()).ToString();
        }

        #endregion Busca URL do Webservice

        #region IDisposable Members

        public void Dispose()
        {
            sVersao_Dados = null;
            sArquivo_XSD = null;
            sWebService = null;
        }

        #endregion IDisposable Members
    }
}