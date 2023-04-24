using System.Data;
using System.Data.SqlClient;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.DataAcces
{
    public class SqlSalesRepository : ISaleRepository
    {
        private string _connectionString;

        public SqlSalesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Sale sale)
        {
            List<Sale> sales = new List<Sale>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var queryString = $"INSERT INTO Sales(ProductName, Price, Date, PaymentMethod) VALUES " +
                    $"('{sale.ProductName}', {sale.Price}, '{sale.Date}', '{sale.PaymentMethod}')";
                var command = new SqlCommand(queryString, connection);
                
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("SQL INSERT affected 0 rows");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<Sale> Get(TimeInterval interval)
        {
            List<Sale> sales = new List<Sale>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var queryString = $"SELECT * FROM Sales WHERE '{interval.StartDate}' <= Date and Date <= '{interval.EndDate}';";
                var command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {

                            sales.Add(new Sale()
                            {
                                Date          = (DateTime)reader["Date"],
                                PaymentMethod = (string)  reader["PaymentMethod"],
                                Price         = (decimal) reader["Price"],
                                ProductName   = (string)  reader["ProductName"]
                            });
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
                return sales;
        }

        public IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval interval)
        {

            var sales = Get(interval);
            
            return sales
                .GroupBy(x => x.ProductName)
                .Select(t => new ProductSale(t.First().ProductName, interval, t.Count()));
        }
    }
}
