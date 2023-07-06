using LiteDB;
using Microsoft.Extensions.Options;

namespace iQuest.VendingMachine.DataAccess
{
    public class LiteDBContext
    {
        public readonly LiteDatabase Context;
        public LiteDBContext(IOptions<LiteDbConfig> configs)
        {
            try
            {
                var db = new LiteDatabase(configs.Value.DatabasePath);
                if (db != null)
                    Context = db;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't find or create LiteDB database.", ex);
            }
        }

        public void SaveChanges(LiteDatabase actualContext)
        {
            actualContext = this.Context;
        }
    }

    public class LiteDbConfig
    {
        public string DatabasePath { get; set; }
    }
}
