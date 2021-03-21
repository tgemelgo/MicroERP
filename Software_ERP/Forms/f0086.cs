using System;
using System.Text;

namespace ERP.Forms
{
    public partial class f0086 : CompSoft.FormSet
    {
        private const string sQuery = "select EspecieDoc, Desc_EspecieDoc from Boletos_Especies_Documentos where inativo = 0 and banco = {0} order by Desc_EspecieDoc";

        public f0086()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                        , "contas_correntes"
                        , "select * from contas_correntes"));

            StringBuilder sb = new StringBuilder(300);
            sb.AppendLine("select contas_correntes_boletos_instrucoes.*, bi.Desc_Boleto_Instrucao");
            sb.AppendLine(" from contas_correntes_boletos_instrucoes");
            sb.AppendLine("  inner join boletos_instrucoes bi on bi.boleto_instrucao = contas_correntes_boletos_instrucoes.boleto_instrucao");
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Filha
                        , "contas_correntes_boletos_instrucoes"
                        , sb.ToString()));

            InitializeComponent();
        }

        private void cboEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando) && this.cboBanco.SelectedIndex >= 0)
            {
                object oValorEspecie = this.CurrentRow["Boleto_EspecieDoc"];
                this.cboEspecieDoc.SQLStatement = string.Format(sQuery, this.cboBanco.SelectedValue);
                this.cboEspecieDoc.SelectedValue = oValorEspecie;
            }

            //-- filtra dados do lookup do grid.
            if (this.cboBanco.SelectedIndex >= 0)
            {
                this.colCodInstrucao.SQLStatement = string.Format("select Boleto_Instrucao, Codigo_Instrucao, Desc_Boleto_Instrucao from boletos_instrucoes where banco = {0} order by Desc_Boleto_Instrucao", this.cboBanco.SelectedValue);
            }
        }

        private void f0086_user_FormStatus_Change()
        {
            this.acInstrucoes.Status_Form = this.FormStatus;
            if (this.FormStatus == CompSoft.TipoFormStatus.Limpar)
            {
                this.cboEspecieDoc.SQLStatement = string.Empty;
            }
        }

        private void f0086_Load(object sender, EventArgs e)
        {
            this.acInstrucoes.Grid_Trabalho = this.grdInstrucoes;
        }

        private void f0086_user_AfterRefreshData()
        {
            this.grdInstrucoes.DataSource = this.DataSetLocal.Tables["contas_correntes_boletos_instrucoes"];
        }
    }
}