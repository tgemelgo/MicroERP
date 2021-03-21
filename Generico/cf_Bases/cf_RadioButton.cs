using CompSoft.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(RadioButton)), ToolboxItem(true)]
    public partial class cf_RadioButton : RadioButton, IBaseControl, IBaseControl_DB, IBaseControl_DB_Generic<bool>
    {
        private string sControlSource = string.Empty;
        private string sTabela;
        private string sTabela_INNER;

        private bool bValorAnterior = false,
                     bIncluirQueryBy = false;

        private string sGroup_Enable = string.Empty;

        #region "Propriedades"

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
        /// Identifica o valor antorior que o controle se encontrava.
        /// </summary>
        [Category("CompSoft")]
        public bool ValorAnterior
        {
            get { return bValorAnterior; }
            set { bValorAnterior = value; }
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
            get { return sTabela_INNER; }
            set { sTabela_INNER = value; }
        }

        #endregion "Propriedades"

        public cf_RadioButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        protected override void OnEnter(EventArgs e)
        {
            this.ValorAnterior = this.Checked;

            base.OnEnter(e);
        }

        #region IBaseControl<bool> Members

        [Category("CompSoft"), Bindable(BindableSupport.Yes)]
        public bool Value
        {
            get { return this.Checked; }
            set { this.Checked = value; }
        }

        #endregion IBaseControl<bool> Members

        #region IBaseControl Members

        /// <summary>
        /// Grupo para manipulação do arquivo.
        /// </summary>
        [Category("CompSoft")]
        string IBaseControl.Grupo
        {
            get { return sGroup_Enable; }
            set { sGroup_Enable = value; }
        }

        #endregion IBaseControl Members

        #region IBaseControl_DB<bool> Members

        /// <summary>
        /// Define se o campo é obrigatório.
        /// </summary>
        [Category("CompSoft")]
        public bool Obrigatorio
        {
            get { return false; }
            set { value = false; }
        }

        /// <summary>
        /// Mensagem Padrão de obrigatoriedade
        /// </summary>
        [Category("CompSoft")]
        public string MensagemObrigatorio
        {
            get { return string.Empty; }
            set { value = string.Empty; }
        }

        [Category("CompSoft")]
        public bool Remover_Mensagem
        {
            set { value = true; }
        }

        [Category("CompSoft")]
        public bool Incluir_QueryBy
        {
            get { return bIncluirQueryBy; }
            set { bIncluirQueryBy = value; }
        }

        [Category("CompSoft")]
        public string ValueQueryBy
        {
            get { return this.Checked ? "1" : "0"; }
        }

        [Category("CompSoft")]
        public bool ValidarCampos()
        {
            return true;
        }

        #endregion IBaseControl_DB<bool> Members

        #region IBaseControl_DB Members

        public bool ReadOnly
        {
            get { return !this.Enabled; }
            set { this.Enabled = !value; }
        }

        #endregion IBaseControl_DB Members
    }
}