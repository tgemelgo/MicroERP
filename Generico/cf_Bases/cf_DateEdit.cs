using CompSoft.compFrameWork;
using CompSoft.Interfaces;
using DevExpress.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    public partial class cf_DateEdit : DateEdit, IBaseControl, IBaseControl_DB, IBaseControl_DB_Generic<DateTime?>
    {
        //-- Variaveis do ambiente.
        private ErrorProvider ep = new ErrorProvider(); //-- Objetos internos do objeto.

        private Color cOldBackColor,
            cOldForeColor;

        private string sControlSource,
            sTabela,
            sTabela_INNER,
            sGroup_Enable = string.Empty,
            sMensagemObrigatorio = "Campo obrigatório";

        private bool bObrigatorio = false,
                     bIncluirQueryby = true;

        private object oValorAnterior;

        #region Propriedades

        /*protected override PopupBaseForm PopupForm
        {
            get
            {
                return p;
            }
        }*/

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
        /// Mensagem que aparecerá caso o campo seja obrigatório.
        /// </summary>
        [Category("CompSoft")]
        public string MensagemObrigatorio
        {
            get { return sMensagemObrigatorio; }
            set { sMensagemObrigatorio = value; }
        }

        /// <summary>
        /// Identifica o valor antorior que o controle se encontrava.
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        public object ValorAnterior
        {
            get { return oValorAnterior; }
            set { oValorAnterior = value; }
        }

        /// <summary>
        /// Nome do campo que este controle se referenciará.
        /// </summary>
        [Category("CompSoft")]
        public string ControlSource
        {
            get { return sControlSource; }
            set { sControlSource = value; }
        }

        /// <summary>
        /// Nome da tabela que este controle se referencia.
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
        /// Set / Get valor do controle
        /// </summary>
        [Category("CompSoft"), Bindable(BindableSupport.Yes), Browsable(false)]
        public DateTime? Value
        {
            get
            {
                if (this.EditValue == null)
                    return null;
                else
                    return Convert.ToDateTime(this.EditValue);
            }
            set { this.EditValue = value; }
        }

        /// <summary>
        /// Indica se o controle entrerá na função de QueryBy
        /// </summary>
        [Category("CompSoft")]
        public bool Incluir_QueryBy
        {
            get { return bIncluirQueryby; }
            set { bIncluirQueryby = value; }
        }

        #endregion Propriedades

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
                    object oValor_Campo = this.EditValue;

                    if (oValor_Campo == null || oValor_Campo == DBNull.Value)
                    {
                        ep.SetIconAlignment(this, ErrorIconAlignment.MiddleRight);
                        ep.SetIconPadding(this, -33);
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

        #region Propriedades padrão do controle

        private void Set_Propriedades_Padrao()
        {
            try
            {
                this.EditValue = null;
            }
            catch { }

            this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            this.Properties.Buttons.Clear();
            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo
                    , ""
                    , -1
                    , true
                    , true
                    , false
                    , DevExpress.Utils.HorzAlignment.Center
                    , null
                    , new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)))});

            this.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Properties.Mask.EditMask = "dd/MM/yyyy";

            Funcoes func;
            this.Properties.MaxValue = func.Ultimo_Dia_Mes(Funcoes.Tipo_Dia.Dias_Corrido, DateTime.Now.AddYears(150));
            this.Properties.MinValue = new DateTime(1901, 01, 01);

            this.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Properties.Mask.BeepOnError = true;
            this.Properties.Mask.SaveLiteral = false;
            this.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton()});

            this.Properties.VistaDisplayMode = DefaultBoolean.False;
            this.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
        }

        #endregion Propriedades padrão do controle

        protected override PopupBaseForm CreatePopupForm()
        {
            PopupDateEditForm form = base.CreatePopupForm() as PopupDateEditForm;

            form.Calendar.ClearButton.Appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
            form.Calendar.ClearButton.Text = "Limpar";

            form.Calendar.TodayButton.Appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
            form.Calendar.TodayButton.Text = "Hoje";

            return form;
        }

        public cf_DateEdit()
        {
            InitializeComponent();

            //-- Define as propriedades padrão.
            this.Set_Propriedades_Padrao();
        }

        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = cOldBackColor;
            this.ForeColor = cOldForeColor;

            base.OnLeave(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            //-- Salva a configuração inicial
            cOldBackColor = this.BackColor;
            cOldForeColor = this.ForeColor;

            //-- Muda para a cor definida.
            this.BackColor = Color.WhiteSmoke;
            this.ForeColor = Color.Black;

            oValorAnterior = this.EditValue;

            base.OnEnter(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            this.ValidarCampos();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            this.BackColor = Color.WhiteSmoke;
            this.ForeColor = Color.DimGray;

            base.OnLayout(levent);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (this.EditValue != null && this.EditValue != DBNull.Value)
            {
                this.ValidarCampos();
                this.EditValue = Convert.ToDateTime(Convert.ToDateTime(this.EditValue).ToShortDateString());
            }
        }

        #region IBaseControl_DB<DateTime> Members

        public string ValueQueryBy
        {
            get
            {
                if (this.EditValue == null || this.EditValue == DBNull.Value)
                    return string.Empty;
                else
                    return Convert.ToDateTime(this.EditValue).ToString("yyyyMMdd");
            }
        }

        public bool ReadOnly
        {
            get { return !this.Enabled; }
            set { this.Enabled = !value; }
        }

        #endregion IBaseControl_DB<DateTime> Members
    }
}