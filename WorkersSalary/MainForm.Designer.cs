
namespace WorkersSalary
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SalariesPanel = new System.Windows.Forms.Panel();
            this.SalariesBtns = new System.Windows.Forms.Panel();
            this.deleteSalary = new System.Windows.Forms.Button();
            this.changeSalary = new System.Windows.Forms.Button();
            this.addSalary = new System.Windows.Forms.Button();
            this.dataGridSalaries = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
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
            this.WorkersPanel.Controls.Add(this.label1);
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
            this.deleteWorker.Location = new System.Drawing.Point(180, 0);
            this.deleteWorker.Name = "deleteWorker";
            this.deleteWorker.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.deleteWorker.Size = new System.Drawing.Size(81, 35);
            this.deleteWorker.TabIndex = 7;
            this.deleteWorker.Text = "Удалить";
            this.deleteWorker.UseVisualStyleBackColor = true;
            this.deleteWorker.Click += new System.EventHandler(this.deleteWorker_Click);
            // 
            // changeWorker
            // 
            this.changeWorker.AutoSize = true;
            this.changeWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.changeWorker.Dock = System.Windows.Forms.DockStyle.Left;
            this.changeWorker.Location = new System.Drawing.Point(89, 0);
            this.changeWorker.Name = "changeWorker";
            this.changeWorker.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.changeWorker.Size = new System.Drawing.Size(91, 35);
            this.changeWorker.TabIndex = 6;
            this.changeWorker.Text = "Изменить";
            this.changeWorker.UseVisualStyleBackColor = true;
            this.changeWorker.Click += new System.EventHandler(this.changeWorker_Click);
            // 
            // addWorker
            // 
            this.addWorker.AutoSize = true;
            this.addWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addWorker.Dock = System.Windows.Forms.DockStyle.Left;
            this.addWorker.Location = new System.Drawing.Point(0, 0);
            this.addWorker.Name = "addWorker";
            this.addWorker.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.addWorker.Size = new System.Drawing.Size(89, 35);
            this.addWorker.TabIndex = 5;
            this.addWorker.Text = "Добавить";
            this.addWorker.UseVisualStyleBackColor = true;
            this.addWorker.Click += new System.EventHandler(this.addWorker_Click);
            // 
            // dataGridWorkers
            // 
            this.dataGridWorkers.AllowUserToResizeColumns = false;
            this.dataGridWorkers.AllowUserToResizeRows = false;
            this.dataGridWorkers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridWorkers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWorkers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridWorkers.Location = new System.Drawing.Point(0, 27);
            this.dataGridWorkers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridWorkers.MultiSelect = false;
            this.dataGridWorkers.Name = "dataGridWorkers";
            this.dataGridWorkers.ReadOnly = true;
            this.dataGridWorkers.RowHeadersWidth = 51;
            this.dataGridWorkers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridWorkers.RowTemplate.Height = 29;
            this.dataGridWorkers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridWorkers.Size = new System.Drawing.Size(509, 176);
            this.dataGridWorkers.TabIndex = 2;
            this.dataGridWorkers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridWorkers_CellClick);
            this.dataGridWorkers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridWorkers_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(15);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.label1.Size = new System.Drawing.Size(159, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Список сотрудников";
            // 
            // SalariesPanel
            // 
            this.SalariesPanel.AutoSize = true;
            this.SalariesPanel.Controls.Add(this.SalariesBtns);
            this.SalariesPanel.Controls.Add(this.dataGridSalaries);
            this.SalariesPanel.Controls.Add(this.label2);
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
            this.deleteSalary.AutoSize = true;
            this.deleteSalary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteSalary.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteSalary.Location = new System.Drawing.Point(180, 0);
            this.deleteSalary.Name = "deleteSalary";
            this.deleteSalary.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.deleteSalary.Size = new System.Drawing.Size(81, 35);
            this.deleteSalary.TabIndex = 2;
            this.deleteSalary.Text = "Удалить";
            this.deleteSalary.UseVisualStyleBackColor = true;
            this.deleteSalary.Click += new System.EventHandler(this.deleteSalary_Click);
            // 
            // changeSalary
            // 
            this.changeSalary.AutoSize = true;
            this.changeSalary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.changeSalary.Dock = System.Windows.Forms.DockStyle.Left;
            this.changeSalary.Location = new System.Drawing.Point(89, 0);
            this.changeSalary.Name = "changeSalary";
            this.changeSalary.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.changeSalary.Size = new System.Drawing.Size(91, 35);
            this.changeSalary.TabIndex = 1;
            this.changeSalary.Text = "Изменить";
            this.changeSalary.UseVisualStyleBackColor = true;
            this.changeSalary.Click += new System.EventHandler(this.changeSalary_Click);
            // 
            // addSalary
            // 
            this.addSalary.AutoSize = true;
            this.addSalary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addSalary.Dock = System.Windows.Forms.DockStyle.Left;
            this.addSalary.Location = new System.Drawing.Point(0, 0);
            this.addSalary.Name = "addSalary";
            this.addSalary.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.addSalary.Size = new System.Drawing.Size(89, 35);
            this.addSalary.TabIndex = 0;
            this.addSalary.Text = "Добавить";
            this.addSalary.UseVisualStyleBackColor = true;
            this.addSalary.Click += new System.EventHandler(this.addSalary_Click);
            // 
            // dataGridSalaries
            // 
            this.dataGridSalaries.AllowUserToResizeColumns = false;
            this.dataGridSalaries.AllowUserToResizeRows = false;
            this.dataGridSalaries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridSalaries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSalaries.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridSalaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSalaries.Location = new System.Drawing.Point(0, 27);
            this.dataGridSalaries.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridSalaries.MinimumSize = new System.Drawing.Size(0, 100);
            this.dataGridSalaries.MultiSelect = false;
            this.dataGridSalaries.Name = "dataGridSalaries";
            this.dataGridSalaries.ReadOnly = true;
            this.dataGridSalaries.RowHeadersWidth = 51;
            this.dataGridSalaries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridSalaries.RowTemplate.Height = 29;
            this.dataGridSalaries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridSalaries.Size = new System.Drawing.Size(509, 181);
            this.dataGridSalaries.TabIndex = 3;
            this.dataGridSalaries.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridSalaries_DataBindingComplete);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(15);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.label2.Size = new System.Drawing.Size(126, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Список выплат";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 565);
            this.Controls.Add(this.SalariesPanel);
            this.Controls.Add(this.WorkersPanel);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(352, 527);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WorkersPanel.ResumeLayout(false);
            this.WorkersPanel.PerformLayout();
            this.WorkersBtns.ResumeLayout(false);
            this.WorkersBtns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWorkers)).EndInit();
            this.SalariesPanel.ResumeLayout(false);
            this.SalariesPanel.PerformLayout();
            this.SalariesBtns.ResumeLayout(false);
            this.SalariesBtns.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

