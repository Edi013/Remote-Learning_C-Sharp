﻿namespace iQuest.VendingMachine.Business
{
    public class ProductSale
    {
        public string ProductName { get; set; }
        public TimeInterval TimeInterval { get; set; }
        public int Quantity { get; set; }
        public ProductSale(string productName, TimeInterval timeInterval, int quantity)
        {
            ProductName = productName;
            TimeInterval = timeInterval;
            Quantity = quantity;
        }
    }
}
