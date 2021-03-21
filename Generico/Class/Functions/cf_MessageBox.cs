using System;
using System.Windows.Forms;

namespace CompSoft.compFrameWork
{
    /// <summary>
    /// Description of cf_MessageBox.
    /// </summary>
    public class MsgBox
    {
        public static void Show(string Mensagem)
        {
            if (Propriedades.Form_Wait == null || Propriedades.Form_Wait.IsDisposed)
                MessageBox.Show(Mensagem);
            else
                MessageBox.Show(Propriedades.Form_Wait
                        , Mensagem);
        }

        public static void Show(string Mensagem, string Titulo)
        {
            if (Propriedades.Form_Wait == null || Propriedades.Form_Wait.IsDisposed)
            {
                MessageBox.Show(Mensagem
                    , Titulo);
            }
            else
            {
                MessageBox.Show(Propriedades.Form_Wait
                        , Mensagem
                        , Titulo);
            }
        }

        public static DialogResult Show(string Mensagem, string Titulo, MessageBoxButtons botoes)
        {
            if (Propriedades.Form_Wait == null || Propriedades.Form_Wait.IsDisposed)
            {
                return MessageBox.Show(Mensagem
                            , Titulo
                            , botoes);
            }
            else
            {
                return MessageBox.Show(Propriedades.Form_Wait
                            , Mensagem
                            , Titulo
                            , botoes);
            }
        }

        public static DialogResult Show(string Mensagem, string Titulo, MessageBoxButtons Botoes, MessageBoxIcon Icones)
        {
            if (Propriedades.Form_Wait == null || Propriedades.Form_Wait.IsDisposed)
            {
                return MessageBox.Show(Mensagem
                            , Titulo
                            , Botoes
                            , Icones);
            }
            else
            {
                return MessageBox.Show(Propriedades.Form_Wait
                            , Mensagem
                            , Titulo
                            , Botoes
                            , Icones);
            }
        }
    }
}