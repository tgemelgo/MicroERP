using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0013 : CompSoft.FormSet
    {
        public f0013()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Transportadoras"
                , "select * from transportadoras"));

            InitializeComponent();
        }

        private void f0013_Load(object sender, EventArgs e)
        {
            Funcoes func;
            this.txtCNPJ.Mask = func.Busca_Propriedade("CNPJ_Masc");
            this.txtCEP.Mask = func.Busca_Propriedade("CEP_Masc");
            this.txtfone1.Mask = func.Busca_Propriedade("Telefone_Masc");
            this.txtfone2.Mask = func.Busca_Propriedade("Telefone_Masc");
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            //-- Abre o formúlario para fazer busca do cep.
            LocalizarCEP cep = new LocalizarCEP(true,
                this.txtEndereco.Text,
                this.txtNumero.Text,
                this.txtComplemento.Text,
                this.txtBairro.Text,
                this.txtCidade.Text,
                this.cboEstado.SelectedValue == null ? string.Empty : this.cboEstado.SelectedValue.ToString(),
                this.txtCEP.Text);

            //-- Verifica qual foi o retorno e atualiza os campos.
            this.txtEndereco.Text = cep.Endereco;
            this.txtNumero.Text = cep.Numero;
            this.txtComplemento.Text = cep.Complemento;
            this.txtBairro.Text = cep.Bairro;
            this.txtCidade.Text = cep.Cidade;
            this.cboEstado.SelectedValue = cep.Estado;
            this.txtCEP.Text = cep.CEP;
        }

        private void txtCNPJ_Validating(object sender, CancelEventArgs e)
        {
            Funcoes func;
            if (!string.IsNullOrEmpty(this.txtCNPJ.Text) && !func.ValidarCnpj(this.txtCNPJ.Text))
            {
                MsgBox.Show("CNPJ inválido, tente novamente."
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Asterisk);

                e.Cancel = true;
            }
        }

        private void txtCNPJ_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }
    }
}