using CompSoft.Data;
using System;

namespace ERP.Forms
{
    public partial class f0042 : CompSoft.FormSet
    {
        public f0042()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "CFOPS_Regras"
                    , "select * from CFOPS_Regras"));

            InitializeComponent();
        }

        private void cmdLimparEstado_Click(object sender, EventArgs e)
        {
            this.cboEstado.SelectedIndex = -1;
        }
    }
}