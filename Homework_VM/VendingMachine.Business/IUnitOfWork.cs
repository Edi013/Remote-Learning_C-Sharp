namespace iQuest.VendingMachine.Business
{
    public interface IUnitOfWork
    {
        IProductRepository productRepository { get; }
        ISaleRepository saleRepository { get; }
    }
}
