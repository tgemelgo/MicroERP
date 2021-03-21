using CompSoft.compFrameWork;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0038 : CompSoft.formBase
    {
        private decimal dValor_Unitario = 0;

        #region Propriedades

        public int CodProduto
        {
            get { return Convert.ToInt32(this.lblCodProduto.Text); }
            set { this.lblCodProduto.Text = value.ToString(); }
        }

        public string Produto
        {
            set { this.lblProduto.Text = value; }
        }

        public int Quantidade
        {
            get { return Convert.ToInt32(this.txtQtde.Text); }
            set { this.txtQtde.Text = value.ToString(); }
        }

        public decimal Desconto_Porcentagem
        {
            get { return Convert.ToDecimal(this.txtDesconto_Porcent.Text); }
            set { this.txtDesconto_Porcent.Text = value.ToString(); }
        }

        public decimal Desconto_Valor
        {
            get { return Convert.ToDecimal(this.txtDesconto_Valor.Text); }
            set { this.txtDesconto_Valor.Text = value.ToString(); }
        }

        public decimal Comissao_Porcentagem
        {
            get { return Convert.ToDecimal(this.txtComissao_Porcent.Text); }
            set { this.txtComissao_Porcent.Text = value.ToString(); }
        }

        public decimal Comissao_Valor
        {
            get { return Convert.ToDecimal(this.txtComissao_Valor.Text); }
            set { this.txtComissao_Valor.Text = value.ToString(); }
        }

        public decimal Valor_Unitario
        {
            set
            {
                this.txtValorUnitario.Text = value.ToString();
                dValor_Unitario = value;
            }
            get { return Convert.ToDecimal(this.txtValorUnitario.Text); }
        }

        #endregion Propriedades

        #region Encontrar Valores a partir de uma porcentagem

        private decimal Encontrar_Valor(decimal dValor_Total_Item, decimal dPorcentagem)
        {
            decimal dValor = 0;
            dValor = (dValor_Total_Item * dPorcentagem);
            dValor = Math.Round((dValor / 100), 2, MidpointRounding.AwayFromZero);

            return dValor;
        }

        #endregion Encontrar Valores a partir de uma porcentagem

        #region Encontrar porcentagem a partir de dois valores.

        private decimal Encontrar_Porcentagem(decimal dValor_Total_Item, decimal dValor_Parcial)
        {
            decimal dPorcentagem = 0;
            dPorcentagem = (dValor_Parcial / dValor_Total_Item);
            dPorcentagem = Math.Round((dPorcentagem * 100), 2, MidpointRounding.AwayFromZero);

            return dPorcentagem;
        }

        #endregion Encontrar porcentagem a partir de dois valores.

        public f0038()
        {
            InitializeComponent();
        }

        private void cmdConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtQtde.Text) && Convert.ToInt32(this.txtQtde.Text) > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MsgBox.Show("A quantidade não pode ser menor igual a zero."
                    , "Alerta"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtDesconto_Porcent_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtDesconto_Porcent.Text) && Convert.ToDecimal(this.txtDesconto_Porcent.Text) > 0)
            {
                decimal dValor_Total = dValor_Unitario * Convert.ToInt32(this.txtQtde.Text);
                //-- Chama rotina para calculo de valores
                this.txtDesconto_Valor.Text = this.Encontrar_Valor(dValor_Total, Convert.ToDecimal(this.txtDesconto_Porcent.Text)).ToString();

                //-- Realiza o re-calculo da comissão.
                if (!string.IsNullOrEmpty(this.txtComissao_Porcent.Text) && Convert.ToDecimal(this.txtComissao_Porcent.Text) > 0)
                    this.txtComissao_Porcent_Validating(this, new CancelEventArgs());
            }
        }

        private void txtDesconto_Valor_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtDesconto_Valor.Text) && Convert.ToDecimal(this.txtDesconto_Valor.Text) > 0)
            {
                decimal dValor_Total = dValor_Unitario * Convert.ToInt32(this.txtQtde.Text);
                //-- Chama rotina para calculo de porcentagem
                this.txtDesconto_Porcent.Text = this.Encontrar_Porcentagem(dValor_Total, Convert.ToDecimal(this.txtDesconto_Valor.Text)).ToString();

                //-- Realiza o re-calculo da comissão.
                if (!string.IsNullOrEmpty(this.txtComissao_Porcent.Text) && Convert.ToDecimal(this.txtComissao_Porcent.Text) > 0)
                    this.txtComissao_Porcent_Validating(this, new CancelEventArgs());
            }
        }

        private void txtComissao_Porcent_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtComissao_Porcent.Text) && Convert.ToDecimal(this.txtComissao_Porcent.Text) > 0)
            {
                decimal dValor_Total = dValor_Unitario * Convert.ToInt32(this.txtQtde.Text);

                //-- Calcula o desconto para atualização.
                if (!string.IsNullOrEmpty(this.txtDesconto_Valor.Text) && Convert.ToDecimal(this.txtDesconto_Valor.Text) > 0)
                    dValor_Total = dValor_Total - Convert.ToDecimal(this.txtDesconto_Valor.Text);

                //-- Chama rotina para calculo de valores
                this.txtComissao_Valor.Text = this.Encontrar_Valor(dValor_Total, Convert.ToDecimal(this.txtComissao_Porcent.Text)).ToString();
            }
        }

        private void txtComissao_Valor_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtComissao_Valor.Text) && Convert.ToDecimal(this.txtComissao_Valor.Text) > 0)
            {
                decimal dValor_Total = dValor_Unitario * Convert.ToInt32(this.txtQtde.Text);

                //-- Calcula o desconto para atualização.
                if (!string.IsNullOrEmpty(this.txtDesconto_Valor.Text) && Convert.ToDecimal(this.txtDesconto_Valor.Text) > 0)
                    dValor_Total = dValor_Total - Convert.ToDecimal(this.txtDesconto_Valor.Text);

                //-- Chama rotina para calculo de valores
                this.txtComissao_Porcent.Text = this.Encontrar_Porcentagem(dValor_Total, Convert.ToDecimal(this.txtComissao_Valor.Text)).ToString();
            }
        }

        private void txtQtde_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtQtde.Text) && Convert.ToInt32(this.txtQtde.Text) > 0)
            {
                e.Cancel = false;
                this.txtDesconto_Porcent_Validating(sender, new CancelEventArgs());
                this.txtComissao_Porcent_Validating(sender, new CancelEventArgs());
            }
            else
                e.Cancel = true;
        }

        private void txtValorUnitario_Validating(object sender, CancelEventArgs e)
        {
            dValor_Unitario = Convert.ToDecimal(this.txtValorUnitario.Text);
            if (!string.IsNullOrEmpty(this.txtValorUnitario.Text) && Convert.ToDecimal(this.txtValorUnitario.Text) > 0)
            {
                e.Cancel = false;
                this.txtDesconto_Porcent_Validating(sender, new CancelEventArgs());
                this.txtComissao_Porcent_Validating(sender, new CancelEventArgs());
            }
            else
                e.Cancel = true;
        }
    }
}