using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financeiro.Util
{
    class DateTime
    {
        private int v1;
        private int monthNumber;
        private int v2;

        public DateTime(int v1, int monthNumber, int v2)
        {
            this.v1 = v1;
            this.monthNumber = monthNumber;
            this.v2 = v2;
        }

        /*Mudificar esse metodo, isnão não eh dataFormat*/
        public static String DateFormat(int Value)
        {
            String sValue = Value.ToString();

            if (sValue.Length == 1)
            {
                return sValue = "0" + sValue;
            }

            return sValue;
        }

        /*Merlhorar coolocando um replace pra tirar possivel barra*/
        public static String InvertDate(String date)
        {
            String Day = date.Substring(0, 2);
            String Month = date.Substring(3, 2);
            String Year = date.Substring(6, 4);
            String Time = date.Substring(11);

            String newDate = Year + "/" + Month + "/" + Day + " " + Time;

            return newDate;

        }

        public static String MonthName(int MonthNumber)
        {
            string fullMonthName = CultureInfo.CreateSpecificCulture("pt").DateTimeFormat.GetMonthName(MonthNumber);
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fullMonthName.ToLower());
        }
    }
}
