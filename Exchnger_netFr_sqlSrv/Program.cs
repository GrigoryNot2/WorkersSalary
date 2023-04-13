using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchnger_netFr_sqlSrv
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new loginForm());
            if (User.role == "User")
            {
                Application.Run(new userForm());
            }
            else if (User.role == "Operator")
            {
                Application.Run(new operatorForm());
            }
        }
    }
}
