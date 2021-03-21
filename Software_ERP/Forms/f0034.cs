using CompSoft.compFrameWork;
using System;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0034 : CompSoft.formBase
    {
        private bool bAlteracao = false;

        public f0034()
        {
            InitializeComponent();
        }

        private void Carregar_Dados()
        {
            Impressoras imp;
            Funcoes func;
            this.txtEspecie.Text = func.Busca_Propriedade("Especie_NF");
            this.cboPortaImpressoraMatricial.SelectedItem = func.Busca_Propriedade("Porta_Padrao_Matricial");
            this.cboEmpresa.SelectedValue = func.Busca_Propriedade("Codigo_Filial");
            this.cboIdioma.SelectedValue = func.Busca_Propriedade("Idioma sistema");
            this.txtCEP.Text = func.Busca_Propriedade("Banco_CEP_Correio");
            this.cboTipoPagamentoCP.SelectedValue = func.Busca_Propriedade("Movimento_Padrao_CP");
            this.cboTipoMovimentoCR.SelectedValue = func.Busca_Propriedade("Movimento_Padrao_CR");
            this.chkGeraNF.Checked = Convert.ToBoolean(func.Busca_Propriedade("GERA_NF"));
            this.chkEstoquePorEmpresa.Checked = Convert.ToBoolean(func.Busca_Propriedade("Estoque_por_empresa"));
            this.chkBaixaManual.Checked = Convert.ToBoolean(func.Busca_Propriedade("Baixa_manual_estoque"));
            this.cboImpressora.SelectedValue = imp.Impressora_Padrao;
            this.cboAmbienteNFe.SelectedValue = func.Busca_Propriedade("Ambiente_NFe");
            this.txtCopiasDanfe.Text = func.Busca_Propriedade("CopiasDanfe");
        }

        private void Salvar_Dados()
        {
            Funcoes func;
            func.Atualizar_Propriedade("Especie_NF", this.txtEspecie.Text);
            func.Atualizar_Propriedade("Porta_Padrao_Matricial", this.cboPortaImpressoraMatricial.Text);
            func.Atualizar_Propriedade("Banco_CEP_Correio", this.txtCEP.Text);
            func.Atualizar_Propriedade("GERA_NF", this.chkGeraNF.Checked.ToString());
            func.Atualizar_Propriedade("Estoque_por_empresa", this.chkEstoquePorEmpresa.Checked.ToString());
            func.Atualizar_Propriedade("Baixa_manual_estoque", this.chkBaixaManual.Checked.ToString());
            func.Atualizar_Propriedade("CopiasDanfe", this.txtCopiasDanfe.Text);

            if (this.cboEmpresa.SelectedIndex >= 0)
                func.Atualizar_Propriedade("Codigo_Filial", this.cboEmpresa.SelectedValue.ToString());

            if (this.cboIdioma.SelectedIndex >= 0)
                func.Atualizar_Propriedade("Idioma sistema", this.cboIdioma.SelectedValue.ToString());

            if (this.cboTipoPagamentoCP.SelectedIndex >= 0)
                func.Atualizar_Propriedade("Movimento_Padrao_CP", this.cboTipoPagamentoCP.SelectedValue.ToString());

            if (this.cboTipoMovimentoCR.SelectedIndex >= 0)
                func.Atualizar_Propriedade("Movimento_Padrao_CR", this.cboTipoMovimentoCR.SelectedValue.ToString());

            func.Atualizar_Propriedade("Ambiente_NFe", this.cboAmbienteNFe.SelectedValue.ToString());

            Impressoras imp;
            imp.Impressora_Padrao = this.cboImpressora.SelectedValue.ToString();
        }

        private void f0034_Load(object sender, EventArgs e)
        {
            Impressoras imp;
            this.cboImpressora.DataSource = imp.Impressoras_Disponiveis();
            this.cboImpressora.DisplayMember = "a";
            this.cboImpressora.ValueMember = "b";

            //-- Carrega portas para impressora.
            for (int i = 1; i < 10; i++)
                this.cboPortaImpressoraMatricial.Items.Add("LPT" + i.ToString());

            this.Carregar_Dados();
        }

        private void f0034_FormClosing(object sender, FormClosingEventArgs e)
        {
            Funcoes func;
            //-- Verifica se houve mudança na filial,
            //-- caso tenha mudança o sistema atualiza os dados para os relatorios
            bool bAtualiarFilial = false;
            if (func.Busca_Propriedade("Codigo_Filial") != string.Empty)
                bAtualiarFilial = true;

            //-- Atualiza propriedades
            func.AlimentaPropriedades_Sist();

            //-- Atualiza dados da filial para mostrar em relatórios.
            if (bAtualiarFilial)
            {
                ERP.Class.Carrega_Dados c = new ERP.Class.Carrega_Dados();
                c.Dados_Filial();
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (bAlteracao)
            {
                DialogResult dr = MsgBox.Show("Ao fechar este formulário, todas as alterações realizadas serão desconsideradas.\r\nVocê confirma esta ação?"
                    , "Sair"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            this.Salvar_Dados();
            bAlteracao = false;
        }

        private void cboEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void cboTipoPagamentoCP_SelectedValueChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void cboContaContabilCP_SelectedValueChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void cboTipoMovimentoCR_SelectedValueChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void cboContaContabilCR_SelectedValueChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void cboIdioma_SelectedValueChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void cboPortaImpressoraMatricial_SelectedValueChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void cboTipo_Frete_SelectedValueChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void txtEspecie_TextChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void chkGeraNF_CheckedChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void chkEstoquePorEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }

        private void chkBaixaManual_CheckedChanged(object sender, EventArgs e)
        {
            bAlteracao = true;
        }
    }
}