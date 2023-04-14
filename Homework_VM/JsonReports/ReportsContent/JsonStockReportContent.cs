using System.Collections.Generic;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonStockReportContent
    {
        public DateTime GeneratedTime;

        public string ReportName { get; set; }
        public List <string> Name { get; set; }
        public List <int> Quantity { get; set; }
    }
}
