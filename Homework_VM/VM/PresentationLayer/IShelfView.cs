using iQuest.VendingMachine.DataLayer;

namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products);
    }
}