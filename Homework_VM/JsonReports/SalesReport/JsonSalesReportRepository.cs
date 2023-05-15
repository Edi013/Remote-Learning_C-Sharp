using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonSalesReportRepository : JsonFileReportsRepository<SalesReportContent>, IReportRepository<SalesReport>
    {
        private SalesReportContent CreateReportContent(SalesReport salesReport)
        {
            var content = new SalesReportContent();

            foreach(var item in salesReport)
            {
                content.Add(
                    new SalesReportProduct(
                       item.Date, item.ProductName, item.Price, item.PaymentMethod));
            }

            return content;
        }
        private JsonReport<SalesReportContent> ToJsonStockReport(SalesReport salesReport)
        {
            var content = CreateReportContent(salesReport);
            return new JsonReport<SalesReportContent>()
            {
                ReportName = salesReport.Name,
                GeneratedTime = salesReport.GeneratedTime,
                Content = content 
            };
        }

        public void Add(SalesReport salesReport)
        {
            GenerateFile(ToJsonStockReport(salesReport));
        }
    }
}
