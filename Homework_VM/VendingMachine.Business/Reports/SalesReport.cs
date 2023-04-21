namespace iQuest.VendingMachine.Business
{
    public class SalesReport : List<Sale>
    {
        public string Name { get; } = "Sales Report";
        public DateTime GeneratedTime { get; set; }

        public SalesReport(IEnumerable<Sale> products)
            : base(products)
        {
            GeneratedTime = DateTime.Now;
        }

    }
}
