public class Node<T>
{
    public T data;

    public Node<T>? next;
    public Node<T>? prev;

    public Node(T _data, Node<T>? _next = null, Node<T>? _prev = null)
    {
        data = _data;
        next = _next;
        prev = _prev;
    }
}

public class LinkedList<T>
{
    private Node<T>? head = null;
    private Node<T>? tail = null;
    private int size = 0;

    public void PushFront(T element)
    {
        Node<T> newNode = new Node<T>(element, head);

        if (head != null)
        {
            head.prev = newNode;
        }

        head = newNode;

        if (tail == null)
        {
            tail = head;
        }

        size++;
    }

    public void PushBack(T element)
    {
        if (head == null)
        {
            PushFront(element);
            return;
        }

        Node<T> newNode = new Node<T>(element, null, tail);

        tail!.next = newNode;
        tail = newNode;

        size++;
    }

    public T PopBack()
    {
        if (head == null)
        {
            throw new Exception("List is empty!");
        }

        T result = tail!.data;

        if (size == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail!.prev!.next = null;
            tail = tail.prev;
        }

        size--;
        return result;
    }

    public T PopFront()
    {
        if (size < 2)
        {
            return PopBack();
        }

        T result = head!.data;

        head = head.next;
        head!.prev = null;

        size--;
        return result;
    }

    public Node<T> GetNodeAt(int index)
    {
        if (index < 0 || index > size - 1)
        {
            throw new Exception("Out of bounds access!");
        }

        if (index == 0)
        {
            return head!;
        }

        if (index == size - 1)
        {
            return tail!;
        }

        Node<T> cur = head!;

        for (int i = 0; i < index; i++)
        {
            cur = cur.next!;
        }

        return cur;
    }

    public T GetAt(int index)
    {
        return GetNodeAt(index).data;
    }

    public void SetAt(int index, T element)
    {
        Node<T> node = GetNodeAt(index);

        node.data = element;
    }

    public T RemoveAt(int index)
    {
        if (index == 0)
        {
            return PopFront();
        }

        if (index == size - 1)
        {
            return PopBack();
        }

        var prev = GetNodeAt(index - 1);
        var result = prev.next!.data;
        var next = prev.next!.next;

        prev.next = next;
        next!.prev = prev;

        size--;
        return result;
    }

    public void Print()
    {
        Node<T>? cur = head;

        while (cur != null)
        {
            Console.Write($"{cur.data}->");

            cur = cur.next;
        }

        Console.WriteLine("[null]");
    }

    public int Size()
    {
        return size;
    }
}