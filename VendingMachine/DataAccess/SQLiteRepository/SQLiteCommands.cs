using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Nagarro.VendingMachine.Models.ProductModel;

namespace Nagarro.VendingMachine.DataAccess.SQLiteRepository
{
    internal static class SQLiteCommands
    {
        private static readonly ICollection<ProductDto> Products = new List<ProductDto>
        {
            new ProductDto
            {
                Name = "Chocolate",
                Price = 9,
                Quantity = 20,
            },
            new ProductDto
            {
                Name = "Chips",
                Price = 5,
                Quantity = 7,
            },
            new ProductDto
            {
                Name = "Still Water",
                Price = 2,
                Quantity = 10,
            }
        };
        internal static void CreateTable(SQLiteConnection connection, string tableName)
        {
            using (SQLiteCommand createTableCommand = new SQLiteCommand(
               $"CREATE TABLE IF NOT EXISTS {tableName} (ColumnId INTEGER PRIMARY KEY, Name TEXT, Price DECIMAL, Quantity INTEGER);", connection))
            {
                createTableCommand.ExecuteNonQuery();
            }
        }

        internal static void AddInitialProducts(SQLiteConnection connection)
        {
            foreach (ProductDto product in Products)
            {
                using (SQLiteCommand insertDataCommand = new SQLiteCommand(
                    $"INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity);",
                    connection))
                {
                    insertDataCommand.Parameters.AddWithValue("@Name", product.Name);
                    insertDataCommand.Parameters.AddWithValue("@Price", product.Price);
                    insertDataCommand.Parameters.AddWithValue("@Quantity", product.Quantity);

                    insertDataCommand.ExecuteNonQuery();
                }
            }
        }
        internal static void DeleteAllDataFromTable(SQLiteConnection connection, string tableName)
        {
            using (SQLiteCommand createTableCommand = new SQLiteCommand(
              $"DELETE FROM  {tableName} ", connection))
            {
                createTableCommand.ExecuteNonQuery();
            }
        }
        internal static bool InitialProductsCheck(SQLiteConnection connection)
        {
            using (SQLiteCommand selectDataCommand = new SQLiteCommand("SELECT * FROM Products;", connection))
            {
                int rowCount = Convert.ToInt32(selectDataCommand.ExecuteScalar());

                return rowCount.Equals(0) ? false : true;
            }
        }

        internal static List<Product> GetProducts(SQLiteConnection connection)
        {
            using (SQLiteCommand selectDataCommand = new SQLiteCommand("SELECT * FROM Products;", connection))
            {
                using (SQLiteDataReader reader = selectDataCommand.ExecuteReader())
                {
                    List<Product> productList = new List<Product>();

                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ColumnId = Convert.ToInt32(reader["ColumnId"]),
                            Name = Convert.ToString(reader["Name"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        };

                        productList.Add(product);
                    }
                    return productList.Count > 0 ? productList : null;
                }
            }
        }
        internal static Product GetProductById(SQLiteConnection connection, int productId)
        {
            using (SQLiteCommand selectDataCommand = new SQLiteCommand($"SELECT * FROM Products WHERE ColumnId = {productId}", connection))
            {
                using (SQLiteDataReader reader = selectDataCommand.ExecuteReader())
                {
                    Product product = new Product();

                    while (reader.Read())
                    {
                        product = new Product
                        {
                            ColumnId = Convert.ToInt32(reader["ColumnId"]),
                            Name = Convert.ToString(reader["Name"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        };
                    }
                    return product != null ? product : null;
                }
            }
        }
        internal static void DispenseProduct(SQLiteConnection connection, int productId)
        {
            Product product = SQLiteCommands.GetProductById(connection, productId);
            using (SQLiteCommand updateCommand = new SQLiteCommand($"UPDATE Products SET Quantity = {product.Quantity} - 1 WHERE ColumnId = {productId}", connection))
            {
                updateCommand.ExecuteNonQuery();
            }
        }
        internal static void AddProduct(SQLiteConnection connection, ProductDto product)
        {
            using (SQLiteCommand insertDataCommand = new SQLiteCommand(
                    $"INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity);",
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
