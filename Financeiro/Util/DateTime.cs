using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Util
{
    class DateTime
    {
        public static String DateFormat(int Value)
        {
            String sValue = Value.ToString();

            if (sValue.Length == 1)
            {
                return sValue = "0" + sValue;
            }

            return sValue;
        }

        public static String InvertDate(String date)
        {
            String Day = date.Substring(0, 2);
            String Month = date.Substring(3, 2);
            String Year = date.Substring(6, 4);

            String Time = date.Substring(11);

            String g = Year + "/" + Month + "/" + Day + " " + Time;

            return g;

        }
    }
}
