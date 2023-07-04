using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.DataAccess
{
    public class EfProductRepository : IProductRepository
    {
        private EfDbContext dbContext;

        public EfProductRepository(EfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddOrReplace(Product product)
        {
            var existingProduct = GetProductByColumnId(product.ColumnId);
            if (existingProduct == null)
            {
                dbContext.Products.Add(product);
                return;
            }

            Update(product);
        }

        public void DecreaseQuantity(Product product)
        {
            product.Quantity--;
            Update(product);
        }

        public Product? GetProductByColumnId(int columnId)
        {
            return dbContext.Products
                .FirstOrDefault(p => p.ColumnId == columnId);
        }

        public List<Product> GetProducts()
        {
                var a = dbContext.Products.ToList();
            return a; 
        }

        public void Update(Product product)
        {
            dbContext.Products
                .First(eachProduct => product.ColumnId == eachProduct.ColumnId)
                .Quantity = product.Quantity;
        }
    }
}
