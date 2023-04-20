using System.Collections.Generic;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonStockReportContent : List<StockReportProduct>
    {
        public JsonStockReportContent() : base()
        {
        }
    }
}
