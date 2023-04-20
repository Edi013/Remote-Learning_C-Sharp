using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonFileReportsRepository<T>
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
        private string GenerateFileName(string reportName, DateTime time)
        {
            var generatedType = ConfigurationManager.AppSettings["ReportsType"];

            return Path + reportName + " - " +
                time.ToString("yyyy MM dd HHmmss") + "." + generatedType;
        }

        private void Generate(JsonReport<T> jsonReport)
        {
            CreateReportsDirectory();

            var fileName = GenerateFileName
                (jsonReport.ReportName, jsonReport.GeneratedTime);

            File.WriteAllText(
                fileName, JsonConvert.SerializeObject(jsonReport.Content, Formatting.Indented)); // Encoding.UTF8
        }

        protected void GenerateFile(JsonReport<T> jsonReport)
        {
            Generate(jsonReport);
        }
    }
}
