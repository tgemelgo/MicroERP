namespace BoletoNet
{
    public abstract class AbstractEspecieDocumento : IEspecieDocumento
    {
        #region Variaveis

        private IBanco _banco;
        private int _codigo;
        private string _sigla;
        private string _especie;

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

        public virtual string Sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }

        public virtual string Especie
        {
            get { return _especie; }
            set { _especie = value; }
        }

        # endregion
    }
}