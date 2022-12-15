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
    public partial class Salaries : Form
    {
        Functions Con;
        public Salaries()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSal();
            GetEmp();
        }
        private void GetEmp()
        {
            string Query = "Select * from EmployeeTbl";
            EmpCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpCb.DataSource = Con.GetData(Query);
        }
        int DSal = 0;
        string period = "";
        private void GetSal()
        {
            string Query = "select * from EmployeeTbl where Empid = {0}";
            Query = string.Format(Query, EmpCb.SelectedValue.ToString());
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                DSal = Convert.ToInt32(dr["EmpSal"].ToString());
            }

            // MessageBox.Show("" + DSal);
            // EmpCb.DataSource = Con.GetData(Query);

            if (DaysTb.Text == "")
            {
                AmountTb.Text = "EGP  " + (d * DSal);
            }
            else if (Convert.ToInt32(DaysTb.Text) > 31)
            {
                MessageBox.Show("Days Can Not be Greater than 31");
            }
            else
            {
                d = Convert.ToInt32(DaysTb.Text);
                AmountTb.Text = "EGP  " + (d * DSal);
            }
        }
        int d = 1;
        private void ShowSal()
        {
            string Query = "Select * from Salary";
            Salarylist.DataSource = Con.GetData(Query);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
