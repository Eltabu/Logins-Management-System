

namespace LoginsManagementSystem.Model
{
    /// <summary>
    /// Public Interface provides utilities to store and retrieve information from database
    /// </summary>
    public interface IDataService
    {
        bool IsFirstTime();

        void initializeDatabase();
    }
}
