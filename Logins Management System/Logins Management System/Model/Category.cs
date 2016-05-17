using System;

namespace LoginsManagementSystem.Model
{
    /// <summary>
    /// Public calss represent an entity
    /// </summary>
    public class Category : IBusinessEntity
    {
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int Id
        { get; set; }

        [SQLite.Net.Attributes.Unique]
        public string CategoryName
        { get; set; }
    }
}
