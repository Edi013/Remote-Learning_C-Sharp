namespace iQuest.VendingMachine.DataLayer
{
    class ProductRepository
    {
        private List<Product> ListOfProducts;

        public ProductRepository()
        {
            // Utilizam o lista din afara 
            // parametru: List<Product> listOfProducts
            // ListOfProducts = listOfProducts;


            // Utilizam o lista interna, private, aici trb sa-i bagam AddProduct() si RemoveProduct()
            ListOfProducts = new List<Product>();
            ListOfProducts.Add(new Product(1, "7Days", 4.99F, 10));
            ListOfProducts.Add(new Product(2, "Rolls", 3.99F, 7));
            ListOfProducts.Add(new Product(3, "Napoleon", 3.00F, 1));
        }

        public List<Product> GetAll(){
            return ListOfProducts;
        }
    }
}