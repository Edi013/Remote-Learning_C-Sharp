using System.Runtime.InteropServices;

namespace iQuest.VendingMachine.Business
{
    public class StockReport : List<Product>
    {
        public DateTime GeneratedTime { get; set; }

        public string Name { get; } = "Stock Report";

        public StockReport(IEnumerable<Product> products, ):
            base(products)
        {
            GeneratedTime = DateTime.Now;
        }
    }
}
