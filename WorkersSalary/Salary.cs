using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersSalary
{
    public class Salary
    {
        public Salary() { }
        public Salary(int id, int tn, float salary, string month)
        {
            Id = id;
            Tn = tn;
            Pay = salary;
            Month = month;
        }
        public int Id { get; set; }
        public int Tn { get; set; }
        public float Pay { get; set; }
        public string Month { get; set; }
    }
}
