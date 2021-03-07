using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeesSampleApp.Windows
{
    public partial class AllEmployees : Form
    {
        int pageSize = 10;
        int pageNumber = 0;
        int currentPage, totalPages;
        DataSet ds;
        SqlDataAdapter adapter;
        private readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public AllEmployees()
        {
            InitializeComponent();
            GetRanks();
            MinSalaryFilter.Controls[0].Visible = false;
            MaxSalaryFilter.Controls[0].Visible = false;
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
            DataRowView drv = (DataRowView)RankFilter.SelectedItem;

            GridView.DataSource = null;
            GridView.Rows.Clear();
            GridView.Columns.Clear();
            GridView.Refresh();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("FilterEmployees", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@pageNumber", SqlDbType.Int).Value = pageNumber;
                adapter.SelectCommand.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
                adapter.SelectCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = FirstNameFilter.Text;
                adapter.SelectCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = LastNameFilter.Text;
                adapter.SelectCommand.Parameters.Add("@Rank", SqlDbType.Int).Value = drv.Row[0];
                adapter.SelectCommand.Parameters.Add("@MinSalary", SqlDbType.Money).Value = MinSalaryFilter.Value;
                adapter.SelectCommand.Parameters.Add("@MaxSalary", SqlDbType.Money).Value = MaxSalaryFilter.Value;

                ds = new DataSet();
                adapter.Fill(ds, "Employees");
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

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                object result = command.ExecuteScalar();
                totalPages = ((int)result - 1) / pageSize + 1;
                TotalPages.Text = totalPages.ToString();
                TotalRecords.Text = result.ToString();
                PageLimit.Text = pageSize.ToString();
            }
            currentPage = 1;
            CurrentPage.Text = currentPage.ToString();
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

        private string GetSql()
        {
            return "SELECT e.EmployeeId, e.FirstName, e.LastName, e.MobileNumber, r.RankId, r.Name, e.Salary, e.Status FROM Employees e INNER JOIN Ranks r ON e.Rank = r.RankId ORDER BY EmployeeId OFFSET ((" + pageNumber + ") * " + pageSize + ") " + "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (pageNumber == 0) return;
            pageNumber--;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds.Tables["Employees"].Rows.Clear();

                adapter.Fill(ds, "Employees");
                currentPage--;
                CurrentPage.Text = currentPage.ToString();
            }
        }


        private void PageLimit_ValueChanged(object sender, EventArgs e)
        {
            if(PageLimit.Value != 0)
            {
                pageSize = (int)PageLimit.Value;
                ShowAll();
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Employees"].Rows.Count < pageSize) return;
            if (totalPages == currentPage) return;
            pageNumber++;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds.Tables["Employees"].Rows.Clear();

                adapter.Fill(ds, "Employees");
                currentPage++;
                CurrentPage.Text = currentPage.ToString();
            }
            
        }

        private void FirstNameFilter_TextChanged(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void LastNameFilter_TextChanged(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void RankFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void MinSalaryFilter_ValueChanged(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void MaxSalaryFilter_ValueChanged(object sender, EventArgs e)
        {
            ShowAll();
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

                    RankFilter.DataSource = dt;
                    RankFilter.DisplayMember = "Name";
                    RankFilter.ValueMember = "RankId";

                }
            }
        }
    }
}
