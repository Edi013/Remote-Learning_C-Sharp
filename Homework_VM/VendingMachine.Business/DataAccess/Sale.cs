namespace iQuest.VendingMachine.Business
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }

        public Sale()
        {
        }
        public Sale(string productName, DateTime date, decimal price, string paymentMethod)
        {
            ProductName = productName;
            Date = date;
            Price = price;
            PaymentMethod = paymentMethod;
        }
    }
}
