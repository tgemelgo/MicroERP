namespace BoletoNet
{
    public interface ICodigoLiquidacao
    {
        IBanco Banco { get; }
        int Enumerado { get; set; }
        string Codigo { get; set; }
        string Descricao { get; }
        string Recurso { get; }
    }
}