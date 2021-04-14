using CompSoft;
using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0032 : CompSoft.FormSet
    {
        #region Construtor

        public f0032()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("    class.*");
            sb.AppendLine("  , p.Unidade_Medida");
            sb.AppendLine("  , um.Desc_Unidade");
            sb.AppendLine("  , p.Classificacao_Fiscal");
            sb.AppendLine("  , cf.Cod_classificacao_fiscal");
            sb.AppendLine("  , p.Comissionado");
            sb.AppendLine("  , p.Porcentagem_Comissao");
            sb.AppendLine("  , p.Valor_Unitario");
            sb.AppendLine("  , p.Valor_Custo_Unitario");
            sb.AppendLine("  , p.Valor_Venda");
            sb.AppendLine("  , p.Peso_Bruto");
            sb.AppendLine("  , p.Peso_Liquido");
            sb.AppendLine("  , p.Qtde_Caixa");
            sb.AppendLine("  , p.Qtde_Por_Caixa");
            sb.AppendLine("  , p.Imagem");
            sb.AppendLine("  , p.Origem_Produto");
            sb.AppendLine("  , p.EAN");
            sb.AppendLine("  , p.CEST");
            sb.AppendLine(" from produtos p");
            sb.AppendLine("  inner join unidades_medidas um on um.unidade_medida = p.unidade_medida");
            sb.AppendLine("  inner join classificacoes_fiscais cf on cf.classificacao_fiscal = p.classificacao_fiscal");
            sb.AppendLine("  inner join vw_Class_Produto class on class.produto = p.produto");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Produtos"
                , sb.ToString()
                , "Produto"));

            sb.Remove(0, sb.Length);
            sb.AppendLine("select ");
            sb.AppendLine("   produtos_tributos.*");
            sb.AppendLine(" , e.Nome_Fantasia");
            sb.AppendLine(" , mc.Descricao_Modalidade as 'Descricao_Modalide_ICMS'");
            sb.AppendLine(" , mc_st.Descricao_Mod_ST as 'Descricao_Modalide_ICMS_ST'");
            sb.AppendLine(" , st_pis.Descricao_SitTrib_PIS");
            sb.AppendLine(" , st_cofins.Descricao_SitTrib_COFINS");
            sb.AppendLine(" from produtos_tributos");
            sb.AppendLine("  inner join empresas e on e.empresa = produtos_tributos.empresa");
            sb.AppendLine("  left outer join Modalidades_Calculo_ICMS mc on mc.Modalidade_Calculo_ICMS = produtos_tributos.Modalidade_Calculo_ICMS");
            sb.AppendLine("  left outer join Modalidades_Calculo_ICMS_ST mc_st on mc_st.Modalidade_Calculo_ICMS_ST = produtos_tributos.Modalidade_Calculo_ICMS_ST");
            sb.AppendLine("  left outer join situacoes_tributaria_pis st_pis on st_pis.situacao_tributaria_pis = produtos_tributos.Situacao_Tributaria_pis");
            sb.AppendLine("  left outer join situacoes_tributaria_cofins st_cofins on st_cofins.situacao_tributaria_cofins = produtos_tributos.Situacao_Tributaria_cofins");
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "Produtos_Tributos"
                , sb.ToString()));

            InitializeComponent();
        }

        #endregion Construtor

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.FormStatus == TipoFormStatus.Modificando || this.FormStatus == TipoFormStatus.Novo) && this.cboCategoria.SelectedValue != null)
            {
                int iSubGrp_Produto = Convert.ToInt32(((DataRowView)this.cboCategoria.SelectedItem)["SubGrupo_Produto"]);
                this.cboSubGrupo.SelectedValue = iSubGrp_Produto;
            }
        }

        private void cboEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            /*if (this.cboEmpresa != null && this.cboEmpresa.Items.Count > 0 && this.cboEmpresa.SelectedItem != null)
            {
                if (this.FormStatus == TipoFormStatus.Modificando || this.FormStatus == TipoFormStatus.Novo)
                {
                    this.cboSituacaoTributaria.Enabled = false;
                    this.cboCSOSN.Enabled = false;

                    if (((DataRowView)this.cboEmpresa.SelectedItem)["regime_tributario"].ToString() == "1")
                    {
                        this.cboCSOSN.Enabled = true;
                        this.cboSituacaoTributaria.SelectedValue = DBNull.Value;
                    }
                    else
                    {
                        this.cboSituacaoTributaria.Enabled = true;
                        this.cboCSOSN.SelectedValue = DBNull.Value;
                    }
                }
            }*/
        }

        private void cboSubGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.FormStatus == CompSoft.TipoFormStatus.Modificando || this.FormStatus == CompSoft.TipoFormStatus.Novo) && this.cboSubGrupo.SelectedValue != null)
            {
                int iGrp_Produto = Convert.ToInt32(((DataRowView)this.cboSubGrupo.SelectedItem)["Grupo_Produto"]);
                this.cboGrupoProduto.SelectedValue = iGrp_Produto;
            }
        }

        private void chkAtivarQtdePorCaixa_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAtivarQtdePorCaixa.Checked)
            {
                this.txtQtdeCaixa.Enabled = true;
            }
            else
            {
                this.txtQtdeCaixa.Enabled = false;
                this.txtQtdeCaixa.Text = string.Empty;
            }
        }

        private void chkICMSEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Modificando || this.FormStatus == CompSoft.TipoFormStatus.Novo)
            {
                this.txtICMS.Enabled = !this.chkICMSEstado.Checked;
                if (string.IsNullOrEmpty(this.txtICMS.Text))
                    this.txtICMS.Text = "0";
            }
        }

        private void chkProdutoComissionado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == TipoFormStatus.Novo || this.FormStatus == TipoFormStatus.Modificando)
            {
                this.txtPorcentagemComissao.Enabled = this.chkProdutoComissionado.Checked;
                if (!this.chkProdutoComissionado.Checked)
                    this.txtPorcentagemComissao.Text = string.Empty;
            }
        }

        private void chkReducaoICMS_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == TipoFormStatus.Novo || this.FormStatus == TipoFormStatus.Modificando)
            {
                if (!this.chkReducaoICMS.Checked)
                {
                    this.optReducaoGeral.Checked = false;
                    this.optReducaoCliente.Checked = false;
                }

                this.optReducaoCliente.Enabled = this.chkReducaoICMS.Checked;
                this.optReducaoGeral.Enabled = this.chkReducaoICMS.Checked;
                this.txtPorcentagemReducao.Enabled = this.chkReducaoICMS.Checked;
            }
        }

        private void chkReducaoST_CheckedChanged(object sender, EventArgs e)
        {
            this.txtAliquotaReducaoST.Enabled = this.chkReducaoST.Checked;
            if (!this.chkReducaoST.Checked)
                this.txtAliquotaReducaoST.Text = string.Empty;
        }

        private void chkSubstituicaoTributaria_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.FormStatus == TipoFormStatus.Modificando || this.FormStatus == TipoFormStatus.Novo) && this.cboCategoria.SelectedValue != null)
            {
                this.txtPorcentSubsTrib.Enabled = this.chkSubstituicaoTributaria.Checked;
                this.cboModalidadeICMS_ST.Enabled = this.chkSubstituicaoTributaria.Checked;
                this.chkReducaoST.Enabled = this.chkSubstituicaoTributaria.Checked;

                this.cboModalidadeICMS_ST.SelectedIndex = -1;
                this.txtPorcentSubsTrib.Text = string.Empty;
                this.chkReducaoST.Checked = false;
            }
        }

        private void cmdAbrirImagem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.AutoUpgradeEnabled = true;
                fd.CheckFileExists = true;
                fd.CheckPathExists = true;
                fd.Filter = "Todos os arquivos de imagem|*.jpg;*.bmp;*.png;*.gif|Arquivos Jpg|*.jpg|Arquivos Bmp|*.bmp|Arquivo Png|*.png|Arquivos Gif|*.gif";
                fd.Title = "Encontra imagem do produto";
                fd.ValidateNames = true;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    Image img = Bitmap.FromFile(fd.FileName);
                    CompSoft.Tools.TrataImagem ti = new TrataImagem(TrataImagem.Tipos_Redicionamento.Proporcional);
                    ti.Width = 240;
                    ti.Height = 240;
                    Image newImg = ti.Redimencionar(ref img);

                    this.picProduto.Image = newImg;

                    //-- Adiciona imagem no dataset.
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    newImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    this.CurrentRow["Imagem"] = ms.ToArray();

                    ms.Close();
                    newImg.Dispose();
                    img.Dispose();
                }
                else
                {
                    this.CurrentRow["Imagem"] = DBNull.Value;
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cmdFiltrar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (this.cboOrigemFiltro.SelectedIndex >= 0 && !string.IsNullOrEmpty(this.cboOrigemFiltro.SelectedValue.ToString()))
                sb.AppendFormat("Origem = '{0}'", this.cboOrigemFiltro.SelectedValue);

            if (this.cboDestinoFiltro.SelectedIndex >= 0 && !string.IsNullOrEmpty(this.cboDestinoFiltro.SelectedValue.ToString()))
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendFormat("Destino = '{0}'", this.cboDestinoFiltro.SelectedValue);
            }

            if (this.cboEmpresaFiltro.SelectedIndex >= 0)
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendFormat("empresa = {0}", this.cboEmpresaFiltro.SelectedValue);
            }

            grdTributos.Filtrar_Dados(sb.ToString());
        }

        private void cmdLimpar_Click(object sender, EventArgs e)
        {
            this.cboGrupoProduto.SelectedValue = DBNull.Value;
            this.cboSubGrupo.SelectedValue = DBNull.Value;
            this.cboCategoria.SelectedValue = DBNull.Value;
        }

        private void f0032_Load(object sender, EventArgs e)
        {
            this.acTritubos.Grid_Trabalho = this.grdTributos;
        }

        private void f0032_user_AfterRefreshData()
        {
            this.grdTributos.DataSource = this.DataSetLocal.Tables["Produtos_Tributos"];
            this.cboDestinoFiltro.SelectedIndex = -1;
            this.cboOrigemFiltro.SelectedIndex = -1;
            this.cboEmpresaFiltro.SelectedIndex = -1;

            try
            {
                if (this.DataSetLocal.Tables[this.MainTabela].Rows.Count > 0)
                {
                    DataRowView RowView = this.CurrentRow;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])RowView.Row["Imagem"]);

                    this.picProduto.Image = Image.FromStream(ms);
                }
            }
            catch
            {
                this.picProduto.Image = null;
            }
        }

        private bool f0032_user_BeforeSave()
        {
            bool bContinuar = true;

            if (this.chkProdutoComissionado.Checked && string.IsNullOrEmpty(this.txtPorcentagemComissao.Text))
            {
                bContinuar = false;
                MsgBox.Show("Informe a porcentagem da comissão do produto."
                    , "Atenção"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }

            return bContinuar;
        }

        private void f0032_user_FormStatus_Change()
        {
            this.acTritubos.Status_Form = this.FormStatus;

            this.cboEmpresa_SelectedValueChanged(this, EventArgs.Empty);

            if (this.FormStatus == TipoFormStatus.Novo || this.FormStatus == TipoFormStatus.Modificando)
            {
                this.chkProdutoComissionado_CheckedChanged(this, new EventArgs());
                this.chkReducaoICMS_CheckedChanged(this, new EventArgs());
                this.chkSubstituicaoTributaria_CheckedChanged(this, new EventArgs());
                this.chkICMSEstado_CheckedChanged(this, new EventArgs());
                this.chkAtivarQtdePorCaixa_CheckedChanged(this, new EventArgs());
            }
            else
                this.cmdAbrirImagem.Enabled = false;

            //-- Trata o controle de filtro dos tributos
            if (this.FormStatus == TipoFormStatus.Pesquisar)
            {
                this.cboEmpresaFiltro.Enabled = true;
                this.cboOrigemFiltro.Enabled = true;
                this.cboDestinoFiltro.Enabled = true;
                this.cmdFiltrar.Enabled = true;
            }
            else
            {
                this.cboEmpresaFiltro.Enabled = false;
                this.cboOrigemFiltro.Enabled = false;
                this.cboDestinoFiltro.Enabled = false;
                this.cmdFiltrar.Enabled = false;
            }
        }
    }
}