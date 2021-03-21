using CompSoft;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class f0091 : FormSet
    {
        public f0091()
        {
            StringBuilder sb = new StringBuilder(700);
            sb.AppendLine(@"select
								  cl.cliente
								, v.nome_vendedor
								, cl.Razao_Social
								, cl.Cpf_CNPJ
								, cl.RG_IE
								, case when cl.Inadimplente = 1 then 'Sim' else 'Não' end as 'Inadimplente'
								, case when cl.Inativo = 1 then 'Sim' else 'Não' end as 'Inativo'
								, coalesce(convert(varchar, cl.ddd1), '') + coalesce(cl.fone1, '') as 'fone1'
								, coalesce(convert(varchar, cl.ddd2), '') + coalesce(cl.fone2, '') as 'fone2'
								, coalesce(convert(varchar, cl.ddd3), '') + coalesce(cl.fone3, '') as 'fone3'
								, cl.email
								, cl.Endereco_Correspondencia
								, cl.Numero_Correspondencia
								, cl.Complemento_Correspondencia
								, cl.Bairro_Correspondencia
								, cl.Cidade_Correspondencia
								, cl.Estado_Correspondencia
								, cl.CEP_Correspondencia
								, cl.Endereco_Entrega
								, cl.Numero_Entrega
								, cl.Complemento_Entrega
								, cl.Bairro_Entrega
								, cl.Cidade_Entrega
								, cl.Estado_Entrega
								, cl.CEP_Entrega
								, max(nf.Data_Emissao) as 'data_ultima_compra'
								, avg(nf.Valor_Total_Nota) as 'Valor_Media_Venda'
								, max(nf.Valor_Total_Nota) as 'Valor_Maior_Venda'
								from clientes cl
									left outer join vendedores v
										on
											v.vendedor = cl.vendedor
									left outer join notas_fiscais nf
										on
											nf.cliente = cl.cliente
								where
									isnull(nf.cancelada, 0) = 0
								group by
									  cl.cliente
									, cl.Razao_Social
									, cl.Cpf_CNPJ
									, cl.email
									, coalesce(convert(varchar, cl.ddd1), '') + coalesce(cl.fone1, '')
									, coalesce(convert(varchar, cl.ddd2), '') + coalesce(cl.fone2, '')
									, coalesce(convert(varchar, cl.ddd3), '') + coalesce(cl.fone3, '')
									, v.nome_vendedor
									, cl.Endereco_Correspondencia
									, cl.Numero_Correspondencia
									, cl.Complemento_Correspondencia
									, cl.Bairro_Correspondencia
									, cl.Cidade_Correspondencia
									, cl.Estado_Correspondencia
									, cl.CEP_Correspondencia
									, cl.Endereco_Entrega
									, cl.Numero_Entrega
									, cl.Complemento_Entrega
									, cl.Bairro_Entrega
									, cl.Cidade_Entrega
									, cl.Estado_Entrega
									, cl.CEP_Entrega
									, cl.RG_IE
									, case when cl.Inadimplente = 1 then 'Sim' else 'Não' end
									, case when cl.Inativo = 1 then 'Sim' else 'Não' end");

            this.Tabelas.Add(new CompSoft.Data.Controle_Tabelas(CompSoft.Data.Controle_Tabelas.TiposTabelas.Pai
                        , "Notas_Fiscais"
                        , sb.ToString()
                        , "cliente"));

            InitializeComponent();
        }

        public override string user_Query(string TabelaAtual)
        {
            StringBuilder sb = new StringBuilder();

            if (this.chkAtivar_Empresa.Checked && this.cboEmpresa.SelectedIndex >= 0)
            {
                sb.AppendFormat("nf.empresa = {0}", this.cboEmpresa.SelectedValue);
            }

            return sb.ToString();
        }

        private void f0071_user_AfterRefreshData()
        {
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cf_TextBox1.Text))
            {
                MessageBox.Show("Selecione o arquivo que será salvo na exportação para continuar.", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.PesquisarDados();

            try
            {
                using (StreamWriter sr = new StreamWriter(this.cf_TextBox1.Text, false, Encoding.UTF8))
                {
                    foreach (DataColumn col in this.DataSetLocal.Tables[0].Columns)
                    {
                        sr.Write(col.ColumnName);
                        sr.Write(';');
                    }

                    sr.WriteLine("");

                    foreach (DataRow row in this.DataSetLocal.Tables[0].Rows)
                    {
                        foreach (DataColumn col in this.DataSetLocal.Tables[0].Columns)
                        {
                            if (row[col.ColumnName] != DBNull.Value)
                            {
                                if (col.DataType == typeof(decimal))
                                {
                                    sr.Write(Convert.ToDecimal(row[col.ColumnName]).ToString("n2", System.Globalization.CultureInfo.GetCultureInfo("pt-br")));
                                }
                                else
                                {
                                    if (col.DataType == typeof(DateTime))
                                        sr.Write(Convert.ToDateTime(row[col.ColumnName]).ToString("dd/MM/yyyy"));
                                    else
                                        sr.Write(row[col.ColumnName].ToString());
                                }
                            }
                            sr.Write(';');
                        }
                        sr.WriteLine("");
                    }
                }

                MessageBox.Show("Arquivo gerado com sucesso", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Não foi possível salvar arquivo, verifique se ele não está aberto por outro programa.", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdDiretorio_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.cf_TextBox1.Text = this.saveFileDialog1.FileName;
            }
        }
    }
}