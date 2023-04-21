namespace iQuest.VendingMachine.Business
{
    public class VolumeReport : List<ProductSale>
    {
        public string Name { get; } = "Volume Report";
        public DateTime GeneratedTime { get; set; }
        public VolumeReport(IEnumerable<ProductSale> productSale)
                : base(productSale)
        {
            GeneratedTime = DateTime.Now;
        }
    }
}
