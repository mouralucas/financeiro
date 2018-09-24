using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Entities
{
    class PaymentForm
    {
        public int PaymentForm_Id { set; get; }
        public String PaymentFormName { set; get; }
        public int ShowOnDash { set; get; }
    }
}
