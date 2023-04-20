namespace iQuest.VendingMachine.JsonReports
{
    public class SalesReportProduct
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }

        public SalesReportProduct(DateTime date, string name, decimal price, string paymentMethod)
        {
            Date = date;
            Name = name;
            Price = price;
            PaymentMethod = paymentMethod;
        }
    }
}
