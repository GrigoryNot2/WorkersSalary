
namespace WorkersSalary
{
    partial class WorkerForm
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
            this.TnTb = new System.Windows.Forms.TextBox();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.TnLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TnTb
            // 
            this.TnTb.Location = new System.Drawing.Point(10, 32);
            this.TnTb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TnTb.Name = "TnTb";
            this.TnTb.Size = new System.Drawing.Size(307, 23);
            this.TnTb.TabIndex = 0;
            // 
            // NameTb
            // 
            this.NameTb.Location = new System.Drawing.Point(10, 82);
            this.NameTb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(307, 23);
            this.NameTb.TabIndex = 1;
            // 
            // SaveBtn
            // 
            this.SaveBtn.AutoSize = true;
            this.SaveBtn.Location = new System.Drawing.Point(10, 132);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.SaveBtn.Size = new System.Drawing.Size(99, 25);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(234, 132);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.CancelBtn.Size = new System.Drawing.Size(82, 25);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // TnLbl
            // 
            this.TnLbl.AutoSize = true;
            this.TnLbl.Location = new System.Drawing.Point(10, 14);
            this.TnLbl.Name = "TnLbl";
            this.TnLbl.Size = new System.Drawing.Size(110, 15);
            this.TnLbl.TabIndex = 4;
            this.TnLbl.Text = "Табельный номер:";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(10, 65);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(95, 15);
            this.NameLbl.TabIndex = 5;
            this.NameLbl.Text = "Имя работника:";
            // 
            // WorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(327, 164);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.TnLbl);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.NameTb);
            this.Controls.Add(this.TnTb);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkerForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WorkerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TnTb;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label TnLbl;
        private System.Windows.Forms.Label NameLbl;
    }
}