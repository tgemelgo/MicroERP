using CompSoft.compFrameWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CompSoft.Data
{
    /// <summary>
    /// Controla toda parte de conexão com o banco de dados e todos os comandos SQL Executados.
    /// </summary>
    public class SQL
    {
        private static SqlConnection db = new SqlConnection(Propriedades.StringConexao);
        private static bool bContinua_Conectado = false;

        #region Propriedade

        /// <summary>
        /// true/false Continua conectado no banco de dados.
        /// </summary>
        public static bool Continuar_Conectado
        {
            get { return bContinua_Conectado; }
            set { bContinua_Conectado = value; }
        }

        #endregion Propriedade

        #region Abrir conexão

        /// <summary>
        /// Abre a conexão com banco de dados
        /// </summary>
        private static void Abrir_Conexao()
        {
            try
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(Propriedades.StringConexao);
                sb.Pooling = true;
                sb.MinPoolSize = 1;
                sb.ApplicationName = Propriedades.TituloMain;
                sb.WorkstationID = System.Environment.MachineName;
                db.ConnectionString = sb.ConnectionString;
                db.Open();
            }
            catch
            {
                MsgBox.Show("Não foi possivel conectar na base de dados, contate o administrador."
                    , "Erro"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Fecha a conexão com o banco de dados.
        /// </summary>
        public static void Fechar_Conexao()
        {
            try
            {
                if (db != null && db.State == ConnectionState.Open)
                    db.Close();
            }
            catch
            {
                MsgBox.Show("Não foi possivel conectar na base de dados, contate o administrador."
                            , "Erro"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
            }
        }

        #endregion Abrir conexão

        #region Select

        #region Sobrecarga, possibilita deixar a conexão aberta. DATA.Select

        /// <summary>
        /// Executa o comando com o retorno de um datatable.
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <param name="NomeTabela">Nome do datatable</param>
        /// <param name="ApenasEstrutura">Se retorna apenas a estrutura da tabela.</param>
        /// <param name="ContinuaConectado">Continua conectado.</param>
        /// <returns>DataTable com a estrutra e dados.</returns>
        public static DataTable Select(string SQLStatement, string NomeTabela, bool ApenasEstrutura, bool ContinuaConectado)
        {
            bContinua_Conectado = ContinuaConectado;
            return Select(SQLStatement, NomeTabela, ApenasEstrutura);
        }

        #endregion Sobrecarga, possibilita deixar a conexão aberta. DATA.Select

        #region Select e retorna DataTable

        /// <summary>
        /// Executa o query e retorna os valores.
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <param name="NomeTabela">Nome do datatable</param>
        /// <param name="ApenasEstrutura">true/false Para retornar apenas a estrutura</param>
        /// <returns>DataTable com dados e estrutura</returns>
        public static DataTable Select(string SQLStatement, string NomeTabela, bool ApenasEstrutura)
        {
            //-- Instancia a classe de dataset
            DataTable dt = new DataTable(NomeTabela);

            try
            {
                //-- Abre a conexão com o banco de dados
                if (db.State != ConnectionState.Open)
                    Abrir_Conexao();

                //-- Executa o command SQL
                SqlDataAdapter da = new SqlDataAdapter(SQLStatement, db);

                //-- Alimenta o DataTable
                dt.BeginLoadData();

                da.FillLoadOption = LoadOption.OverwriteChanges;
                da.FillSchema(dt, SchemaType.Source);
                if (!ApenasEstrutura)
                    da.Fill(dt);

                dt.EndLoadData();

                //-- Gera o retorno Final
                return dt;
            }
            catch //-- (Exception ex)
            {
                /*MessageBox.Show("Erro ao executar query.\r\n" + ex.Message
                    , "Erro"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);*/

                return null;
            }
            finally
            {
                if (!bContinua_Conectado)
                    db.Close();
            }
        }

        #endregion Select e retorna DataTable

        #endregion Select

        #region Execute

        #region Execute

        /// <summary>
        /// Executa comandos SQL
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <returns>true/false para saber se o comando foi executado.</returns>
        public static bool Execute(string SQLStatement)
        {
            try
            {
                //-- Executa o command SQL
                SqlCommand cm = new SqlCommand(SQLStatement, db);

                //-- Abre a conexão com o banco de dados
                if (db.State != ConnectionState.Open)
                    Abrir_Conexao();

                //-- executa o comando no servidor.
                cm.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Show("Erro ao executar query.\r\n" + ex.Message
                    , "Erro"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                if (!bContinua_Conectado)
                    db.Close();
            }
        }

        #endregion Execute

        #region Execute com parametros

        /// <summary>
        /// Executa comandos SQL
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <returns>true/false para saber se o comando foi executado.</returns>
        public static bool Execute(string SQLStatement, IList<SqlParameter> parameter)
        {
            try
            {
                //-- Executa o command SQL
                SqlCommand cm = new SqlCommand(SQLStatement, db);

                //-- Abre a conexão com o banco de dados
                if (db.State != ConnectionState.Open)
                    Abrir_Conexao();

                //-- Seta todos os parametros.
                foreach (SqlParameter p in parameter)
                    cm.Parameters.Add(p);

                //-- executa o comando no servidor.
                cm.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Show("Erro ao executar query.\r\n" + ex.Message
                    , "Erro"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                if (!bContinua_Conectado)
                    db.Close();
            }
        }

        #endregion Execute com parametros

        #region ExecuteNonQuery

        /// <summary>
        /// Executa comandos SQL e retorna a quantidade de linhas afetadas.
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <returns>true/false para saber se o comando foi executado.</returns>
        public static int ExecuteNonQuery(string SQLStatement)
        {
            try
            {
                //-- Executa o command SQL
                SqlCommand cm = new SqlCommand(SQLStatement, db);

                //-- Abre a conexão com o banco de dados
                if (db.State != ConnectionState.Open)
                    Abrir_Conexao();

                //-- executa o comando no servidor e retorna a quantidade de linhas
                return cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MsgBox.Show("Erro ao executar query.\r\n" + ex.Message
                    , "Erro"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                return -1;
            }
            finally
            {
                if (!bContinua_Conectado)
                    db.Close();
            }
        }

        #endregion ExecuteNonQuery

        #region ExecuteScalar

        /// <summary>
        /// Executa comandos SQL e retorna a primeira coluna da primeira linha.
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <returns>INT indicando a primeira linha do primeiro registro pesquisado.</returns>
        public static object ExecuteScalar(string SQLStatement)
        {
            object oValor = new object();

            try
            {
                //-- Executa o command SQL
                SqlCommand cm = new SqlCommand(SQLStatement, db);

                //-- Abre a conexão com o banco de dados
                if (db.State != ConnectionState.Open)
                    Abrir_Conexao();

                //-- executa o comando no servidor.
                oValor = cm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MsgBox.Show("Erro ao executar query.\r\n" + ex.Message
                    , "Erro"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
            finally
            {
                if (!bContinua_Conectado)
                    db.Close();
            }

            return oValor;
        }

        #endregion ExecuteScalar

        #region Sobrecarga, possibilita deixar a conexão aberta. DATA.Execute

        /// <summary>
        /// Executa o comando SQL e permanece conectado, caso seja do interesse.
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <param name="ContinuaConectado">true/false para permanecer conectado.</param>
        /// <returns>true/false Se o comando for executado com sucesso.</returns>
        public static bool Execute(string SQLStatement, bool ContinuaConectado)
        {
            bContinua_Conectado = ContinuaConectado;
            return Execute(SQLStatement);
        }

        /// <summary>
        /// Executa o comando SQL e permanece conectado, caso seja do interesse.
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <param name="ContinuaConectado">true/false para permanecer conectado.</param>
        /// <returns>true/false Se o comando for executado com sucesso.</returns>
        public static bool Execute(string SQLStatement, IList<SqlParameter> parameter, bool ContinuaConectado)
        {
            bContinua_Conectado = ContinuaConectado;
            return Execute(SQLStatement, parameter);
        }

        /// <summary>
        /// Executa o comando SQL e permanece conectado, caso seja do interesse.
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <param name="ContinuaConectado">true/false para permanecer conectado.</param>
        /// <returns>true/false Se o comando for executado com sucesso.</returns>
        public static object ExecuteScalar(string SQLStatement, bool ContinuaConectado)
        {
            bContinua_Conectado = ContinuaConectado;
            return ExecuteScalar(SQLStatement);
        }

        /// <summary>
        /// Executa o comando SQL e permanece conectado, caso seja do interesse.
        /// </summary>
        /// <param name="SQLStatement">Query</param>
        /// <param name="ContinuaConectado">true/false para permanecer conectado.</param>
        /// <returns>true/false Se o comando for executado com sucesso.</returns>
        public static int ExecuteNonQuery(string SQLStatement, bool ContinuaConectado)
        {
            bContinua_Conectado = ContinuaConectado;
            return ExecuteNonQuery(SQLStatement);
        }

        #endregion Sobrecarga, possibilita deixar a conexão aberta. DATA.Execute

        #endregion Execute
    }
}