using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Tools
{
    public partial class frmWait : formBase
    {
        private string sMensagem = string.Empty;
        private Tipo_Imagem tp_Imagem = Tipo_Imagem.Informacao;

        public enum Tipo_Imagem
        {
            Informacao,
            Atencao,
            Wait
        }

        public enum TipoDialogo
        {
            Progresso,
            Espera
        }

        public Tipo_Imagem Tipo_Imagem_Identificacao
        {
            get { return tp_Imagem; }
            set { tp_Imagem = value; }
        }

        /// <summary>
        /// Mensagem que será mostrada ao usuário.
        /// </summary>
        public string Mensagem
        {
            get { return sMensagem; }
            set
            {
                sMensagem = value;
                this.lblTextoMensagem.Text = sMensagem;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Barra de progresso ativa.
        /// </summary>
        public bool Progresso
        {
            get { return pProgressBar.Visible; }
            set
            {
                pProgressBar.Visible = value;
                if (value)
                {
                    this.Size = new Size(487, 118);
                    this.pictureBox1.Image = global::CompSoft.Properties.Resources.Informacao;
                }
                else
                {
                    this.Size = new Size(487, 86);
                    this.pictureBox1.Image = global::CompSoft.Properties.Resources.Wait_Silver;
                }
            }
        }

        /// <summary>
        /// Valor maximo da barra de progresso
        /// </summary>
        public int Maximo_Progresso
        {
            get { return pProgressBar.Properties.Maximum; }
            set
            {
                pProgressBar.Properties.Maximum = value;
                pProgressBar.Position = 0;
            }
        }

        /// <summary>
        /// Valor miminimo da barra de progresso
        /// </summary>
        public int Minimo_Progresso
        {
            get { return pProgressBar.Properties.Minimum; }
            set { pProgressBar.Properties.Minimum = value; }
        }

        /// <summary>
        /// Valor atual da barra de progresso.
        /// </summary>
        public int Atual_Progresso
        {
            get { return pProgressBar.Position; }
            set
            {
                pProgressBar.Position = value;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Define o tipo de imagem que o sistema mostrará na tela.
        /// </summary>
        private void Identifica_Tipo_Imagem()
        {
            switch (tp_Imagem)
            {
                case Tipo_Imagem.Informacao:
                    this.pictureBox1.Image = global::CompSoft.Properties.Resources.Informacao;
                    break;

                case Tipo_Imagem.Atencao:
                    this.pictureBox1.Image = global::CompSoft.Properties.Resources.Atencao;
                    break;

                case Tipo_Imagem.Wait:
                    this.pictureBox1.Image = global::CompSoft.Properties.Resources.Wait_Silver;
                    break;
            }
        }

        /// <summary>
        /// Construtor padrão sem nenhum parametro
        /// </summary>
        public frmWait()
        {
            InitializeComponent();
            CompSoft.compFrameWork.Propriedades.Form_Wait = this;
            this.TopMost = true;
        }

        /// <summary>
        /// Destrutor padrao
        /// </summary>
        ~frmWait()
        {
            compFrameWork.Propriedades.Form_Wait = null;
        }

        /// <summary>
        /// Construtor com parametro.
        /// </summary>
        /// <param name="Mensagem">Mensagem a ser mostrada para o usuário</param>
        public frmWait(string Mensagem)
        {
            InitializeComponent();
            CompSoft.compFrameWork.Propriedades.Form_Wait = this;
            this.Mensagem = Mensagem;

            this.TopMost = true;
            this.Show();
            Application.DoEvents();
        }

        /// <summary>
        /// Construtor com parametro.
        /// </summary>
        /// <param name="Mensagem">Mensagem a ser mostrada para o usuário</param>
        /// <param name="Progresso">Mostra a barra de progresso</param>
        /// <param name="Maximo">Valor máximo da barra de progresso</param>
        /// <param name="Minimo">Valor minimo da barra de progresso</param>
        public frmWait(string Mensagem, bool Progresso, int Maximo, int Minimo)
        {
            InitializeComponent();

            CompSoft.compFrameWork.Propriedades.Form_Wait = this;
            this.Mensagem = Mensagem;
            this.Progresso = Progresso;
            this.pProgressBar.Properties.Maximum = Maximo;
            this.pProgressBar.Properties.Minimum = Minimo_Progresso;

            this.TopMost = true;

            this.pictureBox1.Image = global::CompSoft.Properties.Resources.Informacao;

            if (this.pProgressBar.Properties.Maximum > 0)
                this.Show();
        }

        /// <summary>
        /// Construtor com parametro.
        /// </summary>
        /// <param name="Mensagem">Mensagem a ser mostrada para o usuário</param>
        /// <param name="Progresso">Mostra a barra de progresso</param>
        /// <param name="Maximo">Valor máximo da barra de progresso</param>
        public frmWait(string Mensagem, bool Progresso, int Maximo)
        {
            InitializeComponent();

            CompSoft.compFrameWork.Propriedades.Form_Wait = this;
            this.Mensagem = Mensagem;
            this.Progresso = Progresso;
            this.pProgressBar.Properties.Maximum = Maximo;

            this.TopMost = true;

            this.pictureBox1.Image = global::CompSoft.Properties.Resources.Informacao;

            if (this.pProgressBar.Properties.Maximum > 0)
                this.Show();
        }

        /// <summary>
        /// Construtor com parametro.
        /// </summary>
        /// <param name="Mensagem">Mensagem a ser mostrada para o usuário</param>
        /// <param name="Tipo_Imagem_Dialog">Tipo de mensagem que será apresentada.</param>
        public frmWait(string Mensagem, Tipo_Imagem Tipo_Imagem_Dialog)
        {
            InitializeComponent();

            tp_Imagem = Tipo_Imagem_Dialog;
            this.Identifica_Tipo_Imagem();
            CompSoft.compFrameWork.Propriedades.Form_Wait = this;
            this.Mensagem = Mensagem;

            this.TopMost = true;
            this.Show();
            Application.DoEvents();
        }

        /// <summary>
        /// Construtor com parametro.
        /// </summary>
        /// <param name="Mensagem">Mensagem a ser mostrada para o usuário</param>
        /// <param name="Progresso">Mostra a barra de progresso</param>
        /// <param name="Maximo">Valor máximo da barra de progresso</param>
        public frmWait(string Mensagem, bool Progresso, int Maximo, Tipo_Imagem Tipo_Imagem_Dialog)
        {
            InitializeComponent();

            tp_Imagem = Tipo_Imagem_Dialog;
            this.Identifica_Tipo_Imagem();
            CompSoft.compFrameWork.Propriedades.Form_Wait = this;
            this.Mensagem = Mensagem;
            this.Progresso = Progresso;
            this.pProgressBar.Properties.Maximum = Maximo;

            this.TopMost = true;

            if (this.pProgressBar.Properties.Maximum > 0)
                this.Show();
        }

        protected override void OnLoad(EventArgs e)
        {
            //-- base.OnLoad(e);

            if (!this.Progresso)
                this.pictureBox1.Image = global::CompSoft.Properties.Resources.Wait_Silver;
            else
                this.pictureBox1.Image = global::CompSoft.Properties.Resources.Informacao;
        }
    }
}