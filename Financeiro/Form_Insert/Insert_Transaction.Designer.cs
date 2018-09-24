namespace Financeiro.Form_Insert
{
    partial class Insert_Transaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Box_Operacao = new System.Windows.Forms.ComboBox();
            this.Box_Group = new System.Windows.Forms.ComboBox();
            this.Box_Category = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_Valor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Box_PaymentForm = new System.Windows.Forms.ComboBox();
            this.DatePicker_Data = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.Box_NParcela = new System.Windows.Forms.ComboBox();
            this.Box_Parcelas = new System.Windows.Forms.ComboBox();
            this.Text_Obs = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_Transaction = new System.Windows.Forms.Button();
            this.Button_Extorno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Box_Operacao
            // 
            this.Box_Operacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Box_Operacao.FormattingEnabled = true;
            this.Box_Operacao.Location = new System.Drawing.Point(12, 25);
            this.Box_Operacao.Name = "Box_Operacao";
            this.Box_Operacao.Size = new System.Drawing.Size(125, 21);
            this.Box_Operacao.TabIndex = 0;
            this.Box_Operacao.SelectionChangeCommitted += new System.EventHandler(this.Box_Operacao_SelectionChangeCommitted);
            // 
            // Box_Group
            // 
            this.Box_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Box_Group.FormattingEnabled = true;
            this.Box_Group.Location = new System.Drawing.Point(143, 25);
            this.Box_Group.Name = "Box_Group";
            this.Box_Group.Size = new System.Drawing.Size(151, 21);
            this.Box_Group.TabIndex = 1;
            this.Box_Group.SelectionChangeCommitted += new System.EventHandler(this.Box_Grupo_SelectionChangeCommitted);
            // 
            // Box_Category
            // 
            this.Box_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Box_Category.FormattingEnabled = true;
            this.Box_Category.Location = new System.Drawing.Point(300, 25);
            this.Box_Category.Name = "Box_Category";
            this.Box_Category.Size = new System.Drawing.Size(152, 21);
            this.Box_Category.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Valor";
            // 
            // Text_Valor
            // 
            this.Text_Valor.Location = new System.Drawing.Point(12, 76);
            this.Text_Valor.Name = "Text_Valor";
            this.Text_Valor.Size = new System.Drawing.Size(97, 20);
            this.Text_Valor.TabIndex = 3;
            this.Text_Valor.Text = "9999,99";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Operação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Categoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Grupo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pagamento";
            // 
            // Box_PaymentForm
            // 
            this.Box_PaymentForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Box_PaymentForm.FormattingEnabled = true;
            this.Box_PaymentForm.Location = new System.Drawing.Point(115, 76);
            this.Box_PaymentForm.Name = "Box_PaymentForm";
            this.Box_PaymentForm.Size = new System.Drawing.Size(104, 21);
            this.Box_PaymentForm.TabIndex = 4;
            // 
            // DatePicker_Data
            // 
            this.DatePicker_Data.CustomFormat = "yyyy/MM/dd";
            this.DatePicker_Data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePicker_Data.Location = new System.Drawing.Point(225, 76);
            this.DatePicker_Data.Name = "DatePicker_Data";
            this.DatePicker_Data.Size = new System.Drawing.Size(85, 20);
            this.DatePicker_Data.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Data";
            // 
            // Box_NParcela
            // 
            this.Box_NParcela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Box_NParcela.FormattingEnabled = true;
            this.Box_NParcela.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.Box_NParcela.Location = new System.Drawing.Point(316, 76);
            this.Box_NParcela.Name = "Box_NParcela";
            this.Box_NParcela.Size = new System.Drawing.Size(65, 21);
            this.Box_NParcela.TabIndex = 6;
            // 
            // Box_Parcelas
            // 
            this.Box_Parcelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Box_Parcelas.FormattingEnabled = true;
            this.Box_Parcelas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.Box_Parcelas.Location = new System.Drawing.Point(387, 76);
            this.Box_Parcelas.Name = "Box_Parcelas";
            this.Box_Parcelas.Size = new System.Drawing.Size(65, 21);
            this.Box_Parcelas.TabIndex = 7;
            // 
            // Text_Obs
            // 
            this.Text_Obs.Location = new System.Drawing.Point(12, 125);
            this.Text_Obs.Name = "Text_Obs";
            this.Text_Obs.Size = new System.Drawing.Size(440, 96);
            this.Text_Obs.TabIndex = 8;
            this.Text_Obs.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Data";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Parcela";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(384, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "De";
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(336, 227);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(116, 23);
            this.Button_Cancel.TabIndex = 18;
            this.Button_Cancel.Text = "Sair";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Button_Transaction
            // 
            this.Button_Transaction.Location = new System.Drawing.Point(214, 227);
            this.Button_Transaction.Name = "Button_Transaction";
            this.Button_Transaction.Size = new System.Drawing.Size(116, 23);
            this.Button_Transaction.TabIndex = 19;
            this.Button_Transaction.Text = "Salvar";
            this.Button_Transaction.UseVisualStyleBackColor = true;
            this.Button_Transaction.Click += new System.EventHandler(this.Button_Transaction_Click);
            // 
            // Button_Extorno
            // 
            this.Button_Extorno.Location = new System.Drawing.Point(12, 227);
            this.Button_Extorno.Name = "Button_Extorno";
            this.Button_Extorno.Size = new System.Drawing.Size(116, 23);
            this.Button_Extorno.TabIndex = 20;
            this.Button_Extorno.Text = "Estornar Valor";
            this.Button_Extorno.UseVisualStyleBackColor = true;
            this.Button_Extorno.Visible = false;
            // 
            // Insert_Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 261);
            this.Controls.Add(this.Button_Extorno);
            this.Controls.Add(this.Button_Transaction);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Text_Obs);
            this.Controls.Add(this.Box_Parcelas);
            this.Controls.Add(this.Box_NParcela);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DatePicker_Data);
            this.Controls.Add(this.Box_PaymentForm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Text_Valor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Box_Category);
            this.Controls.Add(this.Box_Group);
            this.Controls.Add(this.Box_Operacao);
            this.Name = "Insert_Transaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert_Transaction";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Insert_Transaction_FormClosing);
            this.Load += new System.EventHandler(this.Insert_Transaction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Box_Operacao;
        private System.Windows.Forms.ComboBox Box_Group;
        private System.Windows.Forms.ComboBox Box_Category;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Text_Valor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Box_PaymentForm;
        private System.Windows.Forms.DateTimePicker DatePicker_Data;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Box_NParcela;
        private System.Windows.Forms.ComboBox Box_Parcelas;
        private System.Windows.Forms.RichTextBox Text_Obs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_Transaction;
        private System.Windows.Forms.Button Button_Extorno;
    }
}