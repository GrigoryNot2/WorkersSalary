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
                command.CommandText = "CREATE TABLE IF NOT EXISTS Workers(" +
                                      "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                      "Tn INTEGER NOT NULL UNIQUE," +
                                     //"Tn INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,"+
                                      "Name TEXT NOT NULL" +
                                      ")";
                command.Connection = connection;
                Int64 number = command.ExecuteNonQuery();
                command.CommandText = "SELECT COUNT(*) FROM workers";
                number = (Int64)command.ExecuteScalar();
                richTextBox1.Text = $"Количество строк в Workers: {number}";
                if (number == 0)
                {
                    command.CommandText = "INSERT INTO workers(Tn, Name) " +
                                          "VALUES (111112, 'Josh'), (111113, 'Nikc')";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text = $"\nДобавлено строк в Workers: {number}";
                }
                command.CommandText = "CREATE TABLE IF NOT EXISTS Salary(" +
                                      "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                      "Tn INTEGER NOT NULL," +
                                      "Salary REAL NOT NULL," +
                                      //"Data" +
                                      "FOREIGN KEY (Tn)" +
                                      "   REFERENCES Workers (Tn)" +
                                      "       ON UPDATE CASCADE" +
                                      "       ON DELETE CASCADE" +
                                      ")";
                command.ExecuteNonQuery();
                command.CommandText = "SELECT COUNT(*) FROM Salary";
                number = (Int64)command.ExecuteScalar();
                richTextBox1.Text = $"Количество строк в Salary: {number}";
            }

        }
    }
}
