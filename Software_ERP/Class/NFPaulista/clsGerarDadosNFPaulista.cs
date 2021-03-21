using CompSoft.compFrameWork;
using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ERP.NFPaulista
{
    internal class GerarDadosNFPaulista : IDisposable
    {
        private string sNotasFiscais = string.Empty;
        private ERP.NFPaulista.GerarNFPaulista nfp;

        public GerarDadosNFPaulista(string sCaminho_Arquivo)
        {
            nfp = new GerarNFPaulista(sCaminho_Arquivo);
        }

        #region IDisposable Members

        public void Dispose()
        {
            sNotasFiscais = null;
            nfp.Dispose();
            nfp = null;
        }

        #endregion IDisposable Members

        #region Coloca todos os códigos de NF separados por virgula.

        /// <summary>
        /// Coloca todos os códigos de NF separados por virgula.
        /// </summary>
        /// <param name="Notas_fiscais">IList com todos os Códigos de NF</param>
        /// <returns>string com códigos separados por virgula</returns>
        private string Criar_IN_NF(IList<int> Notas_fiscais)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int iNF in Notas_fiscais)
            {
                if (sb.Length > 0)
                    sb.Append(", ");

                sb.Append(iNF);
            }

            return sb.ToString();
        }

        #endregion Coloca todos os códigos de NF separados por virgula.

        #region Gera dados e chama rotina para gerar o arquivo de NFp

        public void Gerar_Dados_NFe(IList<int> ilNotas_Fiscais)
        {
            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, carregado dados para exportação.");

            //-- Adicionar todos as NF selecionados em clausula IN do SQL
            sNotasFiscais = this.Criar_IN_NF(ilNotas_Fiscais);

            //-- Encontra as empresas que estão na NF.
            this.Empresas_NF();

            //-- Buscar todas as NF´s
            this.Gera_Dados_Capa_NFPaulista();

            //-- Buscar todos os Itens das NF´s
            this.Gera_Dados_Itens_NFPaulista();

            f.Close();
            f.Dispose();

            //-- Cria NF-Paulista
            if (nfp.Criar_NFPaulista())
                MsgBox.Show("Nota Fiscal Paulista gerada e enviada com sucesso."
                    , "Envio com sucesso"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Information);
            else
                MsgBox.Show("Erro ao gerar ou enviar Nota Fiscal Paulista, consulte o log de envio para verificar os possiveis problemas."
                    , "Atenção"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Error);
        }

        #endregion Gera dados e chama rotina para gerar o arquivo de NFp

        #region Gera Dados da capa da NF

        private void Gera_Dados_Capa_NFPaulista()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   nf.*");
            sb.AppendLine(" , case ");
            sb.AppendLine("  when nf.tipo_Saida = 1 then 1");
            sb.AppendLine("  when nf.tipo_entrada = 1 then 0");
            sb.AppendLine("   end as 'Tipo_Documento_Fiscal'");
            sb.AppendLine(" , cl.Razao_Social as 'Razao_Social_Cliente'");
            sb.AppendLine(" , cl.CPF_CNPJ ");
            sb.AppendLine(" , cl.Pessoa_Juridica");
            sb.AppendLine(" , cl.RG_IE as 'RG_IE_Cliente'");
            sb.AppendLine(" , convert(varchar(10), cl.DDD1) + cl.Fone1 as 'Telefone_Cliente'");
            sb.AppendLine(" , cl.Endereco_Correspondencia");
            sb.AppendLine(" , cl.Numero_Correspondencia");
            sb.AppendLine(" , cl.Complemento_Correspondencia");
            sb.AppendLine(" , cl.Bairro_Correspondencia");
            sb.AppendLine(" , cl.Cidade_Correspondencia");
            sb.AppendLine(" , cl.cod_cidade_correspondencia_ibge");
            sb.AppendLine(" , cl.Estado_Correspondencia");
            sb.AppendLine(" , cl.CEP_Correspondencia");
            sb.AppendLine(" , p.Nome_Pais as 'Pais_Correspondencia'");
            sb.AppendLine(" , t.Razao_Social as 'Razao_Social_Transportadora'");
            sb.AppendLine(" , t.CNPJ");
            sb.AppendLine(" , t.Inscricao_Estadual as 'IE_Transportadora'");
            sb.AppendLine(" , case");
            sb.AppendLine("  when t.Numero is not null then t.Endereco + ', ' + t.Numero");
            sb.AppendLine("  else t.Endereco");
            sb.AppendLine("   end as 'Endereco_Transportadora'");
            sb.AppendLine(" , t.Cidade as 'Cidade_Transportadora'");
            sb.AppendLine(" , t.Estado as 'Estado_Transportadora'");
            sb.AppendLine(" , tf.Tipo_Frete_NFe");
            sb.AppendLine(" from notas_fiscais nf");
            sb.AppendLine("  inner join clientes cl on cl.cliente = nf.cliente");
            sb.AppendLine("  inner join transportadoras t on t.transportadora = nf.transportadora");
            sb.AppendLine("  inner join condicoes_pagamento_pedido cpp on cpp.condicao_pagamento_pedido = nf.condicao_pagamento_pedido");
            sb.AppendLine("  inner join Tipos_Fretes tf on tf.Tipo_Frete = nf.Tipo_Frete");
            sb.AppendLine("  inner join paises p on p.codigo_ibge = cl.cod_pais_correspondencia_ibge");
            sb.AppendFormat(" where nf.nota_fiscal in ({0})", sNotasFiscais);
            DataTable dt = SQL.Select(sb.ToString(), "Notas_Fiscais", false);

            dt.Columns.Add("NumArquivo", typeof(System.Int32));

            ///-- Adiciona tabela no dataset
            nfp.dataset.Tables.Add(dt);
        }

        #endregion Gera Dados da capa da NF

        #region Gera dados dos itens da NF

        private void Gera_Dados_Itens_NFPaulista()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from notas_fiscais_itens");
            sb.AppendFormat(" where Nota_Fiscal in ({0})", sNotasFiscais);
            DataTable dt = SQL.Select(sb.ToString(), "Notas_Fiscais_Itens", false);

            ///-- Adiciona tabela no dataset
            nfp.dataset.Tables.Add(dt);
        }

        #endregion Gera dados dos itens da NF

        #region Gera dados dos duplicatas da NF

        private void Gera_Dados_Duplicatas_NFe()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   nfd.Nota_fiscal");
            sb.AppendLine(" , convert(varchar(20), nf.numero_nota) + '/' + convert(varchar(3), nfd.numero_parcela) as 'Numero_Duplicata'");
            sb.AppendLine(" , nfd.Data_Vencimento");
            sb.AppendLine(" , nfd.Valor_Duplicata");
            sb.AppendLine(" from notas_fiscais_duplicatas nfd");
            sb.AppendLine("  inner join notas_fiscais nf on nf.nota_fiscal = nfd.nota_fiscal");
            sb.AppendFormat(" where nf.Nota_Fiscal in ({0})", sNotasFiscais);
            DataTable dt = SQL.Select(sb.ToString(), "Notas_Fiscais_Duplicatas", false);

            ///-- Adiciona tabela no dataset
            nfp.dataset.Tables.Add(dt);
        }

        #endregion Gera dados dos duplicatas da NF

        #region Encontra as empresas que estão presentas na NF

        private void Empresas_NF()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select e.empresa, e.Razao_Social, e.cnpj  from empresas e");
            sb.AppendLine(" inner join notas_fiscais nf on nf.empresa = e.empresa");
            sb.AppendFormat(" where nf.Nota_Fiscal in ({0})\r\n", sNotasFiscais);
            sb.AppendLine(" group by e.empresa, e.Razao_Social, e.cnpj ");

            DataTable dt = SQL.Select(sb.ToString(), "Empresas", false);
            nfp.dataset.Tables.Add(dt);
        }

        #endregion Encontra as empresas que estão presentas na NF
    }
}