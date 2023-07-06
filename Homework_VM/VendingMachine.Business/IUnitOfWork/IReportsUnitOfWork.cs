namespace iQuest.VendingMachine.Business
{
    public interface IReportsUnitOfWork<ReportType>
    {
        IProductRepository ProductRepository { get; }
        ISaleRepository SaleRepository { get; }
        IReportRepository<ReportType> ReportRepository { get; }

        public void SaveChanges();
    }
}
