using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkersSalary
{
    public partial class SalaryForm : Form
    {
        Salary salary;
        List<Salary> Salaries;
        string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public SalaryForm()
        {
            InitializeComponent();
        }

        public SalaryForm(Salary s)
        {
            InitializeComponent();
            salary = s;
            monthComboBox.DataSource = months;

            if (salary.Pay != 0)
            {
                AmountTb.Text = salary.Pay.ToString();
            }

            if (salary.Month != "")
            {
                //MonthTb.Text = salary.Month.ToString();
                monthComboBox.SelectedItem = salary.Month;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            AmountTb.Text = AmountTb.Text.Replace('.', ',');    //если пользователь неправильно ввёл десятичный разделитель

            float s;

            if (float.TryParse(AmountTb.Text, out s) & s >= 0)
            {
                salary.Pay = s;
            }
            else
            {
                MessageBox.Show("Сумма введена не корректно", "Внимание!");
                return;
            }

            salary.Month = Convert.ToString(monthComboBox.SelectedItem);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
