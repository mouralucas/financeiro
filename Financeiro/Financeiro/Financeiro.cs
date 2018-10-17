using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Financeiro.Form_Insert;
using Financeiro.Form_Report;


namespace Financeiro
{
    static class Financeiro
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Transaction());

        }
    }
}
