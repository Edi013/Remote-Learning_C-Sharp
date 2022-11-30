namespace iQuest.VendingMachine.DataLayer
{
    internal class Product
    {
        private int ColumnId { get; set;}
        private string Name { get; set; }
        private float Price { get; set;} 
        private int Quantity { get; set; }

        public Product(int columnId, string name, float price, int quantity)
        {
            ColumnId = columnId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{ColumnId, -2}{Name, -15}{Price, -7}{Quantity,-3}";    
        }
    }
}