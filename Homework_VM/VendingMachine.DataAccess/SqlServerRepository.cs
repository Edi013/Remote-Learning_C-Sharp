using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;

namespace iQuest.VendingMachine.DataAcces
{
    public class SqlServerRepository : IProductRepository
    {
        private string _connectionString;

        public SqlServerRepository(string connectionString)
        {
            _connectionString = connectionString;
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
            catch (Exception)
            {
                throw;
            }

            return products;
        }

        public Product? GetProductByColumnId(int columnId)
        {
            using var connection = new SqlConnection(_connectionString);
            string queryString = $"Select * From dbo.Products Where ColumnId = '{columnId}'";
            var command = new SqlCommand(queryString, connection);

            try
            {
                connection.Open();  
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                if (!reader.HasRows)
                    return null;

                return new Product
                {
                    ColumnId = Convert.ToInt32(reader["ColumnId"]),
                    Name = reader["Name"].ToString(),
                    Price = Convert.ToSingle(reader["Price"]),
                    Quantity = Convert.ToInt32(reader["Quantity"])
                };         
            }
            catch(InvalidOperationException e)
            {
                throw new Exception("Parsing error ~", e);
            }
            catch (Exception)
            {
                throw;
            }
            return null; //unreachable
        }

        public void DecreaseQuantity(Product product)
        {
            product.Quantity--;

            UpdateProductsTableWith($"UPDATE Products SET Quantity = '{product.Quantity}' Where ColumnId='{product.ColumnId}';");
        }


        public void AddOrReplace(Product product)
        {
            var existingProduct = GetProductByColumnId(product.ColumnId);

            if (existingProduct == null)
            {
                UpdateProductsTableWith($"INSERT INTO Products(ColumnId, Name, Price, Quantity) VALUES " +
                    $"({product.ColumnId},'{product.Name}',{product.Price},{product.Quantity})");
                return;
            }

            UpdateProductsTableWith(
                $"UPDATE Products " +
                $"SET ColumnId={product.ColumnId}, Name={product.Name}, Price={product.Price}, Quantity={product.Quantity} " +
                $"WHERE ColumnId = {product.ColumnId}");
        }

        private void UpdateProductsTableWith(string sqlQuery)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                DataSet dataset = new DataSet();

                adapter.TableMappings.Add("Products", "Products");

                adapter.Fill(dataset);
            }
        }

        public void Update(Product product)
        {
            string query = 
                "UPDATE Products " +
                $"SET Quantity={product.Quantity} " +
                $"WHERE ColumnId = {product.ColumnId}";

            UpdateProductsTableWith(query);
        }
    }
}
