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
    class DB_NotasModerninha
    {
        private String CountString;
        private String Retrieve;
        private String Insert;

        private int Count = -1;

        private NotasModerninha Notas;

        private List<NotasModerninha> List_NotasModerninha = new List<NotasModerninha>();


        public int CountRows(MySqlConnection conn)
        {
            CountString = "SELECT COUNT(*) FROM notas_moderninha";
            MySqlCommand Command = new MySqlCommand(CountString, conn);

            Count = Convert.ToInt32(Command.ExecuteScalar());

            return Count;
        }

        public bool InsertNotas(String Transacao_Id, String Cliente_Nome, String Cliente_Email, String Debito_Credito, String Tipo_Transacao,
            String Status, String Tipo_Pagamento, double Valor_Bruto, double Valor_Desconto, double Valor_Taxa, double Valor_Liquido,
            String Data_Transacao, String Data_Compensacao, int Parcelas, String Codigo_Usuario, String Codigo_Venda, String Serial_Leitor,
            int Recebimentos, int Recebidos, double Valor_Recebido, double Valor_Tarifa_Intermediacao, double Valor_Taxa_Intermediacao,
            double Valor_Taxa_Parcelamento, double Valor_Tarifa_Boleto, String Bandeira_Cartao_Credito, MySqlConnection Conn)
        {

            Insert = "INSERT INTO notas_moderninha " +
                "(transacao_id, cliente_nome, cliente_email, debito_credito, tipo_transacao, status, tipo_pagamento, valor_bruto, valor_desconto, " +
                "valor_taxa, valor_liquido, data_transacao, data_compensacao, parcelas, codigo_usuario, codigo_venda, serial_leitor, recebimentos, " +
                "recebidos, valor_recebido, valor_tarifa_intermediacao, valor_taxa_intermediacao, valor_taxa_parcelamento, valor_tarifa_boleto, " +
                "bandeira_cartao_credito, dataInsercao) " +
                "VALUES " +
                "(@transacao_id, @cliente_nome, @cliente_email, @debito_credito, @tipo_transacao, @status, @tipo_pagamento, @valor_bruto, @valor_desconto, " +
                "@valor_taxa, @valor_liquido, @data_transacao, @data_compensacao, @parcelas, @codigo_usuario, @codigo_venda, @serial_leitor, @recebimentos, " +
                "@recebidos, @valor_recebido, @valor_tarifa_intermediacao, @valor_taxa_intermediacao, @valor_taxa_parcelamento, @valor_tarifa_boleto, " +
                "@bandeira_cartao_credito, current_timestamp())";

            try
            {
                MySqlCommand Command = new MySqlCommand(Insert, Conn);

                Command.Parameters.Add("@transacao_id", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@cliente_nome", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@cliente_email", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@debito_credito", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@tipo_transacao", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@status", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@tipo_pagamento", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@valor_bruto", MySqlDbType.Double);
                Command.Parameters.Add("@valor_desconto", MySqlDbType.Double);
                Command.Parameters.Add("@valor_taxa", MySqlDbType.Double);
                Command.Parameters.Add("@valor_liquido", MySqlDbType.Double);
                Command.Parameters.Add("@data_transacao", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@data_compensacao", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@parcelas", MySqlDbType.Int32, 11);
                Command.Parameters.Add("@codigo_usuario", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@codigo_venda", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@serial_leitor", MySqlDbType.VarChar, 45);
                Command.Parameters.Add("@recebimentos", MySqlDbType.Int32, 11);
                Command.Parameters.Add("@recebidos", MySqlDbType.Int32, 11);
                Command.Parameters.Add("@valor_recebido", MySqlDbType.Double);
                Command.Parameters.Add("@valor_tarifa_intermediacao", MySqlDbType.Double);
                Command.Parameters.Add("@valor_taxa_intermediacao", MySqlDbType.Double);
                Command.Parameters.Add("@valor_taxa_parcelamento", MySqlDbType.Double);
                Command.Parameters.Add("@valor_tarifa_boleto", MySqlDbType.Double);
                Command.Parameters.Add("@bandeira_cartao_credito", MySqlDbType.VarChar, 45);

                Command.Parameters["@transacao_id"].Value = Transacao_Id;
                Command.Parameters["@cliente_nome"].Value = Cliente_Nome;
                Command.Parameters["@cliente_email"].Value = Cliente_Email;
                Command.Parameters["@debito_credito"].Value = Debito_Credito;
                Command.Parameters["@tipo_transacao"].Value = Tipo_Transacao;
                Command.Parameters["@status"].Value = Status;
                Command.Parameters["@tipo_pagamento"].Value = Tipo_Pagamento;
                Command.Parameters["@valor_bruto"].Value = Valor_Bruto;
                Command.Parameters["@valor_desconto"].Value = Valor_Desconto;
                Command.Parameters["@valor_taxa"].Value = Valor_Taxa;
                Command.Parameters["@valor_liquido"].Value = Valor_Liquido;
                Command.Parameters["@data_transacao"].Value = Data_Transacao;
                Command.Parameters["@data_compensacao"].Value = Data_Compensacao;
                Command.Parameters["@parcelas"].Value = Parcelas;
                Command.Parameters["@codigo_usuario"].Value = Codigo_Usuario;
                Command.Parameters["@codigo_venda"].Value = Codigo_Venda;
                Command.Parameters["@serial_leitor"].Value = Serial_Leitor;
                Command.Parameters["@recebimentos"].Value = Recebimentos;
                Command.Parameters["@recebidos"].Value = Recebidos;
                Command.Parameters["@valor_recebido"].Value = Valor_Recebido;
                Command.Parameters["@valor_tarifa_intermediacao"].Value = Valor_Tarifa_Intermediacao;
                Command.Parameters["@valor_taxa_intermediacao"].Value = Valor_Taxa_Intermediacao;
                Command.Parameters["@valor_taxa_parcelamento"].Value = Valor_Taxa_Parcelamento;
                Command.Parameters["@valor_tarifa_boleto"].Value = Valor_Tarifa_Boleto;
                Command.Parameters["@bandeira_cartao_credito"].Value = Bandeira_Cartao_Credito;

                if (Command.ExecuteNonQuery() > 0)
                {
                    //DialogResult dr = MessageBox.Show("Xml importado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Falha ao importar XML!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error: " + e);
                return false;
            }
        }

        public List<NotasModerninha> ListAll(MySqlConnection Conn)
        {
            Retrieve = "Select * FROM notas_moderninha order by data_transacao";

            MySqlCommand Command = new MySqlCommand(Retrieve, Conn);
            MySqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                Notas = new NotasModerninha()
                {
                    Transacao_Id = Convert.IsDBNull(DataReader["transacao_id"]) ? "" : DataReader["transacao_id"].ToString(),
                    Cliente_Nome = Convert.IsDBNull(DataReader["cliente_nome"]) ? "" : DataReader["cliente_nome"].ToString(),
                    Cliente_Email = Convert.IsDBNull(DataReader["cliente_email"]) ? "" : DataReader["cliente_email"].ToString(),
                    Debito_Credito = Convert.IsDBNull(DataReader["debito_credito"]) ? "" : DataReader["debito_credito"].ToString(),
                    Tipo_Transacao = Convert.IsDBNull(DataReader["tipo_transacao"]) ? "" : DataReader["tipo_transacao"].ToString(),
                    Status = Convert.IsDBNull(DataReader["status"]) ? "" : DataReader["status"].ToString(),
                    Tipo_Pagamento = Convert.IsDBNull(DataReader["tipo_pagamento"]) ? "" : DataReader["tipo_pagamento"].ToString(),
                    Valor_Bruto = Convert.IsDBNull(DataReader["valor_bruto"]) ? -1 : Convert.ToDouble(DataReader["valor_bruto"]),
                    Valor_Desconto = Convert.IsDBNull(DataReader["valor_desconto"]) ? -1 : Convert.ToDouble(DataReader["valor_desconto"]),
                    Valor_Taxa = Convert.IsDBNull(DataReader["valor_taxa"]) ? -1 : Convert.ToDouble(DataReader["valor_taxa"]),
                    Valor_Liquido = Convert.IsDBNull(DataReader["valor_liquido"]) ? -1 : Convert.ToDouble(DataReader["valor_liquido"]),
                    Data_Transacao = Convert.IsDBNull(DataReader["data_transacao"]) ? "" : DataReader["data_transacao"].ToString().Remove(10).Trim(),
                    Data_Compensacao = Convert.IsDBNull(DataReader["data_compensacao"]) ? "" : DataReader["data_compensacao"].ToString().Remove(10).Trim(),
                    Parcelas = Convert.IsDBNull(DataReader["parcelas"]) ? -1 : Convert.ToInt32(DataReader["parcelas"]),
                    Codigo_Usuario = Convert.IsDBNull(DataReader["codigo_usuario"]) ? "" : DataReader["codigo_usuario"].ToString(),
                    Codigo_Venda = Convert.IsDBNull(DataReader["codigo_venda"]) ? "" : DataReader["codigo_venda"].ToString(),
                    Serial_Leitor = Convert.IsDBNull(DataReader["serial_leitor"]) ? "" : DataReader["serial_leitor"].ToString(),
                    Recebimentos = Convert.IsDBNull(DataReader["recebimentos"]) ? -1 : Convert.ToInt32(DataReader["recebimentos"]),
                    Recebidos = Convert.IsDBNull(DataReader["recebidos"]) ? -1 : Convert.ToInt32(DataReader["recebidos"]),
                    Valor_Recebido = Convert.IsDBNull(DataReader["valor_recebido"]) ? -1 : Convert.ToDouble(DataReader["valor_recebido"]),
                    Valor_Tarifa_Intermediacao = Convert.IsDBNull(DataReader["valor_tarifa_intermediacao"]) ? -1 : Convert.ToDouble(DataReader["valor_tarifa_intermediacao"]),
                    Valor_Taxa_Intermediacao = Convert.IsDBNull(DataReader["valor_taxa_intermediacao"]) ? -1 : Convert.ToDouble(DataReader["valor_taxa_intermediacao"]),
                    Valor_Taxa_Parcelamento = Convert.IsDBNull(DataReader["valor_taxa_parcelamento"]) ? -1 : Convert.ToDouble(DataReader["valor_taxa_parcelamento"]),
                    Valor_Tarifa_Boleto = Convert.IsDBNull(DataReader["valor_tarifa_boleto"]) ? -1 : Convert.ToDouble(DataReader["valor_tarifa_boleto"]),
                    Bandeira_Cartao_Credito = Convert.IsDBNull(DataReader["bandeira_cartao_credito"]) ? "" : DataReader["bandeira_cartao_credito"].ToString(),
                };

                List_NotasModerninha.Add(Notas);
            }

            DataReader.Close();
            return List_NotasModerninha;
        }
    }

}
