using System;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumInstrucoes_Bradesco
    {
        Protestar = 9,
        NaoProtestar = 10,
        ProtestoFinsFalimentares = 42,
        ProtestarAposNDiasCorridos = 81,
        ProtestarAposNDiasUteis = 82,
        NaoReceberAposNDias = 91,
        DevolverAposNDias = 92,
    }

    #endregion Enumerado

    public class Instrucao_Bradesco : AbstractInstrucao, IInstrucao
    {
        #region Construtores

        public Instrucao_Bradesco()
        {
            try
            {
                this.Banco = new Banco(237);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public Instrucao_Bradesco(int codigo)
        {
            this.carregar(codigo, 0);
        }

        public Instrucao_Bradesco(int codigo, int nrDias)
        {
            this.carregar(codigo, nrDias);
        }

        #endregion Construtores

        #region Metodos Privados

        private void carregar(int idInstrucao, int nrDias)
        {
            try
            {
                this.Banco = new Banco_Bradesco();
                this.Valida();

                switch ((EnumInstrucoes_Bradesco)idInstrucao)
                {
                    case EnumInstrucoes_Bradesco.Protestar:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.Protestar;
                        this.Descricao = "Protestar";
                        break;

                    case EnumInstrucoes_Bradesco.NaoProtestar:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.NaoProtestar;
                        this.Descricao = "Não protestar";
                        break;

                    case EnumInstrucoes_Bradesco.ProtestoFinsFalimentares:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.ProtestoFinsFalimentares;
                        this.Descricao = "Protesto para fins falimentares";
                        break;

                    case EnumInstrucoes_Bradesco.ProtestarAposNDiasCorridos:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.ProtestarAposNDiasCorridos;
                        this.Descricao = string.Format("Protestar após {0} dias corridos do vencimento", nrDias);
                        break;

                    case EnumInstrucoes_Bradesco.ProtestarAposNDiasUteis:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.ProtestarAposNDiasUteis;
                        this.Descricao = string.Format("Protestar após {0} dias úteis do vencimento", nrDias);
                        break;

                    case EnumInstrucoes_Bradesco.NaoReceberAposNDias:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.NaoReceberAposNDias;
                        this.Descricao = string.Format("Não receber após {0} dias do vencimento", nrDias);
                        break;

                    case EnumInstrucoes_Bradesco.DevolverAposNDias:
                        this.Codigo = (int)EnumInstrucoes_Bradesco.DevolverAposNDias;
                        this.Descricao = string.Format("Devolver após {0} dias do vencimento", nrDias);
                        break;

                    default:
                        this.Codigo = 0;
                        this.Descricao = " (Selecione) ";
                        break;
                }

                this.QuantidadeDias = nrDias;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public override void Valida()
        {
            //base.Valida();
        }

        #endregion Metodos Privados
    }
}