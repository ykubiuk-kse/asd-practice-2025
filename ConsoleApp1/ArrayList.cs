public class ArrayList
{
    private int[] array;
    private int capacity;
    private int size;

    public ArrayList()
    {
        capacity = 8;
        size = 0;
        array = new int[capacity];
    }


    /*
    Worst: O(N)
    Average: O(1)
    */
    public void PushBack(int element)
    {
        array[size] = element;
        size++;

        if (size == capacity)
        {
            Resize();
        }
    }

    /*
    Worst: O(N) + O(N) = O(N)
    Average: O(N)
    */
    public void PushFront(int element)
    {
        // O(N)
        for (int i = size; i > 0; i--)
        {
            array[i] = array[i - 1];
        }

        array[0] = element;
        size++;

        // O(N)
        if (size == capacity)
        {
            Resize();
        }
    }

    // O(1)
    public int PopBack()
    {
        if (size == 0)
        {
            throw new Exception("ArrayList is empty!");
        }

        size--;
        int result = array[size];

        return result;
    }

    // O(N)
    public int PopFront()
    {
        if (size == 0)
        {
            throw new Exception("ArrayList is empty!");
        }

        int result = array[0];

        for (int i = 0; i < size; i++)
        {
            array[i] = array[i + 1];
        }

        size--;

        return result;
    }

    // O(1)
    public void SetAt(int element, int index)
    {
        if (index < 0 || index > size - 1)
        {
            throw new Exception("Out of bounds access!");
        }

        array[index] = element;
    }

    // O(1)
    public int GetAt(int index)
    {
        if (index < 0 || index > size - 1)
        {
            throw new Exception("Out of bounds access!");
        }

        return array[index];
    }

    private void Resize()
    {
        capacity *= 2;
        int[] newArray = new int[capacity];

        for (int i = 0; i < size; i++)
        {
            newArray[i] = array[i];
        }

        array = newArray;
    }

    public int Size() {
        return size;
    }
}

