using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersSalary
{
    public class Worker
    {
        public Worker(){}
        public Worker(int id, int tn, string name)
        {
            Id = id;
            Tn = tn;
            Name = name;
        }
        public int Id { get; set; }
        public int Tn { get; set; }
        public string Name { get; set; }
    }
}
