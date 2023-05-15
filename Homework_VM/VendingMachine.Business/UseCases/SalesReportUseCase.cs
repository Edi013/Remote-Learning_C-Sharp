namespace iQuest.VendingMachine.Business
{
    public class SalesReportUseCase : IUseCase
    {
        ISaleRepository productRepository;
        IReportRepository<SalesReport> reportsRepository;
        IReportsView reportsView;

        public SalesReportUseCase(ISaleRepository productRepository, 
            IReportRepository<SalesReport> reportsRepository, IReportsView reportsView)
        {
            this.productRepository = productRepository;
            this.reportsRepository = reportsRepository;
            this.reportsView = reportsView;
        }

        public void Execute()
        {
            reportsRepository.Add(new SalesReport(
                productRepository.Get(
                   reportsView.AskForTimeInterval())));
            reportsView.DisplaySuccessMessage("Sales report generated !");
        }
    }
}
