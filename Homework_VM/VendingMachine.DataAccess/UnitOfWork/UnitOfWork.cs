using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.DataAcces
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        public IProductRepository productRepository { get; }
        public ISaleRepository saleRepository { get; }

        public UnitOfWork(IProductRepository productRepository, ISaleRepository saleRepository, ApplicationDbContext context)
        {
            this.productRepository = productRepository;
            this.saleRepository = saleRepository;
            this.context = context;
        }
    }
}
