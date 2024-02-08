using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    // Create DatabaseManager class and add sealed modifier to disable inheritance
    public sealed class DatabaseManager
    {
        // Declare a static nullable _instance variable
        private static DatabaseManager? _instance = null;
        // Declare a static _lockCheck object to prevent cross threding instances
        private static readonly object _lockCheck = new object();
        // Connection String for Database connection
        private static readonly SqlConnectionStringBuilder _connectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = "DESKTOP-HN72N9A\\SQL2022",
            InitialCatalog = "TMPPP",
            UserID = "DESKTOP-HN72N9A\\Max",
            TrustServerCertificate = true,
            PersistSecurityInfo = false,
            IntegratedSecurity = true
        };

        // Private constructor (can initialize inside the class)
        private DatabaseManager() { }

        // Public static property witch represents the singleton instance
        public static DatabaseManager Instance
        {
            // Add get accessor to prevent modification just reading
            get
            {
                // Lock multiple thread instance initialization
                lock(_lockCheck)
                {
                    // Create new DatabaseManager instance just when _instance is null
                    if (_instance == null)
                    {
                        _instance = new DatabaseManager();
                    }
                    return _instance;
                }
            }
        }

        public void AddDataToTable(int Id, string fullName, int salary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString))
                {
                    // Define the SQL query for inserting
                    string query = "INSERT INTO Employees (Id, FullName, Salary) VALUES (@Id, @FullName, @Salary)";
                    // Create a new SqlCommand instance
                    SqlCommand command = new SqlCommand(query, connection);
                    // Assign parameters to the command to prevent SQL injection
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Salary", salary);

                    // Open Connection and execute Query
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
