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

        public StockReportUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute()
        {

        }
    }
}
