using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public class VolumeReportUseCase : IUseCase
    {
        ISaleRepository saleRepository;
        IReportRepository<VolumeReport> reportRepository;
        IReportsView reportsView;
        public VolumeReportUseCase(ISaleRepository saleRepository,
            IReportRepository<VolumeReport> reportRepository, IReportsView reportsView)
        {
            this.saleRepository = saleRepository;
            this.reportRepository = reportRepository;
            this.reportsView = reportsView;
        }

        public void Execute()
        {
            reportRepository.Add(
                new VolumeReport(
                    saleRepository.GetGroupedByProduct(
                         reportsView.AskForTimeInterval())));
        }
    }
}
