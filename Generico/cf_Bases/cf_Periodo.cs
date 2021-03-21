using CompSoft.compFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompSoft.cf_Bases
{
    [ToolboxBitmap(typeof(DateTimePicker)), ToolboxItem(true)]
    public partial class cf_Periodo : UserControl
    {
        private RegistroWindows reg = new RegistroWindows();
        private bool bEnable = true;

        public DateTime Data_Inicial
        {
            get { return Convert.ToDateTime(this.txtInicial.EditValue); }
        }

        public new bool Enabled
        {
            get { return bEnable; }
            set
            {
                bEnable = value;
                this.txtInicial.Enabled = value;
                this.txtTermino.Enabled = value;
                this.cboPeriodo.Enabled = value;
            }
        }

        public DateTime Data_Termino
        {
            get { return Convert.ToDateTime(this.txtTermino.EditValue); }
        }

        public string Data_Inicial_SQL
        {
            get
            {
                string sData = string.Empty;
                if (this.txtInicial.EditValue != null)
                {
                    sData = Convert.ToDateTime(this.txtInicial.EditValue).ToString("yyyyMMdd")
                        + " 00:00:00";
                }
                return sData;
            }
        }

        public string Data_Termino_SQL
        {
            get
            {
                string sData = string.Empty;
                if (this.txtTermino.EditValue != null)
                {
                    sData = Convert.ToDateTime(this.txtTermino.EditValue).ToString("yyyyMMdd")
                       + " 23:59:00";
                }
                return sData;
            }
        }

        public void Limpar()
        {
            this.cboPeriodo.SelectedIndex = 0;
        }

        public cf_Periodo()
        {
            InitializeComponent();
        }

        private void cf_Periodo_Load(object sender, EventArgs e)
        {
            this.cboPeriodo.SelectedIndex = 0;
            if (Propriedades.FormMain != null)
            {
                //-- Trata Data Inicial
                string sValor = reg.LocalizaRegistro("Periodo_Inicial").ToString();
                if (!string.IsNullOrEmpty(sValor))
                {
                    try
                    {
                        this.txtInicial.EditValue = Convert.ToDateTime(sValor);
                    }
                    catch
                    {
                        this.txtInicial.EditValue = null;
                    }
                }

                //-- Trata Data Final
                sValor = reg.LocalizaRegistro("Periodo_Final").ToString();
                if (!string.IsNullOrEmpty(sValor))
                {
                    try
                    {
                        this.txtTermino.EditValue = Convert.ToDateTime(sValor);
                    }
                    catch
                    {
                        this.txtTermino.EditValue = null;
                    }
                }

                if (!string.IsNullOrEmpty(reg.LocalizaRegistro("Tipo_Periodo").ToString()))
                    this.cboPeriodo.SelectedIndex = int.Parse(reg.LocalizaRegistro("Tipo_Periodo").ToString());
            }
        }

        private void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dDataInicial;
            Funcoes func;

            switch (this.cboPeriodo.Text.ToLower())
            {
                case "nenhuma data":
                    this.txtInicial.EditValue = null;
                    this.txtTermino.EditValue = null;
                    break;

                case "hoje":
                    this.txtInicial.EditValue = DateTime.Now;
                    this.txtTermino.EditValue = DateTime.Now;
                    break;

                case "ontem":
                    this.txtInicial.EditValue = DateTime.Now.AddDays(-1);
                    this.txtTermino.EditValue = DateTime.Now.AddDays(-1);
                    break;

                case "este mês":
                    dDataInicial = DateTime.Now.AddDays((DateTime.Now.Day * -1) + 1);
                    this.txtInicial.EditValue = dDataInicial;
                    this.txtTermino.EditValue = func.Ultimo_Dia_Mes(Funcoes.Tipo_Dia.Dias_Corrido, dDataInicial);
                    break;

                case "mês passado":
                    dDataInicial = DateTime.Now.AddMonths(-1).AddDays((DateTime.Now.Day * -1) + 1);
                    this.txtInicial.EditValue = dDataInicial;
                    this.txtTermino.EditValue = func.Ultimo_Dia_Mes(Funcoes.Tipo_Dia.Dias_Corrido, dDataInicial);
                    break;

                case "este ano":
                    dDataInicial = DateTime.Now.AddMonths((DateTime.Now.Month * -1) + 1).AddDays((DateTime.Now.Day * -1) + 1);
                    this.txtInicial.EditValue = dDataInicial;
                    this.txtTermino.EditValue = func.Ultimo_Dia_Mes(Funcoes.Tipo_Dia.Dias_Corrido, dDataInicial.AddMonths(11));
                    break;

                case "ano passado":
                    dDataInicial = DateTime.Now.AddYears(-1).AddMonths((DateTime.Now.Month * -1) + 1).AddDays((DateTime.Now.Day * -1) + 1);
                    this.txtInicial.EditValue = dDataInicial;
                    this.txtTermino.EditValue = func.Ultimo_Dia_Mes(Funcoes.Tipo_Dia.Dias_Corrido, dDataInicial.AddMonths(11));
                    break;
            }

            if (this.cboPeriodo.Focused)
                reg.GravarRegistro("Tipo_Periodo", this.cboPeriodo.SelectedIndex.ToString());
        }

        private void txtInicial_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtInicial.EditValue == null)
                reg.GravarRegistro("Periodo_Inicial", "");
            else
            {
                reg.GravarRegistro("Periodo_Inicial", Convert.ToDateTime(this.txtInicial.EditValue).ToShortDateString());

                if (!this.cboPeriodo.Focused
                    && this.txtInicial.EditValue != null
                    && this.txtInicial.ValorAnterior != null
                    && (DateTime)this.txtInicial.ValorAnterior != (DateTime)this.txtInicial.EditValue)
                {
                    this.cboPeriodo.SelectedIndex = 7;
                }
            }
        }

        private void txtTermino_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtTermino.EditValue == null)
                reg.GravarRegistro("Periodo_Final", "");
            else
            {
                reg.GravarRegistro("Periodo_Final", Convert.ToDateTime(this.txtTermino.EditValue).ToShortDateString());

                if (!this.cboPeriodo.Focused
                    && this.txtTermino.EditValue != null
                    && this.txtTermino.ValorAnterior != null
                    && (DateTime)this.txtTermino.ValorAnterior != (DateTime)this.txtTermino.EditValue)
                {
                    this.cboPeriodo.SelectedIndex = 7;
                }
            }
        }

        private void txtInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cboPeriodo.SelectedIndex = 7;
        }

        private void txtTermino_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cboPeriodo.SelectedIndex = 7;
        }
    }
}