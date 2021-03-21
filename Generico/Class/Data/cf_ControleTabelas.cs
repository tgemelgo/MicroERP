using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CompSoft.Data
{
    /// <summary>
    /// Controla bind das tabelas
    /// </summary>
    public class Controle_Tabelas
    {
        private string sNomeTabela = string.Empty;
        private string sSQLStatement = string.Empty;
        private TiposTabelas nTipotabela = TiposTabelas.Pai;
        private string sUltimaQuery = string.Empty;
        private string sPrimary_Keys = string.Empty;
        private bool bUsar_FK_Automatica = true;

        /// <summary>
        /// Identifica o tipo de tabela, Pai ou filha.
        /// </summary>
        public enum TiposTabelas
        {
            Pai,
            Filha
        }

        /// <summary>
        /// Permite utilizar a FK_Automaticamente.
        /// </summary>
        public bool Usar_FK_Automaticamente
        {
            get { return bUsar_FK_Automatica; }
            set { bUsar_FK_Automatica = value; }
        }

        /// <summary>
        /// Altera ou retorna o tipo de tabela
        /// </summary>
        public TiposTabelas TipoTabela
        {
            get { return nTipotabela; }
            set { nTipotabela = value; }
        }

        /// <summary>
        /// Altera ou retorna o nome da tabela.
        /// </summary>
        public string NomeTabela
        {
            get { return sNomeTabela.ToLower(); }
            set { sNomeTabela = value.ToLower(); }
        }

        /// <summary>
        /// Query que trará os dados.
        /// </summary>
        public string SQLStatement
        {
            get { return sSQLStatement; }
            set { sSQLStatement = value; }
        }

        /// <summary>
        /// Ultima query que foi executada.
        /// </summary>
        public string Ultima_Query
        {
            get { return sUltimaQuery; }
            set { sUltimaQuery = value; }
        }

        /// <summary>
        /// Identifica as Primary Keys da tabela.
        /// </summary>
        public string Primary_Keys
        {
            get { return sPrimary_Keys; }
            set { sPrimary_Keys = value; }
        }

        /// <summary>
        /// Construtor sem parametros.
        /// </summary>
        public Controle_Tabelas() { }

        /// <summary>
        /// Cria objeto com valores para vinculo no dataset.
        /// </summary>
        /// <param name="Tp_Tabela">Tipo da tabela.</param>
        /// <param name="NomeTabela">Nome da tabela no DataSet</param>
        /// <param name="SQLStatement">Query padrão para execução</param>
        public Controle_Tabelas(TiposTabelas Tp_Tabela, string NomeTabela, string SQLStatement)
        {
            sNomeTabela = NomeTabela;
            sSQLStatement = SQLStatement;
            nTipotabela = Tp_Tabela;
        }

        /// <summary>
        /// Cria objeto com valores para vinculo no dataset.
        /// </summary>
        /// <param name="Tp_Tabela">Tipo da tabela.</param>
        /// <param name="NomeTabela">Nome da tabela no DataSet</param>
        /// <param name="SQLStatement">Query padrão para execução</param>
        /// <param name="PrimaryKey">Identifica as colunas que estão presentes na query</param>
        public Controle_Tabelas(TiposTabelas Tp_Tabela, string NomeTabela, string SQLStatement, string PrimaryKey)
        {
            sNomeTabela = NomeTabela;
            sSQLStatement = SQLStatement;
            nTipotabela = Tp_Tabela;
            sPrimary_Keys = PrimaryKey;
        }

        /// <summary>
        /// Cria objeto com valores para vinculo no dataset.
        /// </summary>
        /// <param name="Tp_Tabela">Tipo da tabela.</param>
        /// <param name="NomeTabela">Nome da tabela no DataSet</param>
        /// <param name="SQLStatement">Query padrão para execução</param>
        /// <param name="PrimaryKey">Identifica as colunas que estão presentes na query</param>
        /// <param name="bUsar_FK_Automaticamente">Identifica se é possivel utilizar a FK automaticamente para vincular Filhas</param>
        public Controle_Tabelas(TiposTabelas Tp_Tabela, string NomeTabela, string SQLStatement, string PrimaryKey, bool bUsar_FK_Automaticamente)
        {
            sNomeTabela = NomeTabela;
            sSQLStatement = SQLStatement;
            nTipotabela = Tp_Tabela;
            sPrimary_Keys = PrimaryKey;
            bUsar_FK_Automatica = bUsar_FK_Automaticamente;
        }

        /// <summary>
        /// Carrega as PK´s customizadas do DataTable.
        /// </summary>
        /// <param name="dt">Datatable que deverá ser atualizado com a PrimaryKey</param>
        /// <param name="sPrimaryKey">String com colunas que são as PrimaryKeys (cada coluna separar por virgula ",")</param>
        internal static void Set_PKs(ref DataTable dt, string sPrimaryKey)
        {
            //-- Caso exista PK o sistema desconsidera.
            dt.PrimaryKey = null;

            //-- Caracter que separa as colunas.
            char[] cCaracter = new char[] { Convert.ToChar(",") };

            //-- Separa itens em linhas.
            string[] sPKs = sPrimaryKey.Split(cCaracter, StringSplitOptions.RemoveEmptyEntries);

            //-- Define o tamanho do array que contemplara a PrimaryKey
            DataColumn[] dc = new DataColumn[sPKs.Length];

            //-- Loop para inclusão das colunas no array.
            for (int i = 0; i < sPKs.Length; i++)
                dc[i] = dt.Columns[sPKs[i].Trim()];

            //-- Seta quais as colunas que contemplaram a PK
            dt.PrimaryKey = dc;
        }
    }
}