using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0053 : CompSoft.FormSet
    {
        #region Contrutores

        public f0053()
        {
            string sSQL = string.Empty;

            sSQL += "SELECT ";
            sSQL += " est.Estoque ";
            sSQL += ", est.Empresa ";
            sSQL += ", est.Produto ";
            sSQL += ", est.Quantidade_Disponivel ";
            sSQL += ", est.Quantidade_Reservada ";
            sSQL += ", est.Quantidade_Total ";
            sSQL += ", pro.desc_produto ";
            sSQL += ", emp.razao_social ";
            sSQL += "    FROM estoques est ";
            sSQL += "INNER JOIN produtos pro ON pro.produto = est.produto ";
            sSQL += "left outer JOIN empresas emp ON emp.empresa = est.empresa ";
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Estoques"
                    , sSQL));

            InitializeComponent();
        }

        #endregion Contrutores

        private void f0053_Load(object sender, EventArgs e)
        {
            this.cboEmpresa.SelectedIndex = -1;
        }

        private void f0053_user_AfterRefreshData()
        {
            this.grdEstoque.DataSource = this.DataSetLocal.Tables["Estoques"];
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodProduto.LookUpRetorno != null)
                this.txtDescProduto.Text = this.txtCodProduto.LookUpRetorno[1].ToString();
        }

        private void txtDescProduto_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtDescProduto.LookUpRetorno != null)
                this.txtCodProduto.Text = this.txtDescProduto.LookUpRetorno[0].ToString();
        }

        private void f0053_user_AfterClear()
        {
            this.cboEmpresa.SelectedIndex = -1;
            this.rbDisponivel.Checked = false;
            this.rbReservado.Checked = false;
            this.rbTotal.Checked = false;
            this.rbMaior.Checked = false;
            this.rbMenor.Checked = false;
            this.rbIgual.Checked = false;
            this.txtQuantidade.Text = string.Empty;
        }

        public override string user_Query(string TabelaAtual)
        {
            return Filtra_Produtos();
        }

        public bool Filtra_Quantidade()
        {
            bool bReturn = false,
                 b1 = (this.rbDisponivel.Checked || this.rbReservado.Checked || this.rbTotal.Checked),
                 b2 = (this.rbMaior.Checked || this.rbMenor.Checked || this.rbIgual.Checked),
                 b3 = (!string.IsNullOrEmpty(this.txtQuantidade.Text));

            bReturn = ((b1 && b2 && b3) || (!b1 && !b2 && !b3));

            //-- Se todos os campos estiverem preenchidos corretamente
            if (b1 && b2 && b3)
                bReturn = true;
            //-- Se nenhum dos campos estiverem preenchidos corretamente
            else
            {
                if (!b1 && !b2 && !b3)
                {
                    bReturn = false;
                }
                else
                {
                    //MsgBox.Show("ة necessário preencher todos os campos para filtrar itens por quantidade. "
                    MsgBox.Show("ة necessário preencher os campos DISPONحVEL, RESERVADO ou TOTAL mais os campos MENOR, MAIOR ou IGUAL mais o campo QUANTIDADE para filtrar itens por quantidade. "
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Exclamation);

                    this.rbDisponivel.Checked = false;
                    this.rbReservado.Checked = false;
                    this.rbTotal.Checked = false;
                    this.rbMaior.Checked = false;
                    this.rbMenor.Checked = false;
                    this.rbIgual.Checked = false;
                    this.txtQuantidade.Text = string.Empty;
                }
                bReturn = false;
            }

            return bReturn;
        }

        private string Filtra_Produtos()
        {
            string sQuery = string.Empty;

            if (!string.IsNullOrEmpty(this.txtCodProduto.Text))
            {
                if (sQuery.Length > 0)
                    sQuery += " and ";

                sQuery = " est.Produto = " + this.txtCodProduto.Text;
            }

            if (this.cboEmpresa.SelectedIndex >= 0)
            {
                if (sQuery.Length > 0)
                    sQuery += " and ";

                sQuery += " est.Empresa = " + this.cboEmpresa.SelectedValue.ToString();
            }

            if (Filtra_Quantidade())
            {
                if (sQuery.Length > 0)
                    sQuery += " and ";

                sQuery += this.rbDisponivel.Checked ? " est.Quantidade_Disponivel" :
                          this.rbReservado.Checked ? " est.Quantidade_Reservada" : " est.Quantidade_Total";

                sQuery += this.rbMaior.Checked ? " > " :
                          this.rbMenor.Checked ? " < " : " = ";

                sQuery += this.txtQuantidade.Text;
            }

            return sQuery;
        }

        private void rbDisponivel_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbReservado_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbTotal_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}