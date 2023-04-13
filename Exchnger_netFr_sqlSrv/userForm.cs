using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exchnger_netFr_sqlSrv
{
    public partial class userForm : Form
    {
        DataTable currency_from = new DataTable();
        DataTable currency_to = new DataTable();

        public userForm()
        {
            InitializeComponent();
            this.Text = User.role + ": " + User.name;
        }

        private void userForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = Exchanger_contained_db; User Id = " + User.login + "; Password = " + User.pass + ";";
            string sqlExp = "pr_get_currency";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExp, connection);
                adapter.Fill(currency_from);
                currency_to = currency_from.Copy();

                combBox_from_cur.DataSource = currency_from;
                combBox_from_cur.DisplayMember = "Name";
                combBox_from_cur.ValueMember = "DgtCode";

                combBox_to_cur.DataSource = currency_to;
                combBox_to_cur.DisplayMember = "Name";
                combBox_to_cur.ValueMember = "DgtCode";
            }
        }

        private void textBox_from_count_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = Exchanger_contained_db; User Id = " + User.login + "; Password = " + User.pass + ";";
            string sqlExp = "pr_get_rates";

            decimal rate = 1;

            if (!textBox_from_count.Focused && !combBox_from_cur.Focused && !combBox_to_cur.Focused)
            {
                return;
            }

            if (textBox_from_count.Text != "")
            {
                if ((int)combBox_from_cur.SelectedValue == (int)combBox_to_cur.SelectedValue)
                {
                    textBox_to_count.Text = textBox_from_count.Text;
                    return;
                }

                decimal value;
                if (decimal.TryParse(textBox_from_count.Text, out value))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(sqlExp, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter from_dgt_code = new SqlParameter
                            {
                                ParameterName = "@from_dgt_code",
                                Value = (int)combBox_from_cur.SelectedValue
                            };
                            command.Parameters.Add(from_dgt_code);

                            SqlParameter to_dgt_code = new SqlParameter
                            {

                                ParameterName = "@to_dgt_code",
                                Value = (int)combBox_to_cur.SelectedValue
                            };
                            command.Parameters.Add(to_dgt_code);

                            SqlParameter rate_buy = new SqlParameter
                            {
                                ParameterName = "@rate",
                                SqlDbType = SqlDbType.Money,
                                Direction = ParameterDirection.Output
                            };
                            command.Parameters.Add(rate_buy);

                            command.ExecuteNonQuery();

                            rate = Convert.ToDecimal(command.Parameters["@rate"].Value);
                            textBox_to_count.Text = (value * rate).ToString();
                        }
                    }
                }
                else MessageBox.Show("Ошибка в воде значения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                textBox_to_count.Text = "";
                return;
            }
        }

        private void textBox_to_count_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = Exchanger_contained_db; User Id = " + User.login + "; Password = " + User.pass + ";";
            string sqlExp = "pr_get_rates";

            decimal rate = 1;

            if (!textBox_to_count.Focused)
            {
                return;
            }

            if (textBox_to_count.Text != "")
            {
                //textBox_to_count.Text = textBox_to_count.Text.Replace('.', ',');

                if ((int)combBox_to_cur.SelectedValue == (int)combBox_from_cur.SelectedValue)
                {
                    textBox_from_count.Text = textBox_to_count.Text;
                    return;
                }

                decimal value;
                if (Decimal.TryParse(textBox_to_count.Text, out value))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(sqlExp, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter from_dgt_code = new SqlParameter
                            {
                                ParameterName = "@from_dgt_code",
                                Value = (int)combBox_to_cur.SelectedValue
                            };
                            command.Parameters.Add(from_dgt_code);

                            SqlParameter to_dgt_code = new SqlParameter
                            {
                                ParameterName = "@to_dgt_code",
                                Value = (int)combBox_from_cur.SelectedValue
                            };
                            command.Parameters.Add(to_dgt_code);

                            SqlParameter rate_buy = new SqlParameter
                            {
                                ParameterName = "@rate",
                                SqlDbType = SqlDbType.Money,
                                Direction = ParameterDirection.Output
                            };
                            command.Parameters.Add(rate_buy);

                            command.ExecuteNonQuery();

                            rate = Convert.ToDecimal(command.Parameters["@rate"].Value);
                            textBox_from_count.Text = (value * rate).ToString();
                        }
                    }
                }
                else MessageBox.Show("Ошибка в воде значения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                textBox_from_count.Text = "";
                return;
            }
        }

        //для textBox_from_count и textBox_to_count ввод только чисел и 1 запятой
        private void textBox_from_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.'))
            {
                e.KeyChar = ',';
            }

            TextBox txt = (TextBox)sender;
            if ((txt.Text.Contains(",") || txt.Text.Contains(".")) && e.KeyChar == ',')
            {
                e.Handled = true;
            }

            if (!(Char.IsDigit(e.KeyChar)
                ||Char.IsControl(e.KeyChar)
                //||e.KeyChar == '.'
                ||e.KeyChar == ','))
            {
                e.Handled = true;
            }
        }

        private void exchange_button_Click(object sender, EventArgs e)
        {               ///если поля пустые, то обмен не состоится
            if (textBox_from_count.Text == "" || textBox_to_count.Text == "")
            {
                MessageBox.Show("Не указана сумма для обмена", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            richTextBox_transactions.AppendText("Обмен валюты:\t" + textBox_from_count.Text + " " + combBox_from_cur.Text + " на " + textBox_to_count.Text + " " + combBox_to_cur.Text + " \t" + DateTime.Now + "\n");
            /// внесение данных в базу данных в Transactions.
            /// 1. Проверить наличие средств на счёте в Users_Counts текущего пользователя
            /// 2. Посмотреть текущий курс обмена Currency => Rate
            /// 3. Посчитать изменения на счетах, если счёта в целевой валюте нет, то он создаётся в Users_Counts
            ///      3.1 Если не удалось создать счёт - сообщение об ошибке
            /// 4. Если данные успешно внесены в таблицу счетов Users_Counts, то данные о транзакции записываются в таблицу Transactions
            ///      4.1. Иначе сообщение об ошибке и отмена внесения данных в Users_Counts
            /// 5. Если данные успешно внесены в таблицу Transactions, то выводится сообщение о транзакции в окно сообщений о транзакциях richTextBox_transactions
            ///      5.1 Иначе сообщить об ошибке внесения данных в таблицу Transactions
        }
    }
}
