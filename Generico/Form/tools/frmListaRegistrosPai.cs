using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Tools
{
    public partial class frmListaRegistrosPai : formBase
    {
        private FormSet f;
        private Type typeOf_Filtro;

        public frmListaRegistrosPai()
        {
            InitializeComponent();

            this.ShowDialog();
        }

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
                this.grdLista.BindingSource.Filter = string.Format("{0} {1} {2}"
                        , this.cboColunas.SelectedValue
                        , sTipoCompacacao
                        , sValorComparacao);
            }
            else
            {
                this.grdLista.BindingSource.Filter = string.Empty;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            //-- base.OnLoad(e);

            f = ((FormSet)compFrameWork.Propriedades.FormMain.ActiveMdiChild);
            this.grdLista.AutoGenerateColumns = true;
            this.grdLista.DataSource = f.BindingSource[f.MainTabela].DataSource;

            DataTable dt = new DataTable("xpto");
            dt.Columns.Add("Descricao", typeof(System.String));
            dt.Columns.Add("Coluna", typeof(System.String));

            foreach (DataGridViewColumn c in this.grdLista.Columns)
            {
                DataRow row = dt.NewRow();
                row["coluna"] = c.DataPropertyName;
                c.HeaderText = c.HeaderText.Replace("_", " ");
                row["descricao"] = c.HeaderText;
                dt.Rows.Add(row);
            }

            this.grdLista.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            this.cboColunas.DataSource = dt;
            this.cboColunas.DisplayMember = "Descricao";
            this.cboColunas.ValueMember = "coluna";
        }

        private void frmListaRegistrosPai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Close();
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
                DataTable dt = this.grdLista.BindingSource.DataSource as DataTable;
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
            this.cboColunas.SelectedValue = this.grdLista.Columns[e.ColumnIndex].DataPropertyName;
        }

        private void frmListaRegistrosPai_FormClosed(object sender, FormClosedEventArgs e)
        {
            //-- Atualiza o registro atual.
            f.Movimentar_Registro(Movimento.Atualizar_Atual);
        }
    }
}