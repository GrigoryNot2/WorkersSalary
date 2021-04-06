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
    public partial class MainForm : Form
    {
        private static List<Salary> Salaries;
        static string connectionString = "data source = workerssalary.db";
        private static List<Worker> Workers;
        public MainForm()
        {
            InitializeComponent();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                Int64 number;
                command.Connection = connection;

                command.CommandText = "SELECT COUNT(name) FROM sqlite_master WHERE type='table' and name = 'Workers'";
                if ((Int64)command.ExecuteScalar() == 0)
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS Workers(" +
                                          "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                          "Tn INTEGER NOT NULL UNIQUE," +
                                          //"Tn INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,"+
                                          "Name TEXT NOT NULL" +
                                          ")";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"Таблица Workers создана\n";
                }

                command.CommandText = "SELECT COUNT(*) FROM workers";
                number = (Int64)command.ExecuteScalar();     //ExecuteScalar() возвращает объект, который не может быть приведён к Int32
                richTextBox1.Text += $"Количество строк в Workers: {number}\n";
                if (number == 0)
                {
                    command.CommandText = "INSERT INTO workers(Tn, Name) " +
                                          "VALUES (111, 'Josh'), (222, 'Nikc'), (333, 'Ralph')";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"Добавлено строк в Workers: {number}\n";
                }

                command.CommandText = "SELECT COUNT(name) FROM sqlite_master WHERE type = 'table' AND name = 'Salary'";
                if ((Int64)command.ExecuteScalar() == 0)
                {
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
                    richTextBox1.Text += $"Таблица Salary создана\n";
                }

                command.CommandText = "SELECT COUNT(*) FROM Salary";
                number = (Int64)command.ExecuteScalar();
                richTextBox1.Text += $"Количество строк в Salary: {number}\n";
                if (number == 0)
                {
                    command.CommandText = "INSERT INTO Salary(Tn, Salary, Month)" +
                                        "VALUES (111, 654.3, 1), (111, 847.1, 2), (111, 456.4, 3), (111, 354.1, 4)," +
                                        "       (222, 688.4, 1), (222, 641.5, 2), (222, 348.4, 3), (222, 871.2, 4)," +
                                        "       (333, 547.2, 1), (333, 146.3, 2), (333, 478.2, 3), (333, 459.1, 4)";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"Добавлено строк в Salary: {number}\n";
                }
                dataGridWorkers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridWorkers.MultiSelect = false;
                Workers = GetWorkers();
                dataGridWorkers.DataSource = Workers;
                dataGridWorkers.Columns["Id"].Visible = false;
                dataGridWorkers.RowHeadersVisible = false;
                dataGridWorkers.Columns["Tn"].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                dataGridWorkers.Columns["Tn"].FillWeight = 30;


                dataGridSalaries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridSalaries.MultiSelect = false;
                //dataGridSalaries.Columns["Id"].Visible = false;
                dataGridSalaries.RowHeadersVisible = false;
            }
        }
        //Salaries = GetSalaries(selectedWorker.Tn);
        //dataGridSalaries.DataSource = Salaries;

        private List<Worker> GetWorkers()
        {
            List<Worker> workers = new List<Worker>();
            string sql = "SELECT * FROM Workers";
            using(SqliteConnection connection=new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sql, connection);
                using(SqliteDataReader reader=command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("_id");
                            int tn = reader.GetInt32("Tn");
                            string name = reader.GetString("Name");

                            Worker worker = new Worker(id, tn, name);
                            workers.Add(worker);
                        }
                    }
                }
            }
            return workers;
        }

        private List<Salary> GetSalaries(int Tn)
        {
            List<Salary> Salaries = new List<Salary>();
            string sql = $"SELECT * FROM Salary WHERE Tn = '{Tn}'";
            using(SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sql, connection);
                //command.Parameters.Add(new SqliteParameter("@Tn", Tn));
                using(SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("_id");
                            int tn = reader.GetInt32("Tn");
                            float salary = reader.GetFloat("Salary");
                            int month = reader.GetInt32("Month");

                            Salary Salary = new Salary(id, tn, salary, month);
                            Salaries.Add(Salary);
                        }
                    }
                }
            }
            return Salaries;
        }

        private void dataGridWorkers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridWorkers.ClearSelection();
        }

        private void dataGridWorkers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Tn = (int)((DataGridView)sender).SelectedRows[0].Cells["Tn"].Value;
            Salaries = GetSalaries(Tn);
            dataGridSalaries.DataSource = Salaries;
            dataGridSalaries.RowHeadersVisible = false;
            dataGridSalaries.Columns["Id"].Visible = false;
        }

        private void addWorker_Click(object sender, EventArgs e)
        {
            //открыть форму

            //проверить уникальность тн работника

            //если не уникальный - сообщить, вернуться в форму

            //если уникальный - получить данные работника из формы

            //создать строку на добавление

            //запрос на добавление

            //обновить коллекцию и таблицу, выделить добавленного работника


            WorkerForm newForm = new WorkerForm(this);
            newForm.Owner = this;
            newForm.ShowDialog();
        }

        private void changeWorker_Click(object sender, EventArgs e)
        {
            //извлечь данные выбранного работника, запомнить кто выбран,
            //если не выбран - сообщить, вернуться

            if (dataGridWorkers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Необхадимо выбрать работника");
                return;
            }

            Worker worker = Workers[dataGridWorkers.CurrentRow.Index];
            //Worker worker = Workers[(int)dataGridWorkers.CurrentRow.Cells["Tn"].Value];

            WorkerForm workerForm = new WorkerForm(worker);
            workerForm.ShowDialog();
            

            //передать в форму

            //проверить уникальность тн работника

            //если не уникальный - сообщить, вернуться в форму

            //если уникальный - получить данные работника из формы

            //если не изменились - сообщить, вернуться

            //если изменились - создать строку на изменение

            //запрос на изменение

            //обновить коллекцию и таблицу, выделить изменённую строку
        }

        private void deleteWorker_Click(object sender, EventArgs e)
        {
            //извлечь данные выбранного работника, запомнить следующего,
            //или предыдущего, или никого

            //создать строку на удаление

            //запрос на удаление

            //выделить сохранеённого работника, если есть
        }
    }
}
