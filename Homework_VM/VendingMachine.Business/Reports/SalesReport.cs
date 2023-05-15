namespace iQuest.VendingMachine.Business
{
    public class SalesReport : List<Sale>
    {
        public string Name { get; } = "Sales Report";
        public DateTime GeneratedTime { get; } = DateTime.Now;

        public SalesReport(IEnumerable<Sale> products)
            : base(products)
        {
        }

    }
}
