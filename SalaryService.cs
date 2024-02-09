using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    // Create SalaryService class
    public class SalaryService
    {
        // Function for updating employee's salary in database
        public void UpdateSalary(int Id, int newSalary)
        {
            Thread thread = new Thread(() =>
            {
                // Get the singleton instance of DatabaseManager
                DatabaseManager dbManager = DatabaseManager.Instance;
                dbManager.UpdateSalary(Id, newSalary);
            });
            thread.Start();
        }
    }
}
