namespace iQuest.VendingMachine.JsonReports
{
    public class JsonVolumeReportContent : VolumeReportProduct
    {
        public JsonVolumeReportContent()
        {
        }
        public JsonVolumeReportContent(DateTime startTime, DateTime endTime, List<StockReportProduct> products)
           : base(startTime, endTime, products)
        {
        }
        
    }
}
