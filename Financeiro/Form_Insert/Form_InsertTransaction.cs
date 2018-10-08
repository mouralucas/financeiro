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
    public partial class Form_InsertTransaction : Form
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

        /*** Return Forms ***/
        private Form_MonthReport ReturnMonthReport = null;

        /*** Report Forms ***/
        Form_MonthReport MonthlyReportForm;
        Form_InsertXml InsertXml;


        /*** Main Constructor ***/
        public Form_InsertTransaction()
        {
            InitializeComponent();
            Conn.OpenConn();
            LoadData();

            OperationType = 0;
        }

        /*** Constructor for Update ***/
        public Form_InsertTransaction(Form_MonthReport ReturnMonthReport, Transaction t)
        {
            InitializeComponent();
            Conn.OpenConn();
            LoadData();

            this.ReturnMonthReport = ReturnMonthReport;

            OperationType = 1;
            Button_Transaction.Text = "Atualizar";
            Button_Extorno.Visible = true;

            Box_Operacao.SelectedValue = t.Operation.Operation_Id;
            Box_Group.SelectedValue = t.Category.Id_Pai;
            Box_Category.SelectedValue = t.Category.Category_Id;
            Text_Valor.Text = string.Format("{0:0.00}", t.Value);
            Box_PaymentForm.SelectedValue = t.PaymentForm.PaymentForm_Id;
            DatePicker_Data.Text = t.Date;
            Box_NParcela.SelectedIndex = t.NInstallment - 1;
            Box_Parcelas.SelectedIndex = t.Installment - 1;
            Text_Obs.Text = t.Observations;
            Transaction_Id = t.Transaction_Id;

        }

        private void Insert_Transaction_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            Box_NParcela.SelectedIndex = 0;
            Box_Parcelas.SelectedIndex = 0;

            GetOperationInfo();
            GetCategoryInfo();
            GetPaymentFormInfo();
        }

        private void Box_Operacao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetGroupBox();
            SetCategoryBox();
        }

        private void Box_Grupo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetCategoryBox();
        }

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

        /*** Transaction Operations ***/
        private void SaveTransaction()
        {
            if (Text_Valor.Text.Equals(""))
            {
                MessageBox.Show("Você Deve Preencher o Valor!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToInt32(Box_NParcela.SelectedItem) > Convert.ToInt32(Box_Parcelas.SelectedItem))
            {
                MessageBox.Show("O número da parcela não pode ser maior que a quantidade de parcelas!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                String dt_pag = "";
                if ((int)Box_PaymentForm.SelectedValue == 2)
                {
                    int dia = Convert.ToInt32(DatePicker_Data.Text.Split('/')[2]);
                    int mes = Convert.ToInt32(DatePicker_Data.Text.Split('/')[1]);
                    int ano = Convert.ToInt32(DatePicker_Data.Text.Split('/')[0]);

                    int parcela = Convert.ToInt32(Box_NParcela.SelectedItem.ToString());

                    if (dia < 13)
                    {
                        dt_pag = ano.ToString() + "/" + Util.DateTime.DateFormat(mes + parcela - 1) + "/20";
                    }
                    else
                    {
                        if (mes != 12)
                        {
                            dt_pag = ano.ToString() + "/" + Util.DateTime.DateFormat(mes + parcela) + "/20";
                        }
                        else
                        {
                            dt_pag = (ano + 1).ToString() + "/" + Util.DateTime.DateFormat(mes + parcela) + "/20";
                        }
                    }
                }
                else
                {
                    dt_pag = DatePicker_Data.Text;
                }

                InsertOk = DB_Transaction.InsertTransaction((int)Box_Operacao.SelectedValue, Convert.ToDouble(Text_Valor.Text.Replace(",", ".")),
                    (int)Box_PaymentForm.SelectedValue, dt_pag, DatePicker_Data.Text, (int)Box_Category.SelectedValue,
                    Convert.ToInt32(Box_NParcela.SelectedItem), Convert.ToInt32(Box_Parcelas.SelectedItem), Text_Obs.Text,
                    Conn.Connection);

                if (InsertOk)
                {
                    SetOperationBox();
                    SetGroupBox();
                    SetCategoryBox();
                    SetPaymentFormBox();

                    Box_NParcela.SelectedIndex = 0;
                    Box_Parcelas.SelectedIndex = 0;

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
            if (Convert.ToInt32(Box_NParcela.SelectedItem) > Convert.ToInt32(Box_Parcelas.SelectedItem))
            {
                MessageBox.Show("O número da parcela não pode ser maior que a quantidade de parcelas!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                String dt_pag = "";
                if ((int)Box_PaymentForm.SelectedValue == 2)
                {
                    int dia = Convert.ToInt32(DatePicker_Data.Text.Split('/')[2]);
                    int mes = Convert.ToInt32(DatePicker_Data.Text.Split('/')[1]);
                    int ano = Convert.ToInt32(DatePicker_Data.Text.Split('/')[0]);

                    int parcela = Convert.ToInt32(Box_NParcela.SelectedItem.ToString());

                    if (dia < 13)
                    {
                        dt_pag = ano.ToString() + "/" + Util.DateTime.DateFormat(mes + parcela - 1) + "/20";
                    }
                    else
                    {
                        if (mes != 12)
                        {
                            dt_pag = ano.ToString() + "/" + Util.DateTime.DateFormat(mes + parcela) + "/20";
                        }
                        else
                        {
                            dt_pag = (ano + 1).ToString() + "/" + Util.DateTime.DateFormat(mes + parcela) + "/20";
                        }
                    }
                }
                else
                {
                    dt_pag = DatePicker_Data.Text;
                }

                UpdateOk = DB_Transaction.UpdateTransaction(Transaction_Id, (int)Box_Operacao.SelectedValue, Convert.ToDouble(Text_Valor.Text.Replace(",", ".")), 0.0,
                   (int)Box_PaymentForm.SelectedValue, dt_pag, DatePicker_Data.Text, (int)Box_Category.SelectedValue,
                   Convert.ToInt32(Box_NParcela.SelectedItem), Convert.ToInt32(Box_Parcelas.SelectedItem), Text_Obs.Text,
                   Conn.Connection);
            }


        }

        /*** Combobox Operations ***/
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
            InsertXml = new Form_InsertXml() { Visible = true };
        }
    }
}
