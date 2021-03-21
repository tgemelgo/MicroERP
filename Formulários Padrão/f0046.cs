using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0046 : CompSoft.FormSet
    {
        private DataTable dt;

        public f0046()
        {
            string sSQL = string.Empty;
            sSQL += "select usuarios_acessos.*, u.Nome_Usuario, mo.Descricao_Modulo, mi.Descricao";
            sSQL += " from usuarios_acessos";
            sSQL += "  inner join usuarios u on u.usuario = usuarios_acessos.usuario";
            sSQL += "  left outer join modulos mo on mo.modulo = usuarios_acessos.modulo";
            sSQL += "  left outer join menus_itens mi on mi.menu_item = usuarios_acessos.menu_item";

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "usuarios_acessos"
                , sSQL));

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Modulos"
                , "select Modulo, Descricao_Modulo from modulos where ativo = 1 order by Descricao_Modulo"));

            InitializeComponent();
        }

        private IList<int> Seleciona_Itens_Pai()
        {
            IList<int> il_Itens = new List<int>();

            foreach (DataRowView li in this.lstMenus.SelectedItems)
            {
                int iParent = Convert.ToInt32(li["ParentNivel"]);
                int iMenu_Item = Convert.ToInt32(li["Menu_Item"]);
                il_Itens.Add(iParent);
                il_Itens.Add(iMenu_Item);
            }

            return il_Itens;
        }

        private void Atualizar_Menus_Itens()
        {
            //-- Marca e filtro registros já utilizados como incluido.
            if (dt != null)
            {
                dt.DefaultView.RowFilter = "Incluido = 0";
                dt.DefaultView.Sort = "descricao";

                this.lstMenus.DataSource = dt.DefaultView;
                this.lstMenus.DisplayMember = "Descricao";
                this.lstMenus.ValueMember = "Menu_Item";
            }
            else
            {
                this.lstMenus.DataSource = null;
                this.lstMenus.Items.Clear();
            }
        }

        private void Carrega_Menus_Itens(int iModulo)
        {
            //-- Carrega itens do menu.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine("    mm.modulo");
            sb.AppendLine("  , mi.Menu_Item");
            sb.AppendLine("  , mi.Descricao");
            sb.AppendLine("  , mi.ParentNivel");
            sb.AppendLine("  , isnull(ua.Usuario_acesso, 0) as 'Incluido'");
            sb.AppendLine(" from Menus_itens mi ");
            sb.AppendLine("  inner join modulos_menus mm on mm.menu_item = mi.menu_item");
            sb.AppendLine("  inner join modulos m on m.modulo = mm.modulo");
            sb.AppendFormat("  left join usuarios_acessos ua on ua.Menu_Item = mi.Menu_item and ua.usuario = {0}", this.cboUsuarios.SelectedValue);
            sb.AppendLine(" where ");
            sb.AppendLine("          mi.ativo = 1");
            sb.AppendLine("   and m.ativo = 1");
            sb.AppendFormat("  and mm.modulo = {0}", iModulo);

            dt = CompSoft.Data.SQL.Select(sb.ToString(), "x", false);
            dt.Columns["Incluido"].ReadOnly = false;

            //-- Marca e filtro registros já utilizados como incluido.
            if (dt != null)
            {
                //-- Encontra registros e marca como utilizados.
                string sFilter = "Modulo = {0}";
                sFilter = string.Format(sFilter, iModulo);
                DataRow[] fRow = this.DataSetLocal.Tables[this.MainTabela].Select(sFilter);

                foreach (DataRow row in fRow)
                {
                    if (row["Menu_Item"] != DBNull.Value)
                    {
                        dt.DefaultView.RowFilter = string.Format("Menu_Item = {0}", row["Menu_Item"]);
                        if (dt.DefaultView.Count > 0)
                        {
                            dt.DefaultView[0].BeginEdit();
                            dt.DefaultView[0]["Incluido"] = 1;
                            dt.DefaultView[0].EndEdit();
                        }
                    }
                }

                dt.DefaultView.RowFilter = "Incluido = 0";
                dt.DefaultView.Sort = "descricao";

                this.lstMenus.DataSource = dt.DefaultView;
                this.lstMenus.DisplayMember = "Descricao";
                this.lstMenus.ValueMember = "Menu_Item";
            }
            else
            {
                this.lstMenus.DataSource = null;
                this.lstMenus.Items.Clear();
            }
        }

        public override string user_Query(string TabelaAtual)
        {
            string sQuery = string.Empty;

            if (TabelaAtual.ToLower().Trim() == "usuarios_acessos")
            {
                if (!string.IsNullOrEmpty(sQuery))
                    sQuery += " and ";

                sQuery += string.Format(" usuarios_acessos.usuario = {0} "
                    , this.cboUsuarios.SelectedValue.ToString());
            }

            return sQuery;
        }

        private void f0046_user_AfterRefreshData()
        {
            this.grdAcessos.DataSource = this.DataSetLocal.Tables["usuarios_acessos"];
            this.grdModulos.DataSource = this.DataSetLocal.Tables["Modulos"];

            this.grdModulos_SelectionChanged(this, new EventArgs());
        }

        private void chkPemissoaModulo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPemissoaModulo.Checked)
                this.lstMenus.Enabled = false;
            else
                this.lstMenus.Enabled = true;

            this.lstMenus.SelectedIndex = -1;
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (!this.chkPemissoaModulo.Checked && this.lstMenus.SelectedIndices.Count <= 0)
            {
                MsgBox.Show("Selecione um item para a permissão."
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
            }
            else
            {
                string sCondicao = string.Empty;
                if (this.chkPemissoaModulo.Checked)
                {
                    //-- Processo para inclusão em um novo DATASET
                    this.grdAcessos.AddNew();

                    //-- captura o código do modulo.
                    string sModulo = ((DataRowView)this.grdModulos.CurrentRow)["Modulo"].ToString();
                    string sDesc_Modulo = ((DataRowView)this.grdModulos.CurrentRow)["Descricao_Modulo"].ToString();

                    this.grdAcessos.CurrentRow["Usuario"] = this.cboUsuarios.SelectedValue;
                    this.grdAcessos.CurrentRow["Modulo"] = sModulo;
                    this.grdAcessos.CurrentRow["Descricao_Modulo"] = sDesc_Modulo;
                    this.grdAcessos.CurrentRow["Menu_Item"] = DBNull.Value;
                    this.grdAcessos.CurrentRow["Descricao"] = DBNull.Value;
                    this.grdAcessos.CurrentRow["Nome_Usuario"] = this.cboUsuarios.Text;
                }
                else
                {
                    //-- Selecione todos os itens pai vinculados.
                    //this.Seleciona_Itens_Pai();

                    foreach (int iItem in this.Seleciona_Itens_Pai())
                    {
                        if (this.DataSetLocal.Tables[this.MainTabela].Select("Menu_Item = " + iItem.ToString()).Length == 0)
                        {
                            DataView dv = new DataView(dt, "Menu_Item = " + iItem.ToString(), "", DataViewRowState.CurrentRows);
                            if (dv.Count > 0)
                            {
                                DataRowView li = dv[0];

                                //-- Processo para inclusão em um novo DATASET
                                this.grdAcessos.AddNew();

                                //-- Processo para incluri dados necessários no DATASET
                                string sMenu_Item = li["Menu_Item"].ToString(),
                                    sDesc_Menu_Item = li["Descricao"].ToString();

                                if (!string.IsNullOrEmpty(sCondicao))
                                    sCondicao += ", ";

                                sCondicao += sMenu_Item;

                                //-- captura o código do modulo.
                                string sModulo = ((DataRowView)this.grdModulos.CurrentRow)["Modulo"].ToString();
                                string sDesc_Modulo = ((DataRowView)this.grdModulos.CurrentRow)["Descricao_Modulo"].ToString();

                                this.grdAcessos.CurrentRow["Usuario"] = this.cboUsuarios.SelectedValue;
                                this.grdAcessos.CurrentRow["Modulo"] = sModulo;
                                this.grdAcessos.CurrentRow["Descricao_Modulo"] = sDesc_Modulo;
                                this.grdAcessos.CurrentRow["Menu_Item"] = sMenu_Item;
                                this.grdAcessos.CurrentRow["Descricao"] = sDesc_Menu_Item;
                                this.grdAcessos.CurrentRow["Nome_Usuario"] = this.cboUsuarios.Text;
                            }
                        }
                        else
                        {
                            sCondicao = iItem.ToString();
                        }

                        //-- Marca item para não aparecer na lista.
                        foreach (DataRow row in dt.Select(string.Format("menu_item in ({0})", sCondicao)))
                            row["Incluido"] = 1;
                    }

                    //-- Atualiza itens da lista.
                    this.Atualizar_Menus_Itens();
                }
            }
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            //-- inclui novamente o item na lista de menus itens
            DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
            if (!string.IsNullOrEmpty(row["Menu_Item"].ToString()))
            {
                foreach (DataRow row_atu in dt.Select("menu_item = " + row["Menu_Item"].ToString()))
                    row_atu["Incluido"] = 0;
            }

            //-- Excluir o item.
            this.grdAcessos.Delete();

            //-- Atualiza lista de menus itens
            this.Atualizar_Menus_Itens();
        }

        private bool f0046_user_BeforeNew()
        {
            MsgBox.Show("Não é permitido incluir um novo item.\nSelecione um usuário já existente e inclua as permissões de acesso ao menu."
                , "Atenção"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Warning);

            return false;
        }

        private void f0046_user_FormStatus_Change()
        {
            this.chkPemissoaModulo.Checked = false;

            switch (this.FormStatus)
            {
                case CompSoft.TipoFormStatus.Limpar:
                    this.lstMenus.DataSource = null;
                    this.lstMenus.Items.Clear();
                    break;
            }
        }

        private void f0046_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dt != null)
                dt.Dispose();
        }

        private void grdModulos_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.FormStatus == CompSoft.TipoFormStatus.Modificando || this.FormStatus == CompSoft.TipoFormStatus.Pesquisar)
                && this.BindingContext[this.DataSetLocal, "Modulos"].Position >= 0)
            {
                DataRowView row = (DataRowView)this.grdModulos.CurrentRow;
                this.Carrega_Menus_Itens(Convert.ToInt32(row["Modulo"]));
                this.lstMenus.SelectedIndex = -1;
            }
        }
    }
}