using System;
using System.Collections.Generic;
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
    }
}
