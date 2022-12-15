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
            try
            {
                if (EmpCb.SelectedIndex == -1 || DaysTb.Text == "" || PerTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    period = PerTb.Value.Date.Month.ToString() + "-" + PerTb.Value.Date.Year.ToString();
                    int Amount = DSal * Convert.ToInt32(DaysTb.Text);
                    int Days = Convert.ToInt32(DaysTb.Text);
                    string Query = "insert into SalaryTbl values ({0},{1},'{2}',{3},'{4}')";
                    Query = string.Format(Query, EmpCb.SelectedValue.ToString(), Days, period, Amount, DateTime.Today.Date);
                    Con.SetData(Query);
                    ShowSal();
                    MessageBox.Show("Salary Paid");
                    DaysTb.Text = "";

                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void EmpCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSal();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Employee obj = new Employee();
            obj.Show();
            this.Hide();
        }

        private void DepLb_Click(object sender, EventArgs e)
        {
            Departments DepForm = new Departments();
            DepForm.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Login LogForm = new Login();
            LogForm.Show();
            this.Hide();
        }
    }
}
