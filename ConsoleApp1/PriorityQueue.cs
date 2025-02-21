


public class PriorityQueue<TElement, TPriority> where TPriority: IComparable<TPriority> {
    private class PQItem: IComparable<PQItem> {
        public TElement element;
        public TPriority priority;

        public int CompareTo(PQItem? other)
        {
            return priority.CompareTo(other!.priority);
        }

        public PQItem(TElement _element, TPriority _priority) {
            element = _element;
            priority = _priority;
        }
    }

    private MinHeap<PQItem> heap = new MinHeap<PQItem>();

    public void Enqueue(TElement element, TPriority priority) {
        PQItem pqItem = new PQItem(element, priority);
        heap.Add(pqItem);
    }

    public TElement Dequeue() {
        PQItem result = heap.ExtractMin();

        return result.element;
    }

    public int Size() {
        return heap.Size();
    }
}