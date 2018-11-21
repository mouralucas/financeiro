using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Financeiro.Connection;
using Financeiro.DB_Manager;
using Financeiro.Form_Report;
using Financeiro.Entities;
using Financeiro.Util;
using Financeiro.Files;

namespace Financeiro.Form_Insert
{
    public partial class Form_Transaction : Form
    {

        DB_Connection Conn = new DB_Connection();
        /*** Database Manager ***/
        DB_Operation DB_Operacao = new DB_Operation();
        DB_Category DB_Category = new DB_Category();
        DB_PaymentForm DB_PaymentForm = new DB_PaymentForm();
        DB_Transaction DB_Transaction = new DB_Transaction();

        /*** Information Lists ***/
        List<Operation> OperationList;
        List<Category> CategoryList;
        List<PaymentForm> PaymentFormList;

        /*** O = insert; 1 = update; ***/
        private int OperationType = 0;
        private int Transaction_Id;

        private bool InsertOk = false;
        private bool UpdateOk = false;
        private bool Initializing = false;

        /*** Return Forms ***/
        private Form_MonthReport ReturnMonthReport = null;

        /*** Report Forms ***/
        Form_MonthReport MonthlyReportForm;
        Form_Moderninha InsertXml;


        /*** Main Constructor ***/
        public Form_Transaction()
        {
            InitializeComponent();
            Conn.OpenConn();
            LoadData();
            SetPaymentDate();

            OperationType = 0;
        }

        /*** Constructor for Update ***/
        public Form_Transaction(Form_MonthReport ReturnMonthReport, Transaction t)
        {
            Initializing = true;

            InitializeComponent();
            Conn.OpenConn();
            LoadData();

            this.ReturnMonthReport = ReturnMonthReport;

            OperationType = 1;
            Button_Transaction.Text = "Atualizar";
            Button_Extorno.Visible = true;


            Box_Operacao.SelectedValue = t.Operation.Operation_Id;
            SetGroupBox();
            Box_Group.SelectedValue = t.Category.Id_Pai;
            SetCategoryBox();
            Box_Category.SelectedValue = t.Category.Category_Id;
            Text_Valor.Text = string.Format("{0:0.00}", t.Value);
            Box_PaymentForm.SelectedValue = t.PaymentForm.PaymentForm_Id;
            DatePicker_Data.Text = t.Date;
            DatePicker_DataPagamento.Text = t.PaymentDate;
            Box_NumeroParcela.SelectedIndex = t.NInstallment - 1;
            Box_QuantidadeParcelas.SelectedIndex = t.Installment - 1;
            Text_Obs.Text = t.Observations;
            Transaction_Id = t.Transaction_Id;

            Initializing = false;
        }

        private void Insert_Transaction_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            Box_NumeroParcela.SelectedIndex = 0;
            Box_QuantidadeParcelas.SelectedIndex = 0;

            GetOperationInfo();
            GetCategoryInfo();
            GetPaymentFormInfo();
        }


        /*** Comboboxes ***/
        private void Box_Operacao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetGroupBox();
            SetCategoryBox();
        }

        private void Box_PaymentForm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetPaymentDate();
        }

        private void Box_NumeroParcela_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if ((Box_NumeroParcela.SelectedIndex) > (Box_QuantidadeParcelas.SelectedIndex))
            {
                Box_NumeroParcela.SelectedIndex = Box_QuantidadeParcelas.SelectedIndex;
            }


            SetPaymentDate();
        }

        private void Box_Grupo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetCategoryBox();
        }

        /*** Buttons ***/
        private void Button_Transaction_Click(object sender, EventArgs e)
        {
            if (OperationType == 0)
            {
                SaveTransaction();
            }
            else if (OperationType == 1)
            {
                UpdateTransaction();
            }
            else
            {
                MessageBox.Show("Esta operação veio de uma janela não prevista", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_Extorno_Click(object sender, EventArgs e)
        {

        }

        private void DatePicker_Data_ValueChanged(object sender, EventArgs e)
        {
            SetPaymentDate();
        }

        /*** Transaction Operations ***/
        private void SaveTransaction()
        {
            if (Text_Valor.Text.Equals(""))
            {
                MessageBox.Show("Você Deve Preencher o Valor!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToInt32(Box_NumeroParcela.SelectedItem) > Convert.ToInt32(Box_QuantidadeParcelas.SelectedItem))
            {
                MessageBox.Show("O número da parcela não pode ser maior que a quantidade de parcelas!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                InsertOk = DB_Transaction.InsertTransaction((int)Box_Operacao.SelectedValue, Convert.ToDouble(Text_Valor.Text.Replace(",", ".")),
                    (int)Box_PaymentForm.SelectedValue, DatePicker_DataPagamento.Text, DatePicker_Data.Text, (int)Box_Category.SelectedValue,
                    Convert.ToInt32(Box_NumeroParcela.SelectedItem), Convert.ToInt32(Box_QuantidadeParcelas.SelectedItem), Text_Obs.Text,
                    Conn.Connection);

                if (InsertOk)
                {
                    SetOperationBox();
                    SetGroupBox();
                    SetCategoryBox();
                    SetPaymentFormBox();

                    Box_NumeroParcela.SelectedIndex = 0;
                    Box_QuantidadeParcelas.SelectedIndex = 0;

                    Text_Valor.Text = string.Empty;
                    Text_Obs.Text = string.Empty;

                    DatePicker_Data.Value = System.DateTime.Now;
                }
            }
        }

        private void UpdateTransaction()
        {
            if (Text_Valor.Text.Equals(""))
            {
                MessageBox.Show("Você Deve Preencher o Valor!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (Convert.ToInt32(Box_NumeroParcela.SelectedItem) > Convert.ToInt32(Box_QuantidadeParcelas.SelectedItem))
            {
                MessageBox.Show("O número da parcela não pode ser maior que a quantidade de parcelas!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UpdateOk = DB_Transaction.UpdateTransaction(Transaction_Id, (int)Box_Operacao.SelectedValue, Convert.ToDouble(Text_Valor.Text.Replace(",", ".")), 0.0,
                   (int)Box_PaymentForm.SelectedValue, DatePicker_DataPagamento.Text, DatePicker_Data.Text, (int)Box_Category.SelectedValue,
                   Convert.ToInt32(Box_NumeroParcela.SelectedItem), Convert.ToInt32(Box_QuantidadeParcelas.SelectedItem), Text_Obs.Text,
                   Conn.Connection);
            }


        }

        /*** Combobox setups ***/
        public void GetOperationInfo()
        {
            OperationList = DB_Operacao.ListAll(Conn.Connection);
            SetOperationBox();
        }

        private void SetOperationBox()
        {
            Box_Operacao.DataSource = null;
            Box_Operacao.DataSource = OperationList;
            Box_Operacao.ValueMember = "Operation_Id";
            Box_Operacao.DisplayMember = "OperationName";

        }

        public void GetCategoryInfo()
        {
            CategoryList = DB_Category.ListAll(Conn.Connection);

            SetGroupBox();
            SetCategoryBox();
        }

        private void SetGroupBox()
        {
            Box_Group.DataSource = null;
            Box_Group.DataSource = CategoryList.FindAll(x => x.Id_Pai == 0 && x.Operation.Operation_Id == (int)Box_Operacao.SelectedValue);
            Box_Group.ValueMember = "Category_Id";
            Box_Group.DisplayMember = "Description";

        }

        private void SetCategoryBox()
        {
            Box_Category.DataSource = null;
            Box_Category.DataSource = CategoryList.FindAll(x => x.Id_Pai == (int)Box_Group.SelectedValue);
            Box_Category.ValueMember = "Category_Id";
            Box_Category.DisplayMember = "Description";
        }

        public void GetPaymentFormInfo()
        {
            PaymentFormList = DB_PaymentForm.ListAll(Conn.Connection);
            SetPaymentFormBox();
        }

        private void SetPaymentFormBox()
        {
            Box_PaymentForm.DataSource = null;
            Box_PaymentForm.DataSource = PaymentFormList;
            Box_PaymentForm.ValueMember = "PaymentForm_Id";
            Box_PaymentForm.DisplayMember = "PaymentFormName";
        }


        /*** Datepickes setup ***/
        private void SetPaymentDate()
        {
            if (!Initializing)
            {
                if ((int)Box_PaymentForm.SelectedValue == 2)
                {
                    int mesPagamento;
                    int anoPagamento;

                    int dia = Convert.ToInt32(DatePicker_Data.Text.Split('/')[2]);
                    int mes = Convert.ToInt32(DatePicker_Data.Text.Split('/')[1]);
                    int ano = Convert.ToInt32(DatePicker_Data.Text.Split('/')[0]);

                    int parcela = Convert.ToInt32(Box_NumeroParcela.SelectedItem.ToString());

                    if (dia < 13)
                    {
                        if ((mes + parcela - 1) > 12)
                        {
                            mesPagamento = (mes + parcela - 1) - 12;
                            anoPagamento = ano + 1;
                        }
                        else
                        {
                            mesPagamento = (mes + parcela - 1);
                            anoPagamento = ano;
                        }

                        DatePicker_DataPagamento.Text = anoPagamento.ToString() + "/" + Util.Format.FillString(mesPagamento) + "/20";
                    }
                    else
                    {
                        if ((mes + parcela) > 12)
                        {
                            mesPagamento = (mes + parcela) - 12;
                            anoPagamento = ano + 1;
                        }
                        else
                        {
                            mesPagamento = (mes + parcela);
                            anoPagamento = ano;
                        }

                        DatePicker_DataPagamento.Text = anoPagamento.ToString() + "/" + Util.Format.FillString(mesPagamento) + "/20";
                    }
                }
                else
                {
                    DatePicker_DataPagamento.Text = DatePicker_Data.Text;
                }
            }
        }

        /*** Closing form operations ***/
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult close = MessageBox.Show("Deseja mesmo sair? Informações não salvas serão perdidas!",
                "Atenção!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            if (close == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Insert_Transaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ReturnMonthReport != null)
            {
                ReturnMonthReport.LoadData();
            }

            Conn.CloseConn();
        }

        /*** Menus ***/
        private void DespesasPorMêsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyReportForm = new Form_MonthReport(this) { Visible = true };
        }

        private void XmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertXml = new Form_Moderninha() { Visible = true };
        }

    }
}
