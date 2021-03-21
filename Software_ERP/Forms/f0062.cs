using CompSoft.compFrameWork;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0062 : ERP.Forms.f0037
    {
        private bool bchkCancelado_status_inicial = false;
        private ERP.Class.clsControleEstoque ceEstoque = new ERP.Class.clsControleEstoque();

        public f0062()
        {
            InitializeComponent();

            this.grdProdutos.UserDeletingRow += new DataGridViewRowCancelEventHandler(grdProdutos_UserDeletingRow);
        }

        private void grdProdutos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Cancel)
            {
                if (this.FormStatus == CompSoft.TipoFormStatus.Modificando)
                {
                    if (this.chkNFGerada.Checked)
                    {
                        string sMensagem = "A NF/Cupom já foi gerada, por este motivo não será possível excluir o item.\r\n";
                        sMensagem += "  - Cancele a NF/Cupom na tela de manutenção, pois os itens deste documento devem voltar ao estoque.\r\n";

                        MsgBox.Show(sMensagem
                            , "Atenção"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Warning);

                        e.Cancel = true;
                    }
                }
                else
                    e.Cancel = true;
            }
        }

        public override void Incluir_Produto(string sMsg)
        {
            if (this.chkCancelado.Checked)
                sMsg += "  - Não é permitido a inclusão de itens em pedidos cancelados.\r\n";

            base.Incluir_Produto(sMsg);
        }

        private void f0062_user_FormStatus_Change()
        {
            switch (this.FormStatus)
            {
                case CompSoft.TipoFormStatus.Modificando:
                    this.chkCancelado.Enabled = !this.chkNFGerada.Checked;
                    this.chkGeraNota.Enabled = !this.chkNFGerada.Checked;
                    bchkCancelado_status_inicial = this.chkCancelado.Checked;
                    this.chkNFGerada.Enabled = false;

                    break;
            }
        }

        private bool f0062_user_BeforeSave()
        {
            //-- Verifica se foram incluidos produtos no pedido.
            if (this.DataSetLocal.Tables["Pedidos_itens"].Rows.Count > 0)
            {
                //-- Caso nao tenha havido alteracao no status do pedido (cancelamento/ativacao)
                if (bchkCancelado_status_inicial == this.chkCancelado.Checked)
                {
                    //-- Retorna estoques aos valores originais
                    Restaura_estoques();

                    //-- Salva novos valores no estoque
                    Salva_estoques();
                }
                else
                {
                    //-- Se inicou ativo e terminou cancelado só retorna estoques
                    //-- Retorna estoques aos valores originais
                    if (!bchkCancelado_status_inicial)
                        Restaura_estoques();

                    //-- Se inicou cancelado e terminou ativo só salva novos valores em estoque
                    //-- Salva novos valores no estoque
                    if (bchkCancelado_status_inicial)
                        Salva_estoques();
                }
            }

            return true;
        }

        //-- Retorna estoques aos valores originais
        private void Restaura_estoques()
        {
            DataView dvinforiginal = new DataView(this.DataSetLocal.Tables["Pedidos_itens"], "", "", DataViewRowState.OriginalRows);
            foreach (DataRowView datarowinf in dvinforiginal)
                ceEstoque.Cancelamento_Item_Pedido(Convert.ToInt32(this.txtCodEmpresa.Text), Convert.ToInt32(datarowinf["Produto"]), Convert.ToInt32(datarowinf["Qtde"]));
        }

        //-- Salva novos valores no estoque
        private void Salva_estoques()
        {
            //-- Salva novos valores no estoque
            DataView dvinf = new DataView(this.DataSetLocal.Tables["Pedidos_itens"], "", "", DataViewRowState.CurrentRows);

            foreach (DataRowView datarowinf in dvinf)
                ceEstoque.Inclusao_Item_Pedido(Convert.ToInt32(this.txtCodEmpresa.Text), Convert.ToInt32(datarowinf["Produto"]), Convert.ToInt32(datarowinf["Qtde"]));
        }

        private void f0062_user_AfterRefreshData()
        {
            if (this.BindingSource[this.MainTabela].Position > -1)
            {
                DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
                if (Convert.ToBoolean(row["Cancelado"]) || Convert.ToBoolean(row["NF_Gerada"]))
                    this.Barra_Ferramentas_Editar_Registro = false;
                else
                    this.Barra_Ferramentas_Editar_Registro = true;
            }
        }

        private void chkCancelado_CheckedChanged(object sender, EventArgs e)
        {
            //-- Em caso de cancelamento de nota fiscal
            if (this.FormStatus == CompSoft.TipoFormStatus.Modificando)
            {
                if (this.chkCancelado.Checked)
                {
                    DialogResult dr = MsgBox.Show("Deseja cancelar a nota atual e todos os seus itens?"
                        , "Cancelamento de Nota Fiscal"
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question);

                    if (dr == DialogResult.No)
                        this.chkCancelado.Checked = false;
                }

                this.Barra_Ferramentas_Editar_Registro = !this.chkCancelado.Checked;
            }
        }
    }
}