namespace iQuest.VendingMachine.XmlReports
{
    public class XmlReport<XmlContent>
    {
        public DateTime GeneratedTime { get; set; }

        public string ReportName { get; set; }
        public XmlContent Content { get; set; }
    }
}
