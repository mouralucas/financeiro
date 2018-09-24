using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Financeiro.Entities;

namespace Financeiro.DB_Manager
{
    class DB_Category
    {
        private String CountString;
        private String Retrieve;

        private int Count = -1;

        private Category Category;
        private Operation Operation;
        private List<Category> CategoryList = new List<Category>();

        public int CountRows(MySqlConnection conn)
        {
            CountString = "SELECT COUNT(*) FROM categoria";
            MySqlCommand Command = new MySqlCommand(CountString, conn);

            Count = Convert.ToInt32(Command.ExecuteScalar());

            return Count;
        }

        public List<Category> ListAll(MySqlConnection Conn)
        {
            Retrieve = "SELECT c.*, o.* FROM categoria c " +
                "INNER JOIN operacao o " +
                "   ON o.operacao_id = c.operacao_id ";

            MySqlCommand Cmd = new MySqlCommand(Retrieve, Conn);
            SetCategoryData(Cmd);
            return CategoryList;
        }

        private void SetCategoryData(MySqlCommand Cmd)
        {
            MySqlDataReader DataRead = Cmd.ExecuteReader();
            CategoryList.Clear();

            while (DataRead.Read())
            {
                Operation = new Operation()
                {
                    Operation_Id = Convert.IsDBNull(DataRead["operacao_id"]) ? -1 : Convert.ToInt32(DataRead["operacao_id"]),
                    OperationName = Convert.IsDBNull(DataRead["operacao"]) ? "" : DataRead["operacao"].ToString()
                };

                Category = new Category()
                {
                    Category_Id = Convert.IsDBNull(DataRead["categoria_id"]) ? -1 : Convert.ToInt32(DataRead["categoria_id"]),
                    Id_Pai = Convert.IsDBNull(DataRead["id_pai"]) ? -1 : Convert.ToInt32(DataRead["id_pai"]),
                    Description = Convert.IsDBNull(DataRead["descricao"]) ? "" : DataRead["descricao"].ToString(),
                    Operation = Operation,
                    Comments = Convert.IsDBNull(DataRead["comentarios"]) ? "" : DataRead["comentarios"].ToString(),
                    ShowOnDash = Convert.IsDBNull(DataRead["showOnDash"]) ? -1 : Convert.ToInt32(DataRead["showOnDash"])
                };

                CategoryList.Add(Category);
            }

            DataRead.Close();
        }

    }
}
