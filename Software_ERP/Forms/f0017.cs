using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.ComponentModel;

namespace ERP.Forms
{
    public partial class f0017 : CompSoft.FormSet
    {
        public f0017()
        {
            string sSQL = string.Empty;

            sSQL += "Select";
            sSQL += "   Contas_Pagar.*";
            sSQL += " , cl.Razao_Social";
            sSQL += " , f.Razao_Social as 'Razao_Social_Filial'";
            sSQL += " from Contas_Pagar";
            sSQL += "  inner join Empresas f on f.Empresa = Contas_Pagar.Empresa";
            sSQL += "  left outer join Clientes cl on cl.cliente = Contas_Pagar.Cliente";
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Contas_Pagar"
                , sSQL));

            sSQL = string.Empty;
            sSQL += "select * from Contas_Pagar_Parcela";
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "Contas_Pagar_Parcela"
                , sSQL));

            InitializeComponent();
        }

        private void txtFilial_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtFilial.LookUpRetorno != null)
                this.txtDescFilial.Text = this.txtFilial.LookUpRetorno[1].ToString();
        }

        private void txtCliente_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCliente.LookUpRetorno != null)
                this.txtDescCliente.Text = this.txtCliente.LookUpRetorno[1].ToString();
        }

        private void frmCad_ContasPagar_user_AfterNew()
        {
            this.txtDtCadastro.EditValue = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Funcoes func;
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
            this.grdParcelas.DataSource = this.DataSetLocal.Tables["Contas_Pagar_Parcela"];

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
                this.grdParcelas.CurrentRow["Parcela_paga"] = false;

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
                    this.grdParcelas.CurrentRow["Valor_Pagar"] = Convert.ToString(decimal.Round(Convert.ToDecimal(this.txtValorPagar.Text) / Convert.ToInt32(this.txtQtdeParcelas.Text), 2));
                }
                else
                {
                    if (i == 1)
                    {
                        this.grdParcelas.CurrentRow["Valor_Original"] = Convert.ToString(decimal.Round(Convert.ToDecimal(this.txtValorOriginal.Text) / Convert.ToInt32(this.txtQtdeParcelas.Text)));
                        this.grdParcelas.CurrentRow["Valor_Pagar"] = Convert.ToString(decimal.Round(Convert.ToDecimal(this.txtValorPagar.Text) / Convert.ToInt32(this.txtQtdeParcelas.Text)));
                    }
                    else
                    {
                        decimal dSubTotal = Convert.ToDecimal(this.DataSetLocal.Tables["Contas_pagar_parcela"].Compute("sum(Valor_Pagar)", ""));

                        this.grdParcelas.CurrentRow["Valor_Original"] = Convert.ToString(Convert.ToDecimal(this.txtValorOriginal.Text) - dSubTotal);
                        this.grdParcelas.CurrentRow["Valor_Pagar"] = Convert.ToString(Convert.ToDecimal(this.txtValorPagar.Text) - dSubTotal);
                    }
                }

                f.Atual_Progresso = i;
            }

            f.Close();
        }

        private void agParcelas_user_After_Novo_OnClick()
        {
            this.grdParcelas.CurrentRow["Data_Cadastro"] = Convert.ToDateTime(DateTime.Now.ToShortDateString());
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
    }
}