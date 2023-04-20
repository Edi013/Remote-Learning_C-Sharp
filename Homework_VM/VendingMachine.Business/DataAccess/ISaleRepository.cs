namespace iQuest.VendingMachine.Business
{
    public interface ISaleRepository
    {
        public IEnumerable<Sale> Get(TimeInterval interval);
        public IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval interval);
        public void Add(Sale sale);
    }
}
