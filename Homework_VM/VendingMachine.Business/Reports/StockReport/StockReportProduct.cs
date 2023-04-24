namespace iQuest.VendingMachine.Business
{
    public class StockReportProduct
    {
        public string Name;
        public int Quantity;
        public StockReportProduct(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public StockReportProduct()
        {
        }
    }
}
