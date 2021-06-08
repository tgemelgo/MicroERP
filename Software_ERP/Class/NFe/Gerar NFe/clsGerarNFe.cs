using CompSoft.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ERP.NFe
{
    internal class XML_NFe : IDisposable
    {
        private DataSet ds;
        private string sCaminhoArquivo = string.Empty;
        private IList<CompSoft.NFe.Dados_Arquivo_NFe> ilFiles;

        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sPathSaveFile">Diretório para criação do arquivo XML</param>
        /// <param name="dataset">DataSet com os dados da NF-e</param>
        public XML_NFe(string sPathSaveFile, DataSet dataset, IList<CompSoft.NFe.Dados_Arquivo_NFe> ilNotas)
        {
            sCaminhoArquivo = sPathSaveFile;
            if (!sCaminhoArquivo.EndsWith(@"\"))
                sCaminhoArquivo += @"\";

            ds = dataset;

            ilFiles = ilNotas;
        }

        #endregion Construtor

        #region IDisposable Members

        public void Dispose()
        {
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
        }

        #endregion IDisposable Members

        #region Gera Xml da NF-e

        /// <summary>
        /// Gera arquivo de NF-e (Um arquivo por NOTA)
        /// </summary>
        public void Gerar_XML_NFe()
        {
            foreach (CompSoft.NFe.Dados_Arquivo_NFe daNFe in ilFiles)
            {
                foreach (DataRow row in ds.Tables["Notas_Fiscais"].Select("Nota_fiscal = " + daNFe.Nota_Fiscal.ToString()))
                {
                    //-- Cria o documento XML.
                    CriarXML xml = new CriarXML();

                    //-- Cria a declaração do XML.
                    xml.Criar_Declaracao("1.0", "UTF-8");

                    //-- Cria os elementos. 'NFe'
                    xml.Criar_Elemento("NFe");
                    xml.Setar_Atributo("NFe", "xmlns", "http://www.portalfiscal.inf.br/nfe");

                    //-- Cria os elementos. 'infNFe'
                    xml.Criar_Elemento("/NFe", "infNFe");
                    xml.Setar_Atributo("/NFe/infNFe", "Id", "NFe" + row["chave_acesso"].ToString());
                    daNFe.Chave_Acesso = row["chave_acesso"].ToString();

                    CompSoft.NFe.Dados_DocumentosNFe doc = new CompSoft.NFe.Dados_DocumentosNFe(CompSoft.NFe.Tipos_Servicos.Sem_WebService_Arquivo_NFe);
                    xml.Setar_Atributo("/NFe/infNFe", "versao", doc.Versao_Dados);

                    //-- Cria o elemento. 'ide'
                    xml.Criar_Elemento("/NFe/infNFe", "ide");
                    this.Criar_Dados_Tag_ide(row, xml, daNFe);

                    //-- Cria o elemento. 'emit'
                    xml.Criar_Elemento("/NFe/infNFe", "emit");
                    this.Criar_Dados_Tag_emit(row, xml);

                    //-- Cria o elemento. 'dest'
                    xml.Criar_Elemento("/NFe/infNFe", "dest");
                    this.Criar_Dados_Tag_dest(row, xml);

                    //-- Cria elementos dos itens da NF-e 'det'
                    foreach (DataRow row_itens in ds.Tables["Notas_Fiscais_Itens"].Select("Nota_Fiscal = " + row["Nota_Fiscal"].ToString(), "CountItem"))
                    {
                        xml.Criar_Elemento("/NFe/infNFe", "det");
                        xml.Setar_Atributo("/NFe/infNFe/det", "nItem", row_itens["CountItem"].ToString());
                        this.Criar_Dados_Tag_det(row, row_itens, xml);
                    }

                    //-- Cria o elemento. 'total'
                    xml.Criar_Elemento("/NFe/infNFe", "total");
                    this.Criar_Dados_Tag_total(row, ds.Tables["Notas_Fiscais_Itens"], xml);

                    //-- Cria o elemento. 'transp'
                    xml.Criar_Elemento("/NFe/infNFe", "transp");
                    this.Criar_Dados_Tag_transp(row, xml);

                    //-- Cria o elemento. 'cobr'
                    xml.Criar_Elemento("/NFe/infNFe", "cobr");
                    this.Criar_Dados_Tag_cobr(row, xml);

                    //-- Cria o elemento. 'pag'
                    xml.Criar_Elemento("/NFe/infNFe", "pag");
                    this.Criar_Dados_Tag_pag(row, xml);

                    xml.Criar_Elemento("/NFe/infNFe", "infAdic");
                    this.Criar_Dados_Tag_infAdic(row, xml);

                    ////////////////////////////////////////////////////////////////////////////////

                    //-- Salva arquivo em disco.
                    string sFileXML = "{0}{1}-nfe.xml";
                    sFileXML = string.Format(sFileXML
                        , sCaminhoArquivo
                        , row["Chave_Acesso"]);

                    //-- Salva o arquivo em disco.
                    xml.Salvar(sFileXML);
                    daNFe.Arquivo_XML = sFileXML;
                    daNFe.Estado_Emissor = row["Estado_Empresa"].ToString();
                    daNFe.Empresa = Convert.ToInt32(row["Empresa"]);
                }
            }
        }

        #endregion Gera Xml da NF-e

        #region Cria dados da identificação da ide

        private void Criar_Dados_Tag_ide(DataRow row_NF, CriarXML xml, CompSoft.NFe.Dados_Arquivo_NFe daNFe)
        {
            CompSoft.compFrameWork.Funcoes func;
            daNFe.Ambiente = (CompSoft.NFe.Ambientes)Convert.ToInt32(func.Busca_Propriedade("Ambiente_NFe"));

            string sElemento_Pai = "/NFe/infNFe/ide";
            xml.Criar_Campo(sElemento_Pai, "cUF", row_NF["Cod_Estado_IBGE_Empresa"]);
            xml.Criar_Campo(sElemento_Pai, "cNF", row_NF["Nota_Fiscal"].ToString().PadLeft(8, '0'));
            xml.Criar_Campo(sElemento_Pai, "natOp", row_NF["desc_cfop"].ToString(), 60);
            //xml.Criar_Campo(sElemento_Pai, "indPag", (ds.Tables["Notas_Fiscais_Duplicatas"].Rows.Count <= 1 ? "0" : "1"));  //-- INDICA SE É PAGAMENTO A VISTA(0) OU A PRAZO(1) OU OUTROS(2)
            xml.Criar_Campo(sElemento_Pai, "mod", "55"); //-- Modelo de documento.
            xml.Criar_Campo(sElemento_Pai, "serie", row_NF["serie_nota"]);
            xml.Criar_Campo(sElemento_Pai, "nNF", row_NF["numero_nota"]);
            xml.Criar_Campo(sElemento_Pai, "dhEmi", Convert.ToDateTime(row_NF["data_emissao"]).AddTicks(DateTime.Now.TimeOfDay.Ticks).ToString_ToXML());
            xml.Criar_Campo(sElemento_Pai, "dhSaiEnt", Convert.ToDateTime(row_NF["data_entrega"]).AddTicks(DateTime.Now.TimeOfDay.Ticks).ToString_ToXML());

            xml.Criar_Campo(sElemento_Pai, "tpNF", row_NF["Tipo_Documento_Fiscal"]);
            xml.Criar_Campo(sElemento_Pai, "idDest", (row_NF["Estado_Correspondencia"].Equals(row_NF["Estado_Empresa"]) ? "1" : "2"));
            xml.Criar_Campo(sElemento_Pai, "cMunFG", row_NF["Cod_Cidade_IBGE_Empresa"].ToString().PadLeft(7, '0'));
            xml.Criar_Campo(sElemento_Pai, "tpImp", "1");
            xml.Criar_Campo(sElemento_Pai, "tpEmis", Convert.ToInt32(daNFe.Forma_Emissao));
            xml.Criar_Campo(sElemento_Pai, "cDV", row_NF["Chave_Acesso_Digito"]);
            xml.Criar_Campo(sElemento_Pai, "tpAmb", func.Busca_Propriedade("Ambiente_NFe")); //-- TIPO DE AMBIENTE PRODUçãO(1) OU HOMOLOGAçãO(2)
            xml.Criar_Campo(sElemento_Pai, "finNFe", "1");
            xml.Criar_Campo(sElemento_Pai, "indFinal", row_NF["consumidor_final"].Equals(true) ? "1" : "0");

            if (row_NF["Chave_Acesso_Referencia"] != DBNull.Value)
            {
                xml.Criar_Campo(sElemento_Pai, "indPres", "0"); //-- PARA NF COMPLEMENTAR
            }
            else
            {
                xml.Criar_Campo(sElemento_Pai, "indPres", "9");
            }
            xml.Criar_Campo(sElemento_Pai, "procEmi", "0");
            xml.Criar_Campo(sElemento_Pai, "verProc", "COMPSOFT " + System.Windows.Forms.Application.ProductVersion, 20);

            if (row_NF["Chave_Acesso_Referencia"] != DBNull.Value)
            {
                //-- Cria o elemento. 'NFref'
                xml.Criar_Elemento("/NFe/infNFe/ide", "NFref");
                this.Criar_Dados_Tag_NFref(row_NF, xml, daNFe);
            }
        }

        #endregion Cria dados da identificação da ide

        #region Cria dados da identificação da NFref

        private void Criar_Dados_Tag_NFref(DataRow row_NF, CriarXML xml, CompSoft.NFe.Dados_Arquivo_NFe daNFe)
        {
            string sElemento_Pai = "/NFe/infNFe/ide/NFref";
            xml.Criar_Campo(sElemento_Pai, "refNFe", row_NF["Chave_Acesso_Referencia"].ToString());

            ////-- DADOS DA REFERENCIA
            //xml.Criar_Elemento(sElemento_Pai, "refNF");
            //sElemento_Pai = "/NFe/infNFe/ide/NFref/refNF";

            //xml.Criar_Campo(sElemento_Pai, "cUF", row_NF["Cod_Estado_IBGE_Empresa"]);
            //xml.Criar_Campo(sElemento_Pai, "AAMM", Convert.ToDateTime(row_NF["Data_Emissao_Referencia"]).ToString("yyMM"));
            //xml.Criar_Campo(sElemento_Pai, "CNPJ", row_NF["CNPJ_Empresa"]);
            //xml.Criar_Campo(sElemento_Pai, "mod", "01");
            //xml.Criar_Campo(sElemento_Pai, "serie", row_NF["serie_nota"]);
            //xml.Criar_Campo(sElemento_Pai, "nNF", row_NF["numero_nota"]);
        }

        #endregion Cria dados da identificação da NFref

        #region Cria dados do emissor da NF-e

        private void Criar_Dados_Tag_emit(DataRow row_NF, CriarXML xml)
        {
            string sElemento_Pai = "/NFe/infNFe/emit";
            xml.Criar_Campo(sElemento_Pai, "CNPJ", row_NF["CNPJ_Empresa"]);
            xml.Criar_Campo(sElemento_Pai, "xNome", row_NF["Razao_Social_Empresa"].ToString().Replace(".", ""));
            xml.Criar_Campo(sElemento_Pai, "xFant", row_NF["Nome_Fantasia_Empresa"].ToString().Replace(".", ""));

            //-- Cria o endereço da empresa
            string sElemento_Endereco = "/NFe/infNFe/emit/enderEmit";
            xml.Criar_Elemento(sElemento_Pai, "enderEmit");
            xml.Criar_Campo(sElemento_Endereco, "xLgr", row_NF["Endereco_Empresa"]);
            xml.Criar_Campo(sElemento_Endereco, "nro", row_NF["Numero_Empresa"]);

            if (row_NF["Complemento_Empresa"] != DBNull.Value && !string.IsNullOrEmpty(row_NF["Complemento_Empresa"].ToString()))
                xml.Criar_Campo(sElemento_Endereco, "xCpl", row_NF["Complemento_Empresa"]);

            xml.Criar_Campo(sElemento_Endereco, "xBairro", row_NF["Bairro_empresa"]);
            xml.Criar_Campo(sElemento_Endereco, "cMun", row_NF["Cod_Cidade_IBGE_Empresa"]);
            xml.Criar_Campo(sElemento_Endereco, "xMun", row_NF["Cidade_Empresa"]);
            xml.Criar_Campo(sElemento_Endereco, "UF", row_NF["Estado_Empresa"]);
            xml.Criar_Campo(sElemento_Endereco, "CEP", row_NF["CEP_Empresa"]);
            xml.Criar_Campo(sElemento_Endereco, "cPais", row_NF["Cod_Pais_IBGE_Empresa"]);
            xml.Criar_Campo(sElemento_Endereco, "xPais", row_NF["Nome_Pais_empresa"]);
            xml.Criar_Campo(sElemento_Endereco, "fone", row_NF["Fone_Comercial_Empresa"]);
            //-- Fim do elemento do endereço

            xml.Criar_Campo(sElemento_Pai, "IE", row_NF["IE_empresa"]);
            xml.Criar_Campo(sElemento_Pai, "CRT", row_NF["Regime_Tributario"]);
        }

        #endregion Cria dados do emissor da NF-e

        #region Cria dados do destinatário da NF-e

        private void Criar_Dados_Tag_dest(DataRow row_NF, CriarXML xml)
        {
            string sElemento_Pai = "/NFe/infNFe/dest";
            CompSoft.compFrameWork.Funcoes func;

            int iAmbiente_NFe = Convert.ToInt32(func.Busca_Propriedade("Ambiente_NFe"));

            //-- Se ambiente de homologação atribiu o CNPJ "99999999000191"
            if (iAmbiente_NFe == 2)
            {
                xml.Criar_Campo(sElemento_Pai, "CNPJ", "99999999000191");
                xml.Criar_Campo(sElemento_Pai, "xNome", "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL");
            }
            else
            {
                //-- Trata ambiente de produção normalmente.
                if ((bool)row_NF["pessoa_juridica"])
                    xml.Criar_Campo(sElemento_Pai, "CNPJ", row_NF["CNPJ_Cliente"]);
                else
                    xml.Criar_Campo(sElemento_Pai, "CPF", row_NF["CNPJ_Cliente"]);

                xml.Criar_Campo(sElemento_Pai, "xNome", row_NF["Razao_Social_Cliente"].ToString().Replace(".", ""));
            }

            //-- Cria o endereço da empresa
            string sElemento_Endereco = "/NFe/infNFe/dest/enderDest";
            xml.Criar_Elemento(sElemento_Pai, "enderDest");
            xml.Criar_Campo(sElemento_Endereco, "xLgr", row_NF["Endereco_Correspondencia"].ToString().Replace(".", "").Replace(",", ""));
            if (row_NF["Numero_Correspondencia"] == DBNull.Value)
                xml.Criar_Campo(sElemento_Endereco, "nro", "0");
            else
                xml.Criar_Campo(sElemento_Endereco, "nro", row_NF["Numero_Correspondencia"]);

            if (row_NF["Complemento_Correspondencia"] != DBNull.Value && !string.IsNullOrEmpty(row_NF["Complemento_Correspondencia"].ToString()))
                xml.Criar_Campo(sElemento_Endereco, "xCpl", row_NF["Complemento_Correspondencia"]);

            xml.Criar_Campo(sElemento_Endereco, "xBairro", row_NF["Bairro_Correspondencia"]);
            xml.Criar_Campo(sElemento_Endereco, "cMun", row_NF["cod_cidade_correspondencia_ibge"]);
            xml.Criar_Campo(sElemento_Endereco, "xMun", row_NF["Cidade_Correspondencia"]);
            xml.Criar_Campo(sElemento_Endereco, "UF", row_NF["Estado_Correspondencia"]);
            xml.Criar_Campo(sElemento_Endereco, "CEP", row_NF["CEP_Correspondencia"]);
            xml.Criar_Campo(sElemento_Endereco, "cPais", row_NF["cod_pais_correspondencia_IBGE"]);
            xml.Criar_Campo(sElemento_Endereco, "xPais", row_NF["Nome_Pais_correspondencia"]);
            xml.Criar_Campo(sElemento_Endereco, "fone", row_NF["Telefone_Cliente"]);
            //-- Fim do elemento do endereço

            if (iAmbiente_NFe == 2)
            {
                xml.Criar_Campo(sElemento_Pai, "indIEDest", "2");
            }
            else
            {
                if ((bool)row_NF["pessoa_juridica"])
                {
                    xml.Criar_Campo(sElemento_Pai, "indIEDest", "1");
                    xml.Criar_Campo(sElemento_Pai, "IE", row_NF["RG_IE_Cliente"].ToString().Replace(".", string.Empty).Replace("-", string.Empty));
                }
                else
                {
                    xml.Criar_Campo(sElemento_Pai, "indIEDest", "2");
                }
            }
        }

        #endregion Cria dados do destinatário da NF-e

        #region Cria dados dos produtos da NF-e

        private void Criar_Dados_Tag_det(DataRow row_NF, DataRow row_INF, CriarXML xml)
        {
            string sElemento_Pai = string.Format("/NFe/infNFe/det[@nItem='{0}']", row_INF["CountItem"]);

            //-- Cria elemento filho 'prod'
            string sElemento_Prod = sElemento_Pai + "/prod";
            xml.Criar_Elemento(sElemento_Pai, "prod");

            //-- Inclui campos do prod.
            xml.Criar_Campo(sElemento_Prod, "cProd", row_INF["produto"]);

            if (row_INF["EAN"] != null && !string.IsNullOrEmpty(row_INF["EAN"].ToString()))
                xml.Criar_Campo(sElemento_Prod, "cEAN", row_INF["EAN"]);
            else
                xml.Criar_Campo(sElemento_Prod, "cEAN", DBNull.Value);

            xml.Criar_Campo(sElemento_Prod, "xProd", row_INF["desc_produto"].ToString(), 120);
            xml.Criar_Campo(sElemento_Prod, "NCM", row_INF["Cod_Classificacao_Fiscal"].ToString(), 120);

            //if (row_INF["Valor_Substituicao_Tributaria"] != DBNull.Value && Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"]) > 0)
            //{
            xml.Criar_Campo(sElemento_Prod, "CEST", "2004600");
            //}
            //else
            //{
            //    xml.Criar_Campo(sElemento_Prod, "CEST", DBNull.Value);
            //}

            xml.Criar_Campo(sElemento_Prod, "CFOP", row_INF["CFOP"]);

            xml.Criar_Campo(sElemento_Prod, "uCom", row_INF["Desc_Unidade_Abrevidado"]);

            decimal dValor = Convert.ToDecimal(row_INF["Quantidade"]);
            xml.Criar_Campo(sElemento_Prod, "qCom", string.Format("{0:n4}", dValor).Replace(',', '.'));

            dValor = Convert.ToDecimal(row_INF["Valor_Unitario"]);
            xml.Criar_Campo(sElemento_Prod, "vUnCom", string.Format("{0:n4}", dValor).Replace(',', '.'));

            dValor = Convert.ToDecimal(row_INF["Valor_Total_Item"]);
            xml.Criar_Campo(sElemento_Prod, "vProd", string.Format("{0:n2}", dValor).Replace(',', '.'));

            if (row_INF["EAN"] != null && !string.IsNullOrEmpty(row_INF["EAN"].ToString()))
                xml.Criar_Campo(sElemento_Prod, "cEANTrib", row_INF["EAN"]);
            else
                xml.Criar_Campo(sElemento_Prod, "cEANTrib", DBNull.Value);

            xml.Criar_Campo(sElemento_Prod, "uTrib", row_INF["Desc_Unidade_Abrevidado"]);

            dValor = Convert.ToDecimal(row_INF["Quantidade"]);
            xml.Criar_Campo(sElemento_Prod, "qTrib", string.Format("{0:n4}", dValor).Replace(',', '.'));

            dValor = Convert.ToDecimal(row_INF["Valor_Unitario"]);
            xml.Criar_Campo(sElemento_Prod, "vUnTrib", string.Format("{0:n4}", dValor).Replace(',', '.'));

            xml.Criar_Campo(sElemento_Prod, "indTot", "1");
            //-- fim dos campos Prod.

            ////////////////////////////////////////////////////////////////////////////

            //-- Cria elemento filho 'imposto'
            string sElemento_Imposto = sElemento_Pai + "/imposto";
            xml.Criar_Elemento(sElemento_Pai, "imposto");

            ////////////////////////////////////////////////////////////////////////////

            //-- Criar elemento neto 'ICMS'
            string sElemento_Imposto_ICMS = sElemento_Imposto + "/ICMS";
            xml.Criar_Elemento(sElemento_Imposto, "ICMS");

            string sElemento_ICMS_Regra = string.Empty;

            //-- Identifica a forma de retorno de dados para NF-e... ICMS ou CSOSN
            if (Convert.ToInt32(row_NF["Regime_Tributario"]) != 3 || Convert.ToBoolean(row_NF["Regime_Normal_RPA"]) && Convert.ToBoolean(row_NF["Calcular_Credito_ICMS_SN"]))
            {
                sElemento_ICMS_Regra = sElemento_Imposto_ICMS + "/ICMSSN";
                string sCSOSN = string.Empty;

                switch (row_INF["CSOSN"].ToString())
                {
                    case "102":
                    case "103":
                    case "300":
                    case "400":
                        sCSOSN = "102";
                        break;

                    case "202":
                    case "203":
                        sCSOSN = "202";
                        break;

                    default:
                        sCSOSN = row_INF["CSOSN"].ToString();
                        break;
                }

                sElemento_ICMS_Regra += sCSOSN;
                xml.Criar_Elemento(sElemento_Imposto_ICMS, "ICMSSN" + sCSOSN);
                this.Criar_Dados_Tag_CSOSN(sElemento_ICMS_Regra, row_INF, xml); //-- Identificação como CSOSN
            }
            else
            {
                int iSituacaoTributaria = Convert.ToInt32(row_INF["Tipo_Situacao_Tributaria"]);

                switch (iSituacaoTributaria)
                {
                    case 41:
                        iSituacaoTributaria = 40;
                        break;
                }

                //-- Criar informações sobre o ICMS de acordo com o tipo de situação tributária.
                xml.Criar_Elemento(sElemento_Imposto_ICMS, "ICMS" + iSituacaoTributaria.ToString().PadLeft(2, '0'));
                sElemento_ICMS_Regra = sElemento_Imposto_ICMS + "/ICMS" + iSituacaoTributaria.ToString().PadLeft(2, '0');
                this.Criar_Dados_Tag_ICMS(sElemento_ICMS_Regra, row_INF, xml); //-- Identificação como ICMS
            }

            //-- Fim da criação dos itens do ICMS
            //-- Fim dos ICMS

            ////////////////////////////////////////////////////////////////////////////

            string sElemento_Imposto_PIS = sElemento_Imposto + "/PIS";
            xml.Criar_Elemento(sElemento_Imposto, "PIS");

            //-- Criar informações sobre o PIS de acordo com o tipo de situação tributária.
            xml.Criar_Elemento(sElemento_Imposto_PIS, "PIS" + row_INF["Sufixo_Nfe_PIS"].ToString());
            string sElemento_PIS_Regra = sElemento_Imposto_PIS + "/PIS" + row_INF["Sufixo_Nfe_PIS"].ToString();
            this.Criar_Dados_Tag_PIS(sElemento_PIS_Regra, row_INF, xml);

            ////////////////////////////////////////////////////////////////////////////

            string sElemento_Imposto_COFINS = sElemento_Imposto + "/COFINS";
            xml.Criar_Elemento(sElemento_Imposto, "COFINS");

            //-- Criar informações sobre o COFINS de acordo com o tipo de situação tributária.
            xml.Criar_Elemento(sElemento_Imposto_COFINS, "COFINS" + row_INF["Sufixo_Nfe_PIS"].ToString());
            string sElemento_COFINS_Regra = sElemento_Imposto_COFINS + "/COFINS" + row_INF["Sufixo_Nfe_PIS"].ToString();
            this.Criar_Dados_Tag_COFINS(sElemento_COFINS_Regra, row_INF, xml);
        }

        #region TAG´s do CSOSN

        private void Criar_Dados_Tag_CSOSN(string sXPath_Elemento, DataRow row_INF, CriarXML xml)
        {
            xml.Criar_Campo(sXPath_Elemento, "orig", row_INF["Origem_Situacao_Tributaria"]);
            xml.Criar_Campo(sXPath_Elemento, "CSOSN", row_INF["CSOSN"]);

            switch (row_INF["CSOSN"].ToString())
            {
                case "101":
                    xml.Criar_Campo(sXPath_Elemento, "pCredSN", string.Format("{0:n2}", row_INF["Aliquota_Cred_SN"] == DBNull.Value ? 0 : Convert.ToDecimal(row_INF["Aliquota_Cred_SN"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vCredICMSSN", string.Format("{0:n2}", row_INF["Valor_Cred_SN"] == DBNull.Value ? 0 : Convert.ToDecimal(row_INF["Valor_Cred_SN"])).Replace(',', '.'));
                    break;

                case "201":
                    xml.Criar_Campo(sXPath_Elemento, "modBCST", row_INF["Modalidade_Calculo_ICMS_ST"]);

                    if (row_INF["Percentual_Adicionado_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pMVAST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Adicionado_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual adicionado ICMS ST

                    if (row_INF["Percentual_Reducao_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pRedBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Reducao_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual de redução ICMS ST

                    xml.Criar_Campo(sXPath_Elemento, "vBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Base_Substituicao_Tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["aliquota_substituicao_tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pCredSN", string.Format("{0:n2}", row_INF["Aliquota_Cred_SN"] == DBNull.Value ? 0 : Convert.ToDecimal(row_INF["Aliquota_Cred_SN"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vCredICMSSN", string.Format("{0:n2}", row_INF["Valor_Cred_SN"] == DBNull.Value ? 0 : Convert.ToDecimal(row_INF["Valor_Cred_SN"])).Replace(',', '.'));
                    break;

                case "202":
                case "203":
                    xml.Criar_Campo(sXPath_Elemento, "modBCST", row_INF["Modalidade_Calculo_ICMS_ST"]);

                    if (row_INF["Percentual_Adicionado_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pMVAST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Adicionado_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual adicionado ICMS ST

                    if (row_INF["Percentual_Reducao_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pRedBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Reducao_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual de redução ICMS ST

                    xml.Criar_Campo(sXPath_Elemento, "vBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Base_Substituicao_Tributaria"] == DBNull.Value ? 0 : row_INF["Valor_Base_Substituicao_Tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["aliquota_substituicao_tributaria"] == DBNull.Value ? 0 : row_INF["aliquota_substituicao_tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"] == DBNull.Value ? 0 : row_INF["Valor_Substituicao_Tributaria"])).Replace(',', '.'));
                    break;

                case "500":
                    xml.Criar_Campo(sXPath_Elemento, "vBCSTRet", string.Format("{0:n2}", Convert.ToDecimal("0")).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMSSTRet", string.Format("{0:n2}", Convert.ToDecimal("0")).Replace(',', '.'));

                    break;

                case "900":
                    xml.Criar_Campo(sXPath_Elemento, "modBCST", row_INF["Modalidade_Calculo_ICMS_ST"]);

                    if (row_INF["Percentual_Adicionado_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pMVAST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Adicionado_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual adicionado ICMS ST

                    if (row_INF["Percentual_Reducao_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pRedBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Reducao_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual de redução ICMS ST

                    xml.Criar_Campo(sXPath_Elemento, "vBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Base_Substituicao_Tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["aliquota_substituicao_tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"])));
                    xml.Criar_Campo(sXPath_Elemento, "pCredSN", string.Format("{0:n2}", row_INF["Aliquota_Cred_SN"] == DBNull.Value ? 0 : Convert.ToDecimal(row_INF["Aliquota_Cred_SN"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vCredICMSSN", string.Format("{0:n2}", row_INF["Valor_Cred_SN"] == DBNull.Value ? 0 : Convert.ToDecimal(row_INF["Valor_Cred_SN"])).Replace(',', '.'));

                    break;
            }
        }

        #endregion TAG´s do CSOSN

        #region TAG´s do ICMS

        private void Criar_Dados_Tag_ICMS(string sXPath_Elemento, DataRow row_INF, CriarXML xml)
        {
            xml.Criar_Campo(sXPath_Elemento, "orig", row_INF["Origem_Situacao_Tributaria"]);
            xml.Criar_Campo(sXPath_Elemento, "CST", row_INF["Tipo_Situacao_Tributaria"]);

            switch (Convert.ToInt32(row_INF["Tipo_Situacao_Tributaria"]))
            {
                case 0:
                    xml.Criar_Campo(sXPath_Elemento, "modBC", row_INF["Modalidade_Calculo_ICMS"]);
                    xml.Criar_Campo(sXPath_Elemento, "vBC", string.Format("{0:n2}", Convert.ToDecimal(row_INF["valor_base_icms"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMS", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Aliquota_ICMS"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMS", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_ICMS"])).Replace(',', '.'));
                    break;

                case 10:
                    xml.Criar_Campo(sXPath_Elemento, "modBC", row_INF["Modalidade_Calculo_ICMS"]);
                    xml.Criar_Campo(sXPath_Elemento, "vBC", string.Format("{0:n2}", row_INF["Valor_Base_ICMS"] == DBNull.Value ? 0 : Convert.ToDecimal(row_INF["Valor_Base_ICMS"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMS", string.Format("{0:n2}", row_INF["Aliquota_ICMS"] == DBNull.Value ? 0 : Convert.ToDecimal(row_INF["Aliquota_ICMS"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMS", string.Format("{0:n2}", row_INF["Valor_ICMS"] == DBNull.Value ? 0 : Convert.ToDecimal(row_INF["Valor_ICMS"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "modBCST", row_INF["Modalidade_Calculo_ICMS_ST"]);
                    if (row_INF["Percentual_Adicionado_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pMVAST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Adicionado_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual adicionado ICMS ST
                    if (row_INF["Percentual_Reducao_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pRedBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Reducao_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual de redução ICMS ST
                    xml.Criar_Campo(sXPath_Elemento, "vBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Base_Substituicao_Tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["aliquota_substituicao_tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"])).Replace(',', '.'));
                    break;

                case 20:
                    xml.Criar_Campo(sXPath_Elemento, "modBC", row_INF["Modalidade_Calculo_ICMS"]);
                    xml.Criar_Campo(sXPath_Elemento, "pRedBC", row_INF["Percentual_reducao_ICMS"]);
                    xml.Criar_Campo(sXPath_Elemento, "vBC", string.Format("{0:n2}", Convert.ToDecimal(row_INF["valor_base_icms"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMS", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Aliquota_ICMS"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMS", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_ICMS"])).Replace(',', '.'));
                    break;

                case 30:
                    xml.Criar_Campo(sXPath_Elemento, "modBCST", row_INF["Modalidade_Calculo_ICMS_ST"]);
                    if (row_INF["Percentual_Adicionado_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pMVAST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Adicionado_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual adicionado ICMS ST
                    if (row_INF["Percentual_Reducao_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pRedBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Reducao_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual de redução ICMS ST
                    xml.Criar_Campo(sXPath_Elemento, "vBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Base_Substituicao_Tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["aliquota_substituicao_tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"])).Replace(',', '.'));
                    break;

                case 40:
                    break;

                case 41:
                    break;

                case 50:
                    break;

                case 51:
                    break;

                case 60:
                    //if (row_INF["Valor_Base_Substituicao_Tributaria"] != DBNull.Value)
                    //    xml.Criar_Campo(sXPath_Elemento, "vBCSTRet", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Base_Substituicao_Tributaria"])));

                    //if (row_INF["Valor_Base_Substituicao_Tributaria"] != DBNull.Value)
                    //    xml.Criar_Campo(sXPath_Elemento, "pST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Aliquota_Substituicao_Tributaria"])));

                    //if (row_INF["Valor_Substituicao_Tributaria"] != DBNull.Value)
                    //    xml.Criar_Campo(sXPath_Elemento, "vICMSSTRet", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"])));

                    if (row_INF["Valor_Base_Substituicao_Tributaria"] == DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "vBCSTRet", string.Format("{0:n2}", 0).Replace(',', '.'));
                    else
                        xml.Criar_Campo(sXPath_Elemento, "vBCSTRet", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Base_Substituicao_Tributaria"])).Replace(',', '.'));

                    if (row_INF["Valor_Base_Substituicao_Tributaria"] == DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pST", string.Format("{0:n2}", 0).Replace(',', '.'));
                    else
                        xml.Criar_Campo(sXPath_Elemento, "pST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Aliquota_Substituicao_Tributaria"])).Replace(',', '.'));

                    xml.Criar_Campo(sXPath_Elemento, "vICMSSubstituto", string.Format("{0:n2}", 0).Replace(',', '.'));

                    if (row_INF["Valor_Substituicao_Tributaria"] == DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "vICMSSTRet", string.Format("{0:n2}", 0).Replace(',', '.'));
                    else
                        xml.Criar_Campo(sXPath_Elemento, "vICMSSTRet", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"])).Replace(',', '.'));
                    break;

                case 70:
                    xml.Criar_Campo(sXPath_Elemento, "pRedBC", "---");
                    xml.Criar_Campo(sXPath_Elemento, "vBC", string.Format("{0:n2}", Convert.ToDecimal(row_INF["valor_base_icms"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMS", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Aliquota_ICMS"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMS", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_ICMS"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "modBCST", row_INF["Modalidade_Calculo_ICMS_ST"]);
                    if (row_INF["Percentual_Adicionado_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pMVAST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Adicionado_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual adicionado ICMS ST
                    if (row_INF["Percentual_Reducao_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pRedBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Reducao_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual de redução ICMS ST
                    xml.Criar_Campo(sXPath_Elemento, "vBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Base_Substituicao_Tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["aliquota_substituicao_tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"])).Replace(',', '.'));
                    break;

                case 90:
                    xml.Criar_Campo(sXPath_Elemento, "vBC", string.Format("{0:n2}", Convert.ToDecimal(row_INF["valor_base_icms"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMS", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Aliquota_ICMS"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMS", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_ICMS"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "modBCST", row_INF["Modalidade_Calculo_ICMS_ST"]);
                    if (row_INF["Percentual_Adicionado_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pMVAST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Adicionado_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual adicionado ICMS ST
                    if (row_INF["Percentual_Reducao_Substituicao_Tributaria"] != DBNull.Value)
                        xml.Criar_Campo(sXPath_Elemento, "pRedBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Percentual_Reducao_Substituicao_Tributaria"])).Replace(',', '.')); //-- Percentual de redução ICMS ST
                    xml.Criar_Campo(sXPath_Elemento, "vBCST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Base_Substituicao_Tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "pICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["aliquota_substituicao_tributaria"])).Replace(',', '.'));
                    xml.Criar_Campo(sXPath_Elemento, "vICMSST", string.Format("{0:n2}", Convert.ToDecimal(row_INF["Valor_Substituicao_Tributaria"])).Replace(',', '.'));
                    break;
            }
        }

        #endregion TAG´s do ICMS

        #region TAG´s do PIS

        private void Criar_Dados_Tag_PIS(string sXPath_Elemento, DataRow row_INF, CriarXML xml)
        {
            decimal dValor = 0;
            xml.Criar_Campo(sXPath_Elemento, "CST", row_INF["Situacao_Tributaria_PIS"].ToString().PadLeft(2, '0'));

            if (row_INF["Valor_Base_PIS"] != DBNull.Value)
            {
                dValor = Convert.ToDecimal(row_INF["Valor_Base_PIS"]);
                xml.Criar_Campo(sXPath_Elemento, "vBC", string.Format("{0:n2}", dValor).Replace(',', '.'));
            }

            if (row_INF["Aliquota_PIS"] != DBNull.Value)
            {
                dValor = Convert.ToDecimal(row_INF["Aliquota_PIS"]);
                xml.Criar_Campo(sXPath_Elemento, "pPIS", string.Format("{0:n2}", dValor).Replace(',', '.'));
            }

            if (row_INF["Valor_PIS"] != DBNull.Value)
            {
                dValor = Convert.ToDecimal(row_INF["Valor_PIS"]);
                xml.Criar_Campo(sXPath_Elemento, "vPIS", string.Format("{0:n2}", dValor).Replace(',', '.'));
            }
        }

        #endregion TAG´s do PIS

        #region TAG´s do COFINS

        private void Criar_Dados_Tag_COFINS(string sXPath_Elemento, DataRow row_INF, CriarXML xml)
        {
            xml.Criar_Campo(sXPath_Elemento, "CST", row_INF["Situacao_Tributaria_COFINS"].ToString().PadLeft(2, '0'));
            decimal dValor = 0;

            if (row_INF["Valor_Base_COFINS"] != DBNull.Value)
            {
                dValor = Convert.ToDecimal(row_INF["Valor_Base_COFINS"]);
                xml.Criar_Campo(sXPath_Elemento, "vBC", string.Format("{0:n2}", dValor).Replace(',', '.'));
            }

            if (row_INF["Aliquota_COFINS"] != DBNull.Value)
            {
                dValor = Convert.ToDecimal(row_INF["Aliquota_COFINS"]);
                xml.Criar_Campo(sXPath_Elemento, "pCOFINS", string.Format("{0:n2}", dValor).Replace(',', '.'));
            }

            if (row_INF["Valor_COFINS"] != DBNull.Value)
            {
                dValor = Convert.ToDecimal(row_INF["Valor_COFINS"]);
                xml.Criar_Campo(sXPath_Elemento, "vCOFINS", string.Format("{0:n2}", dValor).Replace(',', '.'));
            }
        }

        #endregion TAG´s do COFINS

        #endregion Cria dados dos produtos da NF-e

        #region Cria dados do total da NF-e

        private void Criar_Dados_Tag_total(DataRow row_NF, DataTable dtNfItens, CriarXML xml)
        {
            string sElemento_Pai = "/NFe/infNFe/total";
            string sElemento_ICMSTotal = sElemento_Pai + "/ICMSTot";
            xml.Criar_Elemento(sElemento_Pai, "ICMSTot");

            //-- DERPEN E SITUACAO TRIBUTARIA = 101
            //bool ZerarBC_ICMS = false;
            //if (row_NF["empresa"].Equals(2) && dtNfItens.Compute("count(nota_fiscal_item)", "CSOSN = 101").Equals(0))
            //    ZerarBC_ICMS = true;

            if (row_NF["Valor_Base_ICMS"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vBC", Convert.ToDecimal(row_NF["Valor_Base_ICMS"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vBC", 0, 2);

            if (row_NF["Valor_ICMS"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vICMS", Convert.ToDecimal(row_NF["Valor_ICMS"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vICMS", 0, 2);

            xml.Criar_Campo(sElemento_ICMSTotal, "vICMSDeson", 0, 2);
            xml.Criar_Campo(sElemento_ICMSTotal, "vFCP", 0, 2);

            if (row_NF["Valor_Base_Substituicao_ICMS"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vBCST", Convert.ToDecimal(row_NF["Valor_Base_Substituicao_ICMS"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vBCST", 0, 2);

            if (row_NF["Valor_Substituicao_ICMS"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vST", Convert.ToDecimal(row_NF["Valor_Substituicao_ICMS"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vST", 0, 2);

            xml.Criar_Campo(sElemento_ICMSTotal, "vFCPST", 0, 2);
            xml.Criar_Campo(sElemento_ICMSTotal, "vFCPSTRet", 0, 2);

            if (row_NF["Valor_Total_Produtos"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vProd", Convert.ToDecimal(row_NF["Valor_Total_Produtos"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vProd", 0, 2);

            if (row_NF["Valor_Frete"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vFrete", Convert.ToDecimal(row_NF["Valor_Frete"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vFrete", 0, 2);

            if (row_NF["Valor_Seguro"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vSeg", Convert.ToDecimal(row_NF["Valor_Seguro"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vSeg", 0, 2);

            if (row_NF["Valor_Desconto"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vDesc", Convert.ToDecimal(row_NF["Valor_Desconto"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vDesc", 0, 2);

            xml.Criar_Campo(sElemento_ICMSTotal, "vII", 0, 2);

            if (row_NF["Valor_IPI"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vIPI", Convert.ToDecimal(row_NF["Valor_IPI"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vIPI", 0, 2);

            xml.Criar_Campo(sElemento_ICMSTotal, "vIPIDevol", 0, 2);

            if (row_NF["Valor_PIS"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vPIS", Convert.ToDecimal(row_NF["Valor_PIS"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vPIS", 0, 2);

            if (row_NF["Valor_COFINS"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vCOFINS", Convert.ToDecimal(row_NF["Valor_COFINS"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vCOFINS", 0, 2);

            if (row_NF["Outros_Valores"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vOutro", Convert.ToDecimal(row_NF["Outros_Valores"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vOutro", 0, 2);

            if (row_NF["Valor_Total_Nota"] != DBNull.Value)
                xml.Criar_Campo(sElemento_ICMSTotal, "vNF", Convert.ToDecimal(row_NF["Valor_Total_Nota"]), 2);
            else
                xml.Criar_Campo(sElemento_ICMSTotal, "vNF", 0, 2);
        }

        #endregion Cria dados do total da NF-e

        #region Cria dados da transportadora

        private void Criar_Dados_Tag_transp(DataRow row_NF, CriarXML xml)
        {
            string sElemento_Pai = "/NFe/infNFe/transp";
            xml.Criar_Campo(sElemento_Pai, "modFrete", row_NF["Tipo_Frete_NFe"]);

            //////////////////////////////////////////////////////////////////////

            string sElemento_Filho = sElemento_Pai + "/transporta";
            xml.Criar_Elemento(sElemento_Pai, "transporta");

            if (row_NF["CNPJ_Transportadora"].ToString().Length <= 11)
                xml.Criar_Campo(sElemento_Filho, "CPF", row_NF["CNPJ_Transportadora"]);
            else
                xml.Criar_Campo(sElemento_Filho, "CNPJ", row_NF["CNPJ_Transportadora"]);

            xml.Criar_Campo(sElemento_Filho, "xNome", row_NF["Razao_Social_Transportadora"].ToString().Replace(".", ""));

            if (row_NF["CNPJ_Transportadora"].ToString().Length > 11)
                xml.Criar_Campo(sElemento_Filho, "IE", row_NF["IE_Transportadora"]);

            if (row_NF["Endereco_Transportadora"] != DBNull.Value)
                xml.Criar_Campo(sElemento_Filho, "xEnder", row_NF["Endereco_Transportadora"]);

            if (row_NF["Cidade_Transportadora"] != DBNull.Value)
                xml.Criar_Campo(sElemento_Filho, "xMun", row_NF["Cidade_Transportadora"]);

            if (row_NF["Estado_Transportadora"] != DBNull.Value)
                xml.Criar_Campo(sElemento_Filho, "UF", row_NF["Estado_Transportadora"]);

            //////////////////////////////////////////////////////////////////////

            sElemento_Filho = sElemento_Pai + "/vol";
            xml.Criar_Elemento(sElemento_Pai, "vol");

            xml.Criar_Campo(sElemento_Filho, "qVol", row_NF["Quantidade_Itens"]);
            xml.Criar_Campo(sElemento_Filho, "esp", "CAIXAS/PACOTES");
            xml.Criar_Campo(sElemento_Filho, "pesoL", Convert.ToDecimal(row_NF["Peso_Liquido"]), 3);
            xml.Criar_Campo(sElemento_Filho, "pesoB", Convert.ToDecimal(row_NF["Peso_Bruto"]), 3);
        }

        #endregion Cria dados da transportadora

        #region Cria dados da cobrança

        private void Criar_Dados_Tag_cobr(DataRow row_NF, CriarXML xml)
        {
            string sElemento_Pai = "/NFe/infNFe/cobr";
            StringBuilder sb = new StringBuilder();

            sb.Append("<fat>");

            sb.Append("<nFat>");
            sb.Append("0001");
            sb.Append("</nFat>");

            sb.Append("<vOrig>");
            sb.Append(Convert.ToDecimal(row_NF["Valor_Total_Nota"]).ToString("n2").Replace(',', '.'));
            sb.Append("</vOrig>");

            sb.Append("<vDesc>");
            sb.Append(Convert.ToDecimal(0).ToString("n2").Replace(',', '.'));
            sb.Append("</vDesc>");

            sb.Append("<vLiq>");
            sb.Append(Convert.ToDecimal(row_NF["Valor_Total_Nota"]).ToString("n2").Replace(',', '.'));
            sb.Append("</vLiq>");

            sb.Append("</fat>");

            int iParcela = 1;
            foreach (DataRow row in ds.Tables["Notas_Fiscais_Duplicatas"].Select(string.Format("Nota_Fiscal = {0}", row_NF["Nota_Fiscal"])))
            {
                sb.Append("<dup>");

                sb.Append("<nDup>");
                sb.Append(iParcela.ToString("000"));
                sb.Append("</nDup>");

                sb.Append("<dVenc>");
                sb.Append(Convert.ToDateTime(row["Data_Vencimento"]).ToString("yyyy-MM-dd"));
                sb.Append("</dVenc>");

                sb.Append("<vDup>");
                sb.Append(Convert.ToDecimal(row["Valor_Duplicata"]).ToString("n2").Replace(',', '.'));
                sb.Append("</vDup>");

                sb.Append("</dup>");

                iParcela++;
            }

            xml.DocumentoXML.SelectNodes(sElemento_Pai)[0].InnerXml = sb.ToString();
        }

        #endregion Cria dados da cobrança

        #region Cria dados da pagamento

        private void Criar_Dados_Tag_pag(DataRow row_NF, CriarXML xml)
        {
            string sElemento_Pai = "/NFe/infNFe/pag";
            //////////////////////////////////////////////////////////////////////

            string sElemento_Filho = sElemento_Pai + "/detPag";
            xml.Criar_Elemento(sElemento_Pai, "detPag");

            xml.Criar_Campo(sElemento_Filho, "tPag", "15"); //-- 15=Boleto Bancário
            xml.Criar_Campo(sElemento_Filho, "vPag", Convert.ToDecimal(row_NF["Valor_Total_Nota"]), 2);
        }

        #endregion Cria dados da pagamento

        #region Cria Informações adicionais.

        private void Criar_Dados_Tag_infAdic(DataRow row_NF, CriarXML xml)
        {
            string sElemento_Pai = "/NFe/infNFe/infAdic";

            string sObs = "Pedido: " + row_NF["pedido"].ToString() + " " + row_NF["observacao"].ToString();

            //-- Captura as mensagens NF-e
            ERP.NFe.Mensagens_NFe mens_nfe = new Mensagens_NFe();
            IList<string> ilMensagens = mens_nfe.Captura_Mensagem(Convert.ToInt32(row_NF["Nota_Fiscal"]));
            foreach (string sMensagem in ilMensagens)
                sObs += " - " + sMensagem;

            xml.Criar_Campo(sElemento_Pai, "infCpl", sObs.Trim(), 5000);
        }

        #endregion Cria Informações adicionais.
    }
}