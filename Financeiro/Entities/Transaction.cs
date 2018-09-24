using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Entities
{
    class Transaction
    {
        public int Transaction_Id { set; get; }
        public Operation Operation { set; get; }
        public double Value { set; get; }
        public double Reversal { set; get; }
        public PaymentForm PaymentForm { set; get; }
        public String PaymentDate { set; get; }
        public string Date { set; get; }
        public Category Category { set; get; }
        public int NInstallment { set; get; }
        public int Installment { set; get; }
        public string Observations { set; get; }
        public DateTime TransactionDateInsert { set; get; }
        public DateTime TransactionDateUpdate { set; get; }
    }
}
