using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeesSampleApp.Windows
{
    public partial class AddOrEditEmployee : Form
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public AddOrEditEmployee()
        {
            InitializeComponent();            
        }

        private void AddOrEditEmployee_Load(object sender, EventArgs e)
        {
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
                    string query = $"INSERT INTO Employees(FirstName, LastName, MobileNumber, Rank, Salary, Status) VALUES(N'{FirstName.Text}', N'{LastName.Text}', N'{MobileNumber.Text}', {(int)Rank.SelectedValue}, N'{Salary.Text}', N'{Status.Checked}')";
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
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
                    string query = $"UPDATE Employees SET FirstName = N'{FirstName.Text}', LastName = N'{LastName.Text}', MobileNumber = N'{MobileNumber.Text}', Rank = {(int)Rank.SelectedValue}, Salary = N'{Salary.Text}', Status = N'{Status.Checked}' WHERE EmployeeId = {EmployeeId.Text}";
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
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
        }

        public void GetRanks()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Ranks", connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "აირჩიეთ როლი";
                    dt.Rows.InsertAt(row, 0);

                    Rank.DataSource = dt;
                    Rank.DisplayMember = "Name";
                    Rank.ValueMember = "RankId";

                }
            }
        }
    }
}
