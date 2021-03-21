using CompSoft;
using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0011 : FormSet
    {
        private bool bCheck_Status_Fornecedor = true,
             bCheck_Status_Cliente = true;

        public f0011()
        {
            string sSQL_ct = string.Empty;

            sSQL_ct = string.Empty;
            sSQL_ct += "select clientes.*";
            sSQL_ct += "  , v.Nome_Vendedor";
            sSQL_ct += "  , tr.Nome_Fantasia as [Nome_Transportadora]";
            sSQL_ct += "  , tp.desc_tabela_preco";
            sSQL_ct += " from clientes ";
            sSQL_ct += "  left outer join transportadoras tr on tr.transportadora = clientes.transportadora";
            sSQL_ct += "  left outer join vendedores v on v.vendedor = clientes.vendedor";
            sSQL_ct += "  left outer join tabelas_precos tp on tp.tabela_preco = clientes.tabela_preco";
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Clientes"
                , sSQL_ct));

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "Clientes_Contatos"
                , "Select * from Clientes_Contatos"));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            string sSQLFilter = string.Empty;

            if (TabelaAtual == "Clientes")
            {
                if (this.chkFornecedor.Checked)
                {
                    if (!string.IsNullOrEmpty(sSQLFilter))
                        sSQLFilter += " AND ";

                    sSQLFilter += " Clientes.Tipo_Fornecedor = 1 ";
                }

                if (this.chkCliente.Checked)
                {
                    if (!string.IsNullOrEmpty(sSQLFilter))
                        sSQLFilter += " AND ";

                    sSQLFilter += " Clientes.Tipo_Cliente = 1 ";
                }
            }

            return sSQLFilter;
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
                this.txtEstado_Corres.Text,
                this.txtCEP_Corres.Text);

            //-- Verifica qual foi o retorno e atualiza os campos.
            this.txtEndereco_Corres.Text = cep.Endereco;
            this.txtNumero_Corres.Text = cep.Numero;
            this.txtComplemento_Corres.Text = cep.Complemento;
            this.txtBairro_Corres.Text = cep.Bairro;
            this.txtCidade_Corres.Text = cep.Cidade;
            this.txtEstado_Corres.Text = cep.Estado;
            this.txtCEP_Corres.Text = cep.CEP;
        }

        private void txtCNPJ_Validating(object sender, CancelEventArgs e)
        {
            Funcoes func;
            bool bVerifica_Existencia = true;
            if (this.chkPessoaJuridica.Checked)
            {
                if (!string.IsNullOrEmpty(txtCNPJ.Text) && !func.ValidarCnpj(txtCNPJ.Text))
                {
                    MsgBox.Show("CNPJ inválido, confira e regidite o dado"
                        , "Alerta"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Stop);
                    e.Cancel = true;
                    bVerifica_Existencia = false;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCNPJ.Text) && !func.ValidarCPF(txtCNPJ.Text))
                {
                    MsgBox.Show("CPF inválido, confira e regidite o dado"
                        , "Alerta"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Stop);
                    e.Cancel = true;
                    bVerifica_Existencia = false;
                }
            }

            //-- Verifiva se já existe um CPF/CNPJ cadatrado com este número.
            if (bVerifica_Existencia)
            {
                string sSQL = string.Empty;
                sSQL += "select count(cliente) from clientes where CPF_CNPJ = '{0}'";
                string.Format(sSQL, this.txtCNPJ.Text);

                int iExiste = (int)CompSoft.Data.SQL.ExecuteScalar(sSQL);
                if (iExiste > 0)
                {
                    e.Cancel = true;
                    MsgBox.Show("O CPF/CNPJ já está cadastrado, tente novamente."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                }
            }
        }

        private void frmCadClientes_user_AfterRefreshData()
        {
            this.lstContatos.DataSource = this.DataSetLocal.Tables["Clientes_Contatos"];

            this.lblClientes.Text = this.txtRazaoSocial.Text;
        }

        private void FrmCadClientesuser_AfterNew()
        {
            this.txtDtAtu.Text = DateTime.Now.ToShortDateString();
            this.txtDtCad.Text = DateTime.Now.ToShortDateString();
            this.chkPessoaJuridica.Checked = true;

            DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
            row["Tipo_Cliente"] = true;
        }

        private void FrmCadClientesuser_FormStatus_Change()
        {
            switch (this.FormStatus)
            {
                case CompSoft.TipoFormStatus.Modificando:
                    this.txtDtAtu.Text = DateTime.Now.ToShortDateString();
                    this.chkFornecedor.Checked = true;
                    break;

                case CompSoft.TipoFormStatus.Limpar:
                    this.chkFornecedor.Checked = bCheck_Status_Fornecedor;
                    this.chkCliente.Checked = bCheck_Status_Cliente;
                    break;
            }

            this.acContatos.Status_Form = this.FormStatus;
        }

        private void frmCadClientes_Load(object sender, EventArgs e)
        {
            Funcoes func;
            this.txtCNPJ.Mask = func.Busca_Propriedade("CNPJ_Masc");
            this.txtCEP_Corres.Mask = func.Busca_Propriedade("CEP_Masc");
            string sMaskTelefone = func.Busca_Propriedade("Telefone_Masc");
            this.txtFone1.Mask = sMaskTelefone;
            this.txtFone2.Mask = sMaskTelefone;
            this.txtFone3.Mask = sMaskTelefone;
            this.colTelefone.Mask = sMaskTelefone;

            this.acContatos.Grid_Trabalho = this.lstContatos;
        }

        private void chkPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            Funcoes func;
            if (this.chkPessoaJuridica.Checked)
            {
                this.txtCNPJ.Mask = func.Busca_Propriedade("CNPJ_Masc");
                this.lblRazao.Text = "Razão social:";
                this.lblDtNasc.Text = "Dt. fundação:";
                this.lblProfissao.Text = "Ramo de atividade:";
                this.lblRG.Text = "I.E.:";
                this.lblCPF.Text = "CNPJ:";
                this.cboEstadoCivil.Enabled = false;
                this.cboSexo.Enabled = false;
                this.txtNomeFantasia.Enabled = true;
            }
            else
            {
                this.txtCNPJ.Mask = func.Busca_Propriedade("CPF_Masc");
                this.lblRazao.Text = "Nome cliente:";
                this.lblDtNasc.Text = "Dt. Nasc.:";
                this.lblProfissao.Text = "Profissão:";
                this.lblRG.Text = "RG:";
                this.lblCPF.Text = "CPF:";
                this.cboEstadoCivil.Enabled = true;
                this.cboSexo.Enabled = true;
                this.txtNomeFantasia.Enabled = false;
            }
        }

        private void txtRazaoSocial_Validated(object sender, EventArgs e)
        {
            this.lblClientes.Text = this.txtRazaoSocial.Text;
        }

        private void f0002_user_AfterClear()
        {
            this.lblClientes.Text = string.Empty;
            this.chkFornecedor.Checked = true;
        }

        private bool f0011_user_BeforeSearch()
        {
            bCheck_Status_Fornecedor = this.chkFornecedor.Checked;
            bCheck_Status_Cliente = this.chkCliente.Checked;

            return true;
        }
    }
}