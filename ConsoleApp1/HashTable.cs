class HashNode<K, V> where K : IEquatable<K>
{
    public K key;
    public V value;

    public HashNode(K _key, V _value)
    {
        key = _key;
        value = _value;
    }

    public override string ToString()
    {
        return $"[{key}|{value}]";
    }
}

class HashTable<K, V> where K : IEquatable<K>
{
    LinkedList<HashNode<K, V>>[] bucketList;
    int size;
    int capacity;
    float maxLoadFactor;

    public HashTable(int _capacity = 8, float _maxLoadFactor = 0.6f)
    {
        size = 0;
        capacity = _capacity;
        maxLoadFactor = _maxLoadFactor;

        bucketList = CreateBucketList(capacity);
    }

    private LinkedList<HashNode<K, V>>[] CreateBucketList(int capacity)
    {
        var result = new LinkedList<HashNode<K, V>>[capacity];

        for (int i = 0; i < capacity; i++)
        {
            result[i] = new LinkedList<HashNode<K, V>>();
        }

        return result;
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

        if (IsTimeToResize())
        {
            Resize();
        }
    }

    // dict["key"] -> "value" 
    public V Get(K key)
    {
        int index = GetHash(key);

        var bucket = bucketList[index];

        if (bucket.Size() == 0)
        {
            throw new Exception("No such key!");
        }

        var cur = bucket.GetNodeAt(0);

        while (cur != null)
        {
            if (key.Equals(cur.data.key))
            {
                return cur.data.value;
            }

            cur = cur.next;
        }

        throw new Exception("No such key!");
    }

    public V Remove(K key)
    {
        int index = GetHash(key);

        var bucket = bucketList[index];

        if (bucket.Size() == 0)
        {
            throw new Exception("No such key!");
        }

        var cur = bucket.GetNodeAt(0);
        int i = 0;

        while (cur != null)
        {
            if (key.Equals(cur.data.key))
            {
                return bucket.RemoveAt(i).value;
            }

            i++;
            cur = cur.next;
        }

        throw new Exception("No such key!");
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

    private void Resize()
    {
        capacity *= 2;
        var oldBucketList = bucketList;

        bucketList = CreateBucketList(capacity);

        for (int i = 0; i < oldBucketList.Length; i++)
        {
            var bucket = oldBucketList[i];


            if (bucket.Size() == 0)
            {
                continue;
            }

            var cur = bucket.GetNodeAt(0);

            while (cur != null)
            {
                int hash = GetHash(cur.data.key);
                bucketList[hash].PushFront(new HashNode<K, V>(cur.data.key, cur.data.value));

                cur = cur.next;
            }
        }
    }

    private bool IsTimeToResize()
    {
        float lf = (float)size / capacity;

        return lf >= maxLoadFactor;
    }
}