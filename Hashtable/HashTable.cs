namespace Hashtable
{
    public class HashTable<T>
    {
        private readonly Node<T>[] _buckets;

        public int Count 
        { get
            {
                int count = 0;

                foreach (var bucket in _buckets)
                {
                    Node<T> current = bucket;

                    if (current == null)
                        continue;
                    count++;

                    while(current.Next != null)
                    {
                        current = current.Next;
                        count++;
                    }
                }

                return count;
            }
        }

        public HashTable(int size)
        {
            _buckets = new Node<T>[size];
        }

        //Indexer
        public Node<T> this[int i] => _buckets[i]; 
        
        public void DisplayAll()
        {
            foreach (var bucket in _buckets)
            {
                Node<T> current = bucket;

                if (current == null)
                    continue;
                Console.WriteLine(current.ToString());

                while (current.Next != null)
                {
                    current = current.Next;
                    Console.WriteLine(current.ToString());
                }
            }
        }
        public T Get(string key)
        {
            ValidateKey(key);

            var (_, node) = GetNodeByKey(key);

            if (node == null) 
                throw new ArgumentOutOfRangeException
                    (nameof(key), $"The key '{key}' is not found");

            return node.Value;
        }
        public void Add(string key, T item)
        {
            ValidateKey(key);

            var valueNode = new Node<T> { Key = key, Value = item, Next = null };
            int position = GetBucketByKey(key);
            Node<T> listNode = _buckets[position];

            if(listNode == null)
            {
                _buckets[position] = valueNode;
            }
            else
            {
                while(listNode.Next != null)
                {
                    listNode = listNode.Next;
                }
                listNode.Next = valueNode;
            }
        }
        public bool Remove (string key)
        {
            ValidateKey(key);
            int position = GetBucketByKey(key);

            var (previous, current) = GetNodeByKey(key);

            if (current == null) 
                return false;
            if (previous == null)
            {
                _buckets[position] = null;
                return true;
            }
        
            previous.Next = current;
            return true;
        }
        public bool ContainsKey(string key)
        {
            ValidateKey(key);

            var (_, node) = GetNodeByKey(key);

            return node != null;
        }
        public int GetBucketByKey(string key)
        {
            // e.g. of custom hash fn:
            // return key[0] % _buckets.Length;
            return Math.Abs(key.GetHashCode() % _buckets.Length);
        }
        protected (Node<T> previous, Node<T> current) GetNodeByKey(string key)
        {
            int position = GetBucketByKey(key);
            Node<T> current = _buckets[position];
            Node<T> previous = null;

            while(current != null)
            {
                if (current.Key == key)
                    return (previous, current);

                previous = current;
                current = current.Next;
            }

            return (null, null);
        }
        protected void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
        }
    }
}