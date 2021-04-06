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
            worker = w;
            Workers = workers;
            TnTb.Text = worker.Tn.ToString();
            NameTb.Text = worker.Name;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
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
                        //int Tn = int.Parse(TnTb.Text);
                        if (worker.Tn == Tn)
                        {
                            MessageBox.Show("Такой табельный номер уже используется", "Внимание!");
                            return;
                        }
                    }
                }
                //Изменить объект в списке на главной форме и закрыть активную форму
                worker.Tn = int.Parse(TnTb.Text);
                worker.Name = NameTb.Text;
                this.Close();
            }
        }
    }
}
