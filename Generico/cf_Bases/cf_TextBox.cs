using CompSoft.compFrameWork;
using CompSoft.Interfaces;
using CompSoft.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(TextBox)), ToolboxItem(true)]
    public partial class cf_TextBox : TextBox, IBaseControl, IBaseControl_DB, IBaseControl_DB_Generic<string>, ITextControl_DB
    {
        //-- Objetos internos do objeto.
        private ErrorProvider ep = new ErrorProvider();

        //-- Propriedades do objeto.
        private Color cOldBackColor,
            cOldForeColor;

        private TipoControle nTipoControle = TipoControle.Geral;

        private int iColunaLookUp = 0,
            iQtdeCasasDecimais = 0;

        private string sControlSource = string.Empty,
            sTabela,
            sTabela_INNER,
            sMensagemObrigatorio = "Campo obrigatório",
            sValorAnterior = string.Empty,
            sGroup_Enable = string.Empty,
            sSQLStatement = string.Empty;

        private bool bObrigatorio = false,
            bIncluiQuery = true,
            bLookUp = false;

        private DataRow dtLookUp_Retorno;

        private DataTable dtLookup;

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
                if (f_MdiActivate.FormStatus == TipoFormStatus.Novo
                        || f_MdiActivate.FormStatus == TipoFormStatus.Modificando)
                {
                    string sValor_Valida = string.Empty;

                    //-- Verifica o registro foi preenchido.
                    if (sTabela.Equals(f_MdiActivate.MainTabela.ToLower()))
                    {
                        if (!this.IsHandleCreated || !this.Parent.IsHandleCreated)
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

        #region Propriedades

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
        [Category("CompSoft"), Description("Nome do grupo para ativar/destivar controle")]
        public string Grupo
        {
            get { return sGroup_Enable; }
            set { sGroup_Enable = value; }
        }

        /// <summary>
        /// Permite definir se o campo fará parte do query by.
        /// </summary>
        [Category("CompSoft"), Description("Permite definir se o campo fará parte do query by.")]
        public bool Incluir_QueryBy
        {
            get { return bIncluiQuery; }
            set { bIncluiQuery = value; }
        }

        /// <summary>
        /// Identifica a coluna que contem o valor que deverá ser mostrado do combo
        /// </summary>
        [Category("CompSoft"), Description("Número da coluna que identifica o valor de retorno do LookUp")]
        public int Coluna_LookUp
        {
            get { return iColunaLookUp; }
            set { iColunaLookUp = value; }
        }

        /// <summary>
        /// Identifica a qual tabela o control source
        /// </summary>
        [Category("CompSoft"), Description("Tabela para o sistema realizar o Bind")]
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
        /// Identifica a qual tabela o SEARCH deve obedecer, caso a propriedade esteja vazia o sistema utiliza a propriedade tabela
        /// </summary>
        [Category("CompSoft"), Description("Nome da tabela ou alias que o sistema utiliza para realizar o QueryBy")]
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
        /// Idendifica que o campo é obrigatório ao salvar ou ao perder o foco.
        /// </summary>
        [Category("CompSoft"), Description("Idendifica que o campo é obrigatório ao salvar ou ao perder o foco")]
        public bool Obrigatorio
        {
            get { return bObrigatorio; }
            set
            {
                bObrigatorio = value;
                if (ep != null)
                    ep.SetError(this, "");
            }
        }

        /// <summary>
        /// DataRow que será retornado com o valor selecionada no lookup
        /// </summary>
        [Category("CompSoft"), Description("DataRow que será retornado com o valor selecionada no lookup"), Browsable(false)]
        public DataRow LookUpRetorno
        {
            get { return dtLookUp_Retorno; }
        }

        /// <summary>
        /// Mensagem que aparecerá identificando o campo como obrigatório.
        /// </summary>
        [Category("CompSoft"), Description("Mensagem que aparecerá identificando o campo como obrigatório")]
        public string MensagemObrigatorio
        {
            get { return sMensagemObrigatorio; }
            set { sMensagemObrigatorio = value; }
        }

        /// <summary>
        /// Armazena o valor antes da alteração.
        /// </summary>
        [Category("CompSoft"), Browsable(false)]
        public string ValorAnterior
        {
            get { return sValorAnterior; }
            set { sValorAnterior = value; }
        }

        /// <summary>
        /// Identifica se o campo é lookup
        /// </summary>
        [Category("CompSoft"), Description("Identifica se o campo é lookup")]
        public bool LookUp
        {
            get { return bLookUp; }
            set { bLookUp = value; }
        }

        /// <summary>
        /// Query que faz o lookup para o campo
        /// para filtrar coloque o Where NomeCampo@
        /// assim a @ será substituida pelo valor atual do campo.
        /// </summary>
        [Category("CompSoft"), Description("Query que faz o lookup para o campo para filtrar coloque o Where NomeCampo@\r\nassim a @ será substituida pelo valor atual do campo")]
        public string SQLStatement
        {
            get { return sSQLStatement; }
            set { sSQLStatement = value; }
        }

        /// <summary>
        /// Identifica os valores que o controle poderá aceitar.
        /// </summary>
        [Category("CompSoft"), Description("Identifica os valores que o controle poderá aceitar")]
        public TipoControle TipoControles
        {
            get { return nTipoControle; }
            set { nTipoControle = value; }
        }

        /// <summary>
        /// Retorna o valor do controle
        /// </summary>
        [Category("CompSoft"), Bindable(BindableSupport.Yes), Browsable(false)]
        public string Value
        {
            get { return this.Text; }
            set
            {
                this.Text = value;
            }
        }

        /// <summary>
        /// Retorna o texto que está presente no campo.
        /// </summary>
        [Category("CompSoft"), Description("Retorna o texto que está presente no campo")]
        public override string Text
        {
            get
            {
                string sRetorno = base.Text;
                switch ((TipoControle)nTipoControle)
                {
                    case TipoControle.Moeda:
                        //int iDecimal = sRetorno.LastIndexOfAny(new char[] { ',', '.' });
                        //if (iDecimal >= 1)
                        //{
                        //    sRetorno = string.Concat(sRetorno.Substring(0, iDecimal), '.', sRetorno.Substring(iDecimal +1));
                        //    //sInicioString = sInicioString.Replace(".", string.Empty).Replace(",", string.Empty);
                        //    //sRetorno = sInicioString + sRetorno.Substring(iDecimal);
                        //}

                        sRetorno = sRetorno.Replace(".", ",");

                        if (!string.IsNullOrEmpty(sRetorno))
                        {
                            decimal newValue;
                            if (!decimal.TryParse(sRetorno, out newValue))
                                sRetorno = "0";
                            else
                                sRetorno = newValue.ToString();
                        }
                        else
                            sRetorno = null;

                        return sRetorno;

                    case TipoControle.Data:
                        if (string.IsNullOrEmpty(sRetorno))
                            return null;
                        else
                            return sRetorno;

                    default:
                        if (!string.IsNullOrEmpty(Propriedades.StringConexao) && string.IsNullOrEmpty(sRetorno))
                            return null;
                        else
                            return sRetorno;
                }
            }
            set
            {
                //-- Trata valores caso sejam monetários
                switch ((TipoControle)nTipoControle)
                {
                    case TipoControle.Moeda:
                        if (string.IsNullOrEmpty(value))
                            base.Text = null;
                        else
                            base.Text = value.Replace(".", ",");
                        break;

                    case TipoControle.Data:
                        if (string.IsNullOrEmpty(value))
                            base.Text = null;
                        else
                            base.Text = value;
                        break;

                    default:
                        base.Text = value;
                        break;
                }
            }
        }

        /// <summary>
        /// Propriedade que identifica o nome da coluna da tabela do Banco de dados.
        /// </summary>
        [Category("CompSoft"), Description("Propriedade que identifica o nome da coluna da tabela do Banco de dados")]
        public string ControlSource
        {
            get { return sControlSource; }
            set { sControlSource = value; }
        }

        /// <summary>
        /// Get/Set quantidade de casas decimais que o controle permite.
        /// Funciona apenas em campo númerico.
        /// </summary>
        [Category("CompSoft"), Description("Get/Set quantidade de casas decimais que o controle permite.\r\nFunciona apenas em campo númerico.")]
        public int Qtde_Casas_Decimais
        {
            get { return iQtdeCasasDecimais; }
            set { iQtdeCasasDecimais = value; }
        }

        #endregion Propriedades

        #region Metodo de tratamento do LookUp

        /// <summary>
        /// Verifica se o campo existe no ControlSource e preenche o mesmo
        /// </summary>
        private void preencheCampoControlSource()
        {
            if (!string.IsNullOrEmpty(sTabela))
            {
                //-- Varre todas as colunas da tabela do lookup.
                FormSet f = Propriedades.FormMain.ActiveMdiChild as FormSet;
                if (f.FormStatus == TipoFormStatus.Novo || f.FormStatus == TipoFormStatus.Modificando)
                {
                    foreach (System.Data.DataColumn dc in dtLookup.Columns)
                    {
                        //-- Verifica se a coluna da com o nome do look up existe no grid.
                        if (dc.Caption.ToLower() != sControlSource.ToLower() && f.CurrentRow.Row.Table.Columns.Contains(dc.Caption))
                        {
                            if (dtLookUp_Retorno != null)
                                f.CurrentRow[dc.Caption] = dtLookUp_Retorno[dc.Caption];
                            else
                                f.CurrentRow[dc.Caption] = DBNull.Value;
                        }
                    }

                    f.BindingSource[sTabela].EndEdit();
                }
            }
        }

        /// <summary>
        /// Faz o lookup e retorna o registro localizado com o dado digitado no campo
        /// </summary>
        public bool FazerLookUp(bool MostrarLOOK)
        {
            bool bRetorno = true;
            if (this.LookUp && !string.IsNullOrEmpty(sSQLStatement))
            {
                if (Propriedades.FormMain != null && Propriedades.FormMain.ActiveMdiChild != null)
                {
                    FormSet fForm = ((FormSet)Propriedades.FormMain.ActiveMdiChild);
                    if (fForm.FormStatus == TipoFormStatus.Novo ||
                        fForm.FormStatus == TipoFormStatus.Modificando ||
                        fForm.FormStatus == TipoFormStatus.Limpar)
                    {
                        if (MostrarLOOK || (!MostrarLOOK && !string.IsNullOrEmpty(this.Text)))
                        {
                            frmMostarLookUp f = new frmMostarLookUp(this.SQLStatement, this.Text, iColunaLookUp);
                            int iTotalReg = f.CriarLookUp_Estrutura();
                            dtLookup = f.DataTable; //-- tabela com o resultado da pesquisa.

                            switch (iTotalReg)
                            {
                                case 0:
                                    bRetorno = false;
                                    dtLookUp_Retorno = null;
                                    break;

                                case 1:
                                    dtLookUp_Retorno = f.RegistroSelecionado;
                                    this.Text = f.ValorSelecionado;
                                    break;

                                default:
                                    if (MostrarLOOK)
                                    {
                                        if (f.ShowDialog() == DialogResult.OK)
                                        {
                                            if (!string.IsNullOrEmpty(f.ValorSelecionado))
                                            {
                                                dtLookUp_Retorno = f.RegistroSelecionado;
                                                this.Text = f.ValorSelecionado;
                                                preencheCampoControlSource();
                                            }
                                            else
                                            {
                                                bRetorno = false;
                                            }
                                        }
                                        else
                                        {
                                            bRetorno = false;
                                        }
                                    }
                                    break;
                            }

                            f.Dispose();
                        }
                    }
                }
            }

            return bRetorno;
        }

        #endregion Metodo de tratamento do LookUp

        public cf_TextBox()
        {
            InitializeComponent();
        }

        private void cf_TextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = cOldBackColor;
            this.ForeColor = cOldForeColor;
        }

        private void cf_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                //-- Salva a configuração inicial
                cOldBackColor = this.BackColor;
                cOldForeColor = this.ForeColor;

                //-- Muda para a cor definida.
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;

                //-- Captura o valor inicial do controle.
                this.ValorAnterior = this.Text;
                dtLookUp_Retorno = null;

                if (this.TipoControles == TipoControle.Data && !string.IsNullOrEmpty(this.Text))
                    this.Text = this.Text.Replace(CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator, "");

                this.SelectAll();
            }
            catch { }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (!string.IsNullOrEmpty(base.Text) && base.Text.Length > base.MaxLength)
                base.Text = base.Text.Substring(0, base.MaxLength - 1);

            if (!string.IsNullOrEmpty(base.Text))
                this.ValidarCampos();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            //-- Chama o procedimento para validação do campo.
            if (this.ValidarCampos())
            {
                if (!string.IsNullOrEmpty(this.Text))
                {
                    if (bLookUp)
                    {
                        //-- Verifica se o valor digitado é um lookup válido.
                        if (!this.FazerLookUp(false))
                        {
                            base.OnValidating(e);
                            e.Cancel = true;
                        }

                        if (!string.IsNullOrEmpty(sTabela) && dtLookup != null)
                        {
                            preencheCampoControlSource();
                        }
                    }

                    //-- Faz o tratamento caso o caso a ação não tenha sido cancelada.
                    if (!e.Cancel)
                    {
                        //-- Trata os valores de HORA
                        if (this.TipoControles == TipoControle.Hora && this.Text.IndexOf(":") <= 0)
                        {
                            try
                            {
                                if (int.Parse(this.Text.Substring(0, 2)) > 24 || int.Parse(this.Text.Substring(2, 2)) > 59)
                                    this.Text = string.Empty;
                                else
                                    this.Text = string.Format("{0}:{1}", this.Text.Substring(0, 2), this.Text.Substring(2, 2));
                            }
                            catch
                            {
                                this.Text = string.Empty;
                            }
                        }

                        //-- Trata valores caso seja numerico com casas decimais
                        if (this.TipoControles == TipoControle.Indice ||
                            this.TipoControles == TipoControle.Moeda ||
                            this.TipoControles == TipoControle.Numerico)
                        {
                            try
                            {
                                string sFormat_String = string.Empty;
                                string sDecimal = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                                //-- Mascara
                                if (TipoControles == TipoControle.Moeda)
                                    sFormat_String = "0.00";

                                //-- trata valores
                                string sTexto = this.Text;
                                int iDecimal = sTexto.LastIndexOfAny(new char[] { ',', '.' });
                                string sInicioString = sTexto.Substring(0, iDecimal);
                                sInicioString = sInicioString.Replace(".", string.Empty).Replace(",", string.Empty);
                                sTexto = sInicioString + sTexto.Substring(iDecimal);

                                //-- Seta valores
                                this.Text = Convert.ToDecimal(sTexto.Replace(",", sDecimal).Replace(".", sDecimal)).ToString(sFormat_String);
                            }
                            catch { }
                        }
                    }
                }
            }

            base.OnValidating(e);
        }

        private void cf_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //-- Libera a utilização do BackSpace.
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                e.Handled = false;
                return;
            }

            //-- Trata o valor digitado para aceitar somente Text
            if (this.TipoControles == TipoControle.Texto)
            {
                //-- Verifica existem apenas números digitados.
                if (Convert.ToInt32(Convert.ToChar(e.KeyChar.ToString().ToLower())) < Convert.ToInt32(Convert.ToChar("a")) ||
                    Convert.ToInt32(Convert.ToChar(e.KeyChar.ToString().ToLower())) > Convert.ToInt32(Convert.ToChar("z")))
                    e.Handled = true;

                //-- Permite a inclusão de espaços
                if (Convert.ToInt32(e.KeyChar) == 32)
                    e.Handled = false;
            }

            //-- Trata o valor digitado para aceitar somente numeros
            if (this.TipoControles == TipoControle.Moeda
                | this.TipoControles == TipoControle.Numerico
                | this.TipoControles == TipoControle.Data
                | this.TipoControles == TipoControle.Indice
                | this.TipoControles == TipoControle.Inteiro
                | this.TipoControles == TipoControle.Hora)
            {
                //-- Verifica existem apenas números digitados.
                if (Convert.ToInt32(e.KeyChar) < Convert.ToInt32(Convert.ToChar("0")) ||
                        Convert.ToInt32(e.KeyChar) > Convert.ToInt32(Convert.ToChar("9")))
                {
                    if (this.TipoControles != TipoControle.Data & this.TipoControles != TipoControle.Inteiro)
                    {
                        if (e.KeyChar == Convert.ToChar(".")
                            || e.KeyChar == Convert.ToChar(",")
                            || e.KeyChar == Convert.ToChar("-"))
                            e.Handled = false;
                        else
                            e.Handled = true;
                    }
                    else
                        e.Handled = true;
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            //-- Permite a visualização dos dados atravéz de um clique com o botão direito, caso o mesmo possibilite essa funcionalidade.
            if (bLookUp && e.Button == MouseButtons.Right)
            {
                //-- Fazer o lookup no banco de dados.
                this.FazerLookUp(true);
            }
        }

        private void cf_TextBox_Layout(object sender, LayoutEventArgs e)
        {
            if (!bLookUp)
            {
                this.ForeColor = Color.DimGray;
                this.BackColor = Color.WhiteSmoke;
            }
            else
            {
                this.ForeColor = Color.Black;
                this.BackColor = ColorTranslator.FromOle(16573370);
            }
        }

        #region IBaseControl_DB<string> Members

        public string ValueQueryBy
        {
            get
            {
                switch (nTipoControle)
                {
                    case TipoControle.Data:
                        return this.Text != null ? Convert.ToDateTime(this.Text).ToString("yyyyMMdd") : string.Empty;

                    default:
                        return this.Text;
                }
            }
        }

        #endregion IBaseControl_DB<string> Members
    }
}