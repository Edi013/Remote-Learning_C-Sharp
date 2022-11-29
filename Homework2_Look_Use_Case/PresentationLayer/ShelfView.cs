using iQuest.VendingMachine.DataLayer;

namespace iQuest.VendingMachine.PresentationLayer
{
    class ShelfView
    {
        public ShelfView(){}

        public void DisplayProducts(IEnumerable<Product> listOfProducts)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("A list of all products will be displayed as:");
            Console.WriteLine("Product number, name, price, quantity ");
            Console.WriteLine();

            foreach(Product product in listOfProducts){
                Console.WriteLine(product.ToString());    
            }
        }
    }
}