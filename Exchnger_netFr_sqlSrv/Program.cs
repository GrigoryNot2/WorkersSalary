using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchnger_netFr_sqlSrv
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (User.role == "User")
            {
                Application.Run(new userForm());
            }
            else if (User.role == "Operator")
            {
                Application.Run(new operatorForm());
            }
            //else
            //{
            //    MessageBox.Show("Ошибка", "Ошибка");
            //}
        }
    }
}
