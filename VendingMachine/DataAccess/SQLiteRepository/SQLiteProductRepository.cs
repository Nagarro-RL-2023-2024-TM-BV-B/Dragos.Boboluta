using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace Nagarro.VendingMachine.DataAccess.SQLiteRepository
{
    internal class SQLiteProductRepository : IProductRepository
    {
        private readonly SQLiteConnection connection;

        public SQLiteProductRepository(string connectionStringT)
        {

            try
            {
                connection = new SQLiteConnection(connectionStringT);
                connection.Open();
                SQLiteCommands.CreateTable(connection, "Products");
                var initial = SQLiteCommands.InitialProductsCheck(connection);
                if (initial)
                {
                    connection.Close();
                }
                else
                {
                    SQLiteCommands.DeleteAllDataFromTable(connection, "Products");
                    SQLiteCommands.AddInitialProducts(connection);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void DispenseProduct(Product product)
        {
            try
            {
                connection.Open();
                SQLiteCommands.DispenseProduct(connection, product.ColumnId);
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                connection.Open();
                List<Product> list = SQLiteCommands.GetProducts(connection);
                connection.Close();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public Product GetByColumn(int columnId)
        {
            try
            {
                connection.Open();
                Product product = SQLiteCommands.GetProductById(connection, columnId);
                connection.Close();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
