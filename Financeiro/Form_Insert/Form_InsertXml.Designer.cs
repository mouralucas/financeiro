namespace Financeiro.Form_Insert
{
    partial class Form_InsertXml
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
            this.SuspendLayout();
            // 
            // Text_FilePath
            // 
            this.Text_FilePath.Location = new System.Drawing.Point(13, 13);
            this.Text_FilePath.Name = "Text_FilePath";
            this.Text_FilePath.Size = new System.Drawing.Size(219, 20);
            this.Text_FilePath.TabIndex = 0;
            // 
            // Button_SearchFile
            // 
            this.Button_SearchFile.Location = new System.Drawing.Point(238, 13);
            this.Button_SearchFile.Name = "Button_SearchFile";
            this.Button_SearchFile.Size = new System.Drawing.Size(67, 20);
            this.Button_SearchFile.TabIndex = 1;
            this.Button_SearchFile.Text = "Buscar";
            this.Button_SearchFile.UseVisualStyleBackColor = true;
            this.Button_SearchFile.Click += new System.EventHandler(this.Button_SearchFile_Click);
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(311, 13);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(75, 20);
            this.button_import.TabIndex = 2;
            this.button_import.Text = "Importar";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.Button_Import_Click);
            // 
            // Form_InsertXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 450);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.Button_SearchFile);
            this.Controls.Add(this.Text_FilePath);
            this.Name = "Form_InsertXml";
            this.Text = "Form_InsertXml";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_InsertXml_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_FilePath;
        private System.Windows.Forms.Button Button_SearchFile;
        private System.Windows.Forms.Button button_import;
    }
}