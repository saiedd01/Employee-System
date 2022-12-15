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
    public partial class Departments : Form
    {
        Functions Con;
        public Departments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartment();
        }
        private void ShowDepartment()
        {
            string Query = "Select * from DepartTbl";
            Deplist.DataSource = Con.GetData(Query);
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            DepNameTb.Text = "";
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing data");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "insert into DepartTbl values ('{0}')";
                    Query = string.Format(Query,Dep);
                    Con.SetData(Query);
                    MessageBox.Show("Added...");
                    ShowDepartment();
                    clear();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void Deplist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameTb.Text = Deplist.SelectedRows[0].Cells[1].Value.ToString();
            if (DepNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Deplist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing data");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Update DepartTbl set DepName = '{0}' where DepId = {1}";
                    Query = string.Format(Query,DepNameTb.Text,key);
                    Con.SetData(Query);
                    ShowDepartment();
                    MessageBox.Show("Updated...");
                    clear();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing data");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Delete from DepartTbl where DepId = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowDepartment();
                    MessageBox.Show("deleted...");
                    clear();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void EmpLb_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
            this.Hide();
        }

        //private void pictureBox4_Click(object sender, EventArgs e)
        //{
        //    Salaries Sal = new Salaries();
        //    Sal.Show();
        //    this.Hide();
        //}

        //private void SalLb_Click(object sender, EventArgs e)
        //{
        //    Salaries Sal = new Salaries();
        //    Sal.Show();
        //    this.Hide();
        //}
    }
}
