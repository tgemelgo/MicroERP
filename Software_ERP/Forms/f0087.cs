using System;
using System.Text;

namespace ERP.Forms
{
    public partial class f0087 : CompSoft.FormSet
    {
        private const string sQuery_EspecieDoc = "select EspecieDoc, Desc_EspecieDoc " +
                                                    "from dbo.Boletos_Especies_Documentos " +
                                                    "where " +
                                                    "     inativo = 0 " +
                                                    " {0} " +
                                                    "order by Desc_EspecieDoc";

        #region Construtor

        public f0087()
        {
            StringBuilder sb = new StringBuilder(500);
            sb.AppendLine("select ");
            sb.AppendLine("   Boletos_Gerados.Boleto_gerado");
            sb.AppendLine(" , Boletos_Gerados.Empresa");
            sb.AppendLine(" , e.Nome_Fantasia");
            sb.AppendLine(" , nfd.Nota_Fiscal_Duplicata");
            sb.AppendLine(" , nfd.Numero_Parcela");
            sb.AppendLine(" , nfd.Data_Vencimento");
            sb.AppendLine(" , nfd.Valor_Duplicata");
            sb.AppendLine(" , Boletos_Gerados.Data_Documento");
            sb.AppendLine(" , Boletos_Gerados.Conta_Corrente");
            sb.AppendLine(" , b.Descr_Banco");
            sb.AppendLine(" , cc.Agencia");
            sb.AppendLine(" , cc.Numero_Conta");
            sb.AppendLine(" , cc.Boleto_Carteira");
            sb.AppendLine(" , Boletos_Gerados.Banco");
            sb.AppendLine(" , Boletos_Gerados.EspecieDoc");
            sb.AppendLine(" , bed.Desc_EspecieDoc");
            sb.AppendLine(" , Boletos_Gerados.Codigo_Barras");
            sb.AppendLine(" , Boletos_Gerados.Linha_Digitavel");
            sb.AppendLine(" , Boletos_Gerados.ArquivoRemessao_Enviado");
            sb.AppendLine(" , Boletos_Gerados.ArquivoRemessa_Lote");
            sb.AppendLine(" , Boletos_Gerados.Boleto_Impresso");
            sb.AppendLine(" , Boletos_Gerados.Boleto_Pago");
            sb.AppendLine(" , Boletos_Gerados.Data_Pagamento");
            sb.AppendLine(" , boletos_gerados.Valor_Pago");
            sb.AppendLine(" from boletos_gerados");
            sb.AppendLine("  inner join contas_correntes cc on cc.conta_corrente = Boletos_Gerados.conta_corrente");
            sb.AppendLine("  inner join bancos b on b.banco = cc.banco");
            sb.AppendLine("  inner join Boletos_Especies_Documentos bed on bed.banco = cc.banco and bed.EspecieDoc = cc.Boleto_EspecieDoc");
            sb.AppendLine("  inner join empresas e on e.empresa = Boletos_Gerados.empresa");
            sb.AppendLine("  inner join Notas_Fiscais_Duplicatas nfd on nfd.Nota_Fiscal_Duplicata = Boletos_Gerados.nota_fiscal_duplicata");
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                    , "Boletos_Gerados"
                    , sb.ToString()
                    , "Boleto_Gerado"));

            sb.Remove(0, sb.Length);
            sb.AppendLine("select ");
            sb.AppendLine("   Boletos_Gerados_Instrucoes.Boleto_Gerado_Instrucao");
            sb.AppendLine(" , Boletos_Gerados_Instrucoes.Boleto_Gerado");
            sb.AppendLine(" , Boletos_Gerados_Instrucoes.Boleto_Instrucao");
            sb.AppendLine(" , coalesce(Boletos_Gerados_Instrucoes.Mensagem_Customizada, bi.Desc_Boleto_Instrucao) as 'Mensagem_Customizada'");
            sb.AppendLine(" from Boletos_Gerados_Instrucoes");
            sb.AppendLine("  inner join Boletos_Instrucoes bi on Boletos_Gerados_Instrucoes.Boleto_Instrucao = bi.Boleto_Instrucao");
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Filha
                    , "Boletos_Gerados_Instrucoes"
                    , sb.ToString()
                    , "Boleto_Gerado_Instrucao"));

            InitializeComponent();
        }

        #endregion Construtor

        private void cboBanco_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo
                    || this.FormStatus == CompSoft.TipoFormStatus.Modificando
                    || this.FormStatus == CompSoft.TipoFormStatus.Pesquisar)
            {
                if (this.cboBanco.SelectedValue != null)
                {
                    object oValor = null;
                    if (this.CurrentRow != null)
                        oValor = this.CurrentRow[this.cboEspecieDoc.ControlSource];

                    this.cboEspecieDoc.SQLStatement = string.Format(sQuery_EspecieDoc
                                , string.Format("and banco = {0}", this.cboBanco.SelectedValue));

                    if (oValor != null)
                    {
                        this.CurrentRow.BeginEdit();
                        this.CurrentRow[this.cboEspecieDoc.ControlSource] = oValor;
                        this.CurrentRow.EndEdit();
                    }

                    string sQuery = "select Codigo_Instrucao, Desc_Boleto_Instrucao as 'Mensagem_Customizada' from boletos_instrucoes where banco = {0} order by Desc_Boleto_Instrucao";
                    this.Column1.SQLStatement = string.Format(sQuery, this.cboBanco.SelectedValue);
                }
                else
                {
                    this.cboEspecieDoc.SQLStatement = string.Format(sQuery_EspecieDoc, string.Empty);
                    this.Column1.SQLStatement = string.Empty;
                }
            }
        }

        private void f0087_user_AfterRefreshData()
        {
            this.grdInstrucao.DataSource = this.DataSetLocal.Tables["Boletos_Gerados_Instrucoes"];

            this.cboBanco_SelectedValueChanged(this, EventArgs.Empty);
        }

        private void f0087_user_FormStatus_Change()
        {
            this.acInstrucao.Status_Form = this.FormStatus;

            switch (this.FormStatus)
            {
                case CompSoft.TipoFormStatus.Limpar:
                    this.Change_Group("BOLETO", true);
                    break;

                default:
                    this.Change_Group("BOLETO", false);
                    break;
            }
        }

        private void f0087_Load(object sender, EventArgs e)
        {
            this.acInstrucao.Grid_Trabalho = this.grdInstrucao;
        }
    }
}