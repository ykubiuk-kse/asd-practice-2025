namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> ht = new HashTable<string, int>(2);

            ht.Set("key1", 1);
            ht.Set("key2", 2);
            ht.Set("key3", 2);
            ht.Set("key1", 11);
            ht.Print();

            Console.WriteLine(ht.Remove("key1"));
            ht.Print();
        }
    }
}
