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
        IStockReportRepository stockReportRepository;

        public StockReportUseCase(IProductRepository productRepository, IStockReportRepository stockReportRepository)
        {
            this.productRepository = productRepository;
            this.stockReportRepository = stockReportRepository;
        }

        public void Execute()
        {

        }
    }
}
