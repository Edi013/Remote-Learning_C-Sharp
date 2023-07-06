using System.Configuration;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;
using LiteDB;

namespace iQuest.VendingMachine.DataAccess
{
    public class LiteDBRepository : IProductRepository
    {
        private string _connectionString;
     
        public LiteDBRepository(string connectionString)
        {
            _connectionString = connectionString;

            InsertDataIfEmpty();
        }

        private void InsertDataIfEmpty()
        {
            using (var database = new LiteDatabase(
                        _connectionString))
            {
                var collection = database.GetCollection<Product>("Products");
                if (collection.Count() == 0)
                {
                    var products = new List<Product>() {
                        new Product(1, "7Days", 4.99F, 10),
                        new Product(2, "Rolls", 3.99F, 7),
                        new Product(3, "Napoleon", 2.99F, 1),
                        new Product(4, "Ice coffee", 9.99F, 12)
                    };
                    collection.InsertBulk(products);
                }
            }
        }
        public void DecreaseQuantity(Product product)
        {
            product.Quantity--;

            using (var database = new LiteDatabase(
                        _connectionString))
            {
                var collection = database.GetCollection<Product>("Products");
                collection.Update(product);
            }
        }

        public Product? GetProductByColumnId(int columnId)
        {
            Product searchedProduct = null;

            using (var database = new LiteDatabase(
                        _connectionString))
            {
                var collection = database.GetCollection<Product>("Products");
                searchedProduct = collection.FindById(columnId);
            }

            return searchedProduct;
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            using (var database = new LiteDatabase(
                        _connectionString))
            {
                var collection = database.GetCollection<Product>("Products");
                
                products = collection.FindAll().ToList();
            }
            return products;
        }

        public void AddOrReplace(Product product)
        {
            using (var database = new LiteDatabase(
                        _connectionString))
            {
                var collection = database.GetCollection<Product>("Products");
                collection.Upsert(product);
            }
        }

        public void Update(Product product)
        {
            using (var database = new LiteDatabase(
                        _connectionString))
            {
                var collection = database.GetCollection<Product>("Products");
                collection.Update(product);
            }
        }
    }
}
