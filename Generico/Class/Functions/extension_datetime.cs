using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class extension_datetime
    {
        public static string ToString_ToXML(this DateTime dtOriginal)
        {
            return dtOriginal.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        }
    }
}