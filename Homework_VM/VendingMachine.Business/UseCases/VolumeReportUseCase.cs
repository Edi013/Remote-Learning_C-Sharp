using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public class VolumeReportUseCase : IUseCase
    {
        IReportsUnitOfWork<VolumeReport> unitOfWork;
        IReportsView reportsView;
        public VolumeReportUseCase(IReportsUnitOfWork<VolumeReport> unitOfWork, IReportsView reportsView)
        {
            this.unitOfWork = unitOfWork;
            this.reportsView = reportsView;
        }

        public void Execute()
        {
            unitOfWork.ReportRepository.Add(
                new VolumeReport(
                    unitOfWork.SaleRepository.GetGroupedByProduct(
                         reportsView.AskForTimeInterval())));
            reportsView.DisplaySuccessMessage("Volume report generated !");

            unitOfWork.SaveChanges();
        }
    }
}
