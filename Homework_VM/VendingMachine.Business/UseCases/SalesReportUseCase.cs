namespace iQuest.VendingMachine.Business
{
    public class SalesReportUseCase : IUseCase
    {
        IReportsUnitOfWork<SalesReport> unitOfWork;
        IReportsView reportsView;

        public SalesReportUseCase(IReportsUnitOfWork<SalesReport> unitOfWork,
            IReportsView reportsView)
        {
            this.unitOfWork = unitOfWork;
            this.reportsView = reportsView;
        }

        public void Execute()
        {
            unitOfWork.ReportRepository.Add(new SalesReport(
                unitOfWork.SaleRepository.Get(
                   reportsView.AskForTimeInterval())));
            reportsView.DisplaySuccessMessage("Sales report generated !");

            unitOfWork.SaveChanges();
        }
    }
}
