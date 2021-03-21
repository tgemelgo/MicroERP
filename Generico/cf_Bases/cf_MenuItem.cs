using CompSoft.compFrameWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CompSoft.cf_Bases
{
    internal class cf_MenuItem : System.Windows.Forms.MenuItem
    {
        private string sFormulario = string.Empty;
        private string sNamespace = string.Empty;
        private int iMenuItem = 0;

        #region Construtores

        public cf_MenuItem(string MenuItem)
        {
            base.Text = MenuItem;
        }

        public cf_MenuItem()
        {
        }

        #endregion Construtores

        #region Declaração de propriedades

        public string Formulario
        {
            get { return sFormulario; }
            set { sFormulario = value; }
        }

        public string NameSpace
        {
            get { return sNamespace; }
            set { sNamespace = value; }
        }

        public int MenuItem
        {
            get { return iMenuItem; }
            set { iMenuItem = value; }
        }

        #endregion Declaração de propriedades

        #region Override de Evento do click do botão.

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            Funcoes func;
            func.Open_Form(sNamespace, sFormulario);
        }

        #endregion Override de Evento do click do botão.
    }
}