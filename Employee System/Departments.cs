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
                    string Query = "insert into DepartTbl value ('{0}')";
                    Query = string.Format(DepNameTb.Text);
                    Con.SetData(Query);
                    ShowDepartment();
                    MessageBox.Show("Added...");
                    DepNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
