using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace iQuest.VendingMachine.DataLayer
{
    public class SqlServerRepository : IProductRepository
    {
        private string _connectionString;

        public SqlServerRepository(IConfiguration configuration)
        {
            Console.WriteLine("Connection string :" + configuration.GetConnectionString("Default"));
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            try
            {
                using var connection = new SqlConnection(_connectionString);

                string queryString = "Select * From dbo.Products";
                var command = new SqlCommand(queryString, connection);
                //command.CommandText = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                     products.Add(new Product
                     {
                         ColumnId = Convert.ToInt32(reader["ColumnId"]),
                         Name = reader["Name"].ToString(),
                         Price = Convert.ToSingle(reader["Price"]),
                         Quantity = Convert.ToInt32(reader["Quantity"])
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
            var products = GetProducts();
            if (!products.Any())
                return new Product { Quantity = 0 };

            return products.FirstOrDefault(x => x.ColumnId == columnId);
        }
    }
}
