using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Financeiro.Entities;


namespace Financeiro.DB_Manager
{
    class DB_Transaction
    {
        private String CountString;
        private String Insert;
        private String Update;
        private String Retrieve;

        private int Count = -1;

        private Category Category;
        private Operation Operation;
        private PaymentForm PaymentForm;
        private Transaction Transaction;


        private List<Transaction> TransactionsByMonth = new List<Transaction>();

        public int CountRows(MySqlConnection conn)
        {
            CountString = "SELECT COUNT(*) FROM transacoes";
            MySqlCommand Command = new MySqlCommand(CountString, conn);

            Count = Convert.ToInt32(Command.ExecuteScalar());

            return Count;
        }

        public bool InsertTransaction(int Operation_Id, double Value, int PaymentForm_Id, String PaymentDate,
            String Date, int Category_Id, int NInstallment, int Installment, String Obs, MySqlConnection Conn)
        {
            Insert = "INSERT INTO transacoes " +
                "       (operacao_id, valor, formaPagamento_id, dataPagamento, data, categoria_id, nParcela," +
                "           totalParcelas, observacoes, dataInsercao) " +
                "   VALUES " +
                "       (@operacao_id, @valor, @formaPagamento_id, @dataPagamento, @data, @categoria_id, @nParcela," +
                "           @totalParcelas, @observacoes, current_timestamp())";

            try
            {
                MySqlCommand Cmd = new MySqlCommand(Insert, Conn);

                Cmd.Parameters.Add("@operacao_id", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@valor", MySqlDbType.Double);
                Cmd.Parameters.Add("@formaPagamento_id", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@dataPagamento", MySqlDbType.Date);
                Cmd.Parameters.Add("@data", MySqlDbType.Date);
                Cmd.Parameters.Add("@categoria_id", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@nParcela", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@totalParcelas", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@observacoes", MySqlDbType.MediumText);

                Cmd.Parameters["@operacao_id"].Value = Operation_Id;
                Cmd.Parameters["@valor"].Value = Value;
                Cmd.Parameters["@formaPagamento_id"].Value = PaymentForm_Id;
                Cmd.Parameters["@dataPagamento"].Value = PaymentDate;
                Cmd.Parameters["@data"].Value = Date;
                Cmd.Parameters["@categoria_id"].Value = Category_Id;
                Cmd.Parameters["@nParcela"].Value = NInstallment;
                Cmd.Parameters["@totalParcelas"].Value = Installment;
                Cmd.Parameters["@observacoes"].Value = Obs;

                if (Cmd.ExecuteNonQuery() > 0)
                {
                    DialogResult dr = MessageBox.Show("Transação Inserida com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Erro ao Inserir a Transação!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error: " + e);
                return false;
            }
        }


        public bool UpdateTransaction(int Transaction_Id, int Operation_Id, double Value, double Reversal, int PaymentForm_Id, String PaymentDate,
            String Date, int Category_Id, int NInstallment, int Installment, String Obs, MySqlConnection Conn)
        {

            Update = "UPDATE transacoes SET " +
                "operacao_id = @operacao_id, " +
                "valor = @valor, " +
                "estorno = @estorno, " +
                "formaPagamento_id = @formaPagamento_id, " +
                "dataPagamento = @dataPagamento, " +
                "data = @data, " +
                "categoria_id = @categoria_id, " +
                "nParcela = @nParcela, " +
                "totalParcelas = @totalParcelas, " +
                "observacoes = @observacoes, " +
                "dataAtualizacao = current_timestamp(), " +
                "WHERE transacao_id = " + Transaction_Id;

            try
            {
                MySqlCommand Cmd = new MySqlCommand(Update, Conn);

                Cmd.Parameters.Add("@operacao_id", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@valor", MySqlDbType.Double);
                Cmd.Parameters.Add("@estorno", MySqlDbType.Double);
                Cmd.Parameters.Add("@formaPagamento_id", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@dataPagamento", MySqlDbType.Date);
                Cmd.Parameters.Add("@data", MySqlDbType.Date);
                Cmd.Parameters.Add("@categoria_id", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@nParcela", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@totalParcelas", MySqlDbType.Int32, 11);
                Cmd.Parameters.Add("@observacoes", MySqlDbType.MediumText);

                Cmd.Parameters["@operacao_id"].Value = Operation_Id;
                Cmd.Parameters["@valor"].Value = Value;
                Cmd.Parameters["@estorno"].Value = Reversal;
                Cmd.Parameters["@formaPagamento_id"].Value = PaymentForm_Id;
                Cmd.Parameters["@dataPagamento"].Value = PaymentDate;
                Cmd.Parameters["@data"].Value = Date;
                Cmd.Parameters["@categoria_id"].Value = Category_Id;
                Cmd.Parameters["@nParcela"].Value = NInstallment;
                Cmd.Parameters["@totalParcelas"].Value = Installment;
                Cmd.Parameters["@observacoes"].Value = Obs;

                if (Cmd.ExecuteNonQuery() > 0)
                {
                    DialogResult dr = MessageBox.Show("Transação Atualizada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Erro ao Atualizar a Transação!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error: " + e);
                return false;
            }

        }

        public List<Transaction> ListAll(int Month, MySqlConnection Conn)
        {

            Retrieve = "SELECT "
                + "     o.*, c.*, fp.*, t.*"
                + " FROM "
                + "	    transacoes t "
                + " INNER JOIN  "
                + "     operacao o "
                + "         ON t.operacao_id = o.operacao_id "
                + " INNER JOIN "
                + "	    formaspagamento fp "
                + "         ON t.formaPagamento_id = fp.formaPag_id "
                + " INNER JOIN "
                + "	    categoria c "
                + "         ON t.categoria_id = c.categoria_id "
                + " WHERE "
                + "	MONTH(t.dataPagamento) = " + Month
                //+ "	MONTH(t.dataPagamento) = 06"
                + " ORDER BY data";

            MySqlCommand Cmd = new MySqlCommand(Retrieve, Conn);
            MySqlDataReader DataRead = Cmd.ExecuteReader();

            TransactionsByMonth.Clear();

            while (DataRead.Read())
            {
                Operation = new Operation()
                {
                    Operation_Id = Convert.IsDBNull(DataRead["operacao_id"]) ? -1 : Convert.ToInt32(DataRead["operacao_id"]),
                    OperationName = Convert.IsDBNull(DataRead["operacao"]) ? "" : DataRead["operacao"].ToString().Trim()
                };

                Category = new Category()
                {
                    Category_Id = Convert.IsDBNull(DataRead["categoria_id"]) ? -1 : Convert.ToInt32(DataRead["categoria_id"]),
                    Id_Pai = Convert.IsDBNull(DataRead["id_pai"]) ? -1 : Convert.ToInt32(DataRead["id_pai"]),
                    Description = Convert.IsDBNull(DataRead["descricao"]) ? "" : DataRead["descricao"].ToString().Trim(),
                };

                PaymentForm = new PaymentForm()
                {
                    PaymentForm_Id = Convert.IsDBNull(DataRead["formaPag_id"]) ? -1 : Convert.ToInt32(DataRead["formaPag_id"]),
                    PaymentFormName = Convert.IsDBNull(DataRead["formaPag"]) ? "" : DataRead["formaPag"].ToString().Trim()
                };

                Transaction = new Transaction()
                {

                    Transaction_Id = Convert.IsDBNull(DataRead["transacao_id"]) ? -1 : Convert.ToInt32(DataRead["transacao_id"]),
                    Operation = Operation,
                    Value = Convert.IsDBNull(DataRead["valor"]) ? 0 : Convert.ToDouble(DataRead["valor"].ToString().Trim()),
                    Reversal = Convert.IsDBNull(DataRead["estorno"]) ? 0 : Convert.ToDouble(DataRead["estorno"].ToString().Trim()),
                    PaymentForm = PaymentForm,
                    PaymentDate = Convert.IsDBNull(DataRead["dataPagamento"]) ? "" : DataRead["dataPagamento"].ToString().Remove(10).Trim(),
                    Date = Convert.IsDBNull(DataRead["data"]) ? "" : DataRead["data"].ToString().Remove(10).Trim(),
                    Category = Category,

                    NInstallment = Convert.IsDBNull(DataRead["nParcela"]) ? 0 : Convert.ToInt16(DataRead["nParcela"]),
                    Installment = Convert.IsDBNull(DataRead["totalParcelas"]) ? 0 : Convert.ToInt16(DataRead["totalParcelas"]),

                    Observations = Convert.IsDBNull(DataRead["observacoes"]) ? "" : DataRead["observacoes"].ToString().Trim()

                    
                    
                };

                TransactionsByMonth.Add(Transaction);
            }

            DataRead.Close();

            return TransactionsByMonth;
        }
    }
}
