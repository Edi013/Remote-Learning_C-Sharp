using iQuest.VendingMachine.Business;
using Newtonsoft.Json;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonStockReportRepository : JsonFileReportsRepository, IStockReportRepository
    {
        public JsonStockReportRepository()
        {
        }

        private JsonStockReportContent CreateReportContent(StockReport stockReport)
        {
            var content = new JsonStockReportContent()
            {
                ReportName = stockReport.Name,
                GeneratedTime = stockReport.GeneratedTime,
            };

            foreach (Product item in stockReport)
            {
                content.Name.Add(item.Name);
                content.Quantity.Add(item.Quantity);
            }

            return content;
        }
        private JsonReport ToJsonStockReport(StockReport stockReport)
        {
            var content = CreateReportContent(stockReport);
            return new JsonReport()
            {
                ReportAsJsonString = JsonConvert.SerializeObject(content)
            };
        }

        public void Add(StockReport stockReport)
        {

            GenerateFile(ToJsonStockReport(stockReport));
        }

    }
}
