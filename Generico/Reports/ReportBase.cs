using CompSoft.cf_Bases;
using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CompSoft.Reports
{
    public partial class ReportBase : XtraReport
    {
        private bool bRegistroAtual = true;

        private DataSet dt_DataSet = new DataSet();

        private string sNomeRelatorio = string.Empty,
            sDescricaoRelatorio = string.Empty,
            sDataMember_Report = string.Empty;

        private frmWait fwait;

        #region Propriedades do relatorio

        public new string DataMember
        {
            get { return sDataMember_Report; }
            set { sDataMember_Report = value; }
        }

        public string Nome_Relatorio
        {
            get { return sNomeRelatorio; }
            set { sNomeRelatorio = value; }
        }

        public string Descricao_Relatorio
        {
            get { return sDescricaoRelatorio; }
            set { sDescricaoRelatorio = value; }
        }

        public bool Imprimi_Registro_Atual
        {
            get { return bRegistroAtual; }
            set { bRegistroAtual = value; }
        }

        public DataSet Report_DataSet
        {
            get { return dt_DataSet; }
            set { dt_DataSet = value; }
        }

        #endregion Propriedades do relatorio

        #region Metodos e funções do relatório

        #region Adiciona tabelas ao DataSet principal do relatório

        /// <summary>
        /// Alimenta o dataSet do relatorio com a tabela passada.
        /// </summary>
        /// <param name="dt">Data table que contem os dados</param>
        public void ADD_Tabela(DataTable dt)
        {
            try
            {
                if (this.dt_DataSet.Tables[dt.TableName] != null)
                {
                    this.dt_DataSet.Tables[dt.TableName].Clear();
                    this.dt_DataSet.Tables[dt.TableName].Merge(dt);
                }
                else
                {
                    this.dt_DataSet.Tables.Add(dt);
                }
            }
            catch (Exception ex)
            {
                fwait.Close();
                CompSoft.compFrameWork.MsgBox.Show(ex.Message);
            }
        }

        #endregion Adiciona tabelas ao DataSet principal do relatório

        #region Busca os dados para impressao de acordo com os parametros passados pelo form

        /// <summary>
        /// Busca os dados para fazer a impressão
        /// </summary>
        /// <returns>True/False se encontrou registros ou deu algum erro</returns>
        private bool Buscar_Dados_Impressao()
        {
            bool bRetorno = false;

            //-- Formulário com todos os dados.
            FormSet fForm = (FormSet)Propriedades.FormMain.ActiveMdiChild;

            //---- Busca apenas o cliente selecionado pelo cliente.
            if (this.Imprimi_Registro_Atual)
            {
                foreach (Controle_Tabelas ct in fForm.Tabelas)
                {
                    if (ct.TipoTabela == Controle_Tabelas.TiposTabelas.Pai)
                    {
                        DataRow row = ((DataRowView)fForm.BindingSource[ct.NomeTabela].Current).Row;
                        this.dt_DataSet.Tables[ct.NomeTabela].ImportRow(row);

                        //-- Evento indicando que a tabela foi carregada para gerar o relatório.
                        if (this.user_AfterImportTable != null)
                            this.user_AfterImportTable(ct.NomeTabela);
                    }
                    else
                    {
                        DataTable dt = fForm.DataSetLocal.Tables[ct.NomeTabela].Copy();
                        this.ADD_Tabela(dt);

                        //-- Evento indicando que a tabela foi carregada para gerar o relatório.
                        if (this.user_AfterImportTable != null)
                            this.user_AfterImportTable(dt.TableName);
                    }
                }
                bRetorno = true;
            }

            //---- Busca todos os registros que foram localizados no sistema pelo usuário
            else
            {
                string sMonta_condicao = string.Empty;

                //-- Faz a busca tabela por tabela.
                foreach (Controle_Tabelas ct in fForm.Tabelas)
                {
                    if (ct.TipoTabela == Controle_Tabelas.TiposTabelas.Pai)
                    {
                        DataTable dt = fForm.DataSetLocal.Tables[ct.NomeTabela].Copy();
                        this.ADD_Tabela(dt);

                        //-- Evento indicando que a tabela foi carregada para gerar o relatório.
                        if (this.user_AfterImportTable != null)
                            this.user_AfterImportTable(dt.TableName);

                        //-- Monta as condições de busca.
                        DataRow[] fRow = this.dt_DataSet.Tables[fForm.MainTabela].Select();
                        sMonta_condicao = Monta_Condicao_AllRecords(fRow);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(sMonta_condicao))
                        {
                            //-- Monta condições de busca e adicona DT no DataSet
                            string sWhere = sMonta_condicao.ToLower().Replace("%tabela%", ct.NomeTabela);

                            int iContemWhere = ct.SQLStatement.ToLower().IndexOf("where") + 5;
                            string sCondicao1 = string.Empty,
                                sCondicao2 = string.Empty;

                            if (ct.SQLStatement.ToLower().IndexOf("where") > 0)
                            {
                                sCondicao1 = ct.SQLStatement.Substring(0, iContemWhere);
                                sCondicao2 = ct.SQLStatement.Substring(iContemWhere, (ct.SQLStatement.Length - iContemWhere));

                                sCondicao1 += "(" + sWhere + ") AND " + sCondicao2;
                            }
                            else
                                sCondicao1 = ct.SQLStatement + " where " + sWhere;

                            DataTable dt = SQL.Select(sCondicao1, ct.NomeTabela, false);

                            if (dt != null)
                                this.ADD_Tabela(dt);

                            //-- Evento indicando que a tabela foi carregada para gerar o relatório.
                            if (this.user_AfterImportTable != null)
                                this.user_AfterImportTable(dt.TableName);
                        }
                    }
                }

                bRetorno = true;
            }

            return bRetorno;
        }

        #endregion Busca os dados para impressao de acordo com os parametros passados pelo form

        #region Monta as condições para relatórios que tragam todos os registros

        /// <summary>
        /// Monta as condições IN para localizar todos os registros da tabela pai
        /// </summary>
        /// <param name="fRow">DataRow[] que contem as chaves de busca</param>
        /// <returns>Retorna toda a condição IN montada separado por virgula e entre aspas simpes.</returns>
        public string Monta_Condicao_AllRecords(DataRow[] fRow)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //-- Loop que montará todos os itens para pesquisa.
            foreach (DataRow row in fRow)
            {
                bool bPrimeira_Coluna = true;
                foreach (DataColumn dc in row.Table.PrimaryKey)
                {
                    if (sb.Length > 0)
                        sb.Append(" OR ");

                    string sValor = string.Empty;
                    switch (dc.DataType.Name)
                    {
                        case "DateTime":
                            DateTime dt = Convert.ToDateTime(row[dc.Caption]);
                            sValor = dt.ToString("yyyyMMdd");
                            break;

                        default:
                            sValor = row[dc.Caption].ToString();
                            break;
                    }

                    //-- faz query
                    if (bPrimeira_Coluna)
                        sb.AppendFormat("%Tabela%.{0} = '{1}'", dc.Caption, sValor);
                    else
                        sb.AppendFormat(" AND %Tabela%.{0} = '{1}'", dc.Caption, sValor);

                    bPrimeira_Coluna = false;
                }
            }

            return sb.ToString();
        }

        #endregion Monta as condições para relatórios que tragam todos os registros

        #region Copia o dataset do form que chamou o report

        /// <summary>
        /// Copia toda a estrutura do dataset do form original
        /// </summary>
        private void Copia_DataSet_FormOrigem()
        {
            try
            {
                this.dt_DataSet.EnforceConstraints = false;
                FormSet fForm = (FormSet)Propriedades.FormMain.ActiveMdiChild;
                foreach (DataTable dt in fForm.DataSetLocal.Tables)
                {
                    this.ADD_Tabela(dt.Copy());
                    this.dt_DataSet.Tables[dt.TableName].Clear();
                }
            }
            catch (Exception ex)
            {
                fwait.Close();
                MsgBox.Show(ex.Message
                    , "ERRO - Copia de dados da origem"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        #endregion Copia o dataset do form que chamou o report

        #region Binda os controles para geração do relatório

        /// <summary>
        /// Binda todos os campos do relatório
        /// </summary>
        /// <param name="controle">coleção de controles</param>
        private void Bind_Control_Report(XRControlCollection controle)
        {
            foreach (XRControl ctrl in controle)
            {
                if (ctrl.Controls.Count > 0)
                {
                    this.Bind_Control_Report(ctrl.Controls);
                }
                else
                {
                    switch (ctrl.GetType().Name)
                    {
                        case "cf_Report_Label":
                            if (!string.IsNullOrEmpty(((cf_Report_Label)ctrl).ControlSource))
                            {
                                cf_Report_Label Label = ((cf_Report_Label)ctrl);

                                //-- Monta o data member do relatório.
                                string sDataMember;
                                if (string.IsNullOrEmpty(Label.Tabela))
                                    sDataMember = Label.ControlSource;
                                else
                                    sDataMember = string.Format("{0}.{1}"
                                        , Label.Tabela
                                        , Label.ControlSource);

                                //-- Binda o relatório...
                                if (string.IsNullOrEmpty(Label.FormatString))
                                    Label.DataBindings.Add(
                                        "Text"
                                        , this.dt_DataSet
                                        , sDataMember);
                                else
                                    Label.DataBindings.Add(
                                        "Text"
                                        , this.dt_DataSet
                                        , sDataMember
                                        , Label.FormatString);
                            }
                            break;

                        case "cf_Report_CheckBox":
                            if (!string.IsNullOrEmpty(((CompSoft.cf_Bases.cf_Report_CheckBox)ctrl).ControlSource))
                            {
                                //-- Monta o data member do relatório.
                                string sDataMember;
                                if (string.IsNullOrEmpty(((CompSoft.cf_Bases.cf_Report_CheckBox)ctrl).Tabela))
                                    sDataMember = ((CompSoft.cf_Bases.cf_Report_CheckBox)ctrl).ControlSource;
                                else
                                    sDataMember = string.Format("{0}.{1}", ((CompSoft.cf_Bases.cf_Report_CheckBox)ctrl).Tabela, ((CompSoft.cf_Bases.cf_Report_CheckBox)ctrl).ControlSource);

                                ((CompSoft.cf_Bases.cf_Report_CheckBox)ctrl).DataBindings.Add(
                                    "CheckState"
                                    , this.dt_DataSet
                                    , sDataMember);
                            }
                            break;
                    }
                }
            }
        }

        #endregion Binda os controles para geração do relatório

        #region Relaciona todas as tabelas no banco de dados de acordo com o padrão de banco de dados

        private void Relacionar_Tabelas()
        {
            FormSet fForm = (FormSet)Propriedades.FormMain.ActiveMdiChild;

            foreach (DataTable ct in this.dt_DataSet.Tables)
            {
                if (this.dt_DataSet.Tables.Count > 1 && ct.TableName.ToLower() != fForm.MainTabela.ToLower())
                {
                    //-- Define as colunas
                    DataColumn[] parent = this.dt_DataSet.Tables[fForm.MainTabela].PrimaryKey;
                    DataColumn[] child = new DataColumn[parent.Length];

                    int i = 0;
                    foreach (DataColumn dc in parent)
                    {
                        child[i] = this.dt_DataSet.Tables[ct.TableName].Columns[dc.Caption];
                        i++;
                    }

                    //-- Faz o relacionamento
                    try
                    {
                        DataRelation dr = new DataRelation(string.Format("FK_{0}_{1}", fForm.MainTabela, ct.TableName)
                            , parent
                            , child);
                        this.dt_DataSet.Relations.Add(dr);
                    }
                    catch (Exception ex)
                    {
                        fwait.Close();
                        CompSoft.compFrameWork.MsgBox.Show(ex.Message);
                    }
                    finally
                    {
                        this.dt_DataSet.EnforceConstraints = false;
                    }
                }
            }
        }

        #endregion Relaciona todas as tabelas no banco de dados de acordo com o padrão de banco de dados

        #region Metodo que será herdado para sobrepor todos os datareports com o data member

        public virtual void Set_DataMember_DetailReports()
        {
        }

        #endregion Metodo que será herdado para sobrepor todos os datareports com o data member

        #endregion Metodos e funções do relatório

        #region Eventos para desenvolvimento customizado.

        public delegate void AfterImportTable(string TableName);

        public event AfterImportTable user_AfterImportTable;

        #endregion Eventos para desenvolvimento customizado.

        public ReportBase()
        {
            if (Propriedades.FormMain != null && Propriedades.FormMain.ActiveMdiChild != null)
            {
                fwait = new frmWait("Aguarde, gerando relatório.");
                this.dt_DataSet.EnforceConstraints = false;
                this.Copia_DataSet_FormOrigem();
            }

            InitializeComponent();

            CompSoft.compFrameWork.Impressoras imp;
            this.PrinterName = imp.Impressora_Padrao;
        }

        protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
        {
            if (Propriedades.FormMain != null && Propriedades.FormMain.ActiveMdiChild != null)
            {
                if (!this.Buscar_Dados_Impressao())
                {
                    MsgBox.Show("Não foi possivel encontrar registros para trabalho."
                        , "Alerta"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
                else
                {
                    //-- seta os datamember dos itens...
                    this.Set_DataMember_DetailReports();

                    //-- Geralção do relatório.
                    this.Relacionar_Tabelas(); //-- Relaciona tabelas

                    this.DataSource = this.dt_DataSet; //-- Define o DataSet

                    //-- Identifica o DataMember principal do relatório.
                    if (string.IsNullOrEmpty(sDataMember_Report))
                        this.DataMember = ((FormSet)Propriedades.FormMain.ActiveMdiChild).MainTabela;
                    else
                        this.DataMember = sDataMember_Report;

                    this.Bind_Control_Report(this.Bands); //-- Binda os controles para mostrar o relatório.

                    //-- Só vai executar o processo no report local se corrur tudo bem durante o processo de busca e bindagem.
                    base.OnBeforePrint(e);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnAfterPrint(EventArgs e)
        {
            base.OnAfterPrint(e);

            if (Propriedades.FormMain != null)
                fwait.Close();
        }
    }
}