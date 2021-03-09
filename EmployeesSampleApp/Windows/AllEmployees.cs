using EmployeesSampleApp.Models;
using EmployeesSampleApp.Repository;
using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeesSampleApp.Windows
{
    public partial class AllEmployees : Form
    {
        int pageSize = 10;
        int pageNumber = 0;
        int currentPage = 1;
        int totalPages;
        DataSet ds;
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        private RankRepository rankRepository = new RankRepository();
        public AllEmployees()
        {
            InitializeComponent();
            //როლების ფილტრისთვის მონაცემების ბაზიდან წამოღება
            GetRanks();
            //ხელფასის დიაპაზონის ისრების დამალვა
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

        //ნებისმიერ ოპერაციაზე ხდება ამ ფუნქციის გამოძახება. აქედან კონტროლდენა DataGridView-ს სვეტები, გვერდები, გვერდზე მაქსიმალური რაოდენობის ჩანაწერების ჩვენება და გვერდების ნუმერაცია
        public void ShowAll()
        {
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

            #region ცხრილის სვეტები
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
            #endregion

            totalPages = (totalRows - 1) / pageSize + 1;
            TotalPages.Text = totalPages.ToString();
            PageLimit.Text = pageSize.ToString();
            TotalRecords.Text = totalRows.ToString();
            CurrentPage.Text = currentPage.ToString();
        }

        //ორმაგი კლიკის დროს დეტალების ფანჯარაში ყველა ველი უნდა იყოს არააქტიური
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

        //ცხრილის ბოლოს ღილაკების (რედაქტირება და წაშლა) კლიკის დამუშავება
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                //წაშლის შემთხვევაში გამოდის დამადასტურებელი ფანჯარა
                DialogResult res = MessageBox.Show("გსურთ მონიშნული თანამრომლის წაშლა?", "ყურადღება", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    employeeRepository.DeleteEmployee((int)GridView.CurrentRow.Cells[0].Value);
                    ResetValues();
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

        //რედაქტირების დროს რედაქტირების ფანჯარაში ყველა ველი ივსება DataGridView-დან
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

        private void PageLimit_ValueChanged(object sender, EventArgs e)
        {
            if (PageLimit.Value != 0)
            {
                pageSize = (int)PageLimit.Value;
                ShowAll();
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (pageNumber == 0) return;
            currentPage--;
            pageNumber--;
            ShowAll();
        }
        private void Next_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Employees"].Rows.Count < pageSize) 
                return;
            if (totalPages == currentPage) 
                return;
            currentPage++;
            pageNumber++;
            ShowAll();

        }

        //ფილტრის ნებისმიერი ველის რედაქტირების დროს ხდება DataGridView-ს გაწმენდა და მონაცემების ხელახლა წამოღება ბაზიდან
        #region ფილტრები
        private void FirstNameFilter_TextChanged(object sender, EventArgs e)
        {
            ResetValues();
            ShowAll();
        }

        private void LastNameFilter_TextChanged(object sender, EventArgs e)
        {
            ResetValues();
            ShowAll();
        }

        private void RankFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetValues();
            ShowAll();
        }

        private void MinSalaryFilter_ValueChanged(object sender, EventArgs e)
        {
            ResetValues();
            ShowAll();
        }

        private void MaxSalaryFilter_ValueChanged(object sender, EventArgs e)
        {
            ResetValues();
            ShowAll();
        }
        #endregion

        //გამოიყენება როლების ფილტრის combobox-ში მონაცემების ჩასაწერად
        public void GetRanks()
        {
            DataTable dt = rankRepository.AllRanks();

            RankFilter.DataSource = dt;
            RankFilter.DisplayMember = "Name";
            RankFilter.ValueMember = "RankId";
        }

        //ფილტრების გადასაცემად ხდება მონაცემების ერთ კლასში "შეფუთვა"
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

        //ფილტრის გამოყენებისას გადავდივართ ცხრილის პირველ გვერდზე
        private void ResetValues()
        {
            pageNumber = 0;
            currentPage = 1;
        }
    }
}
