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
using Financeiro.Entities;
using Financeiro.Util;

namespace Financeiro.Form_Insert
{
    public partial class Insert_Transaction : Form
    {

        DB_Connection Conn = new DB_Connection();
        /*** Database Manager ***/
        DB_Operation DB_Operacao = new DB_Operation();
        DB_Category DB_Category = new DB_Category();
        DB_PaymentForm DB_PaymentForm = new DB_PaymentForm();


        /*** Information List ***/
        List<Operation> OperationList;
        List<Category> CategoryList;
        List<PaymentForm> PaymentFormList;

        /*
        O = insert
        1 = update
        */
        private int OperationType = 0;

        private bool InsertOk = false;
        private bool UpdateOk = false;


        /*** Main Constructor ***/
        public Insert_Transaction()
        {
            InitializeComponent();
            Conn.OpenConn();
        }

        /*** Constructor for Update ***/
        public Insert_Transaction(Form Generic_Return)
        {
            InitializeComponent();
            Conn.OpenConn();

            OperationType = 1;
            Button_Transaction.Text = "Atualizar";
            Button_Extorno.Visible = true;
        }

        private void Insert_Transaction_Load(object sender, EventArgs e)
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
                //UpdateTransaction();
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
            else
            {
                String dt_pag = "";
                if((int)Box_PaymentForm.SelectedValue == 2)
                {
                    int dia = Convert.ToInt32(DatePicker_Data.Text.Split('/')[2]);
                    int mes = Convert.ToInt32(DatePicker_Data.Text.Split('/')[1]);
                    int ano = Convert.ToInt32(DatePicker_Data.Text.Split('/')[0]);

                    if (dia < 13)
                    {
                        dt_pag = ano.ToString() + "/" + Format.DateFormat(mes) + "/20";
                    }
                    else
                    {
                        if (mes != 12)
                        {
                            dt_pag = ano.ToString() + "/" + Format.DateFormat(mes + 1) + "/20";
                        }
                        else
                        {
                            dt_pag = "20/" + (mes + 1) + "/" + (ano + 1).ToString();
                        }
                    }
                }
                else
                {
                    dt_pag = DatePicker_Data.Text;
                }

                
            }
        }


        /*** Combobox Operations ***/
        public void GetOperationInfo()
        {
            OperationList = DB_Operacao.ListAll(Conn.Connection);
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

        private void Insert_Transaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.CloseConn();
        }


    }
}
