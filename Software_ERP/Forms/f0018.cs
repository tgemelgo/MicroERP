using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0018 : CompSoft.FormSet
    {
        private string sNumero_lote = string.Empty;

        public f0018()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Contas_Pagar_mov"
                , "select * from vw_Contas_Pagar_Baixadas"
                , "Conta_pagar_mov"));

            InitializeComponent();
        }

        private void Encontrar_Titulos_Baixar(bool bLimpar_Tudo)
        {
            f0025 f = new f0025();
            f.Query_Padrao = "select * from vw_Contas_Pagar_Abertas";
            f.PrimaryKey = "Conta_pagar, Conta_Pagar_Parcela";

            if (f.ShowDialog() == DialogResult.OK)
            {
                if (bLimpar_Tudo)
                    this.BindingSource[this.MainTabela].CancelEdit();

                DataRow[] fRow = f.DataSetLocal.Tables["xResultado"].Select("sel = 1");
                foreach (DataRow row in fRow)
                {
                    //-- Captura as informações para inclusão de um novo registro
                    DataRowView nRow = this.BindingSource[this.MainTabela].AddNew() as DataRowView;

                    nRow["Conta_Pagar"] = row["Conta_Pagar"];
                    nRow["Conta_Pagar_Parcela"] = row["Conta_Pagar_Parcela"];
                    nRow["empresa"] = row["empresa"];
                    nRow["Cliente"] = row["Cliente"];
                    nRow["Numero_Documento"] = row["Numero_Documento"];
                    nRow["Tipo_Documento_Titulo"] = row["Tipo_Documento"];
                    nRow["Valor_Original_Titulo"] = row["Valor_Titulo"];
                    nRow["Valor_Pago_Titulo"] = row["Valor_Pago"];
                    nRow["Data_Cadastro_Titulo"] = row["Data_Cadastro_titulo"];
                    nRow["Parcela"] = row["Parcela"];
                    nRow["Data_Cadastro"] = row["Data_Cadastro"];
                    nRow["Data_Emissao"] = row["Data_Emissao"];
                    nRow["Data_Vencimento"] = row["Data_Vencimento"];
                    nRow["Valor_Original"] = row["Valor_Original"];
                    nRow["Valor_Pagar"] = row["Valor_Original"];
                    nRow["Parcela_Paga"] = false;
                    nRow["Tipo_Movimento"] = f.cboTipoMovimento.SelectedIndex < 0 ? DBNull.Value : f.cboTipoMovimento.SelectedValue;
                    nRow["Data_Movimento"] = DateTime.Now.ToShortDateString();
                    nRow["Valor_Pago"] = row["Valor_Original"];
                    nRow["Numero_Lote"] = sNumero_lote;
                    nRow["Razao_Social_Cliente"] = row["Desc_Cliente"];
                    nRow["Razao_Social_Filial"] = row["Desc_Filial"];
                }

                //-- Inclui o registro no DATASET
                this.BindingSource[this.MainTabela].EndEdit();
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
        }

        private void f0018_user_AfterRefreshData()
        {
            this.grdBaixaTitulo.DataSource = this.DataSetLocal.Tables[this.MainTabela];
            //this.DataSetLocal.Tables[this.MainTabela].Columns[0].ReadOnly = false;
        }

        private void cmdAdicionarTitulo_Baixa_Click(object sender, EventArgs e)
        {
            this.Encontrar_Titulos_Baixar(false);
        }

        private void f0018_user_AfterNew()
        {
            Funcoes func;
            sNumero_lote = func.Contador("Lote_Conta_Pagar");
            this.Encontrar_Titulos_Baixar(true);

            foreach (DataRow row in ((DataTable)this.BindingSource[this.MainTabela].DataSource).Select("conta_pagar is null"))
                row.Delete();

            this.BindingSource[this.MainTabela].EndEdit();
        }

        private void f0018_user_AfterSave()
        {
            DataRow[] fRow = this.DataSetLocal.Tables[this.MainTabela].Select();

            foreach (DataRow row in fRow)
            {
                string sSQL = string.Empty;
                sSQL += "update Contas_Pagar_Parcela set";
                sSQL += "   Valor_Pagar = {0}";
                sSQL += " , Parcela_paga = 1";
                sSQL += " where Conta_Pagar_Parcela = {1}";

                decimal dValor_Parcela = Convert.ToDecimal(row["Valor_Pagar"].ToString());
                decimal dValor_Movimento = Convert.ToDecimal(row["Valor_Pago"].ToString());

                decimal dValor_Atual = dValor_Parcela - dValor_Movimento;

                sSQL = string.Format(System.Globalization.CultureInfo.GetCultureInfo("en-us"), sSQL
                    , dValor_Atual
                    , row["Conta_Pagar_Parcela"].ToString());

                //-- Executa a atualização
                CompSoft.Data.SQL.Execute(sSQL);
            }

            Funcoes func;
            sNumero_lote = func.Contador("Lote_Conta_Pagar", true);
        }

        private void txtValorMovimento_Movimentacao_Validating(object sender, CancelEventArgs e)
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
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
        }
    }
}