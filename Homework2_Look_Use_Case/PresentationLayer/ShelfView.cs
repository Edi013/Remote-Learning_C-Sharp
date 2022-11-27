using iQuest.VendingMachine.DataLayer;

namespace iQuest.VendingMachine.PresentationLayer
{
    class ShelfView
    {
        public ShelfView(){}

        public void DisplayProducts(IEnumerable<Product> listOfProducts)
        {
            Console.WriteLine("Product number | name | price | quantyti");
            foreach(Product product in listOfProducts){
                Console.WriteLine($"{product.ColumnId}.{product.Name}    {product.Price}   {product.Quantity} ");    
            }
        }
    }
}