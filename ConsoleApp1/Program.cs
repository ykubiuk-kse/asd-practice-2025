namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> ht = new HashTable<string, int>(2);

            ht.Set("key1", 1);
            ht.Print();
            ht.Set("key2", 2);
            ht.Print();
            ht.Set("key3", 2);
            ht.Print();
            ht.Set("key1", 11);
            ht.Print();
        }
    }
}
