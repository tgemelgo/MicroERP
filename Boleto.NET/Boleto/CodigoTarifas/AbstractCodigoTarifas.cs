namespace BoletoNet
{
    public abstract class AbstractCodigoTarifas : ICodigoTarifas
    {
        #region Variaveis

        private IBanco _banco;
        private int _codigo;
        private string _descricao;

        #endregion Variaveis

        # region Propriedades

        public virtual IBanco Banco
        {
            get { return _banco; }
            set { _banco = value; }
        }

        public virtual int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        # endregion
    }
}