using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Financeiro.Entities;
using Financeiro.Connection;
using Financeiro.DB_Manager;
using Financeiro.Files;
using Financeiro.Calculation;

namespace Financeiro.Form_Insert
{
    public partial class Form_Moderninha : Form
    {
        DB_Connection Conn = new DB_Connection();
        DB_NotasModerninha DB_NotasModerninha = new DB_NotasModerninha();

        Moderninha CalcModerninha = new Moderninha();

        List<NotasModerninha> Notas;

        XmlOperation xml = new XmlOperation();

        public Form_Moderninha()
        {
            InitializeComponent();
            Conn.OpenConn();

            Notas = DB_NotasModerninha.ListAll(Conn.Connection);
            Label_Debitos.Text = "Total de débitos: " + CalcModerninha.Calc("Débito", Notas);
            Label_Credito.Text = "Total de créditos: " + CalcModerninha.Calc("Crédito", Notas);

        }

        private void Button_SearchFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                Filter = "XML Files (*.xml) | *.xml",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                Text_FilePath.Text = FileDialog.FileName;
            }

        }

        private void Button_Import_Click(object sender, EventArgs e)
        {
           if(Text_FilePath != null)
            {

                bool InsertOk = false;
                foreach(NotasModerninha nota in xml.Reader(Text_FilePath.Text))
                {
                  InsertOk = DB_NotasModerninha.InsertNotas(nota.Transacao_Id, nota.Cliente_Nome, nota.Cliente_Email, nota.Debito_Credito, nota.Tipo_Transacao,
                        nota.Status, nota.Tipo_Pagamento, nota.Valor_Bruto, nota.Valor_Desconto, nota.Valor_Taxa, nota.Valor_Liquido, nota.Data_Transacao,
                        nota.Data_Compensacao, nota.Parcelas, nota.Codigo_Usuario, nota.Codigo_Venda, nota.Serial_Leitor, nota.Recebimentos,
                        nota.Recebidos, nota.Valor_Recebido, nota.Valor_Tarifa_Intermediacao, nota.Valor_Taxa_Intermediacao,
                        nota.Valor_Taxa_Parcelamento, nota.Valor_Tarifa_Boleto, nota.Bandeira_Cartao_Credito, Conn.Connection);

                    if (InsertOk)
                    {
                        Table_XmlInserted.Rows.Clear();
                        Table_XmlInserted.Rows.Add(nota.Cliente_Nome, nota.Debito_Credito, nota.Tipo_Transacao, nota.Status, nota.Tipo_Pagamento, nota.Valor_Bruto,
                                nota.Valor_Taxa, nota.Valor_Liquido, nota.Data_Transacao, nota.Data_Compensacao, nota.Bandeira_Cartao_Credito);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo!");
            }
        }

        private void Form_InsertXml_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.CloseConn();
        }

        private void Button_ShowAll_Click(object sender, EventArgs e)
        {
            foreach(NotasModerninha Nota in Notas)
            {
                Table_XmlInserted.Rows.Add(Nota.Cliente_Nome, Nota.Debito_Credito, Nota.Tipo_Transacao, Nota.Status, Nota.Tipo_Pagamento, Nota.Valor_Bruto,
                    Nota.Valor_Taxa, Nota.Valor_Liquido, Nota.Data_Transacao, Nota.Data_Compensacao, Nota.Bandeira_Cartao_Credito);
            }
        }
    }
}
