using CompSoft.cf_Bases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CompSoft.Interfaces
{
    public interface ITextControl_DB
    {
        TipoControle TipoControles { get; set; }

        DataRow LookUpRetorno { get; }

        bool LookUp { get; set; }

        string SQLStatement { get; set; }

        int Coluna_LookUp { get; set; }

        int Qtde_Casas_Decimais { get; set; }
    }
}