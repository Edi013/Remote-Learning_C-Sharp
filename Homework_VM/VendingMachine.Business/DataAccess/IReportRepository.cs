namespace iQuest.VendingMachine.Business
{
    public interface IReportRepository<T>
    {
        public void Add(T report);
    }
}
