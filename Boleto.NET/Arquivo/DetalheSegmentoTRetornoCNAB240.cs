using System;
using System.Collections.Generic;

namespace BoletoNet
{
    public class DetalheSegmentoTRetornoCNAB240
    {
        #region Variáveis

        private int _codigoBanco;
        private int _idCodigoMovimento;
        private CodigoMovimento _codigoMovimento;
        private int _agencia;
        private string _digitoAgencia;
        private long _conta;
        private string _digitoConta;
        private int _dacAgConta;
        private string _nossoNumero; //identificação do título no banco
        private int _codigoCarteira;
        private string _numeroDocumento; //número utilizado pelo cliente para a identificação do título
        private DateTime _dataVencimento;
        private double _valorTitulo;
        private string _identificacaoTituloEmpresa;
        private int _tipoInscricao;
        private string _numeroInscricao;
        private string _nomeSacado;
        private double _valorTarifas;
        private int _codigoRejeicao;
        private string _registro;

        private List<DetalheSegmentoTRetornoCNAB240> _listaDetalhe = new List<DetalheSegmentoTRetornoCNAB240>();

        #endregion Variáveis

        #region Construtores

        public DetalheSegmentoTRetornoCNAB240()
        {
        }

        public DetalheSegmentoTRetornoCNAB240(string registro)
        {
            _registro = registro;
        }

        #endregion Construtores

        #region Propriedades

        public int idCodigoMovimento
        {
            get { return _idCodigoMovimento; }
            set { _idCodigoMovimento = value; }
        }

        public int CodigoBanco
        {
            get { return _codigoBanco; }
            set { _codigoBanco = value; }
        }

        public string Registro
        {
            get { return _registro; }
        }

        public CodigoMovimento CodigoMovimento
        {
            get
            {
                _codigoMovimento = new CodigoMovimento(_codigoBanco, _idCodigoMovimento);
                return _codigoMovimento;
            }
            set
            {
                _codigoMovimento = value;
                _idCodigoMovimento = _codigoMovimento.Codigo;
            }
        }

        public int Agencia
        {
            get { return _agencia; }
            set { _agencia = value; }
        }

        public string DigitoAgencia
        {
            get { return _digitoAgencia; }
            set { _digitoAgencia = value; }
        }

        public long Conta
        {
            get { return _conta; }
            set { _conta = value; }
        }

        public string DigitoConta
        {
            get { return _digitoConta; }
            set { _digitoConta = value; }
        }

        public int DACAgenciaConta
        {
            get { return _dacAgConta; }
            set { _dacAgConta = value; }
        }

        public string NossoNumero
        {
            get { return _nossoNumero; }
            set { _nossoNumero = value; }
        }

        public int CodigoCarteira
        {
            get { return _codigoCarteira; }
            set { _codigoCarteira = value; }
        }

        public string NumeroDocumento
        {
            get { return _numeroDocumento; }
            set { _numeroDocumento = value; }
        }

        public DateTime DataVencimento
        {
            get { return _dataVencimento; }
            set { _dataVencimento = value; }
        }

        public double ValorTitulo
        {
            get { return _valorTitulo; }
            set { _valorTitulo = value; }
        }

        public string IdentificacaoTituloEmpresa
        {
            get { return _identificacaoTituloEmpresa; }
            set { _identificacaoTituloEmpresa = value; }
        }

        public int TipoInscricao
        {
            get { return _tipoInscricao; }
            set { _tipoInscricao = value; }
        }

        public string NumeroInscricao
        {
            get { return _numeroInscricao; }
            set { _numeroInscricao = value; }
        }

        public string NomeSacado
        {
            get { return _nomeSacado; }
            set { _nomeSacado = value; }
        }

        public double ValorTarifas
        {
            get { return _valorTarifas; }
            set { _valorTarifas = value; }
        }

        public int CodigoRejeicao
        {
            get { return _codigoRejeicao; }
            set { _codigoRejeicao = value; }
        }

        public List<DetalheSegmentoTRetornoCNAB240> ListaDetalhe
        {
            get { return _listaDetalhe; }
            set { _listaDetalhe = value; }
        }

        #endregion Propriedades
    }
}