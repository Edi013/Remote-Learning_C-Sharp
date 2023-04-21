namespace iQuest.VendingMachine.Business
{
    public interface IProductRepository
    {
        private static List<Product> products;
        public List<Product> GetProducts();
        public Product? GetProductByColumnId(int columnId);

        public void DecreaseQuantity(Product product);
        public void IncreaseQuantity(QuantitySupply supply);
        public void AddOrReplace(Product product);

    }
}
