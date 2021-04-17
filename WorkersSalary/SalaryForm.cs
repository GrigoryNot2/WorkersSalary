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

        public SalaryForm()
        {
            InitializeComponent();
        }

        public SalaryForm(Salary s)
        {
            InitializeComponent();
            salary = s;

            if (salary.Pay != 0)
            {
                AmountTb.Text = salary.Pay.ToString();
            }

            if (salary.Month != 0)
            {
                MonthTb.Text = salary.Month.ToString();
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

            int m;

            if(int.TryParse(MonthTb.Text, out m) & m >= 1 & m <= 12)
            {
                salary.Month = m;
            }
            else
            {
                MessageBox.Show("Месяц должен быть целым числом от 1 до 12", "Внимание!");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
