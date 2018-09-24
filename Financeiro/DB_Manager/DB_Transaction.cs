using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Financeiro.Entities;

namespace Financeiro.DB_Manager
{
    class DB_Transaction
    {
        private String CountString;
        private String Retrieve;

        private int Count = -1;

        private Category Category;
        private Operation Operation;
        private DB_PaymentForm PaymentForm;

        private List<Transaction> CategoryList = new List<Transaction>();

        public int CountRows(MySqlConnection conn)
        {
            CountString = "SELECT COUNT(*) FROM transacoes";
            MySqlCommand Command = new MySqlCommand(CountString, conn);

            Count = Convert.ToInt32(Command.ExecuteScalar());

            return Count;
        }
    }
}
