﻿using System;
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
        internal static void DeleteAllDataFromTable(SQLiteConnection connection, string tableName)
        {
            using (SQLiteCommand createTableCommand = new SQLiteCommand(
              $"DELETE FROM  {tableName} ", connection))
            {
                createTableCommand.ExecuteNonQuery();
            }
        }
        internal static List<Product> GetProducts(SQLiteConnection connection)
        {
            using (SQLiteCommand selectDataCommand = new SQLiteCommand(
                   "SELECT * FROM Products;",
                   connection))
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
            using (SQLiteCommand updateCommand = new SQLiteCommand($"UPDATE Products SET Quantity = {product.Quantity} - 1 WHERE ColumnId = {productId}",connection))
            {
                updateCommand.ExecuteNonQuery();
            }
        }
    }
}
