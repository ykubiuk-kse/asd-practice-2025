public class Stack
{
    private int capacity;
    private int size;
    private int[] array;

    public Stack(int cap)
    {
        capacity = cap;
        size = 0;
        array = new int[capacity];
    }

    public void Push(int value)
    {
        if (size == capacity)
        {
            throw new Exception("Stack is full!");
        }
        array[size++] = value;
    }

    public int Pop()
    {
        if (size == 0)
        {
            throw new Exception("Stack is empty!");
        }
        return array[--size];
    }

    public int Size() {
        return size;
    }
}