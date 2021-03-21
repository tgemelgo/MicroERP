using CompSoft.compFrameWork;
using CompSoft.Data;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0047 : CompSoft.FormSet
    {
        public f0047()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Propriedades"
                , "select * from propriedades"));

            InitializeComponent();
        }

        private void f0047_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, atualizando ambiente.");
            Funcoes func;
            func.AlimentaPropriedades_Sist();
            f.Close();
            f.Dispose();
        }
    }
}