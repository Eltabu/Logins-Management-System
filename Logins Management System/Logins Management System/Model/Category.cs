using SQLite;

namespace LoginsManagementSystem.Model
{
    /// <summary>
    /// Public calss represent an entity
    /// </summary>
    public class Category : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        { get; set; }

        [Unique]
        public string CategoryName
        { get; set; }
    }
}
