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
        IReportsView reportsView;

        public StockReportUseCase(IProductRepository productRepository, IReportRepository<StockReport> stockReportRepository, IReportsView reportsView)
        {
            this.productRepository = productRepository;
            this.reportRepository = stockReportRepository;
            this.reportsView = reportsView;
        }

        public void Execute()
        {
            reportRepository.Add(new StockReport(productRepository.GetProducts()));
            reportsView.DisplaySuccessMessage("Stock report generated !");
        }
    }
}
