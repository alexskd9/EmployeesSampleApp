using EmployeesSampleApp.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeesSampleApp.Repository
{
    public class EmployeeRepository
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //ძირითადი მეთოდი, რომელსაც მოაქვს თანამშრომლები ბაზიდან. გამოიყენება შენახული პროცედურა. თანამშრომლების სიასთან ერთად მოაქვს ჩანაწერების რაოდენობა
        public DataSet GetAllEmployees(int pageNumber, int pageSize, FilterModel filter, out int totalRows)
        {
            totalRows = 0;
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("FilterEmployees", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@pageNumber", SqlDbType.Int).Value = pageNumber;
                adapter.SelectCommand.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
                adapter.SelectCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = filter.FirstName;
                adapter.SelectCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = filter.LastName;
                adapter.SelectCommand.Parameters.Add("@Rank", SqlDbType.Int).Value = filter.Rank;
                adapter.SelectCommand.Parameters.Add("@MinSalary", SqlDbType.Money).Value = filter.MinSalary;
                adapter.SelectCommand.Parameters.Add("@MaxSalary", SqlDbType.Money).Value = filter.MaxSalary;
                
                //output პარამეტრის განსაზღვრა                
                SqlParameter total = new SqlParameter
                {
                    ParameterName = "@totalRows",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                adapter.SelectCommand.Parameters.Add(total);

                adapter.Fill(ds, "Employees");
                totalRows = (int)total.Value;
            }
            return ds;
        }

        //თანამშრომლის დამატება
        public void AddEmployee(EmployeeModel employee)
        {
            string query = $"INSERT INTO Employees(FirstName, LastName, MobileNumber, Rank, Salary, Status) VALUES(N'{employee.FirstName}', N'{employee.LastName}', N'{employee.MobileNumber}', {employee.Rank}, N'{employee.Salary}', N'{employee.Status}')";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        //თანამშრომლის რედაქტირება
        public void EditEmployee(EmployeeModel employee)
        {
            string query = $"UPDATE Employees SET FirstName = N'{employee.FirstName}', LastName = N'{employee.LastName}', MobileNumber = N'{employee.MobileNumber}', Rank = {employee.Rank}, Salary = N'{employee.Salary}', Status = N'{employee.Status}' WHERE EmployeeId = {employee.Id}";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        //თანამშრომლის წაშლა
        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM Employees WHERE EmployeeId = {id}", connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
