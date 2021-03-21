using CompSoft.compFrameWork;
using CompSoft.Data;
using ERP.Class;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0052 : CompSoft.FormSet
    {
        private clsControleEstoque ceEstoque = new clsControleEstoque();

        #region Contrutores

        public f0052()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   me.Movimento_Estoque");
            sb.AppendLine(" , me.Tipo_Movimento_Estoque");
            sb.AppendLine(" , tme.Desc_Tipo_Movimento_Estoque");
            sb.AppendLine(" , me.Empresa");
            sb.AppendLine(" , me.Cliente");
            sb.AppendLine(" , cl.razao_Social as 'Razao_Cliente'");
            sb.AppendLine(" , me.Numero_Documento");
            sb.AppendLine(" , me.Descricao");
            sb.AppendLine(" , me.Data_Movimento");
            sb.AppendLine(" , me.Valor_Total");
            sb.AppendLine(" FROM Movimentos_Estoque me ");
            sb.AppendLine("     INNER JOIN Tipos_Movimentos_estoque tme ON tme.Tipo_Movimento_Estoque = me.Tipo_Movimento_Estoque");
            sb.AppendLine("     left outer join empresas e ON e.empresa = me.Empresa");
            sb.AppendLine("     left outer JOIN clientes cl ON cl.cliente = me.cliente");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Movimentos_Estoque"
                    , sb.ToString()));

            sb.Remove(0, sb.Length - 1);

            sb.AppendLine("select ");
            sb.AppendLine("   Movimentos_Estoque_itens.Movimento_Estoque_Item");
            sb.AppendLine(" , Movimentos_Estoque_itens.Movimento_Estoque");
            sb.AppendLine(" , class.*");
            sb.AppendLine(" , Movimentos_Estoque_itens.Valor_Unitario");
            sb.AppendLine(" , Movimentos_Estoque_itens.Quantidade");
            sb.AppendLine(" , Movimentos_Estoque_itens.Valor_Total");
            sb.AppendLine(" , pr.valor_custo_unitario");
            sb.AppendLine(" FROM Movimentos_Estoque_itens ");
            sb.AppendLine("  INNER JOIN produtos pr ON pr.produto = Movimentos_Estoque_itens.produto");
            sb.AppendLine("  inner join vw_class_produto class ON class.produto = pr.produto");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                    , "Movimentos_Estoque_itens"
                    , sb.ToString()));

            InitializeComponent();
        }

        #endregion Contrutores

        #region Inclui registro do produto.

        private void Incluir_Produto()
        {
            string sMsg = string.Empty,
                   sSQL = string.Empty;

            //-- Verifica campos obrigatórios.
            if (string.IsNullOrEmpty(this.txtCodProduto.Text))
                sMsg += "  - O produto tem que ser preenchido.\r\n";

            if (string.IsNullOrEmpty(this.txtQtde.Text))
                sMsg += "  - A quantidade tem que ser preenchida.\r\n";

            if (!string.IsNullOrEmpty(this.txtQtde.Text) && Convert.ToInt16(this.txtQtde.Text) <= 0)
                sMsg += "  - A quantidade tem que ser maior que 0.\r\n";

            if (string.IsNullOrEmpty(this.txtPreco.Text))
                sMsg += "  - O preço tem que ser preenchido.\r\n";

            //-- Verifica a possibilidade de incluir os itens.
            if (!string.IsNullOrEmpty(sMsg))
            {
                sMsg = "Erro ao incluir item no movimento\r\n" + sMsg;
                MsgBox.Show(sMsg
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
            }
            else
            {
                int iProduto = Convert.ToInt32(this.txtCodProduto.Text);

                sSQL = "SELECT";
                sSQL += "   class.*";
                sSQL += "   , pr.Valor_Custo_Unitario";
                sSQL += "   FROM produtos pr";
                sSQL += "  inner join vw_class_produto class on class.produto = pr.produto";
                sSQL += "   WHERE pr.Produto = {0}";
                sSQL = string.Format(sSQL, iProduto);
                DataRow row_Produto = SQL.Select(sSQL, "x", false).Rows[0];

                if (row_Produto != null)
                {
                    decimal dValor_Unitario = Convert.ToDecimal(this.txtPreco.Text),
                        dValor_Total_Produto = 0;

                    int iQtde = Convert.ToInt32(this.txtQtde.Text);

                    //-- Realiza calculos.
                    dValor_Total_Produto = dValor_Unitario * iQtde;

                    DataRow[] fRow = ((DataTable)this.grdProdutos.BindingSource.DataSource).Select("Produto = " + iProduto.ToString());
                    if (fRow.Length > 0)
                    {
                        foreach (DataRow row in fRow)
                        {
                            row.BeginEdit();

                            row["Quantidade"] = Convert.ToInt32(row["Quantidade"]) + iQtde;
                            row["Valor_Total"] = Convert.ToDecimal(row["Valor_Total"]) + dValor_Total_Produto;

                            row.EndEdit();
                            this.grdProdutos.BindingSource.EndEdit();
                        }
                    }
                    else
                    {
                        //-- Inicia o processo de inclusão do item.
                        this.grdProdutos.BindingSource.AddNew();

                        this.grdProdutos.CurrentRow["Grupo_Produto"] = row_Produto["Grupo_Produto"];
                        this.grdProdutos.CurrentRow["Desc_Grupo_Produto"] = row_Produto["Desc_Grupo_Produto"];
                        this.grdProdutos.CurrentRow["Produto"] = iProduto;
                        this.grdProdutos.CurrentRow["Desc_Produto"] = this.txtProduto.Text;
                        this.grdProdutos.CurrentRow["Quantidade"] = iQtde;
                        this.grdProdutos.CurrentRow["Valor_Unitario"] = dValor_Unitario;
                        this.grdProdutos.CurrentRow["Valor_Total"] = dValor_Total_Produto;
                    }

                    //-- Calcula os totais do movimento e mostra em tela.
                    this.Calcula_Totais();

                    this.txtCodProduto.Text = string.Empty;
                    this.txtProduto.Text = string.Empty;
                    this.txtQtde.Text = string.Empty;
                    this.txtCodProduto.Focus();
                }
                else
                {
                    MsgBox.Show("Tabela de preço do produto não encontrado, tente novamente."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                }
            }
        }

        #endregion Inclui registro do produto.

        #region Recalcula o valor total

        private void Calcula_Totais()
        {
            object oValor;

            //-- Calcula o total do movimento.
            oValor = this.DataSetLocal.Tables["Movimentos_Estoque_itens"].Compute("sum(Valor_Total)", "");
            if (oValor == DBNull.Value)
                this.txtValorTotal.Text = string.Empty;
            else
            {
                this.txtValorTotal.Text = Convert.ToString(Convert.ToDecimal(oValor));
            }
        }

        #endregion Recalcula o valor total

        #region Filtros personalizados

        public override string user_Query(string TabelaAtual)
        {
            string sQuery = string.Empty;

            if (TabelaAtual.ToLower() == "Movimentos_Estoque".ToLower())
            {
                if (this.chkFiltroData.Checked)
                {
                    if (!string.IsNullOrEmpty(sQuery))
                        sQuery += " AND ";

                    sQuery += string.Format(" me.Data_Movimento between '{0}' and '{1}'"
                            , this.prdDataMovimento.Data_Inicial_SQL
                            , this.prdDataMovimento.Data_Termino_SQL);
                }
            }

            return sQuery;
        }

        #endregion Filtros personalizados

        private void f0052_user_AfterRefreshData()
        {
            this.grdProdutos.DataSource = this.DataSetLocal.Tables["Movimentos_Estoque_itens"];
        }

        private void f0052_Load(object sender, EventArgs e)
        {
            Filtra_Cliente_fornecedor();
            this.grdProdutos.AllowUserToDeleteRows = true;
            this.txtValorTotal.ReadOnly = true;
        }

        private void grdProdutos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MsgBox.Show("Deseja excluir este item do movimento?"
                , "Excluir item"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);

            if (dr == DialogResult.No)
                e.Cancel = true;
        }

        private void grdProdutos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.Calcula_Totais();
        }

        private void txtCodProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                this.Incluir_Produto();
        }

        private void txtProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                this.Incluir_Produto();
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                this.Incluir_Produto();
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodProduto.LookUpRetorno != null)
            {
                this.txtProduto.Text = this.txtCodProduto.LookUpRetorno[1].ToString();
                string sValor = this.txtCodProduto.LookUpRetorno[2].ToString();
                if (string.IsNullOrEmpty(sValor))
                    sValor = "0.00";

                this.txtPreco.Text = sValor;
            }
        }

        private void txtProduto_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtProduto.LookUpRetorno != null)
            {
                this.txtCodProduto.Text = this.txtProduto.LookUpRetorno[0].ToString();
                string sValor = this.txtCodProduto.LookUpRetorno[2].ToString();
                if (string.IsNullOrEmpty(sValor))
                    sValor = "0.00";

                this.txtPreco.Text = sValor;
            }
        }

        private void Filtra_Cliente_fornecedor()
        {
            //-- Se for entrada seleciona fornecedor
            if (this.rbEntrada.Checked)
            {
                this.txtCodCliente.SQLStatement = "select Cliente, Razao_Social, Nome_Fantasia from Clientes where tipo_fornecedor = 1 and Cliente@";
                this.txtCliente.SQLStatement = "select Cliente, Razao_Social, Nome_Fantasia from Clientes where tipo_fornecedor = 1 and Razao_Social@";
            }
            else
            {
                this.txtCodCliente.SQLStatement = "select Cliente, Razao_Social, Nome_Fantasia from Clientes where tipo_cliente = 1 and Cliente@";
                this.txtCliente.SQLStatement = "select Cliente, Razao_Social, Nome_Fantasia from Clientes where tipo_cliente = 1 and Razao_Social@";
            }
        }

        private void rbEntrada_CheckedChanged(object sender, EventArgs e)
        {
            Filtra_Cliente_fornecedor();
            this.lblCliente.Text = "Fornecedor:";
        }

        private void rbSaida_CheckedChanged(object sender, EventArgs e)
        {
            Filtra_Cliente_fornecedor();
            this.lblCliente.Text = "Cliente:";
        }

        private void txtCodCliente_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodCliente.LookUpRetorno != null)
                this.txtCliente.Text = this.txtCodCliente.LookUpRetorno[1].ToString();
        }

        private void txtCliente_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCliente.LookUpRetorno != null)
                this.txtCodCliente.Text = this.txtCliente.LookUpRetorno[0].ToString();
        }

        private bool f0052_user_BeforeSave()
        {
            bool bContinuar = true;

            //-- Verifica se foram incluidos produtos no pedido.
            if (this.DataSetLocal.Tables["Movimentos_Estoque_itens"].Rows.Count <= 0)
            {
                MsgBox.Show("Não é possivel salvar este movimento porque não existem produtos associados."
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);

                bContinuar = false;
            }

            //-- Atualiza dados do estoque
            DataView dvinf = new DataView(this.DataSetLocal.Tables["Movimentos_Estoque_itens"], "", "", DataViewRowState.CurrentRows);

            foreach (DataRowView datarowinf in dvinf)
            {
                ceEstoque.Inclusao_Item_Movimento_Estoque(Convert.ToInt32(this.cboEmpresa.SelectedValue),
                    Convert.ToInt32(datarowinf["Produto"]),
                    Convert.ToInt32(datarowinf["Quantidade"]),
                    this.rbEntrada.Checked ? (int)ERP.Class.clsControleEstoque.Tipo_Movimento_Estoque.Entrada : (int)ERP.Class.clsControleEstoque.Tipo_Movimento_Estoque.Saida);
            }

            return bContinuar;
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                this.Incluir_Produto();
        }

        private void f0052_Shown(object sender, EventArgs e)
        {
            this.cboEmpresa.Obrigatorio = clsControleEstoque.Estoque_por_empresa;
            this.txtCliente.Obrigatorio = clsControleEstoque.Estoque_por_empresa;
        }
    }
}