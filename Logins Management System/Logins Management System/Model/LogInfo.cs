using SQLite;

namespace LoginsManagementSystem.Model
{
    /// <summary>
    /// Public calss represent an entity
    /// </summary>
    public class LogInfo : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        { get; set; }

        public string LogName
        { get; set; }

        public string Strength
        { get; set; }

        public string UserName
        { get; set; }

        public string Password
        { get; set; }
        public string address
        { get; set; }

        public string Detail
        { get; set; }
    }
}
