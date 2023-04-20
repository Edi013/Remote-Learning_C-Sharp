using iQuest.VendingMachine.Business;
using Newtonsoft.Json;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonStockReportRepository : JsonFileReportsRepository<JsonStockReportContent>, IReportRepository<StockReport>
    {
        private JsonStockReportContent CreateReportContent(StockReport stockReport)
        {
            var content = new JsonStockReportContent();

            foreach (Product item in stockReport)
            {
                content.Add( 
                    new StockReportProduct(
                        item.Name, item.Quantity));
            }

            return content;
        }
        private JsonReport<JsonStockReportContent> ToJsonStockReport(StockReport stockReport)
        {
            var content = CreateReportContent(stockReport);
            return new JsonReport<JsonStockReportContent>()
            {
                ReportName = stockReport.Name,
                GeneratedTime = stockReport.GeneratedTime,
                Content = content
            };
        }

        public void Add(StockReport stockReport)
        {
            GenerateFile(ToJsonStockReport(stockReport));
        }
    }
}
