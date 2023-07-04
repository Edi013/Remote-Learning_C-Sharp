using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.DataAccess
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IProductRepository ProductRepository { get; }
        public ISaleRepository SaleRepository { get; }

        public EfUnitOfWork(IProductRepository productRepository, ISaleRepository saleRepository, ApplicationDbContext context)
        {
            ProductRepository = productRepository;
            SaleRepository = saleRepository;
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
