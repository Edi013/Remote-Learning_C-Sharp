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
        private string GenerateFileName(string reportName, ref DateTime time)
        {
            var generatedType = ConfigurationManager.AppSettings["ReportsType"];
            var reportsFilePath = Path;
            return reportsFilePath + "Stock Report - " +
                time.ToString("yyyy MM dd HHmmss") + "." + generatedType;
        }
        private void Generate(string filePath, JsonReport jsonReport)
        {
            CreateReportsDirectory();
            var fileName = GenerateFileName
                (jsonReport.ReportName, ref jsonReport.GeneratedTime);

            File.WriteAllText(fileName, jsonReport.ReportAsJsonString);
        }

        protected void GenerateFile(JsonReport jsonReport)
        {
            Generate(Path, jsonReport);
        }
    }
}
