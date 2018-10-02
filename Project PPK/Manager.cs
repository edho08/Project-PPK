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
        static bool use = true;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            do
            {
                Application.Run(new Login());
                if (isAllowedLogin)
                    Application.Run(new CRUDGeneral());
            } while (use);
        }

        public static bool attemp_login(string uname, string pass) {
            DbInterface.open();
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("@uname", uname);
            args.Add("@pass", pass);
            string[][] count = DbInterface.returnQuery(" SELECT * FROM user WHERE username = @uname AND password = @pass ", args);
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
        public static void log_out() {
            use = true;
            isAllowedLogin = false;
        }
        public static void close() {
            use = false;
        }

    }
}
