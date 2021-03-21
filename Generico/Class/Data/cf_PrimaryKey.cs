using System;
using System.Collections.Generic;
using System.Text;

namespace CompSoft.Data
{
    internal class DS_PrimaryKey
    {
        private string sPK = string.Empty;
        private string sValorPK = string.Empty;

        public string PrimaryKey
        {
            get { return sPK; }
            set { sPK = value; }
        }

        public string ValorPrimaryKey
        {
            get { return sValorPK; }
            set { sValorPK = value; }
        }

        public DS_PrimaryKey(string PK, string ValorPK)
        {
            sPK = PK;
            sValorPK = ValorPK;
        }
    }
}