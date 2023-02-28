using LiteDB;

namespace iQuest.VendingMachine.Business
{
    public class Product
    {
        [BsonId]
        public int ColumnId { get; set;}
        public string Name { get; set; }
        public float Price { get; set;}
        public int Quantity { get; set; }

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
