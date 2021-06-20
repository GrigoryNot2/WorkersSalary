﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
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

                SqlCommand command = new SqlCommand(sqlExp, connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter userParam = new SqlParameter {
                    ParameterName = "@s_user",
                    Value = textBox1.Text
                    };
                command.Parameters.Add(userParam);

                SqlParameter passParam = new SqlParameter
                {
                    ParameterName = "@s_pass",
                    Value = textBox2.Text
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

                command.ExecuteNonQuery();

                textBox1.Text = textBox2.Text = ""; //сложнее подбирать вручную

                if (Convert.ToString(command.Parameters["@s_log_db"].Value) == "")
                {
                    MessageBox.Show("Ошибка ввода учётных данных", "Внимание");
                    return;
                }
                
                //textBox1.Text = Convert.ToString(command.Parameters["@s_log_db"].Value);
                //textBox2.Text = Convert.ToString(command.Parameters["@s_pass_db"].Value);
                //textBox3.Text = Convert.ToString(command.Parameters["@s_role_db"].Value);

                User.login = Convert.ToString(command.Parameters["@s_log_db"].Value);
                User.pass = Convert.ToString(command.Parameters["@s_pass_db"].Value);
                User.role = Convert.ToString(command.Parameters["@s_role_db"].Value);
                User.id = Convert.ToInt32(command.Parameters["@id"].Value);
                this.Close();

                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connection);
                //DataSet ds = new DataSet();
                //sqlDataAdapter.Fill(ds);
                //dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
