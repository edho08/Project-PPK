using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.Common;

namespace Project_PPK
{
    static class Manager
    {
        static bool isAllowedLogin = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        public static bool attemp_login(string uname, string pass) {
            DbInterface.open();
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("@uname", uname);
            args.Add("@pass", pass);
            string[][] count = DbInterface.returnQuery(" SELECT * FROM admin WHERE id_admin = @uname AND hashed_pass = @pass ", args);
            if (count.Length > 0)
            {
                isAllowedLogin = true;
            }
            else {
                isAllowedLogin = false;
            }
            DbInterface.close();
            return isAllowedLogin;
        }
    }
}
