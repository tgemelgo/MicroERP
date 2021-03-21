using System;
using System.Collections.Generic;
using System.IO;

namespace BoletoNet
{
    public class ArquivoRetornoCNAB240 : AbstractArquivoRetorno, IArquivoRetorno
    {
        private Stream _streamArquivo;
        private string _caminhoArquivo = string.Empty;
        private List<DetalheRetornoCNAB240> _listaDetalhes = new List<DetalheRetornoCNAB240>();

        #region Propriedades

        public string CaminhoArquivo
        {
            get { return _caminhoArquivo; }
        }

        public Stream StreamArquivo
        {
            get { return _streamArquivo; }
        }

        public List<DetalheRetornoCNAB240> ListaDetalhes
        {
            get { return _listaDetalhes; }
            set { _listaDetalhes = value; }
        }

        #endregion Propriedades

        #region Construtores

        public ArquivoRetornoCNAB240()
        {
            this.TipoArquivo = TipoArquivo.CNAB240;
        }

        public ArquivoRetornoCNAB240(Stream streamArquivo)
        {
            this.TipoArquivo = TipoArquivo.CNAB240;
            _streamArquivo = streamArquivo;
        }

        public ArquivoRetornoCNAB240(string caminhoArquivo)
        {
            this.TipoArquivo = TipoArquivo.CNAB240;

            _streamArquivo = new StreamReader(caminhoArquivo).BaseStream;
        }

        #endregion Construtores

        #region Métodos de instância

        public void LerArquivoRetorno(IBanco banco)
        {
            LerArquivoRetorno(banco, StreamArquivo);
        }

        public override void LerArquivoRetorno(IBanco banco, Stream arquivo)
        {
            try
            {
                StreamReader stream = new StreamReader(arquivo);
                string linha = "";

                // Lendo o arquivo
                linha = stream.ReadLine();
                OnLinhaLida(null, linha, EnumTipodeLinhaLida.HeaderDeArquivo);

                // Próxima linha (DETALHE)
                linha = stream.ReadLine();
                OnLinhaLida(null, linha, EnumTipodeLinhaLida.HeaderDeLote);
                linha = stream.ReadLine();

                while (linha.Substring(7, 1) == "3")
                {
                    //Ler detalhe do registro - Segmento T
                    DetalheRetornoCNAB240 detalheRetorno = new DetalheRetornoCNAB240(banco.LerDetalheSegmentoTRetornoCNAB240(linha));
                    OnLinhaLida(detalheRetorno, linha, EnumTipodeLinhaLida.DetalheSegmentoT);

                    //Ler detalhe do registro - Segmento U
                    linha = stream.ReadLine();
                    detalheRetorno.SegmentoU = banco.LerDetalheSegmentoURetornoCNAB240(linha);
                    OnLinhaLida(detalheRetorno, linha, EnumTipodeLinhaLida.DetalheSegmentoU);

                    ListaDetalhes.Add(detalheRetorno);
                    linha = stream.ReadLine();
                }
                OnLinhaLida(null, linha, EnumTipodeLinhaLida.TraillerDeLote);
                linha = stream.ReadLine();
                OnLinhaLida(null, linha, EnumTipodeLinhaLida.TraillerDeArquivo);

                stream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler arquivo.", ex);
            }
        }

        #endregion Métodos de instância
    }
}