using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_PPK
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            btnExit.Click += new System.EventHandler(close);
            btnLogin.Click += new System.EventHandler(check_login);
            
        }

        private void close(object sender, EventArgs arg) {
            Close();
        }
        private void check_login(object sender, EventArgs arg) {
            string uname = tbUsername.Text;
            string pass = tbPass.Text;
            bool status = Manager.attemp_login(uname, pass);
            if (status) {
                Close();
            }
        }
    }
}
