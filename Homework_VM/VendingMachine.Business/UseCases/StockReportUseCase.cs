using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public class StockReportUseCase : IUseCase
    {
        IProductRepository productRepository;
        IReportRepository<StockReport> reportRepository;

        public StockReportUseCase(IProductRepository productRepository, IReportRepository<StockReport> stockReportRepository)
        {
            this.productRepository = productRepository;
            this.reportRepository = stockReportRepository;
        }

        public void Execute()
        {
            reportRepository.Add(new StockReport(productRepository.GetProducts()));
        }
    }
}
