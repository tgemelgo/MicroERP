using CompSoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace ERP.NFe
{
    internal class GerarDadosNFe : IDisposable
    {
        private string sNotasFiscais = string.Empty;
        private DataSet ds_NFe = new DataSet();

        public void Gerar_Dados_NFe(IList<CompSoft.NFe.Dados_Arquivo_NFe> ilNotas_Fiscais)
        {
            //-- Adicionar todos as NF selecionados em clausula IN do SQL
            sNotasFiscais = this.Criar_IN_NF(ilNotas_Fiscais);

            //-- Buscar todas as NF´s
            this.Gera_Dados_Capa_NFe();

            //-- Buscar todos os Itens das NF´s
            this.Gera_Dados_Itens_NFe();

            //-- Buscar todos as duplicatas das NF´s
            this.Gera_Dados_Duplicatas_NFe();

            //-- Gera relacionamento entre as tabelas.
            DataColumn dc_PK = this.ds_NFe.Tables["Notas_Fiscais"].Columns["Nota_Fiscal"];
            DataRelation dr = null;
            DataColumn dc_FK = null;

            //-- Relaciona duplicatas
            dc_FK = this.ds_NFe.Tables["Notas_Fiscais_Duplicatas"].Columns["Nota_Fiscal"];
            dr = new DataRelation("vw_DadosCapa_DANFE_vw_DadosDuplicatas_DANFE"
                , dc_PK
                , dc_FK);
            ds_NFe.Relations.Add(dr);

            //-- Relaciona itens
            dc_FK = this.ds_NFe.Tables["Notas_Fiscais_Itens"].Columns["Nota_Fiscal"];
            dr = new DataRelation("vw_DadosCapa_DANFE_vw_DadosItens_DANFE"
                , dc_PK
                , dc_FK);
            ds_NFe.Relations.Add(dr);
        }

        #region Propriedades

        /// <summary>
        /// Dados encontrados da NFe
        /// </summary>
        public DataSet DataSet_NFe
        {
            get { return ds_NFe; }
        }

        #endregion Propriedades

        #region Coloca todos os códigos de NF separados por virgula.

        /// <summary>
        /// Coloca todos os códigos de NF separados por virgula.
        /// </summary>
        /// <param name="Notas_fiscais">IList com todos os Códigos de NF</param>
        /// <returns>string com códigos separados por virgula</returns>
        private string Criar_IN_NF(IList<CompSoft.NFe.Dados_Arquivo_NFe> Notas_fiscais)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CompSoft.NFe.Dados_Arquivo_NFe iNF in Notas_fiscais)
            {
                if (sb.Length > 0)
                    sb.Append(", ");

                sb.Append(iNF.Nota_Fiscal);
            }

            return sb.ToString();
        }

        #endregion Coloca todos os códigos de NF separados por virgula.

        #region Gera Dados da capa da NF

        private void Gera_Dados_Capa_NFe()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"select
                                   nf.*
                                 , case when nf.Nota_Fiscal_Referencia is not null then coalesce(nf.Descricao_CFOP_Complementar, 'Complementar') else cfop.desc_cfop end as 'desc_cfop'
                                 , e.IE as 'IE_empresa'
                                 , e.CNPJ as 'CNPJ_Empresa'
                                 , e.Razao_Social as 'Razao_Social_Empresa'
                                 , e.Nome_Fantasia as 'Nome_Fantasia_Empresa'
                                 , e.endereco as 'Endereco_Empresa'
                                 , e.numero as 'Numero_Empresa'
                                 , e.Complemento as 'Complemento_Empresa'
                                 , e.Bairro as 'Bairro_empresa'
                                 , e.Cidade as 'Cidade_Empresa'
                                 , e.Cod_Cidade_IBGE as 'Cod_Cidade_IBGE_Empresa'
                                 , e.estado as 'Estado_Empresa'
                                 , e.Cod_Estado_IBGE as 'Cod_Estado_IBGE_Empresa'
                                 , e.CEP as 'CEP_Empresa'
                                 , e.ddd_comercial as 'DDD_Empresa'
                                 , e.Telefone_Comercial as 'Fone_Empresa'
                                 , p.Nome_Pais as 'Nome_Pais_empresa'
                                 , e.Cod_Pais_IBGE as 'Cod_Pais_IBGE_Empresa'
                                 , rt.Calcular_Credito_ICMS as 'Calcular_Credito_ICMS_SN'
                                 , ltrim(rtrim(convert(varchar(10), e.ddd_Comercial))) + rtrim(ltrim(e.Telefone_Comercial)) as 'Fone_Comercial_Empresa'
                                 , substring(nf.chave_acesso, len(nf.chave_acesso), 1) as 'Chave_Acesso_Digito'
                                 , case
                                  when nf.tipo_Saida = 1 then 1
                                  when nf.tipo_entrada = 1 then 0
                                   end as 'Tipo_Documento_Fiscal'
                                 , cl.Razao_Social as 'Razao_Social_Cliente'
                                 , cl.CPF_CNPJ as 'CNPJ_Cliente'
                                 , cl.Pessoa_Juridica
                                 , cl.RG_IE as 'RG_IE_Cliente'
                                 , rtrim(ltrim(convert(varchar(10), cl.DDD1))) + rtrim(ltrim(cl.Fone1)) as 'Telefone_Cliente'
                                 , cl.Endereco_Correspondencia
                                 , cl.Numero_Correspondencia
                                 , cl.Complemento_Correspondencia
                                 , cl.Bairro_Correspondencia
                                 , cl.Cidade_Correspondencia
                                 , cl.cod_cidade_correspondencia_ibge
                                 , cl.Estado_Correspondencia
                                 , cl.CEP_Correspondencia
                                 , cl.cod_pais_correspondencia_IBGE
                                 , p1.nome_pais as 'Nome_Pais_correspondencia'
                                 , t.Razao_Social as 'Razao_Social_Transportadora'
                                 , t.CNPJ as 'CNPJ_Transportadora'
                                 , t.Inscricao_Estadual as 'IE_Transportadora'
                                 , case
                                  when t.Numero is not null then t.Endereco + ', ' + t.Numero
                                  else t.Endereco
                                   end as 'Endereco_Transportadora'
                                 , t.Cidade as 'Cidade_Transportadora'
                                 , t.Estado as 'Estado_Transportadora'
                                 , convert(tinyint, cpp.Parcelado) as 'Indica_Parcelado'
                                 , tf.Tipo_Frete_NFe
                                 , e.Regime_Tributario
                                 , nf.NFe_Protocolo
                                 , nf.NFe_Protocolo_Data
                                 , nf.Valor_Cred_Simples_Nacional
                                 , cl.Regime_Normal_RPA
                                 , e.DataEntrega_Igual_DataSistema
                                 , cl.consumidor_final

                                 , nfr.Chave_Acesso as 'Chave_Acesso_Referencia'
                                 , nfr.Data_Emissao as 'Data_Emissao_Referencia'
                                 , nfr.Serie_Nota as 'Serie_Nota_Referencia'
                                 , nfr.Nota_Fiscal as 'Nota_Nota_Referencia'
                                 from notas_fiscais nf
                                  inner join cfops cfop on cfop.cfop = nf.cfop
                                  inner join empresas e on e.empresa = nf.empresa
                                  inner join clientes cl on cl.cliente = nf.cliente
                                  inner join transportadoras t on t.transportadora = nf.transportadora
                                  inner join condicoes_pagamento_pedido cpp on cpp.condicao_pagamento_pedido = nf.condicao_pagamento_pedido
                                  inner join Paises p1 on p1.codigo_ibge = cl.cod_pais_correspondencia_ibge
                                  inner join Tipos_Fretes tf on tf.Tipo_Frete = nf.Tipo_Frete
                                  inner join regimes_tributarios rt on rt.regime_tributario = e.regime_tributario
                                  left outer join Paises p on p.codigo_ibge = e.cod_pais_ibge
                                  left outer join Notas_Fiscais nfr on nfr.Nota_Fiscal = nf.Nota_Fiscal_Referencia
                                 where nf.nota_fiscal in ({0})", sNotasFiscais);
            DataTable dt = SQL.Select(sb.ToString(), "Notas_Fiscais", false);

            dt.Columns["chave_Acesso_digito"].ReadOnly = false;

            DateTime dtHoje = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"), CultureInfo.GetCultureInfo("pt-BR"));

            //-- Gera a chave de acesso dos itens.
            foreach (DataRow row in dt.Select())
            {
                sb.Remove(0, sb.Length);
                sb.Append(row["Cod_Estado_IBGE_Empresa"].ToString().PadLeft(2, '0')); //-- UF de emissão
                sb.Append(Convert.ToDateTime(row["Data_Emissao"]).ToString("yyMM"));  //-- Ano e mês de emissão
                sb.Append(row["CNPJ_Empresa"].ToString().PadLeft(14, '0'));           //-- CNPJ da empresa emissora
                sb.Append("55");                                                      //-- Modelo da Nota
                sb.Append(row["serie_nota"].ToString().PadLeft(3, '0'));              //-- Serie
                sb.Append(row["numero_nota"].ToString().PadLeft(9, '0'));             //-- Número da NF-e
                sb.Append("1");                                                       //-- Tipo de emissão - NORMAL(1) - CONTINGENCIA(2)
                sb.Append(row["Nota_Fiscal"].ToString().PadLeft(8, '0'));             //-- Código númerico aleatório (Campo NOTA_FISCAL = Identity)

                CompSoft.NFe.Funcoes_NFe f = new CompSoft.NFe.Funcoes_NFe();
                string sChave_Acesso = f.Calcula_DV_ChaveNFe(sb.ToString());

                sb.Remove(0, sb.Length);
                sb.AppendFormat("update notas_fiscais set chave_acesso = '{0}' where nota_fiscal = {1}"
                    , sChave_Acesso
                    , row["nota_Fiscal"]);
                CompSoft.Data.SQL.ExecuteNonQuery(sb.ToString());

                row.BeginEdit();
                row["chave_Acesso"] = sChave_Acesso;
                row["chave_Acesso_digito"] = sChave_Acesso.Substring(43, 1);

                //-- Corrigi data de saída
                if (Convert.ToDateTime(row["data_entrega"]) <= dtHoje || Convert.ToBoolean(row["DataEntrega_Igual_DataSistema"]))
                {
                    row["data_entrega"] = dtHoje;
                }
                row.EndEdit();
            }

            ///-- Adiciona tabela no dataset
            ds_NFe.Tables.Add(dt);
        }

        #endregion Gera Dados da capa da NF

        #region Gera dados dos itens da NF

        private void Gera_Dados_Itens_NFe()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   000 as 'CountItem' ");
            sb.AppendLine(" , nfi.*");
            sb.AppendLine(" , replace(cf.Cod_Classificacao_Fiscal, '.', '') as 'Cod_Classificacao_Fiscal'");
            sb.AppendLine(" , substring(nfi.Situacao_Tributaria, 1, 1) as 'Origem_Situacao_Tributaria'");
            sb.AppendLine(" , substring(nfi.Situacao_Tributaria, 2, 2) as 'Tipo_Situacao_Tributaria'");
            sb.AppendLine(" , stp.sufixo_nfe as 'Sufixo_Nfe_PIS'");
            sb.AppendLine(" , stc.sufixo_nfe as 'Sufixo_Nfe_Cofins'");
            sb.AppendLine(" , pr.EAN");
            sb.AppendLine("from notas_fiscais_itens nfi");
            sb.AppendLine(" inner join classificacoes_fiscais cf on cf.classificacao_fiscal = nfi.classificacao_fiscal");
            sb.AppendLine(" inner join produtos pr on pr.produto = nfi.produto");
            sb.AppendLine(" left outer join situacoes_tributaria_pis stp on stp.situacao_tributaria_pis = nfi.situacao_tributaria_pis");
            sb.AppendLine(" left outer join situacoes_tributaria_cofins stc on stc.situacao_tributaria_cofins = nfi.situacao_tributaria_cofins");
            sb.AppendFormat(" where nfi.nota_fiscal in ({0})", sNotasFiscais);
            DataTable dt = SQL.Select(sb.ToString(), "Notas_Fiscais_Itens", false);

            dt.Columns["CountItem"].ReadOnly = false;

            //-- Varre todas as NF.
            foreach (DataRow row in ds_NFe.Tables["Notas_Fiscais"].Select())
            {
                string sFilter = string.Format("Nota_Fiscal = {0}", row["Nota_fiscal"]);
                int i = 1;
                foreach (DataRow row_nfi in dt.Select(sFilter))
                {
                    row_nfi["CountItem"] = i;
                    i++;
                }
            }

            ///-- Adiciona tabela no dataset
            ds_NFe.Tables.Add(dt);
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
            sb.AppendFormat(" where nfd.Nota_Fiscal in ({0})", sNotasFiscais);
            DataTable dt = SQL.Select(sb.ToString(), "Notas_Fiscais_Duplicatas", false);

            ///-- Adiciona tabela no dataset
            ds_NFe.Tables.Add(dt);
        }

        #endregion Gera dados dos duplicatas da NF

        #region IDisposable Members

        public void Dispose()
        {
            sNotasFiscais = null;
            foreach (DataTable dt in ds_NFe.Tables)
                dt.Clear();

            ds_NFe.Dispose();
            ds_NFe = null;
        }

        #endregion IDisposable Members
    }
}