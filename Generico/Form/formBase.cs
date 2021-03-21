using CompSoft.compFrameWork;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CompSoft
{
    public partial class formBase : Form
    {
        #region Metodos tratamento dos estados do form

        /// <summary>
        /// Trata o enable dos controle da tela.
        /// </summary>
        /// <param name="sGroup">Grupo para tratamento, apenas um por vez</param>
        /// <param name="Enabled">Campo habilitado ou desabilitado</param>
        public void Change_Group(string sGroup, bool Enabled)
        {
            this.Change_Group(this.Controls, sGroup, Enabled);
        }

        /// <summary>
        /// Trata o enable dos controle da tela.
        /// </summary>
        /// <param name="Controle">Coleção de controles</param>
        /// <param name="sGroup">Grupo para tratamento, apenas um por vez</param>
        /// <param name="Enabled">Campo habilitado ou desabilitado</param>
        public void Change_Group(Control.ControlCollection Controle, string sGroup, bool Enabled)
        {
            foreach (Control ctrl in Controle)
            {
                if (ctrl.Controls.Count > 0 && ctrl.GetType() != typeof(cf_Bases.cf_DateEdit))
                {
                    this.Change_Group(ctrl.Controls, sGroup, Enabled);
                }
                else
                {
                    if (ctrl.GetType().GetInterface("IBaseControl", true) != null)
                    {
                        Interfaces.IBaseControl cc = (Interfaces.IBaseControl)ctrl;
                        if (!string.IsNullOrEmpty(cc.Grupo) && cc.Grupo.ToLower().IndexOf(sGroup.ToLower()) >= 0)
                        {
                            cc.ReadOnly = !Enabled;
                        }
                    }
                }
            }
        }

        #endregion Metodos tratamento dos estados do form

        #region Propriedades

        /// <summary>
        /// Identifica o titulo do formulário.
        /// </summary>
        [Category("CompSoft")]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        #endregion Propriedades

        public formBase()
        {
            InitializeComponent();

            try
            {
                if (!string.IsNullOrEmpty(CompSoft.compFrameWork.Propriedades.TituloMain))
                    this.Icon = global::CompSoft.Properties.Resources.Icone_Form;
            }
            catch { }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Propriedades.FormMain != null)
                this.Text = "(" + this.Name + ") " + base.Text;
        }
    }
}