namespace iQuest.VendingMachine.Business
{
    public class SalesReportProduct
    {
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }

        public SalesReportProduct()
        {
        }
        public SalesReportProduct(DateTime date, string productName, decimal price, string paymentMethod)
        {
            Date = date;
            ProductName = productName;
            Price = price;
            PaymentMethod = paymentMethod;
        }
    }
}
