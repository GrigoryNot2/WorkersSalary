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
    public partial class WorkerForm : Form
    {
        Worker worker;
        List<Worker> Workers;

        public WorkerForm()
        {
            InitializeComponent();
        }

        public WorkerForm(Worker w, List<Worker> workers)
        {
            InitializeComponent();
            Workers = workers;
            worker = w;
            if (worker.Tn != 0)
            {
                TnTb.Text = worker.Tn.ToString();
            }
            NameTb.Text = worker.Name;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //Проверка - пустые поля
            if (TnTb.Text == "" || NameTb.Text == "")
            {
                MessageBox.Show("Необходимо заполнить все поля", "Внимание!");
                return;
            }
            ////если данные не изменились - сообщить, вернуться
            //if (TnTb.Text == worker.Tn.ToString() && NameTb.Text == worker.Name)
            //{
            //    MessageBox.Show("Необходимо изменить данные сотрудника", "Внимание!");
            //    return;
            //}

            //проверка табельного номера перед конвертацией в число
            //локальная функция, вернёт true, если в строке не только числа
            bool IsNotNumberContains(string input)
            {
                foreach (char c in input)
                    if (!Char.IsNumber(c))
                        return true;
                return false;
            }

            if (IsNotNumberContains(TnTb.Text))
            {
                MessageBox.Show("Табельный номер может состоять только из чисел", "Внимание!");
                return;
            }

            int Tn = int.Parse(TnTb.Text);

            if (Tn < 1)
            {
                MessageBox.Show("Табельный номер не должен быть меньше 1", "Внимание!");
                return;
            }

            //проверить уникальность тн работника
            //если не уникальный - сообщить, вернуться
            if (Tn != worker.Tn)
            {
                foreach (var worker in Workers)
                {
                    if (worker.Tn == Tn)
                    {
                        MessageBox.Show("Такой табельный номер уже используется", "Внимание!");
                        return;
                    }
                }
            }
            //Изменить (новый) объект в списке на главной форме и закрыть активную форму
            worker.Tn = Tn;
            worker.Name = NameTb.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
