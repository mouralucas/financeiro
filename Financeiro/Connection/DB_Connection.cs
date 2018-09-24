using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Financeiro.Connection
{
    class DB_Connection
    {
        public MySqlConnection Connection { set; get; }
        private string server;
        private string database;
        private string user;
        private string password;

        public DB_Connection()
        {
            SetConnection();
        }

        private void SetConnection()
        {
            server = "localhost";
            database = "financeiro_v2";
            user = "financeiro";
            password = "rachel";

            //set the connection
            Connection = new MySqlConnection("Server=" + server + ";" + "Database=" + database + ";"
                + "UID=" + user + ";" + "Password=" + password + ";");

        }

        public bool OpenConn()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator" + ex);
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConn()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

    }
}
