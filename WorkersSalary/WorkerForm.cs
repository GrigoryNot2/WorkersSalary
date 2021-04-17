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
            //Проверка табельного номера - целое положительное число
            int Tn;

            if (!int.TryParse(TnTb.Text, out Tn) || Tn < 1 )
            {
                MessageBox.Show("Табельный номер должен быть целым числом больше 0", "Внимание!");
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
