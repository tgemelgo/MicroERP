using CompSoft;
using CompSoft.compFrameWork;
using System;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0079 : formBase
    {
        public f0079()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            // base.OnLoad(e);
            this.Text = "Empresas disponiveis";
            this.lstEmpresas.Focus();
        }

        private void cf_Button1_Click(object sender, EventArgs e)
        {
            if (this.lstEmpresas.SelectedItems.Count >= 0)
            {
                Funcoes func;
                func.Atualizar_Propriedade("Codigo_Filial", this.lstEmpresas.SelectedValue.ToString()); //-- Atualiza a empresa
                func.AlimentaPropriedades_Sist();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Selecione a empresa padrão do sistema."
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
            }
        }

        private void lstEmpresas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.cf_Button1_Click(this, new EventArgs());
            }
        }

        private void lstEmpresas_DoubleClick(object sender, EventArgs e)
        {
            this.cf_Button1_Click(this, new EventArgs());
        }
    }
}