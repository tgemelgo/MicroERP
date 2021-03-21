using CompSoft.compFrameWork;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CompSoft.compFrameWork
{
    public struct Funcoes
    {
        #region Validar CPF´s e CNPJ´s que são passados por parametro

        /// <summary>
        /// Função para validação de CPF de acordo com parametros passados.
        /// </summary>
        public bool ValidarCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf = string.Empty;
            string digito = string.Empty;
            int soma = 0;
            int resto = 0;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Função para validação CNPJ de acordo com parametros passados.
        /// </summary>
        public bool ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            int resto = 0;
            string digito = string.Empty;
            string tempCnpj = string.Empty;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        #endregion Validar CPF´s e CNPJ´s que são passados por parametro

        #region Valida email com expressão regular

        /// <summary>
        /// Valida se e-mail digitado é válido.
        /// </summary>
        /// <param name="sEmail">e-mail para validação</param>
        /// <returns>true/false indicando se e-mail é válido.</returns>
        public bool Validar_EMail(string sEmail)
        {
            bool bRetorno = false;

            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"^(([^<>()[\]\\.,;:\s@\""]+");
            sb.Append(@"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@");
            sb.Append(@"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}");
            sb.Append(@"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+");
            sb.Append(@"[a-zA-Z]{2,}))$");

            foreach (string mail in sEmail.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Regex rx = new Regex(sb.ToString());
                bRetorno = rx.IsMatch(mail);

                if (!bRetorno)
                    break;
            }
            return bRetorno;
        }

        #endregion Valida email com expressão regular

        #region Validas os campos do formulário e retorna se foi preenchido ou não

        /// <summary>
        /// Valida todos os campos do formulario.
        /// </summary>
        /// <param name="controle">Passa a coleção de controles do formulário</param>
        /// <returns>Retorna se os campos estão validos ou não (true/false)</returns>
        internal bool ValidarCampos(Control.ControlCollection controle)
        {
            Boolean bRetorno = true;

            foreach (Control ctrl in controle)
            {
                //-- Caso o controle possua mais controles internos.
                if (ctrl.Controls.Count > 0 && ctrl.GetType() != typeof(cf_Bases.cf_DateEdit))
                {
                    //-- Chama o mesmo método para obter os controles.
                    //-- Este processo utiliza recurcividade.
                    bool sTempRet = this.ValidarCampos(ctrl.Controls);
                    if (bRetorno && !sTempRet)
                        bRetorno = false;
                }
                else
                {
                    if (ctrl.GetType().GetInterface("IBaseControl_DB", true) != null)
                    {
                        Interfaces.IBaseControl_DB cc = ctrl as Interfaces.IBaseControl_DB;
                        if (!cc.ValidarCampos())
                        {
                            if (bRetorno)
                                bRetorno = false;
                        }
                    }
                }
            }
            return bRetorno;
        }

        #endregion Validas os campos do formulário e retorna se foi preenchido ou não

        #region Atualiza o status da barra de ferramentas do main

        /// <summary>
        /// Atualiza todos os estados da barra de ferramentos.
        /// </summary>
        internal void TratarStatus_BarraFerramentas(CompSoft.TipoFormStatus TpFormStatus, CompSoft.TipoForm TpForm)
        {
            if (Propriedades.FormMain != null)
            {
                //-- Atualiza os botões da barra de tarefas do main.
                switch (TpFormStatus)
                {
                    case CompSoft.TipoFormStatus.Nenhum:
                        Propriedades.FormMain.cmdToolPrimeiro.Enabled = false;
                        Propriedades.FormMain.cmdToolAnterior.Enabled = false;
                        Propriedades.FormMain.cmdToolProximo.Enabled = false;
                        Propriedades.FormMain.cmdToolUltimo.Enabled = false;
                        Propriedades.FormMain.cmdToolNovo.Enabled = false;
                        Propriedades.FormMain.cmdToolAlterar.Enabled = false;
                        Propriedades.FormMain.cmdToolExcluir.Enabled = false;
                        Propriedades.FormMain.cmdToolSalvar.Enabled = false;
                        Propriedades.FormMain.cmdToolPesquisar.Enabled = false;
                        Propriedades.FormMain.cmdToolLimpartela.Enabled = false;
                        Propriedades.FormMain.cmdToolCancelarAlteracoes.Enabled = false;
                        Propriedades.FormMain.cmdToolAtualizar.Enabled = false;
                        Propriedades.FormMain.cmdToolLookUp.Enabled = false;
                        Propriedades.FormMain.cmdToolImpressao.Enabled = false;
                        break;

                    case CompSoft.TipoFormStatus.Novo:
                        Propriedades.FormMain.cmdToolPrimeiro.Enabled = false;
                        Propriedades.FormMain.cmdToolAnterior.Enabled = false;
                        Propriedades.FormMain.cmdToolProximo.Enabled = false;
                        Propriedades.FormMain.cmdToolUltimo.Enabled = false;
                        Propriedades.FormMain.cmdToolNovo.Enabled = false;
                        Propriedades.FormMain.cmdToolAlterar.Enabled = false;
                        Propriedades.FormMain.cmdToolExcluir.Enabled = false;
                        Propriedades.FormMain.cmdToolSalvar.Enabled = true;
                        Propriedades.FormMain.cmdToolPesquisar.Enabled = false;
                        Propriedades.FormMain.cmdToolLimpartela.Enabled = true;
                        Propriedades.FormMain.cmdToolCancelarAlteracoes.Enabled = true;
                        Propriedades.FormMain.cmdToolAtualizar.Enabled = false;
                        Propriedades.FormMain.cmdToolLookUp.Enabled = false;
                        Propriedades.FormMain.cmdToolImpressao.Enabled = false;

                        break;

                    case CompSoft.TipoFormStatus.Limpar:
                        Propriedades.FormMain.cmdToolPrimeiro.Enabled = false;
                        Propriedades.FormMain.cmdToolAnterior.Enabled = false;
                        Propriedades.FormMain.cmdToolProximo.Enabled = false;
                        Propriedades.FormMain.cmdToolUltimo.Enabled = false;
                        Propriedades.FormMain.cmdToolLimpartela.Enabled = true;
                        Propriedades.FormMain.cmdToolPesquisar.Enabled = true;
                        Propriedades.FormMain.cmdToolAtualizar.Enabled = false;
                        Propriedades.FormMain.cmdToolLookUp.Enabled = false;
                        Propriedades.FormMain.cmdToolImpressao.Enabled = false;

                        if (TpForm == CompSoft.TipoForm.Geral)
                        {
                            Propriedades.FormMain.cmdToolNovo.Enabled = true;
                            Propriedades.FormMain.cmdToolAlterar.Enabled = false;
                            Propriedades.FormMain.cmdToolExcluir.Enabled = false;
                            Propriedades.FormMain.cmdToolSalvar.Enabled = false;
                            Propriedades.FormMain.cmdToolCancelarAlteracoes.Enabled = false;
                        }
                        else
                        {
                            Propriedades.FormMain.cmdToolNovo.Enabled = false;
                            Propriedades.FormMain.cmdToolAlterar.Enabled = false;
                            Propriedades.FormMain.cmdToolExcluir.Enabled = false;
                            Propriedades.FormMain.cmdToolSalvar.Enabled = false;
                            Propriedades.FormMain.cmdToolCancelarAlteracoes.Enabled = false;
                        }
                        break;

                    case CompSoft.TipoFormStatus.Pesquisar:
                        Propriedades.FormMain.cmdToolPrimeiro.Enabled = true;
                        Propriedades.FormMain.cmdToolAnterior.Enabled = true;
                        Propriedades.FormMain.cmdToolProximo.Enabled = true;
                        Propriedades.FormMain.cmdToolUltimo.Enabled = true;
                        Propriedades.FormMain.cmdToolPesquisar.Enabled = false;
                        Propriedades.FormMain.cmdToolLimpartela.Enabled = true;
                        Propriedades.FormMain.cmdToolAtualizar.Enabled = true;
                        Propriedades.FormMain.cmdToolLookUp.Enabled = true;
                        Propriedades.FormMain.cmdToolImpressao.Enabled = true;

                        if (TpForm == CompSoft.TipoForm.Geral)
                        {
                            Propriedades.FormMain.cmdToolNovo.Enabled = true;
                            Propriedades.FormMain.cmdToolAlterar.Enabled = true;
                            Propriedades.FormMain.cmdToolExcluir.Enabled = true;
                            Propriedades.FormMain.cmdToolSalvar.Enabled = false;
                            Propriedades.FormMain.cmdToolCancelarAlteracoes.Enabled = false;
                        }
                        else
                        {
                            Propriedades.FormMain.cmdToolNovo.Enabled = false;
                            Propriedades.FormMain.cmdToolAlterar.Enabled = false;
                            Propriedades.FormMain.cmdToolExcluir.Enabled = false;
                            Propriedades.FormMain.cmdToolSalvar.Enabled = false;
                            Propriedades.FormMain.cmdToolCancelarAlteracoes.Enabled = false;
                        }
                        break;

                    case CompSoft.TipoFormStatus.Modificando:
                        Propriedades.FormMain.cmdToolPrimeiro.Enabled = false;
                        Propriedades.FormMain.cmdToolAnterior.Enabled = false;
                        Propriedades.FormMain.cmdToolProximo.Enabled = false;
                        Propriedades.FormMain.cmdToolUltimo.Enabled = false;
                        Propriedades.FormMain.cmdToolNovo.Enabled = false;
                        Propriedades.FormMain.cmdToolAlterar.Enabled = false;
                        Propriedades.FormMain.cmdToolExcluir.Enabled = false;
                        Propriedades.FormMain.cmdToolSalvar.Enabled = true;
                        Propriedades.FormMain.cmdToolPesquisar.Enabled = false;
                        Propriedades.FormMain.cmdToolLimpartela.Enabled = false;
                        Propriedades.FormMain.cmdToolCancelarAlteracoes.Enabled = true;
                        Propriedades.FormMain.cmdToolAtualizar.Enabled = false;
                        Propriedades.FormMain.cmdToolLookUp.Enabled = false;
                        Propriedades.FormMain.cmdToolImpressao.Enabled = false;
                        break;
                }

                if (Propriedades.FormMain.ActiveMdiChild != null && this.Check_Extension(Propriedades.FormMain.ActiveMdiChild.GetType(), typeof(FormSet)))
                {
                    //-- Verifica se a barra de ferramentas sofrerá alterações.
                    FormSet f = ((FormSet)Propriedades.FormMain.ActiveMdiChild);
                    if (!f.Barra_Ferramentas_Novo_Registro)
                        Propriedades.FormMain.cmdToolNovo.Enabled = false;

                    if (!f.Barra_Ferramentas_Editar_Registro)
                        Propriedades.FormMain.cmdToolAlterar.Enabled = false;

                    if (!f.Barra_Ferramentas_Excluir_Registro)
                        Propriedades.FormMain.cmdToolExcluir.Enabled = false;

                    if (!f.Barra_Ferramentas_Limpar_Tela)
                        Propriedades.FormMain.cmdToolLimpartela.Enabled = false;

                    if (!f.Barra_Ferramentas_Pesquisar_Registro)
                        Propriedades.FormMain.cmdToolPesquisar.Enabled = false;

                    if (!f.Barra_Ferramentas_Relatorios)
                        Propriedades.FormMain.cmdToolImpressao.Enabled = false;
                }
            }
        }

        #endregion Atualiza o status da barra de ferramentas do main

        #region Busca todas as propriedades do sistema

        /// <summary>
        /// Busca valor de uma propriedade especifica.
        /// </summary>
        /// <param name="sNomeProperty">Nome da propriedade</param>
        /// <returns>string com o valor da propriedade</returns>
        public string Busca_Propriedade(string sNomeProperty)
        {
            string sRetorno = string.Empty;

            //-- Localiza a propriedade padrão
            DataRow[] fRow = Propriedades.Propriedades_Sist.Select(string.Format("Nome_Propriedade = '{0}'", sNomeProperty));

            //-- Verifica se encontrou alguma.
            switch (fRow.Length)
            {
                case 0:
                    CompSoft.compFrameWork.MsgBox.Show("A propriedade não foi encontrada, contate a CompSoft.\n" + sNomeProperty, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 1:
                    foreach (DataRow row in fRow)
                        sRetorno = row["Valor"].ToString();
                    break;

                case 2:
                    CompSoft.compFrameWork.MsgBox.Show("Foram encontradas muitas references para esta propriedade, contate a CompSoft.\n" + sNomeProperty, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }

            return sRetorno;
        }

        /// <summary>
        /// Atualiza a propriedade com o novo valor.
        /// </summary>
        /// <param name="sNomeProperty"></param>
        /// <param name="sNovoValor"></param>
        public void Atualizar_Propriedade(string sNomeProperty, string sNovoValor)
        {
            string sQuery = "select count(propriedade) from propriedades where nome_Propriedade = '{0}'";
            sQuery = string.Format(sQuery, sNomeProperty);
            int iExiste = Convert.ToInt32(CompSoft.Data.SQL.ExecuteScalar(sQuery, true));

            if (iExiste == 0) //-- atualiza registro existente.
            {
                sQuery = "insert propriedades values('', '{0}', '{1}')";
                sQuery = string.Format(sQuery, sNomeProperty, sNovoValor);
                CompSoft.Data.SQL.Execute(sQuery);
            }
            else //-- Inclui o novo registro.
            {
                sQuery = "update propriedades set valor = '{1}' where nome_propriedade = '{0}'";
                sQuery = string.Format(sQuery, sNomeProperty, sNovoValor);
                CompSoft.Data.SQL.Execute(sQuery);
            }
        }

        /// <summary>
        /// Atualiza propriedades com valores do banco de dados.
        /// </summary>
        public void AlimentaPropriedades_Sist()
        {
            string sSQL = "select * from Propriedades";

            Propriedades.Propriedades_Sist = Data.SQL.Select(sSQL, "Propriedades", false);
        }

        #endregion Busca todas as propriedades do sistema

        #region Calcula a diferença entre datas (DATEDIFF)

        public enum DateInterval
        {
            Second, Minute, Hour, Day, Week, Month, Quarter, Year
        }

        /// <summary>
        /// Calcula diferença entre datas
        /// </summary>
        /// <param name="Interval">Tipo de intervalo</param>
        /// <param name="StartDate">Data Inicial</param>
        /// <param name="EndDate">Data Final</param>
        /// <returns>Retorno de acordo com o valor selecionado</returns>
        public long DateDiff(DateInterval Interval, System.DateTime StartDate, System.DateTime EndDate)
        {
            long lngDateDiffValue = 0;
            System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);

            switch (Interval)
            {
                case DateInterval.Day:
                    lngDateDiffValue = (long)TS.Days;
                    break;

                case DateInterval.Hour:
                    lngDateDiffValue = (long)TS.TotalHours;
                    break;

                case DateInterval.Minute:
                    lngDateDiffValue = (long)TS.TotalMinutes;
                    break;

                case DateInterval.Month:
                    lngDateDiffValue = (long)(TS.Days / 30);
                    break;

                case DateInterval.Quarter:
                    lngDateDiffValue = (long)((TS.Days / 30) / 3);
                    break;

                case DateInterval.Second:
                    lngDateDiffValue = (long)TS.TotalSeconds;
                    break;

                case DateInterval.Week:
                    lngDateDiffValue = (long)(TS.Days / 7);
                    break;

                case DateInterval.Year:
                    lngDateDiffValue = (long)(TS.Days / 365);
                    break;
            }
            return (lngDateDiffValue);
        }

        #endregion Calcula a diferença entre datas (DATEDIFF)

        #region Retorna o ultimo dia do mes de acordo com o parametro

        /// <summary>
        /// Tipo da verificação do ultimo dia do mês
        /// </summary>
        public enum Tipo_Dia
        {
            Dias_Corrido,
            Dias_Uteis_Com_Sabado,
            Dias_Uteis_Sem_Sabado
        }

        /// <summary>
        /// Encontra o ultimo dia do mês de acordo com o valor selecionado.
        /// </summary>
        /// <param name="Dia">Filtro da data de acordo com a necessidade.</param>
        /// <param name="Primeiro_Dia">Qualquer data referencia do mês.</param>
        /// <returns>Retorno do ultimo dia do mês.</returns>
        public DateTime Ultimo_Dia_Mes(Tipo_Dia Dia, DateTime Primeiro_Dia)
        {
            DateTime dtUltimoDia;

            if (Primeiro_Dia.Day == 1)
                dtUltimoDia = Primeiro_Dia.AddMonths(1).AddDays(-1);
            else
            {
                dtUltimoDia = Convert.ToDateTime(
                        string.Format("01/{0}/{1}"
                            , Primeiro_Dia.Month.ToString()
                            , Primeiro_Dia.Year.ToString())).AddMonths(1).AddDays(-1);
            }

            switch (Dia)
            {
                case Tipo_Dia.Dias_Uteis_Com_Sabado:
                    if (dtUltimoDia.DayOfWeek == DayOfWeek.Sunday)
                        dtUltimoDia = dtUltimoDia.AddDays(-1);

                    break;

                case Tipo_Dia.Dias_Uteis_Sem_Sabado:
                    if (dtUltimoDia.DayOfWeek == DayOfWeek.Sunday)
                        dtUltimoDia = dtUltimoDia.AddDays(-2);

                    if (dtUltimoDia.DayOfWeek == DayOfWeek.Saturday)
                        dtUltimoDia = dtUltimoDia.AddDays(-1);

                    break;
            }

            return dtUltimoDia;
        }

        #endregion Retorna o ultimo dia do mes de acordo com o parametro

        #region Trabalha com contadores auxiliares.

        /// <summary>
        /// Captura o proximo registro da contagem
        /// </summary>
        /// <param name="Nome_Contador">Nome do contador na tabela</param>
        /// <returns>Numero do contador disponivel</returns>
        public string Contador(string Nome_Contador)
        {
            return this.Contador(Nome_Contador, false);
        }

        /// <summary>
        /// Captura o proximo registro da contagem e já atualiza liberando o contador para o proximo registro.
        /// </summary>
        /// <param name="Nome_Contador">Nome do contador na tabela</param>
        /// <param name="Auto_Incrementar">Gera o proximo número</param>
        /// <returns>Numero do contador disponivel</returns>
        public string Contador(string Nome_Contador, bool Auto_Incrementar)
        {
            string sSQL = "select Proximo_Valor from contadores where nome_contador = '{0}'";
            sSQL = string.Format(sSQL, Nome_Contador);

            object oValor = Data.SQL.ExecuteScalar(sSQL);

            if (oValor == DBNull.Value || oValor == null)
            {
                oValor = "1";
                sSQL = "insert contadores(Nome_Contador, Proximo_Valor) values('{0}', '{1}')";
                sSQL = string.Format(sSQL, Nome_Contador, oValor);
                Data.SQL.Execute(sSQL);
            }

            if (Auto_Incrementar)
            {
                sSQL = "update Contadores set Proximo_valor = (Proximo_valor + 1) where nome_contador = '{0}'";
                sSQL = string.Format(sSQL, Nome_Contador);
                Data.SQL.Execute(sSQL);
            }

            return oValor.ToString();
        }

        #endregion Trabalha com contadores auxiliares.

        #region Abrir formulário que será passado em parametro.

        /// <summary>
        /// Carrega formulario.
        /// </summary>
        /// <param name="sNamespace">Namespace do formulário.</param>
        /// <param name="sFormulario">Nome do formulário</param>
        public Form Open_Form(string sNamespace, string sFormulario)
        {
            if (!string.IsNullOrEmpty(sFormulario) && !string.IsNullOrEmpty(sNamespace))
            {
                Tools.frmWait f = new Tools.frmWait("Aguarde, carregando formulário...");
                try
                {
                    Assembly obj1;
                    Form obj2;

                    //-- Verifica se existe objeto de entrata e carrega o mesmo.
                    Tools.Object_Entrada oe = new Tools.Object_Entrada();

                    //-- true carrega
                    //-- false não carrega e carrega o original
                    if (oe.Carregar_Formulario(sFormulario))
                    {
                        obj1 = oe.Assembly;
                        sNamespace = "ERP.Objeto";
                    }
                    else
                        obj1 = Assembly.LoadFrom(Application.ExecutablePath);

                    obj2 = (Form)obj1.CreateInstance(sNamespace + "." + sFormulario, true);
                    obj2.MdiParent = Propriedades.FormMain;
                    obj2.Show();

                    return obj2;
                }
                catch (Exception ex)
                {
                    MsgBox.Show(string.Format("Não foi possivel abrir o formulário selecionado [{0}].\r\n\r\n" + ex.Message, sFormulario)
                        , "Atenção"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);

                    return null;
                }
                finally
                {
                    f.Close();
                }
            }
            else
                return null;
        }

        #endregion Abrir formulário que será passado em parametro.

        #region Execute um metodo de um objeto de entrada.

        /// <summary>
        /// Executa um metodo de um objeto de entrada sem tela.
        /// </summary>
        /// <param name="sNomeObjeto">Nome do objeto para buscar os parametros cadastrados.</param>
        /// <param name="paramConstrutor">array object[] com o parametros do construtor.</param>
        /// <param name="paramMetodo">array object[] com os parametros do metodo.</param>
        /// <param name="nomeParamMetodo">array string[] com os nomes do metodo.</param>
        public void Executar_ObjetoEntrada(string sNomeObjeto, object[] paramConstrutor, object[] paramMetodo, string[] nomeParamMetodo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * ");
            sb.AppendLine(" from Objetos_Entrada");
            sb.AppendFormat(" where Objeto_Entrada = '{0}'", sNomeObjeto);
            DataTable dt = CompSoft.Data.SQL.Select(sb.ToString(), "x", false);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                CompSoft.Tools.Object_Entrada o = new CompSoft.Tools.Object_Entrada();
                o.Carregar_Formulario(row["Nome_Arquivo"].ToString(), true);

                Assembly obj1 = o.Assembly;
                Object obj2;

                obj2 = obj1.CreateInstance(string.Format("{0}.{1}", row["Namespace"], row["Classe"])
                    , true
                    , BindingFlags.CreateInstance
                    , (Binder)null
                    , paramConstrutor       //-- Parametros do construtor.
                    , (CultureInfo)null
                    , (object[])null);

                obj2.GetType().InvokeMember(
                      row["Metodo"].ToString()
                    , BindingFlags.InvokeMethod
                    , (Binder)null
                    , obj2
                    , paramMetodo           //-- Parametros do metodo.
                    , (ParameterModifier[])null
                    , (CultureInfo)null
                    , nomeParamMetodo);     //-- Identificação dos parametros

                obj1 = null;
                obj2 = null;
            }

            dt = null;
        }

        #endregion Execute um metodo de um objeto de entrada.

        #region Verifica Se o objejct é herança em algum nivel do objeto de referencia

        /// <summary>
        /// Verifica se o object é herança em algum nivel do objeto de referencia.
        /// </summary>
        /// <param name="typeObject">Type do objeto de comparação</param>
        /// <param name="typeReference">Type do objeto de referencia</param>
        /// <returns>true/false indicando se o o</returns>
        public bool Check_Extension(Type typeObject, Type typeReference)
        {
            bool bRetorno = false;

            //-- Verifica se o objeto Type não é nulo
            if (typeObject != null)
            {
                if (typeObject == typeReference)
                {
                    bRetorno = true;
                }
                else
                {
                    if (typeObject.BaseType != null)
                    {
                        bRetorno = this.Check_Extension(typeObject.BaseType, typeReference);
                    }
                }
            }

            return bRetorno;
        }

        #endregion Verifica Se o objejct é herança em algum nivel do objeto de referencia

        #region Recebe uma determinada quantidade de caracteres de uma variável string (A Esquerda)

        /// <summary>
        /// Recebe uma determinada quantidade de caracteres de uma variável string (A Esquerda)
        /// </summary>
        /// <param name="param">String para a captura dos caracteres</param>
        /// <param name="length">Quantidade de caracteres a ser copiado</param>
        /// <returns>Retorna os caracteres de acordo com o length</returns>
        public string Left(string param, int length)
        {
            string result = param.Substring(0, length);
            return result;
        }

        #endregion Recebe uma determinada quantidade de caracteres de uma variável string (A Esquerda)

        #region Recebe uma determinada quantidade de caracteres de uma variável string (A Direita)

        /// <summary>
        /// Recebe uma determinada quantidade de caracteres de uma variável string (A Direita)
        /// </summary>
        /// <param name="param">String para a captura dos caracteres</param>
        /// <param name="length">Quantidade de caracteres a ser copiado</param>
        /// <returns>Retorna os caracteres de acordo com o length</returns>
        public string Right(string param, int length)
        {
            int begin = param.Length - length;
            string result = param.Substring(begin, length);
            return result;
        }

        #endregion Recebe uma determinada quantidade de caracteres de uma variável string (A Direita)

        #region Tira acento das strings

        /// <summary>
        /// Tira acentos e caracteres especiais das palavras
        /// </summary>
        /// <param name="sValor">String para verificação</param>
        /// <param name="iQtdeCaracter">Tamanho maximo da string, onde a mesma será truncada</param>
        /// <returns>nova string corrigido</returns>
        public string Tira_Acento(string sValor, int iQtdeCaracter)
        {
            char[] cComAcento = @"áéíóúàèìòùãõâêîôû<>´&ç!@#$%¨*/\ºª".ToUpper().ToCharArray();
            char[] cSemAcento = @"aeiouaeiouaoaeiou   Ec           ".ToUpper().ToCharArray();

            string sNewValor = sValor.Trim().ToUpper();
            if (sNewValor.Length > iQtdeCaracter)
                sNewValor = sNewValor.Substring(0, iQtdeCaracter);

            for (int i = 0; i < cComAcento.Length; i++)
                sNewValor = sNewValor.Replace(cComAcento[i], cSemAcento[i]);

            return sNewValor;
        }

        /// <summary>
        /// Tira acentos e caracteres especiais das palavras
        /// </summary>
        /// <param name="sValor">String para verificação</param>
        /// <returns>nova string corrigido</returns>
        public string Tira_Acento(string sValor)
        {
            return Tira_Acento(sValor, sValor.Length);
        }

        #endregion Tira acento das strings
    }
}