using System;
using System.Collections.Generic;
using System.Text;

namespace CompSoft.Interfaces
{
    internal interface IBaseControl_DB_Generic<T>
    {
        T Value { get; set; }
    }
}