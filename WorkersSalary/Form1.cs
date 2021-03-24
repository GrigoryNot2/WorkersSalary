using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WorkersSalary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string connectionString = "data source = workerssalary.db";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS workers(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Tn INTEGER NOT NULL UNIQUE, Name TEXT NOT NULL)";
                command.Connection = connection;

                int number = command.ExecuteNonQuery();

                richTextBox1.Text = $"{number}";
            }
        }

    }
}
