namespace Hashtable
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public string Key { get; set; }
        public T Value { get; set; }

        public override string ToString()
        {
            return $"key '{Key}' : value '{Value}'.";
        }
    }
}
