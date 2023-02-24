namespace iQuest.VendingMachine.DataLayer
{
    public interface IProductRepository
    {
        private static List<Product> products;
        public List<Product> GetProducts();
        public Product? GetProductByColumnId(int columnId);

        public void DecreaseQuantity(Product product);

    }
}
