using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

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
                int number;
                command.Connection = connection;
                //Проверить существование таблицы Workers
                command.CommandText = "SELECT COUNT(name) FROM sqlite_master WHERE type='table' and name = 'Workers'";
                //Если табблица не существует, то создать
                if ((Int64)command.ExecuteScalar() == 0)
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS Workers(" +
                                          "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                          "Tn INTEGER NOT NULL UNIQUE," +
                                          "Name TEXT NOT NULL" +
                                          ")";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"Таблица Workers создана\n";
                }
                //Проверить наличие записей в таблице Workers
                command.CommandText = "SELECT COUNT(*) FROM workers";
                number = Convert.ToInt32(command.ExecuteScalar());     //ExecuteScalar() возвращает объект, который не может быть приведён к Int32
                richTextBox1.Text += $"Количество строк в Workers: {number}\n";
                //Если их нет, то добавить
                if (number == 0)
                {
                    command.CommandText = "INSERT INTO workers(Tn, Name) " +
                                          "VALUES (111, 'Josh'), (222, 'Nikc'), (333, 'Ralph')";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"Добавлено строк в Workers: {number}\n";
                }
                //Проверить существование таблицы Salary
                command.CommandText = "SELECT COUNT(name) FROM sqlite_master WHERE type = 'table' AND name = 'Salary'";
                //Если не существует, создать
                if ((Int64)command.ExecuteScalar() == 0)
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS Salary(" +
                                          "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                          "Tn INTEGER NOT NULL," +
                                          "Salary REAL NOT NULL," +
                                          "Month INTEGER NOT NULL," +
                                          "FOREIGN KEY (Tn)" +
                                          "   REFERENCES Workers (Tn)" +
                                          "       ON UPDATE CASCADE" +
                                          "       ON DELETE CASCADE" +
                                          ")";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"Таблица Salary создана\n";
                }
                //Если таблица пустая, добавить записи
                command.CommandText = "SELECT COUNT(*) FROM Salary";
                number = Convert.ToInt32(command.ExecuteScalar());
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
                dataGridSalaries.RowHeadersVisible = false;
            }
        }
        
        //Создание коллекции работников и заполнение таблицы
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

        //Создание коллекции зарплат и заполнение таблицы
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

        //Очистить выделение строки после заполнения таблицы
        private void dataGridWorkers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           dataGridWorkers.ClearSelection();
        }
        private void dataGridSalaries_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridSalaries.ClearSelection();
        }

        //При выделении работника заполняется коллекция его зарплат и выводится в таблицу
        private void dataGridWorkers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Tn = (int)((DataGridView)sender).SelectedRows[0].Cells["Tn"].Value;
            Salaries = GetSalaries(Tn);
            dataGridSalaries.DataSource = Salaries;
            dataGridSalaries.RowHeadersVisible = false;
            dataGridSalaries.Columns["Id"].Visible = false;
        }

        //Кнопка добавления данных нового работника
        private void addWorker_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            int index;
            //открыть форму
            WorkerForm workerForm = new WorkerForm(worker, Workers);
            workerForm.Text = "Добавить данные нового работника";

            if (workerForm.ShowDialog() != DialogResult.Cancel)
            {
                //создать запрос на добавление
                string sql = $"INSERT INTO Workers (Tn, Name) VALUES ({worker.Tn}, '{worker.Name}')";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sql, connection);
                    //запрос на добавление
                    command.ExecuteNonQuery();
                    //Получить ид добавленного работника, чтобы потом его выделить в таблице
                    sql = "SELECT last_insert_rowid()";
                    command.CommandText = sql;
                    index = Convert.ToInt32(command.ExecuteScalar());
                }

                //обновить коллекцию и таблицу работников
                Workers = GetWorkers();
                dataGridWorkers.DataSource = Workers;
                index = Workers.FindIndex(x => x.Id == index);

                //выделить изменённую строку
                dataGridWorkers.Rows[index].Selected = true;
                dataGridWorkers.CurrentCell = dataGridWorkers.SelectedRows[0].Cells[1];
                //richTextBox1.Text += $"{dataGridWorkers.CurrentRow}";

                //Обновить колекцию и таблицу зарплат
                int Tn = Workers[index].Tn;
                Salaries = GetSalaries(Tn);
                dataGridSalaries.DataSource = Salaries;
                dataGridSalaries.RowHeadersVisible = false;
                dataGridSalaries.Columns["Id"].Visible = false;
            }
        }

        //Кнопка изменения данных существующего рабтника
        private void changeWorker_Click(object sender, EventArgs e)
        {
            //извлечь данные выбранного работника, запомнить кто выбран,
            //если не выбран - сообщить, вернуться
            if (dataGridWorkers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Необхадимо выбрать работника", "Внимание!");
                return;
            }

            int workerId = Workers[dataGridWorkers.CurrentRow.Index].Id;

            //передать в форму
            WorkerForm workerForm = new WorkerForm(Workers[dataGridWorkers.CurrentRow.Index], Workers);
            workerForm.Text = "Изменить данные работника";

            if (workerForm.ShowDialog() != DialogResult.Cancel)
            {
                //создать запрос на изменение
                string sql = $"UPDATE Workers SET " +
                                $"Tn = '{Workers[dataGridWorkers.CurrentRow.Index].Tn}', " +
                                $"Name = '{Workers[dataGridWorkers.CurrentRow.Index].Name}'" +
                                $"WHERE _id = {Workers[dataGridWorkers.CurrentRow.Index].Id}";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sql, connection);

                    //запрос на изменение
                    command.ExecuteNonQuery();
                }

                //обновить коллекцию и таблицу
                Workers = GetWorkers();
                dataGridWorkers.DataSource = Workers;

                //выделить изменённую строку
                int index = Workers.FindIndex(x => x.Id == workerId);
                dataGridWorkers.Rows[index].Selected = true;
                dataGridWorkers.CurrentCell = dataGridWorkers.SelectedRows[0].Cells[1];
                //richTextBox1.Text += $"{dataGridWorkers.CurrentRow}";

                //Обновить колекцию и таблицу зарплат
                int Tn = Workers[index].Tn;
                Salaries = GetSalaries(Tn);
                dataGridSalaries.DataSource = Salaries;
                dataGridSalaries.RowHeadersVisible = false;
                dataGridSalaries.Columns["Id"].Visible = false;
            }
        }

        //Кнопка удаления данных сущетвующего работника
        private void deleteWorker_Click(object sender, EventArgs e)
        {
            //если не выбран - сообщить, вернуться
            if (dataGridWorkers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Необхадимо выбрать работника", "Внимание!");
                return;
            }

            //Сохранить индекс для выделения записи после операции удаления
            //предыдущий, следующий, или нет
            int index = -1;
            if (dataGridWorkers.CurrentRow.Index - 1 >= 0)
            {
                index = dataGridWorkers.CurrentRow.Index - 1;
            }
            else if (dataGridWorkers.CurrentRow.Index + 1 < dataGridWorkers.Rows.Count)
            {
                index = dataGridWorkers.CurrentRow.Index;
            }

            //создать запрос на удаление
            string sql = $"DELETE FROM Workers WHERE _id = '{Workers[dataGridWorkers.CurrentRow.Index].Id}'";
            using(SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sql, connection);
                //запрос на удаление
                command.ExecuteNonQuery();
            }

            //обновить коллекцию и таблицу
            Workers = GetWorkers();
            dataGridWorkers.DataSource = Workers;

            //выделить сохранённого работника, если есть
            if (index > -1)
            {
                dataGridWorkers.Rows[index].Selected = true;
                dataGridWorkers.CurrentCell = dataGridWorkers.SelectedRows[0].Cells[1];
            }

            //Обновить колекцию и таблицу зарплат
            if (index  >= 0)
            {
                int Tn = Workers[index].Tn;
                Salaries = GetSalaries(Tn);
                dataGridSalaries.DataSource = Salaries;
            }
            else
            {
                dataGridSalaries.DataSource = null;
            }
        }

        private void deleteSalary_Click(object sender, EventArgs e)
        {
            //если не выбран - сообщить, вернуться
            if (dataGridSalaries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Необхадимо выбрать запись", "Внимание!");
                return;
            }

            //Сохранить индекс для выделения записи после операции удаления
            //предыдущий, следующий, или нет
            int index = -1;
            if (dataGridSalaries.CurrentRow.Index - 1 >= 0)
            {
                index = dataGridSalaries.CurrentRow.Index - 1;
            }
            else if (dataGridSalaries.CurrentRow.Index + 1 < dataGridSalaries.Rows.Count)
            {
                index = dataGridSalaries.CurrentRow.Index;
            }

            //создать запрос на удаление
            string sql = $"DELETE FROM Salary WHERE _id = '{Workers[dataGridWorkers.CurrentRow.Index].Id}'";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sql, connection);
                //запрос на удаление
                command.ExecuteNonQuery();
            }
        }
    }
}
