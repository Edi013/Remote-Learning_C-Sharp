namespace iQuest.VendingMachine.DataLayer
{
    internal class ProductRepository
    {
        private static List<Product> products;

       public static int MinColumnNumber(){
            int min = products[0].ColumnId;

            foreach(Product product in products)
            {
                if (product.ColumnId < min)
                    min = product.ColumnId;
            }

            return min;   
        }
       public static int MaxColumnNumber(){
            int max = products[0].ColumnId;

            foreach(Product product in products)
            {
                if (product.ColumnId > max)
                    max = product.ColumnId;
            }

            return max;
        }

        public  ProductRepository()
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

        
        public Product? GetProductByColumnId(int columnId)
        {
            foreach(Product product in products)
            {
                if(product.ColumnId == columnId)
                return product;
            }
            return null;
        }
    }
}