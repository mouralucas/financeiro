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
