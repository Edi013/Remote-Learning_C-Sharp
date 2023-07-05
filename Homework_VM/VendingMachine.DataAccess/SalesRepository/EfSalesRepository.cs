using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.DataAcces;
using Microsoft.EntityFrameworkCore;

namespace iQuest.VendingMachine.DataAccess
{
    public class EfSalesRepository : ISaleRepository
    {
        private EfDbContext dbContext;

        public EfSalesRepository(EfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    
        public void Add(Sale sale)
        {
           dbContext.Sales.Add(sale);
        }

        public IEnumerable<Sale> Get(TimeInterval interval)
        {
           return dbContext.Sales
                .Where(x => x.Date >= interval.StartDate 
                && x.Date <= interval.EndDate);
        }

        public IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval interval)
        {
            var sales = Get(interval);
            
            return sales
                .GroupBy(x => x.ProductName)
                .Select(t => new ProductSale(t.First().ProductName, interval, t.Count()));
        }
    }
}

