namespace iQuest.VendingMachine.Business
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        public ISaleRepository SaleRepository { get; }

        public void SaveChanges();
    }
}
