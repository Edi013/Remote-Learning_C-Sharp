namespace iQuest.VendingMachine.DataLayer
{
    public class Product
    {
        internal int ColumnId { get; set;}
        internal string Name { get; set; }
        internal float Price { get; set;} 
        internal int Quantity { get; set; }

        public Product(int columnId, string name, float price, int quantity)
        {
            ColumnId = columnId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public Product()
        {
        }

        public override string ToString()
        {
            return $"{ColumnId, -2}{Name, -15}{Price, -7}{Quantity,-3}";    
        }
    }
}