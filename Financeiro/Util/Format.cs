using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Util
{
    class Format
    {
        public static String FillString(int Value)
        {
            String sValue = Value.ToString();

            if (sValue.Length == 1)
            {
                return sValue = "0" + sValue;
            }

            return sValue;
        }
    }
}
