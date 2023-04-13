
namespace Exchnger_netFr_sqlSrv
{
    partial class userForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userForm));
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_from_count = new System.Windows.Forms.TextBox();
            this.textBox_to_count = new System.Windows.Forms.TextBox();
            this.exchange_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_transactions = new System.Windows.Forms.RichTextBox();
            this.combBox_from_cur = new System.Windows.Forms.ComboBox();
            this.combBox_to_cur = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Обмен валюты";
            // 
            // textBox_from_count
            // 
            this.textBox_from_count.Location = new System.Drawing.Point(33, 57);
            this.textBox_from_count.Name = "textBox_from_count";
            this.textBox_from_count.Size = new System.Drawing.Size(100, 20);
            this.textBox_from_count.TabIndex = 3;
            this.textBox_from_count.TextChanged += new System.EventHandler(this.textBox_from_count_TextChanged);
            this.textBox_from_count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_from_count_KeyPress);
            // 
            // textBox_to_count
            // 
            this.textBox_to_count.Location = new System.Drawing.Point(396, 58);
            this.textBox_to_count.Name = "textBox_to_count";
            this.textBox_to_count.Size = new System.Drawing.Size(100, 20);
            this.textBox_to_count.TabIndex = 4;
            this.textBox_to_count.TextChanged += new System.EventHandler(this.textBox_to_count_TextChanged);
            this.textBox_to_count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_from_count_KeyPress);
            // 
            // exchange_button
            // 
            this.exchange_button.Location = new System.Drawing.Point(297, 116);
            this.exchange_button.Name = "exchange_button";
            this.exchange_button.Size = new System.Drawing.Size(75, 23);
            this.exchange_button.TabIndex = 5;
            this.exchange_button.Text = "Обменять";
            this.exchange_button.UseVisualStyleBackColor = true;
            this.exchange_button.Click += new System.EventHandler(this.exchange_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "История транзакций";
            // 
            // richTextBox_transactions
            // 
            this.richTextBox_transactions.Location = new System.Drawing.Point(2, 198);
            this.richTextBox_transactions.Name = "richTextBox_transactions";
            this.richTextBox_transactions.Size = new System.Drawing.Size(671, 263);
            this.richTextBox_transactions.TabIndex = 7;
            this.richTextBox_transactions.Text = "";
            // 
            // combBox_from_cur
            // 
            this.combBox_from_cur.FormattingEnabled = true;
            this.combBox_from_cur.Location = new System.Drawing.Point(139, 56);
            this.combBox_from_cur.Name = "combBox_from_cur";
            this.combBox_from_cur.Size = new System.Drawing.Size(137, 21);
            this.combBox_from_cur.TabIndex = 8;
            this.combBox_from_cur.SelectedIndexChanged += new System.EventHandler(this.textBox_from_count_TextChanged);
            // 
            // combBox_to_cur
            // 
            this.combBox_to_cur.FormattingEnabled = true;
            this.combBox_to_cur.Location = new System.Drawing.Point(502, 57);
            this.combBox_to_cur.Name = "combBox_to_cur";
            this.combBox_to_cur.Size = new System.Drawing.Size(146, 21);
            this.combBox_to_cur.TabIndex = 9;
            this.combBox_to_cur.SelectedIndexChanged += new System.EventHandler(this.textBox_from_count_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "--->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1208, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // userForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 464);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combBox_to_cur);
            this.Controls.Add(this.combBox_from_cur);
            this.Controls.Add(this.richTextBox_transactions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exchange_button);
            this.Controls.Add(this.textBox_to_count);
            this.Controls.Add(this.textBox_from_count);
            this.Controls.Add(this.label2);
            this.Name = "userForm";
            this.Text = "userForm";
            this.Load += new System.EventHandler(this.userForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_from_count;
        private System.Windows.Forms.TextBox textBox_to_count;
        private System.Windows.Forms.Button exchange_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox_transactions;
        private System.Windows.Forms.ComboBox combBox_from_cur;
        private System.Windows.Forms.ComboBox combBox_to_cur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}