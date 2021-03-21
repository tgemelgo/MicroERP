using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.NFe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0070 : CompSoft.FormSet
    {
        #region Construtor

        public f0070()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("   notas_fiscais_lotes.*");
            sb.AppendLine(" , mrn.descricao as 'Descricao_NFp'");
            sb.AppendLine(" , mrnfe.descricao as 'Descricao_NFe'");
            sb.AppendLine(" from notas_fiscais_lotes");
            sb.AppendLine("  left outer join mensagens_retorno_nfp mrn on mrn.codigo_mensagem_retorno = notas_fiscais_lotes.codigo_mensagem_retorno_NFP");
            sb.AppendLine("  left outer join mensagens_retorno_nfe mrnfe on mrnfe.codigo_mensagem_retorno = notas_fiscais_lotes.codigo_mensagem_retorno_NFE");
            Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                    , "notas_fiscais_lotes"
                    , sb.ToString()
                    , "Nota_Fiscal_Lote"));

            //-------------------

            sb.Remove(0, sb.Length);
            sb.AppendLine("select ");
            sb.AppendLine("   notas_fiscais_lotes_mensagens.*");
            sb.AppendLine(" , mrn.descricao as 'Descricao_NFp'");
            sb.AppendLine(" , mrnfe.descricao as 'Descricao_NFe'");
            sb.AppendLine(" from notas_fiscais_lotes_mensagens");
            sb.AppendLine("  left outer join mensagens_retorno_nfp mrn on mrn.codigo_mensagem_retorno = notas_fiscais_lotes_mensagens.codigo_mensagem_retorno_nfp");
            sb.AppendLine("  left outer join mensagens_retorno_nfe mrnfe on mrnfe.codigo_mensagem_retorno = notas_fiscais_lotes_mensagens.codigo_mensagem_retorno_nfe");
            Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                    , "notas_fiscais_lotes_mensagens"
                    , sb.ToString()));

            //-------------------

            sb.Remove(0, sb.Length);
            sb.AppendLine("select notas_fiscais_lotes_itens.*, cl.razao_social, nf.Numero_nota, nf.Data_Emissao");
            sb.AppendLine(" from notas_fiscais_lotes_itens");
            sb.AppendLine("  inner join notas_fiscais nf on nf.nota_fiscal = notas_fiscais_lotes_itens.nota_fiscal");
            sb.AppendLine("     inner join clientes cl on cl.cliente = nf.cliente");
            Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                    , "Notas_Fiscais_Lotes_Itens"
                    , sb.ToString()));

            InitializeComponent();

#if (!DEBUG)
            this.cf_Button1.Visible = false;
#endif
            if (Name == "f0070")
            {
                cmdImprimirDANFE.Visible = false;
                cmdCancelarNFe.Visible = false;
                cmdBuscarStatusNFe.Visible = false;
                cmdEnviarArquivo.Visible = true;
                cmdCartaCorrecao.Visible = true;
            }
        }

        #endregion Construtor

        #region Identifica os tipos de campos e mostra em tela.

        private void Valida_Tipo_NF()
        {
            if (FormStatus == CompSoft.TipoFormStatus.Novo || FormStatus == CompSoft.TipoFormStatus.Modificando || FormStatus == CompSoft.TipoFormStatus.Pesquisar)
            {
                bool bNFe = Name == "f0070" ? false : true;
                if (bNFe)
                {
                    //-- NFe
                    cboAmbiente_Nfe.Visible = true;
                    cboCodMensagem_NFe.Visible = true;
                    txtMensagemRetorno_NFe.Visible = true;
                    cmdImprimirDANFE.Visible = true;
                    cmdBuscarStatusNFe.Visible = true;
                    cmdBuscarStatusNFe.Enabled = true;
                    cmdCancelarNFe.Visible = true;
                    cmdCancelarNFe.Enabled = true;
                    cmdCartaCorrecao.Visible = true;
                    cmdCartaCorrecao.Enabled = true;

                    if (cboCodMensagem_NFe.SelectedIndex > -1)
                    {
                        string sStatus_NFe = cboCodMensagem_NFe.SelectedValue.ToString();

                        //-- Verifica se é possivel imprimir o danfe.
                        switch (sStatus_NFe)
                        {
                            case "100":  //-- Autorizado o uso da NF-e
                                cmdImprimirDANFE.Enabled = true;
                                cmdCancelarNFe.Enabled = true;
                                cmdCartaCorrecao.Enabled = true;
                                cmdBuscarStatusNFe.Enabled = true;
                                break;

                            case "135":  //-- Evento registrado e vinculado a NF-e
                                cmdImprimirDANFE.Enabled = false;
                                cmdCancelarNFe.Enabled = true;
                                cmdCartaCorrecao.Enabled = true;
                                cmdBuscarStatusNFe.Enabled = true;
                                break;

                            case "103": //-- Lote recebido com sucesso
                            case "104": //-- Lote processado
                            case "105": //-- Lote em processamento
                                cmdImprimirDANFE.Enabled = false;
                                cmdBuscarStatusNFe.Enabled = true;
                                cmdCancelarNFe.Enabled = false;
                                cmdCartaCorrecao.Enabled = false;
                                break;

                            default:
                                cmdImprimirDANFE.Enabled = false;
                                cmdCancelarNFe.Enabled = false;
                                cmdBuscarStatusNFe.Enabled = false;
                                cmdCartaCorrecao.Enabled = false;
                                break;
                        }
                    }

                    //-- NFp
                    cboCodMensagem_NFp.Visible = false;
                    txtMensagemRetorno_NFp.Visible = false;
                    cmdEnviarArquivo.Visible = false;

                    grdMensagens.Columns[2].DataPropertyName = "Codigo_mensagem_retorno_Nfe";
                    grdMensagens.Columns[3].DataPropertyName = "descricao_NFe";
                }
                else
                {
                    //-- NFe
                    cboAmbiente_Nfe.Visible = false;
                    cboCodMensagem_NFe.Visible = false;
                    txtMensagemRetorno_NFe.Visible = false;
                    cmdImprimirDANFE.Visible = false;
                    cmdBuscarStatusNFe.Visible = false;
                    cmdCancelarNFe.Visible = false;
                    cmdCartaCorrecao.Visible = false;

                    //-- NFp
                    cboCodMensagem_NFp.Visible = true;
                    txtMensagemRetorno_NFp.Visible = true;
                    cmdEnviarArquivo.Visible = true;

                    grdMensagens.Columns[2].DataPropertyName = "Codigo_mensagem_retorno_Nfp";
                    grdMensagens.Columns[3].DataPropertyName = "descricao_NFp";
                }
            }
            else
            {
                cmdBuscarStatusNFe.Enabled = false;
                cmdCancelarNFe.Enabled = false;
                cmdImprimirDANFE.Enabled = false;
                cmdEnviarArquivo.Enabled = false;
                cmdCartaCorrecao.Enabled = false;
            }
        }

        #endregion Identifica os tipos de campos e mostra em tela.

        #region Permite consulta

        private void Permite_Consulta()
        {
            bool bRetorno = false;

            if (FormStatus == CompSoft.TipoFormStatus.Pesquisar)
            {
                int iCodigo_Retorno = 0;

                //-- NF-p
                if (chkNFp.Checked && cboCodMensagem_NFp.SelectedIndex >= 0)
                {
                    iCodigo_Retorno = Convert.ToInt32(cboCodMensagem_NFp.SelectedValue);

                    //-- Verifica o protocolo não é vazio e o código de retorno é <> de 999 (erro não catalogado).
                    if (!string.IsNullOrEmpty(txtProtocolo.Text) && iCodigo_Retorno != 999)
                    {
                        if (!chkRetornoDados.Checked)
                            bRetorno = true;
                        else
                        {
                            switch (iCodigo_Retorno)
                            {
                                case 105:
                                    bRetorno = true;
                                    break;
                            }
                        }
                    }
                }

                //-- NF-e
                if (chkNFe.Checked && cboCodMensagem_NFe.SelectedIndex >= 0)
                {
                    iCodigo_Retorno = Convert.ToInt32(cboCodMensagem_NFe.SelectedValue);

                    //-- Verifica o protocolo não é vazio e o código de retorno é <> de 999 (erro não catalogado).
                    if (!string.IsNullOrEmpty(txtProtocolo.Text))
                    {
                        switch (iCodigo_Retorno)
                        {
                            case 103:
                            case 105:
                                bRetorno = true;
                                break;
                        }
                    }
                }
            }

            cmdAtualizarSecretaria.Enabled = bRetorno;
        }

        #endregion Permite consulta

        public override string user_Query(string TabelaAtual)
        {
            string sQuery = string.Empty;

            if (TabelaAtual.ToLower().Trim() == MainTabela.ToLower().Trim())
            {
                if (Name == "f0070")
                    sQuery = "notas_fiscais_lotes.Tipo_NFp = 1";

                if (Name == "f0073")
                    sQuery = "notas_fiscais_lotes.Tipo_NFe = 1";
            }

            return sQuery;
        }

        private void f0070_user_AfterRefreshData()
        {
            grdMensagens.DataSource = DataSetLocal.Tables["notas_fiscais_lotes_mensagens"];
            grdNotasFiscais.DataSource = DataSetLocal.Tables["Notas_Fiscais_Lotes_Itens"];

            grdMensagens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdNotasFiscais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Permite_Consulta();

            if (!string.IsNullOrEmpty(txtArquivo.Text) && System.IO.File.Exists(txtArquivo.Text))
                cmdEnviarArquivo.Enabled = true;

            txtArquivo.Enabled = true;
            txtArquivo.ReadOnly = true;

            Valida_Tipo_NF();

            cf_Button1.Enabled = true;
        }

        private void f0070_user_FormStatus_Change()
        {
            Permite_Consulta();
        }

        private void cmdAtualizarSecretaria_Click(object sender, EventArgs e)
        {
            if (chkNFp.Checked)
            {
                NFPaulista.NFP_TrataWS ws = new ERP.NFPaulista.NFP_TrataWS();

                IList<int> ilLote = new List<int>();
                ilLote.Add(Convert.ToInt32(txtLote.Text));
                ws.Buscar_Retorno_Lote(ilLote);
            }

            if (chkNFe.Checked)
            {
                //-- captura datarowview atual selecionado.
                DataRowView row = (DataRowView)BindingSource[MainTabela].Current;

                //-- Alimenta variaveis necessárias para trabalho.
                Dados_Arquivo_NFe daNFe = new Dados_Arquivo_NFe();
                daNFe.Carregar_Dados(Convert.ToInt32(row["nota_fiscal_lote"]));

                //-- Instancia WebService
                ERP.NFe.NFe nfe = new ERP.NFe.NFe();
                nfe.Resultado_Processamento_NFe(daNFe);
            }

            Atualizar_Query_Atual();
        }

        private void cmdEnviarArquivo_Click(object sender, EventArgs e)
        {
            CompSoft.Tools.frmWait f = new CompSoft.Tools.frmWait("Aguarde, enviando arquivo a Secretária da Fazenda.\r\nEste processo poderá demorar alguns minutos.", CompSoft.Tools.frmWait.Tipo_Imagem.Atencao);
            f.Show();

            ERP.NFPaulista.NFP_TrataWS nfp = new ERP.NFPaulista.NFP_TrataWS();

            System.IO.FileInfo fi = new System.IO.FileInfo(txtArquivo.Text);
            int iEmpresa = Convert.ToInt32(fi.Name.Substring(0, 3));

            IList<int> iLote = new List<int>();
            iLote.Add(Convert.ToInt32(txtLote.Text));
            nfp.Enviar_Arquivos(iEmpresa, iLote);

            Atualizar_Query_Atual();

            f.Close();
        }

        private void chkNFe_CheckedChanged(object sender, EventArgs e)
        {
            Valida_Tipo_NF();
        }

        private void chkNFp_CheckedChanged(object sender, EventArgs e)
        {
            Valida_Tipo_NF();
        }

        private void cf_Button1_Click(object sender, EventArgs e)
        {
            CompSoft.NFe.ValidadorXMLClass v = new ValidadorXMLClass();
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            //v.ValidarXML(fd.FileName, @"C:\Users\Tiago\Downloads\PL_008f\PL_008f\nfe_v3.10.xsd");
            v.ValidarXML(fd.FileName, @"C:\Users\tiago\Desktop\PL_009_V4_00_NT_2018_005_v1.20\enviNFe_v4.00.xsd");
            CompSoft.compFrameWork.MsgBox.Show(v.Retorno.ToString());
            CompSoft.compFrameWork.MsgBox.Show(v.RetornoString);
        }

        private void cmdImprimirDANFE_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboCodMensagem_NFe.SelectedValue) == 100)
            {
                foreach (DataRow row in DataSetLocal.Tables["Notas_Fiscais_Lotes_Itens"].Select())
                {
                    Dados_Arquivo_NFe daNFe = new Dados_Arquivo_NFe(Convert.ToInt32(row["Nota_Fiscal"]));
                    daNFe.Arquivo_XML = txtArquivo.Text;

                    ERP.NFe.Impressao_Danfe imp;
                    imp.Imprimir_Danfe(daNFe, true);
                }
            }
        }

        private void cmdBuscarStatusNFe_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)BindingSource[MainTabela].Current;
            IList<Dados_Arquivo_NFe> ilNotas = new List<Dados_Arquivo_NFe>();

            Dados_Arquivo_NFe daNFe = new Dados_Arquivo_NFe();
            daNFe.Carregar_Dados(Convert.ToInt32(row["Nota_Fiscal_Lote"]));

            ilNotas.Add(daNFe);

            ERP.NFe.NFe nfe = new ERP.NFe.NFe();
            nfe.Consultar_Situacao_NFe(ilNotas);

            Atualizar_Query_Atual();
        }

        private void cmdCancelarNFe_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)BindingSource[MainTabela].Current;
            IList<Dados_Arquivo_NFe> ilNotas = new List<Dados_Arquivo_NFe>();

            Dados_Arquivo_NFe daNFe = new Dados_Arquivo_NFe();
            daNFe.Carregar_Dados(Convert.ToInt32(row["Nota_Fiscal_Lote"]));

            ilNotas.Add(daNFe);

            ERP.NFe.NFe nfe = new ERP.NFe.NFe();
            nfe.Cancelar_NFe(ilNotas);

            Atualizar_Query_Atual();

            //-- Atualiza

            //-- Exclui o titulo a receber.
            Funcoes func;
            if (!string.IsNullOrEmpty(txtProtocoloCancelamento.Text) && Convert.ToBoolean(func.Busca_Propriedade("Gera_Consiliacao_Automatica")))
            {
                Financeiro.ConsiliacaoFinanceira cf = new Financeiro.ConsiliacaoFinanceira();
                cf.Excluir_ContaReceber(daNFe.Nota_Fiscal);
            }
        }

        private void cmdCartaCorrecao_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)BindingSource[MainTabela].Current;
            IList<Dados_Arquivo_NFe> ilNotas = new List<Dados_Arquivo_NFe>();

            Dados_Arquivo_NFe daNFe = new Dados_Arquivo_NFe();
            daNFe.Carregar_Dados(Convert.ToInt32(row["Nota_Fiscal_Lote"]));

            ilNotas.Add(daNFe);

            ERP.NFe.NFe nfe = new ERP.NFe.NFe();
            nfe.CartaCorrecao_NFe(ilNotas);

            Atualizar_Query_Atual();

            //-- Atualiza

            //-- Exclui o titulo a receber.
            Funcoes func;
            if (!string.IsNullOrEmpty(txtProtocoloCancelamento.Text) && Convert.ToBoolean(func.Busca_Propriedade("Gera_Consiliacao_Automatica")))
            {
                Financeiro.ConsiliacaoFinanceira cf = new Financeiro.ConsiliacaoFinanceira();
                cf.Excluir_ContaReceber(daNFe.Nota_Fiscal);
            }
        }
    }
}