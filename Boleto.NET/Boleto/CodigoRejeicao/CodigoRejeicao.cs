namespace BoletoNet
{
    public class CodigoRejeicao : AbstractCodigoRejeicao, ICodigoRejeicao
    {
        #region Variaveis

        private ICodigoRejeicao _ICodigoRejeicao = null;

        #endregion Variaveis

        #region Propriedades da interface

        public override IBanco Banco
        {
            get { return _ICodigoRejeicao.Banco; }
        }

        public override int Codigo
        {
            get { return _ICodigoRejeicao.Codigo; }
        }

        public override string Descricao
        {
            get { return _ICodigoRejeicao.Descricao; }
        }

        #endregion Propriedades da interface
    }
}