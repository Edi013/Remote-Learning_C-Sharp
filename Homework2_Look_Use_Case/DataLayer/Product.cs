namespace iQuest.VendingMachine.DataLayer
{
    class Product
    {
        public int ColumnId { get; set;}
        public string Name { get; }
        public float Price { get; set;} 
        public int Quantity { get; set; }
        public Product(){}
        public Product(int columnId, string name, float price, int quantity)
        {
            ColumnId = columnId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}