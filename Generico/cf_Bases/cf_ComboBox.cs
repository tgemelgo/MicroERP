using CompSoft.compFrameWork;
using CompSoft.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(ComboBox)), ToolboxItem(true)]
    public partial class cf_ComboBox : ComboBox, IBaseControl, IBaseControl_DB, IBaseControl_DB_Generic<object>
    {
        private ErrorProvider ep = new ErrorProvider(); //-- Objetos internos do objeto.

        //-- Variaveis do ambiente.
        private Color cOldBackColor,
            cOldForeColor;

        private string sControlSource = string.Empty,
            sTabela,
            sTabela_INNER,
            sMensagemObrigatorio = "Campo obrigatório",
            sSQLStatement = string.Empty,
            sGroup_Enable = string.Empty;

        private object oValorAnterior = null;

        private bool bObrigatorio = false
                    , bIncluirQueryBy = true
                    , bIncluirSelecione = false;

        #region Verificar obrigatóriedade dos campos

        /// <summary>
        /// Valida o campo como obrigatório ou não
        /// </summary>
        /// <returns>Valido true/false</returns>
        public bool ValidarCampos()
        {
            Funcoes func;
            if (bObrigatorio
                && !string.IsNullOrEmpty(sControlSource)
                && Propriedades.FormMain != null
                && Propriedades.FormMain.ActiveMdiChild != null
                && func.Check_Extension(Propriedades.FormMain.ActiveMdiChild.GetType(), typeof(FormSet)))
            {
                FormSet f_MdiActivate = ((FormSet)Propriedades.FormMain.ActiveMdiChild);

                //-- Caso o campo seja para validação execute o HelpProvider.
                //-- Verifica qual é o modo do formulário, permitindo apenas como Novo ou Modificando.
                if (f_MdiActivate.FormStatus == CompSoft.TipoFormStatus.Novo
                        || f_MdiActivate.FormStatus == CompSoft.TipoFormStatus.Modificando)
                {
                    string sValor_Combo = string.Empty;

                    //-- Verifica se o controle já existe em memoria, caso exista captura o valor do controle.
                    if (!this.IsHandleCreated)
                    {
                        DataRowView row = (DataRowView)f_MdiActivate.BindingSource[sTabela].Current;
                        sValor_Combo = row[sControlSource].ToString();
                    }
                    else
                    {
                        if (this.Value != null)
                            sValor_Combo = this.Value.ToString();
                    }

                    if (string.IsNullOrEmpty(sValor_Combo))
                    {
                        ep.SetIconAlignment(this, ErrorIconAlignment.MiddleRight);
                        ep.SetIconPadding(this, -35);
                        ep.SetError(this, sMensagemObrigatorio);
                        return false;
                    }
                    else
                    {
                        ep.SetError(this, "");
                        return true;
                    }
                }
                else
                {
                    ep.SetError(this, "");
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        #endregion Verificar obrigatóriedade dos campos

        #region Propriedades

        /// <summary>
        /// mostra como primeiro item 'Selecione -->'
        /// </summary>
        [Category("CompSoft"), Description("Mostra como primeiro item 'Selecione -->'")]
        public bool Incluir_Reg_Selecione
        {
            set { bIncluirSelecione = value; }
            get { return bIncluirSelecione; }
        }

        /// <summary>
        /// Remove mensagem de obrigatoriedade
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        public bool Remover_Mensagem
        {
            set
            {
                if (value)
                    ep.SetError(this, "");
            }
        }

        /// <summary>
        /// Identifica se o grupo ou grupos que o controle pertence.
        /// </summary>
        [Category("CompSoft")]
        public string Grupo
        {
            get { return sGroup_Enable; }
            set { sGroup_Enable = value; }
        }

        /// <summary>
        /// Define se o campo é obrigatório.
        /// </summary>
        [Category("CompSoft")]
        public bool Obrigatorio
        {
            get { return bObrigatorio; }
            set { bObrigatorio = value; }
        }

        /// <summary>
        /// Identifica a qual tabela o query by deve obedecer, caso a propriedade esteja vazia o sistema utiliza a propriedade tabela
        /// </summary>
        [Category("CompSoft")]
        public string Tabela_INNER
        {
            get
            {
                if (!string.IsNullOrEmpty(Propriedades.TituloMain))
                {
                    if (!string.IsNullOrEmpty(sTabela_INNER))
                        return sTabela_INNER;
                    else
                        return sTabela;
                }
                else
                    return sTabela_INNER;
            }
            set { sTabela_INNER = value; }
        }

        /// <summary>
        /// Mensagem que aparecerá caso o campo seja obrigatório.
        /// </summary>
        [Category("CompSoft")]
        public string MensagemObrigatorio
        {
            get { return sMensagemObrigatorio; }
            set { sMensagemObrigatorio = value; }
        }

        /// <summary>
        /// Query que alimentará o datasource do campo
        /// 1º campo sempre o valor que será gravado no banco de dados (ValueMember)
        /// Toda vez que esta propriedade é alterado o sistema automaticamente realimenta a listagem do controle
        /// </summary>
        [Category("CompSoft")]
        public string SQLStatement
        {
            get { return sSQLStatement; }
            set
            {
                sSQLStatement = value;
                if (!string.IsNullOrEmpty(Propriedades.StringConexao)
                        && !string.IsNullOrEmpty(this.SQLStatement))
                {
                    this.AlimentaCombo();
                }
            }
        }

        /// <summary>
        /// Alimenta e trata os itens do COMBO
        /// </summary>
        private void AlimentaCombo()
        {
            if (!string.IsNullOrEmpty(sSQLStatement))
            {
                //-- Monta combo
                DataTable dt = Data.SQL.Select(sSQLStatement, "xTmpSQL", false);

                //-- Adicione a linha Selecione
                if (bIncluirSelecione)
                {
                    DataRow newRow = dt.NewRow();

                    newRow[0] = -1;
                    newRow[1] = "01. Selecione -->";

                    dt.Rows.Add(newRow);

                    dt.DefaultView.Sort = dt.Columns[0].Caption + " ASC";
                }

                if (dt != null)
                {
                    this.DataSource = dt;
                    this.ValueMember = dt.Columns[0].Caption;
                    this.DisplayMember = dt.Columns[1].Caption;
                }
                else
                {
                    MsgBox.Show(string.Format("Ocorreu um erro na execução da query:\r\n\r\n'{0}'.", this.SQLStatement)
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
            }
            else
            {
                this.DataSource = null;
                this.ValueMember = string.Empty;
                this.DisplayMember = string.Empty;

                this.Items.Clear();
            }
        }

        /// <summary>
        /// Define qual é o nome do campo que vincula o campo com o banco de dados.
        /// </summary>
        [Category("CompSoft")]
        public string ControlSource
        {
            get { return sControlSource; }
            set { sControlSource = value; }
        }

        /// <summary>
        /// Define o nome da tabela que vincula o campo com o banco de dados.
        /// </summary>
        [Category("CompSoft")]
        public string Tabela
        {
            get { return string.IsNullOrEmpty(sTabela) ? string.Empty : sTabela.ToLower(); }
            set
            {
                if (value != null)
                    sTabela = value.ToLower();
                else
                    sTabela = value;
            }
        }

        /// <summary>
        /// Armazena o valor anterior a atualização.
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        public object ValorAnterior
        {
            get { return oValorAnterior; }
            set { oValorAnterior = value; }
        }

        /// <summary>
        /// Retorna valor do controle
        /// </summary>
        [Category("CompSoft"), Bindable(BindableSupport.Yes), Browsable(false)]
        public object Value
        {
            get { return base.SelectedValue; }
            set
            {
                if (value == null)
                    base.SelectedValue = DBNull.Value;
                else
                    base.SelectedValue = value;
            }
        }

        /// <summary>
        /// Incluir campo na função QueryBy
        /// </summary>
        [Category("CompSoft")]
        public bool Incluir_QueryBy
        {
            get { return bIncluirQueryBy; }
            set { bIncluirQueryBy = value; }
        }

        #endregion Propriedades

        public cf_ComboBox()
        {
            InitializeComponent();
        }

        private void cf_ComboBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = cOldBackColor;
            this.ForeColor = cOldForeColor;
        }

        private void cf_ComboBox_Enter(object sender, EventArgs e)
        {
            //-- Salva a configuração inicial
            cOldBackColor = this.BackColor;
            cOldForeColor = this.ForeColor;

            //-- Muda para a cor definida.
            this.BackColor = Color.WhiteSmoke;
            this.ForeColor = Color.Black;

            oValorAnterior = this.SelectedValue;
        }

        private void cf_ComboBox_Validating(object sender, CancelEventArgs e)
        {
            //-- Chama o procedimento para validação do campo.
            this.ValidarCampos();
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            if (this.SelectedIndex != -1 && this.IsHandleCreated)
                this.ValidarCampos();

            base.OnSelectedValueChanged(e);
        }

        private void cf_ComboBox_Layout(object sender, LayoutEventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            this.ForeColor = Color.DimGray;
        }

        #region IBaseControl_DB Members

        /// <summary>
        /// Retorna o valor para função do QueryBy
        /// </summary>
        [Category("CompSoft")]
        public string ValueQueryBy
        {
            get
            {
                if (this.SelectedIndex <= -1)
                    return string.Empty;
                else
                    return this.SelectedValue.ToString();
            }
        }

        [Category("CompSoft")]
        public bool ReadOnly
        {
            get { return !this.Enabled; }
            set { this.Enabled = !value; }
        }

        #endregion IBaseControl_DB Members
    }
}