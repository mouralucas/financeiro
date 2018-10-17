namespace Financeiro.Form_Insert
{
    partial class Form_Moderninha
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
            this.Text_FilePath = new System.Windows.Forms.TextBox();
            this.Button_SearchFile = new System.Windows.Forms.Button();
            this.button_import = new System.Windows.Forms.Button();
            this.Table_XmlInserted = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_ShowAll = new System.Windows.Forms.Button();
            this.Label_Debitos = new System.Windows.Forms.Label();
            this.Label_Credito = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Table_XmlInserted)).BeginInit();
            this.SuspendLayout();
            // 
            // Text_FilePath
            // 
            this.Text_FilePath.Location = new System.Drawing.Point(13, 13);
            this.Text_FilePath.Name = "Text_FilePath";
            this.Text_FilePath.Size = new System.Drawing.Size(333, 20);
            this.Text_FilePath.TabIndex = 0;
            // 
            // Button_SearchFile
            // 
            this.Button_SearchFile.Location = new System.Drawing.Point(352, 13);
            this.Button_SearchFile.Name = "Button_SearchFile";
            this.Button_SearchFile.Size = new System.Drawing.Size(67, 20);
            this.Button_SearchFile.TabIndex = 1;
            this.Button_SearchFile.Text = "Buscar";
            this.Button_SearchFile.UseVisualStyleBackColor = true;
            this.Button_SearchFile.Click += new System.EventHandler(this.Button_SearchFile_Click);
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(425, 12);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(75, 20);
            this.button_import.TabIndex = 2;
            this.button_import.Text = "Importar";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.Button_Import_Click);
            // 
            // Table_XmlInserted
            // 
            this.Table_XmlInserted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table_XmlInserted.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.Table_XmlInserted.Location = new System.Drawing.Point(13, 39);
            this.Table_XmlInserted.Name = "Table_XmlInserted";
            this.Table_XmlInserted.Size = new System.Drawing.Size(1178, 340);
            this.Table_XmlInserted.TabIndex = 4;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Nome Cliente";
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Débito/Crédito";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tipo Transaçao";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Status";
            this.Column5.Name = "Column5";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo de Pagamento";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Valor Bruto";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Valor Taxa";
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Valor Liquido";
            this.Column8.Name = "Column8";
            this.Column8.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Data Compra";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Data Compensação";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Bandeira Crédito";
            this.Column11.Name = "Column11";
            // 
            // Button_ShowAll
            // 
            this.Button_ShowAll.Location = new System.Drawing.Point(1019, 11);
            this.Button_ShowAll.Name = "Button_ShowAll";
            this.Button_ShowAll.Size = new System.Drawing.Size(172, 23);
            this.Button_ShowAll.TabIndex = 5;
            this.Button_ShowAll.Text = "Mostrar Tudo";
            this.Button_ShowAll.UseVisualStyleBackColor = true;
            this.Button_ShowAll.Click += new System.EventHandler(this.Button_ShowAll_Click);
            // 
            // Label_Debitos
            // 
            this.Label_Debitos.AutoSize = true;
            this.Label_Debitos.Location = new System.Drawing.Point(12, 382);
            this.Label_Debitos.Name = "Label_Debitos";
            this.Label_Debitos.Size = new System.Drawing.Size(70, 13);
            this.Label_Debitos.TabIndex = 6;
            this.Label_Debitos.Text = "Total Débitos";
            // 
            // Label_Credito
            // 
            this.Label_Credito.AutoSize = true;
            this.Label_Credito.Location = new System.Drawing.Point(12, 404);
            this.Label_Credito.Name = "Label_Credito";
            this.Label_Credito.Size = new System.Drawing.Size(72, 13);
            this.Label_Credito.TabIndex = 7;
            this.Label_Credito.Text = "Total Créditos";
            // 
            // Form_InsertXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 450);
            this.Controls.Add(this.Label_Credito);
            this.Controls.Add(this.Label_Debitos);
            this.Controls.Add(this.Button_ShowAll);
            this.Controls.Add(this.Table_XmlInserted);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.Button_SearchFile);
            this.Controls.Add(this.Text_FilePath);
            this.Name = "Form_InsertXml";
            this.Text = "Form_InsertXml";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_InsertXml_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Table_XmlInserted)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_FilePath;
        private System.Windows.Forms.Button Button_SearchFile;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.DataGridView Table_XmlInserted;
        private System.Windows.Forms.Button Button_ShowAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Label Label_Debitos;
        private System.Windows.Forms.Label Label_Credito;
    }
}