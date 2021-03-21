using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0019 : CompSoft.FormSet
    {
        private string sNumero_lote = string.Empty;

        public f0019()
        {
            string sSQL = string.Empty;

            sSQL += "select * from vw_Contas_Receber_Baixadas";

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Contas_Receber_mov"
                , sSQL
                , "Conta_receber_mov"));

            InitializeComponent();
        }

        private void Encontrar_Titulos_Baixar(bool bLimpar_Tudo)
        {
            string sSQL = string.Empty;
            sSQL += "select * from vw_Contas_Receber_Abertas";

            f0026 f = new f0026();
            f.Query_Padrao = sSQL;
            f.PrimaryKey = "Conta_receber, Conta_receber_Parcela";

            if (f.ShowDialog() == DialogResult.OK)
            {
                if (bLimpar_Tudo)
                    this.BindingSource[this.MainTabela].CancelEdit();

                DataRow[] fRow = f.DataSetLocal.Tables["xResultado"].Select("sel = 1");
                foreach (DataRow row in fRow)
                {
                    //-- Captura as informações para inclusão de um novo registro
                    DataRow nRow = this.DataSetLocal.Tables[this.MainTabela].NewRow();

                    nRow["Conta_Receber"] = row["Conta_Receber"];
                    nRow["Conta_Receber_Parcela"] = row["Conta_Receber_Parcela"];
                    nRow["empresa"] = row["empresa"];
                    nRow["Cliente"] = row["Cliente"];
                    nRow["Numero_Documento"] = row["Numero_Documento"];
                    nRow["Tipo_Documento_Titulo"] = row["Tipo_Documento"];
                    nRow["Tipo_Pagamento_Titulo"] = row["Tipo_Pagamento"];
                    nRow["Valor_Original_Titulo"] = row["Valor_Titulo"];
                    nRow["Valor_Pago_Titulo"] = row["Valor_Pago"];
                    nRow["Data_Cadastro_Titulo"] = row["Data_Cadastro_titulo"];
                    nRow["Parcela"] = row["Parcela"];
                    nRow["Data_Cadastro"] = row["Data_Cadastro"];
                    nRow["Data_Emissao"] = row["Data_Emissao"];
                    nRow["Data_Vencimento"] = row["Data_Vencimento"];
                    nRow["Valor_Original"] = row["Valor_Original"];
                    nRow["Valor_Receber"] = row["Valor_Original"];
                    nRow["Parcela_Paga"] = false;
                    nRow["Tipo_Movimento"] = f.cboTipoMovimento.SelectedIndex < 0 ? DBNull.Value : f.cboTipoMovimento.SelectedValue;
                    nRow["Data_Movimento"] = DateTime.Now.ToShortDateString();
                    nRow["Valor_Pago"] = row["Valor_Original"];
                    nRow["Numero_Lote"] = this.sNumero_lote;
                    nRow["Razao_Social_Cliente"] = row["Desc_Cliente"];
                    nRow["Razao_Social_Filial"] = row["Desc_Filial"];
                    nRow["Protesto"] = row["Protesto"];

                    //-- Inclui o registro no DATASET
                    this.DataSetLocal.Tables[this.MainTabela].Rows.Add(nRow);
                }
            }

            f.Close();
        }

        private void f0018_user_FormStatus_Change()
        {
            this.txtDescFornecedor.Obrigatorio = false;

            if (this.FormStatus == CompSoft.TipoFormStatus.Novo)
                this.cmdAdicionarTitulo_Baixa.Enabled = true;
            else
                this.cmdAdicionarTitulo_Baixa.Enabled = false;

            if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Limpar)
                this.Change_Group("Movimento", true);
            else
                this.Change_Group("Movimento", false);

            //-- habilita os valores
            if (this.FormStatus == CompSoft.TipoFormStatus.Limpar)
                this.Change_Group("Titulo", true);
            else
                this.Change_Group("Titulo", false);

            this.chkProtestoPago_CheckedChanged(this, EventArgs.Empty);
        }

        private void f0018_user_AfterRefreshData()
        {
            this.grdBaixaTitulo.DataSource = this.DataSetLocal.Tables["Contas_Receber_mov"];
            this.DataSetLocal.Tables[this.MainTabela].Columns[0].ReadOnly = false;
        }

        private void cmdAdicionarTitulo_Baixa_Click(object sender, EventArgs e)
        {
            this.Encontrar_Titulos_Baixar(false);
        }

        private void f0018_user_AfterNew()
        {
            Funcoes func;
            sNumero_lote = func.Contador("Lote_Conta_Receber");
            this.Encontrar_Titulos_Baixar(true);
            foreach (DataRow row in this.DataSetLocal.Tables[0].Select("conta_receber is null"))
                row.Delete();
        }

        private void f0018_user_AfterSave()
        {
            DataRow[] fRow = this.DataSetLocal.Tables[this.MainTabela].Select();

            foreach (DataRow row in fRow)
            {
                string sSQL = string.Empty;
                sSQL += "update Contas_Receber_Parcela set";
                sSQL += "   Valor_Receber = {0}";
                sSQL += " , Parcela_paga = 1";
                sSQL += " where Conta_Receber_Parcela = {1}";

                decimal dValor_Parcela = Convert.ToDecimal(row["Valor_Receber"].ToString());
                decimal dValor_Movimento = Convert.ToDecimal(row["Valor_Pago"].ToString());

                decimal dValor_Atual = dValor_Parcela - dValor_Movimento;

                sSQL = string.Format(System.Globalization.CultureInfo.GetCultureInfo("en-us"), sSQL
                    , dValor_Atual
                    , row["Conta_Receber_Parcela"].ToString());

                //-- Executa a atualização
                CompSoft.Data.SQL.Execute(sSQL);
            }

            Funcoes func;
            sNumero_lote = func.Contador("Lote_Conta_Receber", true);
        }

        private void txtValorMovimento_Movimentacao_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtValorMovimento_Movimentacao.Text))
            {
                if (Convert.ToDecimal(this.txtValorMovimento_Movimentacao.Text) > Convert.ToDecimal(this.txtValorParcela.Text))
                {
                    string sMensagem = "O valor da baixa é superior ao da parcela, confirme esta baixa.";

                    if (MsgBox.Show(sMensagem, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        this.txtValorMovimento_Movimentacao.Focus();
                }
            }
        }

        private void chkProtestoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo)
            {
                this.txtDtProtestoPago.Enabled = this.chkProtestoPago.Checked;

                if (!this.chkProtestoPago.Checked)
                    this.txtDtProtestoPago.EditValue = null;
            }
        }
    }
}