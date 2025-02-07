namespace DSA;

public class LinkedList<T> where T : IComparable
{
    public int Length { get; private set; }
    public LinkedListNode<T>? Head { get; private set; }
    public LinkedListNode<T>? Tail { get; private set; }

    public void Prepend(T item)
    {
        var newNode = new LinkedListNode<T>(item);

        if (Head is not null)
        {
            newNode.Next = Head;
        }

        Head = newNode;

        if (Length == 0)
        {
            Tail = newNode;
        }

        Length++;
    }

    public void Append(T item)
    {
        var newNode = new LinkedListNode<T>(item);

        if (Tail is not null)
        {
            Tail.Next = newNode;
        }

        Tail = newNode;

        if (Length == 0)
        {
            Head = newNode;
        }

        Length++;
    }
    
    public void Insert(int index, T item)
    {
        if (index > Length || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var newNode = new LinkedListNode<T>(item);

        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
            Head.Next = Tail;
        }
        else if (index == 0)
        {
            newNode.Next = Head;
            Head = newNode;
        }
        else if (index == Length)
        {
            Tail!.Next = newNode;
            Tail = newNode;
        }
        else
        {
            var curr = Head;
            var idx = 0;
            while (idx != index - 1)
            {
                curr = Head!.Next;
                idx++;
            }

            newNode.Next = curr!.Next;
            curr.Next = newNode;
        }

        Length++;
    }

    public void Remove(T item)
    {
        if (Length == 0)
        {
            return;
        }

        while (Head is not null && Head.Data.Equals(item))
        {
            var temp = Head.Next;
            Head.Next = null;
            Head = temp;
            Length--;
        }

        if (Head is null)
        {
            Tail = null;
            return;
        }
        
        var curr = Head;

        while (curr!.Next != null)
        {
            while (curr.Next?.Data.Equals(item) ?? false)
            {
                var temp = curr.Next;
                curr.Next = curr.Next.Next;
                temp.Next = null;
                Length--;
            }

            curr = curr.Next;
        }
    }

    public T Get(int index)
    {
        if (index > Length - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var curr = Head;
        var idx = 0;
        while (idx != index)
        {
            idx++;
            curr = curr!.Next;
        }

        return curr!.Data;
    }

    public void RemoveAt(int index)
    {
        if (index > Length - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            Head = Head!.Next;
            Length--;
            return;
        }

        var curr = Head;
        var idx = 0;
        while (idx != index - 1)
        {
            idx++;
            curr = curr!.Next;
        }

        var temp = curr.Next.Next;
        curr.Next.Next = null;
        curr.Next = temp;

        Length--;
    }
    
}

public class LinkedListNode<T> where T : IComparable
{
    public T Data { get; }
    public LinkedListNode<T>? Next { get; internal set; }
    
    public LinkedListNode(T data)
    {
        Data = data;
    }
}