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
        /*** DataBase Connection ***/
        DB_Connection Conn = new DB_Connection();
        DB_Transaction DB_Transaction = new DB_Transaction();

        /*** Lists ***/
        private List<Transaction> TransactionsByMonth;

        /*** Return Forms ***/
        private Form_InsertTransaction InsertTransactionForm = null;

        /*** Other Variables ***/
        private int Selected_Id = -1;

        /*** Main constructor ***/
        public Form_MonthReport()
        {
            InitializeComponent();
            Conn.OpenConn();
        }

        /*** Constructor from Insert Transaction Form ***/
        public Form_MonthReport(Form_InsertTransaction InsertTransactionForm)
        {
            InitializeComponent();
            Conn.OpenConn();

            this.InsertTransactionForm = InsertTransactionForm;
        }

        
        private void Form_MonthReport_Load(object sender, EventArgs e)
        {
            table_despesasMes.ClearSelection();
            Table_ReceitasMes.ClearSelection();
            LoadData();
        }

        public void LoadData()
        {
            table_despesasMes.Rows.Clear();
            Table_ReceitasMes.Rows.Clear();

            Selected_Id = -1;

            TransactionsByMonth = DB_Transaction.ListAll(DateTime.Now.Month, Conn.Connection);
            foreach (Transaction t in TransactionsByMonth.FindAll(x => x.Operation.Operation_Id == 1 || x.Operation.Operation_Id == 3))
            {
                table_despesasMes.Rows.Add(t.Transaction_Id, t.Category.Description,
                        "R$ " + string.Format("{0:0.00}", t.Value), "R$ " + string.Format("{0:0.00}", t.Reversal), 
                        t.PaymentForm.PaymentFormName, t.Date, t.PaymentDate, t.Observations);
            }

            foreach (Transaction t in TransactionsByMonth.FindAll(x => x.Operation.Operation_Id == 2))
            {
                Table_ReceitasMes.Rows.Add(t.Transaction_Id, t.Category.Description, "R$ " + string.Format("{0:0.00}", t.Value),
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
                Form_InsertTransaction transaction = new Form_InsertTransaction(this, t) { Visible = true };
                
            }
        }

        private void Form_MonthReport_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(InsertTransactionForm != null)
            {
                InsertTransactionForm.Visible = true;
            }

            Conn.CloseConn();
        }


    }
}
