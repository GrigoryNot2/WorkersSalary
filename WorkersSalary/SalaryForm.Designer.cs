
namespace WorkersSalary
{
    partial class SalaryForm
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
            this.MonthLbl = new System.Windows.Forms.Label();
            this.AmountLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.AmountTb = new System.Windows.Forms.TextBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // MonthLbl
            // 
            this.MonthLbl.AutoSize = true;
            this.MonthLbl.Location = new System.Drawing.Point(11, 83);
            this.MonthLbl.Name = "MonthLbl";
            this.MonthLbl.Size = new System.Drawing.Size(57, 20);
            this.MonthLbl.TabIndex = 11;
            this.MonthLbl.Text = "Месяц:";
            // 
            // AmountLbl
            // 
            this.AmountLbl.AutoSize = true;
            this.AmountLbl.Location = new System.Drawing.Point(11, 15);
            this.AmountLbl.Name = "AmountLbl";
            this.AmountLbl.Size = new System.Drawing.Size(123, 20);
            this.AmountLbl.TabIndex = 10;
            this.AmountLbl.Text = "Сумма выплаты:";
            // 
            // CancelBtn
            // 
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(267, 172);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CancelBtn.Size = new System.Drawing.Size(94, 33);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.AutoSize = true;
            this.SaveBtn.Location = new System.Drawing.Point(11, 172);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.SaveBtn.Size = new System.Drawing.Size(113, 33);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // AmountTb
            // 
            this.AmountTb.Location = new System.Drawing.Point(11, 39);
            this.AmountTb.Name = "AmountTb";
            this.AmountTb.Size = new System.Drawing.Size(350, 27);
            this.AmountTb.TabIndex = 6;
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(11, 105);
            this.monthComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(350, 28);
            this.monthComboBox.TabIndex = 7;
            // 
            // SalaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 219);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.MonthLbl);
            this.Controls.Add(this.AmountLbl);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.AmountTb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SalaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SalaryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MonthLbl;
        private System.Windows.Forms.Label AmountLbl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveBtn;
        //private System.Windows.Forms.TextBox MonthTb;
        private System.Windows.Forms.TextBox AmountTb;
        private System.Windows.Forms.ComboBox monthComboBox;
    }
}