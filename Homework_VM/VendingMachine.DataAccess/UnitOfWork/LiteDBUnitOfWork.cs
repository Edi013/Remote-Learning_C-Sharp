using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.DataAccess
{
    public class LiteDBUnitOfWork : IProductAndSalesUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        public List<Product> Products { get; set; }
        public ISaleRepository SaleRepository { get; }
        public List<Sale> Sales { get; set; }

        public LiteDBUnitOfWork(IProductRepository productRepository, ISaleRepository saleRepository)
        {
            
            ProductRepository = productRepository;
            SaleRepository = saleRepository;

            Products = productRepository.GetProducts();

            DateTime StartDate = new DateTime(year: 0, day: 0, month: 0);
            DateTime EndDate = DateTime.Now;
            Sales = (List<Sale>?)saleRepository.Get(
                new TimeInterval(StartDate, EndDate));

        }
        
        public void SaveChanges()
        {
        }
    }
}
