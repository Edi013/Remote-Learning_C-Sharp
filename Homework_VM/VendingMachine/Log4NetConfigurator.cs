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

            FileInfo configFile = new FileInfo("D:\\technologii\\GitHubDesktop\\NagarroRepo\\RL_Csharp\\Homework_VM\\VendingMachine\\log4net.config");
            XmlConfigurator.Configure(configFile);
        }
    }
}
