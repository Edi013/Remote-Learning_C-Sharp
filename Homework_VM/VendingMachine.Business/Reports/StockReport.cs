using System.Runtime.InteropServices;

namespace iQuest.VendingMachine.Business
{
    public class StockReport : List<Product>
    {
        public string Name { get; } = "Stock Report";
        public DateTime GeneratedTime { get; } = DateTime.Now;

        public StockReport(IEnumerable<Product> products, ):
            base(products)
        {
        }
    }
}
