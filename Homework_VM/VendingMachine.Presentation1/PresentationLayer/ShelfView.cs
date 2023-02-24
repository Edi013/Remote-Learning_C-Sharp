using iQuest.VendingMachine.DataLayer;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShelfView : DisplayBase, IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            Console.WriteLine();
            Console.WriteLine();
            DisplayLine("A list of all products will be displayed as:" , ConsoleColor.White);
            DisplayLine("Product number, name, price, quantity " , ConsoleColor.White);
            Console.WriteLine();

            foreach(Product product in products){
                Console.WriteLine(product.ToString());    
            }
        }
    }
}