namespace iQuest.VendingMachine.JsonReports
{
    public class ProductPOCO
    {
        public string Name;
        public int Quantity;
        public ProductPOCO(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
