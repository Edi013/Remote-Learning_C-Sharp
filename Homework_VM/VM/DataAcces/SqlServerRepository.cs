﻿using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace iQuest.VendingMachine.DataLayer
{
    public class SqlServerRepository : IProductRepository
    {
        private string _connectionString;

        public SqlServerRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            Console.WriteLine("Connection string :" + _connectionString);
        }
        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            try
            {
                using var connection = new SqlConnection(_connectionString);
                string queryString = "Select * From dbo.Products";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

               foreach(DataRow row in dataset.Tables[0].Rows)
                {
                     products.Add(new Product
                     {
                         ColumnId = Convert.ToInt32(row["ColumnId"]),
                         Name = row["Name"].ToString(),
                         Price = Convert.ToSingle(row["Price"]),
                         Quantity = Convert.ToInt32(row["Quantity"])
                     });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in SqlServerRepo - line 41 ~");
                Console.WriteLine(e.Message);
            }

            return products;
        }

        public Product? GetProductByColumnId(int columnId)
        {
            var products = new List<Product>();
            using var connection = new SqlConnection(_connectionString);
            string queryString = $"Select * From dbo.Products Where ColumnId = '{columnId}'";
            var command = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
              
            return new Product
            {
                ColumnId = Convert.ToInt32(reader["ColumnId"]),
                Name = reader["Name"].ToString(),
                Price = Convert.ToSingle(reader["Price"]),
                Quantity = Convert.ToInt32(reader["Quantity"])
            };         
        }

        public void DecreaseQuantity(Product product)
        {
            product.Quantity--;

            using var connection = new SqlConnection(_connectionString);
            string queryString = $"UPDATE Products SET Quantity = '{product.Quantity}' Where ColumnId='{product.ColumnId}';";

            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet dataset = new DataSet();

            adapter.TableMappings.Add("Products", "Products");
            //adapter.Update(dataset, "dbo.Products");
            adapter.Fill(dataset);
        }
    }
}
