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

        public int CountRows(MySqlConnection Conn)
        {
            CountString = "SELECT COUNT(*) FROM transacoes";
            MySqlCommand Command = new MySqlCommand(CountString, Conn);

            Count = Convert.ToInt32(Command.ExecuteScalar());

            return Count;
        }

        public bool InsertTransaction(int Operation_Id, double Value, int PaymentForm_Id, String PaymentDate,
            String Date, int Category_Id, int NInstallment, int Installment, String Obs, MySqlConnection Conn)
        {
            Insert = "INSERT INTO transacoes "
                + "       (operacao_id, valor, formaPagamento_id, dataPagamento, data, categoria_id, nParcela," 
                + "           totalParcelas, observacoes, dataInsercao) " 
                + "   VALUES " 
                + "       (@operacao_id, @valor, @formaPagamento_id, @dataPagamento, @data, @categoria_id, @nParcela," 
                + "           @totalParcelas, @observacoes, current_timestamp())";

            try
            {
                MySqlCommand Command = new MySqlCommand(Insert, Conn);

                Command.Parameters.Add("@operacao_id", MySqlDbType.Int32, 11);
                Command.Parameters.Add("@valor", MySqlDbType.Double);
                Command.Parameters.Add("@formaPagamento_id", MySqlDbType.Int32, 11);
                Command.Parameters.Add("@dataPagamento", MySqlDbType.Date);
                Command.Parameters.Add("@data", MySqlDbType.Date);
                Command.Parameters.Add("@categoria_id", MySqlDbType.Int32, 11);
                Command.Parameters.Add("@nParcela", MySqlDbType.Int32, 11);
                Command.Parameters.Add("@totalParcelas", MySqlDbType.Int32, 11);
                Command.Parameters.Add("@observacoes", MySqlDbType.MediumText);

                Command.Parameters["@operacao_id"].Value = Operation_Id;
                Command.Parameters["@valor"].Value = Value;
                Command.Parameters["@formaPagamento_id"].Value = PaymentForm_Id;
                Command.Parameters["@dataPagamento"].Value = PaymentDate;
                Command.Parameters["@data"].Value = Date;
                Command.Parameters["@categoria_id"].Value = Category_Id;
                Command.Parameters["@nParcela"].Value = NInstallment;
                Command.Parameters["@totalParcelas"].Value = Installment;
                Command.Parameters["@observacoes"].Value = Obs;

                if (Command.ExecuteNonQuery() > 0)
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
                "dataAtualizacao = current_timestamp() " +
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

        public List<Transaction> ListAll(int Month, int Year, MySqlConnection Conn)
        {

            Retrieve = "SELECT "
                + "         o.operacao_id       AS operacao_id,"
                + "         o.operacao          AS operacao,"
                + "         c.categoria_id      AS categoria_id,"
                + "         c.id_pai            AS id_pai,"
                + "         c.descricao         AS descricao,"
                + "         fp.formaPag_id      AS formaPag_id,"
                + "         fp.formaPag         AS formaPag,"
                + "         t.transacao_id      AS transacao_id, "
                + "         t.valor             AS valor, "
                + "         t.estorno           AS estorno, "
                + "         t.dataPagamento     AS dataPagamento, "
                + "         t.data              AS data, "
                + "         t.nParcela          AS nParcela, "
                + "         t.totalParcelas     AS totalParcelas, "
                + "         t.observacoes       AS observacoes "
                + " FROM "
                + " transacoes t "
                + " INNER JOIN  "
                + "     operacao o "
                + "         ON t.operacao_id = o.operacao_id "
                + " INNER JOIN "
                + "	    formaspagamento fp "
                + "         ON t.formaPagamento_id = fp.formaPag_id "
                + " INNER JOIN "
                + "	    categoria c "
                + "         ON t.categoria_id = c.categoria_id "
                + " WHERE 1=1"
                + "	AND MONTH(t.dataPagamento) = " + Month
                + " AND YEAR(t.dataPagamento) = " + Year
                + " ORDER BY data";

            MySqlCommand Command = new MySqlCommand(Retrieve, Conn);
            MySqlDataReader DataReader = Command.ExecuteReader();

            TransactionsByMonth.Clear();

            while (DataReader.Read())
            {
                Operation = new Operation()
                {
                    Operation_Id = Convert.IsDBNull(DataReader["operacao_id"]) ? -1 : Convert.ToInt32(DataReader["operacao_id"]),
                    OperationName = Convert.IsDBNull(DataReader["operacao"]) ? "" : DataReader["operacao"].ToString().Trim()
                };

                Category = new Category()
                {
                    Category_Id = Convert.IsDBNull(DataReader["categoria_id"]) ? -1 : Convert.ToInt32(DataReader["categoria_id"]),
                    Id_Pai = Convert.IsDBNull(DataReader["id_pai"]) ? -1 : Convert.ToInt32(DataReader["id_pai"]),
                    Description = Convert.IsDBNull(DataReader["descricao"]) ? "" : DataReader["descricao"].ToString().Trim(),
                };

                PaymentForm = new PaymentForm()
                {
                    PaymentForm_Id = Convert.IsDBNull(DataReader["formaPag_id"]) ? -1 : Convert.ToInt32(DataReader["formaPag_id"]),
                    PaymentFormName = Convert.IsDBNull(DataReader["formaPag"]) ? "" : DataReader["formaPag"].ToString().Trim()
                };

                Transaction = new Transaction()
                {

                    Transaction_Id = Convert.IsDBNull(DataReader["transacao_id"]) ? -1 : Convert.ToInt32(DataReader["transacao_id"]),
                    Operation = Operation,
                    Value = Convert.IsDBNull(DataReader["valor"]) ? 0 : Convert.ToDouble(DataReader["valor"].ToString().Trim()),
                    Reversal = Convert.IsDBNull(DataReader["estorno"]) ? 0 : Convert.ToDouble(DataReader["estorno"].ToString().Trim()),
                    PaymentForm = PaymentForm,
                    PaymentDate = Convert.IsDBNull(DataReader["dataPagamento"]) ? "" : DataReader["dataPagamento"].ToString().Remove(10).Trim(),
                    Date = Convert.IsDBNull(DataReader["data"]) ? "" : DataReader["data"].ToString().Remove(10).Trim(),
                    Category = Category,

                    NInstallment = Convert.IsDBNull(DataReader["nParcela"]) ? 0 : Convert.ToInt16(DataReader["nParcela"]),
                    Installment = Convert.IsDBNull(DataReader["totalParcelas"]) ? 0 : Convert.ToInt16(DataReader["totalParcelas"]),

                    Observations = Convert.IsDBNull(DataReader["observacoes"]) ? "" : DataReader["observacoes"].ToString().Trim()



                };

                TransactionsByMonth.Add(Transaction);
            }

            DataReader.Close();

            return TransactionsByMonth;
        }
    }
}
