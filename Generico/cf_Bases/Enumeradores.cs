using System;
using System.Collections.Generic;
using System.Text;

namespace CompSoft
{
    public enum TipoControle
    {
        Geral = 0,
        Texto = 1,
        Numerico = 2,
        Moeda = 3,
        Data = 4,
        Indice = 5,
        Inteiro = 6,
        Hora = 7
    }

    /// <summary>
    /// Status disponiveis no formulário.
    /// </summary>
    public enum TipoFormStatus
    {
        Nenhum,
        Novo,
        Limpar,
        Pesquisar,
        Modificando,
        Excluindo,
        Fechando
    }

    /// <summary>
    /// Tipo de movimento do registro
    /// </summary>
    public enum Movimento
    {
        Primeiro,
        Ultimo,
        Proximo,
        Voltar,
        Atualizar_Atual
    }

    /// <summary>
    /// Como o sistema mostrará o total de registros.
    /// </summary>
    internal enum MostrarTotalRegistros
    {
        Contagem_Zerada,
        Contagem_Atual
    }

    /// <summary>
    /// Identifica o tipo de tratamento da barra de ferramentas.
    /// </summary>
    public enum TipoForm
    {
        Consulta,
        Geral
    }
}