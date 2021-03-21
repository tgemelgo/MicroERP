using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    /// <summary>
    /// Class responsável pelo gerenciamento do menu.
    /// </summary>
    internal class cf_MenuBuilder : IDisposable
    {
        #region Declaração de variaveis

        private IList<cf_MenuItem> al = new List<cf_MenuItem>();

        #endregion Declaração de variaveis

        #region Rotina que busca no banco de dados e monta o menu

        public MainMenu MontarMenu(int Modulo, int Usuario, EventHandler EventoSair)
        {
            //-- Instancia o menu principal
            MainMenu main = new MainMenu();
            string sObjetoAtual = string.Empty;

            try
            {
                //-- Monta o select que retornará os dados necessários para montar o menu.
                string sSQL = "select * from vw_Retornar_Menus_Items_Acessos where(Usuario = {0} and Modulo = {1})";
                sSQL = string.Format(sSQL
                    , Usuario.ToString()
                    , Modulo.ToString());

                //-- Tabela com os itens do menu
                DataTable dt_Menu = SQL.Select(sSQL, "MenusItens", false);

                string sFiltro = string.Empty;
                //-- Verifica se o usuário e ADM
                if (!compFrameWork.Propriedades.Usuario_ADM || compFrameWork.Propriedades.CodigoUsuario != 1)
                {
                    //-- Faz filtro para items não admin.
                    DataRow[] fFiltroRow = dt_Menu.Select("descricao like '%99%'");

                    if (fFiltroRow.Length > 0)
                    {
                        foreach (DataRow row in fFiltroRow)
                            sFiltro = string.Format("Menu_item <> {0} and ParentNivel <> {0}", row["Menu_Item"].ToString());
                    }
                }

                //-- Monta a collection com todos os dados selecionados.
                DataRow[] fRow = dt_Menu.Select(sFiltro, "NameSpace, nivel, ParentNivel, Descricao");

                //-- Limpa todos os itens do menu.
                main.MenuItems.Clear();
                al.Clear();

                //-- Loop para adicionar todos os itens no menu.
                foreach (DataRow row in fRow)
                {
                    sObjetoAtual = string.Empty;

                    if (Convert.ToInt32(row["ParentNivel"].ToString()) != 0)
                    {
                        if (Convert.ToInt32(row["Nivel"].ToString()) == 0)
                        {
                            sObjetoAtual = row["Descricao"].ToString();

                            AdicionarItem(
                                main,
                                row["Descricao"].ToString(),
                                row["Formulario"].ToString(),
                                row["NameSpace"].ToString(),
                                Convert.ToInt32(row["Menu_Item"].ToString()),
                                Convert.ToInt32(row["ParentNivel"].ToString()));
                        }
                        else
                        {
                            sObjetoAtual = row["Descricao"].ToString();

                            AdicionarItem(
                                null,
                                row["Descricao"].ToString(),
                                row["Formulario"].ToString(),
                                row["NameSpace"].ToString(),
                                Convert.ToInt32(row["Menu_Item"].ToString()),
                                Convert.ToInt32(row["ParentNivel"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string sMensagem = "Erro ao associar o objeto {0}:\n -{1}";
                sMensagem = string.Format(sMensagem, sObjetoAtual, ex.Message);

                CompSoft.compFrameWork.MsgBox.Show(sMensagem, "Erro de acessoação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                main.MenuItems.Add("Sair", EventoSair);
            }
            return main;
        }

        #endregion Rotina que busca no banco de dados e monta o menu

        #region Adiciona o item ao menu

        private void AdicionarItem(object Menu, string Titulo, string Formulario, string Namespace, int MenuItem, int ParentNivel)
        {
            cf_MenuItem mItem = new cf_MenuItem();

            //-- Adiciona o texto ao item.
            mItem.Text = Titulo;
            mItem.NameSpace = Namespace;
            mItem.Formulario = Formulario;
            mItem.MenuItem = MenuItem;

            //-- Verifica se é root ou sub-item
            if (Menu is MainMenu)
            {
                ((MainMenu)Menu).MenuItems.Add(mItem);
            }
            else
            {
                //-- Localiza o menu pai.
                RetornoMenu(ParentNivel).MenuItems.Add(mItem);
            }

            //-- Incrementa no Array
            al.Add(mItem);
        }

        #endregion Adiciona o item ao menu

        #region Localiza o sub-menu e o inclui

        private cf_MenuItem RetornoMenu(int ParentNivel)
        {
            foreach (cf_MenuItem mi in al)
            {
                if (mi.MenuItem == ParentNivel)
                {
                    return mi;
                }
            }
            return null;
        }

        #endregion Localiza o sub-menu e o inclui

        #region IDisposable Members

        public void Dispose()
        {
            al = null;
        }

        #endregion IDisposable Members
    }
}