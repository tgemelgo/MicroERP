using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(Button)), ToolboxItem(true)]
    public partial class cf_AcaoGrid : UserControl
    {
        private CompSoft.TipoFormStatus tp_Status;
        private CompSoft.cf_Bases.cf_DataGrid grdGrid;

        #region Propriedades

        /// <summary>
        /// Deixa o botão novo ativo.
        /// </summary>
        public bool Permitir_Inclusao
        {
            get { return this.cmdNovo.Enabled; }
            set { this.cmdNovo.Enabled = value; }
        }

        /// <summary>
        /// Deixa o botão salvar ativo.
        /// </summary>
        public bool Permitir_Alteracao
        {
            get { return true; }
            set { value = true; }
        }

        /// <summary>
        /// Deixa o botão exclusão ativo.
        /// </summary>
        public bool Permitir_Exclusao
        {
            get { return this.cmdExcluir.Enabled; }
            set { this.cmdExcluir.Enabled = value; }
        }

        /// <summary>
        /// Atualiza a permissão do botão de acordo com o Status do formulário.
        /// </summary>
        public TipoFormStatus Status_Form
        {
            set
            {
                tp_Status = value;

                if (tp_Status != TipoFormStatus.Novo && tp_Status != TipoFormStatus.Modificando)
                {
                    this.cmdNovo.Enabled = false;
                    this.cmdExcluir.Enabled = false;
                }
                else
                {
                    this.cmdNovo.Enabled = true;

                    if (this.grdGrid.BindingSource.Count <= 0)
                        this.cmdExcluir.Enabled = false;
                    else
                        this.cmdExcluir.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Grid para manipulação das incormações.
        /// </summary>
        public cf_DataGrid Grid_Trabalho
        {
            set
            {
                grdGrid = value;
                this.grdGrid.RowsAdded += new DataGridViewRowsAddedEventHandler(grdGrid_RowsAdded);
                this.grdGrid.RowsRemoved += new DataGridViewRowsRemovedEventHandler(grdGrid_RowsRemoved);
            }
        }

        #endregion Propriedades

        #region Eventos

        private void grdGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (this.grdGrid != null && this.grdGrid.BindingSource != null)
            {
                if (this.grdGrid.BindingSource.Count > 0)
                    this.cmdExcluir.Enabled = true;
                else
                    this.cmdExcluir.Enabled = false;
            }
        }

        private void grdGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.cmdExcluir.Enabled = false;

            if (tp_Status == TipoFormStatus.Novo || tp_Status == TipoFormStatus.Modificando)
            {
                if (this.grdGrid != null && this.grdGrid.BindingSource != null)
                {
                    if (this.grdGrid.BindingSource.Count > 0)
                        this.cmdExcluir.Enabled = true;
                }
            }
        }

        public delegate bool Before_Novo_OnClick();

        public event Before_Novo_OnClick user_Before_Novo_OnClick;

        public delegate bool Before_Excluir_OnClick();

        public event Before_Excluir_OnClick user_Before_Excluir_OnClick;

        public delegate void After_Novo_OnClick();

        public event After_Novo_OnClick user_After_Novo_OnClick;

        public delegate void After_Excluir_OnClick();

        public event After_Excluir_OnClick user_After_Excluir_OnClick;

        public delegate void After_Click_All_Button_OnClick();

        public event After_Click_All_Button_OnClick user_After_Click_All_Button_OnClick;

        #endregion Eventos

        #region Metodos das operações padrões

        /// <summary>
        /// Informa o grid que será adicionado um novo item.
        /// </summary>
        public void Novo_Item()
        {
            bool bRetorno = true;
            if (this.user_Before_Novo_OnClick != null)
                bRetorno = this.user_Before_Novo_OnClick();

            if (bRetorno)
            {
                this.grdGrid.AddNew();

                if (this.user_After_Novo_OnClick != null)
                    this.user_After_Novo_OnClick();
            }
        }

        /// <summary>
        /// Exclui um item já existente.
        /// </summary>
        public void Excluir_Item()
        {
            bool bRetorno = true;
            if (user_Before_Excluir_OnClick != null)
                bRetorno = this.user_Before_Excluir_OnClick();

            if (bRetorno)
            {
                grdGrid.Delete();
                if (grdGrid.BindingSource.Count <= 0)
                {
                    this.cmdExcluir.Enabled = false;
                }
                else
                {
                    this.cmdExcluir.Enabled = true;
                }

                if (user_After_Excluir_OnClick != null)
                    this.user_After_Excluir_OnClick();
            }
        }

        #endregion Metodos das operações padrões

        public cf_AcaoGrid()
        {
            InitializeComponent();
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            bool bRetorno = true;

            if (this.user_Before_Novo_OnClick != null)
                bRetorno = this.user_Before_Excluir_OnClick();

            if (bRetorno)
            {
                DialogResult dr = compFrameWork.MsgBox.Show("Deseja excluir o registro selecionado?"
                    , "Exclusão"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    //-- Exclui linha selecionada.
                    this.Excluir_Item();

                    if (this.user_After_Excluir_OnClick != null)
                        this.user_After_Excluir_OnClick();

                    if (this.user_After_Click_All_Button_OnClick != null)
                        this.user_After_Click_All_Button_OnClick();
                }
            }
        }

        private void cmdNovo_Click(object sender, EventArgs e)
        {
            bool bRetorno = true;

            if (this.user_Before_Novo_OnClick != null)
                bRetorno = this.user_Before_Novo_OnClick();

            if (bRetorno)
            {
                //-- Inclui um novo item.
                this.Novo_Item();

                if (this.user_After_Novo_OnClick != null)
                    this.user_After_Novo_OnClick();

                if (this.user_After_Click_All_Button_OnClick != null)
                    this.user_After_Click_All_Button_OnClick();

                //-- Joga o foco no grid.
                this.grdGrid.Focus();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Size = new Size(24, 55);
        }

        private void cmdExcluir_EnabledChanged(object sender, EventArgs e)
        {
            int i = 0;
            i++;
        }
    }
}