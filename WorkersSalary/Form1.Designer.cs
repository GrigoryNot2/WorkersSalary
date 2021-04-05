
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
            this.WorkersPanel = new System.Windows.Forms.Panel();
            this.WorkersBtns = new System.Windows.Forms.Panel();
            this.deleteWorker = new System.Windows.Forms.Button();
            this.changeWorker = new System.Windows.Forms.Button();
            this.addWorker = new System.Windows.Forms.Button();
            this.dataGridWorkers = new System.Windows.Forms.DataGridView();
            this.SalariesPanel = new System.Windows.Forms.Panel();
            this.SalariesBtns = new System.Windows.Forms.Panel();
            this.deleteSalary = new System.Windows.Forms.Button();
            this.changeSalary = new System.Windows.Forms.Button();
            this.addSalary = new System.Windows.Forms.Button();
            this.dataGridSalaries = new System.Windows.Forms.DataGridView();
            this.WorkersPanel.SuspendLayout();
            this.WorkersBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWorkers)).BeginInit();
            this.SalariesPanel.SuspendLayout();
            this.SalariesBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSalaries)).BeginInit();
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
            // WorkersPanel
            // 
            this.WorkersPanel.Controls.Add(this.WorkersBtns);
            this.WorkersPanel.Controls.Add(this.dataGridWorkers);
            this.WorkersPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WorkersPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkersPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WorkersPanel.Name = "WorkersPanel";
            this.WorkersPanel.Size = new System.Drawing.Size(509, 235);
            this.WorkersPanel.TabIndex = 3;
            // 
            // WorkersBtns
            // 
            this.WorkersBtns.Controls.Add(this.deleteWorker);
            this.WorkersBtns.Controls.Add(this.changeWorker);
            this.WorkersBtns.Controls.Add(this.addWorker);
            this.WorkersBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WorkersBtns.Location = new System.Drawing.Point(0, 200);
            this.WorkersBtns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WorkersBtns.Name = "WorkersBtns";
            this.WorkersBtns.Size = new System.Drawing.Size(509, 35);
            this.WorkersBtns.TabIndex = 3;
            // 
            // deleteWorker
            // 
            this.deleteWorker.AutoSize = true;
            this.deleteWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteWorker.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteWorker.Location = new System.Drawing.Point(140, 0);
            this.deleteWorker.Name = "deleteWorker";
            this.deleteWorker.Size = new System.Drawing.Size(61, 35);
            this.deleteWorker.TabIndex = 7;
            this.deleteWorker.Text = "Удалить";
            this.deleteWorker.UseVisualStyleBackColor = true;
            // 
            // changeWorker
            // 
            this.changeWorker.AutoSize = true;
            this.changeWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.changeWorker.Dock = System.Windows.Forms.DockStyle.Left;
            this.changeWorker.Location = new System.Drawing.Point(69, 0);
            this.changeWorker.Name = "changeWorker";
            this.changeWorker.Size = new System.Drawing.Size(71, 35);
            this.changeWorker.TabIndex = 6;
            this.changeWorker.Text = "Изменить";
            this.changeWorker.UseVisualStyleBackColor = true;
            // 
            // addWorker
            // 
            this.addWorker.AutoSize = true;
            this.addWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addWorker.Dock = System.Windows.Forms.DockStyle.Left;
            this.addWorker.Location = new System.Drawing.Point(0, 0);
            this.addWorker.Name = "addWorker";
            this.addWorker.Size = new System.Drawing.Size(69, 35);
            this.addWorker.TabIndex = 5;
            this.addWorker.Text = "Добавить";
            this.addWorker.UseVisualStyleBackColor = true;
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
            this.dataGridWorkers.Size = new System.Drawing.Size(509, 235);
            this.dataGridWorkers.TabIndex = 2;
            this.dataGridWorkers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridWorkers_CellClick);
            this.dataGridWorkers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridWorkers_DataBindingComplete);
            // 
            // SalariesPanel
            // 
            this.SalariesPanel.AutoSize = true;
            this.SalariesPanel.Controls.Add(this.SalariesBtns);
            this.SalariesPanel.Controls.Add(this.dataGridSalaries);
            this.SalariesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SalariesPanel.Location = new System.Drawing.Point(0, 235);
            this.SalariesPanel.Name = "SalariesPanel";
            this.SalariesPanel.Size = new System.Drawing.Size(509, 243);
            this.SalariesPanel.TabIndex = 4;
            // 
            // SalariesBtns
            // 
            this.SalariesBtns.Controls.Add(this.deleteSalary);
            this.SalariesBtns.Controls.Add(this.changeSalary);
            this.SalariesBtns.Controls.Add(this.addSalary);
            this.SalariesBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SalariesBtns.Location = new System.Drawing.Point(0, 208);
            this.SalariesBtns.Name = "SalariesBtns";
            this.SalariesBtns.Size = new System.Drawing.Size(509, 35);
            this.SalariesBtns.TabIndex = 4;
            // 
            // deleteSalary
            // 
            this.deleteSalary.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteSalary.Location = new System.Drawing.Point(150, 0);
            this.deleteSalary.Name = "deleteSalary";
            this.deleteSalary.Size = new System.Drawing.Size(75, 35);
            this.deleteSalary.TabIndex = 2;
            this.deleteSalary.Text = "Удалить";
            this.deleteSalary.UseVisualStyleBackColor = true;
            // 
            // changeSalary
            // 
            this.changeSalary.Dock = System.Windows.Forms.DockStyle.Left;
            this.changeSalary.Location = new System.Drawing.Point(75, 0);
            this.changeSalary.Name = "changeSalary";
            this.changeSalary.Size = new System.Drawing.Size(75, 35);
            this.changeSalary.TabIndex = 1;
            this.changeSalary.Text = "Изменить";
            this.changeSalary.UseVisualStyleBackColor = true;
            // 
            // addSalary
            // 
            this.addSalary.Dock = System.Windows.Forms.DockStyle.Left;
            this.addSalary.Location = new System.Drawing.Point(0, 0);
            this.addSalary.Name = "addSalary";
            this.addSalary.Size = new System.Drawing.Size(75, 35);
            this.addSalary.TabIndex = 0;
            this.addSalary.Text = "Добавить";
            this.addSalary.UseVisualStyleBackColor = true;
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
            this.dataGridSalaries.Size = new System.Drawing.Size(509, 243);
            this.dataGridSalaries.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 565);
            this.Controls.Add(this.SalariesPanel);
            this.Controls.Add(this.WorkersPanel);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(352, 533);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WorkersPanel.ResumeLayout(false);
            this.WorkersBtns.ResumeLayout(false);
            this.WorkersBtns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWorkers)).EndInit();
            this.SalariesPanel.ResumeLayout(false);
            this.SalariesBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSalaries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel WorkersPanel;
        private System.Windows.Forms.Panel WorkersBtns;
        private System.Windows.Forms.DataGridView dataGridWorkers;
        private System.Windows.Forms.Button deleteWorker;
        private System.Windows.Forms.Button changeWorker;
        private System.Windows.Forms.Button addWorker;
        private System.Windows.Forms.Panel SalariesPanel;
        private System.Windows.Forms.DataGridView dataGridSalaries;
        private System.Windows.Forms.Panel SalariesBtns;
        private System.Windows.Forms.Button deleteSalary;
        private System.Windows.Forms.Button changeSalary;
        private System.Windows.Forms.Button addSalary;
    }
}

