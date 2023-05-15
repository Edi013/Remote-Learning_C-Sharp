using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace iQuest.VendingMachine.XmlReports
{
    public class XmlFileReportsRepository<T>
    {
        private string Path { get; }

        public XmlFileReportsRepository()
        {
            Path = ConfigurationManager.AppSettings["ReportsFilePath"];
        }

        private void CreateReportsDirectory()
        {
            Directory.CreateDirectory(Path);
        }
        private string GenerateFileName(string reportName, DateTime time)
        {
            return Path + reportName + " - " +
                time.ToString("yyyy MM dd HHmmss") + ".xml";
        }

        private void Generate(XmlReport<T> xmlReport)
        {
            CreateReportsDirectory();

            string fileName = GenerateFileName
                (xmlReport.ReportName, xmlReport.GeneratedTime);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };
            using (TextWriter stringWriter = new StreamWriter(fileName))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(xmlWriter, xmlReport.Content);
                }
            }
        }

        protected void GenerateFile(XmlReport<T> xmlReport)
        {
            Generate(xmlReport);
        }
    }
}
