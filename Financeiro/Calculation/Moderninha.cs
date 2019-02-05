using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financeiro.Entities;

namespace Financeiro.Calculation
{
    class Moderninha
    {
        private double Result;

        public double Calc(String PaymentForm, List<NotasModerninha> Notas)
        {
            Result = 0;
            foreach(NotasModerninha Nota in Notas)
            {
                if(Nota.Debito_Credito.Equals("Crédito") && Nota.Tipo_Pagamento.Contains(PaymentForm))
                {
                    Result += Nota.Valor_Liquido;
                }
            }

            return Result;
        }
    }
}
