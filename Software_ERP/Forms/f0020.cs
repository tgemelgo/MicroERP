using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0020 : CompSoft.FormSet
    {
        public f0020()
        {
            string sSQL = string.Empty;

            sSQL += "Select ";
            sSQL += "   Contas_Receber.* ";
            sSQL += " , cl.Razao_Social ";
            sSQL += " , f.Razao_Social as 'Razao_Social_Filial' ";
            sSQL += " from Contas_Receber ";
            sSQL += "  inner join Empresas f on f.Empresa = Contas_Receber.Empresa ";
            sSQL += "  left outer join Clientes cl on cl.cliente = Contas_Receber.Cliente ";
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Contas_Receber"
                , sSQL));

            sSQL = string.Empty;
            sSQL += "select * from Contas_Receber_Parcela";
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "Contas_Receber_Parcela"
                , sSQL));

            InitializeComponent();
        }

        private void txtFilial_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtFilial.LookUpRetorno != null)
            {
                this.txtDescFilial.Text = this.txtFilial.LookUpRetorno[1].ToString();
            }
        }

        private void txtCliente_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCliente.LookUpRetorno != null)
            {
                this.txtDescCliente.Text = this.txtCliente.LookUpRetorno[1].ToString();
            }
        }

        private void frmCad_ContasPagar_user_AfterNew()
        {
            Funcoes func;
            this.txtDtCadastro.EditValue = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            this.txtFilial.Text = func.Busca_Propriedade("Codigo_Filial");
            this.txtFilial.FazerLookUp(false);
            if (this.txtFilial.LookUpRetorno != null)
                this.txtDescFilial.Text = this.txtFilial.LookUpRetorno[1].ToString();
        }

        private void frmCad_ContasPagar_user_FormStatus_Change()
        {
            this.txtDescCliente.Obrigatorio = false;
            this.txtDescFilial.ReadOnly = true;
            this.txtParcelamentoQtde.Enabled = false;
            this.agParcelas.Status_Form = this.FormStatus;

            if (this.grdParcelas.Rows.Count <= 0)
            {
                if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
                    this.cmdGerarParcelas.Enabled = true;
                else
                    this.cmdGerarParcelas.Enabled = false;
            }
            else
                this.cmdGerarParcelas.Enabled = false;

            this.opgParcelamento_DiaFixo.Checked = true;
            this.optParcelamento_EmDias.Checked = false;
            this.txtQtdeParcelas.Text = string.Empty;
            this.txtParcelamentoQtde.Text = string.Empty;
        }

        private void txtValorOriginal_Validated(object sender, EventArgs e)
        {
            this.txtValorPagar.Text = this.txtValorOriginal.Text;
        }

        private void f0017_user_AfterRefreshData()
        {
            this.grdParcelas.DataSource = this.DataSetLocal.Tables["Contas_Receber_Parcela"].DefaultView;

            if (this.grdParcelas.Rows.Count <= 0)
            {
                if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
                    this.cmdGerarParcelas.Enabled = true;
                else
                    this.cmdGerarParcelas.Enabled = false;
            }
            else
                this.cmdGerarParcelas.Enabled = false;
        }

        private void f0017_Enter(object sender, EventArgs e)
        {
            this.agParcelas.Grid_Trabalho = this.grdParcelas;
        }

        private void opgParcelamento_DiaFixo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.opgParcelamento_DiaFixo.Checked)
            {
                this.txtParcelamentoQtde.Enabled = false;
                this.txtParcelamentoQtde.Text = string.Empty;
            }
        }

        private void optParcelamento_EmDias_CheckedChanged(object sender, EventArgs e)
        {
            if (this.optParcelamento_EmDias.Checked)
                this.txtParcelamentoQtde.Enabled = true;
        }

        private void cmdGerarParcelas_Click(object sender, EventArgs e)
        {
            string sErro = string.Empty;

            if (this.txtPrimeiraDataVencimento.EditValue == null)
                sErro += "Informe a primeira data para vencimento.\n";

            if (string.IsNullOrEmpty(this.txtQtdeParcelas.Text))
                sErro += "Informe a quantidade de parcelas do titulo.\n";

            if (this.optParcelamento_EmDias.Checked)
            {
                if (string.IsNullOrEmpty(this.txtParcelamentoQtde.Text))
                    sErro += "A quantidade de dias para parcelamento tem que ser informada.\n";
            }

            if (string.IsNullOrEmpty(sErro))
            {
                CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, o sistema está gerando as parcelas", true, int.Parse(this.txtQtdeParcelas.Text), 0);

                //-- Gera parcelamento.
                for (int i = 1; i <= int.Parse(this.txtQtdeParcelas.Text); i++)
                {
                    //-- Novo item
                    this.agParcelas.Novo_Item();

                    //-- Trata os dados para incluir no DB
                    this.grdParcelas.CurrentRow["Parcela"] = i.ToString();
                    this.grdParcelas.CurrentRow["Data_Cadastro"] = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    this.grdParcelas.CurrentRow["Data_Emissao"] = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    this.grdParcelas.CurrentRow["Parcela_Paga"] = false;
                    this.grdParcelas.CurrentRow["Protesto"] = false;

                    //-- Verifica o tipo de parcelamento.
                    if (this.opgParcelamento_DiaFixo.Checked)
                    {
                        DateTime dt = Convert.ToDateTime(this.txtPrimeiraDataVencimento.EditValue).AddMonths(i - 1);
                        this.grdParcelas.CurrentRow["Data_Vencimento"] = dt;
                    }

                    if (this.optParcelamento_EmDias.Checked)
                    {
                        int iSomaDias = 0;

                        iSomaDias = int.Parse(this.txtParcelamentoQtde.Text) * (i - 1);

                        DateTime dt = Convert.ToDateTime(this.txtPrimeiraDataVencimento.EditValue).AddDays(iSomaDias);
                        this.grdParcelas.CurrentRow["Data_Vencimento"] = dt;
                    }

                    //-- Faz o calculo dos valores das parcelas
                    if (i != int.Parse(this.txtQtdeParcelas.Text))
                    {
                        this.grdParcelas.CurrentRow["Valor_Original"] = Convert.ToString(decimal.Round(Convert.ToDecimal(this.txtValorOriginal.Text) / Convert.ToInt32(this.txtQtdeParcelas.Text), 2));
                        this.grdParcelas.CurrentRow["Valor_Receber"] = Convert.ToString(decimal.Round(Convert.ToDecimal(this.txtValorPagar.Text) / Convert.ToInt32(this.txtQtdeParcelas.Text), 2));
                    }
                    else
                    {
                        if (i == 1)
                        {
                            this.grdParcelas.CurrentRow["Valor_Original"] = Convert.ToString(decimal.Round(Convert.ToDecimal(this.txtValorOriginal.Text) / Convert.ToInt32(this.txtQtdeParcelas.Text)));
                            this.grdParcelas.CurrentRow["Valor_Receber"] = Convert.ToString(decimal.Round(Convert.ToDecimal(this.txtValorPagar.Text) / Convert.ToInt32(this.txtQtdeParcelas.Text)));
                        }
                        else
                        {
                            decimal dSubTotal = Convert.ToDecimal(this.DataSetLocal.Tables["Contas_Receber_parcela"].Compute("sum(Valor_Receber)", ""));

                            this.grdParcelas.CurrentRow["Valor_Original"] = Convert.ToString(Convert.ToDecimal(this.txtValorOriginal.Text) - dSubTotal);
                            this.grdParcelas.CurrentRow["Valor_Receber"] = Convert.ToString(Convert.ToDecimal(this.txtValorPagar.Text) - dSubTotal);
                        }
                    }

                    f.Atual_Progresso = i;
                }

                f.Close();
            }
            else
            {
                MsgBox.Show("Erro ao realizar parcelamento automático.\n" + sErro
                    , "Alerta"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Asterisk);
            }
        }

        private void agParcelas_user_After_Click_All_Button_OnClick()
        {
            if (this.grdParcelas.Rows.Count <= 0)
            {
                if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
                    this.cmdGerarParcelas.Enabled = true;
                else
                    this.cmdGerarParcelas.Enabled = false;
            }
            else
                this.cmdGerarParcelas.Enabled = false;
        }

        private void txtDescCliente_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtDescCliente.LookUpRetorno != null)
            {
                this.txtCliente.Text = this.txtDescCliente.LookUpRetorno[0].ToString();
            }
        }

        private bool agParcelas_user_Before_Excluir_OnClick()
        {
            return default(bool);
        }

        private void agParcelas_user_After_Novo_OnClick()
        {
            this.grdParcelas.CurrentRow["Data_Cadastro"] = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        }

        private void grdParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (this.grdParcelas.BindingSource.Current != null)
            {
                if ((e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 5) && (this.FormStatus == CompSoft.TipoFormStatus.Modificando || this.FormStatus == CompSoft.TipoFormStatus.Novo))
                {
                    DataRowView row = this.grdParcelas.BindingSource.Current as DataRowView;
                    if (!Convert.ToBoolean(row["Parcela_Paga"]))
                        this.grdParcelas.EditMode = DataGridViewEditMode.EditOnEnter;
                    else
                        this.grdParcelas.EditMode = DataGridViewEditMode.EditProgrammatically;
                }
                else
                    this.grdParcelas.EditMode = DataGridViewEditMode.EditProgrammatically;
            }*/
        }

        private void grdParcelas_EditModeChanged(object sender, EventArgs e)
        {
            //this.grdParcelas.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private bool f0020_user_BeforeSave()
        {
            //-- Exclui o titulo a receber.
            Funcoes func;
            if (Convert.ToBoolean(func.Busca_Propriedade("Gera_Consiliacao_Automatica")))
            {
                DataView dv = new DataView(this.DataSetLocal.Tables["Contas_Receber_Parcela"]
                            , string.Empty
                            , string.Empty
                            , DataViewRowState.CurrentRows);

                foreach (DataRowView row in dv)
                {
                    string sQuery = string.Format("select Parcela_paga from Contas_Receber_Parcela where Conta_Receber_Parcela = {0}", row["Conta_Receber_Parcela"]);
                    bool bParcelaPaga_DB = Convert.ToBoolean(SQL.ExecuteScalar(sQuery, true))
                        , bParcelaPaga_Atu = Convert.ToBoolean(row["Parcela_Paga"]);

                    if (!bParcelaPaga_Atu && bParcelaPaga_Atu != bParcelaPaga_DB)
                    {
                        DataRowView row_CR = this.BindingSource[this.MainTabela].Current as DataRowView;

                        Financeiro.ConsiliacaoFinanceira cf = new Financeiro.ConsiliacaoFinanceira();
                        cf.Cancelar_Baixa_ContaReceber(Convert.ToInt32(row_CR["Nota_Fiscal"]), Convert.ToInt32(row["Conta_Receber_Parcela"]));
                    }
                }

                SQL.Fechar_Conexao();
            }

            return true;
        }

        private void grdParcelas_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //this.grdParcelas.EndEdit();
        }
    }
}