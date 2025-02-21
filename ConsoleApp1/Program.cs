namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();

            pq.Enqueue("C", 1);
            pq.Enqueue("A", 1);
            pq.Enqueue("B", 9);
            pq.Enqueue("D", 3);

            while (pq.Size() > 0) {
                Console.WriteLine(pq.Dequeue());
            }

        }
    }
}
