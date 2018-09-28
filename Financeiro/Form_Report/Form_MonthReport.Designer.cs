﻿namespace Financeiro.Form_Report
{
    partial class Form_MonthReport
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
            this.table_despesasMes = new System.Windows.Forms.DataGridView();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Estorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_formaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DataPag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.box_month = new System.Windows.Forms.ComboBox();
            this.table_receitasMes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_obss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_edit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.table_despesasMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_receitasMes)).BeginInit();
            this.SuspendLayout();
            // 
            // table_despesasMes
            // 
            this.table_despesasMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_despesasMes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Id,
            this.Column_Categoria,
            this.Column_Valor,
            this.Column_Estorno,
            this.Column_formaPagamento,
            this.Column_data,
            this.Column_DataPag,
            this.Column_obs});
            this.table_despesasMes.Location = new System.Drawing.Point(12, 33);
            this.table_despesasMes.Name = "table_despesasMes";
            this.table_despesasMes.Size = new System.Drawing.Size(928, 279);
            this.table_despesasMes.TabIndex = 1;
            this.table_despesasMes.Click += new System.EventHandler(this.Table_DespesasMes_Click);
            // 
            // Column_Id
            // 
            this.Column_Id.HeaderText = "Id";
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Id.Width = 50;
            // 
            // Column_Categoria
            // 
            this.Column_Categoria.HeaderText = "Categoria";
            this.Column_Categoria.Name = "Column_Categoria";
            this.Column_Categoria.Width = 180;
            // 
            // Column_Valor
            // 
            this.Column_Valor.HeaderText = "Valor";
            this.Column_Valor.Name = "Column_Valor";
            this.Column_Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column_Valor.Width = 90;
            // 
            // Column_Estorno
            // 
            this.Column_Estorno.HeaderText = "Estorno";
            this.Column_Estorno.Name = "Column_Estorno";
            this.Column_Estorno.Width = 90;
            // 
            // Column_formaPagamento
            // 
            this.Column_formaPagamento.HeaderText = "Forma de Pagamento";
            this.Column_formaPagamento.Name = "Column_formaPagamento";
            this.Column_formaPagamento.Width = 120;
            // 
            // Column_data
            // 
            this.Column_data.HeaderText = "Data";
            this.Column_data.Name = "Column_data";
            this.Column_data.Width = 110;
            // 
            // Column_DataPag
            // 
            this.Column_DataPag.HeaderText = "Data do Pagamento";
            this.Column_DataPag.Name = "Column_DataPag";
            this.Column_DataPag.Width = 110;
            // 
            // Column_obs
            // 
            this.Column_obs.HeaderText = "Observações";
            this.Column_obs.Name = "Column_obs";
            this.Column_obs.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Detalhamento das despesas e receitas do mes de:";
            // 
            // box_month
            // 
            this.box_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_month.FormattingEnabled = true;
            this.box_month.Location = new System.Drawing.Point(263, 6);
            this.box_month.Name = "box_month";
            this.box_month.Size = new System.Drawing.Size(145, 21);
            this.box_month.TabIndex = 4;
            // 
            // table_receitasMes
            // 
            this.table_receitasMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_receitasMes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column_obss});
            this.table_receitasMes.Location = new System.Drawing.Point(12, 318);
            this.table_receitasMes.Name = "table_receitasMes";
            this.table_receitasMes.Size = new System.Drawing.Size(928, 126);
            this.table_receitasMes.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Forma de Pagamento";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Data";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 110;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Data do Pagamento";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 110;
            // 
            // Column_obss
            // 
            this.Column_obss.HeaderText = "Observação";
            this.Column_obss.Name = "Column_obss";
            this.Column_obss.Width = 120;
            // 
            // button_edit
            // 
            this.button_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_edit.Location = new System.Drawing.Point(946, 421);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(181, 23);
            this.button_edit.TabIndex = 15;
            this.button_edit.Text = "Editar Registro Selecionado";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // Form_MonthReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 455);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.table_receitasMes);
            this.Controls.Add(this.box_month);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.table_despesasMes);
            this.Name = "Form_MonthReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_MonthReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MonthReport_FormClosing);
            this.Load += new System.EventHandler(this.Form_MonthReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_despesasMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_receitasMes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table_despesasMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Estorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_formaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DataPag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_obs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox box_month;
        private System.Windows.Forms.DataGridView table_receitasMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_obss;
        private System.Windows.Forms.Button button_edit;
    }
}