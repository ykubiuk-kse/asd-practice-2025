namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            MinHeap heap = new MinHeap();

            for (int i = 10; i >= 0; i--) {
                heap.Add(i);
            }

            heap.Print();

            for (int i = 0; i <= 10; i++) {
                Console.WriteLine(heap.ExtractMin());
            }
        }
    }
}
