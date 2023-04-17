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
        private string Path { get; set; }

        public JsonFileReportsRepository()
        {
            Path = ConfigurationManager.AppSettings["ReportsFilePath"];
        }

        private void CreateReportsDirectory()
        {
            Directory.CreateDirectory(Path);
        }
        private void GenerateFileName(string reportName, DateTime time)
        {
            var generatedType = ConfigurationManager.AppSettings["ReportsType"];
            var reportsFilePath = Path;
            var fileName = reportName + "-" + time.ToString() + "." + generatedType;
            if (!File.Exists(reportsFilePath+fileName))
                File.Create(reportsFilePath+fileName);
        }
        private void Generate(string filePath, JsonReport jsonReport)
        {
            CreateReportsDirectory();
            GenerateFileName(jsonReport.ReportName, jsonReport.GeneratedTime);
        }

        protected void GenerateFile(JsonReport jsonReport)
        {
            Generate(Path, jsonReport);
        }
    }
}
