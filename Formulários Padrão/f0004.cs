using CompSoft;
using CompSoft.Data;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERP.Forms
{
    /// <summary>
    /// Description of frmCadModulos.
    /// </summary>
    public partial class f0004 : FormSet
    {
        public f0004()
        {
            string sSQL = string.Empty;
            sSQL += "select Modulo_Menu, Modulos_Menus.Modulo, Modulos_Menus.Menu_item, mi.Descricao as 'Descricao_Menu'";
            sSQL += " from modulos_Menus";
            sSQL += "  inner join Modulos m on m.modulo = modulos_Menus.Modulo";
            sSQL += "  inner join Menus_itens mi on mi.Menu_Item = Modulos_menus.Menu_item";

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai, "Modulos", "Select * from modulos"));
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha, "Modulos_Menus", sSQL));

            InitializeComponent();
        }

        private void FrmCadModulosuser_AfterRefreshData()
        {
            this.lstMenus.DataSource = this.DataSetLocal.Tables["Modulos_Menus"];

            if (this.DataSetLocal.Tables[this.MainTabela].Rows.Count > 0)
            {
                DataRowView RowView = (DataRowView)this.BindingSource[this.MainTabela].Current;
                if (RowView.Row["imagem"] != DBNull.Value)
                {
                    MemoryStream ms = new MemoryStream((byte[])RowView.Row["imagem"]);
                    this.pictureBox1.Image = Image.FromStream(ms);
                }
                else
                    this.pictureBox1.Image = null;
            }
        }

        private void frmCadModulos_user_FormStatus_Change()
        {
            this.acModulos_itens.Status_Form = this.FormStatus;
            if (this.FormStatus == CompSoft.TipoFormStatus.Limpar | this.FormStatus == CompSoft.TipoFormStatus.Novo)
                this.pictureBox1.Image = null;
        }

        private void f0004_Load(object sender, EventArgs e)
        {
            this.acModulos_itens.Grid_Trabalho = this.lstMenus;
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {
            string sFile_Img = string.Empty;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivos Png|*.png|Todos os arquivos|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Imagem para o modulo";
            if (ofd.ShowDialog() == DialogResult.OK)
                sFile_Img = ofd.FileName;

            if (string.IsNullOrEmpty(sFile_Img))
            {
                this.pictureBox1.Image = null;
                DataRowView drw = ((DataRowView)this.BindingSource[this.MainTabela].Current);
                drw["imagem"] = null;
            }
            else
            {
                Image img = Image.FromFile(sFile_Img);
                CompSoft.Tools.TrataImagem ti = new CompSoft.Tools.TrataImagem(32, 32, CompSoft.Tools.TrataImagem.Tipos_Redicionamento.Proporcional);
                img = ti.Redimencionar(ref img);

                this.pictureBox1.Image = img;
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                DataRowView drw = ((DataRowView)this.BindingSource[this.MainTabela].Current);
                drw["imagem"] = ms.ToArray();
            }
        }

        private void f0004_user_AfterNew()
        {
            this.chkAtivo.Enabled = true;
            this.pictureBox1.Image = null;
        }
    }
}