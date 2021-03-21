using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace CompSoft.Tools
{
    public class TrataImagem
    {
        private int iWidth = 0, iHeight = 0;
        private Tipos_Redicionamento tp_Redimencionamento;

        /// <summary>
        /// Identifica o tipo de redicionamento.
        /// </summary>
        public enum Tipos_Redicionamento
        {
            Fixo,
            Proporcional
        }

        /// <summary>
        /// Largura horizontal da imagem
        /// </summary>
        public int Width
        {
            get { return iWidth; }
            set { iWidth = value; }
        }

        /// <summary>
        /// Largura vertical da imagem
        /// </summary>
        public int Height
        {
            get { return iHeight; }
            set { iHeight = value; }
        }

        /// <summary>
        /// Construtor - Trataimagem e altera o tamanho sem perder qualidade.
        /// </summary>
        /// <param name="Width">Largura - Tamanho em pixes</param>
        /// <param name="Height">Altura - Tamanho em pixes</param>
        /// /// <param name="Tipo_Redicionamento">Tipo de redimencionamento</param>
        public TrataImagem(int Width, int Height, Tipos_Redicionamento Tipo_Redicionamento)
        {
            iWidth = Width;
            iHeight = Height;
            tp_Redimencionamento = Tipo_Redicionamento;
        }

        /// <summary>
        /// /// Construtor - Trataimagem e altera o tamanho sem perder qualidade.
        /// </summary>
        /// <param name="Tipo_Redicionamento">Tipo de redimencionamento</param>
        public TrataImagem(Tipos_Redicionamento Tipo_Redicionamento)
        {
            iWidth = 0;
            iHeight = 0;
            tp_Redimencionamento = Tipo_Redicionamento;
        }

        /// <summary>
        /// Redimenciona imagem.
        /// </summary>
        /// <param name="Image_Original">Imagem com o seu tamanho real</param>
        /// <returns>Imagem com o tamanho alterado.</returns>
        public Image Redimencionar(ref Image Image_Original)
        {
            Image imgFinal;
            Graphics grp;

            //-- Redimenciona proporcionalmente.
            if (tp_Redimencionamento == Tipos_Redicionamento.Proporcional)
                this.Redimenciona_Imagem_Proporcionalmente(Image_Original.Width, Image_Original.Height);

            //-- redimenciona imagem de acordo com o parametro.
            imgFinal = new Bitmap(iWidth, iHeight);
            grp = Graphics.FromImage(imgFinal);
            grp.CompositingQuality = CompositingQuality.HighQuality;
            grp.SmoothingMode = SmoothingMode.HighQuality;
            grp.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grp.DrawImage(Image_Original, new Rectangle(0, 0, iWidth, iHeight));

            return imgFinal;
        }

        public Image Redimencionar(Image Image_Original)
        {
            return Redimencionar(ref Image_Original);
        }

        /// <summary>
        /// Redimenciona a imagem de acordo com os parametros
        /// </summary>
        /// <param name="iWidth_Original">Largura da imagem original</param>
        /// <param name="iHeight_Original">Altura da imagem original</param>
        private void Redimenciona_Imagem_Proporcionalmente(int iWidth_Original, int iHeight_Original)
        {
            //-- Calcula o valor da largura de acordo com a necessidade.
            if (iWidth_Original > iWidth)
            {
                decimal iPercTamanho = iWidth / Convert.ToDecimal(iWidth_Original);

                iWidth_Original = Convert.ToInt32(Convert.ToDecimal(iWidth_Original) * iPercTamanho);
                iHeight_Original = Convert.ToInt32(Convert.ToDecimal(iHeight_Original) * iPercTamanho);
            }

            //-- Calcula o valor da altura de acordo com a necessidade.
            if (iHeight_Original > iHeight)
            {
                decimal iPercTamanho = iHeight / Convert.ToDecimal(iHeight_Original);

                iWidth_Original = Convert.ToInt32(Convert.ToDecimal(iWidth_Original) * iPercTamanho);
                iHeight_Original = Convert.ToInt32(Convert.ToDecimal(iHeight_Original) * iPercTamanho);
            }

            iWidth = iWidth_Original;
            iHeight = iHeight_Original;
        }
    }
}