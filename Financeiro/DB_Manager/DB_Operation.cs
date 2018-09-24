using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Financeiro.Entities;

namespace Financeiro.DB_Manager
{
    class DB_Operation
    {
        private String CountString;
        private String Retrieve;

        private int Count = -1;

        private Operation Operation;

        private List<Operation> OperationList = new List<Operation>();

        public int CountRows(MySqlConnection conn)
        {
            CountString = "SELECT COUNT(*) FROM operacao";
            MySqlCommand Command = new MySqlCommand(CountString, conn);

            Count = Convert.ToInt32(Command.ExecuteScalar());

            return Count;
        }

        public List<Operation> ListAll(MySqlConnection Conn)
        {
            Retrieve = "SELECT o.* FROM operacao o";

            MySqlCommand Cmd = new MySqlCommand(Retrieve, Conn);
            SetOperationData(Cmd);
            return OperationList;
        }

        private void SetOperationData(MySqlCommand Cmd)
        {
            MySqlDataReader DataRead = Cmd.ExecuteReader();
            OperationList.Clear();


            while (DataRead.Read())
            {
                Operation = new Operation()
                {
                    Operation_Id = Convert.IsDBNull(DataRead["operacao_id"]) ? -1 : Convert.ToInt32(DataRead["operacao_id"]),
                    OperationName = Convert.IsDBNull(DataRead["operacao"]) ? "" : DataRead["operacao"].ToString()
                };

                OperationList.Add(Operation);
            }

            DataRead.Close();
        }
    }
}
