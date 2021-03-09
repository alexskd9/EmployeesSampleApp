using EmployeesSampleApp.Models;
using EmployeesSampleApp.Repository;
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
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        private RankRepository rankRepository = new RankRepository();
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
            //pageNumber = 0;

            GridView.DataSource = null;
            GridView.Rows.Clear();
            GridView.Columns.Clear();
            GridView.Refresh();

            FilterModel filter = GetFilters();

            if (ds != null)
            {
                ds.Tables["Employees"].Clear();
            }
            ds = employeeRepository.GetAllEmployees(pageNumber, pageSize, filter, out int totalRows);
            GridView.DataSource = ds.Tables[0];

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

            totalPages = (totalRows - 1) / pageSize + 1;
            TotalPages.Text = totalPages.ToString();
            PageLimit.Text = pageSize.ToString();
            TotalRecords.Text = totalRows.ToString();
            currentPage = 1;
            CurrentPage.Text = (pageNumber+1).ToString();
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
                if (res == DialogResult.Yes)
                {
                    employeeRepository.DeleteEmployee((int)GridView.CurrentRow.Cells[0].Value);
                    ShowAll();
                }
            }
            else if (GridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                AddOrEditEmployee aoee = FillFields();

                aoee.Text = "რედაქტირება";
                aoee.Execute.Text = "რედაქტირება";
                aoee.DeleteEmployee.Visible = true;
                aoee.Show(this);
            }
        }

        private AddOrEditEmployee FillFields()
        {
            AddOrEditEmployee aoee = new AddOrEditEmployee();
            aoee.GetRanks();
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
            ShowAll();
            //using (SqlConnection connection = new SqlConnection(connString))
            //{
            //    adapter = new SqlDataAdapter(GetSql(), connection);

            //    ds.Tables["Employees"].Rows.Clear();

            //    adapter.Fill(ds, "Employees");
            //    currentPage--;
            //    CurrentPage.Text = currentPage.ToString();
            //}
        }


        private void PageLimit_ValueChanged(object sender, EventArgs e)
        {
            if (PageLimit.Value != 0)
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
            ShowAll();
            //using (SqlConnection connection = new SqlConnection(connString))
            //{
            //    adapter = new SqlDataAdapter(GetSql(), connection);

            //    ds.Tables["Employees"].Rows.Clear();

            //    adapter.Fill(ds, "Employees");
            //    currentPage++;
            //    CurrentPage.Text = currentPage.ToString();
            //}

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
            DataTable dt = rankRepository.AllRanks();

            RankFilter.DataSource = dt;
            RankFilter.DisplayMember = "Name";
            RankFilter.ValueMember = "RankId";
        }

        private FilterModel GetFilters()
        {
            DataRowView drv = (DataRowView)RankFilter.SelectedItem;
            return new FilterModel()
            {
                FirstName = FirstNameFilter.Text,
                LastName = LastNameFilter.Text,
                Rank = (int)drv.Row[0],
                MinSalary = MinSalaryFilter.Value,
                MaxSalary = MaxSalaryFilter.Value
            };
        }
    }
}
