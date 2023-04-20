using iQuest.VendingMachine.Business;
using Newtonsoft.Json;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonSalesReportRepository : JsonFileReportsRepository<JsonSalesReportContent>, IReportRepository<SalesReport>
    {
        private JsonSalesReportContent CreateReportContent(SalesReport salesReport)
        {
            var content = new JsonSalesReportContent();

            foreach(var item in salesReport)
            {
                content.Add(
                    new SalesReportProduct(
                       item.Date, item.Name, item.Price, item.PaymentMethod));
            }

            return content;
        }
        private JsonReport<JsonSalesReportContent> ToJsonStockReport(SalesReport salesReport)
        {
            var content = CreateReportContent(salesReport);
            return new JsonReport<JsonSalesReportContent>()
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
