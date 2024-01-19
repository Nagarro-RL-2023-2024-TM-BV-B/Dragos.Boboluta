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
            var connectionString = "Data Source=C:\\Users\\drago\\source\\repos\\SQLiteDB\\vendingdb.db;Version=3;";
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
                SQLiteCommands.CreateTable(connection,"Products");
                SQLiteCommands.DeleteAllDataFromTable(connection, "Products");
                SQLiteCommands.AddInitialProducts(connection);
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
                List<Product> list =  SQLiteCommands.GetProducts(connection);
                connection.Close();
                return list;
            }
            catch(Exception ex)
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
            throw new NotImplementedException();
        }
    }
}
