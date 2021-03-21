using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Data;

namespace ERP.Class
{
    internal class clsControleEstoque
    {
        #region Propriedades da classe.

        /// <summary>
        /// Verifica se o sistema está configurado para estoque por empresa ou geral.
        /// </summary>
        public static bool Estoque_por_empresa
        {
            get
            {
                Funcoes func;
                return Convert.ToBoolean(func.Busca_Propriedade("Estoque_por_empresa"));
            }
        }

        /// <summary>
        /// Identifica que a baixa do estoque será realizada manualmente.
        /// </summary>
        public static bool Baixa_estoque_manual
        {
            get
            {
                Funcoes func;
                return Convert.ToBoolean(func.Busca_Propriedade("Baixa_manual_estoque"));
            }
        }

        #endregion Propriedades da classe.

        #region Enum's

        public enum Tipo_Movimento_Estoque
        {
            Entrada = 1,
            Saida = 2
        }

        #endregion Enum's

        #region Métodos

        /// <summary>
        /// Verifica se existe o item no estoque para a empresa
        /// Em caso negativo insere novo item
        /// </summary>
        /// <param name="iEmpresa"></param>
        /// <param name="iCodigoproduto"></param>
        /// <returns>True/False se o processo foi realizado com sucesso</returns>
        public bool Existe_Item_Estoque(int iEmpresa, int iCodigoproduto)
        {
            string sQuery = string.Empty;
            int iQtde = 0;
            bool bReturn = false;

            if (Estoque_por_empresa)
            {
                sQuery = "SELECT COUNT(Estoque) FROM estoques WHERE empresa = {0} AND produto = {1}";
                sQuery = string.Format(sQuery
                    , iEmpresa
                    , iCodigoproduto);
            }
            else
            {
                sQuery = "SELECT COUNT(Estoque) FROM estoques WHERE empresa is null AND produto = {0}";
                sQuery = string.Format(sQuery
                    , iCodigoproduto);
            }

            Object oValor = SQL.ExecuteScalar(sQuery);
            if (oValor != DBNull.Value)
                iQtde = Convert.ToInt32(oValor);

            //-- Caso não exista insere novo item
            if (iQtde <= 0)
                bReturn = Inclusao_Item_Estoque(iEmpresa, iCodigoproduto);
            else
                bReturn = true;

            return bReturn;
        }

        /// <summary>
        /// Insere item no estoque
        /// Usado na inclusao de movimento estoque
        /// </summary>
        /// <param name="iEmpresa"></param>
        /// <param name="iCodigoproduto"></param>
        /// <returns>True/False se o processo foi realizado com sucesso</returns>
        private bool Inclusao_Item_Estoque(int iEmpresa, int iCodigoproduto)
        {
            string sQuery = string.Empty;

            sQuery = "INSERT INTO estoques (Empresa, Produto, Quantidade_Disponivel, Quantidade_Reservada, Quantidade_Total) values({0},{1},0,0,0)";
            if (Estoque_por_empresa)
            {
                sQuery = string.Format(sQuery
                    , iEmpresa
                    , iCodigoproduto);
            }
            else
            {
                sQuery = string.Format(sQuery
                        , "Null"
                        , iCodigoproduto);
            }

            return SQL.Execute(sQuery);
        }

        /// <summary>
        /// Se for entrada insere qtde no estoque disponivel
        /// Se for saida retira qtde do estoque disponivel
        /// Usado na inclusao de item de movimento estoque
        /// </summary>
        /// <param name="iEmpresa"></param>
        /// <param name="iCodigoproduto"></param>
        /// <param name="iQuantidade"></param>
        /// <param name="iTipoMovimentoEstoque"></param>
        /// <returns>True/False se o processo foi realizado com sucesso</returns>
        public bool Inclusao_Item_Movimento_Estoque(int iEmpresa, int iCodigoproduto, int iQuantidade, int iTipoMovimentoEstoque)
        {
            bool bReturn = true;
            string sQuery = string.Empty;

            //-- Testa se existe o item na tabela estoque
            this.Existe_Item_Estoque(iEmpresa, iCodigoproduto);

            sQuery = "SELECT quantidade_disponivel FROM estoques ";
            sQuery += "WHERE empresa {0} AND produto = {1}";
            if (Estoque_por_empresa)
            {
                sQuery = string.Format(sQuery
                    , " = " + iEmpresa.ToString()
                    , iCodigoproduto);
            }
            else
            {
                sQuery = string.Format(sQuery
                    , " is null "
                    , iCodigoproduto);
            }

            DataRow[] datarowEstoque = SQL.Select(sQuery, "x", false).Select();
            foreach (DataRow dr in datarowEstoque)
            {
                sQuery = string.Empty;

                if (iTipoMovimentoEstoque == (int)Tipo_Movimento_Estoque.Entrada)
                {
                    sQuery = "update estoques set Quantidade_disponivel = Quantidade_disponivel + {2} ";
                    sQuery += " where empresa {0} and produto = {1}";
                    if (Estoque_por_empresa)
                    {
                        sQuery = string.Format(sQuery
                            , " = " + iEmpresa.ToString()
                            , iCodigoproduto
                            , iQuantidade);
                    }
                    else
                    {
                        sQuery = string.Format(sQuery
                            , " is null "
                            , iCodigoproduto
                            , iQuantidade);
                    }

                    bReturn = SQL.Execute(sQuery);
                }
                else
                {
                    //-- Se houver quantidade em estoque
                    if (Convert.ToInt32(dr["quantidade_disponivel"]) >= iQuantidade)
                    {
                        sQuery = "update estoques set Quantidade_disponivel = Quantidade_disponivel - {2} ";
                        sQuery += " where empresa {0} and produto = {1}";
                        if (Estoque_por_empresa)
                        {
                            sQuery = string.Format(sQuery
                                , " = " + iEmpresa.ToString()
                                , iCodigoproduto
                                , iQuantidade);
                        }
                        else
                        {
                            sQuery = string.Format(sQuery
                                , " is NULL "
                                , iCodigoproduto
                                , iQuantidade);
                        }

                        bReturn = SQL.Execute(sQuery);
                    }
                }
            }
            return bReturn;
        }

        /// <summary>
        /// Retira qtde do estoque disponivel
        /// Insere qtde no estoque reservado
        /// Usado na inclusao de item de pedido
        /// </summary>
        /// <param name="iEmpresa"></param>
        /// <param name="iCodigoproduto"></param>
        /// <param name="iQuantidade"></param>
        /// <returns>True/False se o processo foi realizado com sucesso</returns>
        public bool Inclusao_Item_Pedido(int iEmpresa, int iCodigoproduto, int iQuantidade)
        {
            bool bReturn = true;
            string sQuery = string.Empty;

            //-- Testa se existe o item na tabela estoque
            Existe_Item_Estoque(iEmpresa, iCodigoproduto);

            sQuery += "update estoques set Quantidade_disponivel = Quantidade_disponivel - {2}, ";
            sQuery += "     quantidade_Reservada = Quantidade_Reservada + {2}";
            sQuery += " where empresa {0} and produto = {1}";

            if (Estoque_por_empresa)
            {
                sQuery = string.Format(sQuery
                    , " = " + iEmpresa.ToString()
                    , iCodigoproduto
                    , iQuantidade);
            }
            else
            {
                sQuery = string.Format(sQuery
                        , " is NULL "
                        , iCodigoproduto
                        , iQuantidade);
            }

            bReturn = SQL.Execute(sQuery);

            return bReturn;
        }

        /// <summary>
        /// Retira qtde do estoque reservado
        /// Usado na inclusao de item de nota fiscal
        /// </summary>
        /// <param name="iEmpresa"></param>
        /// <param name="iCodigoproduto"></param>
        /// <param name="iQuantidade"></param>
        /// <returns>True/False se o processo foi realizado com sucesso</returns>
        public bool Inclusao_Item_Nota_Fiscal(int iEmpresa, int iCodigoproduto, int iQuantidade)
        {
            bool bReturn = true;
            string sQuery = string.Empty;

            //-- Testa se existe o item na tabela estoque
            Existe_Item_Estoque(iEmpresa, iCodigoproduto);

            sQuery = "SELECT quantidade_reservada FROM estoques ";
            sQuery += "WHERE empresa {0} AND produto = {1}";

            if (Estoque_por_empresa)
            {
                sQuery = string.Format(sQuery
                    , " = " + iEmpresa.ToString()
                    , iCodigoproduto);
            }
            else
            {
                sQuery = string.Format(sQuery
                    , " is NULL "
                    , iCodigoproduto);
            }

            DataRow[] datarowEstoque = SQL.Select(sQuery, "", false).Select();
            foreach (DataRow dr in datarowEstoque)
            {
                //-- Se houver quantidade reservada
                if (Convert.ToInt32(dr["quantidade_reservada"]) >= iQuantidade)
                {
                    sQuery = string.Empty;

                    sQuery = "update estoques set quantidade_reservada = quantidade_reservada - {2} ";
                    sQuery += "WHERE empresa {0} AND produto = {1}";

                    if (Estoque_por_empresa)
                    {
                        sQuery = string.Format(sQuery
                            , " = " + iEmpresa.ToString()
                            , iCodigoproduto
                            , iQuantidade);
                    }
                    else
                    {
                        sQuery = string.Format(sQuery
                            , " is NULL "
                            , iCodigoproduto
                            , iQuantidade);
                    }
                }

                bReturn = SQL.Execute(sQuery);
            }
            return bReturn;
        }

        /// <summary>
        /// Marca a nota fiscal como estoque baixado.
        /// </summary>
        /// <param name="iCodigo_NF">Primary key da tabela notas fiscais</param>
        public void Marca_Nota_Fiscal_Baixada(int iCodigo_NF)
        {
            string sSQL = string.Empty;
            sSQL += "update Notas_Fiscais set Estoque_Baixado = 1 where nota_fiscal = {0}";
            sSQL = string.Format(sSQL, iCodigo_NF);

            SQL.Execute(sSQL);
        }

        /// <summary>
        /// Verifica se há estoque disponivel para o item
        /// </summary>
        /// <param name="iEmpresa">a</param>
        /// <param name="iCodigoproduto">b</param>
        /// <param name="iQtde">c</param>
        /// <returns>True/False se há estoque disponivel para o item</returns>
        public bool Verifica_Estoque_Disponivel_Item(int iEmpresa, int iCodigoproduto, int iQtde)
        {
            int iQtdeEstoque = 0;

            string sSQL = string.Empty;
            sSQL += "select quantidade_disponivel from estoques ";
            sSQL += " where empresa {0}";
            sSQL += "  and produto = {1}";

            if (Estoque_por_empresa)
            {
                sSQL = string.Format(sSQL
                    , " = " + iEmpresa.ToString()
                    , iCodigoproduto);
            }
            else
            {
                sSQL = string.Format(sSQL
                    , " is NULL "
                    , iCodigoproduto);
            }

            object oValor = SQL.ExecuteScalar(sSQL);
            if (oValor != DBNull.Value)
                iQtdeEstoque = Convert.ToInt32(oValor);

            return (iQtdeEstoque >= iQtde);
        }

        /// <summary>
        /// Retira qtde do estoque reservado
        /// Insere qtde no estoque disponivel
        /// Usado no cancelamento de pedido
        /// </summary>
        /// <param name="iEmpresa"></param>
        /// <param name="iCodigoproduto"></param>
        /// <param name="iQuantidade"></param>
        /// <returns>True/False se o processo foi realizado com sucesso</returns>
        public bool Cancelamento_Item_Pedido(int iEmpresa, int iCodigoproduto, int iQuantidade)
        {
            bool bReturn = true;
            string sQuery = string.Empty;

            //-- Testa se existe o item na tabela estoque
            Existe_Item_Estoque(iEmpresa, iCodigoproduto);

            sQuery = "SELECT quantidade_disponivel, quantidade_reservada FROM estoques ";
            sQuery += "WHERE empresa {0} AND produto = {1}";

            if (Estoque_por_empresa)
            {
                sQuery = string.Format(sQuery
                    , " = " + iEmpresa.ToString()
                    , iCodigoproduto);
            }
            else
            {
                sQuery = string.Format(sQuery
                    , " is NULL "
                    , iCodigoproduto);
            }

            DataRow[] datarowEstoque = SQL.Select(sQuery, "", false).Select("", "");
            foreach (DataRow dr in datarowEstoque)
            {
                //-- Se houver quantidade em estoque
                if (Convert.ToInt32(dr["quantidade_reservada"]) >= iQuantidade)
                {
                    sQuery = string.Empty;

                    sQuery += "update estoques set Quantidade_disponivel = Quantidade_disponivel + {2}, ";
                    sQuery += "     quantidade_Reservada = Quantidade_Reservada - {2}";
                    sQuery += " where empresa {0} and produto = {1}";

                    if (Estoque_por_empresa)
                    {
                        sQuery = string.Format(sQuery
                            , " = " + iEmpresa.ToString()
                            , iCodigoproduto
                            , iQuantidade);
                    }
                    else
                    {
                        sQuery = string.Format(sQuery
                                , " is NULL "
                                , iCodigoproduto
                                , iQuantidade);
                    }
                    bReturn = SQL.Execute(sQuery);
                }
                else
                {
                    bReturn = false;
                }
            }
            return bReturn;
        }

        /// <summary>
        /// Insere qtde no estoque disponivel
        /// Usado no cancelamento de item de nota fiscal
        /// </summary>
        /// <param name="iEmpresa"></param>
        /// <param name="iCodigoproduto"></param>
        /// <param name="iQuantidade"></param>
        /// <returns>True/False se o processo foi realizado com sucesso</returns>
        public bool Cancelamento_Item_Nota_Fiscal(int iEmpresa, int iCodigoproduto, int iQuantidade)
        {
            bool bReturn = true;
            string sQuery = string.Empty;

            //-- Testa se existe o item na tabela estoque
            Existe_Item_Estoque(iEmpresa, iCodigoproduto);

            sQuery = string.Empty;

            sQuery += "UPDATE estoques SET Quantidade_disponivel = Quantidade_disponivel + {2} ";
            sQuery += " WHERE empresa {0} AND produto = {1}";

            if (Estoque_por_empresa)
            {
                sQuery = string.Format(sQuery
                    , " = " + iEmpresa.ToString()
                    , iCodigoproduto
                    , iQuantidade);
            }
            else
            {
                sQuery = string.Format(sQuery
                    , " is NULL "
                    , iCodigoproduto
                    , iQuantidade);
            }

            bReturn = SQL.Execute(sQuery);

            return bReturn;
        }

        /// <summary>
        /// Gravacao de movimento estoque
        /// </summary>
        /// <param name="iTipo"></param>
        /// <param name="iEmpresa"></param>
        /// <param name="iCliente"></param>
        /// <param name="sNumeroDocumento"></param>
        /// <param name="sDescricao"></param>
        /// <param name="dtDia"></param>
        /// <param name="dValorTotal"></param>
        /// <returns>Codigo do movimento estoque que deve ser utilizado na inclusao de itens</returns>
        public int Registra_Movimento_Estoque(int iTipo, int iEmpresa, int iCliente,
                                              string sNumeroDocumento, string sDescricao,
                                              DateTime dtDia, decimal dValorTotal)
        {
            int iCodigoMovimento = 0;
            string sQuery = string.Empty;
            bool bReturn = false;
            string sData = dtDia.Year.ToString()
                + dtDia.Month.ToString().PadLeft(2, Convert.ToChar("0"))
                + dtDia.Day.ToString().PadLeft(2, Convert.ToChar("0"));

            sQuery = "INSERT INTO movimentos_estoque (Tipo_Movimento_Estoque, Empresa, Cliente, Numero_Documento, Descricao, Data_Movimento, Valor_Total) values({0},{1},{2},'{3}','{4}','{5}',{6})";
            sQuery = string.Format(System.Globalization.CultureInfo.GetCultureInfo("en-us")
                , sQuery
                , iTipo
                , iEmpresa
                , iCliente
                , sNumeroDocumento
                , sDescricao
                , sData
                , dValorTotal);

            bReturn = SQL.Execute(sQuery, true);

            if (bReturn)
            {
                object oValor = SQL.ExecuteScalar("SELECT @@IDENTITY", false);
                if (oValor != DBNull.Value)
                    iCodigoMovimento = Convert.ToInt32(oValor);
            }

            return iCodigoMovimento; //retona o codigo do movimento (IDENTITY)
        }

        /// <summary>
        /// Gravacao de item de movimento estoque
        /// </summary>
        /// <param name="iCodigoEstoque"> Retorno do metodo Registra_Movimento_Estoque</param>
        /// <param name="iProduto"></param>
        /// <param name="dValorUnitario"></param>
        /// <param name="iQuantidade"></param>
        /// <param name="dValorTotal"></param>
        /// <returns></returns>
        public bool Registra_Movimento_Estoque_Item(int iCodigoEstoque, int iProduto, decimal dValorUnitario,
                                                    int iQuantidade, decimal dValorTotal)
        {
            string sQuery = string.Empty;
            bool bReturn = false;

            sQuery = "INSERT INTO Movimentos_Estoque_Itens (Movimento_Estoque, Produto, Valor_Unitario, Quantidade, Valor_Total) values({0}, {1}, {2}, {3}, {4})";

            sQuery = string.Format(System.Globalization.CultureInfo.GetCultureInfo("en-us")
                , sQuery
                , iCodigoEstoque
                , iProduto
                , dValorUnitario
                , iQuantidade
                , dValorTotal);

            bReturn = SQL.Execute(sQuery);

            return bReturn;
        }

        #endregion Métodos
    }
}