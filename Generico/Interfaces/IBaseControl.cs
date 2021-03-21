using System;
using System.Collections.Generic;
using System.Text;

namespace CompSoft.Interfaces
{
    public interface IBaseControl
    {
        /// <summary>
        /// Identifica o grupo para função de habilitar e desabilitar grupo de controle
        /// </summary>
        string Grupo { get; set; }

        /// <summary>
        /// Define o estado do controle em tela de acordo com o status do formulário.
        /// </summary>
        bool ReadOnly { get; set; }
    }
}