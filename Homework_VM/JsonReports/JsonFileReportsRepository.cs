using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonFileReportsRepository
    {
        private string DirectoryName { get; set; }

        public JsonFileReportsRepository(string directoryName)
        {
            DirectoryName = directoryName;
        }

        private void CreateReportsDirectory()
        {
            if(!Directory.Exists(DirectoryName))
                Directory.CreateDirectory(DirectoryName);
        }
        private void GenerateFileName(string reportName, DateTime time)
        {
            var generatedType = ConfigurationManager.AppSettings["ReportType"];
            var fileName = reportName + "-" + time.ToString() + "." + generatedType;
            if (!File.Exists(fileName))
                File.Create(fileName);
        }
        private void Generate(string filePath, JsonReport jsonReport)
        {
            CreateReportsDirectory();
            GenerateFileName(jsonReport.ReportName, jsonReport.GeneratedTime);
        }

        protected void GenerateFile(JsonReport jsonReport)
        {
            Generate(ConfigurationManager.AppSettings["ReportFilePath"], jsonReport);
        }
    }
}
