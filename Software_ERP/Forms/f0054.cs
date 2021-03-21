using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0054 : CompSoft.FormSet
    {
        private int iCliente_Deleted = 0,
            iOrdem_Deleted = 0;

        #region Contrutores

        public f0054()
        {
            string sSQL = string.Empty;

            sSQL += "select  ";
            sSQL += "   ro.Romaneio ";
            sSQL += "   , ro.Descricao ";
            sSQL += "   , ro.Funcionario_Motorista ";
            sSQL += "   , ro.Data_Romaneio ";
            sSQL += "   , fu.Nome  ";
            sSQL += "   from romaneios ro ";
            sSQL += "   left outer join funcionarios fu on ro.Funcionario_Motorista = fu.Funcionario ";

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Romaneios"
                    , sSQL
                    , "Romaneio"));

            sSQL = string.Empty;

            sSQL += "select ";
            sSQL += "     romaneios_itens.Romaneio_Item";
            sSQL += " , romaneios_itens.Romaneio";
            sSQL += " , romaneios_itens.Cliente";
            sSQL += " , cl.razao_Social";
            sSQL += " , cl.Endereco_Entrega";
            sSQL += " , cl.Numero_Entrega";
            sSQL += " , cl.Complemento_Entrega";
            sSQL += " , cl.Bairro_Entrega";
            sSQL += " , cl.Cidade_Entrega";
            sSQL += " , cl.Estado_Entrega";
            sSQL += " , romaneios_itens.Pedido";
            sSQL += " , romaneios_itens.Observacao";
            sSQL += " , romaneios_itens.Ordem";
            sSQL += "   from romaneios_itens";
            sSQL += "  inner join pedidos ped on romaneios_itens.Pedido = ped.pedido";
            sSQL += "    inner join clientes cl on cl.cliente = romaneios_itens.Cliente";
            sSQL += "  inner join transportadoras tra on tra.transportadora = ped.transportadora";
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                    , "Romaneios_itens"
                    , sSQL
                    , "Romaneio_Item"));

            InitializeComponent();
        }

        #endregion Contrutores

        #region Inclui item do romaneio.

        private void Incluir_Item_Romaneio()
        {
            string sMsg = string.Empty,
                   sSQL = string.Empty;

            //-- Verifica campos obrigatórios.
            if (string.IsNullOrEmpty(this.txtCodPedido.Text))
                sMsg += "  - O Pedido tem que ser preenchido.\r\n";

            //-- Verifica a possibilidade de incluir os itens.
            if (!string.IsNullOrEmpty(sMsg))
            {
                sMsg = "Erro ao incluir item de Romaneio\r\n" + sMsg;
                MsgBox.Show(sMsg
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
            }
            else
            {
                int iPedido = Convert.ToInt32(this.txtCodPedido.Text);

                sSQL = "select ";
                sSQL += " ped.pedido";
                sSQL += " , ped.Cliente";
                sSQL += " , cl.razao_Social";
                sSQL += " , cl.Endereco_Entrega";
                sSQL += " , cl.Numero_Entrega";
                sSQL += " , cl.Complemento_Entrega";
                sSQL += " , cl.Bairro_Entrega";
                sSQL += " , cl.Cidade_Entrega";
                sSQL += " , cl.Estado_Entrega";
                sSQL += " from pedidos ped";
                sSQL += "  inner join clientes cl on cl.cliente = ped.Cliente";
                sSQL += " where ped.pedido = {0}";

                sSQL = string.Format(sSQL, iPedido);
                DataRow row_Pedido = SQL.Select(sSQL, "x", false).Rows[0];

                if (row_Pedido != null)
                {
                    DataRow[] fRow = this.DataSetLocal.Tables["Romaneios_itens"].Select("Pedido = " + iPedido.ToString());
                    if (fRow.Length > 0)
                    {
                        MsgBox.Show("Pedido já existente neste romaneio, inclusão cancelada."
                            , "Atenção"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //-- Inicia o processo de inclusão do item.
                        this.grdPedidos.BindingSource.AddNew();

                        //-- Verifica se existe mensagem para este cliente.
                        string sMensage = string.Empty;
                        DataRow[] fRow_Mensagem = this.DataSetLocal.Tables["Romaneios_Itens"].Select(string.Format("cliente = {0}", row_Pedido["cliente"]));
                        if (fRow_Mensagem.Length > 0)
                        {
                            foreach (DataRow row in fRow_Mensagem)
                                sMensage = row["Observacao"].ToString();
                        }
                        else
                            sMensage = this.txtObs.Text;

                        this.grdPedidos.CurrentRow["pedido"] = row_Pedido["pedido"];
                        this.grdPedidos.CurrentRow["razao_Social"] = row_Pedido["razao_Social"];
                        this.grdPedidos.CurrentRow["Endereco_Entrega"] = row_Pedido["Endereco_Entrega"];
                        this.grdPedidos.CurrentRow["Numero_Entrega"] = row_Pedido["Numero_Entrega"];
                        this.grdPedidos.CurrentRow["Complemento_Entrega"] = row_Pedido["Complemento_Entrega"];
                        this.grdPedidos.CurrentRow["Bairro_Entrega"] = row_Pedido["Bairro_Entrega"];
                        this.grdPedidos.CurrentRow["Cidade_Entrega"] = row_Pedido["Cidade_Entrega"];
                        this.grdPedidos.CurrentRow["Estado_Entrega"] = row_Pedido["Estado_Entrega"];
                        this.grdPedidos.CurrentRow["Cliente"] = row_Pedido["Cliente"];
                        this.grdPedidos.CurrentRow["Observacao"] = sMensage;
                        this.grdPedidos.CurrentRow["Ordem"] = this.Ordem_Cliente_Romaneio_Inclusao(Convert.ToInt32(row_Pedido["Cliente"]));

                        this.grdPedidos.BindingSource.EndEdit();
                    }

                    //-- Limpa campos.
                    this.Limpa_Campos();

                    //-- Inclui registro.
                    this.Incluir_Clientes_Ordem(Convert.ToInt32(row_Pedido["Cliente"]));
                }
                else
                {
                    MsgBox.Show("Pedido não encontrado, tente novamente."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                }

                this.txtCodPedido.Focus();
            }
        }

        #endregion Inclui item do romaneio.

        #region Limpa campos da tela

        private void Limpa_Campos()
        {
            this.txtCodPedido.Text = string.Empty;
            this.txtObs.Text = string.Empty;
            this.txtNomeCliente.Text = string.Empty;
        }

        #endregion Limpa campos da tela

        #region Busca clientes para ordenação.

        private void Busca_Clientes()
        {
            string sValor = this.txtRomaneio.Text;
            if (string.IsNullOrEmpty(sValor))
                sValor = "0";

            string sSQL = string.Empty;
            sSQL += "select distinct ri.Ordem, ri.Cliente, cl.Razao_Social";
            sSQL += " from romaneios_itens ri";
            sSQL += "  inner join clientes cl on cl.cliente = ri.cliente";
            sSQL += " where ri.Romaneio = {0}";
            sSQL = string.Format(sSQL, sValor);

            DataTable dt = SQL.Select(sSQL, "x", false);

            if (this.grdClientesRomaneio.DataSource != null)
            {
                this.grdClientesRomaneio.BindingSource.DataSource = dt;
            }
            else
            {
                BindingSource bs = new BindingSource(dt, null);
                this.grdClientesRomaneio.DataSource = bs;
                this.grdClientesRomaneio.BindingSource.Sort = "Ordem";
            }
        }

        #endregion Busca clientes para ordenação.

        #region Controla ordem do romaneio.

        /// <summary>
        /// Identifica qual é a ordem que o cliente assumirá.
        /// </summary>
        /// <param name="iCliente">Código do cliente</param>
        /// <returns>Número da ordem que o cliente assumirá.</returns>
        private int Ordem_Cliente_Romaneio_Inclusao(int iCliente)
        {
            int iRetorno = 0;
            string sFilter = "Cliente = {0}";
            sFilter = string.Format(sFilter, iCliente);
            DataRow[] fRow = ((DataTable)this.grdClientesRomaneio.BindingSource.DataSource).Select(sFilter);

            if (fRow.Length == 0)
            {
                object oValor = this.DataSetLocal.Tables["Romaneios_itens"].Compute("max(ordem)", "");
                if (oValor != DBNull.Value)
                    iRetorno = Convert.ToInt32(oValor) + 1;
                else
                    iRetorno = 1;
            }
            else
            {
                foreach (DataRow row in fRow)
                    iRetorno = Convert.ToInt32(row["Ordem"]);
            }

            return iRetorno;
        }

        #endregion Controla ordem do romaneio.

        #region Inclui cliente no grid para definir ordem.

        private void Incluir_Clientes_Ordem(int iCliente)
        {
            DataRow[] fRow = this.DataSetLocal.Tables["Romaneios_itens"].Select("Cliente = " + iCliente.ToString());
            DataTable dt = ((DataTable)this.grdClientesRomaneio.BindingSource.DataSource);

            foreach (DataRow row in fRow)
            {
                string sFiltro = string.Format("Cliente = {0}", row["cliente"]);
                DataRow[] fRow2 = dt.Select(sFiltro);

                //-- Inclui novo registro.
                if (fRow2.Length == 0)
                {
                    DataRow newrow = dt.NewRow();

                    newrow["Ordem"] = row["Ordem"];
                    newrow["Cliente"] = row["Cliente"];
                    newrow["Razao_Social"] = row["razao_Social"];

                    dt.Rows.Add(newrow);
                }
            }
        }

        #endregion Inclui cliente no grid para definir ordem.

        #region Verifica se o sistema vai excluir o item

        public void Excluir_Cliente_Ordem(int iCliente, int iOrdem)
        {
            DataTable dt = ((DataView)this.grdClientesRomaneio.DataSource).Table;
            string sFilter = string.Format("Cliente = {0}", iCliente);

            if (this.DataSetLocal.Tables["Romaneios_itens"].Select(sFilter).Length == 0)
            {
                foreach (DataRow row in dt.Select(sFilter))
                {
                    //-- Atualiza a tabela principal.
                    DataRow[] fRow = this.DataSetLocal.Tables["Romaneios_itens"].Select("Ordem > " + iOrdem.ToString());
                    foreach (DataRow row_Altera in fRow)
                        row_Altera["Ordem"] = Convert.ToInt32(row_Altera["Ordem"]) - 1;

                    //-- Atualiza a tabela de controle.
                    fRow = dt.Select("Ordem > " + iOrdem.ToString());
                    foreach (DataRow row_Altera in fRow)
                        row_Altera["Ordem"] = Convert.ToInt32(row_Altera["Ordem"]) - 1;

                    //-- Exclui registro.
                    row.Delete();
                }
            }
        }

        #endregion Verifica se o sistema vai excluir o item

        #region Movimenta para cima

        private void Movimenta_Cima()
        {
            int iOrdem_Selecionado = 0,
                iOrdem_Alteracao = 0;

            if (this.grdClientesRomaneio.BindingSource.Position > 0)
            {
                DataRowView row = (DataRowView)this.grdClientesRomaneio.BindingSource.Current;

                iOrdem_Selecionado = Convert.ToInt32(row["Ordem"]);
                iOrdem_Alteracao = iOrdem_Selecionado - 1; //-- Identifica que o registro está sendo movimentado para um nivel acima na ordem.

                string sFilter = "Ordem = {0} or Ordem = {1}";
                sFilter = string.Format(sFilter, iOrdem_Selecionado, iOrdem_Alteracao);

                //-- Altera o controle de ordenação.
                foreach (DataRow row_Alt in ((DataTable)this.grdClientesRomaneio.BindingSource.DataSource).Select(sFilter, "Ordem"))
                {
                    bool bContinuar = true;

                    if (Convert.ToInt32(row_Alt["Ordem"]) == iOrdem_Selecionado)
                    {
                        row_Alt["Ordem"] = Convert.ToInt32(row_Alt["Ordem"]) - 1;
                        bContinuar = false;
                    }

                    if (bContinuar && Convert.ToInt32(row_Alt["Ordem"]) == iOrdem_Alteracao)
                        row_Alt["Ordem"] = Convert.ToInt32(row_Alt["Ordem"]) + 1;
                }

                //-- Altera a tabela para salvar no banco.
                foreach (DataRow row_Alt in this.DataSetLocal.Tables["Romaneios_Itens"].Select(sFilter))
                {
                    bool bContinuar = true;

                    if (Convert.ToInt32(row_Alt["Ordem"]) == iOrdem_Selecionado)
                    {
                        row_Alt["Ordem"] = Convert.ToInt32(row_Alt["Ordem"]) - 1;
                        bContinuar = false;
                    }

                    if (bContinuar && Convert.ToInt32(row_Alt["Ordem"]) == iOrdem_Alteracao)
                        row_Alt["Ordem"] = Convert.ToInt32(row_Alt["Ordem"]) + 1;
                }

                //-- Informa ao sistema que já foram feitas as atualizações.
                this.grdClientesRomaneio.BindingSource.EndEdit();
            }
        }

        #endregion Movimenta para cima

        #region Movimenta para Baixo

        private void Movimenta_Baixo()
        {
            int iOrdem_Selecionado = 0,
                iOrdem_Alteracao = 0;

            if (this.grdClientesRomaneio.BindingSource.Position < this.grdClientesRomaneio.BindingSource.Count - 1)
            {
                DataRowView row = (DataRowView)this.grdClientesRomaneio.BindingSource.Current;

                iOrdem_Selecionado = Convert.ToInt32(row["Ordem"]);
                iOrdem_Alteracao = iOrdem_Selecionado + 1; //-- Identifica que o registro está sendo movimentado para um nivel acima na ordem.

                string sFilter = "Ordem = {0} or Ordem = {1}";
                sFilter = string.Format(sFilter, iOrdem_Selecionado, iOrdem_Alteracao);

                //-- Altera o controle de ordenação.
                foreach (DataRow row_Alt in ((DataTable)this.grdClientesRomaneio.BindingSource.DataSource).Select(sFilter, "Ordem"))
                {
                    bool bContinuar = true;

                    if (Convert.ToInt32(row_Alt["Ordem"]) == iOrdem_Selecionado)
                    {
                        row_Alt["Ordem"] = Convert.ToInt32(row_Alt["Ordem"]) + 1;
                        bContinuar = false;
                    }

                    if (bContinuar && Convert.ToInt32(row_Alt["Ordem"]) == iOrdem_Alteracao)
                        row_Alt["Ordem"] = Convert.ToInt32(row_Alt["Ordem"]) - 1;
                }

                //-- Altera a tabela para salvar no banco.
                foreach (DataRow row_Alt in this.DataSetLocal.Tables["Romaneios_Itens"].Select(sFilter))
                {
                    bool bContinuar = true;

                    if (Convert.ToInt32(row_Alt["Ordem"]) == iOrdem_Selecionado)
                    {
                        row_Alt["Ordem"] = Convert.ToInt32(row_Alt["Ordem"]) + 1;
                        bContinuar = false;
                    }

                    if (bContinuar && Convert.ToInt32(row_Alt["Ordem"]) == iOrdem_Alteracao)
                        row_Alt["Ordem"] = Convert.ToInt32(row_Alt["Ordem"]) - 1;
                }

                //-- Informa ao sistema que já foram feitas as atualizações.
                this.grdClientesRomaneio.BindingSource.EndEdit();
            }
        }

        #endregion Movimenta para Baixo

        private void f0054_Load(object sender, EventArgs e)
        {
            this.grdPedidos.AllowUserToDeleteRows = true;
            this.grdClientesRomaneio.AutoGenerateColumns = false;
            this.grdClientesRomaneio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.cmdBaixo.ImageAlign = ContentAlignment.MiddleCenter;
            this.cmdCima.ImageAlign = ContentAlignment.MiddleCenter;

            this.DataSetLocal.Tables["Romaneios_itens"].RowDeleting += new DataRowChangeEventHandler(f0054_RowDeleting);
            this.DataSetLocal.Tables["Romaneios_itens"].RowDeleted += new DataRowChangeEventHandler(f0054_RowDeleted);
        }

        private void f0054_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            this.Excluir_Cliente_Ordem(iCliente_Deleted, iOrdem_Deleted);
        }

        private void f0054_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            iCliente_Deleted = Convert.ToInt32(e.Row["cliente"]);
            iOrdem_Deleted = Convert.ToInt32(e.Row["Ordem"]);
        }

        private void f0054_user_AfterRefreshData()
        {
            this.grdPedidos.DataSource = this.DataSetLocal.Tables["Romaneios_itens"];
            this.Busca_Clientes();
        }

        private void grdPedidos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Modificando)
            {
                DialogResult dr = MsgBox.Show("Deseja excluir este item do romaneio?"
                    , "Excluir item"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        }

        private void txtCodPedido_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCodPedido.LookUpRetorno != null)
                this.txtNomeCliente.Text = this.txtCodPedido.LookUpRetorno[1].ToString();
        }

        private void txtNomeCliente_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtNomeCliente.LookUpRetorno != null)
                this.txtCodPedido.Text = this.txtNomeCliente.LookUpRetorno[0].ToString();
        }

        private void txtCodPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                this.Incluir_Item_Romaneio();
        }

        private void txtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                this.Incluir_Item_Romaneio();
        }

        private void f0054_user_AfterNew()
        {
            this.Busca_Clientes();
        }

        private void cmdCima_Click(object sender, EventArgs e)
        {
            this.Movimenta_Cima();
        }

        private void cmdBaixo_Click(object sender, EventArgs e)
        {
            this.Movimenta_Baixo();
        }

        private void f0054_user_AfterClear()
        {
            if (this.grdClientesRomaneio.DataSource != null)
                ((DataTable)this.grdClientesRomaneio.DataSource).Clear();
        }
    }
}