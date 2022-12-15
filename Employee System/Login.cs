using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTb.Text == "" || passwordTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!!");
            }
            else if (usernameTb.Text == "Admin" && passwordTb.Text == "admin")
            {
                Employee Empform = new Employee();
                Empform.Show();
                this.Hide();
            }
            else
            {
                usernameTb.Text = "";
                passwordTb.Text = "";
            }
    }
}
