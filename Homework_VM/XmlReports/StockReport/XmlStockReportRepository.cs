using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.XmlReports
{
    public class XmlStockReportRepository : XmlFileReportsRepository<StockReportContent>, IReportRepository<StockReport>
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
        private XmlReport<StockReportContent> ToXmlStockReport(StockReport stockReport)
        {
            var content = CreateReportContent(stockReport);
            return new XmlReport<StockReportContent>()
            {
                ReportName = stockReport.Name,
                GeneratedTime = stockReport.GeneratedTime,
                Content = content
            };
        }

        public void Add(StockReport stockReport)
        {
            GenerateFile(ToXmlStockReport(stockReport));
        }
    }
}
