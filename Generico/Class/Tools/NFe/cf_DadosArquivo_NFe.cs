using System;
using System.Data;
using System.Text;

namespace CompSoft.NFe
{
    public enum Formas_Emissao
    {
        Normal = 1,
        Formulario_Seguranca = 2,
        Contigencia_SCAN = 3,
        Contigencia_DPEC = 4
    }

    /// <summary>
    /// Classe para identificação dos documentos XML
    /// </summary>
    public class Dados_Arquivo_NFe
    {
        private string sArquivoXML = string.Empty;
        private string sEstado_Emissor = string.Empty;
        private string sNumero_Recibo = string.Empty;
        private string sChave_Acesso = string.Empty;
        private string sNumero_Autorizacao = string.Empty;
        private int iNota_Fiscal = 0;
        private int iEmpresa = 0;
        private int iNumero_Lote = 0;
        private int iNota_Fiscal_Lote = 0;
        private int iCodEstado_Emissor = 0;
        private string sTexto_Carta_Correcao = string.Empty;
        private Formas_Emissao fm_Emissao = Formas_Emissao.Normal;
        private Ambientes tp_Ambiente = Ambientes.Homologacao;

        public Dados_Arquivo_NFe(int Codigo_Nota_Fiscal)
        {
            iNota_Fiscal = Codigo_Nota_Fiscal;
        }

        public Dados_Arquivo_NFe()
        {
        }

        /// <summary>
        /// Número da autorilização de uso da NF-e.
        /// </summary>
        public string Numero_Autorizacao_Uso
        {
            get { return sNumero_Autorizacao; }
            set { sNumero_Autorizacao = value; }
        }

        /// <summary>
        /// Chave de acesso da NF-e string com 44 posições
        /// </summary>
        public string Texto_Carta_Correcao
        {
            get { return sTexto_Carta_Correcao; }
            set { sTexto_Carta_Correcao = value; }
        }

        /// <summary>
        /// Chave de acesso da NF-e string com 44 posições
        /// </summary>
        public string Chave_Acesso
        {
            get { return sChave_Acesso; }
            set { sChave_Acesso = value; }
        }

        /// <summary>
        /// Ambiente que a NF-e foi emitida.
        /// </summary>
        public Ambientes Ambiente
        {
            get { return tp_Ambiente; }
            set { tp_Ambiente = value; }
        }

        /// <summary>
        /// Código da tabela nota fiscal lote
        /// </summary>
        public int Cod_Nota_Fiscal_Lote
        {
            get { return iNota_Fiscal_Lote; }
            set { iNota_Fiscal_Lote = value; }
        }

        /// <summary>
        /// Numero do comprovante de envio para Secretária da Fazenda.
        /// </summary>
        public string Numero_Recibo
        {
            get { return sNumero_Recibo; }
            set { sNumero_Recibo = value; }
        }

        /// <summary>
        /// Código da empresa que está enviando o lote... (Código interno) tabela de empresas
        /// </summary>
        public int Empresa
        {
            get { return iEmpresa; }
            set { iEmpresa = value; }
        }

        /// <summary>
        /// CNPJ da empresa que está enviando o lote...
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        /// Numero do lote de envio.
        /// </summary>
        public int Numero_Lote
        {
            get { return iNumero_Lote; }
            set { iNumero_Lote = value; }
        }

        /// <summary>
        /// Caminho do documento XML.
        /// </summary>
        public string Arquivo_XML
        {
            get { return sArquivoXML; }
            set { sArquivoXML = value; }
        }

        /// <summary>
        /// Estado do emissor da NF-e
        /// </summary>
        public string Estado_Emissor
        {
            get { return sEstado_Emissor; }
            set { sEstado_Emissor = value; }
        }

        /// <summary>
        /// Código identity da NF no ERP CompSoft
        /// </summary>
        public int Nota_Fiscal
        {
            get { return iNota_Fiscal; }
            set { iNota_Fiscal = value; }
        }

        /// <summary>
        /// Forma de Emissão da NF-e.
        /// </summary>
        public Formas_Emissao Forma_Emissao
        {
            get { return fm_Emissao; }
            set { fm_Emissao = value; }
        }

        /// <summary>
        /// Código do estado emissor
        /// </summary>
        public int Codigo_Estado_Emissor
        {
            get
            {
                if (iCodEstado_Emissor == 0)
                {
                    iCodEstado_Emissor = Convert.ToInt32(Data.SQL.ExecuteScalar(string.Format("select codigo_IBGE from estados where estado = '{0}'", sEstado_Emissor)));
                }

                return iCodEstado_Emissor;
            }
        }

        /// <summary>
        /// Carrega dados já existentes de um LOTE
        /// </summary>
        /// <param name="NotaFiscal_Lote"></param>
        public void Carregar_Dados(int NotaFiscal_Lote)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   nfl.Nota_Fiscal_Lote");
            sb.AppendLine(" , nf.Nota_Fiscal");
            sb.AppendLine(" , nfl.Empresa");
            sb.AppendLine(" , nfl.Numero_Lote");
            sb.AppendLine(" , nfl.Protocolo");
            sb.AppendLine(" , nfl.Tipo_Emissao_NFe");
            sb.AppendLine(" , nfl.Arquivo_envio");
            sb.AppendLine(" , nfl.Ambiente_NFe");
            sb.AppendLine(" , nf.nfe_protocolo");
            sb.AppendLine(" , e.estado");
            sb.AppendLine(" , e.CNPJ");
            sb.AppendLine(" , nf.Chave_Acesso");
            sb.AppendLine(" , nf.Texto_Carta_Correcao");
            sb.AppendLine(" from notas_fiscais_Lotes nfl ");
            sb.AppendLine("  inner join notas_fiscais_lotes_itens nfli on nfli.nota_fiscal_lote = nfl.nota_fiscal_lote");
            sb.AppendLine("  inner join notas_fiscais nf on nf.nota_fiscal = nfli.nota_fiscal");
            sb.AppendLine("  inner join empresas e on e.empresa = nf.empresa");
            sb.AppendFormat(" where nfl.nota_fiscal_lote = {0}\r\n", NotaFiscal_Lote);
            DataTable dt = CompSoft.Data.SQL.Select(sb.ToString(), "x", false);

            foreach (DataRow row in dt.Select())
            {
                sArquivoXML = row["Arquivo_envio"].ToString();
                sEstado_Emissor = row["estado"].ToString();
                sNumero_Recibo = row["Protocolo"].ToString();
                iNota_Fiscal = Convert.ToInt32(row["Nota_Fiscal"]);
                iEmpresa = Convert.ToInt32(row["Empresa"]);
                iNumero_Lote = Convert.ToInt32(row["Numero_Lote"]);
                iNota_Fiscal_Lote = Convert.ToInt32(row["Nota_Fiscal_Lote"]);
                fm_Emissao = (Formas_Emissao)Convert.ToInt32(row["Tipo_Emissao_NFe"]);
                tp_Ambiente = (Ambientes)Convert.ToInt32(row["Ambiente_NFe"]);
                sChave_Acesso = row["Chave_Acesso"].ToString();
                sNumero_Autorizacao = row["nfe_protocolo"].ToString();
                sTexto_Carta_Correcao = row["Texto_Carta_Correcao"].ToString();
                this.CNPJ = row["CNPJ"].ToString();
            }
        }
    }
}