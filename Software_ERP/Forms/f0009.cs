using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0009 : CompSoft.FormSet
    {
        public f0009()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Vendedores"
                , "select * from vendedores"));

            InitializeComponent();
        }

        private void cmdBuscar_Corres_Click(object sender, EventArgs e)
        {
            //-- Abre o formúlario para fazer busca do cep.
            LocalizarCEP cep = new LocalizarCEP(true,
                this.txtEndereco.Text,
                this.txtNumero.Text,
                this.txtComplemento.Text,
                this.txtBairro.Text,
                this.txtCidade.Text,
                this.txtEstado.Text,
                this.txtCEP.Text);

            //-- Verifica qual foi o retorno e atualiza os campos.
            this.txtEndereco.Text = cep.Endereco;
            this.txtNumero.Text = cep.Numero;
            this.txtComplemento.Text = cep.Complemento;
            this.txtBairro.Text = cep.Bairro;
            this.txtCidade.Text = cep.Cidade;
            this.txtEstado.Text = cep.Estado;
            this.txtCEP.Text = cep.CEP;
        }

        private void f0009_Load(object sender, EventArgs e)
        {
            Funcoes func;
            this.txtCPF.Mask = func.Busca_Propriedade("CPF_Masc");
            this.txtCEP.Mask = func.Busca_Propriedade("CEP_Masc");
            this.txtfone1.Mask = func.Busca_Propriedade("Telefone_Masc");
            this.txtfone2.Mask = func.Busca_Propriedade("Telefone_Masc");
        }

        private void txtCPF_Validating(object sender, CancelEventArgs e)
        {
            Funcoes func;
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
            {
                if (!string.IsNullOrEmpty(this.txtCPF.Text) && !func.ValidarCPF(this.txtCPF.Text))
                {
                    MsgBox.Show("CPF inválido, tente novamente."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Asterisk);

                    e.Cancel = true;
                }
                else
                {
                    string sSQL = string.Empty;
                    sSQL += "select count(vendedor) from vendedores where cpf = '{0}'";
                    sSQL = string.Format(sSQL, this.txtCPF.Text);

                    int iValor = (int)SQL.ExecuteScalar(sSQL);
                    if (iValor > 0)
                    {
                        e.Cancel = true;
                        MsgBox.Show("Não é possivel cadastrar este CPF, pois ele já existe na base de dados."
                                        , "Atenção"
                                        , MessageBoxButtons.OK
                                        , MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void txtCPF_Validated(object sender, EventArgs e)
        {
            if ((this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
                && !string.IsNullOrEmpty(this.txtCPF.Text))
            {
                DataRowView drw = (DataRowView)this.BindingSource[this.MainTabela].Current;

                string sSQL = string.Empty;
                sSQL += "select";
                sSQL += "   Nome as 'Nome_Vendedor'";
                sSQL += " , CPF";
                sSQL += " , RG";
                sSQL += " , Endereco";
                sSQL += " , Numero";
                sSQL += " , Complemento";
                sSQL += " , Bairro";
                sSQL += " , Cidade";
                sSQL += " , Estado";
                sSQL += " , CEP";
                sSQL += " , DDD1";
                sSQL += " , Fone1";
                sSQL += " , DDD2";
                sSQL += " , Fone2";
                sSQL += " from funcionarios";
                sSQL += " where cpf = '{0}'";
                sSQL = string.Format(sSQL, this.txtCPF.Text);
                DataTable dt_Func = SQL.Select(sSQL, "x", false);

                //-- Varre os registros
                foreach (DataRow row in dt_Func.Select())
                {
                    drw.BeginEdit();

                    foreach (DataColumn dc in dt_Func.Columns)
                        drw[dc.ColumnName] = row[dc.ColumnName];

                    drw.EndEdit();
                }
            }
        }
    }
}