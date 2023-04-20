namespace iQuest.VendingMachine.Business
{
    public class VolumeReport : List<ProductSale>
    {
        public string Name { get; set; }
        public DateTime GeneratedTime { get; set; }
        public VolumeReport(IEnumerable<ProductSale> productSale, string name = "Volume report")
                : base(productSale)
        {
            Name = name;
            GeneratedTime = DateTime.Now;
        }
    }
}
