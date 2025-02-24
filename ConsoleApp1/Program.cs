namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < 10; i++) {
                // list.Print();
                list.PushBack(i);
            }
            list.Print();

            list.SetAt(0, 10);
            list.Print();
            list.SetAt(9, 90);
            list.Print();
            list.SetAt(5, 50);
            list.Print();
            list.SetAt(1000, 123);

            // for (int i = 0; i < 10; i++) {
            //     list.Print();
            //     Console.WriteLine($"Deleting: {list.PopFront()}");
            // }

            // list.PopFront();
        }
    }
}
