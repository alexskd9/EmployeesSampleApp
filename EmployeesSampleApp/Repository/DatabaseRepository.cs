using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeesSampleApp.Repository
{
    public class DatabaseRepository
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["MasterConnection"].ConnectionString;

        public bool CheckIfDBExists()
        {
            bool exists = false;
            using(SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM master.dbo.sysdatabases where name = 'EmployeesDB'";
                SqlCommand command = new SqlCommand(query, connection);
                object res = command.ExecuteScalar();
                if((int)res == 1)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public bool CreateDatabase()
        {
            bool created = false;
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\Scripts\createDB.sql");
            string a = File.ReadAllText(path);
            IEnumerable<string> commandStrings = Regex.Split(a, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandStrings.ToString(), connection);
                command.ExecuteNonQuery();
            }
            return created;
        }
    }
}
