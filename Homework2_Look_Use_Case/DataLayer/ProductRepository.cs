namespace iQuest.VendingMachine.DataLayer
{
    class ProductRepository
    {
        private List<Product> ListOfProducts;

        public ProductRepository()
        {
            // Daca utilizam o lista din afara:
            // parametru: List<Product> listOfProducts
            // ListOfProducts = listOfProducts;

            // Daca utilizam o lista interna:
            ListOfProducts = new List<Product>();
            ListOfProducts.Add(new Product(1, "7Days", 4.99F, 10));
            ListOfProducts.Add(new Product(2, "Rolls", 3.99F, 7));
            ListOfProducts.Add(new Product(3, "Napoleon", 2.99F, 1));
            ListOfProducts.Add(new Product(4, "Ice coffee", 9.99F, 12));
        }

        public List<Product> GetAll(){
            return ListOfProducts;
        }
    }
}