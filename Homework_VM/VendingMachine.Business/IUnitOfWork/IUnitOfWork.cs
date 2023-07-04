namespace iQuest.VendingMachine.Business
{
    public interface IProductAndSalesUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        public ISaleRepository SaleRepository { get; }

        public void SaveChanges();
    }
}
