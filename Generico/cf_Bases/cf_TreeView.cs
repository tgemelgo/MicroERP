using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(TreeView)), ToolboxItem(true)]
    public partial class cf_TreeView : TreeView
    {
        private IList<TreeNode> al = new List<TreeNode>();
        private ImageList il = new ImageList();

        public ImageList Collection_ImageList
        {
            get { return il; }
            set
            {
                il = value;
                this.ImageList = value;
            }
        }

        public cf_TreeView()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        public void Clear()
        {
            al.Clear();
            this.Nodes.Clear();
        }

        #region Inclui os itens no TreeView

        public bool Adicinar_Node(bool Root, string sID, string sDescricao, string sNome, int iIndexImage, int iIndexImageSelected, string sParent)
        {
            bool bRetorno = true;

            try
            {
                TreeNode tn = new TreeNode();

                tn.Text = sDescricao;
                tn.Name = sNome;
                tn.Tag = sID;

                if (iIndexImage >= 0)
                    tn.ImageIndex = iIndexImage;

                if (iIndexImageSelected >= 0)
                    tn.SelectedImageIndex = iIndexImageSelected;

                if (Root)
                    this.Nodes.Add(tn);
                else
                    RetornoNode(sParent).Nodes.Add(tn);

                al.Add(tn);
                bRetorno = true;
            }
            catch
            {
                bRetorno = false;
            }

            return bRetorno;
        }

        #endregion Inclui os itens no TreeView

        #region Localiza o node para inclusão do nó

        private TreeNode RetornoNode(string sNome)
        {
            foreach (TreeNode tn in al)
            {
                if (tn.Name == sNome)
                {
                    return tn;
                }
            }
            return null;
        }

        #endregion Localiza o node para inclusão do nó
    }
}