using iQuest.VendingMachine.Business;
using Newtonsoft.Json;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonStockReportRepository : JsonFileReportsRepository, IStockReportRepository
    {
        private JsonStockReportContent CreateReportContent(StockReport stockReport)
        {
            var content = new JsonStockReportContent();

            foreach (Product item in stockReport)
            {
                content.Stock.Add( 
                    new ProductPOCO(
                        item.Name, item.Quantity));
            }

            return content;
        }
        private JsonReport ToJsonStockReport(StockReport stockReport)
        {
            var content = CreateReportContent(stockReport);
            return new JsonReport()
            {
                ReportName = stockReport.Name,
                GeneratedTime = stockReport.GeneratedTime,
                ReportAsJsonString = JsonConvert.SerializeObject(content.Stock)
            };
        }

        public void Add(StockReport stockReport)
        {
            GenerateFile(ToJsonStockReport(stockReport));
        }
    }
}
