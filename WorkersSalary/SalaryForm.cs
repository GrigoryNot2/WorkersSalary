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

        public SalaryForm(Salary s, List<Salary> salaries, int Tn)
        {
            InitializeComponent();
            Salaries = salaries;
            salary = s;

        }
    }
}
