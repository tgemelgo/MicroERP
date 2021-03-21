using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CompSoft.Tools
{
    internal partial class frmMostarLookUp : CompSoft.formBase
    {
        private string sSQLStatement = string.Empty;
        private string sValorCondicao = string.Empty;
        private string sValorSelecionado = string.Empty;
        private string sColunaRetorno = string.Empty;
        private int iColuna = 0;
        private Type typeOf_Filtro;

        #region "Declaração de propriedades"

        /// <summary>
        /// SQLStatement para consulta no lookup
        /// </summary>
        public string SQLStatement
        {
            get { return sSQLStatement; }
            set { sSQLStatement = value; }
        }

        /// <summary>
        /// Valor selecionado de acordo com a coluna referencia
        /// </summary>
        public string ValorSelecionado
        {
            get { return RegistroSelecionado[sColunaRetorno].ToString(); }
        }

        /// <summary>
        /// Registro selecionado no lookup
        /// </summary>
        public DataRow RegistroSelecionado
        {
            get { return ((DataRowView)this.grdLookup.BindingSource.Current).Row; }
        }

        /// <summary>
        /// Tabela que está alimentada no lookup
        /// </summary>
        public DataTable DataTable
        {
            get { return (DataTable)this.grdLookup.BindingSource.DataSource; }
        }

        #endregion "Declaração de propriedades"

        private void Filtrar_Registros()
        {
            if (this.chkValorBool.Visible
                        || (this.txtValor.Visible && !string.IsNullOrEmpty(this.txtValor.Text))
                        || (this.txtValorDateTime.Visible && this.txtValorDateTime.EditValue != null))
            {
                string sTipoCompacacao = string.Empty
                    , sValorComparacao = string.Empty;

                //-- Trata valores da coluna.
                switch (typeOf_Filtro.Name)
                {
                    //-- trata valores númericos
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Double":
                    case "Decimal":
                        sTipoCompacacao = " = ";
                        sValorComparacao = this.txtValor.Text.Replace(",", ".");
                        break;

                    case "Boolean":
                        sTipoCompacacao = " = ";
                        sValorComparacao = this.chkValorBool.Checked ? "1" : "0";
                        break;

                    //-- trata valores para data
                    case "DateTime":
                        sTipoCompacacao = " >= ";
                        sValorComparacao = string.Format("#{0} 00:00:00# and {1} <= #{0} 23:59:59#"
                            , Convert.ToDateTime(this.txtValorDateTime.EditValue).ToString("MM/dd/yyyy")
                            , this.cboColunas.SelectedValue);
                        break;

                    //-- trata outros tipos de valores
                    default:
                        sTipoCompacacao = " LIKE ";
                        sValorComparacao = string.Format("'{0}'", this.txtValor.Text);
                        break;
                }

                //-- Verifica se o processo pode continuar.
                this.grdLookup.BindingSource.Filter = string.Format("{0} {1} {2}"
                        , this.cboColunas.SelectedValue
                        , sTipoCompacacao
                        , sValorComparacao);
            }
            else
            {
                this.grdLookup.BindingSource.Filter = string.Empty;
            }
        }

        public frmMostarLookUp(string SQLStatement, string Condicao, int ReturnColumn)
        {
            InitializeComponent();

            sSQLStatement = SQLStatement;
            sValorCondicao = Condicao;
            iColuna = ReturnColumn;
        }

        public frmMostarLookUp(string SQLStatement, string Condicao, string ReturnColumn)
        {
            InitializeComponent();

            sSQLStatement = SQLStatement;
            sValorCondicao = Condicao;
            sColunaRetorno = ReturnColumn;
        }

        internal int CriarLookUp_Estrutura()
        {
            //-- Monta a instrução SQL
            if (string.IsNullOrEmpty(sValorCondicao))
                sValorCondicao = "%";
            else
                sValorCondicao = sValorCondicao.Trim();

            //-- Busca Dados no banco de dados e retorna um DataTable.
            sSQLStatement = string.Format(sSQLStatement.Replace("@", " like '{0}'"), sValorCondicao.Replace("'", string.Empty));
            DataTable dt = SQL.Select(sSQLStatement, "xTmpLook", false);

            //-- captura o nome da coluna do dataTable.
            if (string.IsNullOrEmpty(sColunaRetorno))
            {
                sColunaRetorno = dt.Columns[iColuna].Caption;
            }

            //-- Alimenta DataTable.
            BindingSource bs = new BindingSource(dt, null);
            this.grdLookup.AutoGenerateColumns = true;
            this.grdLookup.DataSource = bs;
            this.grdLookup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //-- Seleciona um registro caso o busca retorne apenas 1.
            if (bs.Count == 1)
                DialogResult = DialogResult.OK;

            return bs.Count;
        }

        protected override void OnLoad(EventArgs e)
        {
            //            base.OnLoad(e);
            DataTable dt = new DataTable("xpto");
            dt.Columns.Add("Descricao", typeof(System.String));
            dt.Columns.Add("Coluna", typeof(System.String));

            foreach (DataGridViewColumn c in this.grdLookup.Columns)
            {
                DataRow row = dt.NewRow();
                row["coluna"] = c.DataPropertyName;
                c.HeaderText = c.HeaderText.Replace("_", " ");
                row["descricao"] = c.HeaderText;
                dt.Rows.Add(row);
            }

            this.grdLookup.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            this.cboColunas.DataSource = dt;
            this.cboColunas.DisplayMember = "Descricao";
            this.cboColunas.ValueMember = "coluna";
        }

        private void frmMostarLookUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void grdLookup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //-- Verifica se for precionada a tecla enter.
            if (e.KeyChar == 13)
            {
                this.Filtrar_Registros();
            }
        }

        private void cboColunas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboColunas.Items.Count >= 0 && this.cboColunas.SelectedValue != null)
            {
                //-- Captura o tipo de dado da coluna selecionada
                DataTable dt = this.grdLookup.BindingSource.DataSource as DataTable;
                if (dt.Columns[this.cboColunas.SelectedValue.ToString()] != null && dt.Columns[this.cboColunas.SelectedValue.ToString()].DataType != null)
                {
                    typeOf_Filtro = dt.Columns[this.cboColunas.SelectedValue.ToString()].DataType;

                    //-- Trata valores da coluna.
                    switch (typeOf_Filtro.Name)
                    {
                        //-- trata valores númericos
                        case "Double":
                        case "Decimal":
                            this.txtValor.TipoControles = TipoControle.Numerico;
                            this.txtValor.Qtde_Casas_Decimais = 2;
                            this.txtValor.Visible = true;
                            this.chkValorBool.Visible = false;
                            this.txtValorDateTime.Visible = false;
                            break;

                        case "Int16":
                        case "Int32":
                        case "Int64":
                            this.txtValor.TipoControles = TipoControle.Numerico;
                            this.txtValor.Qtde_Casas_Decimais = 0;
                            this.txtValor.Visible = true;
                            this.chkValorBool.Visible = false;
                            this.txtValorDateTime.Visible = false;
                            break;

                        case "Boolean":
                            this.txtValor.Visible = false;
                            this.chkValorBool.Visible = true;
                            this.txtValorDateTime.Visible = false;
                            break;

                        //-- trata valores para data
                        case "DateTime":
                            this.txtValor.Visible = false;
                            this.chkValorBool.Visible = false;
                            this.txtValorDateTime.Visible = true;
                            break;

                        //-- trata outros tipos de valores
                        default:
                            this.txtValor.TipoControles = TipoControle.Geral;
                            this.txtValor.Qtde_Casas_Decimais = 0;
                            this.txtValor.Visible = true;
                            this.chkValorBool.Visible = false;
                            this.txtValorDateTime.Visible = false;
                            break;
                    }
                }
            }

            this.txtValor.Text = string.Empty;
            this.chkValorBool.Checked = false;
            this.txtValorDateTime.EditValue = null;
        }

        private void chkValorBool_CheckedChanged(object sender, EventArgs e)
        {
            this.Filtrar_Registros();
        }

        private void txtValorDateTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            //-- Verifica se for precionada a tecla enter.
            if (e.KeyChar == 13)
            {
                this.Filtrar_Registros();
            }
        }

        private void grdLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.cboColunas.SelectedValue = this.grdLookup.Columns[e.ColumnIndex].DataPropertyName;
        }
    }
}