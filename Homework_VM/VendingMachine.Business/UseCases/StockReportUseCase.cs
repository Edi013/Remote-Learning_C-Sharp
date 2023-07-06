using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public class StockReportUseCase : IUseCase
    {
        IReportsUnitOfWork<StockReport> unitOfWork;
        IReportsView reportsView;

        public StockReportUseCase(IReportsUnitOfWork<StockReport> unitOfWork, IReportsView reportsView)
        {
            this.unitOfWork = unitOfWork;
            this.reportsView = reportsView;
        }

        public void Execute()
        {
            unitOfWork.ReportRepository.Add(
                new StockReport(unitOfWork.ProductRepository.GetProducts()));
            reportsView.DisplaySuccessMessage("Stock report generated !");
        }
    }
}
