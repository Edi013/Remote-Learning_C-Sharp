namespace iQuest.VendingMachine.DataLayer
{
    internal class ProductRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            // Daca utilizam o lista din afara:
            // parametru: List<Product> listOfProducts
            // ListOfProducts = listOfProducts;

            // Daca utilizam o lista interna:
            products = new List<Product>() {
                new Product(1, "7Days", 4.99F, 10),
                new Product(2, "Rolls", 3.99F, 7),
                new Product(3, "Napoleon", 2.99F, 1),
                new Product(4, "Ice coffee", 9.99F, 12)
            };
        }

        public List<Product> GetAll(){
            return products;
        }
    }
}