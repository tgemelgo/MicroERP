using CompSoft.Tools;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0080 : CompSoft.FormSet
    {
        public f0080()
        {
            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                    , "Bancos"
                    , "select * from bancos"));

            InitializeComponent();
        }

        private void cmdLocalizarLogo_Click(object sender, EventArgs e)
        {
            if (this.foFile_Open.ShowDialog() == DialogResult.OK)
            {
                //-- Localiza e abre o arquivo em Steam
                FileStream fs = new FileStream(this.foFile_Open.FileName
                    , FileMode.OpenOrCreate
                    , FileAccess.Read);

                //-- Converte o arquivo para Binario.
                byte[] MyData = new byte[fs.Length];
                fs.Read(MyData, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                TrataImagem t = new TrataImagem(150, 50, TrataImagem.Tipos_Redicionamento.Proporcional);
                MemoryStream ms = new MemoryStream(MyData);
                Image img_Final = t.Redimencionar(Image.FromStream(ms));
                this.pictureBox1.Image = img_Final;
                img_Final.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                //-- Atualiza registro.
                DataRowView RowView = (DataRowView)this.BindingSource[this.MainTabela].Current;
                img_Final.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                RowView.Row["Logo_Banco"] = ms.ToArray();
            }
        }

        private void f0080_user_AfterRefreshData()
        {
            try
            {
                if (this.DataSetLocal.Tables[this.MainTabela].Rows.Count > 0)
                {
                    DataRowView RowView = (DataRowView)this.BindingSource[this.MainTabela].Current;
                    MemoryStream ms = new MemoryStream((byte[])RowView.Row["Logo_Banco"]);

                    this.pictureBox1.Image = Image.FromStream(ms);
                }
            }
            catch { }
        }

        private void f0080_user_AfterClear()
        {
            this.pictureBox1.Image = null;
        }

        private void f0080_user_FormStatus_Change()
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
                this.cmdLocalizarLogo.Enabled = true;
            else
                this.cmdLocalizarLogo.Enabled = false;
        }
    }
}