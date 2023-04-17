using System.Collections.Generic;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonStockReportContent 
    {
        public List<ProductPOCO> Stock { get; set; }
        public JsonStockReportContent()
        {
            Stock = new List<ProductPOCO>();
        }
    }
}
