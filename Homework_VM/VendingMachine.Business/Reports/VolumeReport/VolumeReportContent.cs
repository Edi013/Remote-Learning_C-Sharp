namespace iQuest.VendingMachine.Business
{
    public class VolumeReportContent : VolumeReportProduct
    {
        public VolumeReportContent()
        {
        }
        public VolumeReportContent(DateTime startTime, DateTime endTime, List<StockReportProduct> products)
           : base(startTime, endTime, products)
        {
        }
        
    }
}
