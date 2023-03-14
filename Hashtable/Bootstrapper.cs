namespace Hashtable
{
    public class Bootstrapper
    {
        public static void Main()
        {
            var hashTable = new HashTable<int>(4);

            Console.WriteLine("key 'One' will lead to table " + hashTable.GetBucketByKey("One"));
            Console.WriteLine("key 'Two' will lead to table " + hashTable.GetBucketByKey("Two"));
            Console.WriteLine("key 'Three' will lead to table " + hashTable.GetBucketByKey("Three"));

            hashTable.Add("a", 1);
            hashTable.Add("b", 2);
            hashTable.Add("c", 3);
            hashTable.Add("d", 4);
            hashTable.Add("e", 5);
            hashTable.Add("f", 6);
            hashTable.Add("g", 7);
            hashTable.Add("h", 8);

            hashTable.DisplayAll();

            try
            {
                Console.WriteLine(hashTable.Get("Four"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(hashTable.Count);
            return;
        }
    }
}