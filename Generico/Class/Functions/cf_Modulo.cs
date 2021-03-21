using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.Tools
{
    internal class cf_Modulo : IDisposable
    {
        private DevExpress.XtraBars.PopupMenu ts_Modulos = new DevExpress.XtraBars.PopupMenu();

        /// <summary>
        /// true/false se existem itens na barra de modulos
        /// </summary>
        public bool Possui_Itens
        {
            get { return (ts_Modulos.ItemLinks.Count > 0); }
        }

        /// <summary>
        /// Carrega todos os itens da barra de ferramentas de modulos.
        /// </summary>
        public void Carregar_Barra_Ferramenta(DevExpress.XtraBars.Ribbon.RibbonControl ribbon)
        {
            string sQuery = "select * from vw_retornar_modulos_acessos where usuario = {0}";

            sQuery = string.Format(sQuery
                , Propriedades.CodigoUsuario);
            DataTable dt = SQL.Select(sQuery, "x", false);

            Propriedades.FormMain.cmdToolModulos.DropDownControl = ts_Modulos;
            DevExpress.Utils.ImageCollection ic = (DevExpress.Utils.ImageCollection)ribbon.Images;

            //-- Carrega itens do menu.
            foreach (DataRow row in dt.Select("", "descricao_modulo"))
            {
                DevExpress.XtraBars.BarButtonItem bbi = new DevExpress.XtraBars.BarButtonItem();
                bbi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(Propriedades.FormMain.bbi_ItemClick);
                bbi.Caption = row["Descricao_Modulo"].ToString();
                bbi.Description = row["Descricao_Modulo"].ToString();
                bbi.Tag = row["Modulo"];

                //-- Carrega imagem.
                DataTable dt_imagem = SQL.Select("Select imagem from Modulos where modulo = " + row["Modulo"].ToString(), "x", false);
                if (dt_imagem.Rows.Count > 0 && dt_imagem.Rows[0][0] != DBNull.Value)
                {
                    MemoryStream ms = new MemoryStream((byte[])dt_imagem.Rows[0][0]);
                    ic.AddImage(Image.FromStream(ms));
                    bbi.ImageIndex = ic.Images.Count - 1;
                }
                ribbon.Items.Add(bbi);
                ts_Modulos.ItemLinks.Add(bbi);
            }

            dt.Dispose();
            dt = null;
        }

        #region IDisposable Members

        public void Dispose()
        {
            ts_Modulos.Dispose();
            ts_Modulos = null;
        }

        #endregion IDisposable Members
    }
}