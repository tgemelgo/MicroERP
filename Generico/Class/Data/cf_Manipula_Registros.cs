using CompSoft.cf_Bases;
using CompSoft.compFrameWork;
using CompSoft.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Data
{
    public class ManipulaRegistros
    {
        private System.Text.StringBuilder sbCondicao = new System.Text.StringBuilder();

        #region Rotina de Inclusão/Atualiação do banco de dados

        /// <summary>
        /// Atualiza todas as tabelas com os campos bindados na tela
        /// </summary>
        /// <param name="fForm">Formulário que está sendo trabalhado.</param>
        /// <returns>true/false caso consiga atualizar tudo.</returns>
        public bool Salvar_Dados(FormSet fForm)
        {
            bool bRetorno = false;

            SqlConnection db = new SqlConnection(Propriedades.StringConexao);
            try
            {
                db.Open();

                //-- filtra somente tabelas pai.
                IList<Controle_Tabelas> iTab = ((List<Controle_Tabelas>)fForm.Tabelas).FindAll(
                    new Predicate<Controle_Tabelas>(delegate (Controle_Tabelas obj)
                        { return (obj.TipoTabela == Controle_Tabelas.TiposTabelas.Pai); }));

                //-- Loop para atualiza todos os pai
                foreach (Controle_Tabelas ct in iTab)
                {
                    SqlCommand cm = new SqlCommand(string.Format("select * from {0}", ct.NomeTabela), db);
                    //-- Monta todas os updates para atualização no banco de dados.
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated_Pai);

                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    cb.SetAllValues = false;
                    cb.ConflictOption = ConflictOption.OverwriteChanges;
                    fForm.BindingSource[ct.NomeTabela].EndEdit();
                    da.Update(fForm.DataSetLocal, ct.NomeTabela);
                }

                //-- filtra somente tabelas pai.
                iTab = ((List<Controle_Tabelas>)fForm.Tabelas).FindAll(
                    new Predicate<Controle_Tabelas>(delegate (Controle_Tabelas obj)
                        { return (obj.TipoTabela == Controle_Tabelas.TiposTabelas.Filha); }));

                //-- Loop para atualiza todos os filhos
                foreach (Controle_Tabelas ct in iTab)
                {
                    SqlCommand cm = new SqlCommand(string.Format("select * from {0}", ct.NomeTabela), db);
                    //-- Monta todas os updates para atualização no banco de dados.
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated_Filha);

                    //-- Atualiza Foreign key para não ocorrer erro de constraint nas tabelas filhas.
                    Atualizar_ForeignKey_Filha(fForm, ct.NomeTabela);

                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    cb.SetAllValues = false;
                    cb.ConflictOption = ConflictOption.OverwriteChanges;
                    fForm.BindingSource[ct.NomeTabela].EndEdit();
                    da.Update(fForm.DataSetLocal, ct.NomeTabela);
                }

                //-- Aceita todas as alterações realizadas.
                fForm.DataSetLocal.AcceptChanges();
                bRetorno = true;
            }
            catch (Exception ex)
            {
                CompSoft.compFrameWork.MsgBox.Show(string.Format("ERRO AO SALVAR DADOS NA TABELA.\n{0}", ex.Message), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRetorno = false;
            }
            finally
            {
                db.Close();
            }

            return bRetorno;
        }

        #endregion Rotina de Inclusão/Atualiação do banco de dados

        #region Exclusão do banco de dados

        /// <summary>
        /// Excluir os registros das tabelas filhas e depois os da tabela pai.
        /// </summary>
        /// <param name="fForm">Formulário que está sendo trabalhado.</param>
        /// <returns>true/false caso consiga atualizar tudo.</returns>
        public bool Excluir_Dados(FormSet fForm)
        {
            bool bRetorno = false;

            SqlConnection db = new SqlConnection(Propriedades.StringConexao);
            try
            {
                db.Open();

                //-- filtra somente tabelas pai.
                IList<Controle_Tabelas> iTab = ((List<Controle_Tabelas>)fForm.Tabelas).FindAll(
                    new Predicate<Controle_Tabelas>(delegate (Controle_Tabelas obj)
                        { return (obj.TipoTabela == Controle_Tabelas.TiposTabelas.Filha); }));

                //-- Loop para atualiza todos os filhos
                foreach (Controle_Tabelas ct in iTab)
                {
                    //-- Monta todas os updates para atualização no banco de dados.
                    SqlDataAdapter da = new SqlDataAdapter(string.Format("select * from {0}", ct.NomeTabela), db);

                    try
                    {
                        SqlCommandBuilder cb = new SqlCommandBuilder(da);
                        cb.ConflictOption = ConflictOption.CompareRowVersion;
                        cb.SetAllValues = false;
                        da.UpdateBatchSize = 100;
                        da.Update(fForm.DataSetLocal, ct.NomeTabela);
                        bRetorno = true;
                    }
                    catch
                    {
                        MsgBox.Show("Não foi possivel excluir registro.", "Alerta - FILHA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fForm.DataSetLocal.RejectChanges();
                        bRetorno = false;
                        goto Erro;
                    }
                }

                //-- filtra somente tabelas pai.
                iTab = ((List<Controle_Tabelas>)fForm.Tabelas).FindAll(
                    new Predicate<Controle_Tabelas>(delegate (Controle_Tabelas obj)
                        { return (obj.TipoTabela == Controle_Tabelas.TiposTabelas.Pai); }));

                //-- Loop para atualiza todos os pai
                foreach (Controle_Tabelas ct in iTab)
                {
                    //-- Monta todas os updates para atualização no banco de dados.
                    SqlDataAdapter da = new SqlDataAdapter(string.Format("select * from {0}", ct.NomeTabela), db);

                    try
                    {
                        SqlCommandBuilder cb = new SqlCommandBuilder(da);
                        cb.ConflictOption = ConflictOption.CompareRowVersion;
                        cb.SetAllValues = false;
                        da.UpdateBatchSize = 100;
                        da.Update(fForm.DataSetLocal, ct.NomeTabela);
                        bRetorno = true;
                    }
                    catch
                    {
                        MsgBox.Show("Não foi possivel excluir registro.", "Alerta - PAI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fForm.DataSetLocal.RejectChanges();
                        fForm.Movimentar_Registro(CompSoft.Movimento.Voltar);
                        bRetorno = false;
                        goto Erro;
                    }
                }

                //-- Aceita todas as alterações realizadas.
                fForm.DataSetLocal.AcceptChanges();
            }
            catch (Exception ex)
            {
                MsgBox.Show(string.Format("ERRO AO EXCLUIR DADO REGISTRO DA TABELA.\n{0}", ex.Message), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bRetorno = false;
            }
            finally
            {
                db.Close();
            }

        Erro:
            return bRetorno;
        }

        #endregion Exclusão do banco de dados

        #region Atualiza Foreign key das tabelas filhas

        /// <summary>
        /// Atualiza registros recem criados no dataset.
        /// </summary>
        /// <param name="fForm">Form ativo</param>
        /// <param name="sNomeTabela">Nome da tabela que será atualizada.</param>
        private void Atualizar_ForeignKey_Filha(FormSet fForm, String sNomeTabela)
        {
            fForm.BindingSource[sNomeTabela].EndEdit();

            DataView dv = new DataView(fForm.DataSetLocal.Tables[sNomeTabela], "", "", DataViewRowState.Added);
            foreach (DataRowView Row in dv)
            {
                foreach (DS_PrimaryKey pk in fForm.PrimaryKeyMain)
                    Row[pk.PrimaryKey] = pk.ValorPrimaryKey;
            }

            fForm.BindingSource[sNomeTabela].EndEdit();
        }

        #endregion Atualiza Foreign key das tabelas filhas

        #region Trata os eventos pós-update

        protected void OnRowUpdated_Pai(object sender, SqlRowUpdatedEventArgs args)
        {
            try
            {
                if (args.Row.RowState == DataRowState.Added)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select IDENT_CURRENT('");
                    sb.Append(args.Row.Table.TableName);
                    sb.Append("')");

                    SqlCommand cm = new SqlCommand(sb.ToString(), args.Command.Connection);

                    ((FormSet)Propriedades.FormMain.ActiveMdiChild).PrimaryKey_Main(args.Row);

                    int nReg = 0;
                    try
                    {
                        nReg = Convert.ToInt32(cm.ExecuteScalar());
                    }
                    catch { }

                    if (nReg != 0)
                    {
                        foreach (DS_PrimaryKey pk in ((FormSet)Propriedades.FormMain.ActiveMdiChild).PrimaryKeyMain)
                        {
                            if (args.Row.Table.Columns[pk.PrimaryKey].AutoIncrement)
                            {
                                pk.ValorPrimaryKey = nReg.ToString();
                                args.Row[pk.PrimaryKey] = nReg.ToString();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        protected static void OnRowUpdated_Filha(object sender, SqlRowUpdatedEventArgs args)
        {
            try
            {
                if (args.Row.RowState == DataRowState.Added)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select IDENT_CURRENT('");
                    sb.Append(args.Row.Table.TableName);
                    sb.Append("')");

                    SqlCommand cm = new SqlCommand(sb.ToString(), args.Command.Connection);

                    int nReg = 0;
                    try
                    {
                        nReg = Convert.ToInt32(cm.ExecuteScalar());
                    }
                    catch { }

                    if (nReg != 0)
                    {
                        foreach (DataColumn dc in args.Row.Table.PrimaryKey)
                        {
                            //-- Atualizar apenas se for Identity.
                            if (dc.AutoIncrement)
                            {
                                if (dc.ReadOnly)
                                    dc.ReadOnly = false;

                                args.Row[dc.Caption] = nReg;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        #endregion Trata os eventos pós-update

        #region Seta Bind dos controles para navegação e atualização.

        /// <summary>
        /// Seta todos os DataBind do formulário.
        /// </summary>
        /// <param name="controle">Nome do controle para o bind</param>
        /// <param name="fForm">formulário que o controle pertence</param>
        internal void setarValores_Bind(Control.ControlCollection controle, FormSet fForm)
        {
            if (string.IsNullOrEmpty(fForm.MainTabela))
            {
                MsgBox.Show("A propriedade MainTabela do form não foi preenchida."
                    , "Alerta"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
            else
            {
                foreach (Control ctrl in controle)
                {
                    //-- Caso o controle possua mais controles internos.
                    if (ctrl.Controls.Count > 0 && ctrl.GetType() != typeof(cf_DateEdit))
                    {
                        //-- Caso seja um container de controles o metodo se chama automaticamente.
                        setarValores_Bind(ctrl.Controls, fForm);
                    }
                    else
                    {
                        if (ctrl.GetType().GetInterface("IBaseControl_DB", true) != null)
                        {
                            Interfaces.IBaseControl_DB cc = (Interfaces.IBaseControl_DB)ctrl;
                            if (!string.IsNullOrEmpty(cc.Tabela) && !string.IsNullOrEmpty(cc.ControlSource))
                            {
                                //-- Inicia o Bind
                                Binding b;

                                try
                                {
                                    //-- Captura todas as colunas da tabela que o controle está vinculado.
                                    DataColumn dcc = fForm.DataSetLocal.Tables[cc.Tabela].Columns[cc.ControlSource];

                                    switch (ctrl.GetType().Name)
                                    {
                                        case "cf_TextBox":
                                            b = new Binding("Text", fForm.BindingSource[cc.Tabela], cc.ControlSource);
                                            cf_TextBox control_text = (cf_Bases.cf_TextBox)ctrl;

                                            switch (control_text.TipoControles)
                                            {
                                                case CompSoft.TipoControle.Data:
                                                    b.FormatString = "dd/MM/yyyy";
                                                    break;

                                                case CompSoft.TipoControle.Hora:
                                                    b.FormatString = "HH:mm";
                                                    break;

                                                case CompSoft.TipoControle.Moeda:
                                                    b.FormatString = "N2";
                                                    break;

                                                case CompSoft.TipoControle.Numerico:
                                                    b.FormatString = "N" + control_text.Qtde_Casas_Decimais.ToString();
                                                    break;

                                                case CompSoft.TipoControle.Indice:
                                                    b.FormatString = "F5";
                                                    break;

                                                case CompSoft.TipoControle.Inteiro:
                                                    b.FormatString = "D";
                                                    break;

                                                default:
                                                    b.FormatString = string.Empty;
                                                    break;
                                            }
                                            b.FormattingEnabled = true;
                                            b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                                            b.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;

                                            if (control_text.MaxLength == 32767)
                                            {
                                                //-- Define o tamanho maximo do controle.
                                                control_text.MaxLength = this.Captura_MaxCaracter(dcc);
                                            }

                                            //-- Verifica a obrigatoriedade dos controles
                                            if (!cc.Obrigatorio)
                                            {
                                                if (fForm.MainTabela.ToLower().Equals(cc.Tabela.ToLower()))
                                                    cc.Obrigatorio = !dcc.AllowDBNull;
                                            }
                                            break;

                                        case "cf_MaskedBox":
                                            b = new Binding("Text", fForm.BindingSource[cc.Tabela], cc.ControlSource);
                                            cf_MaskedBox control_mask = (cf_Bases.cf_MaskedBox)ctrl;

                                            b.FormattingEnabled = false;
                                            b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                                            b.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;

                                            if (control_mask.MaxLength == 32767)
                                            {
                                                //-- Define o tamanho maximo do controle.
                                                control_mask.MaxLength = this.Captura_MaxCaracter(dcc);
                                            }

                                            //-- Verifica a obrigatoriedade dos controles
                                            if (!cc.Obrigatorio)
                                            {
                                                if (fForm.MainTabela.ToLower().Equals(cc.Tabela.ToLower()))
                                                    cc.Obrigatorio = !dcc.AllowDBNull;
                                            }
                                            break;

                                        case "cf_ComboBox":
                                            b = new Binding("SelectedValue", fForm.BindingSource[cc.Tabela], cc.ControlSource);
                                            b.FormattingEnabled = false;
                                            b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                                            b.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;

                                            ((CompSoft.cf_Bases.cf_ComboBox)ctrl).SelectedIndex = -1;

                                            //-- Verifica a obrigatoriedade dos controles
                                            if (!cc.Obrigatorio)
                                            {
                                                if (fForm.MainTabela.ToLower().Equals(cc.Tabela.ToLower()))
                                                    cc.Obrigatorio = !dcc.AllowDBNull;
                                            }
                                            break;

                                        case "cf_CheckBox":
                                            b = new Binding("Checked", fForm.BindingSource[cc.Tabela], cc.ControlSource);
                                            b.FormattingEnabled = true;
                                            b.DataSourceNullValue = false;
                                            b.NullValue = false;
                                            b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                                            b.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
                                            break;

                                        case "cf_RadioButton":
                                            b = new Binding("Checked", fForm.BindingSource[cc.Tabela], cc.ControlSource);
                                            b.FormattingEnabled = true;
                                            b.DataSourceNullValue = false;
                                            b.NullValue = false;
                                            b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                                            b.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
                                            break;

                                        case "cf_DateEdit":
                                            b = new Binding("EditValue", fForm.BindingSource[cc.Tabela], cc.ControlSource);
                                            b.FormattingEnabled = true;
                                            b.NullValue = null;
                                            b.DataSourceNullValue = DBNull.Value;
                                            b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                                            b.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;

                                            //-- Verifica a obrigatoriedade dos controles
                                            if (!cc.Obrigatorio)
                                            {
                                                if (fForm.MainTabela.ToLower().Equals(cc.Tabela.ToLower()))
                                                    cc.Obrigatorio = !dcc.AllowDBNull;
                                            }
                                            break;

                                        default:
                                            b = new Binding("Value", fForm.BindingSource[cc.Tabela], cc.ControlSource);
                                            b.FormattingEnabled = true;
                                            b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                                            b.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
                                            b.FormatString = string.Empty;
                                            break;
                                    }

                                    try
                                    {
                                        ctrl.DataBindings.Add(b);
                                    }
                                    catch
                                    {
                                        string sMsg = string.Empty;
                                        sMsg += "ERRO AO REALIZAR O BIND:";
                                        sMsg += "\n\r     -Controle: " + ctrl.Name;
                                        sMsg += "\n\r   -DataSource: " + b.DataSource.ToString();
                                        sMsg += "\n\r       -Tabela: " + cc.Tabela;
                                        sMsg += "\n\r       -Coluna: " + cc.ControlSource;
                                        MsgBox.Show(sMsg
                                            , "Alerta"
                                            , MessageBoxButtons.OK
                                            , MessageBoxIcon.Error);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string sMsg = string.Empty;
                                    sMsg += "ERRO AO REALIZAR O BIND:";
                                    sMsg += "\n\r     -Controle: " + ctrl.Name;
                                    sMsg += "\n\r       -Tabela: " + cc.Tabela;
                                    sMsg += "\n\r       -Coluna: " + cc.ControlSource;
                                    sMsg += "\n\r" + ex.Message;
                                    MsgBox.Show(sMsg
                                        , "Alerta"
                                        , MessageBoxButtons.OK
                                        , MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion Seta Bind dos controles para navegação e atualização.

        #region Captura o número máximo de caracteres

        internal int Captura_MaxCaracter(DataColumn dcc)
        {
            int iRetorno = 0;
            if (dcc != null)
            {
                switch (dcc.DataType.Name.ToLower())
                {
                    case "string":
                        if (dcc.MaxLength >= 0)
                            iRetorno = dcc.MaxLength;
                        else
                            iRetorno = 32767;
                        break;

                    case "byte":  //-- Quando o campo for tinyint
                        iRetorno = 2;
                        break;

                    case "int16":
                        iRetorno = 4;
                        break;

                    case "int32":
                        iRetorno = 9;
                        break;

                    case "datetime":
                        iRetorno = 10;
                        break;

                    case "decimal":
                        iRetorno = 18;
                        break;
                }
            }

            return iRetorno;
        }

        #endregion Captura o número máximo de caracteres

        #region Define o estados dos controles de acordo com o status do formulário.

        /// <summary>
        /// Seta todos os DataBind do formulário.
        /// </summary>
        /// <param name="controle">Nome do controle para o bind</param>
        /// <param name="tp_Status">Status do formulário</param>
        internal void setarReadOnly_FormStatus(Control.ControlCollection controle, CompSoft.TipoFormStatus tp_Status)
        {
            foreach (Control ctrl in controle)
            {
                //-- Caso o controle possua mais controles internos.
                if (ctrl.Controls.Count > 0)
                {
                    //-- Chama o mesmo método para obter os controles.
                    //-- Este processo utiliza recurcividade.
                    setarReadOnly_FormStatus(ctrl.Controls, tp_Status);
                }

                if (ctrl.GetType().GetInterface("IBaseControl", true) != null)
                {
                    //-- Atualiza estado do controle
                    IBaseControl cc = ctrl as IBaseControl;
                    IBaseControl_DB cc_DB = null;
                    if (ctrl.GetType().GetInterface("IBaseControl_DB", true) != null)
                        cc_DB = cc as IBaseControl_DB;

                    switch (tp_Status)
                    {
                        case CompSoft.TipoFormStatus.Pesquisar:
                            cc.ReadOnly = true;
                            break;

                        case CompSoft.TipoFormStatus.Limpar:
                            cc.ReadOnly = false;
                            if (cc_DB != null && string.IsNullOrEmpty(cc_DB.ControlSource) && ctrl.GetType() == typeof(cf_TextBox))
                                ctrl.Text = string.Empty;

                            break;

                        case CompSoft.TipoFormStatus.Modificando:
                            //-- Verifica se o controle é identity
                            if (cc_DB != null && Control_IsIdentity(ref cc_DB))
                                cc.ReadOnly = true;
                            else
                                cc.ReadOnly = false;

                            break;

                        case CompSoft.TipoFormStatus.Nenhum:
                            cc.ReadOnly = true;
                            break;

                        case CompSoft.TipoFormStatus.Novo:
                            if (ctrl.GetType() == typeof(cf_TreeView))
                                ((cf_Bases.cf_TreeView)ctrl).Clear();

                            //-- Verifica se o controle é identity
                            if (cc_DB != null && this.Control_IsIdentity(ref cc_DB))
                                cc.ReadOnly = true;
                            else
                                cc.ReadOnly = false;

                            break;
                    }
                }
            }
        }

        #endregion Define o estados dos controles de acordo com o status do formulário.

        #region Verifica se o controle é Identity com referencia no Banco de dados

        /// <summary>
        /// Retorna se o controle está associado a uma coluna Identity
        /// </summary>
        /// <param name="ctrl">controle já customizado (Class CustonControl)</param>
        /// <returns>true/false se o controle é Identity</returns>
        private bool Control_IsIdentity(ref Interfaces.IBaseControl_DB ctrl)
        {
            bool bRetono = false;
            if (Propriedades.FormMain != null && Propriedades.FormMain.ActiveMdiChild != null)
            {
                FormSet f = (FormSet)Propriedades.FormMain.ActiveMdiChild;

                if (ctrl.Tabela == f.MainTabela && !string.IsNullOrEmpty(ctrl.ControlSource))
                {
                    DataColumn dc = f.DataSetLocal.Tables[ctrl.Tabela].Columns[ctrl.ControlSource];
                    bRetono = dc.AutoIncrement;
                }
            }

            return bRetono;
        }

        #endregion Verifica se o controle é Identity com referencia no Banco de dados

        #region Faz o queryby para os campos da tela

        /// <summary>
        /// Guarda o valor gerado pelo get_QueryBy
        /// </summary>
        internal string Condicoes_QueryBy
        {
            get { return sbCondicao.ToString(); }
            set
            {
                if (sbCondicao.Length > 0)
                    sbCondicao.Remove(0, sbCondicao.Length);
            }
        }

        /// <summary>
        /// Metodo que retorna a clausula WHERE com todos os campos preenchidos do formulário.
        /// </summary>
        /// <param name="controle">Coleção pai de todos os controles do form (Formulario.Controls)</param>
        internal void get_QueryBy(Control.ControlCollection controle, string sMainTabela)
        {
            foreach (Control ctrl in controle)
            {
                //-- Caso o controle possua mais controles internos.
                if (ctrl.Controls.Count > 0 && ctrl.GetType() != typeof(cf_DateEdit))
                {
                    //-- Chama o mesmo método para obter os controles.
                    //-- Este processo utiliza recursividade.
                    get_QueryBy(ctrl.Controls, sMainTabela);
                }
                else
                {
                    try
                    {
                        if (ctrl.GetType().GetInterface("IBaseControl_DB", true) != null)
                        {
                            Interfaces.IBaseControl_DB cc = (Interfaces.IBaseControl_DB)ctrl;
                            if (cc.Incluir_QueryBy && cc.Tabela.Equals(sMainTabela) && !string.IsNullOrEmpty(cc.ValueQueryBy))
                            {
                                //-- Verifica se inclui no queryby
                                switch (ctrl.GetType().Name)
                                {
                                    case "cf_TextBox":
                                        //-- Inclui o AND para tratar os dados.
                                        if (sbCondicao.Length > 0)
                                            sbCondicao.Append(" AND ");
                                        else
                                            sbCondicao.Append(" ");

                                        sbCondicao.Append(cc.Tabela_INNER);
                                        sbCondicao.Append(".");
                                        sbCondicao.Append(cc.ControlSource);

                                        switch (((Interfaces.ITextControl_DB)cc).TipoControles)
                                        {
                                            case CompSoft.TipoControle.Texto:
                                            case CompSoft.TipoControle.Geral:
                                                sbCondicao.Append(" like '");
                                                sbCondicao.Append(cc.ValueQueryBy);
                                                sbCondicao.Append("' ");
                                                break;

                                            case CompSoft.TipoControle.Indice:
                                            case CompSoft.TipoControle.Inteiro:
                                            case CompSoft.TipoControle.Moeda:
                                            case CompSoft.TipoControle.Numerico:
                                                sbCondicao.Append(" = ");
                                                sbCondicao.Append(cc.ValueQueryBy);
                                                break;

                                            default:
                                                sbCondicao.Append(" = '");
                                                sbCondicao.Append(cc.ValueQueryBy);
                                                sbCondicao.Append("' ");
                                                break;
                                        }
                                        break;

                                    case "cf_DateEdit":
                                        if (sbCondicao.Length > 0)
                                            sbCondicao.Append(" AND ");

                                        sbCondicao.Append(" convert(datetime, convert(varchar(10), ");
                                        sbCondicao.Append(cc.Tabela_INNER);
                                        sbCondicao.Append(".");
                                        sbCondicao.Append(cc.ControlSource);
                                        sbCondicao.Append(", 112)) = '");
                                        sbCondicao.Append(cc.ValueQueryBy);
                                        sbCondicao.Append("' ");
                                        break;

                                    default:
                                        //-- Inclui o AND para tratar os dados.
                                        if (sbCondicao.Length > 0)
                                            sbCondicao.Append(" AND ");
                                        else
                                            sbCondicao.Append(" ");

                                        sbCondicao.Append(cc.Tabela_INNER);
                                        sbCondicao.Append(".");
                                        sbCondicao.Append(cc.ControlSource);
                                        sbCondicao.Append(" like '");
                                        sbCondicao.Append(cc.ValueQueryBy);
                                        sbCondicao.Append("' ");

                                        break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MsgBox.Show("Erro ao executar QueryBy\r\n" + ctrl.Name + "\r\n" + ex.Message
                            , "Atenção"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion Faz o queryby para os campos da tela

        #region Limpa controles de uma determinada tabela.

        /// <summary>
        /// Limpa tabela de acordo com parametros.
        /// </summary>
        /// <param name="cc">Coleção de controles</param>
        internal void Limpa_Campos(Control.ControlCollection cc, string sTabela)
        {
            for (int i = 0; i < cc.Count; i++)
            {
                if (cc[i].Controls.Count > 0)
                {
                    this.Limpa_Campos(cc[i].Controls, sTabela);
                }
                else
                {
                    if (cc[i].GetType().GetInterface("IBaseControl_DB", true) != null)
                    {
                        Interfaces.IBaseControl_DB cc1 = (Interfaces.IBaseControl_DB)cc[i];
                        if (cc1.Tabela.ToLower().Equals(sTabela.ToLower()))
                        {
                            switch (cc[i].GetType().Name)
                            {
                                case "cf_TextBox":
                                case "cf_MaskedBox":
                                    ((Interfaces.IBaseControl_DB_Generic<string>)cc[i]).Value = string.Empty;
                                    break;

                                case "cf_DateEdit":
                                    ((Interfaces.IBaseControl_DB_Generic<DateTime?>)cc[i]).Value = null;
                                    break;

                                case "cf_ComboBox":
                                    ((Interfaces.IBaseControl_DB_Generic<object>)cc[i]).Value = DBNull.Value;
                                    break;

                                case "cf_CheckBox":
                                case "cf_RadioButton":
                                    ((Interfaces.IBaseControl_DB_Generic<bool>)cc[i]).Value = false;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        #endregion Limpa controles de uma determinada tabela.
    }
}