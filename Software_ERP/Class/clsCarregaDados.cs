using CompSoft.compFrameWork;
using System;
using System.Data;
using System.Drawing;

namespace ERP.Class
{
    internal struct Carrega_Dados
    {
        public void Dados_Filial()
        {
            Funcoes func;
            string sSQL = string.Empty,
                iCodFilial = func.Busca_Propriedade("Codigo_Filial");

            sSQL += "select ";
            sSQL += " Nome_Fantasia";
            sSQL += " , DDD_Comercial";
            sSQL += " , Telefone_Comercial";
            sSQL += " , DDD_Fax";
            sSQL += " , Telefone_Fax";
            sSQL += " , endereco";
            sSQL += " , numero";
            sSQL += " , complemento";
            sSQL += " , bairro";
            sSQL += " , cidade";
            sSQL += " , estado";
            sSQL += " , cep";
            sSQL += " , email";
            sSQL += " , home_page";
            sSQL += " , logo";
            sSQL += " from Empresas";
            sSQL += "    where Empresa = {0}";
            sSQL = string.Format(sSQL, iCodFilial);
            DataTable dt = CompSoft.Data.SQL.Select(sSQL, "x", false);

            foreach (DataRow row in dt.Select())
            {
                string sEndereco = string.Empty,
                    sInternet = string.Empty,
                    sTelefone = string.Empty;

                //-- Mostra endereço
                sEndereco += row["endereco"].ToString();
                sEndereco += ", " + row["numero"].ToString();
                sEndereco += " " + row["complemento"].ToString();
                sEndereco += " - " + row["bairro"].ToString();
                sEndereco += " - " + row["Cidade"].ToString();
                sEndereco += "/" + row["Estado"].ToString();
                if (row["CEP"] != DBNull.Value || row["CEP"] != null)
                    sEndereco += " CEP: " + string.Format("{0:#00000-000}", Convert.ToInt32(row["CEP"]));

                if (row["home_page"] != null && row["home_page"] != DBNull.Value)
                    sInternet += "Web Site: " + row["home_page"].ToString();

                if (row["Email"] != null && row["Email"] != DBNull.Value)
                {
                    if (!string.IsNullOrEmpty(sInternet))
                        sInternet += " | E-mail: " + row["Email"].ToString();
                    else
                        sInternet += "E-mail: " + row["Email"].ToString();
                }

                if (row["telefone_Comercial"] != null && !string.IsNullOrEmpty(row["telefone_Comercial"].ToString()))
                {
                    sTelefone += "Fone: (" + row["DDD_Comercial"].ToString();
                    sTelefone += ") " + string.Format("{0:#000-0000}", int.Parse(row["telefone_Comercial"].ToString()));
                }

                if (!string.IsNullOrEmpty(sTelefone))
                    sTelefone += " | ";

                if (row["telefone_fax"] != null && !string.IsNullOrEmpty(row["telefone_fax"].ToString()))
                {
                    sTelefone += "Fax: (" + row["DDD_Fax"].ToString();
                    sTelefone += ") " + string.Format("{0:#000-0000}", int.Parse(row["telefone_fax"].ToString()));
                }

                //-- Carrega logo da filial.
                if (row["Logo"] != DBNull.Value)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])row["Logo"]);
                    Propriedades.Imagem_Relatorio_Lado_Esquerdo = Image.FromStream(ms);
                }

                Propriedades.Relatorio_EnderecoEmpresa = sEndereco;
                Propriedades.Relatorio_InternetEmpresa = sInternet;
                Propriedades.Relatorio_NomeEmpresa = row["nome_Fantasia"].ToString();
                Propriedades.Relatorio_TelefoneEmpresa = sTelefone;
            }
        }
    }
}