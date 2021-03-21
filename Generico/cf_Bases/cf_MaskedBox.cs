using CompSoft.compFrameWork;
using CompSoft.Interfaces;
using CompSoft.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(MaskedTextBox)), ToolboxItem(true)]
    public partial class cf_MaskedBox : MaskedTextBox, IBaseControl, IBaseControl_DB, IBaseControl_DB_Generic<string>
    {
        //-- Objetos internos do objeto.
        private ErrorProvider ep = new ErrorProvider();

        //-- Propriedades do objeto.
        private Color cOldBackColor,
            cOldForeColor;

        private string sControlSource = string.Empty,
            sTabela,
            sTabela_INNER,
            sMensagemObrigatorio = "Campo obrigatório",
            sValorAnterior = string.Empty,
            sGrupo = string.Empty;

        private int iMaxLength = 32767;

        private bool bObrigatorio = false,
            bIncluiQueryBy = true;

        #region Verificar obrigatóriedade dos campos

        /// <summary>
        /// Valida o campo como obrigatório ou não
        /// </summary>
        /// <returns>Valido true/false</returns>
        public bool ValidarCampos()
        {
            Funcoes func;
            if (bObrigatorio
                && !string.IsNullOrEmpty(this.ControlSource)
                && Propriedades.FormMain != null
                && Propriedades.FormMain.ActiveMdiChild != null
                && func.Check_Extension(Propriedades.FormMain.ActiveMdiChild.GetType(), typeof(FormSet)))
            {
                FormSet f_MdiActivate = ((FormSet)Propriedades.FormMain.ActiveMdiChild);

                //-- Caso o campo seja para validação execute o HelpProvider.
                //-- Verifica qual é o modo do formulário, permitindo apenas como Novo ou Modificando.
                if (((FormSet)f_MdiActivate).FormStatus == TipoFormStatus.Novo || ((FormSet)f_MdiActivate).FormStatus == TipoFormStatus.Modificando)
                {
                    string sValor_Valida = string.Empty;

                    //-- Verifica o registro foi preenchido.
                    if (sTabela.Equals(f_MdiActivate.MainTabela.ToLower()))
                    {
                        if (!this.IsHandleCreated)
                        {
                            DataRowView row = (DataRowView)f_MdiActivate.BindingSource[sTabela].Current;
                            sValor_Valida = row[sControlSource].ToString();
                        }
                        else
                        {
                            sValor_Valida = this.Value;
                        }
                    }

                    //-- Verifica se o valor está OK.
                    if (string.IsNullOrEmpty(sValor_Valida))
                    {
                        ep.SetIconAlignment(this, ErrorIconAlignment.MiddleRight);
                        ep.SetIconPadding(this, -19);
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
                return true;
        }

        #endregion Verificar obrigatóriedade dos campos

        #region "Propriedades"

        /// <summary>
        /// Remove mensagem de obrigatoriedade
        /// </summary>
        [Category("CompSoft")]
        public bool Remover_Mensagem
        {
            set
            {
                if (value)
                    ep.SetError(this, "");
            }
        }

        /// <summary>
        /// Identifica a qual tabela o query by deve obedecer, caso a propriedade esteja vazia o sistema utiliza a propriedade tabela
        /// </summary>
        [Category("CompSoft")]
        public string Tabela_INNER
        {
            get { return sTabela_INNER; }
            set { sTabela_INNER = value; }
        }

        /// <summary>
        /// Defie o grupo de campos
        /// </summary>
        [Category("CompSoft")]
        public string Grupo
        {
            get { return sGrupo; }
            set { sGrupo = value; }
        }

        /// <summary>
        /// Define o tamanho maximo.
        /// </summary>
        [Category("CompSoft")]
        public override int MaxLength
        {
            get { return iMaxLength; }
            set { iMaxLength = value; }
        }

        /// <summary>
        /// Identifica a qual tabela o control source
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
        /// Identifica o tamanho maximo permitido no controle
        /// </summary>
        [Category("CompSoft")]
        public int Length
        {
            get { return iMaxLength; }
            set { iMaxLength = value; }
        }

        /// <summary>
        /// Idendifica que o campo é obrigatório ao salvar ou ao perder o foco.
        /// </summary>
        [Category("CompSoft")]
        public bool Obrigatorio
        {
            get { return bObrigatorio; }
            set { bObrigatorio = value; }
        }

        /// <summary>
        /// Mensagem que aparecerá identificando o campo como obrigatório.
        /// </summary>
        [Category("CompSoft")]
        public string MensagemObrigatorio
        {
            get { return sMensagemObrigatorio; }
            set { sMensagemObrigatorio = value; }
        }

        /// <summary>
        /// Armazena o valor antes da alteração.
        /// </summary>
        [Category("CompSoft")]
        public string ValorAnterior
        {
            get { return sValorAnterior; }
            set { sValorAnterior = value; }
        }

        /// <summary>
        /// Retorna o texto que está presente no campo.
        /// </summary>
        [Category("CompSoft")]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// Propriedade que identifica o nome da coluna da tabela do Banco de dados.
        /// </summary>
        [Category("CompSoft")]
        public string ControlSource
        {
            get { return sControlSource; }
            set { sControlSource = value; }
        }

        /// <summary>
        /// Incluir campo na função QueryBy
        /// </summary>
        [Category("CompSoft")]
        public bool Incluir_QueryBy
        {
            get { return bIncluiQueryBy; }
            set { bIncluiQueryBy = value; }
        }

        #endregion "Propriedades"

        public cf_MaskedBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void cf_TextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = cOldBackColor;
            this.ForeColor = cOldForeColor;
        }

        private void cf_TextBox_Enter(object sender, EventArgs e)
        {
            //-- Salva a configuração inicial
            cOldBackColor = this.BackColor;
            cOldForeColor = this.ForeColor;

            //-- Muda para a cor definida.
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;

            //-- Captura o valor inicial do controle.
            this.ValorAnterior = this.Text;

            this.SelectAll();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            //-- Chama o procedimento para validação do campo.
            this.ValidarCampos();

            base.OnValidating(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (!string.IsNullOrEmpty(this.Text))
                this.ValidarCampos();
        }

        private void cf_TextBox_Layout(object sender, LayoutEventArgs e)
        {
            this.ForeColor = Color.DimGray;
            this.BackColor = Color.WhiteSmoke;
        }

        #region IBaseControl Members

        /// <summary>
        /// Grupo de campos.
        /// </summary>
        [Category("CompSoft")]
        string IBaseControl.Grupo
        {
            get { return sGrupo; }
            set { sGrupo = value; }
        }

        #endregion IBaseControl Members

        #region IBaseControl_DB<string> Members

        /// <summary>
        /// Retorna o valor do controle
        /// </summary>
        [Category("CompSoft"), Bindable(BindableSupport.Yes)]
        public string Value
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        /// <summary>
        /// Retorna o valor para a função do QueryBy
        /// </summary>
        [Category("CompSoft")]
        public string ValueQueryBy
        {
            get { return this.Text; }
        }

        #endregion IBaseControl_DB<string> Members
    }
}