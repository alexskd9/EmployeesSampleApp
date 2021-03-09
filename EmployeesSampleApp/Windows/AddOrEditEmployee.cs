using EmployeesSampleApp.Models;
using EmployeesSampleApp.Repository;
using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeesSampleApp.Windows
{
    public partial class AddOrEditEmployee : Form
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        private RankRepository rankRepository = new RankRepository();
        public AddOrEditEmployee()
        {
            InitializeComponent();            
        }

        private void AddOrEditEmployee_Load(object sender, EventArgs e)
        {
            if (Execute.Text == "დამატება")
                GetRanks();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            AllEmployees ae = (AllEmployees)this.Owner;
            if(Execute.Text == "დამატება")
            {
                if((int)Rank.SelectedValue == 0)
                {
                    MessageBox.Show("აირჩიეთ როლი!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    EmployeeModel employee = new EmployeeModel()
                    {
                        FirstName = FirstName.Text,
                        LastName = LastName.Text,
                        MobileNumber = MobileNumber.Text,
                        Rank = (int)Rank.SelectedValue,
                        Salary = Convert.ToDecimal(Salary.Text),
                        Status = Status.Checked
                    };

                    employeeRepository.AddEmployee(employee);
                }
            }
            else if(Execute.Text == "რედაქტირება")
            {
                if ((int)Rank.SelectedValue == 0)
                {
                    MessageBox.Show("აირჩიეთ როლი!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    EmployeeModel employee = new EmployeeModel()
                    {
                        Id = Convert.ToInt32(EmployeeId.Text),
                        FirstName = FirstName.Text,
                        LastName = LastName.Text,
                        MobileNumber = MobileNumber.Text,
                        Rank = (int)Rank.SelectedValue,
                        Salary = Convert.ToDecimal(Salary.Text),
                        Status = Status.Checked
                    };

                    employeeRepository.EditEmployee(employee);
                }
            }
            ae.ShowAll();
            Close();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Text = "რედაქტირება";
            Execute.Text = "რედაქტირება";

            FirstName.Enabled = true;
            LastName.Enabled = true;
            MobileNumber.Enabled = true;
            Rank.Enabled = true;
            Salary.Enabled = true;
            Status.Enabled = true;
            Execute.Visible = true;
            Edit.Visible = false;
            DeleteEmployee.Visible = true;
        }

        public void GetRanks()
        {
            DataTable dt = rankRepository.AllRanks();

            Rank.DataSource = dt;
            Rank.DisplayMember = "Name";
            Rank.ValueMember = "RankId";
        }

        private void DeleteEmployee_Click(object sender, EventArgs e)
        {
            AllEmployees ae = (AllEmployees)this.Owner;
            DialogResult res = MessageBox.Show("გსურთ მონიშნული თანამრომლის წაშლა?", "ყურადღება", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                employeeRepository.DeleteEmployee(Convert.ToInt32(EmployeeId.Text));
            }
            ae.ShowAll();
            Close();
        }
    }
}
