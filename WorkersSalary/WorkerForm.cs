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
            TnTb.Text = worker.Tn.ToString();
            NameTb.Text = worker.Name;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //Пустые поля
            if (TnTb.Text == "" || NameTb.Text=="")
            {
                MessageBox.Show("Необходимо заполнить поля", "Внимание!");
                return;
            }
            //если данные не изменились - сообщить, вернуться
            if (TnTb.Text == worker.Tn.ToString() && NameTb.Text == worker.Name)
            {
                MessageBox.Show("Данные не измененены", "Внимание!");
                return;
            }
            else
            {
                //проверить уникальность тн работника
                //если не уникальный - сообщить, вернуться
                int Tn = int.Parse(TnTb.Text);
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
                this.Close();
            }
        }
    }
}
