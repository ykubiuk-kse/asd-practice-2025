class Queue
{
    private int capacity;
    private int size;
    private int front;
    private int rear;
    private int[] array;

    public Queue(int cap)
    {
        capacity = cap;
        size = 0;
        front = 0;
        rear = 0;
        array = new int[capacity];
    }

    public void Enqueue(int value)
    {
        if (size == capacity)
        {
            throw new Exception("Queue is full!");
        }

        array[rear] = value;
        rear = (rear + 1) % capacity;
        size++;
    }

    public int Dequeue()
    {
        if (size == 0)
        {
            throw new Exception("Queue is empty!");
        }

        int value = array[front];
        front = (front + 1) % capacity;
        size--;

        return value;
    }

    public int Size() {
        return size;
    }
}