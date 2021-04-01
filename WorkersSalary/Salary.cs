using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersSalary
{
    class Salary
    {
        public Salary(int id, int tn, float salary, int month)
        {
            Id = id;
            Tn = tn;
            Pay = salary;
            Montn = month;
        }
        public int Id { get; private set; }
        public int Tn { get; private set; }
        public float Pay { get; private set; }
        public int Montn { get; private set; }
    }
}
