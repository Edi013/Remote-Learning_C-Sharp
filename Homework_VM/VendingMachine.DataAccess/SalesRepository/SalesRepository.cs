using System.Configuration;
using System.Text;
using System.Text.Json;
using iQuest.VendingMachine.Business;
using Newtonsoft.Json;

namespace iQuest.VendingMachine.DataAccess
{
    public class SalesRepository : ISaleRepository
    {
        private List<Sale> sales { get; set; }
        private string jsonFileName;
        private string jsonFilePath;

        public SalesRepository()
        {
            jsonFileName = "SalesDb.json";
            jsonFilePath = ConfigurationManager.AppSettings["SalesRepositoryDbPath"] + jsonFileName;

            ReadStoredSales();
        }
        private void ReadStoredSales()
        {
                sales = new List<Sale>();
            if(!File.Exists(jsonFilePath))
            {
                File.WriteAllText(jsonFilePath, "");
                return;
            }

            sales = JsonConvert.DeserializeObject<List<Sale>>(
                File.ReadAllText(jsonFilePath));
        }
        private void Update()
        {
            File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(sales, Formatting.Indented), Encoding.UTF8);
        }

        public IEnumerable<Sale> Get(TimeInterval interval)
        {
            return sales
                .Where(s => 
                    interval.StartDate <= s.Date && s.Date <= interval.EndDate);
        }
        public IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval interval)
        {
            return sales
                .Where(s =>
                        interval.StartDate <= s.Date && s.Date <= interval.EndDate)
                .GroupBy(s => s.Name)
                .Select(t => new ProductSale(t.First().Name, interval, t.Count()));
        }
        public void Add(Sale sale)
        {
            sales.Add(sale);
            Update();
        }

    }
}
