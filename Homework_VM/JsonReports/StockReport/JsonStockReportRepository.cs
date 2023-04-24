using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonStockReportRepository : JsonFileReportsRepository<StockReportContent>, IReportRepository<StockReport>
    {
        private StockReportContent CreateReportContent(StockReport stockReport)
        {
            var content = new StockReportContent();

            foreach (Product item in stockReport)
            {
                content.Add( 
                    new StockReportProduct(
                        item.Name, item.Quantity));
            }

            return content;
        }
        private JsonReport<StockReportContent> ToJsonStockReport(StockReport stockReport)
        {
            var content = CreateReportContent(stockReport);
            return new JsonReport<StockReportContent>()
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
