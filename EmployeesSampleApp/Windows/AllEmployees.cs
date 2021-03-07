using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesSampleApp.Windows
{
    public partial class AllEmployees : Form
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public AllEmployees()
        {
            InitializeComponent();
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            AddOrEditEmployee aoee = new AddOrEditEmployee();
            aoee.Text = "დამატება";
            aoee.Execute.Text = "დამატება";
            aoee.Show(this);
        }

        private void AllEmployees_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        public void ShowAll()
        {
            GridView.DataSource = null;
            GridView.Rows.Clear();
            GridView.Columns.Clear();
            GridView.Refresh();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT e.EmployeeId, e.FirstName, e.LastName, e.MobileNumber, r.RankId, r.Name, e.Salary, e.Status FROM Employees e INNER JOIN Ranks r ON e.Rank = r.RankId ", connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView.DataSource = ds.Tables[0];                
            }
            GridView.Columns["EmployeeId"].HeaderText = "Id";
            GridView.Columns["FirstName"].HeaderText = "სახელი";
            GridView.Columns["LastName"].HeaderText = "გვარი";
            GridView.Columns["MobileNumber"].HeaderText = "ტელ. ნომერი";
            GridView.Columns["Name"].HeaderText = "როლი";
            GridView.Columns["Salary"].HeaderText = "ხელფასი";
            GridView.Columns["Status"].HeaderText = "სტატუსი";

            GridView.Columns["Salary"].DefaultCellStyle.Format = "0.00";
            GridView.Columns["MobileNumber"].Visible = false;
            GridView.Columns["EmployeeId"].Visible = false;
            GridView.Columns["RankId"].Visible = false;

            DataGridViewButtonColumn col1 = new DataGridViewButtonColumn();
            col1.UseColumnTextForButtonValue = true;
            col1.HeaderText = "";
            col1.Text = "რედაქტირება";
            col1.Name = "Edit";
            GridView.Columns.Add(col1);

            DataGridViewButtonColumn col2 = new DataGridViewButtonColumn();
            col2.UseColumnTextForButtonValue = true;
            col2.HeaderText = "";
            col2.Text = "წაშლა";
            col2.Name = "Delete";
            GridView.Columns.Add(col2);            
        }

        private void GridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AddOrEditEmployee aoee = FillFields();

            aoee.FirstName.Enabled = false;
            aoee.LastName.Enabled = false;
            aoee.MobileNumber.Enabled = false;
            aoee.Rank.Enabled = false;
            aoee.Salary.Enabled = false;
            aoee.Status.Enabled = false;
            aoee.Edit.Visible = true;
            aoee.Execute.Visible = false;

            aoee.Text = "დეტალები";
            aoee.Show(this);
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult res = MessageBox.Show("გსურთ მონიშნული თანამრომლის წაშლა?", "ყურადღება", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)
                {
                    using(SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"DELETE FROM Employees WHERE EmployeeId = {GridView.CurrentRow.Cells[0].Value}", connection);
                        command.ExecuteNonQuery();
                        ShowAll();
                    }
                }
            }
            else if (GridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                AddOrEditEmployee aoee = FillFields();

                aoee.Text = "რედაქტირება";
                aoee.Execute.Text = "რედაქტირება";
                aoee.Show(this);
            }
        }

        private AddOrEditEmployee FillFields()
        {
            AddOrEditEmployee aoee = new AddOrEditEmployee();
            aoee.EmployeeId.Text = GridView.CurrentRow.Cells[0].Value.ToString();
            aoee.FirstName.Text = GridView.CurrentRow.Cells[1].Value.ToString();
            aoee.LastName.Text = GridView.CurrentRow.Cells[2].Value.ToString();
            aoee.MobileNumber.Text = GridView.CurrentRow.Cells[3].Value.ToString();
            aoee.Rank.SelectedValue = GridView.CurrentRow.Cells[4].Value.ToString();
            aoee.Salary.Text = GridView.CurrentRow.Cells[6].Value.ToString();
            aoee.Status.Checked = (bool)GridView.CurrentRow.Cells[7].Value;

            return aoee;
        }
    }
}
