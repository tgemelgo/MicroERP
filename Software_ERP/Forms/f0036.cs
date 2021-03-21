using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0036 : CompSoft.FormSet
    {
        public f0036()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   f.Funcionario");
            sb.AppendLine(" , f.Motorista");
            sb.AppendLine(" , f.Nome");
            sb.AppendLine(" , f.Endereco");
            sb.AppendLine(" , f.Numero");
            sb.AppendLine(" , f.Complemento");
            sb.AppendLine(" , f.Bairro");
            sb.AppendLine(" , f.Cidade");
            sb.AppendLine(" , f.Estado");
            sb.AppendLine(" , f.CEP");
            sb.AppendLine(" , f.DDD1");
            sb.AppendLine(" , f.Fone1");
            sb.AppendLine(" , f.DDD2");
            sb.AppendLine(" , f.Fone2");
            sb.AppendLine(" , f.Nome_Pai");
            sb.AppendLine(" , f.Nome_Mae");
            sb.AppendLine(" , f.Departamento");
            sb.AppendLine(" , d.Desc_Departamento");
            sb.AppendLine(" , f.Funcao");
            sb.AppendLine(" , f.Jornada_Diaria");
            sb.AppendLine(" , f.Entrada_Manha");
            sb.AppendLine(" , f.Saida_Manha");
            sb.AppendLine(" , f.Entrada_Tarde");
            sb.AppendLine(" , f.Saida_Tarde");
            sb.AppendLine(" , f.Data_Nascimento");
            sb.AppendLine(" , f.Cidade_Nascimento");
            sb.AppendLine(" , f.Estado_Nascimento");
            sb.AppendLine(" , f.Data_Admissao");
            sb.AppendLine(" , f.Data_Demissao");
            sb.AppendLine(" , f.Matricula");
            sb.AppendLine(" , f.Escolaridade");
            sb.AppendLine(" , e.Desc_Escolaridade");
            sb.AppendLine(" , f.Nacionalidade");
            sb.AppendLine(" , f.Estado_Civil");
            sb.AppendLine(" , ec.Desc_Estado_Civil");
            sb.AppendLine(" , f.Tipo_Vinculo");
            sb.AppendLine(" , tv.Desc_Tipo_Vinculo");
            sb.AppendLine(" , f.Banco");
            sb.AppendLine(" , f.Agencia");
            sb.AppendLine(" , f.Conta_Corrente");
            sb.AppendLine(" , f.Tipo_Conta");
            sb.AppendLine(" , tc.Desc_Tipo_Conta");
            sb.AppendLine(" , f.RG");
            sb.AppendLine(" , f.RG_Data_Emissao");
            sb.AppendLine(" , f.RG_Orgao_Emissao");
            sb.AppendLine(" , f.Titulo_Eleitor");
            sb.AppendLine(" , f.CPF");
            sb.AppendLine(" , f.Carteira_Proficional");
            sb.AppendLine(" , f.Serie");
            sb.AppendLine(" , f.Pis");
            sb.AppendLine(" , f.Qtde_Dependentes");
            sb.AppendLine(" , f.Qtde_Filhos");
            sb.AppendLine(" , f.Valor_Salario");
            sb.AppendLine(" , f.Valor_Perioculosidade");
            sb.AppendLine(" , f.Valor_Adicional_Noturno");
            sb.AppendLine(" , f.Valor_Seguro");
            sb.AppendLine(" , f.Data_Adesao");
            sb.AppendLine(" , f.Observacao");
            sb.AppendLine(" , f.Inativo");
            sb.AppendLine(" from funcionarios f");
            sb.AppendLine("  left outer join departamentos d on d.departamento = f.departamento");
            sb.AppendLine("  left outer join Escolaridades e on e.escolaridade = f.escolaridade");
            sb.AppendLine("  left outer join Tipos_Vinculos tv on tv.Tipo_Vinculo = f.Tipo_Vinculo");
            sb.AppendLine("  left outer join Tipos_Contas tc on tc.Tipo_Conta = f.Tipo_Conta");
            sb.AppendLine("  left outer join Estados_Civis ec on ec.estado_civil = f.Estado_Civil");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "Funcionarios"
                    , sb.ToString()));

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                    , "Funcionarios_Dependentes"
                    , "select * from funcionarios_dependentes"));

            InitializeComponent();
        }

        private void cmdBuscar_Corres_Click(object sender, EventArgs e)
        {
            //-- Abre o formúlario para fazer busca do cep.
            LocalizarCEP cep = new LocalizarCEP(true,
                this.txtEndereco_Corres.Text,
                this.txtNumero_Corres.Text,
                this.txtComplemento_Corres.Text,
                this.txtBairro_Corres.Text,
                this.txtCidade_Corres.Text,
                this.cboEstado.Text,
                this.txtCEP_Corres.Text);

            //-- Verifica qual foi o retorno e atualiza os campos.
            this.txtEndereco_Corres.Text = cep.Endereco;
            this.txtNumero_Corres.Text = cep.Numero;
            this.txtComplemento_Corres.Text = cep.Complemento;
            this.txtBairro_Corres.Text = cep.Bairro;
            this.txtCidade_Corres.Text = cep.Cidade;
            this.cboEstado.SelectedValue = cep.Estado;
            this.txtCEP_Corres.Text = cep.CEP;
        }

        private void Recalcula_Horas()
        {
            long lDiferencaHora = 0;
            Funcoes func;

            if (!string.IsNullOrEmpty(this.txtHoraEntradaManha.Text) && !string.IsNullOrEmpty(this.txtHoraSaidaTarde.Text))
                lDiferencaHora = func.DateDiff(Funcoes.DateInterval.Minute, Convert.ToDateTime(this.txtHoraEntradaManha.Text), Convert.ToDateTime(this.txtHoraSaidaTarde.Text));

            if (!string.IsNullOrEmpty(this.txtHoraSaidaManha.Text) && !string.IsNullOrEmpty(this.txtHoraEntradaTarde.Text))
                lDiferencaHora -= func.DateDiff(Funcoes.DateInterval.Minute, Convert.ToDateTime(this.txtHoraSaidaManha.Text), Convert.ToDateTime(this.txtHoraEntradaTarde.Text));

            if (lDiferencaHora == 0)
                this.txtJornada.Text = string.Empty;
            else
                this.txtJornada.Text = Convert.ToDateTime("00:00:00").AddMinutes(lDiferencaHora).ToShortTimeString();
        }

        private void txtHoraEntradaManha_Validated(object sender, EventArgs e)
        {
            Recalcula_Horas();
        }

        private void txtHoraSaidaManha_Validated(object sender, EventArgs e)
        {
            Recalcula_Horas();
        }

        private void txtHoraEntradaTarde_Validated(object sender, EventArgs e)
        {
            Recalcula_Horas();
        }

        private void txtHoraSaidaTarde_Validated(object sender, EventArgs e)
        {
            Recalcula_Horas();
        }

        private void f0036_Load(object sender, EventArgs e)
        {
            Funcoes func;
            this.txtCEP_Corres.Mask = func.Busca_Propriedade("CEP_Masc");
            this.txtTelefone1.Mask = func.Busca_Propriedade("Telefone_Masc");
            this.txtTelefone2.Mask = func.Busca_Propriedade("Telefone_Masc");
            this.txtCPF.Mask = func.Busca_Propriedade("CPF_Masc");
            this.acDependentes.Grid_Trabalho = this.grdDependentes;
        }

        private void txtCPF_Validating(object sender, CancelEventArgs e)
        {
            Funcoes func;
            if (!func.ValidarCPF(this.txtCPF.Text))
            {
                MsgBox.Show("CPF inválido, digite novamente!"
                    , "Alerta"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);

                e.Cancel = true;
            }
        }

        private void f0036_user_AfterRefreshData()
        {
            this.grdDependentes.DataSource = this.DataSetLocal.Tables["Funcionarios_Dependentes"];
        }

        private void f0036_user_FormStatus_Change()
        {
            this.acDependentes.Status_Form = this.FormStatus;
        }
    }
}