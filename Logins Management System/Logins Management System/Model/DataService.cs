using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using System.Linq;

namespace LoginsManagementSystem.Model
{
    /// <summary>
    /// Public class provides methods to access, store and retrieve information from database
    /// </summary>
    public class DataService : IDataService
    {
        public SQLiteAsyncConnection Connection { get; }
        public string Path;


        public DataService()
        {
            Path = System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, "19325f02-bb86-40ae-b111-bf495e23e.db3");
            ////var location = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "TestDB.db3");

            //Connection = new SQLiteAsyncConnection(location, true);
            //CreateTableAsync();
        }

        public bool IsFirstTime()
        {
            if (System.IO.File.Exists(Path))
            {
                return true;
            }
            return false;
        }

        public void initializeDatabase()
        {

        }

        private async void CreateTableAsync()
        {
            CreateTablesResult SettingTable = await Connection.CreateTableAsync<Setting>();
        }
    }
}
