using System;
using System.Collections.Generic;
using System.Text;

namespace CompSoft.cf_Bases
{
    internal class cf_ImageListBoxItem : DevExpress.XtraEditors.Controls.ImageListBoxItem
    {
        private string sDescricao
            , sNameSpace
            , sRelatorio;

        private bool bTodos_Reg = false
            , bReg_Atual = false;

        private int iId_Relatorio
            , iTipoSelecionado;

        public bool Todos_Reg
        {
            get { return bTodos_Reg; }
            set { bTodos_Reg = value; }
        }

        public bool Reg_Atual
        {
            get { return bReg_Atual; }
            set { bReg_Atual = value; }
        }

        public int Tipo_Selecionado
        {
            get { return iTipoSelecionado; }
            set { iTipoSelecionado = value; }
        }

        public int Id_Relatorio
        {
            get { return iId_Relatorio; }
            set { iId_Relatorio = value; }
        }

        public string Descricao
        {
            get { return sDescricao; }
            set { sDescricao = value; }
        }

        public string NameSpace
        {
            get { return sNameSpace; }
            set { sNameSpace = value; }
        }

        public string Relatorio
        {
            get { return sRelatorio; }
            set { sRelatorio = value; }
        }
    }
}