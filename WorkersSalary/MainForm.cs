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
        static string connectionString = "data source = workerssalary.db";
        private static List<Salary> Salaries;   //Коллекция для спика выплат
        private static List<Worker> Workers;    //Коллекция для списка сотрудников
        string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

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
                //Проверить наличие записей в таблице сотрудников
                command.CommandText = "SELECT COUNT(*) FROM workers";
                number = Convert.ToInt32(command.ExecuteScalar());
                richTextBox1.Text += $"Количество строк в Workers: {number}\n";
                //Если их нет, то добавить
                if (number == 0)
                {
                    command.CommandText = "INSERT INTO workers(Tn, Name) " +
                                          "VALUES (111, 'Josh'), (222, 'Nikc'), (333, 'Ralph')";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"Добавлено строк в Workers: {number}\n";
                }
                //Проверить существование таблицы выплат
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
                                        "VALUES (111, 654.3, 0), (111, 847.1, 1), (111, 456.4, 2), (111, 354.1, 3)," +
                                        "       (222, 688.4, 0), (222, 641.5, 1), (222, 348.4, 2), (222, 871.2, 3)," +
                                        "       (333, 547.2, 0), (333, 146.3, 1), (333, 478.2, 2), (333, 459.1, 3)";
                    number = command.ExecuteNonQuery();
                    richTextBox1.Text += $"Добавлено строк в Salary: {number}\n";
                }
                dataGridWorkers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridWorkers.MultiSelect = false;
                Workers = GetWorkers();
                dataGridWorkers.DataSource = Workers;
                dataGridWorkers.Columns["Id"].Visible = false;
                dataGridWorkers.RowHeadersVisible = false;
                dataGridWorkers.Columns["Tn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridWorkers.Columns["Tn"].FillWeight = 40;
                dataGridWorkers.Columns["Tn"].HeaderText = "Табельный номер";
                dataGridWorkers.Columns["Name"].HeaderText = "Имя";

                dataGridSalaries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridSalaries.MultiSelect = false;
                dataGridSalaries.RowHeadersVisible = false;
            }
        }
        
        //Создание коллекции работников и заполнение таблицы
        private List<Worker> GetWorkers()
        {
            List<Worker> workers = new List<Worker>();
            using(SqliteConnection connection=new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Workers";
                using (SqliteDataReader reader=command.ExecuteReader())
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
            using(SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Salary WHERE Tn = @Tn ORDER BY Month";
                command.Parameters.Add(new SqliteParameter("@Tn", Tn));
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
                            string month = months[reader.GetInt32("Month")];

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
            if (((DataGridView)sender).SelectedRows.Count != 0)     //если не проверить, при щелчке на заголовок 
            {                                                       //.Cells["Tn"] бросит исключение ArgumentOutOfRange
                int Tn = (int)((DataGridView)sender).SelectedRows[0].Cells["Tn"].Value;
                Salaries = GetSalaries(Tn);
                dataGridSalaries.DataSource = Salaries;
                dataGridSalaries.Columns["Tn"].HeaderText = "Табельный номер";
                dataGridSalaries.Columns["Pay"].HeaderText = "Сумма";
                dataGridSalaries.Columns["Month"].HeaderText = "Месяц";
                dataGridSalaries.RowHeadersVisible = false;
                dataGridSalaries.Columns["Id"].Visible = false;
            }
        }

        //Кнопка добавления данных нового работника
        private void addWorker_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            int index;
            //открыть форму
            WorkerForm workerForm = new WorkerForm(worker, Workers);
            workerForm.Text = "Добавить данные нового сотрудника";

            if (workerForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //создать запрос на добавление
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO Workers (Tn, Name) VALUES (@Tn, @Name)";
                        command.Parameters.Add(new SqliteParameter("@Tn", worker.Tn));
                        command.Parameters.Add(new SqliteParameter("Name", worker.Name));
                        //запрос на добавление
                        command.ExecuteNonQuery();
                        //Получить ид добавленного работника, чтобы потом его выделить в таблице
                        command.CommandText = "SELECT last_insert_rowid()";
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
                catch (Exception ex)
                {
                    richTextBox1.Text += $"{ex.Message}\n";
                    MessageBox.Show($"{ex.Message}");
                }
            }
        }

        //Кнопка изменения данных существующего рабтника
        private void changeWorker_Click(object sender, EventArgs e)
        {
            //извлечь данные выбранного работника, запомнить кто выбран,
            //если не выбран - сообщить, вернуться
            if (dataGridWorkers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать сотрудника из списка", "Внимание!");
                return;
            }

            int workerId = Workers[dataGridWorkers.CurrentRow.Index].Id;

            //передать в форму
            WorkerForm workerForm = new WorkerForm(Workers[dataGridWorkers.CurrentRow.Index], Workers);
            workerForm.Text = "Изменить данные сотрудника";

            if (workerForm.ShowDialog() == DialogResult.OK)
            {
                //создать запрос на изменение
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "UPDATE Workers SET " +
                                          "Tn = @Tn, " +
                                          "Name = @Name " +
                                          "WHERE _id = @Id";
                    command.Parameters.Add(new SqliteParameter("@Tn", Workers[dataGridWorkers.CurrentRow.Index].Tn));
                    command.Parameters.Add(new SqliteParameter("@Name", Workers[dataGridWorkers.CurrentRow.Index].Name));
                    command.Parameters.Add(new SqliteParameter("@Id", Workers[dataGridWorkers.CurrentRow.Index].Id));

                    //запрос на изменение
                    command.ExecuteNonQuery();
                }

                //обновить коллекцию и таблицу
                Workers = GetWorkers();
                dataGridWorkers.DataSource = Workers;

                //выделить изменённую строку
                int index = Workers.FindIndex(x => x.Id == workerId);   //поиск индекса в коллекции для элемента с нужным Ид
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
                MessageBox.Show("Необходимо выбрать сотрудника из списка", "Внимание!");
                return;
            }

            if (MessageBox.Show(
                "Данную операцию невозможно отменить. Информация о сотруднике и истории его заработка будет уничтожена. " +
                "Продолжить выполнение?",
                "Внимание!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
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
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Workers WHERE _id = @Id";
                    command.Parameters.Add(new SqliteParameter("@Id", Workers[dataGridWorkers.CurrentRow.Index].Id));
                    //запрос на удаление
                    command.ExecuteNonQuery();
                }

                //обновить коллекцию и таблицу работников
                Workers = GetWorkers();
                dataGridWorkers.DataSource = Workers;

                //выделить сохранённого работника, если есть
                if (index > -1)
                {
                    dataGridWorkers.Rows[index].Selected = true;
                    dataGridWorkers.CurrentCell = dataGridWorkers.SelectedRows[0].Cells[1];
                }

                //Обновить колекцию и таблицу зарплат
                if (index >= 0)
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
        }

        //Кнопка добавления данных новой выплаты работнику
        private void addSalary_Click(object sender, EventArgs e)
        {
            if (dataGridWorkers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать сотрудника", "Внимание!");
                return;
            }

            int salaryId;
            Salary salary = new Salary();

            SalaryForm salaryForm = new SalaryForm(salary);
            salaryForm.Text = "Создать новую запись о зарплате";

            if (salaryForm.ShowDialog() == DialogResult.OK)
            {
                salary.Tn = Workers[dataGridWorkers.CurrentRow.Index].Tn;

                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Salary(Tn, Salary, Month) VALUES (@Tn, @Salary, @Month)";
                    command.Parameters.Add(new SqliteParameter("@Tn", salary.Tn));
                    command.Parameters.Add(new SqliteParameter("@Salary", salary.Pay));
                    command.Parameters.Add(new SqliteParameter("@Month", Array.IndexOf(months, salary.Month)));

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT last_insert_rowid()";
                    salaryId = Convert.ToInt32(command.ExecuteScalar());
                }

                //обновить коллекцию и таблицу
                Salaries = GetSalaries(Workers[dataGridWorkers.CurrentRow.Index].Tn);
                dataGridSalaries.DataSource = Salaries;

                //выделить добавленную строку
                salaryId = Salaries.FindIndex(x => x.Id == salaryId);
                dataGridSalaries.Rows[salaryId].Selected = true;
                dataGridSalaries.CurrentCell = dataGridSalaries.SelectedRows[0].Cells[1];
            }
        }

        //Кнопка изменения существующих данных выплаты рабтнику
        private void changeSalary_Click(object sender, EventArgs e)
        {
            if (dataGridWorkers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать сотрудника", "Внимание!");
                return;
            }
            //извлечь данные выбранной записи, запомнить что выбрано,
            //если не выбрано - сообщить, вернуться
            if (dataGridSalaries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать запись из списка выплат", "Внимание!");
                return;
            }

            int salaryId = Salaries[dataGridSalaries.CurrentRow.Index].Id; //ид - из-за сортировки по месяцу в запросе, индекс в колекции может измениться 

            SalaryForm salaryForm = new SalaryForm(Salaries[dataGridSalaries.CurrentRow.Index]);
            salaryForm.Text = "Изменить запись о зарплате";

            if (salaryForm.ShowDialog() == DialogResult.OK)
            {
                //запрос на изменение данных
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "UPDATE Salary SET " +
                                          "Salary = @Pay, " +
                                          "Month = @Month " +
                                          "Where _id = @Id";
                    command.Parameters.Add(new SqliteParameter("@Pay", Salaries[dataGridSalaries.CurrentRow.Index].Pay));
                    command.Parameters.Add(new SqliteParameter("@Month", Array.IndexOf(months, Salaries[dataGridSalaries.CurrentRow.Index].Month)));
                    command.Parameters.Add(new SqliteParameter("@Id", Salaries[dataGridSalaries.CurrentRow.Index].Id));
                    command.ExecuteNonQuery();
                }

                //обновить коллекцию и таблицу
                Salaries = GetSalaries(Workers[dataGridWorkers.CurrentRow.Index].Tn);
                dataGridSalaries.DataSource = Salaries;

                //выделить изменённую строку
                salaryId = Salaries.FindIndex(x => x.Id == salaryId);
                dataGridSalaries.Rows[salaryId].Selected = true;
                dataGridSalaries.CurrentCell = dataGridSalaries.SelectedRows[0].Cells[1];
            }
        }

        //Кнопка удаления сущетвующих данных выплаты работнику
        private void deleteSalary_Click(object sender, EventArgs e)
        {
            //если не выбран - сообщить, вернуться
            if (dataGridSalaries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать запись из списка выплат", "Внимание!");
                return;
            }

            if (MessageBox.Show("Данную операцию невозможно отменить. " +
                "Запись о выплате будет уничтожена. Продолжить выполнение?",
                "Внимание!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
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

                //запрос на удаление
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Salary WHERE _id = @Id";
                    command.Parameters.Add(new SqliteParameter("@Id", Salaries[dataGridSalaries.CurrentRow.Index].Id));
                    command.ExecuteNonQuery();
                }

                if (dataGridWorkers.SelectedRows.Count > 0)
                {
                    Salaries = GetSalaries(Convert.ToInt32(dataGridWorkers.CurrentRow.Cells["Tn"].Value));
                    dataGridSalaries.DataSource = Salaries;

                    //выделить сохранённую запись, если есть
                    if (index > -1)
                    {
                        dataGridSalaries.Rows[index].Selected = true;
                        dataGridSalaries.CurrentCell = dataGridSalaries.SelectedRows[0].Cells[1];
                    }
                }
                else
                {
                    dataGridSalaries.DataSource = null;
                }
            }
        }
    }
}
