using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frmMain : CompSoft.frmMain
    {
        public frmMain()
        {
            //#if !DEBUG
            //    this.BackgroundImage = global::ERP.Properties.Resources.CompSoft___Sistemas;
            //#endif

            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!string.IsNullOrEmpty(Propriedades.NomeUsuario))
            {
                Class.Carrega_Dados c = new Class.Carrega_Dados();
                c.Dados_Filial();
            }

            this.Refresh();
        }

        private void StatusBar_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {
            if (e.Clicks == 2 && e.StatusBarPanel.Name == "lblEmpresa")
            {
                f0079 f = new f0079();
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //-- Atualiza o nome da empresa
                    Funcoes func;
                    string sEmpresa = string.Empty
                    , sCodEmpresa = func.Busca_Propriedade("codigo_filial")
                    , sSQL = string.Empty;

                    //-- Carrega nome da empresa
                    sSQL = string.Format("select Nome_Fantasia from empresas where empresa = {0}", sCodEmpresa);
                    sEmpresa = SQL.ExecuteScalar(sSQL).ToString();

                    this.lblEmpresa.Text = string.Format(this.lblEmpresa.Tag.ToString(), sEmpresa);
                }
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                Funcoes func;
                string sEmpresa = string.Empty
                    , sCodEmpresa = func.Busca_Propriedade("codigo_filial")
                    , sSQL = string.Empty;

                if (string.IsNullOrEmpty(sCodEmpresa))
                {
                    f0079 f = new f0079();
                    f.ShowDialog();

                    sCodEmpresa = func.Busca_Propriedade("codigo_filial");
                }

                //-- Carrega nome da empresa
                sSQL = string.Format("select Nome_Fantasia from empresas where empresa = {0}", sCodEmpresa);
                sEmpresa = SQL.ExecuteScalar(sSQL).ToString();

                this.lblEmpresa.Text = string.Format(this.lblEmpresa.Tag.ToString(), sEmpresa);
            }
            catch { }
        }
    }
}