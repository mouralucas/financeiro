using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Financeiro.Entities;

namespace Financeiro.DB_Manager
{
    class DB_PaymentForm
    {

        private String CountString;
        private String Retrieve;

        private int Count = -1;

        private PaymentForm PaymentForm;

        private List<PaymentForm> PaymentFormList = new List<PaymentForm>();

        public int CountRows(MySqlConnection conn)
        {
            CountString = "SELECT COUNT(*) FROM formaspagamento";
            MySqlCommand Command = new MySqlCommand(CountString, conn);

            Count = Convert.ToInt32(Command.ExecuteScalar());

            return Count;
        }

        public List<PaymentForm> ListAll(MySqlConnection Conn)
        {

            Retrieve = "SELECT fm.* FROM formaspagamento fm";

            MySqlCommand Cmd = new MySqlCommand(Retrieve, Conn);
            SetPaymentFormData(Cmd);
            return PaymentFormList;
        }

        private void SetPaymentFormData(MySqlCommand Cmd)
        {
            MySqlDataReader DataRead = Cmd.ExecuteReader();
            PaymentFormList.Clear();

            while (DataRead.Read())
            {
                PaymentForm = new PaymentForm()
                {
                    PaymentForm_Id = Convert.IsDBNull(DataRead["formaPag_id"]) ? -1 : Convert.ToInt32(DataRead["formaPag_id"]),
                    PaymentFormName = Convert.IsDBNull(DataRead["formaPag"]) ? "" : DataRead["formaPag"].ToString(),
                    ShowOnDash = Convert.IsDBNull(DataRead["showOnDash"]) ? -1 : Convert.ToInt32(DataRead["showOnDash"])
                };

                PaymentFormList.Add(PaymentForm);
            }

            DataRead.Close();
        }
    }
}
