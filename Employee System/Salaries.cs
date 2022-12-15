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
            ShowSalary();
            GetEmp();
        }
        private void ShowSalary()
        {
            try
            {
                string Query = "Select * from SalaryTbl";
                Salarylist.DataSource = Con.GetData(Query);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void clear()
        {
            DaysTb.Text = "";
            
        }

        private void GetEmp()
        {
            string Query = "Select * from EmployeeTbl";
            EmpCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpCb.DataSource = Con.GetData(Query);
        }

        int DSal = 0;
        string period="";
        private void GetSalary()
        {
            string Query = "Select * from EmployeeTbl where EmpId={0}";
            Query = string.Format(Query, EmpCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                DSal = Convert.ToInt32(dr["EmpSal"].ToString());
            }

            //MessageBox.Show("" + DSal);
            //EmpCb.DataSource = Con.GetData(Query);
            if (DaysTb.Text == "")
            {
                AmountTb.Text = "EGP" + (d * DSal);
            }
            else if (Convert.ToInt32(DaysTb.Text) > 31)
            {
                MessageBox.Show("Days can not be Geater than 31");
            }
            else
            {
                d = Convert.ToInt32(DaysTb.Text);
                AmountTb.Text = "EGP" + (d * DSal);
            }
        }

        private void Salaries_Load(object sender, EventArgs e)
        {

        }
        int d = 1;
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpCb.SelectedIndex==-1||DaysTb.Text==""|| Periodfin.Text=="")
                {
                    MessageBox.Show("MissingData...");
                }
                else
                {
                    period = Periodfin.Value.ToString() + "-" + Periodfin.Value.ToString();
                    int amount = DSal * Convert.ToInt32(DaysTb.Text);
                    int day = Convert.ToInt32(DaysTb.Text);
                    string Query = "insert into SalaryTbl values ({0},{1},'{2}',{3},'{4}')";
                    Query = string.Format(Query, EmpCb.SelectedValue.ToString(), day, period, amount, DateTime.Today.Date);
                    Con.SetData(Query);
                    ShowSalary();
                    MessageBox.Show("Paied...");
                    clear();
                }
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void EmpCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSalary();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Employee Emp = new Employee();
            Emp.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Departments Dep = new Departments();
            Dep.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employee Emp = new Employee();
            Emp.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Departments Dep = new Departments();
            Dep.Show();
            this.Hide();
        }
    }
}
