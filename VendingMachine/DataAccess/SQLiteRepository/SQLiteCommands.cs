using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            using (SQLiteCommand deleteDataCommand = new SQLiteCommand(
              $"DELETE FROM  {tableName} ", connection))
            {
                deleteDataCommand.ExecuteNonQuery();
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
            Product product = GetProductById(connection, productId);
            using (SQLiteCommand updateCommand = new SQLiteCommand($"UPDATE Products SET Quantity = @Quantity - 1 WHERE ColumnId = @ColumnId", connection))
            {
                updateCommand.Parameters.AddWithValue("@ColumnId", product.ColumnId);
                updateCommand.Parameters.AddWithValue("@Quantity", product.Quantity);

                updateCommand.ExecuteNonQuery();
            }
        }
        internal static void AddProduct(SQLiteConnection connection, ProductDto product)
        {
            bool productAlreadyExists = false;
            string checkProductQuery = "SELECT COUNT(*) FROM Products WHERE Name = @ProductNameToCheck;";
            using (SQLiteCommand checkProductCommand = new SQLiteCommand(checkProductQuery, connection))
            {
                checkProductCommand.Parameters.AddWithValue("@ProductNameToCheck", product.Name);

                int productCount = Convert.ToInt32(checkProductCommand.ExecuteScalar());

                if (productCount > 0)
                {
                    productAlreadyExists = true;
                }
                else
                {
                    productAlreadyExists = false;
                }
            }
            if (!productAlreadyExists)
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
            else
            {
                using (SQLiteCommand updateCommand = new SQLiteCommand($"UPDATE Products SET Quantity = Quantity +  @Quantity WHERE Name = @ProductNameToCheck", connection))
                {
                    updateCommand.Parameters.AddWithValue("@ProductNameToCheck", product.Name);
                    updateCommand.Parameters.AddWithValue("@Quantity", product.Quantity);

                    updateCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
