using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.XmlReports
{
    public class XmlVolumeReportRepository : XmlFileReportsRepository<VolumeReportContent>, IReportRepository<VolumeReport>
    {
        private VolumeReportContent CreateReportContent(VolumeReport volumeReport)
        {
            var content = new VolumeReportContent()
            {
                StartTime = volumeReport.Select(x => x.TimeInterval.StartDate).Min(),
                EndTime = volumeReport.Select(x => x.TimeInterval.EndDate).Max(),
                Products = new List<StockReportProduct>()
            };

            foreach (var item in volumeReport)
            {
                content.Products.Add(new StockReportProduct(item.ProductName, item.Quantity));
            }

            return content;
        }
        private XmlReport<VolumeReportContent> ToJsonStockReport(VolumeReport volumeReport)
        {
            var content = CreateReportContent(volumeReport);
            return new XmlReport<VolumeReportContent>()
            {
                ReportName = volumeReport.Name,
                GeneratedTime = volumeReport.GeneratedTime,
                Content = content,
            };
        }

        public void Add(VolumeReport volumeReport)
        {
            GenerateFile(ToJsonStockReport(volumeReport));
        }
    }
}
