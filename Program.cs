using System;

public class MyList<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;
    private int count; // Dodane pole count

    public void Add(T data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        count++; // Zwiększ licznik po dodaniu elementu
    }

    public int Count // Dodana właściwość Count
    {
        get { return count; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index cannot be negative");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                if (current == null)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

                current = current.Next;
            }

            if (current == null)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            return current.Data;
        }
    }
}

class Program
{
    static void Main()
    {
        MyList<int> myList = new MyList<int>();
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);
        myList.Add(4);
        myList.Add(5);

        Console.WriteLine("List of even numbers:");
        for (int i = 0; i < myList.Count; i++)
        {
            if (myList[i] % 2 == 0)
            {
                Console.WriteLine(myList[i]);
            }
        }
    }
}

