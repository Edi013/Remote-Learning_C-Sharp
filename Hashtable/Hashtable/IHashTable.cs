using Hashtable;

namespace HashTable
{
    public interface IHashTable<T>
    {
        public int Count { get;  }

        public void DisplayAll();
        public T Get(string key);
        public void Add(string key, T item);
        public bool Remove(string key);
        public bool ContainsKey(string key);
        public int GetBucketByKey(string key);
        public (Node<T> previous, Node<T> current) GetNodeByKey(string key);
        public void ValidateKey(string key);
    }
}