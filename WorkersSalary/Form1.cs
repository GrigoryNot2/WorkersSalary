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
                Int64 number = command.ExecuteNonQuery();   //ExecuteScalar() возвращает объект, который не может быть приведён к Int32
                richTextBox1.Text += $"Таблица Workers создана: {number}";
                command.CommandText = "SELECT COUNT(*) FROM workers";
                number = (Int64)command.ExecuteScalar();
                richTextBox1.Text += $"\nКоличество строк в Workers: {number}";
                if (number == 0)
                {
                    command.CommandText = "INSERT INTO workers(Tn, Name) " +
                                          "VALUES (111, 'Josh'), (222, 'Nikc'), (333, 'Ralph')";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"\nДобавлено строк в Workers: {number}";
                }
                command.CommandText = "CREATE TABLE IF NOT EXISTS Salary(" +
                                      "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                      "Tn INTEGER NOT NULL," +
                                      "Salary REAL NOT NULL," +
                                      "Month INTEGER NOT NULL," +
                                      //"Data" +
                                      "FOREIGN KEY (Tn)" +
                                      "   REFERENCES Workers (Tn)" +
                                      "       ON UPDATE CASCADE" +
                                      "       ON DELETE CASCADE" +
                                      ")";
                number = command.ExecuteNonQuery();
                richTextBox1.Text += $"\nТаблица Salary создана: {number}";
                command.CommandText = "SELECT COUNT(*) FROM Salary";
                number = (Int64)command.ExecuteScalar();
                richTextBox1.Text += $"\nКоличество строк в Salary: {number}";
                if (number==0)
                {
                    command.CommandText = "INSERT INTO Salary(Tn, Salary, Month)" +
                                        "VALUES (111, 654.3, 1), (111, 847.1, 2), (111, 456.4, 3), (111, 354.1, 4)," +
                                        "       (222, 688.4, 1), (222, 641.5, 2), (222, 348.4, 3), (222, 871.2, 4)," +
                                        "       (333, 547.2, 1), (333, 146.3, 2), (333, 478.2, 3), (333, 459.1, 4)";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"\nДобавлено строк в Salary: {number}";
                }
            }

        }
    }
}
