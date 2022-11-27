namespace iQuest.VendingMachine.DataLayer
{
    class ProductRepository
    {
        public List<Product> ListOfProducts;

        public ProductRepository()
        {
            ListOfProducts.AddRange( new Product[]
            {
                new Product(),
                new Product()
            });
        }

        public List<Product> GetAll(){
            return ListOfProducts;
        }
    }
}