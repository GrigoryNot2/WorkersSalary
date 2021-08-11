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
    public partial class loginForm : Form
    {
        private DataTable Logins = new DataTable();
        public loginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = Exchanger_contained_db; User Id = getpass; Password = getpass;";
            string sqlExp = "pr_get_access";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlExp, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter userParam = new SqlParameter
                    {
                        ParameterName = "@s_user",
                        Value = textBox_login.Text
                    };
                    command.Parameters.Add(userParam);

                    SqlParameter passParam = new SqlParameter
                    {
                        ParameterName = "@s_pass",
                        Value = textBox_pass.Text
                    };
                    command.Parameters.Add(passParam);
                    //SqlParameter 1 = new SqlParameter()
                    SqlParameter userdbParam = new SqlParameter
                    {
                        ParameterName = "@s_log_db",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(userdbParam);

                    SqlParameter passdbParam = new SqlParameter
                    {
                        ParameterName = "@s_pass_db",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(passdbParam);

                    SqlParameter roleParam = new SqlParameter
                    {
                        ParameterName = "@s_role_db",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(roleParam);

                    SqlParameter idParam = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idParam);

                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(nameParam);

                    command.ExecuteNonQuery();

                    textBox_login.Text = textBox_pass.Text = ""; //сложнее подбирать пароль вручную

                    if (Convert.ToString(command.Parameters["@s_log_db"].Value) == "")
                    {
                        MessageBox.Show("Ошибка ввода учётных данных", "Внимание");
                        return;
                    }

                    User.login = Convert.ToString(command.Parameters["@s_log_db"].Value);
                    User.pass = Convert.ToString(command.Parameters["@s_pass_db"].Value);
                    User.role = Convert.ToString(command.Parameters["@s_role_db"].Value);
                    User.id = Convert.ToInt32(command.Parameters["@id"].Value);
                    User.name = Convert.ToString(command.Parameters["@name"].Value);
                }
                this.Close();

                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connection);
                //DataSet ds = new DataSet();
                //sqlDataAdapter.Fill(ds);
                //dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = Exchanger_contained_db; User Id = getpass; Password = getpass;";
            string sqlExp = "pr_Logins";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlExp, connection);
                adapter.Fill(Logins);

                comboBoxLogins.DataSource = Logins;

                comboBoxLogins.DisplayMember = "app_log";
                comboBoxLogins.ValueMember = "app_log";
               comboBoxLogins.SelectedText = "app_log";
            }
        }

        private void comboBoxLogins_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_login.Text = Logins.Rows[comboBoxLogins.SelectedIndex].Field<string>(0);
            textBox_pass.Text = Logins.Rows[comboBoxLogins.SelectedIndex].Field<string>(1);
        }
    }
}
