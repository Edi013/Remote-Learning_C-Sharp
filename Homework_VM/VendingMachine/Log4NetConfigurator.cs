using System.Configuration;
using log4net.Config;

namespace iQuest.VendingMachine
{
    public class Log4NetConfigurator
    {
        public static void Configure()
        {
            string pathToLogFile = ConfigurationManager.AppSettings["LoggerConfigFilePath"];
            if (!File.Exists(pathToLogFile))
            {
                File.Create(pathToLogFile);
            }

            FileInfo configFile = new FileInfo(pathToLogFile);
            XmlConfigurator.Configure(configFile);
        }
    }
}
