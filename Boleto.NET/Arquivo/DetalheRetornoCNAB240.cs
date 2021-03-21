namespace BoletoNet
{
    public class DetalheRetornoCNAB240
    {
        #region Variáveis

        private DetalheSegmentoTRetornoCNAB240 _segmentoT = new DetalheSegmentoTRetornoCNAB240();
        private DetalheSegmentoURetornoCNAB240 _segmentoU = new DetalheSegmentoURetornoCNAB240();

        #endregion Variáveis

        #region Construtores

        public DetalheRetornoCNAB240()
        {
        }

        public DetalheRetornoCNAB240(DetalheSegmentoTRetornoCNAB240 segmentoT)
        {
            _segmentoT = segmentoT;
        }

        public DetalheRetornoCNAB240(DetalheSegmentoTRetornoCNAB240 segmentoT, DetalheSegmentoURetornoCNAB240 segmentoU)
        {
            _segmentoT = segmentoT;
            _segmentoU = segmentoU;
        }

        #endregion Construtores

        #region Propriedades

        public DetalheSegmentoTRetornoCNAB240 SegmentoT
        {
            get { return _segmentoT; }
            set { _segmentoT = value; }
        }

        public DetalheSegmentoURetornoCNAB240 SegmentoU
        {
            get { return _segmentoU; }
            set { _segmentoU = value; }
        }

        #endregion Propriedades
    }
}