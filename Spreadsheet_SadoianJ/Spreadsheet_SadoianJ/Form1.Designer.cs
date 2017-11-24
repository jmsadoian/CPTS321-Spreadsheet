namespace Spreadsheet_SadoianJ
{
    partial class Form1
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
            this.SpreadSheet = new System.Windows.Forms.DataGridView();
            this.DemoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // SpreadSheet
            // 
            this.SpreadSheet.AllowUserToAddRows = false;
            this.SpreadSheet.AllowUserToDeleteRows = false;
            this.SpreadSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SpreadSheet.Location = new System.Drawing.Point(0, 0);
            this.SpreadSheet.Name = "SpreadSheet";
            this.SpreadSheet.RowTemplate.Height = 40;
            this.SpreadSheet.Size = new System.Drawing.Size(1526, 1005);
            this.SpreadSheet.TabIndex = 0;
            // 
            // DemoButton
            // 
            this.DemoButton.Location = new System.Drawing.Point(0, 1017);
            this.DemoButton.Name = "DemoButton";
            this.DemoButton.Size = new System.Drawing.Size(1526, 80);
            this.DemoButton.TabIndex = 1;
            this.DemoButton.Text = "Click me to demo the spreadsheet";
            this.DemoButton.UseVisualStyleBackColor = true;
            this.DemoButton.Click += new System.EventHandler(this.DemoButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 1109);
            this.Controls.Add(this.DemoButton);
            this.Controls.Add(this.SpreadSheet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SpreadSheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SpreadSheet;
        private System.Windows.Forms.Button DemoButton;
    }
}

