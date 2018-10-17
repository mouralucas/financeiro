﻿using System;
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
        private List<Transaction> MonthlyTransactions = new List<Transaction>();

        /*** Return Forms ***/
        private Form_Transaction InsertTransactionForm = null;

        /*** Other Variables ***/
        private int Selected_Id = -1;

        /*** Main constructor ***/
        public Form_MonthReport()
        {
            InitializeComponent();
            Conn.OpenConn();
        }

        /*** Constructor from Insert Transaction Form ***/
        public Form_MonthReport(Form_Transaction InsertTransactionForm)
        {
            InitializeComponent();
            Conn.OpenConn();

            this.InsertTransactionForm = InsertTransactionForm;
        }

        
        private void Form_MonthReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            Table_Despesas.Rows.Clear();
            Table_Receitas.Rows.Clear();

            Selected_Id = -1;

            Box_Month.SelectedIndex = DateTime.Now.Month - 1;

            MonthlyTransactions.Clear();
            MonthlyTransactions = DB_Transaction.ListAll(DateTime.Now.Month, Conn.Connection);
            SetTableDespesa();
            SetTableReceita();


        }

        private void Table_DespesasMes_Click(object sender, EventArgs e)
        {
            Selected_Id = (int)(Table_Despesas.Rows[Table_Despesas.CurrentCell.RowIndex].Cells[0].Value);
        }

        private void Table_ReceitasMes_Click(object sender, EventArgs e)
        {
            Selected_Id = (int)(Table_Receitas.Rows[Table_Receitas.CurrentCell.RowIndex].Cells[0].Value);
        }

        private void Box_Month_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MonthlyTransactions.Clear();
            MonthlyTransactions = DB_Transaction.ListAll(Box_Month.SelectedIndex+1, Conn.Connection);
            SetTableDespesa();
            SetTableReceita();
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if(Selected_Id == -1)
            {
                MessageBox.Show("Selecione um registro", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Transaction t = MonthlyTransactions.Find(x => x.Transaction_Id == Selected_Id);
                Form_Transaction transaction = new Form_Transaction(this, t) { Visible = true };
                
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

        /*** Table operations ***/
        private void SetTableDespesa()
        {
            Table_Despesas.Rows.Clear();
            Table_Despesas.ClearSelection();
            foreach (Transaction t in MonthlyTransactions.FindAll(x => x.Operation.Operation_Id == 1 || x.Operation.Operation_Id == 3))
            {
                Table_Despesas.Rows.Add(t.Transaction_Id, t.Category.Description,
                        "R$ " + string.Format("{0:0.00}", t.Value), "R$ " + string.Format("{0:0.00}", t.Reversal),
                        t.PaymentForm.PaymentFormName, t.Date, t.PaymentDate, t.Observations);
            }
        }

        private void SetTableReceita()
        {
            Table_Receitas.Rows.Clear();
            Table_Receitas.ClearSelection();
            foreach (Transaction t in MonthlyTransactions.FindAll(x => x.Operation.Operation_Id == 2))
            {
                Table_Receitas.Rows.Add(t.Transaction_Id, t.Category.Description, "R$ " + string.Format("{0:0.00}", t.Value),
                    t.PaymentForm.PaymentFormName, t.Date, t.PaymentDate, t.Observations);
            }
        }
    }
}
