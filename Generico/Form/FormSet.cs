using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CompSoft
{
    public partial class FormSet : formBase
    {
        #region Variaveis

        private string sMainTabela,
            sTituloForm = string.Empty;

        private TipoFormStatus iFormStatus = TipoFormStatus.Nenhum;
        private TipoFormStatus iOldFormStatus;

        private DataSet dtDataSetLocal = new DataSet();

        private Dictionary<string, BindingSource> dBindingSource = new Dictionary<string, BindingSource>();

        private IList<DS_PrimaryKey> iCodPrimaryKey = new List<DS_PrimaryKey>();
        private IList<Controle_Tabelas> iTabelas = new List<Controle_Tabelas>();

        //-- Variaveis que permite ativar ou não a barra de ferramentas.
        private bool bNovoRegistro = true,
            bEditarRegistro = true,
            bExcluirRegistro = true,
            bPesquisarRegistro = true,
            bLimparTela = true,
            bRelatorio = true;

        //-- Identifica o tipo de formulário.
        private TipoForm tpTipo_Formulario = TipoForm.Geral;

        #endregion Variaveis

        #region Propriedades

        /// <summary>
        /// Array com todas as tabelas filhas do formulário
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        public IList<Controle_Tabelas> Tabelas
        {
            get { return iTabelas; }
            set { iTabelas = value; }
        }

        [Category("CompSoft"), Browsable(false)]
        public DataRowView CurrentRow
        {
            get
            {
                if (this.BindingSource[sMainTabela].Position >= 0)
                    return (DataRowView)this.BindingSource[sMainTabela].Current;
                else
                    return null;
            }
        }

        /// <summary>
        /// Array com todas as primary keys que a tebela MAIN tem.
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        internal IList<DS_PrimaryKey> PrimaryKeyMain
        {
            get { return iCodPrimaryKey; }
            set { iCodPrimaryKey = value; }
        }

        /// <summary>
        /// Informa o status anterior do formulário.
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        public TipoFormStatus OldFormStatus
        {
            get { return iOldFormStatus; }
        }

        /// <summary>
        /// Informa o status atual do formulário.
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        public TipoFormStatus FormStatus
        {
            get { return iFormStatus; }
            set
            {
                //-- faz Verificação caso seja status de modificação
                bool bRetorno = true;
                if (value == TipoFormStatus.Modificando)
                {
                    if (user_BeforeEdit != null)
                        bRetorno = this.user_BeforeEdit();
                }

                if (bRetorno)
                {
                    iOldFormStatus = iFormStatus; //-- Armazena o status para mudança

                    iFormStatus = value;

                    //-- Processo normal.
                    Funcoes func;
                    func.TratarStatus_BarraFerramentas(this.iFormStatus, this.tpTipo_Formulario);
                    ManipulaRegistros mr = new ManipulaRegistros();
                    mr.setarReadOnly_FormStatus(this.Controls, iFormStatus);

                    this.Text = sTituloForm + " - " + value.ToString();

                    //-- Evento que indica alteração de status.
                    if (user_FormStatus_Change != null)
                        this.user_FormStatus_Change();
                }
            }
        }

        /// <summary>
        /// DataSet Local armazena todas as querys executas dentro do form em suas tabelas.
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        public DataSet DataSetLocal
        {
            get { return dtDataSetLocal; }
            set { dtDataSetLocal = value; }
        }

        /// <summary>
        /// Organiza as fontes de dados (DataTable, DataView)
        /// </summary>
        [Category("CompSoft"), ToolboxItem(false), Browsable(false)]
        public Dictionary<string, BindingSource> BindingSource
        {
            get { return dBindingSource; }
            set { dBindingSource = value; }
        }

        /// <summary>
        /// Tabela principal da tela.
        /// </summary>
        [Category("CompSoft")]
        public string MainTabela
        {
            get { return string.IsNullOrEmpty(sMainTabela) ? sMainTabela : sMainTabela.ToLower(); }
            set { sMainTabela = string.IsNullOrEmpty(value) ? value : value.ToLower(); }
        }

        /// <summary>
        /// Permite ativar botão de novo registro na barra de ferramentas neste formulário
        /// </summary>
        [Category("CompSoft")]
        public bool Barra_Ferramentas_Novo_Registro
        {
            get { return bNovoRegistro; }
            set { bNovoRegistro = value; }
        }

        /// <summary>
        /// Permite ativar botão de editar registro na barra de ferramentas neste formulário
        /// </summary>
        [Category("CompSoft")]
        public bool Barra_Ferramentas_Editar_Registro
        {
            get { return bEditarRegistro; }
            set { bEditarRegistro = value; }
        }

        /// <summary>
        /// Permite ativar botão de excluir registro na barra de ferramentas neste formulário
        /// </summary>
        [Category("CompSoft")]
        public bool Barra_Ferramentas_Excluir_Registro
        {
            get { return bExcluirRegistro; }
            set { bExcluirRegistro = value; }
        }

        /// <summary>
        /// Permite ativar botão de pesquisar registro na barra de ferramentas neste formulário
        /// </summary>
        [Category("CompSoft")]
        public bool Barra_Ferramentas_Pesquisar_Registro
        {
            get { return bPesquisarRegistro; }
            set { bPesquisarRegistro = value; }
        }

        /// <summary>
        /// Permite ativar botão de limpar registro na barra de ferramentas neste formulário
        /// </summary>
        [Category("CompSoft")]
        public bool Barra_Ferramentas_Limpar_Tela
        {
            get { return bLimparTela; }
            set { bLimparTela = value; }
        }

        /// <summary>
        /// Permite ativar botão de relatórios na barra de ferramentas neste formulário
        /// </summary>
        [Category("CompSoft")]
        public bool Barra_Ferramentas_Relatorios
        {
            get { return bRelatorio; }
            set { bRelatorio = value; }
        }

        /// <summary>
        /// Identifica o tipo de formulário.
        /// </summary>
        [Category("CompSoft")]
        public TipoForm Tipo_Formulario
        {
            get { return tpTipo_Formulario; }
            set { tpTipo_Formulario = value; }
        }

        #endregion Propriedades

        #region Manipulação com o banco de dados

        #region Pesquisa

        #region Realiza a pesquisa no banco de dados.

        /// <summary>
        /// Realiza a pesquisa no banco de dados
        /// </summary>
        /// <returns>true/false - Retorna se foi encontrado algum registro ou se a pesquisa foi realizada.</returns>
        public virtual bool PesquisarDados()
        {
            bool bRetorno = false;

            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, efetuando pesquisa no banco de dados...");
            try
            {
                bool bRetorno_Before = true;
                if (this.user_BeforeSearch != null)
                    bRetorno_Before = this.user_BeforeSearch();

                if (!string.IsNullOrEmpty(sMainTabela) && iTabelas.Count > 0 && bRetorno_Before)
                {
                    //-- Alimenta todas as tabelas selecionadas.
                    if (!this.AlimentarTabelas_Pai())
                    {
                        MsgBox.Show("Nenhum registro foi localizado com este filtro."
                            , "Aviso"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);

                        this.FormStatus = TipoFormStatus.Limpar;
                    }
                    else
                    {
                        f.Mensagem = "Aguarde, efetuando pesquisa dos registros auxiliares...";

                        //-- Seta a PK da tabela Main.
                        int iPosition = dBindingSource[sMainTabela].Position;
                        this.PrimaryKey_Main(dtDataSetLocal.Tables[sMainTabela].Rows[iPosition]);

                        //-- Carrega dados das tabelas filhas.
                        this.AlimentarTabelas_Filha();

                        //-- Seta os total de registros.
                        this.TotalRegistros(MostrarTotalRegistros.Contagem_Atual);

                        bRetorno = true;
                    }
                }
                else
                {
                    MsgBox.Show("Nenhuma tabela foi identificada como referencia para o sistema, inclua os parametros no construtor do formulário."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                }

                if (bRetorno && this.user_AfterSearch != null)
                    this.user_AfterSearch();

                if (bRetorno && this.user_AfterRefreshData != null)
                    this.user_AfterRefreshData();
            }
            catch { }
            finally
            {
                f.Close();

                //-- Atualiza Barra de ferramentas.
                if (this.MdiParent != null)
                {
                    Funcoes func;
                    func.TratarStatus_BarraFerramentas(iFormStatus, tpTipo_Formulario);
                }
            }

            return bRetorno;
        }

        #endregion Realiza a pesquisa no banco de dados.

        #region Atualiza apenas o registro selecionado.

        /// <summary>
        /// Realiza a pesquisa no banco de dados com as informações da ultima query
        /// </summary>
        /// <returns>Retorna se foi encontrado algum registro ou se a pesquisa foi realizada.</returns>
        public bool Atualizar_Query_Atual()
        {
            bool bRetorno = false;

            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, efetuando pesquisa no banco de dados...");
            try
            {
                if (sMainTabela != string.Empty && iTabelas.Count > 0)
                {
                    //-- Alimenta todas as tabelas selecionadas.
                    if (!this.AlimentarTabelas_Pai_Requery())
                    {
                        MsgBox.Show("Nenhum registro foi localizado com este filtro."
                            , "Aviso"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                        this.FormStatus = TipoFormStatus.Limpar;
                    }
                    else
                    {
                        f.Mensagem = "Aguarde, efetuando pesquisa dos registros auxiliares...";

                        //-- Seta a PK da tabela Main.
                        int iPosition = dBindingSource[sMainTabela].Position;
                        this.PrimaryKey_Main(dtDataSetLocal.Tables[sMainTabela].Rows[iPosition]);

                        //-- Carrega dados das tabelas filhas.
                        this.AlimentarTabelas_Filha();

                        //-- Seta os total de registros.
                        this.TotalRegistros(MostrarTotalRegistros.Contagem_Atual);
                    }
                }
                else
                {
                    CompSoft.compFrameWork.MsgBox.Show("Não foi possivel encontrar nenhuma tabela para ser criada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                bRetorno = true;
            }
            catch
            {
                bRetorno = false;
            }
            finally { f.Close(); }

            if (bRetorno && this.user_AfterSearch != null)
                this.user_AfterSearch();

            if (bRetorno && this.user_AfterRefreshData != null)
                this.user_AfterRefreshData();

            return bRetorno;
        }

        #endregion Atualiza apenas o registro selecionado.

        #region Movimenta registros

        /// <summary>
        /// Faz a movimentação do registros.
        /// </summary>
        /// <param name="tp_Movimento">Especifica o tipo de movimentação</param>
        internal void Movimentar_Registro(Movimento tp_Movimento)
        {
            switch (tp_Movimento)
            {
                case Movimento.Primeiro:
                    dBindingSource[sMainTabela].Position = 0;
                    break;

                case Movimento.Proximo:
                    dBindingSource[sMainTabela].Position += 1;
                    break;

                case Movimento.Voltar:
                    dBindingSource[sMainTabela].Position -= 1;
                    break;

                case Movimento.Ultimo:
                    dBindingSource[sMainTabela].Position = dBindingSource[sMainTabela].Count - 1;
                    break;

                case Movimento.Atualizar_Atual:
                    dBindingSource[sMainTabela].Position = dBindingSource[sMainTabela].Position;
                    break;
            }

            if (dBindingSource[sMainTabela].Position >= 0)
            {
                //-- Guarta o primary key da tabela.
                //int iPosition = dBindingSource[sMainTabela].Position;
                this.PrimaryKey_Main(this.CurrentRow.Row);

                //-- Atualiza tabela filha
                this.AlimentarTabelas_Filha();

                //-- Total registros
                this.TotalRegistros(MostrarTotalRegistros.Contagem_Atual);

                //-- chama evento
                if (user_AfterRefreshData != null)
                    this.user_AfterRefreshData();

                //-- Trata o status da barra de ferramentas de acordo com o movimento.
                Funcoes func;
                func.TratarStatus_BarraFerramentas(iFormStatus, tpTipo_Formulario);
            }
        }

        #endregion Movimenta registros

        #region Trabalha com a barra de ferramentas - Total de registros.

        /// <summary>
        /// Atualiza a contagem de registros e atualiza na barra de ferramentas.
        /// </summary>
        /// <param name="tp_Total">Especifica o tipo de contagem.</param>
        internal void TotalRegistros(MostrarTotalRegistros tp_Total)
        {
            int iRegAtual = 0,
                iRegTotal = 0;

            if (tp_Total == MostrarTotalRegistros.Contagem_Zerada)
            {
                Propriedades.FormMain.lblTotalRegistros.Caption = "# 0";
                Propriedades.FormMain.lblRegistroAtual.Caption = "# 0";
            }
            else
            {
                if (!string.IsNullOrEmpty(this.MainTabela) && dtDataSetLocal.Tables.Count > 0)
                {
                    iRegTotal = dtDataSetLocal.Tables[this.MainTabela].Rows.Count;

                    //-- Sistema em novo acrescenta um na contagem para contar o que está incluindo.
                    if (this.FormStatus == TipoFormStatus.Novo)
                        iRegTotal += 1;

                    iRegAtual = dBindingSource[sMainTabela].Position + 1;

                    Propriedades.FormMain.lblTotalRegistros.Caption = "# " + iRegTotal.ToString();
                    Propriedades.FormMain.lblRegistroAtual.Caption = "# " + iRegAtual.ToString();
                }
            }
        }

        #endregion Trabalha com a barra de ferramentas - Total de registros.

        #region Monta a estrutura das tabelas para o bind dos controles na tela.

        /// <summary>
        /// Monta a estrutura das tabelas para fazer o bind dos campos
        /// </summary>
        private void montaEstruturaDataSet()
        {
            foreach (Controle_Tabelas ct in this.Tabelas)
            {
                //-- Query para capturar o DataTable.
                DataTable dt = SQL.Select(ct.SQLStatement, ct.NomeTabela, true, true);

                //-- Adiciona o DataTable ao Dataset.
                dtDataSetLocal.Tables.Add(dt);

                //-- Adicionar o bindingSource
                dBindingSource.Add(ct.NomeTabela.ToLower(), new BindingSource(dt, null));

                if (!string.IsNullOrEmpty(ct.Primary_Keys))
                    Controle_Tabelas.Set_PKs(ref dt, ct.Primary_Keys);
            }

            //-- Fecha conexão com o banco de dados.
            SQL.Fechar_Conexao();
        }

        #endregion Monta a estrutura das tabelas para o bind dos controles na tela.

        #region Monta a estrutura de bind nos controles

        /// <summary>
        /// Faz a bindagem de todos os campos que possuirem tabela, controlsource
        /// </summary>
        private void AlimentarBind_Controles()
        {
            if (!string.IsNullOrEmpty(sMainTabela))
            {
                //--Seta todos os bind´s possiveis da tela.
                ManipulaRegistros mr = new ManipulaRegistros();
                mr.setarValores_Bind(this.Controls, this);
            }
            else
                MsgBox.Show("A tabela principal do formulário não foi preenchida. (Main_Tabela)"
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
        }

        #endregion Monta a estrutura de bind nos controles

        #region Monta as todas as condições possiveis de busca

        /// <summary>
        /// Monta as condições pata a query que está sendo preparada.
        /// </summary>
        /// <param name="TableActivate">Tipo de tabela que está sendo trabalhada.</param>
        /// <param name="ct">Classe controle de tabelas</param>
        /// <returns>Retorna o command pronto para ser executado.</returns>
        private string MontarCondicoes(string TableActivate, Controle_Tabelas ct)
        {
            string sWhere = string.Empty;

            //-- Trata apenas quando o tipo da tabela é pai.
            if (ct.TipoTabela == Controle_Tabelas.TiposTabelas.Pai)
            {
                ManipulaRegistros m = new ManipulaRegistros();
                //-- Rotina que faz o queryby dos campos.
                m.Condicoes_QueryBy = string.Empty;
                m.get_QueryBy(this.Controls, this.MainTabela);
                sWhere = m.Condicoes_QueryBy;
            }

            //-- Condições definidas pelo usuário.
            string sCondicao = this.user_Query(TableActivate);
            if (sCondicao != string.Empty)
            {
                if (sWhere != string.Empty)
                    sWhere += " AND " + sCondicao;
                else
                    sWhere = sCondicao;
            }

            //-- Executa apenas nas filhas
            if (ct.TipoTabela == Controle_Tabelas.TiposTabelas.Filha && ct.Usar_FK_Automaticamente)
            {
                //-- Monta o vinculo entra a tabela Pai(Main com as filhas)
                string sForeign = this.ForeignKey(TableActivate);
                if (sForeign != string.Empty)
                {
                    if (sWhere != string.Empty)
                        sWhere += " AND " + sForeign;
                    else
                        sWhere = sForeign;
                }
            }

            return sWhere;
        }

        #endregion Monta as todas as condições possiveis de busca

        #region Faz as foreign key para todas as filhas, automaticamente.

        /// <summary>
        /// Retorna a Foreign key da Tabela Main (Pai)
        /// </summary>
        internal string ForeignKey(string Tabela)
        {
            string sForeignKey = string.Empty;
            string sFormatString = "{0}.{1} = {2}";

            foreach (DS_PrimaryKey dt in this.PrimaryKeyMain)
            {
                if (sForeignKey != string.Empty)
                    sForeignKey += " AND ";

                StringBuilder sb = new StringBuilder();

                DataColumn dcc = this.DataSetLocal.Tables[Tabela].Columns[dt.PrimaryKey];

                //-- Define o tamanho maximo do controle.
                switch (dcc.DataType.Name.ToLower())
                {
                    case "string":
                        sb.Append("'");
                        sb.Append(dt.ValorPrimaryKey);
                        sb.Append("'");
                        break;

                    case "byte":  //-- Quando o campo for tinyint
                    case "int16":
                    case "int32":
                        sb.Append(dt.ValorPrimaryKey);
                        break;

                    case "datetime":
                        sb.Append("'");
                        sb.Append(dt.ValorPrimaryKey);
                        sb.Append("'");
                        break;
                }

                sForeignKey += string.Format(sFormatString
                    , Tabela
                    , dt.PrimaryKey
                    , sb.ToString());
            }

            return sForeignKey;
        }

        #endregion Faz as foreign key para todas as filhas, automaticamente.

        #region Adiciona tabelas ao DataSet

        /// <summary>
        /// Adicona tabela no dataset local, caso já exista ele a substituirá.
        /// </summary>
        /// <param name="dt">Tabela retornada no do select.</param>
        /// <returns>Execução com sucesso.</returns>
        public bool Adicionar_DataSet(ref DataTable dt)
        {
            bool bRetorno = false;

            try
            {
                //-- Verifica se a tabela já existe.
                if (dtDataSetLocal.Tables[dt.TableName] != null)
                {
                    dtDataSetLocal.Tables[dt.TableName].Clear();
                    dtDataSetLocal.Tables[dt.TableName].Merge(dt, false, MissingSchemaAction.Ignore);
                }
                else
                    dtDataSetLocal.Tables.Add(dt);

                bRetorno = true;
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }

            return bRetorno;
        }

        #endregion Adiciona tabelas ao DataSet

        #region Adiciona condições necessárias para possiveis filtros.

        /// <summary>
        /// Adiciona condições WHERE a query
        /// </summary>
        /// <param name="sQuery_Atual">Query atual</param>
        /// <param name="sCondicao">Filtro para query</param>
        /// <returns>String com a nova query alterada.</returns>
        private string Adiciona_Condicoes(string sQuery_Atual, string sCondicao)
        {
            string sSQL = string.Empty;
            //-- Verifica se existe where na query.
            //-- Caso exista adiciona a condição a este where.
            if (sQuery_Atual.ToLower().LastIndexOf("where") > 0)
            {
                int iPosicao = (sQuery_Atual.ToLower().LastIndexOf("where") + 5);
                string sSQL1 = sQuery_Atual.Substring(0, iPosicao),
                    sSQL2 = sQuery_Atual.Substring(iPosicao, (sQuery_Atual.Length - iPosicao)),
                    NewSQL = "{0} {1} and {2}";

                sSQL = string.Format(NewSQL, sSQL1, sCondicao, sSQL2);
            }
            else
            {
                //-- Caso não exista o sistema irá verificar se existe ORDER BY ou GROUP BY
                int iPosicao_Order = (sQuery_Atual.ToLower().LastIndexOf("order") - 1),
                    iPosicao_Group = (sQuery_Atual.ToLower().LastIndexOf("group") - 1);

                //-- Caso exista um Group By ou um Order By na query sem um Where
                if (iPosicao_Group >= 0 | iPosicao_Order >= 0)
                {
                    string NewSQL = "{0} where {1} {2}";

                    //-- Caso exista um group o sistema apenas vai considera-lo
                    if (iPosicao_Group >= 0)
                    {
                        string sSQL1 = sQuery_Atual.Substring(0, iPosicao_Group),
                        sSQL2 = sQuery_Atual.Substring(iPosicao_Group, (sQuery_Atual.Length - iPosicao_Group));

                        sSQL = string.Format(NewSQL, sSQL1, sCondicao, sSQL2);
                    }
                    else
                    {
                        //-- Caso não exista um group o sistema vai considerar o order by
                        if (iPosicao_Order >= 0)
                        {
                            string sSQL1 = sQuery_Atual.Substring(0, iPosicao_Order),
                            sSQL2 = sQuery_Atual.Substring(iPosicao_Order, (sQuery_Atual.Length - iPosicao_Order));

                            sSQL = string.Format(NewSQL, sSQL1, sCondicao, sSQL2);
                        }
                    }
                }
                else
                {
                    sSQL = sQuery_Atual + " where " + sCondicao;
                }
            }

            return sSQL;
        }

        #endregion Adiciona condições necessárias para possiveis filtros.

        #region Alimenta todas as tabelas Pai

        /// <summary>
        /// Alimentar todas as tabelas (Pai) criadas no LOAD do form.
        /// </summary>
        /// <returns>Retorna se todos os pais encontraram registros.</returns>
        public bool AlimentarTabelas_Pai()
        {
            bool bRetorno = false;

            //-- filtra somente tabelas pai.
            IList<Controle_Tabelas> iTab_Pai = ((List<Controle_Tabelas>)iTabelas).FindAll(
                new Predicate<Controle_Tabelas>(delegate (Controle_Tabelas obj)
                    { return (obj.TipoTabela == Controle_Tabelas.TiposTabelas.Pai); }));

            //-- varre ao array para encontrar a tabela main.
            foreach (Controle_Tabelas tf in iTab_Pai)
            {
                string sSQL = string.Empty;
                sSQL += this.MontarCondicoes(tf.NomeTabela, tf);
                if (sSQL != string.Empty)
                    sSQL = this.Adiciona_Condicoes(tf.SQLStatement, sSQL);
                else
                    sSQL = tf.SQLStatement;

                DataTable dt_temp = SQL.Select(sSQL, tf.NomeTabela, false, true);
                //-- Seta as primary keys caso necessário.
                if (!string.IsNullOrEmpty(tf.Primary_Keys))
                {
                    try
                    {
                        Controle_Tabelas.Set_PKs(ref dt_temp, tf.Primary_Keys);
                    }
                    catch (Exception ex)
                    {
                        MsgBox.Show(string.Format("Erro ao definir chave primaria.\r\n{0}", ex.Message));
                    }
                }

                //-- Adiciona DataTable em DataSet
                Adicionar_DataSet(ref dt_temp);

                //-- Verifica
                if (dtDataSetLocal.Tables[tf.NomeTabela].Rows.Count > 0 || bRetorno)
                {
                    bRetorno = true;

                    //-- Guarda a ultima query executada
                    tf.Ultima_Query = sSQL;
                }
                else
                    bRetorno = false;
            }

            return bRetorno;
        }

        /// <summary>
        /// Localiza os dados das tabelas pai, entretando com as incormações da ultima query.
        /// </summary>
        /// <returns>Retorna se todos os pais encontraram registros.</returns>
        private bool AlimentarTabelas_Pai_Requery()
        {
            bool bRetorno = false;

            //-- filtra somente tabelas pai.
            IList<Controle_Tabelas> iTab_Pai = ((List<Controle_Tabelas>)iTabelas).FindAll(
                new Predicate<Controle_Tabelas>(delegate (Controle_Tabelas obj)
                    { return (obj.TipoTabela == Controle_Tabelas.TiposTabelas.Pai && !string.IsNullOrEmpty(obj.Ultima_Query)); }));

            //-- varre ao array para encontrar a tabela main.
            foreach (Controle_Tabelas tf in iTab_Pai)
            {
                int iPosicao = dBindingSource[sMainTabela].Position;
                //-- faz o merge da tabela LOCAL com a nova tabela que está sendo carregado do servidor.
                DataTable dt_temp = SQL.Select(tf.Ultima_Query, tf.NomeTabela, false);

                //-- Seta as primary keys caso necessário.
                if (!string.IsNullOrEmpty(tf.Primary_Keys))
                {
                    try
                    {
                        Controle_Tabelas.Set_PKs(ref dt_temp, tf.Primary_Keys);
                    }
                    catch (Exception ex)
                    {
                        MsgBox.Show(string.Format("Erro ao definir chave primaria.\r\n", ex.Message));
                    }
                }

                //-- Faz o merge com os dados.
                this.Adicionar_DataSet(ref dt_temp);

                //-- Verifica
                if (dBindingSource[tf.NomeTabela].Count > 0 || bRetorno)
                    bRetorno = true;
                else
                    bRetorno = false;

                dBindingSource[sMainTabela].Position = iPosicao;
            }

            return bRetorno;
        }

        #endregion Alimenta todas as tabelas Pai

        #region Alimenta todas as tabelas filhas

        /// <summary>
        /// Alimentar todas as tabelas (Filha) criadas no LOAD do form.
        /// </summary>
        /// <returns>Retorna se todos os pais encontraram registros.</returns>
        private void AlimentarTabelas_Filha()
        {
            //-- filtra somente tabelas pai.
            IList<Controle_Tabelas> iTab_Filha = ((List<Controle_Tabelas>)iTabelas).FindAll(
                new Predicate<Controle_Tabelas>(delegate (Controle_Tabelas obj)
                    { return (obj.TipoTabela == Controle_Tabelas.TiposTabelas.Filha); }));

            //-- varre ao array para encontrar a tabela main.
            foreach (Controle_Tabelas tf in iTab_Filha)
            {
                string sSQL = string.Empty;
                sSQL += this.MontarCondicoes(tf.NomeTabela, tf);
                if (sSQL != string.Empty)
                    sSQL = this.Adiciona_Condicoes(tf.SQLStatement, sSQL);
                else
                    sSQL = tf.SQLStatement;

                //-- Seta as primary keys caso necessário.
                DataTable dt_temp = SQL.Select(sSQL, tf.NomeTabela, false, true);
                if (!string.IsNullOrEmpty(tf.Primary_Keys))
                    Controle_Tabelas.Set_PKs(ref dt_temp, tf.Primary_Keys);

                //-- Adiciona DataTable em DataSet
                Adicionar_DataSet(ref dt_temp);
            }

            //-- Fecha todas a conexão com o banco de dados.
            SQL.Fechar_Conexao();
        }

        #endregion Alimenta todas as tabelas filhas

        #region Guarta todas as PK da tabela main

        /// <summary>
        /// Guarda as PK da tabela PAI para trabalho futuro.
        /// </summary>
        /// <param name="row">Passa por parametro o registro de trabalho</param>
        internal void PrimaryKey_Main(DataRow row)
        {
            this.PrimaryKeyMain.Clear();

            DataColumn[] fDc = dtDataSetLocal.Tables[this.MainTabela].PrimaryKey;

            if (fDc.Length > 0)
            {
                //-- Inclui todos as primary keys no array.
                foreach (DataColumn dc in fDc)
                {
                    if (dc.ReadOnly)
                        dc.ReadOnly = false;

                    DS_PrimaryKey ds_PK = new DS_PrimaryKey(dc.Caption, row[dc.Caption].ToString());

                    this.PrimaryKeyMain.Add(ds_PK);
                }
            }
            else
            {
                string sMensagem = "Não foi encontrada a chave primaria da tabela '{0}'.";
                sMensagem = string.Format(sMensagem, this.MainTabela);
                CompSoft.compFrameWork.MsgBox.Show(sMensagem
                    , "Erro"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        #endregion Guarta todas as PK da tabela main

        #endregion Pesquisa

        #region Salvar

        /// <summary>
        /// Executa a rotina de Inclusão/Alteração/Exclusão no banco de dados.
        /// </summary>
        /// <returns>Retorna se o metodo realizaou a tarefa com exito.</returns>
        public bool Salvar()
        {
            bool bRetorno = false,
                   bRetBefore = true;

            if (user_BeforeSave != null)
                bRetBefore = user_BeforeSave();

            //-- Formulário Wait
            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, os dados estão sendo enviados para o banco de dados.");

            if (bRetBefore)
            {
                if (this.FormStatus == TipoFormStatus.Novo)
                {
                    //-- Encerra as atualizações.
                    //-- Faz o processo normal para atualização dos dados.
                    foreach (Controle_Tabelas ct in iTabelas)
                    {
                        //-- Atualiza bool para 0 caso seja null e encerra atualiza DataTable
                        this.Atualizar_DataRow_Boolean_NULL(ct.NomeTabela);
                    }
                }

                //-- Salva no banco de dados.
                ManipulaRegistros mr = new ManipulaRegistros();
                if (this.FormStatus != TipoFormStatus.Excluindo)
                {
                    bRetorno = mr.Salvar_Dados(this);
                }
                else
                {
                    if (mr.Excluir_Dados(this))
                        bRetorno = true;
                }

                if (bRetorno && user_AfterSave != null)
                    this.user_AfterSave();
            }

            f.Close();

            return bRetorno;
        }

        #region Atualiza todos os campos boolean como o default value

        /// <summary>
        /// Verifica dentro da tabela atual se existe algum campo como boolean que esteja null
        /// caso ele esteja o sistema define o valor padrão para este controle.
        /// </summary>
        /// <param name="sTabela">Nome da tabela para verifição</param>
        private void Atualizar_DataRow_Boolean_NULL(string sTabela)
        {
            if (dBindingSource[sTabela].Count > 0)
            {
                DataRow row = ((DataRowView)dBindingSource[sTabela].Current).Row;

                foreach (DataColumn dc in row.Table.Columns)
                {
                    if (!dc.AllowDBNull && !dc.AutoIncrement)
                    {
                        if (dc.DataType == typeof(System.Boolean) && string.IsNullOrEmpty(row[dc.Caption].ToString()))
                        {
                            if (dc.DefaultValue != null && !string.IsNullOrEmpty(dc.DefaultValue.ToString()))
                                row[dc.Caption] = dc.DefaultValue;
                            else
                                row[dc.Caption] = 0;
                        }
                    }
                }
            }
        }

        #endregion Atualiza todos os campos boolean como o default value

        #endregion Salvar

        #region Limpa

        #region Rotina que limpa todos os dados

        /// <summary>
        /// Rotina que limpará todos os controles do formulário.
        /// </summary>
        public void Limpar()
        {
            foreach (Controle_Tabelas ct in iTabelas)
            {
                dtDataSetLocal.Tables[ct.NomeTabela].Clear();
                dBindingSource[ct.NomeTabela].RemoveFilter();
                dBindingSource[ct.NomeTabela].RemoveSort();
            }

            //-- Remove todos os indicativos de obrigatoriedade dos controles
            this.Remover_Indicativo_Obrigatorio(this.Controls);

            //-- Seta total de regisros no barra de ferramentas
            this.TotalRegistros(MostrarTotalRegistros.Contagem_Zerada);

            if (user_AfterClear != null)
                this.user_AfterClear();
        }

        #endregion Rotina que limpa todos os dados

        #region Tira todos os indicadores de campo obrigatório

        private void Remover_Indicativo_Obrigatorio(Control.ControlCollection controle)
        {
            foreach (Control ctrl in controle)
            {
                //-- Caso o controle possua mais controles internos.
                if (ctrl.Controls.Count > 0 && ctrl.GetType().Name != "cf_DateEdit")
                {
                    //-- Chama o mesmo método para obter os controles.
                    //-- Este processo utiliza recurcividade.
                    this.Remover_Indicativo_Obrigatorio(ctrl.Controls);
                }

                if (ctrl.GetType().ToString() == "CompSoft.cf_Bases.cf_ComboBox")
                    ((CompSoft.cf_Bases.cf_ComboBox)ctrl).Remover_Mensagem = true;

                if (ctrl.GetType().ToString() == "CompSoft.cf_Bases.cf_TextBox")
                    ((CompSoft.cf_Bases.cf_TextBox)ctrl).Remover_Mensagem = true;

                if (ctrl.GetType().ToString() == "CompSoft.cf_Bases.cf_MaskedBox")
                    ((CompSoft.cf_Bases.cf_MaskedBox)ctrl).Remover_Mensagem = true;

                if (ctrl.GetType().ToString() == "CompSoft.cf_Bases.cf_DateEdit")
                    ((CompSoft.cf_Bases.cf_DateEdit)ctrl).Remover_Mensagem = true;
            }
        }

        #endregion Tira todos os indicadores de campo obrigatório

        #endregion Limpa

        #region Excluir

        /// <summary>
        /// Rotina que excluirá todos os dados do registro corrente.
        /// </summary>
        public void Excluir()
        {
            bool bRetorno = true;
            if (this.user_BeforeDelete != null)
                bRetorno = this.user_BeforeDelete();

            if (bRetorno)
            {
                DialogResult dr = MsgBox.Show("Você deseja mesmo excluir este registro?"
                    , "Pergunta"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    this.FormStatus = TipoFormStatus.Excluindo;

                    //-- filtra somente tabelas pai.
                    IList<Controle_Tabelas> iTab = ((List<Controle_Tabelas>)iTabelas).FindAll(
                        new Predicate<Controle_Tabelas>(delegate (Controle_Tabelas obj)
                            { return (obj.TipoTabela == Controle_Tabelas.TiposTabelas.Filha); }));

                    //-- Exclui os dados da tabela filha vinculada.
                    foreach (Controle_Tabelas ct in iTab)
                    {
                        int nTotal = dBindingSource[ct.NomeTabela].Count;

                        for (int i = 0; i < nTotal; i++)
                            dBindingSource[ct.NomeTabela].RemoveCurrent();
                    }

                    //-- filtra somente tabelas pai.
                    iTab = ((List<Controle_Tabelas>)iTabelas).FindAll(
                        new Predicate<Controle_Tabelas>(delegate (Controle_Tabelas obj)
                            { return (obj.TipoTabela == Controle_Tabelas.TiposTabelas.Pai); }));

                    //-- Exclui os dados da tabela pai.
                    foreach (Controle_Tabelas ct in iTab)
                        dBindingSource[ct.NomeTabela].RemoveCurrent();

                    //-- Apos a exclusão o sistema salva a exclusão.
                    if (this.Salvar())
                    {
                        //-- Seta o total de registros
                        this.TotalRegistros(MostrarTotalRegistros.Contagem_Atual);

                        if (user_AfterDelete != null)
                            this.user_AfterDelete();

                        this.FormStatus = TipoFormStatus.Pesquisar;
                        this.Movimentar_Registro(Movimento.Atualizar_Atual);

                        if (dBindingSource[sMainTabela].Count <= 0)
                            this.FormStatus = TipoFormStatus.Limpar;
                    }
                }
            }
        }

        #endregion Excluir

        #region Novo

        public bool Novo()
        {
            bool bRetorno = true;
            if (user_BeforeNew != null)
                bRetorno = this.user_BeforeNew();

            //-- Verifica se o processo de inclusão tem permissão para continuar
            if (bRetorno)
            {
                //-- Limpa todas as tabelas filhas.
                foreach (Controle_Tabelas ct in this.Tabelas)
                {
                    if (ct.TipoTabela == Controle_Tabelas.TiposTabelas.Filha)
                        ((DataTable)dBindingSource[ct.NomeTabela].DataSource).Clear();
                }

                //-- Limpa tadas as Primary Key atual.
                iCodPrimaryKey.Clear();

                //-- Adiciona novo registro ao banco de dados.
                if (bRetorno)
                {
                    dBindingSource[sMainTabela].AddNew();
                    this.TotalRegistros(MostrarTotalRegistros.Contagem_Atual);

                    if (user_AfterNew != null)
                        this.user_AfterNew();
                }
            }

            return bRetorno;
        }

        #endregion Novo

        #region Desfazer alterações

        /// <summary>
        /// Remove todas as alterações atuais.
        /// </summary>
        public void Desfazer()
        {
            //-- Cancela as incluções e a alterações no DataTable atual.
            foreach (Controle_Tabelas ct in iTabelas)
            {
                dBindingSource[ct.NomeTabela].EndEdit();
                dtDataSetLocal.Tables[ct.NomeTabela].RejectChanges();
            }

            //-- Seta a quantidade de registros na barra de ferramentas
            this.TotalRegistros(MostrarTotalRegistros.Contagem_Atual);

            //-- Remove todos as indicações visuais que o campo é obrigatório
            this.Remover_Indicativo_Obrigatorio(this.Controls);

            //-- Atualiza os dados dos DataSet´s das tabelas filhas.
            if (this.FormStatus != TipoFormStatus.Nenhum & this.FormStatus != TipoFormStatus.Limpar)
            {
                //-- Posiciona PK do registro atual.
                int iPosicao = dBindingSource[sMainTabela].Position;
                if (iPosicao >= 0)
                    this.PrimaryKey_Main(dtDataSetLocal.Tables[sMainTabela].Rows[iPosicao]);

                //-- Atualiza Tabelas filhas.
                this.AlimentarTabelas_Filha();
            }

            //-- Evento identificando que o metodo desfazer alterações foi invocado.
            if (this.user_AfterCancelAction != null)
                this.user_AfterCancelAction();

            //-- Requery nos dados da tela.
            if (this.user_AfterRefreshData != null)
                this.user_AfterRefreshData();
        }

        #endregion Desfazer alterações

        #endregion Manipulação com o banco de dados

        #region Declaração de metodos e eventos customizados.

        public virtual string user_Query(string TabelaAtual)
        {
            return "";
        }

        public delegate void AfterSearch();

        [Category("CompSoft")]
        public event AfterSearch user_AfterSearch;

        public delegate void AfterRefreshData();

        [Category("CompSoft")]
        public event AfterRefreshData user_AfterRefreshData;

        public delegate void AfterNew();

        [Category("CompSoft")]
        public event AfterNew user_AfterNew;

        public delegate void AfterClear();

        [Category("CompSoft")]
        public event AfterClear user_AfterClear;

        public delegate void AfterSave();

        [Category("CompSoft")]
        public event AfterSave user_AfterSave;

        public delegate void AfterDelete();

        [Category("CompSoft")]
        public event AfterDelete user_AfterDelete;

        public delegate void FormStatus_Change();

        [Category("CompSoft")]
        public event FormStatus_Change user_FormStatus_Change;

        public delegate bool BeforeNew();

        [Category("CompSoft")]
        public event BeforeNew user_BeforeNew;

        public delegate bool BeforeDelete();

        [Category("CompSoft")]
        public event BeforeDelete user_BeforeDelete;

        public delegate bool BeforeEdit();

        [Category("CompSoft")]
        public event BeforeEdit user_BeforeEdit;

        public delegate bool BeforeSave();

        [Category("CompSoft")]
        public event BeforeSave user_BeforeSave;

        public delegate bool BeforeSearch();

        [Category("CompSoft")]
        public event BeforeSearch user_BeforeSearch;

        public delegate void AfterCancelAction();

        [Category("CompSoft")]
        public event AfterCancelAction user_AfterCancelAction;

        #endregion Declaração de metodos e eventos customizados.

        #region Rotina padrão do formulário

        public FormSet()
        {
            InitializeComponent();

            //-- Remove as constraits dos DATASET´s
            dtDataSetLocal.EnforceConstraints = false;
        }

        protected override void OnEnter(EventArgs e)
        {
            this.SuspendLayout();

            base.OnEnter(e);

            if (string.IsNullOrEmpty(sTituloForm))
            {
                sTituloForm = this.Text;
            }

            //-- Verifica se existe relatório e atualiza status da barra de ferramentas
            Funcoes func;
            func.TratarStatus_BarraFerramentas(this.iFormStatus, this.tpTipo_Formulario);

            //-- Seta o número de registros na barra de ferramentas
            this.TotalRegistros(MostrarTotalRegistros.Contagem_Atual);

            this.ResumeLayout();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.SuspendLayout();

            //-- Monta estrutura das tabelas;
            if (!string.IsNullOrEmpty(Propriedades.StringConexao))
            {
                if (this.Tabelas.Count > 0)
                    this.montaEstruturaDataSet();
            }

            base.OnLoad(e);

            this.ResumeLayout();
        }

        protected override void OnShown(EventArgs e)
        {
            this.SuspendLayout();

            if (Propriedades.FormMain != null && Propriedades.FormMain.ActiveMdiChild != null)
            {
                //-- Verifica se pode ativar ou desativar o botão de impressão na barra de ferramentas.
                if (bRelatorio)
                    bRelatorio = this.ExisteRelatorio();

                this.AlimentarBind_Controles();
                this.FormStatus = TipoFormStatus.Limpar;
                this.Limpar();
            }

            if (this.user_AfterRefreshData != null)
                this.user_AfterRefreshData();

            base.OnShown(e);

            this.ResumeLayout();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult dr = DialogResult.Yes;
            if (this.FormStatus == TipoFormStatus.Novo || this.FormStatus == TipoFormStatus.Modificando)
            {
                dr = MsgBox.Show("Todas as alterações ou inclusões deste registro serão desconsideradas, deseja continuar?"
                    , "Fechar formulário"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);
            }

            if (dr == DialogResult.Yes)
            {
                try
                {
                    //-- suspend o bind do controle e remove da memoria todos os controles.
                    foreach (Controle_Tabelas ct in iTabelas)
                        dBindingSource[ct.NomeTabela].SuspendBinding();
                }
                catch { }

                base.OnClosing(e);
            }
            else
                e.Cancel = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (Propriedades.FormMain.MdiChildren.Length < 1)
            {
                this.TotalRegistros(MostrarTotalRegistros.Contagem_Zerada);
                this.FormStatus = TipoFormStatus.Nenhum;
            }
            else
            {
                if (Propriedades.FormMain.MdiChildren.Length == 1 && this.Name == Propriedades.FormMain.ActiveMdiChild.Name)
                {
                    this.TotalRegistros(MostrarTotalRegistros.Contagem_Zerada);
                    this.FormStatus = TipoFormStatus.Nenhum;
                }
                else
                {
                    Funcoes func;
                    if (func.Check_Extension(Propriedades.FormMain.ActiveMdiChild.GetType(), typeof(FormSet)))
                    {
                        //-- Verifica se existe relatório e atualiza status da barra de ferramentas
                        FormSet f = (FormSet)Propriedades.FormMain.ActiveMdiChild;

                        func.TratarStatus_BarraFerramentas(f.FormStatus, f.Tipo_Formulario);

                        f.TotalRegistros(MostrarTotalRegistros.Contagem_Atual);
                    }
                }
            }
        }

        #endregion Rotina padrão do formulário

        #region Verifica se existe relatório para este formulário.

        /// <summary>
        /// Verifica se existe relatório para este formulário.
        /// </summary>
        /// <returns>true/false indicando se existe relatório para este formulário.</returns>
        private bool ExisteRelatorio()
        {
            bool bRetorno = false;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(Menu_Item_relatorio)");
            sb.AppendLine(" from menus_itens_relatorios mir");
            sb.AppendLine("  inner join menus_itens mi on mi.menu_item = mir.menu_item");
            sb.AppendFormat(" where formulario = '{0}'", this.Name);

            if (Convert.ToInt32(SQL.ExecuteScalar(sb.ToString())) > 0)
                bRetorno = true;

            return bRetorno;
        }

        #endregion Verifica se existe relatório para este formulário.
    }
}