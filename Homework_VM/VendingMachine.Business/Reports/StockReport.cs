using System.Runtime.InteropServices;

namespace iQuest.VendingMachine.Business
{
    public class StockReport : List<Product>
    {
        public DateTime GeneratedTime { get; set; }

        public string Name { get; private set; }

        public StockReport(IEnumerable<Product> products, string name = "Stock Report"):
            base(products)
        {
            GeneratedTime = DateTime.Now;
            Name = name;
        }
    }
}
