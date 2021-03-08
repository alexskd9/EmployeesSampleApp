using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSampleApp.Repository
{
    public class RankRepository
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public DataTable AllRanks()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Ranks", connection))
                {                    
                    adapter.Fill(dt);

                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "აირჩიეთ როლი";
                    dt.Rows.InsertAt(row, 0);
                }
            }

            return dt;
        }
    }
}
