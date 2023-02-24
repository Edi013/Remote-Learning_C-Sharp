using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.DataLayer
{
    public class InMemoryRepository : IProductRepository
    {
        private static List<Product> products;

        public  InMemoryRepository()
        {
            products = new List<Product>() {
                new Product(1, "7Days", 4.99F, 10),
                new Product(2, "Rolls", 3.99F, 7),
                new Product(3, "Napoleon", 2.99F, 1),
                new Product(4, "Ice coffee", 9.99F, 12)
            };
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product? GetProductByColumnId(int columnId)
        {
            foreach(Product product in products)
            {
                if(product.ColumnId == columnId)
                return product;
            }
            return null;
        }

        public void DecreaseQuantity(Product product)
        {
            product.Quantity--;
        }
    }
}
