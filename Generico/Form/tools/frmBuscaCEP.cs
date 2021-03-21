using CompSoft;
using CompSoft.compFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Tools
{
    public partial class LocalizarCEP : FormSet
    {
        private string sDatabase = string.Empty;
        private string sEndereco = string.Empty;
        private string sNumero = string.Empty;
        private string sComplemento = string.Empty;
        private string sBairro = string.Empty;
        private string sCidade = string.Empty;
        private string sEstado = string.Empty;
        private string sCEP = string.Empty;

        #region "Propriedades do formulário."

        public string Endereco
        {
            get { return sEndereco; }
            set { sEndereco = value; }
        }

        public string Numero
        {
            get { return sNumero; }
            set { sNumero = value; }
        }

        public string Complemento
        {
            get { return sComplemento; }
            set { sComplemento = value; }
        }

        public string Bairro
        {
            get { return sBairro; }
            set { sBairro = value; }
        }

        public string Cidade
        {
            get { return sCidade; }
            set { sCidade = value; }
        }

        public string Estado
        {
            get { return sEstado; }
            set { sEstado = value; }
        }

        public string CEP
        {
            get { return sCEP; }
            set { sCEP = value; }
        }

        #endregion "Propriedades do formulário."

        #region "Construtores"

        public LocalizarCEP(bool AbrirBusca)
        {
            Funcoes func;
            sDatabase = func.Busca_Propriedade("Banco_CEP_Correio");

            this.Tabelas.Add(new Data.Controle_Tabelas(Data.Controle_Tabelas.TiposTabelas.Pai
                , "Logradouros"
                , string.Format("Select * from {0}..Logradouros", sDatabase)
                , "CEP"));

            InitializeComponent();

            if (AbrirBusca)
                this.ShowDialog();
        }

        public LocalizarCEP(bool AbrirBusca, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string Estado, string CEP)
        {
            Funcoes func;
            sDatabase = func.Busca_Propriedade("Banco_CEP_Correio");

            this.Tabelas.Add(new Data.Controle_Tabelas(Data.Controle_Tabelas.TiposTabelas.Pai
                , "Logradouros"
                , string.Format("Select * from {0}..Logradouros", sDatabase)
                , "CEP"));

            InitializeComponent();

            this.Endereco = Endereco;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.Estado = Estado;
            this.CEP = CEP;

            if (AbrirBusca)
                this.ShowDialog();
        }

        #endregion "Construtores"

        //-- Faz as condições do select.
        public override string user_Query(string Tabela)
        {
            string sCondicao = string.Empty;

            //-- Verifica se os campos faram parte do Select
            //-- Endereço
            if (!string.IsNullOrEmpty(this.txtEnderecoBusca.Text))
            {
                if (sCondicao != string.Empty)
                    sCondicao += string.Format("  and Endereco like '%{0}%'", this.txtEnderecoBusca.Text);
                else
                    sCondicao += string.Format("      Endereco like '%{0}%'", this.txtEnderecoBusca.Text);
            }

            //-- Bairro
            if (!string.IsNullOrEmpty(this.txtBairroBusca.Text))
            {
                if (sCondicao != string.Empty)
                    sCondicao += string.Format("  and Bairro like '%{0}%'", this.txtBairroBusca.Text);
                else
                    sCondicao += string.Format("      Bairro like '%{0}%'", this.txtBairroBusca.Text);
            }

            //-- Cidade
            if (!string.IsNullOrEmpty(this.txtCidadeBusca.Text))
            {
                if (sCondicao != string.Empty)
                    sCondicao += string.Format("  and Cidade like '%{0}%'", this.txtCidadeBusca.Text);
                else
                    sCondicao += string.Format("      Cidade like '%{0}%'", this.txtCidadeBusca.Text);
            }

            //-- Estado
            if (!string.IsNullOrEmpty(this.txtEstado.Text))
            {
                if (sCondicao != string.Empty)
                    sCondicao += string.Format("  and Estado like '%{0}%'", this.txtEstado.Text);
                else
                    sCondicao += string.Format("      Estado like '%{0}%'", this.txtEstado.Text);
            }

            //-- CEP
            if (!string.IsNullOrEmpty(this.txtCEPBusca.Text))
            {
                if (sCondicao != string.Empty)
                    sCondicao += string.Format("  and CEP = '{0}'", this.txtCEPBusca.Text);
                else
                    sCondicao += string.Format("      CEP = '{0}'", this.txtCEPBusca.Text);
            }

            return sCondicao;
        }

        private void cmdExportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNumeroSel.Text))
            {
                MsgBox.Show("- O Número do logradouro tem que ser preenchido."
                    , "Alerta"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Asterisk);
            }
            else
            {
                //-- Faz o retorno dos dados nas colunas selecionadas.
                this.Bairro = this.txtBairroSel.Text;
                this.Cidade = this.txtCidadeSel.Text;
                this.Endereco = this.txtEnderecoSel.Text;
                this.Estado = this.txtEstadoSel.Text;
                this.CEP = this.txtCEPSel.Text;
                this.Numero = this.txtNumeroSel.Text;
                this.Complemento = this.txtCompSel.Text;
                this.Close();
            }
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {
            //-- Localiza os registros.

            this.txtEnderecoBusca.ReadOnly = false;
            this.txtBairroBusca.ReadOnly = false;
            this.txtCidadeBusca.ReadOnly = false;
            this.txtEstado.ReadOnly = false;
            this.txtCEPBusca.ReadOnly = false;
            this.txtNumeroSel.ReadOnly = false;
            this.txtCompSel.ReadOnly = false;

            this.PesquisarDados();
        }

        protected override void OnLoad(EventArgs e)
        {
            //-- Alimenta os campos de acordo com as propriedades.
            this.txtBairroBusca.Text = this.Bairro;
            this.txtCidadeBusca.Text = this.Cidade;
            this.txtEnderecoBusca.Text = this.Endereco;
            this.txtEstado.Text = this.Estado;
            this.txtCEPBusca.Text = this.CEP;

            base.OnLoad(e);

            this.cf_DataGrid1.DataSource = new BindingSource(this.DataSetLocal.Tables[this.MainTabela], null);

            this.Text = "Localizador de Endereço";
        }

        protected override void OnShown(EventArgs e)
        {
            //--base.OnShown(e);
        }

        private void cmdNovaPesquisa_Click(object sender, EventArgs e)
        {
            this.txtEnderecoBusca.Text = string.Empty;
            this.txtBairroBusca.Text = string.Empty;
            this.txtCidadeBusca.Text = string.Empty;
            this.txtEstado.Text = string.Empty;
            this.txtCEPBusca.Text = string.Empty;
            this.Limpar();
        }

        private void LocalizarCEP_user_AfterRefreshData()
        {
            this.cf_DataGrid1.DataSource = this.DataSetLocal.Tables[this.MainTabela];
        }

        private void cf_DataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.cf_DataGrid1.CurrentRow != null)
            {
                DataRowView row = (DataRowView)this.cf_DataGrid1.CurrentRow;

                txtEnderecoSel.Text = row["Endereco"].ToString();
                txtBairroSel.Text = row["Bairro"].ToString();
                txtCidadeSel.Text = row["Cidade"].ToString();
                txtEstadoSel.Text = row["Estado"].ToString();
                txtCEPSel.Text = row["CEP"].ToString();
            }
            else
            {
                txtEnderecoSel.Text = string.Empty;
                txtBairroSel.Text = string.Empty;
                txtCidadeSel.Text = string.Empty;
                txtEstadoSel.Text = string.Empty;
                txtCEPSel.Text = string.Empty;
            }
        }

        private void LocalizarCEP_user_FormStatus_Change()
        {
            this.Text = "Busca de CEP";
        }

        private void LocalizarCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
                this.Close();
        }
    }
}