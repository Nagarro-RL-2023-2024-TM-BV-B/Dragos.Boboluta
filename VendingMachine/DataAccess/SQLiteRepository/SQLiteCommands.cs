using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.VendingMachine.DataAccess.SQLiteRepository
{
    internal static class SQLiteCommands
    {
        private static readonly ICollection<Product> Products = new List<Product>
        {
            new Product
            {
                Name = "Chocolate",
                Price = 9,
                Quantity = 20,
                ColumnId = 1
            },
            new Product
            {
                Name = "Chips",
                Price = 5,
                Quantity = 7,
                ColumnId = 2
            },
            new Product
            {
                Name = "Still Water",
                Price = 2,
                Quantity = 10,
                ColumnId = 3
            }
        };
        internal static void CreateTable(SQLiteConnection connection,string tableName)
        {
            using (SQLiteCommand createTableCommand = new SQLiteCommand(
               $"CREATE TABLE IF NOT EXISTS {tableName} (ColumnId INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Price DECIMAL, Quantity INTEGER);", connection))
            {
                createTableCommand.ExecuteNonQuery();
            }
        }
        internal static void AddInitialProducts(SQLiteConnection connection)
        {
            foreach (Product product in Products)
            {
                using (SQLiteCommand insertDataCommand = new SQLiteCommand(
                    "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity);",
                    connection))
                {
                    insertDataCommand.Parameters.AddWithValue("@Name", product.Name);
                    insertDataCommand.Parameters.AddWithValue("@Price", product.Price);
                    insertDataCommand.Parameters.AddWithValue("@Quantity", product.Quantity);

                    insertDataCommand.ExecuteNonQuery();
                }
            }
        }
    
       
    }
}
