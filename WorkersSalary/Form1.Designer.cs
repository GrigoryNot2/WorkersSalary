
namespace WorkersSalary
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dataGridWorkers = new System.Windows.Forms.DataGridView();
            this.dataGridSalaries = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWorkers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSalaries)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(2, 484);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(799, 115);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // dataGridWorkers
            // 
            this.dataGridWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWorkers.Location = new System.Drawing.Point(2, 1);
            this.dataGridWorkers.Name = "dataGridWorkers";
            this.dataGridWorkers.RowHeadersWidth = 51;
            this.dataGridWorkers.RowTemplate.Height = 29;
            this.dataGridWorkers.Size = new System.Drawing.Size(799, 242);
            this.dataGridWorkers.TabIndex = 1;
            // 
            // dataGridSalaries
            // 
            this.dataGridSalaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSalaries.Location = new System.Drawing.Point(2, 249);
            this.dataGridSalaries.Name = "dataGridSalaries";
            this.dataGridSalaries.RowHeadersWidth = 51;
            this.dataGridSalaries.RowTemplate.Height = 29;
            this.dataGridSalaries.Size = new System.Drawing.Size(799, 228);
            this.dataGridSalaries.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 600);
            this.Controls.Add(this.dataGridSalaries);
            this.Controls.Add(this.dataGridWorkers);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWorkers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSalaries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridWorkers;
        private System.Windows.Forms.DataGridView dataGridSalaries;
    }
}

