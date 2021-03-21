using System;
using System.Collections.Generic;

namespace BoletoNet
{
    public class DetalheSegmentoURetornoCNAB240
    {
        #region Variáveis

        private double _jurosMultaEncargos;
        private double _valorDescontoConcedido;
        private double _valorAbatimentoConcedido;
        private double _valorIOFRecolhido;
        private double _valorPagoPeloSacado;
        private double _valorLiquidoASerCreditado;
        private double _valorOutrasDespesas;
        private double _valorOutrosCreditos;
        private DateTime _dataOcorrencia;
        private DateTime _dataCredito;
        private string _codigoOcorrenciaSacado;
        private DateTime _dataOcorrenciaSacado;
        private double _valorOcorrenciaSacado;
        private string _registro;

        private List<DetalheSegmentoURetornoCNAB240> _listaDetalhe = new List<DetalheSegmentoURetornoCNAB240>();

        #endregion Variáveis

        #region Construtores

        public DetalheSegmentoURetornoCNAB240(string registro)
        {
            _registro = registro;
        }

        public DetalheSegmentoURetornoCNAB240()
        {
        }

        #endregion Construtores

        #region Propriedades

        public double JurosMultaEncargos
        {
            get { return _jurosMultaEncargos; }
            set { _jurosMultaEncargos = value; }
        }

        public double ValorDescontoConcedido
        {
            get { return _valorDescontoConcedido; }
            set { _valorDescontoConcedido = value; }
        }

        public double ValorAbatimentoConcedido
        {
            get { return _valorAbatimentoConcedido; }
            set { _valorAbatimentoConcedido = value; }
        }

        public double ValorIOFRecolhido
        {
            get { return _valorIOFRecolhido; }
            set { _valorIOFRecolhido = value; }
        }

        public double ValorPagoPeloSacado
        {
            get { return _valorPagoPeloSacado; }
            set { _valorPagoPeloSacado = value; }
        }

        public double ValorLiquidoASerCreditado
        {
            get { return _valorLiquidoASerCreditado; }
            set { _valorLiquidoASerCreditado = value; }
        }

        public double ValorOutrasDespesas
        {
            get { return _valorOutrasDespesas; }
            set { _valorOutrasDespesas = value; }
        }

        public double ValorOutrosCreditos
        {
            get { return _valorOutrosCreditos; }
            set { _valorOutrosCreditos = value; }
        }

        public DateTime DataOcorrencia
        {
            get { return _dataOcorrencia; }
            set { _dataOcorrencia = value; }
        }

        public DateTime DataCredito
        {
            get { return _dataCredito; }
            set { _dataCredito = value; }
        }

        public string CodigoOcorrenciaSacado
        {
            get { return _codigoOcorrenciaSacado; }
            set { _codigoOcorrenciaSacado = value; }
        }

        public DateTime DataOcorrenciaSacado
        {
            get { return _dataOcorrenciaSacado; }
            set { _dataOcorrenciaSacado = value; }
        }

        public double ValorOcorrenciaSacado

        {
            get { return _valorOcorrenciaSacado; }
            set { _valorOcorrenciaSacado = value; }
        }

        public List<DetalheSegmentoURetornoCNAB240> ListaDetalhe
        {
            get { return _listaDetalhe; }
            set { _listaDetalhe = value; }
        }

        public string Registro
        {
            get { return _registro; }
        }

        #endregion Propriedades
    }
}