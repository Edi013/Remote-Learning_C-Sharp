namespace iQuest.VendingMachine.Business
{
    public class Sale
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }

        public Sale(string name, DateTime date, decimal price, string paymentMethod)
        {
            Name = name;
            Date = date;
            Price = price;
            PaymentMethod = paymentMethod;
        }
    }
}
