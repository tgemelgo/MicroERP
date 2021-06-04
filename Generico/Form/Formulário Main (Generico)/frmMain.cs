using CompSoft.cf_Bases;
using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraNavBar;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CompSoft
{
    public partial class frmMain : FormSet
    {
        public frmMain()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            InitializeComponent();

            RegistroWindows rw = new RegistroWindows();
            string sValor_DockFav = rw.LocalizaRegistro("DockFav").ToString();

            if (string.IsNullOrEmpty(sValor_DockFav))
                this.dock_Favoritos.Dock = DockingStyle.Right;
            else
            {
                this.dock_Favoritos.Dock = (DockingStyle)Convert.ToInt32(sValor_DockFav);
            }
        }

        #region Metodos padrões do sistema

        #region Veririca se o form é formSet

        /// <summary>
        /// Veririca se o forme é herdado do formset
        /// </summary>
        /// <returns>True/False se for herdado do formeset</returns>
        private bool Heranca_FormSet()
        {
            bool bRetorno = false;

            if (Propriedades.FormMain.ActiveMdiChild != null)
            {
                Funcoes func;
                if (func.Check_Extension(Propriedades.FormMain.ActiveMdiChild.GetType(), typeof(FormSet)))
                    bRetorno = true;
                else
                    bRetorno = false;
            }

            return bRetorno;
        }

        #endregion Veririca se o form é formSet

        #region Eventos do formulário.

        private void mnuMenuSair(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dock_Favoritos_DockChanged(object sender, EventArgs e)
        {
            RegistroWindows rw = new RegistroWindows();
            rw.GravarRegistro("DockFav", Convert.ToInt32(this.dock_Favoritos.Dock).ToString());
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        this.cmdToolAlterar_ItemClick(this, new DevExpress.XtraBars.ItemClickEventArgs(this.cmdToolAlterar, null));
                        break;

                    case Keys.F3:
                        this.cmdToolPesquisar_ItemClick(this, new DevExpress.XtraBars.ItemClickEventArgs(this.cmdToolPesquisar, null));
                        break;

                    case Keys.F4:
                        this.cmdToolNovo_ItemClick(this, new DevExpress.XtraBars.ItemClickEventArgs(this.cmdToolNovo, null));
                        break;

                    case Keys.F5:
                        this.cmdToolAtualizar_ItemClick(this, new DevExpress.XtraBars.ItemClickEventArgs(this.cmdToolAtualizar, null));
                        break;

                    case Keys.F6:
                        this.cmdToolSalvar_ItemClick(this, new DevExpress.XtraBars.ItemClickEventArgs(this.cmdToolSalvar, null));
                        break;

                    case Keys.F7:
                        this.cmdToolCancelarAlteracoes_ItemClick(this, new DevExpress.XtraBars.ItemClickEventArgs(this.cmdToolCancelarAlteracoes, null));
                        break;

                    case Keys.F8:
                        this.cmdToolLimpartela_ItemClick(this, new DevExpress.XtraBars.ItemClickEventArgs(this.cmdToolLimpartela, null));
                        break;

                    case Keys.F9:
                        this.cmdToolExcluir_ItemClick(this, new DevExpress.XtraBars.ItemClickEventArgs(this.cmdToolExcluir, null));
                        break;

                    case Keys.P:
                        if (e.Control)
                            this.cmdToolImpressao_ItemClick(this, new DevExpress.XtraBars.ItemClickEventArgs(this.cmdToolImpressao, null));
                        break;
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Exit();
        }

        protected override void OnShown(EventArgs e)
        {
            //-- Caso o titulo não esteja preenchido significa que a aplicação não está em execução.
            if (!string.IsNullOrEmpty(Propriedades.TituloMain))
            {
                //-- verifica se o software está em uso
                this.Verifica_Software_Aberto();

                Propriedades.FormMain = this;

                //-- identifica qual é o formulário main.
                this.FormStatus = TipoFormStatus.Nenhum;
                this.Text = Propriedades.TituloMain;
                this.lblTotalRegistros.Caption = "# 0";
                this.lblRegistroAtual.Caption = "# 0";

                MainMenu m = new MainMenu();
                m.MenuItems.Add("Sair", mnuMenuSair);
                this.Menu = m;

                //-- Valida entrada do menu.
                frmLogin f = new frmLogin();
                if (f.ShowDialog() != DialogResult.OK)
                    Application.Exit(); //-- Login não valiado ou encerrado pelo usuário.
                else
                {
                    f.Dispose();
                    this.lblToolUserLogado.Text = string.Format(this.lblToolUserLogado.Text
                        , Propriedades.CodigoUsuario.ToString()
                        , Propriedades.NomeUsuario);

                    this.lblDatabase.Text = string.Format(this.lblDatabase.Text
                        , Propriedades.DataBase);

                    this.lblServidor.Text = string.Format(this.lblServidor.Text
                        , f.Servidor);

                    this.lblModulo.Text = string.Format(this.lblModulo.Tag.ToString(), "(Nenhum)");

                    this.lblVersão.Text = string.Format(this.lblVersão.Text
                        , Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf(".")));

                    //-- Carrega modulos
                    this.Carregar_Modulos();

                    //-- Busca todas as propriedades do sistema.
                    Funcoes func;
                    if (Propriedades.Propriedades_Sist == null)
                        func.AlimentaPropriedades_Sist();

                    //-- Carrega lista de favoritos
                    this.Carrega_Favoritos();

                    //-- parametros e cultura do sistema.
                    //CultureInfo forceDotCulture = (CultureInfo)Application.CurrentCulture.Clone();
                    //forceDotCulture.NumberFormat.NumberDecimalSeparator = func.Busca_Propriedade("SeparadorDecimal");
                    //forceDotCulture.NumberFormat.NumberGroupSeparator = func.Busca_Propriedade("SeperadorGrupo");
                    //forceDotCulture.NumberFormat.NumberDecimalDigits = 2;
                    //forceDotCulture.NumberFormat.CurrencyDecimalDigits = 2;
                    //forceDotCulture.NumberFormat.CurrencySymbol = string.Empty;
                    //forceDotCulture.NumberFormat.PercentDecimalDigits = 2;
                    //forceDotCulture.DateTimeFormat.DateSeparator = func.Busca_Propriedade("DataSeparador");
                    //forceDotCulture.DateTimeFormat.ShortDatePattern = func.Busca_Propriedade("FormatoDataAbreviada");
                    //forceDotCulture.DateTimeFormat.ShortTimePattern = func.Busca_Propriedade("FormatoHoraAbreviada");

                    Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("pt-br");
                    Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("pt-br");

                    //-- Ativa a barra de status e mostra todos os parametros
                    this.StatusBar.Visible = true;
                }
            }

            base.OnShown(e);
        }

        protected override void OnMdiChildActivate(EventArgs e)
        {
            Funcoes func;

            //-- Atualiza status da barra de ferramentas.
            if (this.ActiveMdiChild != null && !this.Heranca_FormSet())
            {
                func.TratarStatus_BarraFerramentas(TipoFormStatus.Nenhum, TipoForm.Geral);
            }
            else
            {
                if (this.ActiveMdiChild != null)
                {
                    //-- Caso seja objeto de entrada.
                    if (this.ActiveMdiChild.GetType().Namespace.ToLower() == "erp.objeto")
                    {
                        if (this.ActiveMdiChild.GetType().BaseType.BaseType.ToString() == "CompSoft.FormSet")
                            func.TratarStatus_BarraFerramentas(((FormSet)this.ActiveMdiChild).FormStatus, ((FormSet)this.ActiveMdiChild).Tipo_Formulario);
                    }

                    //-- Caso seja FormBase
                    if (this.ActiveMdiChild.GetType().BaseType.ToString() == "CompSoft.formBase")
                        func.TratarStatus_BarraFerramentas(TipoFormStatus.Nenhum, TipoForm.Geral);

                    //-- Caso seja FormSet
                    if (this.ActiveMdiChild.GetType().BaseType.ToString() == "CompSoft.FormSet")
                        func.TratarStatus_BarraFerramentas(((FormSet)this.ActiveMdiChild).FormStatus, ((FormSet)this.ActiveMdiChild).Tipo_Formulario);
                }
            }

            base.OnMdiChildActivate(e);
        }

        #endregion Eventos do formulário.

        #region Chama rotina para carregar modulos do sistema.

        public void bbi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int iModulo = int.Parse(e.Item.Tag.ToString());
            this.lblModulo.Text = string.Format(this.lblModulo.Tag.ToString(), e.Item.Caption);
            if (iModulo > 0)
            {
                if (this.Menu != null)
                    this.Menu.MenuItems.Clear();

                //-- Monta menus
                cf_MenuBuilder menu = new cf_MenuBuilder();
                this.Menu = menu.MontarMenu(iModulo, Propriedades.CodigoUsuario, mnuMenuSair);
            }
        }

        /// <summary>
        /// Chama classe que carregará todos os modulos que o usuário tem acesso.
        /// </summary>
        private void Carregar_Modulos()
        {
            if (Propriedades.Carrega_Barra_Ferramentas_Modulos)
            {
                cf_Modulo tsm = new cf_Modulo();
                tsm.Carregar_Barra_Ferramenta(this.toolBarNavegacao);
            }
            else
            {
                //-- Monta menus
                cf_MenuBuilder menu = new cf_MenuBuilder();
                this.Menu = menu.MontarMenu(1, Propriedades.CodigoUsuario, mnuMenuSair);
            }
        }

        #endregion Chama rotina para carregar modulos do sistema.

        #region Carrega barra de favoritos

        private void Carrega_Favoritos()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.AppendLine("select gf.Grupo_Favorito, gf.Desc_Grupo_Favorito");
            sb.AppendLine(" from Grupos_Favoritos gf");
            sb.AppendLine("  inner join Menus_Itens_Favoritos mif on gf.grupo_favorito = gf.grupo_favorito");
            sb.AppendFormat(" where mif.usuario = {0}\r\n", Propriedades.CodigoUsuario);
            sb.AppendLine(" group by gf.Grupo_Favorito, gf.Desc_Grupo_Favorito");
            DataTable dt_grupo = SQL.Select(sb.ToString(), "x", false);

            if (dt_grupo.Rows.Count > 0)
                this.dock_Favoritos.Visibility = DockVisibility.Visible;

            foreach (DataRow row in dt_grupo.Select())
            {
                //-- Adiciona o grupo.
                NavBarGroup nbg = new NavBarGroup(row["Desc_Grupo_Favorito"].ToString());
                nbg.Tag = Convert.ToInt32(row["Grupo_Favorito"]);
                nbg.Expanded = true;
                navBar_Favoritos.Groups.Add(nbg);

                //-- Verifica os itens e adiciona.
                sb = new StringBuilder(300);
                sb.AppendLine("select mi.Descricao, mi.namespace, mi.formulario");
                sb.AppendLine(" from Menus_Itens_Favoritos mif");
                sb.AppendLine("  inner join menus_itens mi on mi.menu_item = mif.Menu_item");
                sb.AppendFormat(" where mif.grupo_favorito = {0}\r\n", row["Grupo_Favorito"]);
                sb.AppendFormat("     and mif.usuario = {0}\r\n", Propriedades.CodigoUsuario);
                DataTable dt_Itens = SQL.Select(sb.ToString(), "x", false);

                foreach (DataRow row_Item in dt_Itens.Select())
                {
                    NavBarItemLink ln = nbg.AddItem();
                    ln.Item.SmallImage = this.toolFav.Images[0];
                    ln.Item.Caption = row_Item["Descricao"].ToString();
                    ln.Item.LinkClicked += new NavBarLinkEventHandler(Item_LinkClicked);
                    ln.Item.Tag = string.Format("{0};{1}"
                            , row_Item["namespace"]
                            , row_Item["formulario"]);
                }
            }
        }

        private void Item_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string[] sParam = e.Link.Item.Tag.ToString().Split(new char[] { ';' });

            Funcoes func;
            func.Open_Form(sParam[0], sParam[1]);
        }

        #endregion Carrega barra de favoritos

        #region Todos os eventos da barra de ferramentas

        private void cmdToolPrimeiro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolPrimeiro.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).Movimentar_Registro(Movimento.Primeiro);
            }
        }

        private void cmdToolAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolAnterior.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).Movimentar_Registro(Movimento.Voltar);
            }
        }

        private void cmdToolLookUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolLookUp.Enabled)
            {
                frmListaRegistrosPai f = new frmListaRegistrosPai();
            }
        }

        private void cmdToolProximo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolProximo.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).Movimentar_Registro(Movimento.Proximo);
            }
        }

        private void cmdToolUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolUltimo.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).Movimentar_Registro(Movimento.Ultimo);
            }
        }

        private void cmdToolNovo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolNovo.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).FormStatus = TipoFormStatus.Novo;
                if (!((FormSet)this.ActiveMdiChild).Novo())
                    ((FormSet)this.ActiveMdiChild).FormStatus = ((FormSet)this.ActiveMdiChild).OldFormStatus;
            }
        }

        private void cmdToolAlterar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolAlterar.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).FormStatus = TipoFormStatus.Modificando;
            }
        }

        private void cmdToolExcluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolExcluir.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).FormStatus = TipoFormStatus.Pesquisar;
                ((FormSet)this.ActiveMdiChild).Excluir();
            }
        }

        private void cmdToolSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolSalvar.Enabled)
            {
                Funcoes func;
                if (func.ValidarCampos(this.ActiveMdiChild.Controls))
                {
                    if (((FormSet)this.ActiveMdiChild).Salvar())
                    {
                        ((FormSet)this.ActiveMdiChild).FormStatus = TipoFormStatus.Pesquisar;
                        ((FormSet)this.ActiveMdiChild).TotalRegistros(MostrarTotalRegistros.Contagem_Atual);
                    }
                }
                else
                {
                    CompSoft.compFrameWork.MsgBox.Show("Existem campos obrigatórios não preenchidos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmdToolLimpartela_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolLimpartela.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).FormStatus = TipoFormStatus.Limpar;
                ((FormSet)this.ActiveMdiChild).Limpar();
            }
        }

        private void cmdToolCancelarAlteracoes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolCancelarAlteracoes.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).FormStatus = ((FormSet)this.ActiveMdiChild).OldFormStatus;
                ((FormSet)this.ActiveMdiChild).Desfazer();
            }
        }

        private void cmdToolAtualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolAtualizar.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).FormStatus = TipoFormStatus.Pesquisar;
                ((FormSet)this.ActiveMdiChild).Atualizar_Query_Atual();
            }
        }

        private void cmdToolPesquisar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolPesquisar.Enabled)
            {
                ((FormSet)this.ActiveMdiChild).FormStatus = TipoFormStatus.Pesquisar;
                ((FormSet)this.ActiveMdiChild).PesquisarDados();
            }
        }

        private void cmdToolImpressao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Heranca_FormSet() && this.ActiveMdiChild != null && this.cmdToolImpressao.Enabled)
            {
                frmGerenciadorRelatorios f = new frmGerenciadorRelatorios();
                f.ShowDialog();
            }
        }

        #endregion Todos os eventos da barra de ferramentas

        #endregion Metodos padrões do sistema

        #region Verifica se o software já está aberto.

        private void Verifica_Software_Aberto()
        {
            //-- Verifica se o programa já não está em execução.
            Process ProcessoAtual = Process.GetCurrentProcess();
            Process[] ProcessoRodando = Process.GetProcessesByName(ProcessoAtual.ProcessName);
            DialogResult dr = DialogResult.Yes;

            foreach (Process Processo in ProcessoRodando)
            {
                if (Processo.Id != ProcessoAtual.Id)
                {
                    dr = MsgBox.Show("Programa já em execução, deseja executar assim mesmo?"
                            , "Alerta"
                            , MessageBoxButtons.YesNo
                            , MessageBoxIcon.Question);
                }
            }

            //-- Caso o usuário decida abrir uma nova instancia do aplicativo.
            if (dr == DialogResult.No)
            {
                Application.Exit();
            }
        }

        #endregion Verifica se o software já está aberto.
    }
}