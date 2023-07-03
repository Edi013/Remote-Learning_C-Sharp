using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.DataAcces
{
    public class EfProductRepository : IProductRepository
    {
        private ApplicationDbContext dbContext;

        public EfProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddOrReplace(Product product)
        {
            var existingProduct = GetProductByColumnId(product.ColumnId);
            if (existingProduct == null)
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return;
            }

            Update(product);
            dbContext.SaveChanges();
        }

        public void DecreaseQuantity(Product product)
        {
            product.Quantity--;
            Update(product);
            dbContext.SaveChanges();
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
            dbContext.SaveChanges();
        }
    }
}
