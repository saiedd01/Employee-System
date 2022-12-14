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
    public partial class Employee : Form
    {
        Functions Con;
        public Employee()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmp();
            GetDepartment();
        }
        private void ShowEmp()
        {
            string Query = "Select * from EmployeeTbl";
            Emplist.DataSource = Con.GetData(Query);
        }

        private void GetDepartment()
        {
            string Query = "Select * from DepartTbl";
            DepCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Con.GetData(Query);
        }
        public void clear()
        {
            EmpNameTb.Text = "";
            GenCb.SelectedIndex = -1;
            DepCb.SelectedIndex = -1;
            DailySalTb.Text = "";
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex==-1 || DepCb.SelectedIndex==-1 || DailySalTb.Text=="")
                {
                    MessageBox.Show("Missing data");
                }
                else
                {
                    string Emp = EmpNameTb.Text;
                    string Gen = GenCb.SelectedItem.ToString();
                    string Dep = DepCb.SelectedValue.ToString();
                    string DDb = DDBTb.Value.ToString("yyyy-MM-dd");
                    string jDate = JDate.Value.ToString("yyyy-MM-dd");
                    int Salary = Convert.ToInt32(DailySalTb.Text);
                    string Query = "insert into EmployeeTbl values ('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, Emp, Gen, Dep, DDb, jDate, Salary);
                    Con.SetData(Query);
                    MessageBox.Show("Added...");
                    ShowEmp();
                    clear();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
