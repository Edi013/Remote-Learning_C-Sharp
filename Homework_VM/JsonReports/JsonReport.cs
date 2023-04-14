namespace iQuest.VendingMachine.JsonReports
{
    public class JsonReport
    {
        public DateTime GeneratedTime;

        public string ReportName { get; set; }
        public string ReportAsJsonString { get; set; }
    }
}
