using CompSoft;
using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0002 : FormSet
    {
        #region construtor

        public f0002()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine("    clientes.Cliente");
            sb.AppendLine("  , clientes.Razao_Social");
            sb.AppendLine("  , clientes.Nome_Fantasia");
            sb.AppendLine("  , clientes.Pessoa_Juridica");
            sb.AppendLine("  , clientes.RG_IE");
            sb.AppendLine("     , clientes.CPF_CNPJ");
            sb.AppendLine("     , clientes.DDD1");
            sb.AppendLine("     , clientes.Fone1");
            sb.AppendLine("     , clientes.DDD2");
            sb.AppendLine("     , clientes.Fone2");
            sb.AppendLine("     , clientes.DDD3");
            sb.AppendLine("     , clientes.Fone3");
            sb.AppendLine("  , clientes.Sexo");
            sb.AppendLine("  , clientes.Profissao_Ramo_Atividade");
            sb.AppendLine("  , clientes.Estado_Civil");
            sb.AppendLine("  , clientes.Dt_Nasc_Fundacao");
            sb.AppendLine("  , clientes.Endereco_Correspondencia");
            sb.AppendLine("  , clientes.Numero_Correspondencia");
            sb.AppendLine("  , clientes.Complemento_Correspondencia");
            sb.AppendLine("  , clientes.Bairro_Correspondencia");
            sb.AppendLine("  , clientes.Cidade_Correspondencia");
            sb.AppendLine("  , clientes.Cod_Cidade_Correspondencia_IBGE");
            sb.AppendLine("  , clientes.Estado_Correspondencia");
            sb.AppendLine("  , clientes.Cod_Estado_Correspondencia_IBGE");
            sb.AppendLine("  , clientes.CEP_Correspondencia");
            sb.AppendLine("  , clientes.Cod_Pais_Correspondencia_IBGE");
            sb.AppendLine("  , clientes.Endereco_Cobranca");
            sb.AppendLine("  , clientes.Numero_Cobranca");
            sb.AppendLine("  , clientes.Complemento_Cobranca");
            sb.AppendLine("  , clientes.Bairro_Cobranca");
            sb.AppendLine("  , clientes.Cidade_Cobranca");
            sb.AppendLine("  , clientes.Estado_Cobranca");
            sb.AppendLine("  , clientes.CEP_Cobranca");
            sb.AppendLine("  , clientes.Endereco_Entrega");
            sb.AppendLine("  , clientes.Numero_Entrega");
            sb.AppendLine("  , clientes.Complemento_Entrega");
            sb.AppendLine("  , clientes.Bairro_Entrega");
            sb.AppendLine("  , clientes.Cidade_Entrega");
            sb.AppendLine("  , clientes.Estado_Entrega");
            sb.AppendLine("  , clientes.CEP_Entrega");
            sb.AppendLine("  , clientes.Data_Cadastro");
            sb.AppendLine("  , clientes.Data_Atualizacao");
            sb.AppendLine("  , clientes.Forma_Pagamento");
            sb.AppendLine("  , clientes.Tipo_Produto_Fornece");
            sb.AppendLine("  , clientes.EMail");
            sb.AppendLine("  , clientes.Home_Page");
            sb.AppendLine("  , clientes.Tipo_Cliente");
            sb.AppendLine("  , clientes.Tipo_Fornecedor");
            sb.AppendLine("  , clientes.Vendedor");
            sb.AppendLine("  , v.Nome_Vendedor");
            sb.AppendLine("  , clientes.Transportadora");
            sb.AppendLine("  , tr.Razao_Social as [Nome_Transportadora]");
            sb.AppendLine("  , clientes.Reducao_ICMS");
            sb.AppendLine("  , clientes.Nao_Incide_ST");
            sb.AppendLine("  , Clientes.Tabela_preco");
            sb.AppendLine("  , tp.desc_tabela_preco");
            sb.AppendLine("  , clientes.Consumidor_Final");
            sb.AppendLine("  , clientes.Inadimplente");
            sb.AppendLine("  , clientes.Regime_Normal_RPA");
            sb.AppendLine("  , clientes.Observacoes");
            sb.AppendLine("  , clientes.Observacoes_Nota");
            sb.AppendLine("  , clientes.Inativo");
            sb.AppendLine(" from clientes ");
            sb.AppendLine("  left outer join transportadoras tr on tr.transportadora = clientes.transportadora");
            sb.AppendLine("  left outer join vendedores v on v.vendedor = clientes.vendedor");
            sb.AppendLine("  left outer join tabelas_precos tp on tp.tabela_preco = clientes.tabela_preco");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Clientes"
                , sb.ToString()));

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "Clientes_Contatos"
                , "Select * from Clientes_Contatos"));

            sb.Remove(0, sb.Length - 1);
            sb.AppendLine("select 0 as Cliente, tabelas_precos_itens.*, pr.Desc_Produto, pr.Valor_Venda as 'Valor_Venda_Original'");
            sb.AppendLine(" from tabelas_precos_itens");
            sb.AppendLine("  inner join produtos pr on pr.produto = tabelas_precos_itens.produto");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "Tabelas_precos_itens"
                , sb.ToString()
                , "Tabela_Preco_Item"
                , false));

            InitializeComponent();
        }

        #endregion construtor

        public override string user_Query(string TabelaAtual)
        {
            string sSQLFilter = string.Empty;

            switch (TabelaAtual.ToLower())
            {
                case "clientes":
                    if (!string.IsNullOrEmpty(sSQLFilter))
                        sSQLFilter += " AND ";

                    sSQLFilter += " Clientes.Tipo_Cliente = 1 ";
                    break;

                case "tabelas_precos_itens":
                    if (!string.IsNullOrEmpty(sSQLFilter))
                        sSQLFilter += " AND ";

                    int iTabela_Preco = 0;
                    if (this.BindingSource[this.MainTabela].Position >= 0)
                    {
                        object oValor = ((DataRowView)this.BindingSource[this.MainTabela].Current)["Tabela_Preco"];
                        if (oValor != DBNull.Value)
                            iTabela_Preco = Convert.ToInt32(oValor);
                    }

                    sSQLFilter += string.Format(" Tabelas_Precos_itens.Tabela_Preco = {0}", iTabela_Preco);
                    break;
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
                this.cboCidade_Corres.Text,
                this.cboEstado_Corres.Text,
                this.txtCEP_Corres.Text);

            //-- Verifica qual foi o retorno e atualiza os campos.
            this.txtEndereco_Corres.Text = cep.Endereco;
            this.txtNumero_Corres.Text = cep.Numero;
            this.txtComplemento_Corres.Text = cep.Complemento;
            this.txtBairro_Corres.Text = cep.Bairro;
            this.cboEstado_Corres.Text = cep.Estado;
            this.cboCidade_Corres.Text = cep.Cidade;
            this.txtCEP_Corres.Text = cep.CEP;
        }

        private void cmdBuscar_Cobr_Click(object sender, EventArgs e)
        {
            //-- Abre o formúlario para fazer busca do cep.
            LocalizarCEP cep = new LocalizarCEP(true,
                this.txtEndereco_Cobr.Text,
                this.txtNumero_Cobr.Text,
                this.txtComplemento_Cobr.Text,
                this.txtBairro_Cobr.Text,
                this.cboCidade_Cobr.Text,
                this.cboEstado_Cobr.Text,
                this.txtCEP_Cobr.Text);

            //-- Verifica qual foi o retorno e atualiza os campos.
            this.txtEndereco_Cobr.Text = cep.Endereco;
            this.txtNumero_Cobr.Text = cep.Numero;
            this.txtComplemento_Cobr.Text = cep.Complemento;
            this.txtBairro_Cobr.Text = cep.Bairro;
            this.cboEstado_Cobr.Text = cep.Estado;
            this.cboCidade_Cobr.Text = cep.Cidade;
            this.txtCEP_Cobr.Text = cep.CEP;
        }

        private void chkMesmoEndereco_CheckedChanged(object sender, EventArgs e)
        {
            //-- Verifica se será o mesmo endereço.
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
            {
                if (this.chkMesmoEndereco.Checked)
                {
                    this.txtEndereco_Cobr.Text = this.txtEndereco_Corres.Text;
                    this.txtNumero_Cobr.Text = this.txtNumero_Corres.Text;
                    this.txtComplemento_Cobr.Text = this.txtComplemento_Corres.Text;
                    this.txtBairro_Cobr.Text = this.txtBairro_Corres.Text;
                    this.cboEstado_Cobr.Text = this.cboEstado_Corres.Text;
                    this.cboCidade_Cobr.Text = this.cboCidade_Corres.Text;
                    this.txtCEP_Cobr.Text = this.txtCEP_Corres.Text;

                    this.txtEndereco_Cobr.ReadOnly = true;
                    this.txtNumero_Cobr.ReadOnly = true;
                    this.txtComplemento_Cobr.ReadOnly = true;
                    this.txtBairro_Cobr.ReadOnly = true;
                    this.cboCidade_Cobr.Enabled = false;
                    this.cboEstado_Cobr.Enabled = false;
                    this.txtCEP_Cobr.ReadOnly = true;
                    this.cmdBuscar_Cobr.Enabled = false;
                }
                else
                {
                    this.txtEndereco_Cobr.ReadOnly = false;
                    this.txtNumero_Cobr.ReadOnly = false;
                    this.txtComplemento_Cobr.ReadOnly = false;
                    this.txtBairro_Cobr.ReadOnly = false;
                    this.cboCidade_Cobr.Enabled = true;
                    this.cboEstado_Cobr.Enabled = true;
                    this.txtCEP_Cobr.ReadOnly = false;
                    this.cmdBuscar_Cobr.Enabled = true;
                }
            }
        }

        private void txtCNPJ_Validating(object sender, CancelEventArgs e)
        {
            bool bVerifica_Existencia = true;
            Funcoes func;
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
            if (this.txtCEP_Cobr.Text.Equals(txtCEP_Corres.Text) && !string.IsNullOrEmpty(this.txtCEP_Corres.Text))
                this.chkMesmoEndereco.Checked = true;
            else
                this.chkMesmoEndereco.Checked = false;

            int iTabela_Preco = 0;
            if (this.BindingSource[this.MainTabela].Position >= 0)
            {
                object oValor = ((DataRowView)this.BindingSource[this.MainTabela].Current)["Tabela_Preco"];
                if (oValor != DBNull.Value)
                {
                    iTabela_Preco = Convert.ToInt32(oValor);

                    object oCondPgto = SQL.ExecuteScalar(string.Format("select condicao_pagamento_pedido from tabelas_precos where tabela_preco = {0}"
                                , iTabela_Preco));

                    if (oCondPgto != null && oCondPgto != DBNull.Value)
                        this.cboCondPgto.SelectedValue = oCondPgto;
                    else
                        this.cboCondPgto.SelectedIndex = -1;
                }
                else
                {
                    this.cboCondPgto.SelectedIndex = -1;
                }
            }

            this.DataSetLocal.Tables["Tabelas_precos_itens"].Columns["Cliente"].ReadOnly = false;

            this.lstContatos.DataSource = this.DataSetLocal.Tables["Clientes_Contatos"];
            this.grdTabela_Preco.DataSource = this.DataSetLocal.Tables["Tabelas_precos_itens"];
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
                    break;

                case CompSoft.TipoFormStatus.Limpar:
                    if (this.grdTabela_Preco.DataSource != null)
                        ((DataTable)this.grdTabela_Preco.BindingSource.DataSource).Clear();
                    break;
            }

            this.acTabelas_Precos.Status_Form = this.FormStatus;
            this.acContatos.Status_Form = this.FormStatus;
        }

        private void frmCadClientes_Load(object sender, EventArgs e)
        {
            Funcoes func;
            this.txtCNPJ.Mask = func.Busca_Propriedade("CNPJ_Masc");
            this.txtCEP_Cobr.Mask = func.Busca_Propriedade("CEP_Masc");
            this.txtCEP_Corres.Mask = func.Busca_Propriedade("CEP_Masc");
            string sMaskTelefone = func.Busca_Propriedade("Telefone_Masc");
            this.txtFone1.Mask = sMaskTelefone;
            this.txtFone2.Mask = sMaskTelefone;
            //this.txtFone3.Mask = sMaskTelefone;
            this.colTelefone.Mask = sMaskTelefone;

            this.grdTabela_Preco.AutoGenerateColumns = false;

            this.acContatos.Grid_Trabalho = this.lstContatos;
            this.acTabelas_Precos.Grid_Trabalho = this.grdTabela_Preco;
        }

        private void chkPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == TipoFormStatus.Novo || this.FormStatus == TipoFormStatus.Modificando)
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
                    this.txtIE.Obrigatorio = true;
                }
                else
                {
                    this.txtCNPJ.Mask = func.Busca_Propriedade("CPF_Masc");
                    this.lblRazao.Text = "Nome cliente:";
                    this.lblDtNasc.Text = "Dt. Nasc.:";
                    this.lblProfissao.Text = "Profissão:";
                    this.lblRG.Text = "RG:";
                    this.lblCPF.Text = "CPF:";
                    this.txtIE.Obrigatorio = false;
                    this.cboEstadoCivil.Enabled = true;
                    this.cboSexo.Enabled = true;
                    this.txtNomeFantasia.Enabled = false;
                }
            }
        }

        private void cmdBuscar_Entrega_Click(object sender, EventArgs e)
        {
            //-- Abre o formúlario para fazer busca do cep.
            LocalizarCEP cep = new LocalizarCEP(true,
                this.txtEndereco_Entrega.Text,
                this.txtNumero_Entrega.Text,
                this.txtComplemento_Entrega.Text,
                this.txtBairro_Entrega.Text,
                this.cboCidade_Corres.Text,
                this.cboEstado_Corres.Text,
                this.txtCEP_Entrega.Text);

            //-- Verifica qual foi o retorno e atualiza os campos.
            this.txtEndereco_Entrega.Text = cep.Endereco;
            this.txtNumero_Entrega.Text = cep.Numero;
            this.txtComplemento_Entrega.Text = cep.Complemento;
            this.txtBairro_Entrega.Text = cep.Bairro;
            this.cboEstado_Entrega.Text = cep.Estado;
            this.cboCidade_Entrega.Text = cep.Cidade;
            this.txtCEP_Entrega.Text = cep.CEP;
        }

        private void chkMesmoEndereco2_CheckedChanged(object sender, EventArgs e)
        {
            //-- Verifica se será o mesmo endereço.
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
            {
                if (this.chkMesmoEndereco2.Checked)
                {
                    this.txtEndereco_Entrega.Text = this.txtEndereco_Corres.Text;
                    this.txtNumero_Entrega.Text = this.txtNumero_Corres.Text;
                    this.txtComplemento_Entrega.Text = this.txtComplemento_Corres.Text;
                    this.txtBairro_Entrega.Text = this.txtBairro_Corres.Text;
                    this.cboEstado_Entrega.SelectedValue = this.cboEstado_Corres.SelectedValue;
                    this.cboCidade_Entrega.SelectedValue = this.cboCidade_Corres.SelectedValue;
                    this.txtCEP_Entrega.Text = this.txtCEP_Corres.Text;

                    this.txtEndereco_Entrega.ReadOnly = true;
                    this.txtNumero_Entrega.ReadOnly = true;
                    this.txtComplemento_Entrega.ReadOnly = true;
                    this.txtBairro_Entrega.ReadOnly = true;
                    this.cboCidade_Entrega.Enabled = false;
                    this.cboEstado_Entrega.Enabled = false;
                    this.txtCEP_Entrega.ReadOnly = true;
                    this.cmdBuscar_Entrega.Enabled = false;
                }
                else
                {
                    this.txtEndereco_Entrega.ReadOnly = false;
                    this.txtNumero_Entrega.ReadOnly = false;
                    this.txtComplemento_Entrega.ReadOnly = false;
                    this.txtBairro_Entrega.ReadOnly = false;
                    this.cboCidade_Entrega.Enabled = true;
                    this.cboEstado_Entrega.Enabled = true;
                    this.txtCEP_Entrega.ReadOnly = false;
                    this.cmdBuscar_Entrega.Enabled = true;
                }
            }
        }

        private void f0002_user_AfterClear()
        {
            this.cboCondPgto.SelectedIndex = -1;
        }

        private bool f0002_user_BeforeSave()
        {
            bool bRetorno = true;
            DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;

            if (this.grdTabela_Preco.BindingSource.Count > 0)
            {
                if (row["Tabela_preco"] == DBNull.Value)
                {
                    //-- Cria nome da tabela de preço.
                    string sNome_Tabela = "Tb Preco: " + (string.IsNullOrEmpty(this.txtNomeFantasia.Text) ? this.txtRazaoSocial.Text : this.txtNomeFantasia.Text);
                    if (sNome_Tabela.Length > 30)
                        sNome_Tabela = sNome_Tabela.Substring(0, 30);

                    //-- Inclui tabela de preço no banco de dados.

                    string sCondPgto = "0";
                    if (this.cboCondPgto.SelectedIndex >= 0)
                        sCondPgto = this.cboCondPgto.SelectedValue.ToString();
                    else
                        sCondPgto = "NULL";

                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("insert Tabelas_Precos(Desc_Tabela_Preco, Condicao_Pagamento_Pedido) values('{0}', {1})"
                            , sNome_Tabela
                            , sCondPgto);
                    CompSoft.Data.SQL.Execute(sb.ToString(), true);

                    //-- Captura o identity criado e atualiza a tabela de clientes.
                    int iTabela_Preco = Convert.ToInt32(CompSoft.Data.SQL.ExecuteScalar("Select @@Identity", false));
                    row["Tabela_Preco"] = iTabela_Preco;

                    //-- Atualiza a tabela_precos_itens com o código da tabela criado
                    //-- Assim não ocorrerá erro de FK ao salvar os dados no banco.
                    this.grdTabela_Preco.BindingSource.EndEdit();
                    foreach (DataRow Row_Itens in this.DataSetLocal.Tables["Tabelas_Precos_itens"].Select())
                        Row_Itens["Tabela_Preco"] = iTabela_Preco;
                }
                else
                {
                    if (this.FormStatus == TipoFormStatus.Modificando)
                    {
                        string sCondPgto;
                        if (this.cboCondPgto.SelectedIndex >= 0)
                            sCondPgto = this.cboCondPgto.SelectedValue.ToString();
                        else
                            sCondPgto = "NULL";

                        SQL.Execute(string.Format("update Tabelas_Precos set condicao_pagamento_pedido = {0} where Tabela_Preco = {1}"
                                    , sCondPgto
                                    , row["Tabela_preco"]));
                    }
                }
            }

            if (this.cboEstado_Corres.SelectedItem != null)
            {
                row["Cod_Cidade_Correspondencia_IBGE"] = ((DataRowView)this.cboCidade_Corres.SelectedItem)["Codigo_IBGE"];
                row["Cod_Estado_Correspondencia_IBGE"] = ((DataRowView)this.cboEstado_Corres.SelectedItem)["Codigo_IBGE"];
            }

            return bRetorno;
        }

        private void cboEstadoCorrespondencia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboEstado_Corres.SelectedIndex >= 0)
            {
                string sValor = string.Empty;

                //-- Guarda a informação do registro.
                if (this.BindingSource[this.MainTabela].Position >= 0)
                {
                    DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
                    sValor = row["Cidade_Correspondencia"].ToString();
                }

                //-- Seta valores.
                string sQuery = "select Nome_municipio, Nome_municipio as 'nom', codigo_ibge from municipios where estado = '{0}' order by nome_municipio";
                sQuery = string.Format(sQuery, this.cboEstado_Corres.SelectedValue.ToString());
                this.cboCidade_Corres.SQLStatement = sQuery;

                //-- Caso exista o valor o sistema mostrará no combo.
                if (!string.IsNullOrEmpty(sValor))
                    this.cboCidade_Corres.SelectedValue = sValor;
            }
            else
                this.cboCidade_Corres.DataSource = null;
        }

        private void cboEstado_Cobr_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboEstado_Cobr.SelectedIndex >= 0)
            {
                string sValor = string.Empty;

                //-- Guarda a informação do registro.
                if (this.BindingSource[this.MainTabela].Position >= 0)
                {
                    DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
                    sValor = row["Cidade_cobranca"].ToString();
                }

                //-- Seta valores.
                string sQuery = "select Nome_municipio, Nome_municipio as 'nom', codigo_ibge from municipios where estado = '{0}' order by nome_municipio";
                sQuery = string.Format(sQuery, this.cboEstado_Cobr.SelectedValue.ToString());
                this.cboCidade_Cobr.SQLStatement = sQuery;

                //-- Caso exista o valor o sistema mostrará no combo.
                if (!string.IsNullOrEmpty(sValor))
                    this.cboCidade_Cobr.SelectedValue = sValor;
            }
            else
                this.cboCidade_Cobr.DataSource = null;
        }

        private void cboEstado_Entrega_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboEstado_Entrega.SelectedIndex >= 0)
            {
                string sValor = string.Empty;

                //-- Guarda a informação do registro.
                if (this.BindingSource[this.MainTabela].Position >= 0)
                {
                    DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
                    sValor = row["Cidade_Entrega"].ToString();
                }

                //-- Seta valores.
                string sQuery = "select Nome_municipio, Nome_municipio as 'nom', codigo_ibge from municipios where estado = '{0}' order by nome_municipio";
                sQuery = string.Format(sQuery, this.cboEstado_Entrega.SelectedValue);
                this.cboCidade_Entrega.SQLStatement = sQuery;

                //-- Caso exista o valor o sistema mostrará no combo.
                if (!string.IsNullOrEmpty(sValor))
                {
                    this.cboCidade_Entrega.Value = sValor;
                }
            }
            else
                this.cboCidade_Entrega.DataSource = null;
        }

        private void acTabelas_Precos_user_After_Novo_OnClick()
        {
            //-- Encontra a tabela de preço, mostra 0 para atualização na hora que for salvar o registro.
            object oTabela = ((DataRowView)this.BindingSource[this.MainTabela].Current)["Tabela_Preco"];
            if (oTabela == DBNull.Value)
                oTabela = 0;

            ((DataRowView)this.grdTabela_Preco.BindingSource.Current)["Tabela_Preco"] = oTabela;
        }

        private void txtNomeTransportadora_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmdLimparCondPgto_Click(object sender, EventArgs e)
        {
            this.cboCondPgto.SelectedIndex = -1;
        }

        private void txtRazaoSocial_TextChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == TipoFormStatus.Limpar)
                this.lblClientes.Text = string.Empty;
            else
                this.lblClientes.Text = this.txtRazaoSocial.Text;
        }
    }
}