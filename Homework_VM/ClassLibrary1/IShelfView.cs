namespace iQuest.VendingMachine.Business
{
    public interface IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products);
    }
}
