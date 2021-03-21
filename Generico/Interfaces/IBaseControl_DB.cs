using System.ComponentModel;

namespace CompSoft.Interfaces
{
    /// <summary>
    /// interface para criação de componentes que manipulam dados
    /// </summary>
    public interface IBaseControl_DB
    {
        string ControlSource { get; set; }

        string Tabela { get; set; }

        string Tabela_INNER { get; set; }

        bool Obrigatorio { get; set; }

        string MensagemObrigatorio { get; set; }

        bool Remover_Mensagem { set; }

        bool Incluir_QueryBy { get; set; }

        string ValueQueryBy { get; }

        bool ValidarCampos();
    }
}