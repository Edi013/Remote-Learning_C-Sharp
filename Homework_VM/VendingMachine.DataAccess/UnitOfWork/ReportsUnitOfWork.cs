using iQuest.VendingMachine.Business;
namespace iQuest.VendingMachine.DataAccess
{
    public class ReportsUnitOfWork<T> : IReportsUnitOfWork<T>
    {
        private EfDbContext _dbContext;

        public IProductRepository ProductRepository { get; }
        public ISaleRepository SaleRepository { get; }
        public IReportRepository<T> ReportRepository { get; }

        public ReportsUnitOfWork(IProductRepository ProductRepository, ISaleRepository SaleRepository,
            IReportRepository<T> ReportRepository, EfDbContext dbContext)
        {
            this.ProductRepository = ProductRepository;
            this.SaleRepository = SaleRepository;
            this.ReportRepository = ReportRepository;
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
