using EmployeesSampleApp.Repository;
using EmployeesSampleApp.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesSampleApp
{
    static class Program
    {
        private static DatabaseRepository databaseRepository = new DatabaseRepository();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //პროგრამის გაშვებისას მოწმდება მონაცემთა ბაზის არსებობა. თუ ის არ არსებობს, მაშინ ხდება მისი შექმნა
            bool exists = databaseRepository.CheckIfDBExists();
            if (!exists)
            {
                databaseRepository.CreateDatabase();
            }
            Application.Run(new AllEmployees());
        }
    }
}
