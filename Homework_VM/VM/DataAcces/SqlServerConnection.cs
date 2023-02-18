using iQuest.VendingMachine.DataLayer;
using Microsoft.Extensions.Configuration;

public static class SqlServerConnection
{
    private static IConfiguration _configuration;

    public static SqlServerRepository SetUp()
    {
        var builder = new ConfigurationBuilder()
               .SetBasePath("D:\\technologii\\GitHubDesktop\\NagarroRepo\\RL_Csharp\\Homework_VM\\VM\\") //Directory.GetCurrentDirectory()
               .AddJsonFile("appsettings.json", false, true);

        _configuration = builder.Build();

        SqlServerRepository database = new SqlServerRepository(_configuration);

       return database;
    }
}
