namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphAL gAl = new GraphAL(5);

            gAl.AddEdge(0, 1);
            gAl.AddEdge(0, 2);
            gAl.AddEdge(2, 3);
            gAl.AddEdge(2, 4);
            gAl.AddEdge(3, 4);

            gAl.Print();

            gAl.DFS(0);
            gAl.DFSRecursive(0);
            gAl.BFS(0);
        }
    }
}
