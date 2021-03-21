using CompSoft;
using CompSoft.compFrameWork;
using CompSoft.Data;
using CompSoft.Tools;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0001 : CompSoft.FormSet
    {
        public f0001()
        {
            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Pai
                , "Empresas"
                , "select * from empresas"));

            this.Tabelas.Add(new Controle_Tabelas(Controle_Tabelas.TiposTabelas.Filha
                , "Contas_Correntes"
                , "select * from Contas_Correntes"));

            InitializeComponent();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            //-- Abre o formúlario para fazer busca do cep.
            LocalizarCEP cep = new LocalizarCEP(true,
                this.txtEndereco.Text,
                this.txtNumero.Text,
                this.txtComplemento.Text,
                this.txtBairro.Text,
                this.cboCidade.Text,
                this.cboEstado.Text,
                this.txtCEP.Text);

            //-- Verifica qual foi o retorno e atualiza os campos.
            this.txtEndereco.Text = cep.Endereco;
            this.txtNumero.Text = cep.Numero;
            this.txtComplemento.Text = cep.Complemento;
            this.txtBairro.Text = cep.Bairro;
            this.cboEstado.Text = cep.Estado;
            this.cboCidade.Text = cep.Cidade;
            this.txtCEP.Text = cep.CEP;
        }

        private void txtCNPJ_Validating(object sender, CancelEventArgs e)
        {
            Funcoes func;
            if (!string.IsNullOrEmpty(txtCNPJ.Text) && !func.ValidarCnpj(txtCNPJ.Text))
            {
                MsgBox.Show("CNPJ inválido, confira e regidite o valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;
            }
        }

        private void frmCadastroFilial_Load(object sender, EventArgs e)
        {
            this.cmdSelCertificadoDigital.ImageAlign = ContentAlignment.MiddleCenter;

            Funcoes func;
            this.txtCNPJ.Mask = func.Busca_Propriedade("CNPJ_Masc");

            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo", typeof(System.Int32));
            dt.Columns.Add("Desc", typeof(System.String));

            DataRow newrow = dt.NewRow();
            newrow["codigo"] = 1;
            newrow["desc"] = "Contribuintes";
            dt.Rows.Add(newrow);

            newrow = dt.NewRow();
            newrow["codigo"] = 2;
            newrow["desc"] = "Contabilistas";
            dt.Rows.Add(newrow);

            newrow = dt.NewRow();
            newrow["codigo"] = 3;
            newrow["desc"] = "Consumidores";
            dt.Rows.Add(newrow);

            this.cboCategoriaUsuario.DataSource = dt;
            this.cboCategoriaUsuario.DisplayMember = "desc";
            this.cboCategoriaUsuario.ValueMember = "codigo";

            this.acContaCorrente.Grid_Trabalho = this.grdContasCorrentes;
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {
            if (this.foFile_Open.ShowDialog() == DialogResult.OK)
            {
                //-- Localiza e abre o arquivo em Steam
                FileStream fs = new FileStream(this.foFile_Open.FileName
                    , FileMode.OpenOrCreate
                    , FileAccess.Read);

                //-- Converte o arquivo para Binario.
                byte[] MyData = new byte[fs.Length];
                fs.Read(MyData, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                TrataImagem t = new TrataImagem(150, 110, TrataImagem.Tipos_Redicionamento.Proporcional);
                MemoryStream ms = new MemoryStream(MyData);
                Image img_Final = t.Redimencionar(Image.FromStream(ms));
                this.pictureBox1.Image = img_Final;
                img_Final.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                //-- Atualiza registro.
                DataRowView RowView = (DataRowView)this.BindingSource[this.MainTabela].Current;
                img_Final.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                RowView.Row["Logo"] = ms.ToArray();
            }
        }

        private void f0006_user_AfterRefreshData()
        {
            try
            {
                if (this.DataSetLocal.Tables[this.MainTabela].Rows.Count > 0)
                {
                    DataRowView RowView = (DataRowView)this.BindingSource[this.MainTabela].Current;
                    MemoryStream ms = new MemoryStream((byte[])RowView.Row["Logo"]);

                    this.pictureBox1.Image = Image.FromStream(ms);
                }
            }
            catch { }

            this.grdContasCorrentes.DataSource = this.DataSetLocal.Tables["Contas_Correntes"];
        }

        private void f0006_user_AfterClear()
        {
            this.pictureBox1.Image = null;
        }

        private void f0006_user_AfterNew()
        {
            this.pictureBox1.Image = null;
        }

        private void f0006_user_FormStatus_Change()
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Novo || this.FormStatus == CompSoft.TipoFormStatus.Modificando)
            {
                this.cmdLocalizar.Enabled = true;
                this.cf_CheckBox1_CheckedChanged(this, EventArgs.Empty);
                this.cmdSelCertificadoDigital.Enabled = true;
                this.cf_CheckBox1_CheckedChanged_1(this, EventArgs.Empty);
                this.chkXMLAtivarRecurso_CheckedChanged(this, EventArgs.Empty);
                this.cboCRT_SelectedValueChanged(this, EventArgs.Empty);
            }
            else
            {
                this.cmdLocalizar.Enabled = false;
                this.cmdSelCertificadoDigital.Enabled = false;
            }

            this.txtSenhaNFP.PasswordChar = '*';
            this.acContaCorrente.Status_Form = this.FormStatus;

            this.txtInfoCertificadoDigital.Enabled = false;
            this.txtSerialNumberCertificadoDigital.Enabled = false;
        }

        private void f0006_FormClosing(object sender, FormClosingEventArgs e)
        {
            ERP.Class.Carrega_Dados c = new ERP.Class.Carrega_Dados();
            c.Dados_Filial();
        }

        private void cboEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboEstado.SelectedIndex >= 0)
            {
                string sValor = string.Empty;

                //-- Guarda a informação do registro.
                if (this.BindingSource[this.MainTabela].Position >= 0)
                {
                    DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;
                    sValor = row["Cidade"].ToString();
                }

                //-- Seta valores.
                string sQuery = "select Nome_municipio, Nome_municipio as 'nom', codigo_ibge from municipios where estado = '{0}' order by nome_municipio";
                sQuery = string.Format(sQuery, this.cboEstado.SelectedValue.ToString());
                this.cboCidade.SQLStatement = sQuery;

                //-- Caso exista o valor o sistema mostrará no combo.
                if (!string.IsNullOrEmpty(sValor))
                    this.cboCidade.SelectedValue = sValor;
            }
            else
                this.cboCidade.DataSource = null;
        }

        private bool f0001_user_BeforeSave()
        {
            DataRowView row = (DataRowView)this.BindingSource[this.MainTabela].Current;

            row["cod_estado_ibge"] = ((DataRowView)this.cboEstado.SelectedItem)["codigo_ibge"];
            row["cod_cidade_ibge"] = ((DataRowView)this.cboCidade.SelectedItem)["codigo_ibge"];

            return true;
        }

        private void cf_CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Modificando || this.FormStatus == CompSoft.TipoFormStatus.Novo)
            {
                if (this.chkAtivarNFP.Checked)
                {
                    this.txtUsuarioNFP.Enabled = true;
                    this.txtSenhaNFP.Enabled = true;
                    this.cboCategoriaUsuario.Enabled = true;
                }
                else
                {
                    this.txtUsuarioNFP.Text = string.Empty;
                    this.txtSenhaNFP.Text = string.Empty;
                    this.cboCategoriaUsuario.SelectedIndex = -1;

                    this.txtUsuarioNFP.Enabled = false;
                    this.txtSenhaNFP.Enabled = false;
                    this.cboCategoriaUsuario.Enabled = false;
                }
            }
        }

        private void txtSenhaNFP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
                this.txtSenhaNFP.PasswordChar = '*';
            else
            {
                if (string.IsNullOrEmpty(this.txtSenhaNFP.Text) || this.txtSenhaNFP.Text.Length == 1)
                    this.txtSenhaNFP.PasswordChar = '\0';
            }
        }

        private void cmdSelCertificadoDigital_Click(object sender, EventArgs e)
        {
            CompSoft.NFe.Certificado certificado = new CompSoft.NFe.Certificado();
            try
            {
                X509Certificate2 cert = certificado.Buscar_Certificado_Digital();
                if (cert != null)
                {
                    this.txtSerialNumberCertificadoDigital.Text = cert.SerialNumber;
                    this.Captura_Info_Certificado(cert);
                }
            }
            catch
            {
                MsgBox.Show("Seleção do certificado digital foi cancelada pelo usuário."
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Captura informações do certificado digital.
        /// </summary>
        /// <param name="cert">Certificado Digital</param>
        private void Captura_Info_Certificado(X509Certificate2 cert)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Subject Name:");
                sb.AppendLine(cert.Subject);
                sb.AppendLine("");
                sb.Append("Data de efetivação: ");
                sb.Append(cert.GetEffectiveDateString());
                sb.Append("    Data da expiração: ");
                sb.AppendLine(cert.GetExpirationDateString());
                sb.Append("Agencia certificadora: ");
                sb.AppendLine(cert.IssuerName.Name);

                this.txtInfoCertificadoDigital.Text = sb.ToString();
            }
            catch
            {
                this.txtSerialNumberCertificadoDigital.Text = string.Empty;
                this.txtInfoCertificadoDigital.Text = string.Empty;
            }
        }

        private void cf_Pageframe1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 2)
            {
                if (!string.IsNullOrEmpty(this.txtSerialNumberCertificadoDigital.Text))
                {
                    CompSoft.NFe.Certificado certificado = new CompSoft.NFe.Certificado();
                    X509Certificate2 cert = certificado.Buscar_Certificado_Digital(this.txtSerialNumberCertificadoDigital.Text, X509FindType.FindBySerialNumber);
                    if (cert != null)
                        this.Captura_Info_Certificado(cert);
                }
                else
                {
                    this.txtInfoCertificadoDigital.Text = string.Empty;
                }
            }
        }

        private void txtSerialNumberCertificadoDigital_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSerialNumberCertificadoDigital.Text))
            {
                CompSoft.NFe.Certificado certificado = new CompSoft.NFe.Certificado();
                X509Certificate2 cert = certificado.Buscar_Certificado_Digital(this.txtSerialNumberCertificadoDigital.Text, X509FindType.FindBySerialNumber);
                if (cert != null)
                    this.Captura_Info_Certificado(cert);
            }
            else
            {
                this.txtInfoCertificadoDigital.Text = string.Empty;
            }
        }

        private void cf_CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.FormStatus == CompSoft.TipoFormStatus.Modificando || this.FormStatus == CompSoft.TipoFormStatus.Novo)
            {
                if (cf_CheckBox1.Checked)
                    this.cmdSelCertificadoDigital.Enabled = true;
                else
                {
                    this.txtSerialNumberCertificadoDigital.Text = string.Empty;
                    this.txtInfoCertificadoDigital.Text = string.Empty;
                    this.cmdSelCertificadoDigital.Enabled = false;
                }
            }
        }

        private void chkXMLAtivarRecurso_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == TipoFormStatus.Novo || this.FormStatus == TipoFormStatus.Modificando)
            {
                if (this.chkXMLAtivarRecurso.Checked)
                {
                    this.Change_Group("EMAIL", true);
                    this.txtXMLEmail.Obrigatorio = true;
                    this.txtXMLServidor.Obrigatorio = true;
                }
                else
                {
                    this.Change_Group("EMAIL", false);
                    this.txtXMLEmail.Text = string.Empty;
                    this.chkXMLRequerAutentica.Checked = false;
                    this.txtXMLSenha.Text = string.Empty;
                    this.txtXMLServidor.Text = string.Empty;
                    this.txtXMLUsuario.Text = string.Empty;
                    this.txtXMLMensagemNFe.Text = string.Empty;

                    this.txtXMLEmail.Obrigatorio = false;
                    this.txtXMLServidor.Obrigatorio = false;
                }
            }
        }

        private void chkXMLRequerAutentica_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkXMLRequerAutentica.Checked)
            {
                this.txtXMLSenha.Obrigatorio = true;
                this.txtXMLUsuario.Obrigatorio = true;
            }
            else
            {
                this.txtXMLSenha.Obrigatorio = false;
                this.txtXMLUsuario.Obrigatorio = false;
            }
        }

        private void cboCRT_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.FormStatus == TipoFormStatus.Novo || this.FormStatus == TipoFormStatus.Modificando)
            {
                if (this.cboCRT.SelectedIndex >= 0)
                {
                    //-- Verifica se é possivel calcular o crédito do ICMS do regime Simples Nacional
                    DataRowView row = (DataRowView)this.cboCRT.SelectedItem;
                    if (!Convert.ToBoolean(row["Calcular_Credito_ICMS"]))
                    {
                        this.txtAliquotaCredSimplesNacional.Enabled = false;
                        this.txtAliquotaCredSimplesNacional.Text = string.Empty;
                    }
                    else
                        this.txtAliquotaCredSimplesNacional.Enabled = true;
                }
                else
                {
                    this.txtAliquotaCredSimplesNacional.Enabled = false;
                }
            }
        }
    }
}