namespace iQuest.VendingMachine.Business
{
    public class SalesReport : List<Sale>
    {
        public string Name { get; set; }
        public DateTime GeneratedTime { get; set; }

        public SalesReport(IEnumerable<Sale> products, string name = "Sales Report")
            : base(products)
        {
            GeneratedTime = DateTime.Now;
            Name = name;
        }

    }
}
