using Design_Patterns;
using System;

// Create Employee class
public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Salary { get; set; }
}

class myProgram
{
    static void Main(string[] args)
    {
        // Create a list of employees
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FullName = "John Doe", Salary = 50000 },
            new Employee { Id = 2, FullName = "Jane Smith", Salary = 55000 },
            new Employee { Id = 3, FullName = "Michael Johnson", Salary = 60000 },
            new Employee { Id = 4, FullName = "Emily Brown", Salary = 52000 },
            new Employee { Id = 5, FullName = "David Wilson", Salary = 58000 }
        };

        // Start multiple threads, and add employees in database
        foreach (Employee employee in employees)
        {
            // Create a new thread for each employee
            Thread thread = new Thread((object emp) =>
            {
                Employee empDetails = (Employee)emp;

                // Get the singleton instance of DatabaseManager
                DatabaseManager dbManager = DatabaseManager.Instance;

                // Insert data in the table
                dbManager.AddDataToTable(empDetails.Id, empDetails.FullName, empDetails.Salary);
            });

            // Start the thread and pass the employee object as a parameter
            thread.Start(employee);
        }

        // Get instance of SalaryService
        SalaryService salaryService = new SalaryService();
        // Call UpdateSalary function 
        salaryService.UpdateSalary(3, 110000);
    }
}