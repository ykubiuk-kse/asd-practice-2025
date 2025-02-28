class HashNode<K, V> where K : IEquatable<K>
{
    public K key;
    public V value;

    public HashNode(K _key, V _value)
    {
        key = _key;
        value = _value;
    }

    public override string ToString() {
        return $"[{key}|{value}]";
    }
}

class HashTable<K, V> where K : IEquatable<K>
{
    LinkedList<HashNode<K, V>>[] bucketList;
    int size;
    int capacity;

    public HashTable(int _capacity = 8)
    {
        size = 0;
        capacity = _capacity;

        bucketList = new LinkedList<HashNode<K, V>>[capacity];

        for (int i = 0; i < capacity; i++)
        {
            bucketList[i] = new LinkedList<HashNode<K, V>>();
        }
    }

    public void Set(K key, V value)
    {
        int hash = GetHash(key);

        LinkedList<HashNode<K, V>> bucket = bucketList[hash];


        if (bucket.Size() > 0)
        {
            Node<HashNode<K, V>>? cur = bucket.GetNodeAt(0);
            while (cur != null)
            {
                if (cur.data.key.Equals(key))
                {
                    cur.data.value = value;
                    return;
                }

                cur = cur.next;
            }
        }

        HashNode<K, V> newNode = new HashNode<K, V>(key, value);
        bucket.PushFront(newNode);

        size++;
    }

    private int GetHash(K key)
    {
        return Math.Abs(key.GetHashCode()) % capacity;
    }

    public void Print()
    {
        for (int i = 0; i < capacity; i++)
        {
            bucketList[i].Print();
        }
        Console.WriteLine();
    }

    private void Resize() {
        capacity *= 2;
        var oldBucketList = bucketList;

        bucketList = new LinkedList<HashNode<K, V>>[capacity];

        for (int i = 0; i < oldBucketList.Length; i++) {
            var bucket = oldBucketList[i];

            var cur = bucket.GetNodeAt(0);

            while (cur != null) {
                int hash = GetHash(cur.data.key);
                bucketList[hash].PushFront(new HashNode<K, V>(cur.data.key, cur.data.value));

                cur = cur.next;
            } 
        }
    }
}