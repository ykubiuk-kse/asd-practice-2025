class MinHeap {
    private ArrayList array = new ArrayList();

    private int LeftIndex(int parentIndex) {
        return parentIndex * 2 + 1;
    }

    private int RightIndex(int parentIndex) {
        return parentIndex * 2 + 2;
    }

    private int ParentIndex(int childIndex) {
        return (childIndex - 1) / 2;
    }

    public void Add(int element) {
        array.PushBack(element);
        HeapifyUp();
    }

    public int ExtractMin() {
        int min = array.GetAt(0);

        Swap(0, array.Size() - 1);
        array.PopBack();

        HeapifyDown(0);

        return min;
    }

    private void HeapifyUp() {
        int index = array.Size() - 1;

        while(index > 0 && array.GetAt(ParentIndex(index)) > array.GetAt(index)) {
            Swap(index, ParentIndex(index));
            index = ParentIndex(index);
        }
    }

    private void HeapifyDown(int index) {
        int leftChildIndex = LeftIndex(index);
        int rightChildIndex = RightIndex(index);
        int smallestIndex = index;

        if (leftChildIndex < array.Size() && array.GetAt(smallestIndex) > array.GetAt(leftChildIndex)) {
            smallestIndex = leftChildIndex;
        }

        if (rightChildIndex < array.Size() && array.GetAt(smallestIndex) > array.GetAt(rightChildIndex)) {
            smallestIndex = rightChildIndex;
        }

        if (smallestIndex != index) {
            Swap(index, smallestIndex);
            HeapifyDown(smallestIndex);
        }
    }

    private void Swap(int index1, int index2) {
        int temp = array.GetAt(index1);
        array.SetAt(array.GetAt(index2), index1);
        array.SetAt(temp, index2);
    }

    public void Print() {
        for (int i = 0; i < array.Size(); i++) {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
        for (int i = 0; i < array.Size(); i++) {
            Console.Write($"{array.GetAt(i)} ");
        }
        Console.WriteLine();
    }
}