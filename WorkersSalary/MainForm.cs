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
        string readOnly = ";Mode = ReadOnly";
        string readWrite = ";Mode = ReadWrite";
        private static List<Salary> Salaries;   //Коллекция для спика выплат
        private static List<Worker> Workers;    //Коллекция для списка сотрудников
        string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public MainForm()
        {
            InitializeComponent();

            using (var connection = new SqliteConnection(connectionString))
            {
                int number;
                connection.Open();
                //Проверить существование таблицы Workers
                string queryCheck = "SELECT COUNT(name) FROM sqlite_master WHERE type='table' and name = 'Workers'";
                using (SqliteCommand commandCheck = new SqliteCommand(queryCheck, connection))
                {
                    //Если таблица не существует, создать
                    try
                    {
                        if (Convert.ToInt32(commandCheck.ExecuteScalar()) == 0)
                        {
                            string queryCreate = "CREATE TABLE IF NOT EXISTS Workers(" +
                                                 "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                                 "Tn INTEGER NOT NULL UNIQUE," +
                                                 "Name TEXT NOT NULL" +
                                                 ")";
                            using (SqliteCommand commandCreate = new SqliteCommand(queryCreate, connection))
                            {
                                commandCreate.ExecuteNonQuery();
                                richTextBox1.Text += $"Таблица сотрудников (Workers) создана\n";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = $"Ошибка при проверке существования или создании таблицы сотрудников (Workers): {ex.Message}\n";
                        richTextBox1.Text += message;
                        MessageBox.Show(message);
                        return;
                    }
                    
                }

                //Проверить наличие записей в таблице сотрудников
                queryCheck = "SELECT COUNT(*) FROM workers";
                using (SqliteCommand commandCheck = new SqliteCommand(queryCheck, connection))
                {
                    try
                    {
                        number = Convert.ToInt32(commandCheck.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        string message = $"Ошибка при проверке количества записей в таблице сотрудников (Workers): {ex.Message}\n";
                        richTextBox1.Text += message;
                        MessageBox.Show(message);
                        return;
                    }
                    richTextBox1.Text += $"Количество строк в таблице сотрудников (Workers): {number}\n";
                    //Если их нет, добавить
                    string queryInsert = "INSERT INTO workers(Tn, Name) " +
                                         "VALUES (111, 'Josh'), (222, 'Nikc'), (333, 'Ralph')";
                    if (number == 0)
                    {
                        using (SqliteCommand commandInsert = new SqliteCommand(queryInsert, connection))
                        {
                            try
                            {
                                number = commandInsert.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                string message = $"Ошибка при заполнении таблицы сотрудников (Workers): {ex.Message}\n";
                                richTextBox1.Text += message;
                                MessageBox.Show(message);
                                return;
                            }
                            richTextBox1.Text += $"Добавлено строк в таблицу сотрудников (Workers): {number}\n";
                        }
                    }
                }
                
                //Проверить существование таблицы выплат
                queryCheck = "SELECT COUNT(name) FROM sqlite_master WHERE type = 'table' AND name = 'Salary'";

                using (SqliteCommand commandCheck = new SqliteCommand(queryCheck, connection))
                {
                    //Если таблица не существует, создать
                    try
                    {
                        if (Convert.ToInt32(commandCheck.ExecuteScalar()) == 0)
                        {
                            string queryCreate = "CREATE TABLE IF NOT EXISTS Salary(" +
                                                 "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                                 "Tn INTEGER NOT NULL," +
                                                 "Salary REAL NOT NULL," +
                                                 "Month INTEGER NOT NULL," +
                                                 "FOREIGN KEY (Tn)" +
                                                 "   REFERENCES Workers (Tn)" +
                                                 "       ON UPDATE CASCADE" +
                                                 "       ON DELETE CASCADE" +
                                                 ")";
                            using (SqliteCommand commandCreate = new SqliteCommand(queryCreate, connection))
                            {
                                number = commandCreate.ExecuteNonQuery();
                                richTextBox1.Text += $"Таблица выплат (Salary) создана\n";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = $"Ошибка при проверке существования или создании таблицы выплат (Salary): {ex.Message}\n";
                        richTextBox1.Text += message;
                        MessageBox.Show(message);
                        return;
                    }
                    
                }

                //Проверить наличие записей в таблице выплат
                queryCheck = "SELECT COUNT(*) FROM Salary";
                using (SqliteCommand commandCkeck = new SqliteCommand(queryCheck, connection))
                {
                    try
                    {
                        number = Convert.ToInt32(commandCkeck.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        string message = $"Ошибка при проверке количества записей в таблице выплат (Salary): {ex.Message}\n";
                        richTextBox1.Text += message;
                        MessageBox.Show(message);
                        return;
                    }
                    richTextBox1.Text += $"Количество строк в таблице выплат (Salary): {number}\n";
                    //Если их нет, добавить
                    string queryInsert = "INSERT INTO Salary(Tn, Salary, Month)" +
                                         "VALUES (111, 654.3, 0), (111, 847.1, 1), (111, 456.4, 2), (111, 354.1, 3)," +
                                         "       (222, 688.4, 0), (222, 641.5, 1), (222, 348.4, 2), (222, 871.2, 3)," +
                                         "       (333, 547.2, 0), (333, 146.3, 1), (333, 478.2, 2), (333, 459.1, 3)";
                    if (number == 0)
                    {
                        using (SqliteCommand commandInsert = new SqliteCommand(queryInsert, connection))
                        {
                            try
                            {
                                number = commandInsert.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                string message = $"Ошибка при заполнении таблицы выплат (Salary): {ex.Message}\n";
                                richTextBox1.Text += message;
                                MessageBox.Show(message);
                                return;
                            }
                            richTextBox1.Text += $"Добавлено строк в таблицу выплат (Salary): {number}\n";
                        }
                    }
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
            using(SqliteConnection connection = new SqliteConnection(connectionString + readOnly))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Workers";
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
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
                }
                catch (Exception ex)
                {
                    string message = $"Ошибка при получении списка сотрудников: {ex.Message}\n";
                    richTextBox1.Text += message;
                    MessageBox.Show(message);
                }
            }
            return workers;
        }

        //Создание коллекции зарплат и заполнение таблицы
        private List<Salary> GetSalaries(int Tn)
        {
            List<Salary> Salaries = new List<Salary>();
            using(SqliteConnection connection = new SqliteConnection(connectionString + readOnly))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Salary WHERE Tn = @Tn ORDER BY Month";
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.Add(new SqliteParameter("@Tn", Tn));
                        //command.Parameters.Add(new SqliteParameter("@Tn", Tn));
                        using (SqliteDataReader reader = command.ExecuteReader())
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
                }
                catch (Exception ex)
                {
                    string message = $"Ошибка при получении списка выплат: {ex.Message}\n";
                    richTextBox1.Text += message;
                    MessageBox.Show(message);
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
                    using (SqliteConnection connection = new SqliteConnection(connectionString + readWrite))
                    {
                        connection.Open();
                        //'trololo'); drop table 'workers';
                        //string queryInsert = $"INSERT INTO Workers (Tn, Name) VALUES ({worker.Tn}, {worker.Name})";
                        string queryInsert = "INSERT INTO Workers (Tn, Name) VALUES (@Tn, @Name)";
                        using (SqliteCommand command = new SqliteCommand(queryInsert, connection))
                        {
                            command.Parameters.Add(new SqliteParameter("@Tn", worker.Tn));
                            command.Parameters.Add(new SqliteParameter("Name", worker.Name));
                            //запрос на добавление
                            command.ExecuteNonQuery();
                            richTextBox1.Text += $"Данные нового сотрудника {worker.Name} успешно внесены в базу данных\n";
                        }
                        //Получить ид добавленного работника, чтобы потом выделить его в таблице
                        using (SqliteCommand command = new SqliteCommand("SELECT last_insert_rowid()", connection))
                        {
                            index = Convert.ToInt32(command.ExecuteScalar());
                        }

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
                    string message = $"Ошибка при добавлении данных нового сотрудника: {ex.Message}\n";
                    richTextBox1.Text += message;
                    MessageBox.Show(message);
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
                try
                {
                    //создать запрос на изменение
                    using (SqliteConnection connection = new SqliteConnection(connectionString + readWrite))
                    {
                        connection.Open();
                        string queryUpdate = "UPDATE Workers SET " +
                                             "Tn = @Tn, " +
                                             "Name = @Name " +
                                             "WHERE _id = @Id";
                        using (SqliteCommand command = new SqliteCommand(queryUpdate, connection))
                        {
                            command.Parameters.Add(new SqliteParameter("@Tn", Workers[dataGridWorkers.CurrentRow.Index].Tn));
                            command.Parameters.Add(new SqliteParameter("@Name", Workers[dataGridWorkers.CurrentRow.Index].Name));
                            command.Parameters.Add(new SqliteParameter("@Id", Workers[dataGridWorkers.CurrentRow.Index].Id));
                            //запрос на изменение
                            command.ExecuteNonQuery();
                            richTextBox1.Text += $"Данные сотрудника успешно изменены\n";
                        }
                    }

                    //обновить коллекцию и таблицу
                    Workers = GetWorkers();
                    dataGridWorkers.DataSource = Workers;

                    //выделить изменённую строку
                    int index = Workers.FindIndex(x => x.Id == workerId);   //поиск индекса в коллекции для элемента с нужным Ид
                    dataGridWorkers.Rows[index].Selected = true;
                    dataGridWorkers.CurrentCell = dataGridWorkers.SelectedRows[0].Cells[1];

                    //Обновить колекцию и таблицу зарплат
                    int Tn = Workers[index].Tn;
                    Salaries = GetSalaries(Tn);
                    dataGridSalaries.DataSource = Salaries;
                    dataGridSalaries.RowHeadersVisible = false;
                    dataGridSalaries.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    string message = $"Ошибка при измененении данных сотрудника: {ex.Message}\n";
                    richTextBox1.Text += message;
                    MessageBox.Show(message);
                }
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

                try
                {
                    //создать запрос на удаление
                    using (SqliteConnection connection = new SqliteConnection(connectionString + readWrite))
                    {
                        connection.Open();
                        string queryDelete = "DELETE FROM Workers WHERE _id = @Id";
                        using (SqliteCommand command = new SqliteCommand(queryDelete, connection))
                        {
                            command.Parameters.Add(new SqliteParameter("@Id", Workers[dataGridWorkers.CurrentRow.Index].Id));
                            //запрос на удаление
                            command.ExecuteNonQuery();
                            richTextBox1.Text += $"Данные сотрудника {Workers[dataGridWorkers.CurrentRow.Index].Name} успешно удалены\n";
                        }

                    }
                }
                catch (Exception ex)
                {
                    string message = $"Ошибка при удалении данных сотрудника: {ex.Message}\n";
                    richTextBox1.Text += message;
                    MessageBox.Show(message);
                    return;
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

                try
                {
                    using (SqliteConnection connection = new SqliteConnection(connectionString + readWrite))
                    {
                        connection.Open();
                        string queryInsert = "INSERT INTO Salary(Tn, Salary, Month) VALUES (@Tn, @Salary, @Month)";
                        using (SqliteCommand command = new SqliteCommand(queryInsert, connection))
                        {
                            command.Parameters.Add(new SqliteParameter("@Tn", salary.Tn));
                            command.Parameters.Add(new SqliteParameter("@Salary", salary.Pay));
                            command.Parameters.Add(new SqliteParameter("@Month", Array.IndexOf(months, salary.Month)));

                            command.ExecuteNonQuery();
                            richTextBox1.Text += $"Данные о новой выплате успешно внесены в базу данных\n";
                        }

                        using (SqliteCommand command = new SqliteCommand("SELECT last_insert_rowid()", connection))
                        {
                            salaryId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    //обновить коллекцию и таблицу
                    Salaries = GetSalaries(Workers[dataGridWorkers.CurrentRow.Index].Tn);
                    dataGridSalaries.DataSource = Salaries;

                    //выделить добавленную строку
                    salaryId = Salaries.FindIndex(x => x.Id == salaryId);
                    dataGridSalaries.Rows[salaryId].Selected = true;
                    dataGridSalaries.CurrentCell = dataGridSalaries.SelectedRows[0].Cells[1];
                }
                catch (Exception ex)
                {
                    string message = $"Ошибка при добавлении данных новой выплаты: {ex.Message}\n";
                    richTextBox1.Text += message;
                    MessageBox.Show(message);
                }
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
                try
                {
                    //запрос на изменение данных
                    using (SqliteConnection connection = new SqliteConnection(connectionString + readWrite))
                    {
                        connection.Open();
                        string queryUpdate = "UPDATE Salary SET " +
                                             "Salary = @Pay, " +
                                             "Month = @Month " +
                                             "Where _id = @Id";
                        using (SqliteCommand command = new SqliteCommand(queryUpdate, connection))
                        {
                            command.Parameters.Add(new SqliteParameter("@Pay", Salaries[dataGridSalaries.CurrentRow.Index].Pay));
                            command.Parameters.Add(new SqliteParameter("@Month", Array.IndexOf(months, Salaries[dataGridSalaries.CurrentRow.Index].Month)));
                            command.Parameters.Add(new SqliteParameter("@Id", Salaries[dataGridSalaries.CurrentRow.Index].Id));
                            
                            command.ExecuteNonQuery();
                            richTextBox1.Text += $"Новые данные о выбранной выплате успешно внесены в базу данных\n";
                        }
                    }

                    //обновить коллекцию и таблицу
                    Salaries = GetSalaries(Workers[dataGridWorkers.CurrentRow.Index].Tn);
                    dataGridSalaries.DataSource = Salaries;

                    //выделить изменённую строку
                    salaryId = Salaries.FindIndex(x => x.Id == salaryId);
                    dataGridSalaries.Rows[salaryId].Selected = true;
                    dataGridSalaries.CurrentCell = dataGridSalaries.SelectedRows[0].Cells[1];
                }
                catch (Exception ex)
                {
                    string message = $"Ошибка при изменении данных выплаты: {ex.Message}\n";
                    richTextBox1.Text += message;
                    MessageBox.Show(message);
                }
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

                try
                {
                    //запрос на удаление
                    using (SqliteConnection connection = new SqliteConnection(connectionString + readWrite))
                    {
                        connection.Open();
                        string queryDelete = "DELETE FROM Salary WHERE _id = @Id";
                        using (SqliteCommand command = new SqliteCommand(queryDelete, connection))
                        {
                            command.Parameters.Add(new SqliteParameter("@Id", Salaries[dataGridSalaries.CurrentRow.Index].Id));

                            command.ExecuteNonQuery();
                            richTextBox1.Text += $"Данные о выбранной выплате успешно удалены\n";
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = $"Ошибка при удалении данных о выбранной выплате: {ex.Message}\n";
                    richTextBox1.Text += message;
                    MessageBox.Show(message);
                    return;
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
