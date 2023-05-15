namespace iQuest.VendingMachine.Business
{
    public class VolumeReportProduct
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<StockReportProduct> Products { get; set; }

        public VolumeReportProduct()
        {
        }

        public VolumeReportProduct(DateTime startTime, DateTime endTime, List<StockReportProduct> products)
        {
            StartTime = startTime;
            EndTime = endTime;
            Products = products;
        }
    }
}
