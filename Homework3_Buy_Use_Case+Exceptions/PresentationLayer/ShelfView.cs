using iQuest.VendingMachine.DataLayer;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShelfView : DisplayBase
    {
        public void DisplayProducts(IEnumerable<Product> listOfProducts)
        {
            Console.WriteLine();
            Console.WriteLine();
            DisplayLine("A list of all products will be displayed as:" , ConsoleColor.White);
            DisplayLine("Product number, name, price, quantity " , ConsoleColor.White);
            Console.WriteLine();

            foreach(Product product in listOfProducts){
                Console.WriteLine(product.ToString());    
            }
        }
    }
}