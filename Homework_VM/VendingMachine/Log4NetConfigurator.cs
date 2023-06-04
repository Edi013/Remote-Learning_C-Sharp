using System.Configuration;
using log4net.Config;

namespace iQuest.VendingMachine
{
    public class Log4NetConfigurator
    {
        public static void Configure()
        {
            string pathToLogFile = ConfigurationManager.AppSettings["LogFilePath"];
            if (!File.Exists(pathToLogFile))
            {
                File.Create(pathToLogFile);
            }

            string logPath = ConfigurationManager.AppSettings["LogFilePath"];
            FileInfo configFile = new FileInfo(logPath);
            XmlConfigurator.Configure(configFile);
        }
    }
}
