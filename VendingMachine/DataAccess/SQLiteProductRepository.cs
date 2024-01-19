using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;


namespace Nagarro.VendingMachine.DataAccess
{
    internal class SQLiteProductRepository : IProductRepository
    {
        private SQLiteConnection connection;

        public SQLiteProductRepository(string connectionStringT)
        {
            var connectionString = "Data Source=C:\\Users\\drago\\source\\repos\\SQLiteDB\\vendindb.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                using (SQLiteCommand createTableCommand = new SQLiteCommand(
                "CREATE TABLE IF NOT EXISTS Products (ColumnId INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Price DECIMAL, Quantity INTEGER);", connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }




        }
        public List<Product> GetAll()
        {
            throw new NotImplementedException();

        }

        public Product GetByColumn(int columnId)
        {
            throw new NotImplementedException();
        }
    }
}
