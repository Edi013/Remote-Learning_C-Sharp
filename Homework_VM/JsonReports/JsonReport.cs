namespace iQuest.VendingMachine.JsonReports
{
    public class JsonReport<T>
    {
        public DateTime GeneratedTime { get; set; }

        public string ReportName { get; set; }
        public T Content { get; set; }
    }
}
