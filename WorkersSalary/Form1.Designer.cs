
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
            this.dataGridSalaries = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridWorkers = new System.Windows.Forms.DataGridView();
            this.addWorker = new System.Windows.Forms.Button();
            this.changeWorker = new System.Windows.Forms.Button();
            this.deleteWorker = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSalaries)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(0, 478);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(509, 87);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // dataGridSalaries
            // 
            this.dataGridSalaries.AllowUserToResizeColumns = false;
            this.dataGridSalaries.AllowUserToResizeRows = false;
            this.dataGridSalaries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSalaries.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridSalaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSalaries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSalaries.Location = new System.Drawing.Point(0, 0);
            this.dataGridSalaries.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridSalaries.MinimumSize = new System.Drawing.Size(0, 180);
            this.dataGridSalaries.MultiSelect = false;
            this.dataGridSalaries.Name = "dataGridSalaries";
            this.dataGridSalaries.RowHeadersWidth = 51;
            this.dataGridSalaries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridSalaries.RowTemplate.Height = 29;
            this.dataGridSalaries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridSalaries.Size = new System.Drawing.Size(509, 478);
            this.dataGridSalaries.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dataGridWorkers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 227);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.deleteWorker);
            this.panel2.Controls.Add(this.changeWorker);
            this.panel2.Controls.Add(this.addWorker);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 193);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(509, 34);
            this.panel2.TabIndex = 3;
            // 
            // dataGridWorkers
            // 
            this.dataGridWorkers.AllowUserToResizeColumns = false;
            this.dataGridWorkers.AllowUserToResizeRows = false;
            this.dataGridWorkers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridWorkers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWorkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridWorkers.Location = new System.Drawing.Point(0, 0);
            this.dataGridWorkers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridWorkers.MultiSelect = false;
            this.dataGridWorkers.Name = "dataGridWorkers";
            this.dataGridWorkers.RowHeadersWidth = 51;
            this.dataGridWorkers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridWorkers.RowTemplate.Height = 29;
            this.dataGridWorkers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridWorkers.Size = new System.Drawing.Size(509, 227);
            this.dataGridWorkers.TabIndex = 2;
            this.dataGridWorkers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridWorkers_CellClick);
            this.dataGridWorkers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridWorkers_DataBindingComplete);
            // 
            // addWorker
            // 
            this.addWorker.AutoSize = true;
            this.addWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addWorker.Dock = System.Windows.Forms.DockStyle.Left;
            this.addWorker.Location = new System.Drawing.Point(0, 0);
            this.addWorker.Name = "addWorker";
            this.addWorker.Size = new System.Drawing.Size(69, 34);
            this.addWorker.TabIndex = 5;
            this.addWorker.Text = "Добавить";
            this.addWorker.UseVisualStyleBackColor = true;
            // 
            // changeWorker
            // 
            this.changeWorker.AutoSize = true;
            this.changeWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.changeWorker.Dock = System.Windows.Forms.DockStyle.Left;
            this.changeWorker.Location = new System.Drawing.Point(69, 0);
            this.changeWorker.Name = "changeWorker";
            this.changeWorker.Size = new System.Drawing.Size(71, 34);
            this.changeWorker.TabIndex = 6;
            this.changeWorker.Text = "Изменить";
            this.changeWorker.UseVisualStyleBackColor = true;
            // 
            // deleteWorker
            // 
            this.deleteWorker.AutoSize = true;
            this.deleteWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteWorker.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteWorker.Location = new System.Drawing.Point(140, 0);
            this.deleteWorker.Name = "deleteWorker";
            this.deleteWorker.Size = new System.Drawing.Size(61, 34);
            this.deleteWorker.TabIndex = 7;
            this.deleteWorker.Text = "Удалить";
            this.deleteWorker.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 565);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridSalaries);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(352, 533);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSalaries)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWorkers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridSalaries;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridWorkers;
        private System.Windows.Forms.Button deleteWorker;
        private System.Windows.Forms.Button changeWorker;
        private System.Windows.Forms.Button addWorker;
    }
}

