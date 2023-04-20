using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonVolumeReportRepository : JsonFileReportsRepository<JsonVolumeReportContent>, IReportRepository<VolumeReport>
    {
        private JsonVolumeReportContent CreateReportContent(VolumeReport volumeReport)
        {
            var content = new JsonVolumeReportContent()
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
        private JsonReport<JsonVolumeReportContent> ToJsonStockReport(VolumeReport volumeReport)
        {
            var content = CreateReportContent(volumeReport);
            return new JsonReport<JsonVolumeReportContent>()
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
