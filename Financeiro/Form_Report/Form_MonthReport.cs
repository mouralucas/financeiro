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
using Financeiro.DB_Manager;
using Financeiro.Connection;
using Financeiro.Form_Insert;

namespace Financeiro.Form_Report
{
    public partial class Form_MonthReport : Form
    {
        DB_Connection Conn = new DB_Connection();
        DB_Transaction DB_Transaction = new DB_Transaction();

        private List<Transaction> TransactionsByMonth;

        private int Selected_Id = -1;

        public Form_MonthReport()
        {
            InitializeComponent();
            Conn.OpenConn();
        }

        private void Form_MonthReport_Load(object sender, EventArgs e)
        {
            table_despesasMes.ClearSelection();
            table_receitasMes.ClearSelection();
            LoadData();
        }

        public void LoadData()
        {
            table_despesasMes.Rows.Clear();
            table_receitasMes.Rows.Clear();

            Selected_Id = -1;

            TransactionsByMonth = DB_Transaction.ListAll(DateTime.Now.Month, Conn.Connection);
            foreach(Transaction t in TransactionsByMonth)
            {
                table_despesasMes.Rows.Add(t.Transaction_Id, t.Category.Description,
                        "R$ " + string.Format("{0:0.00}", t.Value), "R$ " + string.Format("{0:0.00}", t.Reversal), 
                        t.PaymentForm.PaymentFormName, t.Date, t.PaymentDate, t.Observations);
            }

        }

        private void Table_DespesasMes_Click(object sender, EventArgs e)
        {
            Selected_Id = (int)(table_despesasMes.Rows[table_despesasMes.CurrentCell.RowIndex].Cells[0].Value);
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if(Selected_Id == -1)
            {
                MessageBox.Show("Selecione um registro", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Transaction t = TransactionsByMonth.Find(x => x.Transaction_Id == Selected_Id);
                Insert_Transaction transaction = new Insert_Transaction(this, t) { Visible = true };
                
            }
        }

        private void Form_MonthReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.CloseConn();
        }


    }
}
